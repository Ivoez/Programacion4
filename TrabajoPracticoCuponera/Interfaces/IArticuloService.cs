using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoPracticoCuponera.Dtos;

namespace TrabajoPracticoCuponera.Interfaces
{
    public interface IArticuloService
    {
        Task<List<ArticuloDTO>> ObtenerTodosAsync();
        Task<ArticuloDTO?> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(ArticuloDTO dto);
        Task<bool> ActualizarAsync(int id, ArticuloDTO dto);
        Task<bool> EliminarAsync(int id);
    }
}
