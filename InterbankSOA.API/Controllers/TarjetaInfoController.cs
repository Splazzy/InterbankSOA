using Microsoft.AspNetCore.Mvc;
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
    }
}
