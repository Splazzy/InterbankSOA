namespace InterbankSOA.API.Models
{
    public class PlinearRequest
    {
        public string CuentaCargo { get; set; } = string.Empty;
        public string CelularDestino { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public string SessionToken { get; set; } = string.Empty;
    }

    public class PlinearResponse
    {
        public string IdOperacion { get; set; } = string.Empty;
        public string CodigoRespuesta { get; set; } = string.Empty;
        public string MensajeConfirmacion { get; set; } = string.Empty;
        public decimal NuevoSaldo { get; set; }
    }
}
