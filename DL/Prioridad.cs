using System;
using System.Collections.Generic;

namespace DL;

public partial class Prioridad
{
    public int IdPrioridad { get; set; }

    public string Prioridad1 { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
