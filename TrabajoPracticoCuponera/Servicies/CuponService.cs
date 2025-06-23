using Microsoft.EntityFrameworkCore;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Servicies
{
    public class CuponService : ICuponService
    {
        private readonly AppDbContext _context;

        public CuponService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CuponDTO>> ObtenerTodos()
        {
            return await _context.Cupones.Select(c => new CuponDTO
            {
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                PorcentajeDto = c.PorcentajeDto,
                ImportePromo = c.ImportePromo,
                FechaInicio = c.FechaInicio,
                FechaFin = c.FechaFin,
                Id_Tipo_Cupon = c.Id_Tipo_Cupon,
                Activo = c.Activo
            }).ToListAsync();
        }

        public async Task<List<CuponDTO>> ObtenerActivos()
        {
            var hoy = DateTime.Now.Date;
            return await _context.Cupones
                .Where(c => c.Activo && c.FechaInicio <= hoy && c.FechaFin >= hoy)
                .Select(c => new CuponDTO
                {
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    PorcentajeDto = c.PorcentajeDto,
                    ImportePromo = c.ImportePromo,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    Id_Tipo_Cupon = c.Id_Tipo_Cupon,
                    Activo = c.Activo
                }).ToListAsync();
        }

        public async Task<bool> CrearCuponConDetalleAsync(CuponDetalleDTO dto)
        {
            // Validación según tipo
            if (dto.Cupon.Id_Tipo_Cupon == 1 && !dto.Cupon.PorcentajeDto.HasValue)
                return false;

            if (dto.Cupon.Id_Tipo_Cupon == 2 && !dto.Cupon.ImportePromo.HasValue)
                return false;

            // Generar NroCupon aleatorio con formato 123-456-789
            string nroCupon;
            do
            {
                nroCupon = $"{GenerarSegmento()}-{GenerarSegmento()}-{GenerarSegmento()}";
            } while (await _context.Cupones.AnyAsync(c => c.NroCupon == nroCupon));

            var cupon = new CuponModel
            {
                NroCupon = nroCupon,
                Nombre = dto.Cupon.Nombre,
                Descripcion = dto.Cupon.Descripcion,
                PorcentajeDto = dto.Cupon.PorcentajeDto,
                ImportePromo = dto.Cupon.ImportePromo,
                FechaInicio = dto.Cupon.FechaInicio,
                FechaFin = dto.Cupon.FechaFin,
                Id_Tipo_Cupon = dto.Cupon.Id_Tipo_Cupon,
                Activo = dto.Cupon.Activo
            };

            _context.Cupones.Add(cupon);

            foreach (var item in dto.Detalles)
            {
                _context.CuponesDetalle.Add(new CuponDetalleModel
                {
                    NroCupon = cupon.NroCupon,
                    id_Articulo = item.Id_Articulo,
                    Cantidad = item.Cantidad
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerarSegmento()
        {
            var random = new Random();
            return random.Next(100, 999).ToString();
        }

        public async Task<bool> EliminarCuponAsync(string nroCupon)
        {
            var cupon = await _context.Cupones.FindAsync(nroCupon);
            if (cupon == null) return false;

            _context.Cupones.Remove(cupon);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<CuponDTO>> ObtenerCuponesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CuponDTO> ObtenerCuponPorIdAsync(string nroCupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CrearCuponAsync(CuponDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarCuponAsync(string nroCupon, CuponDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<CuponDTO> ObtenerCuponPorNroAsync(string nroCupon)
        {
            throw new NotImplementedException();
        }
    }
}
