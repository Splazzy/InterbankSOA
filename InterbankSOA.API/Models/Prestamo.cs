using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? MontoOriginal { get; set; }

    public decimal? SaldoPendiente { get; set; }

    public int? NumeroCuotas { get; set; }

    public int? PlazoMeses { get; set; }

    public decimal? TasaInteres { get; set; }

    public string? EstadoPrestamo { get; set; }

    public virtual ICollection<CronogramaPago> CronogramaPagos { get; set; } = new List<CronogramaPago>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
