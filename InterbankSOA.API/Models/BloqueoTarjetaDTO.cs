namespace InterbankSOA.API.Models
{
    public class BloqueoTarjetaRequest
    {
        public string IdTarjeta { get; set; } = string.Empty;
        public string SessionToken { get; set; } = string.Empty;
        public string MotivoBloqueo { get; set; } = string.Empty;
    }

    public class BloqueoTarjetaResponse
    {
        public string CodigoRespuesta { get; set; } = string.Empty;
        public string MensajeConfirmacion { get; set; } = string.Empty;
        public string EstadoTarjeta { get; set; } = string.Empty;
    }
}
