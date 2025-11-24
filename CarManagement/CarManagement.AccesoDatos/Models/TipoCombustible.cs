using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class TipoCombustible
{
    public int TipoCombustibleId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Combustible> Combustibles { get; set; } = new List<Combustible>();
}
