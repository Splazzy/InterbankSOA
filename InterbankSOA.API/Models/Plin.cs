using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Plin
{
    public int IdPlin { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCuentaCargo { get; set; }

    public string? CelularAfiliado { get; set; }

    public string? BancoReceptor { get; set; }

    public bool? SwClaveDinamica { get; set; }

    public decimal? MontoSinClave { get; set; }

    public bool? AlertasActivas { get; set; }

    public virtual Cuentum? IdCuentaCargoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
