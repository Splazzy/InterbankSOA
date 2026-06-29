using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class TarjetaCredito
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

    public string? PinHash { get; set; }

    public string? CvvDinamico { get; set; }

    public bool? SwComprasInternet { get; set; }

    public bool? SwUsoExterior { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<MillasBenefit> MillasBenefits { get; set; } = new List<MillasBenefit>();

    public virtual ICollection<MovimientoTarjetum> MovimientoTarjeta { get; set; } = new List<MovimientoTarjetum>();
}
