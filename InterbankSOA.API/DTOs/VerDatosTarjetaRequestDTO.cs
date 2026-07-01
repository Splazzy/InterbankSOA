namespace InterbankSOA.API.DTOs
{
    public class VerDatosTarjetaRequestDTO
    {
        public int IdTarjeta { get; set; }
        public string? SessionToken { get; set; }
        public string? ClaveDinamica { get; set; }
    }
}
