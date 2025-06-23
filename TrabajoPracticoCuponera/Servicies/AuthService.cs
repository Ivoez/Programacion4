using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context; 
            _config = config;
        }

        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var user = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.User_Name == model.User_Name);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                return new UnauthorizedObjectResult("Credenciales inválidas");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.User_Name),
                new Claim(ClaimTypes.Role, user.Rol.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new OkObjectResult(new
            {
                Mensaje = "Login Correcto",
                Token = tokenString,
                Vencimiento = DateTime.Now.AddHours(1),
                Rol = user.Rol.Nombre,
                User = user.User_Name
            });
        }

        public async Task<IActionResult> RegisterAsync(RegistroUsuarioDTO dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.User_Name == dto.User_Name))
                return new BadRequestObjectResult("El nombre de usuario ya existe.");

            var user = new UserModel
            {
                User_Name = dto.User_Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                Estado = true,
                Id_Rol = 2 // Cliente
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Usuario registrado correctamente.");
        }
    }
}