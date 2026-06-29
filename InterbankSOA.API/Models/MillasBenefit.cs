using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class MillasBenefit
{
    public int IdMillas { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTarjeta { get; set; }

    public int? CantidadTotal { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public virtual ICollection<HistorialMilla> HistorialMillas { get; set; } = new List<HistorialMilla>();

    public virtual TarjetaCredito? IdTarjetaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
