using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string Placa { get; set; } = null!;

    public int? MarcaId { get; set; }

    public int? ModeloId { get; set; }

    public int? Año { get; set; }

    public string? Color { get; set; }

    public int? Kilometraje { get; set; }

    public int? TipoVehiculoId { get; set; }

    public DateOnly? FechaProximaRevision { get; set; }

    public int? EstadoId { get; set; }

    public string? Observaciones { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Combustible> Combustibles { get; set; } = new List<Combustible>();

    public virtual ICollection<Conductore> Conductores { get; set; } = new List<Conductore>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    public virtual Marca? Marca { get; set; }

    public virtual Modelo? Modelo { get; set; }

    public virtual TiposVehiculo? TipoVehiculo { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
