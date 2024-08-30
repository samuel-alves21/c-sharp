using Blog.Data;
using Blog.Extesions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers;

[ApiController]
public class AccountController(TokenService tokenService) : Controller
{
  private readonly TokenService _tokenService = tokenService;

  [HttpPost("v1/accounts/")]
  public async Task<IActionResult> Post([FromBody] RegisterViewModel model, [FromServices] BlogDataContext context)
  {
    if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

    string password = PasswordGenerator.Generate(25, true, false);

    User user = new User
    {
      Name = model.Name,
      Email = model.Email,
      Slug = model.Email.Replace("@", "-").Replace(".", "-"),
      PasswordHash = PasswordHasher.Hash(password)
    };

    try
    {
      await context.Users.AddAsync(user);
      await context.SaveChangesAsync();

      return Ok(new ResultViewModel<dynamic>(new
      {
        user = user.Email,
        password
      }));
    }
    catch (DbUpdateException)
    {
      return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
    }
    catch
    {
      return StatusCode(500, new ResultViewModel<string>("05X100 - Falha interna no servidor"));
    }
  }

  [HttpPost("v1/accounts/login")]
  async public Task<IActionResult> Login([FromBody] LoginViewModel model, [FromServices] BlogDataContext context, [FromServices] TokenService token)
  {
    if (!ModelState.IsValid) return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

    var user = await context.Users.AsNoTracking().Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email.ToLower() == model.Email.ToLower());

    if (user == null) return StatusCode(401, new ResultViewModel<string>("05X01 Usuário ou senha inválidos"));
    if (!PasswordHasher.Verify(user.PasswordHash, model.password)) return StatusCode(401, new ResultViewModel<string>("05X01 Usuário ou senha inválidos"));

    try
    {
      var userToken = tokenService.GenerateToken(user);
      return Ok(new ResultViewModel<string>(userToken, null));
    }
    catch
    {
      return StatusCode(500, new ResultViewModel<string>("05X100 - Falha interna no servidor"));
    }
  }
}