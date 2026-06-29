using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Dispositivo
{
    public int IdDispositivo { get; set; }

    public int? IdUsuario { get; set; }

    public string? MacAddress { get; set; }

    public string? SistemaOperativo { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
