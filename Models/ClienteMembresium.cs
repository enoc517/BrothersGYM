using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class ClienteMembresium
{
    public int IdclienteMembresia { get; set; }

    public int Idcliente { get; set; }

    public int IdcategoriaMembresia { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaRenovacion { get; set; }

    public virtual CategoriaMembresium IdcategoriaMembresiaNavigation { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; }
}
