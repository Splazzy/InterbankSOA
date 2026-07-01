using InterbankSOA.API.Models;

namespace InterbankSOA.API.Services
{
    public class TarjetaService : ITarjetaService
    {
        public BloqueoTarjetaResponse BloquearTarjeta(BloqueoTarjetaRequest request)
        {
            return new BloqueoTarjetaResponse
            {
                CodigoRespuesta = "00",
                MensajeConfirmacion = $"La tarjeta {request.IdTarjeta} ha sido bloqueada por motivo de: {request.MotivoBloqueo}.",
                EstadoTarjeta = "Inactiva"
            };
        }
    }
}
