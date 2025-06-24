using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Interfaces;

namespace TrabajoPracticoCuponera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/Articulo
        [HttpGet]
        public async Task<ActionResult<List<ArticuloDTO>>> GetAll()
        {
            var articulos = await _articuloService.ObtenerTodosAsync();
            return Ok(articulos);
        }

        // GET: api/Articulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDTO>> GetById(int id)
        {
            var articulo = await _articuloService.ObtenerPorIdAsync(id);
            if (articulo == null)
                return NotFound();

            return Ok(articulo);
        }

        // POST: api/Articulo
        [HttpPost]
        public async Task<ActionResult> Create(ArticuloDTO dto)
        {
            var result = await _articuloService.CrearAsync(dto);
            if (!result)
                return BadRequest("No se pudo crear el artículo.");

            return CreatedAtAction(nameof(GetById), new { id = dto.Id_Articulo }, dto);
        }

        // PUT: api/Articulo/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ArticuloDTO dto)
        {
            var result = await _articuloService.ActualizarAsync(id, dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Articulo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _articuloService.EliminarAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}