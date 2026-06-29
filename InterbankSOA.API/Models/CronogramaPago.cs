using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class CronogramaPago
{
    public int IdCuota { get; set; }

    public int? IdPrestamo { get; set; }

    public int? NumeroCuota { get; set; }

    public decimal? MontoCuota { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? EstadoPago { get; set; }

    public virtual Prestamo? IdPrestamoNavigation { get; set; }
}
