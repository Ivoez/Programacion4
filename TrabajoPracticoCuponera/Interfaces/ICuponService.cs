using TrabajoPracticoCuponera.Dtos;

namespace TrabajoPracticoCuponera.Interfaces
{
    public interface ICuponService
    {
        Task<List<CuponDTO>> ObtenerTodosAsync();
        Task<List<CuponDTO>> ObtenerActivosAsync();
        Task<CuponDTO?> ObtenerPorNroAsync(string nroCupon);
        Task<bool> CrearAsync(CuponDTO dto);
        Task<bool> ActualizarAsync(string nroCupon, CuponDTO dto);
        Task<bool> EliminarAsync(string nroCupon);
    }
}
