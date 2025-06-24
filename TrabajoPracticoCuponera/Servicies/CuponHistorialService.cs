using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;
using TrabajoPracticoCuponera.Models;

namespace TrabajoPracticoCuponera.Servicies
{
    public class CuponHistorialService : ICuponHistorialService
    {
        private readonly AppDbContext _context;

        public CuponHistorialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ReclamarCuponAsync(string nroCupon, int idUsuario)
        {
            var cupon = await _context.Cupones.FirstOrDefaultAsync(c => c.NroCupon == nroCupon && c.Activo);
            if (cupon == null)
                return false;

            bool yaReclamo = await _context.CuponesHistorial.AnyAsync(h => h.NroCupon == nroCupon && h.Id_Usuario == idUsuario);
            if (yaReclamo)
                return false;

            var nuevoHistorial = new CuponHistorialModel
            {
                NroCupon = nroCupon,
                FechaUso = DateTime.Now,
                Id_Usuario = idUsuario
            };

            _context.CuponesHistorial.Add(nuevoHistorial);
            cupon.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CuponHistorialDTO>> ObtenerHistorialPorUsuarioAsync(int idUsuario)
        {
            var historial = await _context.CuponesHistorial
                .Where(h => h.Id_Usuario == idUsuario)
                .Include(h => h.Usuario)
                .Select(h => new CuponHistorialDTO
                {
                    Id_Historial = h.Id_Historial,
                    NroCupon = h.NroCupon,
                    FechaUso = h.FechaUso,
                    Id_Usuario = h.Id_Usuario,
                    UsuarioNombre = h.Usuario.User_Name
                })
                .ToListAsync();

            return historial;
        }
    }
}