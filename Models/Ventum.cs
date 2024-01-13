using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Ventum
{
    public int Idventa { get; set; }

    public int Idempleado { get; set; }

    public int Idproducto { get; set; }

    public int Idcliente { get; set; }

    public int Cantidad { get; set; }

    public decimal Pago { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; }

    public virtual Empleado IdempleadoNavigation { get; set; }

    public virtual Producto IdproductoNavigation { get; set; }
}
