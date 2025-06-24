using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TrabajoPracticoCuponera.Context;
using TrabajoPracticoCuponera.Interfaces;

namespace TrabajoPracticoCuponera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponHistorialController : ControllerBase
    {
        private readonly ICuponHistorialService _historialService;
        private readonly ICuponService _cuponService;
        private readonly AppDbContext _context;

        public CuponHistorialController(
            ICuponHistorialService historialService,
            ICuponService cuponService,
            AppDbContext context)
        {
            _historialService = historialService;
            _cuponService = cuponService;
            _context = context;
        }

        // ✅ GET api/CuponHistorial/mio
        // Obtiene cupones reclamados por el cliente autenticado
        [Authorize(Roles = "Cliente")]
        [HttpGet("mio")]
        public async Task<IActionResult> ObtenerHistorialCliente()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized(new { mensaje = "No se encontró el id del usuario en el token." });
            }

            var historial = await _historialService.ObtenerHistorialPorUsuarioAsync(userId);
            return Ok(historial);
        }

        // ✅ POST api/CuponHistorial/reclamar/{nroCupon}
        // Reclama un cupón por parte del cliente autenticado
        [Authorize(Roles = "Cliente")]
        [HttpPost("reclamar/{nroCupon}")]
        public async Task<IActionResult> ReclamarCupon(string nroCupon)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                return Unauthorized(new { mensaje = "Usuario no autenticado." });

            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.User_Name == userName);
            if (user == null)
                return Unauthorized(new { mensaje = "Usuario no encontrado." });

            var exito = await _historialService.ReclamarCuponAsync(nroCupon, user.Id_Usuario);
            if (!exito)
                return BadRequest(new { mensaje = "No se pudo reclamar el cupón. Puede que ya haya sido reclamado o no exista." });

            return Ok(new { mensaje = "Cupón reclamado correctamente." });
        }
    }
}