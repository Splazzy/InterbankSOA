using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class HistorialMilla
{
    public int IdHistorial { get; set; }

    public int? IdMillas { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaMov { get; set; }

    public virtual MillasBenefit? IdMillasNavigation { get; set; }
}
