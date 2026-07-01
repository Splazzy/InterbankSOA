using Microsoft.AspNetCore.Mvc;
using InterbankSOA.API.Models;
using InterbankSOA.API.Services;

namespace InterbankSOA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _tarjetaService;

        public TarjetaController(ITarjetaService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }

        [HttpPost("bloquear")]
        public IActionResult Bloquear([FromBody] BloqueoTarjetaRequest request)
        {
            var result = _tarjetaService.BloquearTarjeta(request);
            return Ok(result);
        }
    }
}
