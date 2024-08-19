using System.Text;
using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
byte[] key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication((x) =>
{
  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer((x) =>
{
  x.TokenValidationParameters = new()
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
  options.SuppressModelStateInvalidFilter = true;
});

WebApplication app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
