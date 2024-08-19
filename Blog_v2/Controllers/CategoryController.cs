using Blog.Data;
using Blog.Extesions;
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
    {
      try
      {
        List<Category> categories = await context.Categories.ToListAsync();
        return Ok(new ResultViewModel<List<Category>>(categories));
      }
      catch
      {
        return StatusCode(500, new ResultViewModel<List<Category>>("05X04 - falha interna no servidor"));
      }
    }

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetOneAsync([FromServices] BlogDataContext context, [FromRoute] int id)
    {
      try
      {
        Category? category = await context.Categories.FirstOrDefaultAsync((x) => x.Id == id);
        if (category == null) return NotFound(new ResultViewModel<Category>("05X03 - Conteúdo não encontrado"));
        return Ok(new ResultViewModel<Category>(category));
      }
      catch
      {
        return StatusCode(500, new ResultViewModel<List<Category>>("05X04 - falha interna no servidor"));
      }
    }

    [HttpPost("v1/categories/")]
    public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.GetErrors());
      }

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

        return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
      }
      catch (DbUpdateException)
      {
        return StatusCode(500, new ResultViewModel<Category>("Não foi possível incluir a categoria"));
      }
      catch (Exception)
      {
        return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
      }
    }

    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model, [FromRoute] int id)
    {
      Category? category = await context.Categories.FirstOrDefaultAsync((x) => x.Id == id);

      if (category == null) return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

      category.Name = model.Name;
      category.Slug = model.Slug;

      context.Categories.Update(category);
      await context.SaveChangesAsync();

      return Ok(new ResultViewModel<Category>(category));
    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
    {
      Category? category = await context.Categories.FirstOrDefaultAsync((x) => x.Id == id);

      if (category == null) return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

      context.Categories.Remove(category);
      await context.SaveChangesAsync();

      return Ok(new ResultViewModel<Category>(category));
    }
  }
}