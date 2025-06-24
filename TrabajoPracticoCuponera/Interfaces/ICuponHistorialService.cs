using System.Collections.Generic;
using System.Threading.Tasks;
using TrabajoPracticoCuponera.Dtos;

namespace TrabajoPracticoCuponera.Interfaces
{
    public interface ICuponHistorialService
    {
        Task<bool> ReclamarCuponAsync(string nroCupon, int idUsuario);
        Task<List<CuponHistorialDTO>> ObtenerHistorialPorUsuarioAsync(int idUsuario);
    }
}