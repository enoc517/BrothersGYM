using System;
using System.Collections.Generic;

namespace BrothersGYM.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Direccion { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Telefono { get; set; }

    public string Cedula { get; set; }

    public string Correo { get; set; }

    public string Estado { get; set; }

    public virtual ICollection<ClienteMembresium> ClienteMembresia { get; set; } = new List<ClienteMembresium>();

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public virtual ICollection<SesionesRayosUv> SesionesRayosUvs { get; set; } = new List<SesionesRayosUv>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
