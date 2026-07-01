using Microsoft.AspNetCore.Mvc;
using InterbankSOA.API.Models;
using InterbankSOA.API.Services;

namespace InterbankSOA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlinController : ControllerBase
    {
        private readonly IPlinService _plinService;

        public PlinController(IPlinService plinService)
        {
            _plinService = plinService;
        }

        [HttpPost("enviar")]
        public IActionResult EnviarPlin([FromBody] PlinearRequest request)
        {
            var response = _plinService.ProcesarPlin(request);
            return Ok(response);
        }
    }
}
