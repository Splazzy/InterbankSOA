namespace InterbankSOA.API.DTOs
{
    public class VerDatosTarjetaResponseDTO
    {
        public int IdTarjeta { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateOnly? FechaVencimiento { get; set; }
        public string? CvvDinamico { get; set; }
        public bool? EstadoTarjeta { get; set; }
    }
}
