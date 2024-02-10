using System;
using System.Collections.Generic;

namespace DL;

public partial class TaskUser
{
    public int? IdTask { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Task? IdTaskNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
