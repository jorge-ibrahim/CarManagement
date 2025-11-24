using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class TiposVehiculo
{
    public int TipoVehiculoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
