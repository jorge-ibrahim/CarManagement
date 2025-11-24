using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class TipoDocumento
{
    public int TipoDocumentoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
