using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using volcanes_api_v2.Interfaces;
using volcanes_api_v2.Models;
using volcanes_api_v2.Services;
using volcanes_api_v2.Services.ServicesController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<VolcanDb2Context>(options =>
{
    options.UseMySql("name=ConnectionString", ServerVersion.Parse("11.1.2-mariadb"));
});

builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var tokenKey = Encoding.UTF8.GetBytes("name=JwtKey");
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
        
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();