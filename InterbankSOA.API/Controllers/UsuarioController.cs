using Microsoft.AspNetCore.Mvc;
using InterbankSOA.API.Services;
using InterbankSOA.API.DTOs;

namespace InterbankSOA.API.Controllers
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

        // Método GET que ya tenías
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        // NUEVO: Método POST
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioCreateDTO usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCreado = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return CreatedAtAction(nameof(GetUsuarios), new { id = usuarioCreado.IdUsuario }, usuarioCreado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var mensaje = await _usuarioService.LoginAsync(loginDto);
                return Ok(new { Mensaje = mensaje });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}