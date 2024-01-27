using System;
using System.Collections.Generic;

namespace DL;

public partial class Estatus
{
    public int IdEstatus { get; set; }

    public string Estatus1 { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
