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

                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {

                    int query = context.Database.ExecuteSqlRaw($"TaskAdd {idUsuario}, '{task.TaskName}', '{task.Descripcion}', '{task.FechaVencimiento}', {task.Estatus.IdEstatus}, {task.Prioridad.IdPrioridad}");

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
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error: " + ex.Message;
            }

            return result;


        }





        public static ML.Result GetAll(int idUsuario, string txtSearch, string dtFechaVencimiento)
        {

            ML.Result result = new ML.Result();

            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    var query = context.Tasks.FromSqlRaw($"TaskGetAll {idUsuario}, '{txtSearch}', '{dtFechaVencimiento}'");


                    if (query.ToList().Count() > 0)
                    {


                        result.Objects = new List<object>();



                        foreach (var taskEF in query.ToList())
                        {

                            ML.Task task = new ML.Task();


                            task.IdTask = (int)taskEF.IdTask;
                            task.TaskName = taskEF.TaskName == null ? taskEF.TaskName = "" : (string)taskEF.TaskName;
                            task.Descripcion = taskEF.Descripcion == null ? "" : (string)taskEF.Descripcion;
                            task.FechaCreacion = taskEF.FechaVencimiento == null ? "" : taskEF.FechaVencimiento.Value.Date.ToString("dd-MM-yyyy");
                            task.FechaVencimiento = taskEF.FechaVencimiento == null ? "" : taskEF.FechaVencimiento.Value.Date.ToString("dd-MM-yyyy");
                            task.Estatus = new ML.Estatus();
                            task.Estatus.IdEstatus = (int)taskEF.IdEstatus;
                            task.Prioridad = new ML.Prioridad();
                            task.Prioridad.IdPrioridad = (int)taskEF.IdPrioridad;


                            result.Objects.Add(task);


                        }

                        result.Correct = true;


                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron resultados";
                    }


                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;

        }












    }
}
