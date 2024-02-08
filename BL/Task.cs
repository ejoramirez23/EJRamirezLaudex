using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Task
    {


        public static ML.Result Add(ML.Task task, int idUsuario)
        {

            ML.Result result = new ML.Result();


            try
            {

                using(DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {

                    int query = context.Database.ExecuteSqlRaw($"TaskAdd {idUsuario}, '{task.TaskName}', '{task.Descripcion}', '{task.FechaCreacion}', '{task.FechaVencimiento}', {task.Estatus.IdEstatus}, {task.Prioridad.IdPrioridad}");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Tarea agregada exitosamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar tarea";
                    }

                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error: " + ex.Message;    
            }

            return result;


        }



    }
}
