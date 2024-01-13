using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Puesto
{
    public int Idpuesto { get; set; }

    public string Nombre { get; set; }

    public decimal PagHora { get; set; }

    public int Iddepartamento { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Departamento IddepartamentoNavigation { get; set; }
}
