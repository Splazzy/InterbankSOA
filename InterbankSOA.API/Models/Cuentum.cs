using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Cuentum
{
    public int IdCuenta { get; set; }

    public int IdUsuario { get; set; }

    public string? NumeroCuenta { get; set; }

    public string? Cci { get; set; }

    public string? TipoCuenta { get; set; }

    public string? TipoMoneda { get; set; }

    public decimal? SaldoDisponible { get; set; }

    public decimal? SaldoContable { get; set; }

    public decimal? LimiteDiarioTrx { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Operacion> OperacionIdCuentaDestinoNavigations { get; set; } = new List<Operacion>();

    public virtual ICollection<Operacion> OperacionIdCuentaOrigenNavigations { get; set; } = new List<Operacion>();

    public virtual ICollection<Plin> Plins { get; set; } = new List<Plin>();
}
