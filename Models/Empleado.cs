using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public string Cedula { get; set; }

    public int Idpuesto { get; set; }

    public string CuentaBancaria { get; set; }

    public string NumeroSeguroSocial { get; set; }

    public string RetencionCcss { get; set; }

    public DateTime FechaContratacion { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

    public virtual Puesto IdpuestoNavigation { get; set; }

    public virtual ICollection<Jornadum> Jornada { get; set; } = new List<Jornadum>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
