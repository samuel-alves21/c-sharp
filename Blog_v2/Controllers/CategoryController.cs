using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
  [ApiController]
  public class CategoryController : ControllerBase
  {
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
      => Ok(await context.Categories.ToListAsync());

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetOneAsync([FromServices] BlogDataContext context, [FromRoute] int id)
    {
      if (context == null) return NotFound();
      return Ok(await context.Categories.FirstOrDefaultAsync((x) => x.Id == id));
    }

    [HttpPost("v1/categories/")]
    public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model)
    {
      try
      {
        Category category = new()
        {
          Id = 0,
          Name = model.Name,
          Slug = model.Slug.ToLower(),
          Posts = []
        };
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return Created($"v1/categories/{category.Id}", category);
      }
      catch (DbUpdateException)
      {
        return StatusCode(500, "Não foi possível incluir a categoria");
      }
      catch (Exception)
      {
        return StatusCode(500, "Falha interna no servidor");
      }
    }

    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model, [FromRoute] int id)
    {
      Category? category = await context.Categories.FirstOrDefaultAsync((x) => x.Id == id);

      if (category == null) return NotFound();

      category.Name = model.Name;
      category.Slug = model.Slug;

      context.Categories.Update(category);
      await context.SaveChangesAsync();

      return Ok(category);
    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
    {
      Category? category = await context.Categories.FirstOrDefaultAsync((x) => x.Id == id);

      if (category == null) return NotFound();

      context.Categories.Remove(category);
      await context.SaveChangesAsync();

      return Ok(category);
    }
  }
}