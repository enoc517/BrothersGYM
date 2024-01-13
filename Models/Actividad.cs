using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Actividad
{
    public int Idactividad { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
