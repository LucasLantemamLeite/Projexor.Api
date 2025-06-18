using Projexor.Services.Token;

var builder = WebApplication.CreateBuilder(args);

JwtSettings.JwtToken = builder.Configuration.GetValue<string>("JwtSettings:JwtToken") ?? string.Empty;

var app = builder.Build();



app.Run();
