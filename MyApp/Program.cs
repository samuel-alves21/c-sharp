var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{name}", (string name) => Results.Ok($"Name: {name}"));
app.MapPost("/", (User user) => Results.Ok(user));

app.Run();

public class User
{
  public string Name { get; set; } = "";
  public int Id { get; set; }
}
