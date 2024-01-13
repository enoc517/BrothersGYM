using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class CategoriaMembresium
{
    public int IdcategoriaMembresia { get; set; }

    public string Descripcion { get; set; }

    public double Precio { get; set; }

    public virtual ICollection<ClienteMembresium> ClienteMembresia { get; set; } = new List<ClienteMembresium>();
}
