using TrabajoPracticoCuponera.Dtos;

namespace TrabajoPracticoCuponera.Interfaces
{
    public interface ICuponService
    {
        Task<IEnumerable<CuponDTO>> ObtenerCuponesAsync();
        Task<CuponDTO> ObtenerCuponPorNroAsync(string nroCupon);
        Task<bool> CrearCuponAsync(CuponDTO dto);
        Task<bool> ActualizarCuponAsync(string nroCupon, CuponDTO dto);
        Task<bool> EliminarCuponAsync(string nroCupon);
    }
}
