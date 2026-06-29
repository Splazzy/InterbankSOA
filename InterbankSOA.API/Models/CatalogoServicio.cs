using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class CatalogoServicio
{
    public int IdServicio { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? CodigoEmpresa { get; set; }

    public string? CategoriaServicio { get; set; }

    public bool? EstadoActivo { get; set; }

    public virtual ICollection<PagoServicio> PagoServicios { get; set; } = new List<PagoServicio>();
}
