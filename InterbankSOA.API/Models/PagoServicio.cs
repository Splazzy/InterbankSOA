using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class PagoServicio
{
    public int IdPagoServicio { get; set; }

    public int? IdOperacion { get; set; }

    public int? IdServicio { get; set; }

    public string? CodigoCliente { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? Estado { get; set; }

    public virtual Operacion? IdOperacionNavigation { get; set; }

    public virtual CatalogoServicio? IdServicioNavigation { get; set; }
}
