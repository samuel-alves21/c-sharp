using Blog.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddControllers();

WebApplication app = builder.Build();
app.MapControllers();

app.Run();
