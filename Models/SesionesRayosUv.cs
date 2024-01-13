using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class SesionesRayosUv
{
    public int Idsesiones { get; set; }

    public string Descripcion { get; set; }

    public int? Idcliente { get; set; }

    public int PaqueteSesionesId { get; set; }

    public virtual ICollection<ClienteSesione> ClienteSesiones { get; set; } = new List<ClienteSesione>();

    public virtual Cliente IdclienteNavigation { get; set; }

    public virtual PaquteSesione PaqueteSesiones { get; set; }
}
