using Microsoft.EntityFrameworkCore;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.DTOs;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Select(u => new UsuarioDTO
                {
                    Id_Usuario = u.Id_Usuario,
                    User_Name = u.User_Name,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Dni = u.Dni,
                    Email = u.Email,
                    Estado = u.Estado,
                    RolNombre = u.Rol.Nombre,
                    Id_Rol = u.Id_Rol
                })
                .ToListAsync();
        }

        public async Task<UsuarioDTO?> ObtenerUsuarioPorIdAsync(int id)
        {
            var u = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(x => x.Id_Usuario == id);

            if (u == null) return null;

            return new UsuarioDTO
            {
                Id_Usuario = u.Id_Usuario,
                User_Name = u.User_Name,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Dni = u.Dni,
                Email = u.Email,
                Estado = u.Estado,
                RolNombre = u.Rol.Nombre,
                Id_Rol = u.Id_Rol
            };
        }

        public async Task<bool> CrearUsuarioAsync(UsuarioDTO usuarioDto, string password)
        {
            // Verificar duplicados
            if (await _context.Usuarios.AnyAsync(u => u.User_Name == usuarioDto.User_Name || u.Email == usuarioDto.Email))
                return false;

            var nuevoUsuario = new UserModel
            {
                User_Name = usuarioDto.User_Name,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Dni = usuarioDto.Dni,
                Email = usuarioDto.Email,
                Estado = usuarioDto.Estado,
                Id_Rol = usuarioDto.Id_Rol
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarUsuarioAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            // Evitar duplicados al editar
            if (await _context.Usuarios.AnyAsync(u =>
                (u.User_Name == usuarioDto.User_Name || u.Email == usuarioDto.Email) &&
                u.Id_Usuario != id))
                return false;

            usuario.User_Name = usuarioDto.User_Name;
            usuario.Nombre = usuarioDto.Nombre;
            usuario.Apellido = usuarioDto.Apellido;
            usuario.Dni = usuarioDto.Dni;
            usuario.Email = usuarioDto.Email;
            usuario.Estado = usuarioDto.Estado;
            usuario.Id_Rol = usuarioDto.Id_Rol;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}