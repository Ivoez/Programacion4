using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoCuponera.Dtos;
using TrabajoPracticoCuponera.Models;

    
        namespace TrabajoPracticoCuponera.Interfaces
        {
        public interface IAuthService
        {
            Task<IActionResult> LoginAsync(LoginModel model);
            Task<IActionResult> RegisterAsync(RegistroUsuarioDTO dto);
        }
    }



