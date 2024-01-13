using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Departamento
{
    public int Iddepartamento { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
