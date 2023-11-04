using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresAPI.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? NombreDepartamento { get; set; }

    [JsonIgnore]
    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();

    [JsonIgnore]
    public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
}
