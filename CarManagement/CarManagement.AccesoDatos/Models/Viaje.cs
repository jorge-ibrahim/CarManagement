using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Viaje
{
    public int ViajeId { get; set; }

    public int? RutaId { get; set; }

    public int? VehiculoId { get; set; }

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public int? ConductorId { get; set; }

    public virtual Conductore? Conductor { get; set; }

    public virtual Ruta? Ruta { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
