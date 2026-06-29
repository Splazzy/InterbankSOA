using System;
using System.Collections.Generic;

namespace InterbankSOA.API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Dni { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string UsuarioDigital { get; set; } = null!;

    public string ClaveHash { get; set; } = null!;

    public string? HashBiometrico { get; set; }

    public string? Email { get; set; }

    public string? Celular { get; set; }

    public string? PerfilRiesgo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<AlertaConfig> AlertaConfigs { get; set; } = new List<AlertaConfig>();

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    public virtual ICollection<MillasBenefit> MillasBenefits { get; set; } = new List<MillasBenefit>();

    public virtual ICollection<Plin> Plins { get; set; } = new List<Plin>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();

    public virtual ICollection<TarjetaCredito> TarjetaCreditos { get; set; } = new List<TarjetaCredito>();
}
