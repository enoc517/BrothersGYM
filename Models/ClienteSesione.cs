using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class ClienteSesione
{
    public int IdclienteSesiones { get; set; }

    public int Idsesiones { get; set; }

    public DateTime FechaCita { get; set; }

    public bool Estado { get; set; }

    public virtual SesionesRayosUv IdsesionesNavigation { get; set; }
}
