using Projexor.Data.Context;
using Projexor.Services.Token;

var builder = WebApplication.CreateBuilder(args);

JwtSettings.JwtToken = builder.Configuration.GetValue<string>("JwtSettings:JwtToken") ?? string.Empty;
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
