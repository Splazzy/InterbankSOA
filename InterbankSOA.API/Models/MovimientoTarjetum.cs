using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class MovimientoTarjetum
{
    public int IdMovimiento { get; set; }

    public int? IdTarjeta { get; set; }

    public decimal? Monto { get; set; }

    public int? Cuotas { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public virtual TarjetaCredito? IdTarjetaNavigation { get; set; }
}
