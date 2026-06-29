using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Sesion
{
    public int IdSesion { get; set; }

    public int IdUsuario { get; set; }

    public string? TokenHash { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public string? DireccionIp { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
