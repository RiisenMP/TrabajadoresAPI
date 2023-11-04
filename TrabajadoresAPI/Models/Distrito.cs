using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrabajadoresAPI.Models;

public partial class Distrito
{
    public int Id { get; set; }

    public int? IdProvincia { get; set; }

    public string? NombreDistrito { get; set; }

    [JsonIgnore]
    public virtual Provincia? IdProvinciaNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
}
