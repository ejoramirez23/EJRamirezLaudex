using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Task
    {


        public int IdTask { get; set; }

        public string TaskName { get; set; }

        public string Descripcion { get; set; }

        public string FechaCreacion { get; set; }

        public string  FechaVencimiento { get; set; }

        public ML.Estatus Estatus { get; set; }

        public ML.Prioridad Prioridad { get; set; }


    }
}
