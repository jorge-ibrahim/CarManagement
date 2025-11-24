using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Ruta
{
    public int RutaId { get; set; }

    public string? NombreRuta { get; set; }

    public string? Descripcion { get; set; }

    public int? Distancia { get; set; }

    public int? TiempoEstimado { get; set; }

    public string? PuntosControl { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
