using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class DetallePedido
{
    public int IddetalleProducto { get; set; }

    public int Idpedido { get; set; }

    public int Idproducto { get; set; }

    public decimal PrecioUnidad { get; set; }

    public int Cantidad { get; set; }

    public decimal Descuento { get; set; }

    public virtual Pedido IdpedidoNavigation { get; set; }

    public virtual Producto IdproductoNavigation { get; set; }
}
