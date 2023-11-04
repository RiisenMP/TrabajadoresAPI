using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresAPI.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public int? IdDepartamento { get; set; }

    public string? NombreProvincia { get; set; }

    [JsonIgnore]
    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    [JsonIgnore]
    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
}
