using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class CategoriaLicencium
{
    public int CategoriaLicenciaId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Conductore> Conductores { get; set; } = new List<Conductore>();
}
