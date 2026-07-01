using System.Linq;
using InterbankSOA.API.DTOs;
using InterbankSOA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InterbankSOA.API.Services
{
    public class TarjetaInfoService : ITarjetaInfoService
    {
        private readonly InterbankSOAContext _context;

        public TarjetaInfoService(InterbankSOAContext context)
        {
            _context = context;
        }

        public TarjetaDetalleDTO? GetTarjetaDetalle(int idTarjeta)
        {
            var tarjeta = _context.TarjetaCreditos
                .AsNoTracking()
                .FirstOrDefault(t => t.IdTarjeta == idTarjeta);

            if (tarjeta == null)
                return null;

            return new TarjetaDetalleDTO
            {
                IdTarjeta = tarjeta.IdTarjeta,
                IdUsuario = tarjeta.IdUsuario,
                NumeroEnmascarado = tarjeta.NumeroEnmascarado,
                AliasTarjeta = tarjeta.AliasTarjeta,
                LimiteCredito = tarjeta.LimiteCredito,
                DeudaTotal = tarjeta.DeudaTotal,
                FechaVencimiento = tarjeta.FechaVencimiento,
                DiaPago = tarjeta.DiaPago,
                DiaCierre = tarjeta.DiaCierre,
                EstadoActivo = tarjeta.EstadoActivo,
                SwComprasInternet = tarjeta.SwComprasInternet,
                SwUsoExterior = tarjeta.SwUsoExterior
            };
        }

        public TarjetaMovimientosResponseDTO? GetTarjetaMovimientos(int idTarjeta)
        {
            var tarjeta = _context.TarjetaCreditos
                .AsNoTracking()
                .FirstOrDefault(t => t.IdTarjeta == idTarjeta);

            if (tarjeta == null)
                return null;

            var tarjetaDto = new TarjetaDetalleDTO
            {
                IdTarjeta = tarjeta.IdTarjeta,
                IdUsuario = tarjeta.IdUsuario,
                NumeroEnmascarado = tarjeta.NumeroEnmascarado,
                AliasTarjeta = tarjeta.AliasTarjeta,
                LimiteCredito = tarjeta.LimiteCredito,
                DeudaTotal = tarjeta.DeudaTotal,
                FechaVencimiento = tarjeta.FechaVencimiento,
                DiaPago = tarjeta.DiaPago,
                DiaCierre = tarjeta.DiaCierre,
                EstadoActivo = tarjeta.EstadoActivo,
                SwComprasInternet = tarjeta.SwComprasInternet,
                SwUsoExterior = tarjeta.SwUsoExterior
            };

            var tarjetaMovimientos = _context.MovimientoTarjeta
                .AsNoTracking()
                .Where(m => m.IdTarjeta == idTarjeta)
                .Select(m => new MovimientoDTO
                {
                    IdMovimiento = m.IdMovimiento,
                    IdTarjeta = m.IdTarjeta,
                    Monto = m.Monto,
                    Cuotas = m.Cuotas,
                    FechaHora = m.FechaHora,
                    Descripcion = m.Descripcion,
                    Estado = m.Estado,
                    TipoMovimiento = "Tarjeta"
                })
                .ToList();

            return new TarjetaMovimientosResponseDTO
            {
                Tarjeta = tarjetaDto,
                Movimientos = tarjetaMovimientos
            };
        }
    }
}
