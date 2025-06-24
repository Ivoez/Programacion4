using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly AppDbContext _context;

        public ArticuloService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArticuloDTO>> ObtenerTodosAsync()
        {
            return await _context.Articulos
                .Select(a => new ArticuloDTO
                {
                    Id_Articulo = a.Id_Articulo,
                    Nombre_Articulo = a.Nombre_Articulo,
                    Descripcion_Articulo = a.Descripcion_Articulo,
                    Activo = a.Activo,
                    Precio = a.Precio
                }).ToListAsync();
        }

        public async Task<ArticuloDTO?> ObtenerPorIdAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return null;

            return new ArticuloDTO
            {
                Id_Articulo = articulo.Id_Articulo,
                Nombre_Articulo = articulo.Nombre_Articulo,
                Descripcion_Articulo = articulo.Descripcion_Articulo,
                Activo = articulo.Activo,
                Precio = articulo.Precio
            };
        }

        public async Task<bool> CrearAsync(ArticuloDTO dto)
        {
            var articulo = new ArticuloModel
            {
                Nombre_Articulo = dto.Nombre_Articulo,
                Descripcion_Articulo = dto.Descripcion_Articulo,
                Activo = dto.Activo,
                Precio = dto.Precio
            };

            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarAsync(int id, ArticuloDTO dto)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return false;

            articulo.Nombre_Articulo = dto.Nombre_Articulo;
            articulo.Descripcion_Articulo = dto.Descripcion_Articulo;
            articulo.Activo = dto.Activo;
            articulo.Precio = dto.Precio;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return false;

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}