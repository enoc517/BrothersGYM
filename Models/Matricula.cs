using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Matricula
{
    public int Idmartricula { get; set; }

    public int Idcliente { get; set; }

    public int Idclase { get; set; }

    public virtual Clase IdclaseNavigation { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; }
}
