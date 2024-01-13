using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class FacturaPedido
{
    public int IdfacturaPedido { get; set; }

    public int Idproveedor { get; set; }

    public int Idproducto { get; set; }

    public int Idpedido { get; set; }

    public DateTime FechaEmision { get; set; }

    public decimal Iva { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Pedido IdpedidoNavigation { get; set; }

    public virtual Producto IdproductoNavigation { get; set; }

    public virtual Proveedor IdproveedorNavigation { get; set; }
}
