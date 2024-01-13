using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Proveedor
{
    public int Idproveedores { get; set; }

    public string Nombre { get; set; }

    public string Telefono { get; set; }

    public string Direccion { get; set; }

    public virtual ICollection<FacturaPedido> FacturaPedidos { get; set; } = new List<FacturaPedido>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
