using InterbankSOA.API.Models;

namespace InterbankSOA.API.Services
{
    public interface ITarjetaService
    {
        BloqueoTarjetaResponse BloquearTarjeta(BloqueoTarjetaRequest request);
    }
}
