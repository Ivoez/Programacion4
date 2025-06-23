using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;

namespace TrabajoPracticoCuponera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponController : ControllerBase
    {
        private readonly ICuponService _cuponService;

        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
        }

        // GET: api/Cupon
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var cupones = await _cuponService.ObtenerTodosAsync();
            return Ok(cupones);
        }

        // GET: api/Cupon/tipoC
        [HttpGet("tipos")]
        public async Task<IActionResult> GetTipos()
        {
            var tipos = await _cuponService.ObtenerTiposAsync();
            return Ok(tipos);
        }



        // GET: api/Cupon/activos
        [HttpGet("activos")]
        public async Task<IActionResult> ObtenerActivos()
        {
            var cupones = await _cuponService.ObtenerActivosAsync();
            return Ok(cupones);
        }

        // GET: api/Cupon/{nroCupon}
        [HttpGet("{nroCupon}")]
        public async Task<IActionResult> ObtenerPorNro(string nroCupon)
        {
            var cupon = await _cuponService.ObtenerPorNroAsync(nroCupon);
            if (cupon == null)
                return NotFound(new { mensaje = "Cupón no encontrado." });

            return Ok(cupon);
        }

        // POST: api/Cupon
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Crear([FromBody] CuponDTO dto)
        {
            var creado = await _cuponService.CrearAsync(dto);
            if (!creado)
                return BadRequest(new { mensaje = "No se pudo crear el cupón. Verifique los datos." });

            return Ok(new { mensaje = "Cupón creado correctamente." });
        }

        // PUT: api/Cupon/{nroCupon}
        [HttpPut("{nroCupon}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar(string nroCupon, [FromBody] CuponDTO dto)
        {
            var actualizado = await _cuponService.ActualizarAsync(nroCupon, dto);
            if (!actualizado)
                return NotFound(new { mensaje = "No se encontró el cupón a actualizar." });

            return Ok(new { mensaje = "Cupón actualizado correctamente." });
        }

        // DELETE: api/Cupon/{nroCupon}
        [HttpDelete("{nroCupon}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(string nroCupon)
        {
            var eliminado = await _cuponService.EliminarAsync(nroCupon);
            if (!eliminado)
                return NotFound(new { mensaje = "No se encontró el cupón a eliminar." });

            return Ok(new { mensaje = "Cupón eliminado correctamente." });
        }
    }
}