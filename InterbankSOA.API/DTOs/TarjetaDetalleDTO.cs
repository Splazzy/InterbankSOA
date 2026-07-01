namespace InterbankSOA.API.DTOs
{
    public class TarjetaDetalleDTO
    {
        public int IdTarjeta { get; set; }
        public int? IdUsuario { get; set; }
        public string? NumeroEnmascarado { get; set; }
        public string? AliasTarjeta { get; set; }
        public decimal? LimiteCredito { get; set; }
        public decimal? DeudaTotal { get; set; }
        public DateOnly? FechaVencimiento { get; set; }
        public int? DiaPago { get; set; }
        public int? DiaCierre { get; set; }
        public bool? EstadoActivo { get; set; }
        public bool? SwComprasInternet { get; set; }
        public bool? SwUsoExterior { get; set; }
    }
}
