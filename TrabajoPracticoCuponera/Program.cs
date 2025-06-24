using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;
using TrabajoPracticoCuponera.Services;
using TrabajoPracticoCuponera.Servicies;

var builder = WebApplication.CreateBuilder(args);

// DATABASE 


string connectionString = builder.Configuration.GetConnectionString("conexion");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Configurar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });








// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/////////////////////////////////// mis servicios
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICuponService, CuponService>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();

var app = builder.Build();





















// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
