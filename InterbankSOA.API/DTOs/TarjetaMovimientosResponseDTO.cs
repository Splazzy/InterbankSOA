namespace InterbankSOA.API.DTOs
{
    public class TarjetaMovimientosResponseDTO
    {
        public TarjetaDetalleDTO? Tarjeta { get; set; }
        public IEnumerable<MovimientoDTO>? Movimientos { get; set; }
    }
}
