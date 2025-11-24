using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Incidente
{
    public int IncidenteId { get; set; }

    public int? VehiculoId { get; set; }

    public DateTime FechaIncidente { get; set; }

    public string Descripcion { get; set; } = null!;

    public byte[]? FotoAdjunta { get; set; }

    public int? EstadoId { get; set; }

    public string? Responsable { get; set; }

    public bool Activo { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
