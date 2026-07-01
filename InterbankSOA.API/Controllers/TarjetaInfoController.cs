using Microsoft.AspNetCore.Mvc;
using InterbankSOA.API.DTOs;
using InterbankSOA.API.Services;

namespace InterbankSOA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarjetaInfoController : ControllerBase
    {
        private readonly ITarjetaInfoService _tarjetaInfoService;

        public TarjetaInfoController(ITarjetaInfoService tarjetaInfoService)
        {
            _tarjetaInfoService = tarjetaInfoService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTarjeta(int id)
        {
            var tarjeta = _tarjetaInfoService.GetTarjetaDetalle(id);
            if (tarjeta == null)
                return NotFound(new { Error = "Tarjeta no encontrada." });

            return Ok(tarjeta);
        }

        [HttpGet("{id}/movimientos")]
        public IActionResult GetMovimientos(int id)
        {
            var movimientos = _tarjetaInfoService.GetTarjetaMovimientos(id);
            if (movimientos == null)
                return NotFound(new { Error = "Tarjeta no encontrada." });

            return Ok(movimientos);
        }

        [HttpPost("datos-sensibles")]
        public IActionResult GetDatosTarjeta([FromBody] VerDatosTarjetaRequestDTO request)
        {
            if (request == null)
                return BadRequest(new { Error = "Solicitud inválida." });

            var datos = _tarjetaInfoService.GetDatosTarjeta(request.IdTarjeta, request.SessionToken ?? string.Empty, request.ClaveDinamica ?? string.Empty);
            if (datos == null)
                return Unauthorized(new { Error = "Acceso denegado. Validación de seguridad fallida." });

            return Ok(datos);
        }
    }
}
