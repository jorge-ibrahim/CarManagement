using System;
using System.Collections.Generic;

namespace CarManagement.AccesoDatos.Models;

public partial class Documento
{
    public int DocumentoId { get; set; }

    public int? VehiculoId { get; set; }

    public int? TipoDocumentoId { get; set; }

    public string? NumeroDocumento { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public decimal? Costo { get; set; }

    public bool Activo { get; set; }

    public virtual TipoDocumento? TipoDocumento { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
