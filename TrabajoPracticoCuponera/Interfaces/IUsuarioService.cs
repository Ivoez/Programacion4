using TrabajoPracticoCuponera.DTOs;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosAsync();
        Task<UsuarioDTO?> ObtenerUsuarioPorIdAsync(int id);
        Task<bool> CrearUsuarioAsync(UsuarioDTO usuarioDto, string password);
        Task<bool> ActualizarUsuarioAsync(int id, UsuarioDTO usuarioDto);
        Task<bool> EliminarUsuarioAsync(int id);
    }
}