using System;
using System.Collections.Generic;

namespace DL;

public partial class Task
{
    public int IdTask { get; set; }

    public string? TaskName { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? IdEstatus { get; set; }

    public int? IdPrioridad { get; set; }

    public virtual Estatus? IdEstatusNavigation { get; set; }

    public virtual Prioridad? IdPrioridadNavigation { get; set; }
}
