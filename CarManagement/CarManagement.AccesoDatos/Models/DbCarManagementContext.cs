using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.AccesoDatos.Models;

public partial class DbCarManagementContext : DbContext
{
    public DbCarManagementContext()
    {
    }

    public DbCarManagementContext(DbContextOptions<DbCarManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaLicencium> CategoriaLicencia { get; set; }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<Conductore> Conductores { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Incidente> Incidentes { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<TallerServicio> TallerServicios { get; set; }

    public virtual DbSet<TipoCombustible> TipoCombustibles { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-59FQ4HV\\SQLEXPRESS; database= DbCarManagement; Persist Security Info=True;User ID=sa;Password=fiorela;Pooling=False;MultipleActiveResultSets=False;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaLicencium>(entity =>
        {
            entity.HasKey(e => e.CategoriaLicenciaId).HasName("PK__Categori__88581D1BF5F085CB");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.HasKey(e => e.CombustibleId).HasName("PK__Combusti__EA82AB3B32003943");

            entity.ToTable("Combustible");

            entity.Property(e => e.CantidadLitros).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaCarga).HasColumnType("datetime");

            entity.HasOne(d => d.TipoCombustible).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.TipoCombustibleId)
                .HasConstraintName("FK__Combustib__TipoC__6FE99F9F");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Combustibles)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Combustib__Vehic__6EF57B66");
        });

        modelBuilder.Entity<Conductore>(entity =>
        {
            entity.HasKey(e => e.ConductorId).HasName("PK__Conducto__BDDAB6800AD0DE4A");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.NumeroLicencia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoriaLicencia).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.CategoriaLicenciaId)
                .HasConstraintName("FK__Conductor__Categ__4D94879B");

            entity.HasOne(d => d.Estado).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Conductor__Estad__4CA06362");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Conductor__Vehic__4E88ABD4");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC76E0C605CF");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .HasConstraintName("FK__Documento__TipoD__5629CD9C");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Documento__Vehic__5535A963");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B0005299500");

            entity.ToTable("Estado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(e => e.IncidenteId).HasName("PK__Incident__16C7A36AADA2E65F");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaIncidente).HasColumnType("datetime");
            entity.Property(e => e.Responsable).HasMaxLength(100);

            entity.HasOne(d => d.Estado).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Incidente__Estad__693CA210");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Incidente__Vehic__68487DD7");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.MantenimientoId).HasName("PK__Mantenim__A62E61A26AE4F111");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.TallerServicio).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.TallerServicioId)
                .HasConstraintName("FK__Mantenimi__Talle__619B8048");

            entity.HasOne(d => d.TipoMantenimiento).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.TipoMantenimientoId)
                .HasConstraintName("FK__Mantenimi__TipoM__60A75C0F");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Mantenimi__Vehic__5FB337D6");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas__D5B1CD8B94333070");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.ModeloId).HasName("PK__Modelos__FA60529A07641D57");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.RutaId).HasName("PK__Rutas__7B61998EF04F2E9F");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.NombreRuta).HasMaxLength(100);
            entity.Property(e => e.PuntosControl).HasMaxLength(500);
        });

        modelBuilder.Entity<TallerServicio>(entity =>
        {
            entity.HasKey(e => e.TallerServicioId).HasName("PK__TallerSe__C4176A07087763C0");

            entity.ToTable("TallerServicio");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCombustible>(entity =>
        {
            entity.HasKey(e => e.TipoCombustibleId).HasName("PK__TipoComb__A94761B6EA351271");

            entity.ToTable("TipoCombustible");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__TipoDocu__A329EA8761F07969");

            entity.ToTable("TipoDocumento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoMantenimiento>(entity =>
        {
            entity.HasKey(e => e.TipoMantenimientoId).HasName("PK__TipoMant__CF3911C764DEC478");

            entity.ToTable("TipoMantenimiento");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposVehiculo>(entity =>
        {
            entity.HasKey(e => e.TipoVehiculoId).HasName("PK__TiposVeh__1EA21D0D3D3EF3D5");

            entity.ToTable("TiposVehiculo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08860035E256E2");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).HasMaxLength(500);
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Estado).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Vehiculos__Estad__45F365D3");

            entity.HasOne(d => d.Marca).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK__Vehiculos__Marca__4316F928");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ModeloId)
                .HasConstraintName("FK__Vehiculos__Model__440B1D61");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoVehiculoId)
                .HasConstraintName("FK__Vehiculos__TipoV__44FF419A");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.ViajeId).HasName("PK__Viajes__D76D88CC79F49ED7");

            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");

            entity.HasOne(d => d.Conductor).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.ConductorId)
                .HasConstraintName("FK__Viajes__Conducto__74AE54BC");

            entity.HasOne(d => d.Ruta).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.RutaId)
                .HasConstraintName("FK__Viajes__RutaId__72C60C4A");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK__Viajes__Vehiculo__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
