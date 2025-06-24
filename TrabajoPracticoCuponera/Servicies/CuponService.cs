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

        // Obtener todos los cupones
        public async Task<List<CuponDTO>> ObtenerTodosAsync()
        {
            return await _context.Cupones
                .Select(c => new CuponDTO
                {
                    NroCupon = c.NroCupon,
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

        // Obtener solo los activos y vigentes
        public async Task<List<CuponDTO>> ObtenerActivosAsync()
        {
            var hoy = DateTime.Today;
            return await _context.Cupones
                .Where(c => c.Activo && c.FechaInicio <= hoy && c.FechaFin >= hoy)
                .Select(c => new CuponDTO
                {
                    NroCupon = c.NroCupon,
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

        // Obtener uno por su número
        public async Task<CuponDTO?> ObtenerPorNroAsync(string nroCupon)
        {
            var cupon = await _context.Cupones
                .Include(c => c.Detalles)
                    .ThenInclude(d => d.Articulo)
                .FirstOrDefaultAsync(c => c.NroCupon == nroCupon);

            if (cupon == null) return null;

            return new CuponDTO
            {
                NroCupon = cupon.NroCupon,
                Nombre = cupon.Nombre,
                Descripcion = cupon.Descripcion,
                PorcentajeDto = cupon.PorcentajeDto,
                ImportePromo = cupon.ImportePromo,
                FechaInicio = cupon.FechaInicio,
                FechaFin = cupon.FechaFin,
                Id_Tipo_Cupon = cupon.Id_Tipo_Cupon,
                Activo = cupon.Activo,
                Detalles = cupon.Detalles.Select(d => new CuponDetalleDTO
                {
                    Id_Articulo = d.id_Articulo,
                    Cantidad = d.Cantidad,
                    
                }).ToList()
            };
        }

        //obtener el tipo de cupon 
        public async Task<List<TipoCuponDTO>> ObtenerTiposAsync()
        {
            return await _context.TipoCupones
                .Select(t => new TipoCuponDTO
                {
                    Id_Tipo_Cupon = t.Id_Tipo_Cupon,
                    Nombre = t.Nombre
                }).ToListAsync();
        }





        // Crear cupón
        public async Task<bool> CrearAsync(CuponDTO dto)
        {
            // Validar tipo de cupón
            if (dto.Id_Tipo_Cupon == 1 && !dto.PorcentajeDto.HasValue) return false;
            if (dto.Id_Tipo_Cupon == 2 && !dto.ImportePromo.HasValue) return false;

            string nroCupon;
            do
            {
                nroCupon = $"{Segmento()}-{Segmento()}-{Segmento()}";
            } while (await _context.Cupones.AnyAsync(c => c.NroCupon == nroCupon));

            var cupon = new CuponModel
            {
                NroCupon = nroCupon,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PorcentajeDto = dto.PorcentajeDto,
                ImportePromo = dto.ImportePromo,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Id_Tipo_Cupon = dto.Id_Tipo_Cupon,
                Activo = dto.Activo
            };

            _context.Cupones.Add(cupon);

            if (dto.Detalles?.Any() == true)
            {
                foreach (var item in dto.Detalles)
                {
                    _context.CuponesDetalle.Add(new CuponDetalleModel
                    {
                        NroCupon = nroCupon,
                        id_Articulo = item.Id_Articulo,
                        Cantidad = item.Cantidad
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        // Actualizar cupón
        public async Task<bool> ActualizarAsync(string nroCupon, CuponDTO dto)
        {
            var cupon = await _context.Cupones
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.NroCupon == nroCupon);

            if (cupon == null) return false;

            cupon.Nombre = dto.Nombre;
            cupon.Descripcion = dto.Descripcion;
            cupon.PorcentajeDto = dto.PorcentajeDto;
            cupon.ImportePromo = dto.ImportePromo;
            cupon.FechaInicio = dto.FechaInicio;
            cupon.FechaFin = dto.FechaFin;
            cupon.Id_Tipo_Cupon = dto.Id_Tipo_Cupon;
            cupon.Activo = dto.Activo;

            // Borrar detalle anterior y agregar nuevo
            _context.CuponesDetalle.RemoveRange(cupon.Detalles);

            if (dto.Detalles?.Any() == true)
            {
                foreach (var item in dto.Detalles)
                {
                    _context.CuponesDetalle.Add(new CuponDetalleModel
                    {
                        NroCupon = nroCupon,
                        id_Articulo = item.Id_Articulo,
                        Cantidad = item.Cantidad
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar cupón
        public async Task<bool> EliminarAsync(string nroCupon)
        {
            var cupon = await _context.Cupones
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.NroCupon == nroCupon);

            if (cupon == null) return false;

            _context.CuponesDetalle.RemoveRange(cupon.Detalles);
            _context.Cupones.Remove(cupon);

            await _context.SaveChangesAsync();
            return true;
        }

        private string Segmento() => new Random().Next(100, 999).ToString();

      
    }
}
