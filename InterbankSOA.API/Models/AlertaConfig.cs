using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class AlertaConfig
{
    public int IdConfig { get; set; }

    public int? IdUsuario { get; set; }

    public string? TipoAlerta { get; set; }

    public string? Canal { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
