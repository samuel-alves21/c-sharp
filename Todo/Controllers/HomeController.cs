using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  [ApiController]

  public class HomeController : ControllerBase
  {
    [HttpGet("/")]
    public IActionResult GetAll([FromServices] AppDbContext context) => Ok(context.Todos.ToList());

    [HttpPost("/")]
    public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
      if (todo == null) return BadRequest();
      context.Todos.Add(todo);
      context.SaveChanges();
      return Created($"/{todo.Id}", todo);
    }

    [HttpGet("/{id:int}")]
    public IActionResult GetOne([FromRoute] int id, [FromServices] AppDbContext context)
    {
      TodoModel? todo = context.Todos.FirstOrDefault(x => x.Id == id);
      if (todo == null) return NotFound();
      return Ok(todo);
    }

    [HttpPut("/{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
      TodoModel? model = context.Todos.FirstOrDefault(x => x.Id == id);
      if (todo == null || model == null) return NotFound();

      model.Title = todo.Title;
      model.Done = todo.Done;

      context.Update(model);
      context.SaveChanges();
      return Ok(todo);
    }

    [HttpDelete("/{id:int}")]
    public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
    {
      TodoModel? model = context.Todos.FirstOrDefault(x => x.Id == id);
      if (model == null) return NotFound();
      context.Remove(model);
      context.SaveChanges();
      return Ok(model);
    }
  }
}