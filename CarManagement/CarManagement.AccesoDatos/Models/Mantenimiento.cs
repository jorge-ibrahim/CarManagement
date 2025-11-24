using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Mantenimiento
{
    public int MantenimientoId { get; set; }

    public int? VehiculoId { get; set; }

    public int? TipoMantenimientoId { get; set; }

    public DateOnly? FechaMantenimiento { get; set; }

    public string? Descripcion { get; set; }

    public int? Kilometraje { get; set; }

    public decimal? Costo { get; set; }

    public int? TallerServicioId { get; set; }

    public string? Observaciones { get; set; }

    public bool Activo { get; set; }

    public virtual TallerServicio? TallerServicio { get; set; }

    public virtual TipoMantenimiento? TipoMantenimiento { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
