using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class HistorialPago
{
    public int IdhistorialPago { get; set; }

    public string Descripcion { get; set; }

    public int Idjornada { get; set; }

    public virtual Jornadum IdjornadaNavigation { get; set; }
}
