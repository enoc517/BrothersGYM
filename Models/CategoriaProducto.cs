using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class CategoriaProducto
{
    public int IdcategoriaProducto { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
