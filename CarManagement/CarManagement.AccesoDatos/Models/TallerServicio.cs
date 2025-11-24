using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class TallerServicio
{
    public int TallerServicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
}
