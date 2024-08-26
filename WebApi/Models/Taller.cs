using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Taller
{
    public int IdTaller { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }
}
