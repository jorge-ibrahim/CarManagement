using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Combustible
{
    public int CombustibleId { get; set; }

    public int? VehiculoId { get; set; }

    public DateTime FechaCarga { get; set; }

    public decimal? CantidadLitros { get; set; }

    public decimal? CostoTotal { get; set; }

    public int? Kilometraje { get; set; }

    public int? TipoCombustibleId { get; set; }

    public virtual TipoCombustible? TipoCombustible { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
