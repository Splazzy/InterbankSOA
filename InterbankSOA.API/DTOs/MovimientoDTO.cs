namespace InterbankSOA.API.DTOs
{
    public class MovimientoDTO
    {
        public int IdMovimiento { get; set; }
        public int? IdTarjeta { get; set; }
        public decimal? Monto { get; set; }
        public int? Cuotas { get; set; }
        public DateTime? FechaHora { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public string? TipoMovimiento { get; set; }
    }
}
