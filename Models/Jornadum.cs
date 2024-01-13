using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Jornadum
{
    public int Idjornada { get; set; }

    public int Idempleado { get; set; }

    public DateTime DiaHoraEntrada { get; set; }

    public DateTime DiaHoraSalida { get; set; }

    public decimal HorasTrabajadas { get; set; }

    public decimal SalarioBruto { get; set; }

    public virtual ICollection<HistorialPago> HistorialPagos { get; set; } = new List<HistorialPago>();

    public virtual Empleado IdempleadoNavigation { get; set; }
}
