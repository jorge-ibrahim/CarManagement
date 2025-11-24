using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Conductore
{
    public int ConductorId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? NumeroLicencia { get; set; }

    public int? CategoriaLicenciaId { get; set; }

    public DateOnly? FechaVencimientoLicencia { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? EstadoId { get; set; }

    public int? VehiculoId { get; set; }

    public bool Activo { get; set; }

    public virtual CategoriaLicencium? CategoriaLicencia { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
