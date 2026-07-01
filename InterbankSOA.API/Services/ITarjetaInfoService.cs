using InterbankSOA.API.DTOs;

namespace InterbankSOA.API.Services
{
    public interface ITarjetaInfoService
    {
        TarjetaDetalleDTO? GetTarjetaDetalle(int idTarjeta);
        TarjetaMovimientosResponseDTO? GetTarjetaMovimientos(int idTarjeta);
        VerDatosTarjetaResponseDTO? GetDatosTarjeta(int idTarjeta, string sessionToken, string claveDinamica);
    }
}
