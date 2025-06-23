using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;

namespace TrabajoPracticoCuponera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private readonly ICuponService _cuponService;

        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
        }

        // GET: api/Cupon
        [HttpGet]
        public async Task<IActionResult> ObtenerCupones()
        {
            var cupones = await _cuponService.ObtenerCuponesAsync();
            return Ok(cupones);
        }

        // GET: api/Cupon/NRO123
        [HttpGet("{nroCupon}")]
        public async Task<IActionResult> ObtenerCupon(string nroCupon)
        {
            var cupon = await _cuponService.ObtenerCuponPorNroAsync(nroCupon);
            if (cupon == null) return NotFound();
            return Ok(cupon);
        }

        // POST: api/Cupon
        [HttpPost]
        public async Task<IActionResult> CrearCupon([FromBody] CuponDTO cuponDto)
        {
            var creado = await _cuponService.CrearCuponAsync(cuponDto);
            if (!creado) return BadRequest("Ya existe un cupón con ese número.");
            return Ok("Cupón creado correctamente.");
        }

        // PUT: api/Cupon/NRO123
        [HttpPut("{nroCupon}")]
        public async Task<IActionResult> ActualizarCupon(string nroCupon, [FromBody] CuponDTO cuponDto)
        {
            var actualizado = await _cuponService.ActualizarCuponAsync(nroCupon, cuponDto);
            if (!actualizado) return NotFound("Cupón no encontrado.");
            return Ok("Cupón actualizado correctamente.");
        }

        // DELETE: api/Cupon/NRO123
        [HttpDelete("{nroCupon}")]
        public async Task<IActionResult> EliminarCupon(string nroCupon)
        {
            var eliminado = await _cuponService.EliminarCuponAsync(nroCupon);
            if (!eliminado) return NotFound("Cupón no encontrado.");
            return Ok("Cupón eliminado correctamente.");
        }
    }
}

