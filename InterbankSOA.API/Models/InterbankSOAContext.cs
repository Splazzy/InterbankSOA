using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InterbankSOA.API.Models;

public partial class InterbankSOAContext : DbContext
{
    public InterbankSOAContext()
    {
    }

    public InterbankSOAContext(DbContextOptions<InterbankSOAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlertaConfig> AlertaConfigs { get; set; }

    public virtual DbSet<CatalogoServicio> CatalogoServicios { get; set; }

    public virtual DbSet<CronogramaPago> CronogramaPagos { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<HistorialMilla> HistorialMillas { get; set; }

    public virtual DbSet<MillasBenefit> MillasBenefits { get; set; }

    public virtual DbSet<MovimientoTarjetum> MovimientoTarjeta { get; set; }

    public virtual DbSet<Operacion> Operacions { get; set; }

    public virtual DbSet<PagoServicio> PagoServicios { get; set; }

    public virtual DbSet<Plin> Plins { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Sesion> Sesions { get; set; }

    public virtual DbSet<TarjetaCredito> TarjetaCreditos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=InterbankSOA;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlertaConfig>(entity =>
        {
            entity.HasKey(e => e.IdConfig).HasName("PK__AlertaCo__79F217648D808BBA");

            entity.ToTable("AlertaConfig");

            entity.Property(e => e.Canal)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoAlerta)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AlertaConfigs)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__AlertaCon__IdUsu__75A278F5");
        });

        modelBuilder.Entity<CatalogoServicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Catalogo__2DCCF9A23A2C04DE");

            entity.ToTable("CatalogoServicio");

            entity.Property(e => e.CategoriaServicio)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CronogramaPago>(entity =>
        {
            entity.HasKey(e => e.IdCuota).HasName("PK__Cronogra__0899C1489B12013B");

            entity.ToTable("CronogramaPago");

            entity.Property(e => e.EstadoPago)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MontoCuota).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.CronogramaPagos)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK__Cronogram__IdPre__693CA210");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuenta__D41FD706B57599CE");

            entity.HasIndex(e => e.Cci, "UQ__Cuenta__C1FF090665CECE30").IsUnique();

            entity.HasIndex(e => e.NumeroCuenta, "UQ__Cuenta__E039507B8ADC0659").IsUnique();

            entity.Property(e => e.Cci)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCI");
            entity.Property(e => e.LimiteDiarioTrx).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SaldoContable).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.SaldoDisponible).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoMoneda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuenta__IdUsuari__59063A47");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.IdDispositivo).HasName("PK__Disposit__B1EDB8E45FAF822A");

            entity.ToTable("Dispositivo");

            entity.Property(e => e.MacAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SistemaOperativo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Dispositi__IdUsu__5441852A");
        });

        modelBuilder.Entity<HistorialMilla>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__9CC7DBB4E4EA8BD1");

            entity.Property(e => e.FechaMov).HasColumnType("datetime");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMillasNavigation).WithMany(p => p.HistorialMillas)
                .HasForeignKey(d => d.IdMillas)
                .HasConstraintName("FK__Historial__IdMil__7C4F7684");
        });

        modelBuilder.Entity<MillasBenefit>(entity =>
        {
            entity.HasKey(e => e.IdMillas).HasName("PK__MillasBe__052E071E913D4A2B");

            entity.ToTable("MillasBenefit");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.MillasBenefits)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK__MillasBen__IdTar__797309D9");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MillasBenefits)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__MillasBen__IdUsu__787EE5A0");
        });

        modelBuilder.Entity<MovimientoTarjetum>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__881A6AE092078ADE");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.MovimientoTarjeta)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK__Movimient__IdTar__66603565");
        });

        modelBuilder.Entity<Operacion>(entity =>
        {
            entity.HasKey(e => e.IdOperacion).HasName("PK__Operacio__7778456BF02D137D");

            entity.ToTable("Operacion");

            entity.Property(e => e.Concepto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NumeroComprobante)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TipoOperacion)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCuentaDestinoNavigation).WithMany(p => p.OperacionIdCuentaDestinoNavigations)
                .HasForeignKey(d => d.IdCuentaDestino)
                .HasConstraintName("FK__Operacion__IdCue__6383C8BA");

            entity.HasOne(d => d.IdCuentaOrigenNavigation).WithMany(p => p.OperacionIdCuentaOrigenNavigations)
                .HasForeignKey(d => d.IdCuentaOrigen)
                .HasConstraintName("FK__Operacion__IdCue__628FA481");
        });

        modelBuilder.Entity<PagoServicio>(entity =>
        {
            entity.HasKey(e => e.IdPagoServicio).HasName("PK__PagoServ__3CD758CE169AFBD2");

            entity.ToTable("PagoServicio");

            entity.Property(e => e.CodigoCliente)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnType("datetime");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.PagoServicios)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK__PagoServi__IdOpe__71D1E811");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.PagoServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__PagoServi__IdSer__72C60C4A");
        });

        modelBuilder.Entity<Plin>(entity =>
        {
            entity.HasKey(e => e.IdPlin).HasName("PK__Plin__FB8143A01200BBCC");

            entity.ToTable("Plin");

            entity.Property(e => e.BancoReceptor)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.CelularAfiliado)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MontoSinClave).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.IdCuentaCargoNavigation).WithMany(p => p.Plins)
                .HasForeignKey(d => d.IdCuentaCargo)
                .HasConstraintName("FK__Plin__IdCuentaCa__6D0D32F4");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Plins)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Plin__IdUsuario__6C190EBB");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__6FF194C08AE9539D");

            entity.ToTable("Prestamo");

            entity.Property(e => e.EstadoPrestamo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.SaldoPendiente).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prestamo__IdUsua__5EBF139D");
        });

        modelBuilder.Entity<Sesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__Sesion__22EC535BEFD4C0C0");

            entity.ToTable("Sesion");

            entity.Property(e => e.DireccionIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DireccionIP");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Sesions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sesion__IdUsuari__5165187F");
        });

        modelBuilder.Entity<TarjetaCredito>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta).HasName("PK__TarjetaC__6AF43C1511072027");

            entity.ToTable("TarjetaCredito");

            entity.Property(e => e.AliasTarjeta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CvvDinamico)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DeudaTotal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.LimiteCredito).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NumeroEnmascarado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PinHash)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TarjetaCreditos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__TarjetaCr__IdUsu__5BE2A6F2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF974C936892");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.UsuarioDigital, "UQ__Usuario__131A3385433FFD1E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345374EE3A").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__Usuario__C035B8DD3ADE285C").IsUnique();

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClaveHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HashBiometrico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.PerfilRiesgo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioDigital)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
