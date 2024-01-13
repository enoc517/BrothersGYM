using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int Idempleado { get; set; }

    public DateOnly FechaPedido { get; set; }

    public DateOnly FechaEntregaAprox { get; set; }

    public string Direccion { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<FacturaPedido> FacturaPedidos { get; set; } = new List<FacturaPedido>();

    public virtual Empleado IdempleadoNavigation { get; set; }
}
