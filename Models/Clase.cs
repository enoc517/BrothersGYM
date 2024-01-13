using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Clase
{
    public int Idclase { get; set; }

    public int Idempleado { get; set; }

    public int Idactividad { get; set; }

    public int Idsala { get; set; }

    public DateTime DiayHora { get; set; }

    public DateTime HoraFin { get; set; }

    public bool Estado { get; set; }

    public int Capacidad { get; set; }

    public virtual Actividad IdactividadNavigation { get; set; }

    public virtual Empleado IdempleadoNavigation { get; set; }

    public virtual Sala IdsalaNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
