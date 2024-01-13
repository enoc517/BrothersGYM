using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public int IdcategoriaProducto { get; set; }

    public int Idproveedores { get; set; }

    public string Nombre { get; set; }

    public int CantidadUnidad { get; set; }

    public decimal PrecioUnidad { get; set; }

    public int Existentes { get; set; }

    public int Espera { get; set; }

    public string Imagen { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<FacturaPedido> FacturaPedidos { get; set; } = new List<FacturaPedido>();

    public virtual CategoriaProducto IdcategoriaProductoNavigation { get; set; }

    public virtual Proveedor IdproveedoresNavigation { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
