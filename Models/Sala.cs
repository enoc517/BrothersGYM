using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Sala
{
    public int Idsala { get; set; }

    public int Cupo { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
