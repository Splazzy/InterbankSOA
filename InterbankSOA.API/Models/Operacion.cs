using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Operacion
{
    public int IdOperacion { get; set; }

    public int? IdCuentaOrigen { get; set; }

    public int? IdCuentaDestino { get; set; }

    public string? TipoOperacion { get; set; }

    public decimal? Monto { get; set; }

    public string? Moneda { get; set; }

    public string? Concepto { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Estado { get; set; }

    public string? NumeroComprobante { get; set; }

    public virtual Cuentum? IdCuentaDestinoNavigation { get; set; }

    public virtual Cuentum? IdCuentaOrigenNavigation { get; set; }

    public virtual ICollection<PagoServicio> PagoServicios { get; set; } = new List<PagoServicio>();
}
