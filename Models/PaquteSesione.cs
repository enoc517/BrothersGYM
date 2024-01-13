using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class PaquteSesione
{
    public int PaqueteSesioensId { get; set; }

    public string Nombre { get; set; }

    public int? Cantidad { get; set; }

    public virtual ICollection<SesionesRayosUv> SesionesRayosUvs { get; set; } = new List<SesionesRayosUv>();
}
