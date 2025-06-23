using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoCuponera.DTOs;
using TrabajoPracticoCuponera.Interfaces;

namespace TrabajoPracticoCuponera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDTO dto)
        {
            var success = await _usuarioService.CrearUsuarioAsync(dto, dto.Dni); // Usamos el DNI como contraseña temporal por defecto
            if (!success)
                return BadRequest("Nombre de usuario o email ya en uso.");

            return Ok("Usuario creado correctamente.");
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioDTO dto)
        {
            var success = await _usuarioService.ActualizarUsuarioAsync(id, dto);
            if (!success)
                return NotFound("Usuario no encontrado o datos duplicados.");

            return Ok("Usuario actualizado correctamente.");
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var success = await _usuarioService.EliminarUsuarioAsync(id);
            if (!success)
                return NotFound("Usuario no encontrado.");

            return Ok("Usuario eliminado correctamente.");
        }
    }
}

