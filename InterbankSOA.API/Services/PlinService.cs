using InterbankSOA.API.Models;

namespace InterbankSOA.API.Services
{
    public class PlinService : IPlinService
    {
        public PlinearResponse ProcesarPlin(PlinearRequest request)
        {
            return new PlinearResponse
            {
                IdOperacion = "PLIN-" + Guid.NewGuid().ToString().Substring(0, 8),
                CodigoRespuesta = "00",
                MensajeConfirmacion = $"Transferencia de S/{request.Monto} enviada a {request.CelularDestino} exitosamente.",
                NuevoSaldo = 1499.00m
            };
        }
    }
}
