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



        public static ML.Result Update(ML.Task task, int idUsuario)
        {

            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    int query = context.Database.ExecuteSqlRaw($"TaskUpdate {task.IdTask}, '{task.TaskName}', '{task.Descripcion}', '{task.FechaVencimiento}', {task.Estatus.IdEstatus}, {task.Prioridad.IdPrioridad}");

                    if (query > 0)
                    {

                        result.Correct = true;
                        result.Message = "Tarea actualizada correctamente";

                    }
                    else
                    {

                        result.Correct = false;
                        result.Message = "Ocurrio un problema al actualizar la tarea";

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




        public static ML.Result UpdateTaskCompleted(int idTask)
        {

            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    int query = context.Database.ExecuteSqlRaw($"TaskUpdateCompleted {idTask}");

                    if (query > 0)
                    {

                        result.Correct = true;
                        result.Message = "Tarea completada";

                    }
                    else
                    {

                        result.Correct = false;
                        result.Message = "Ocurrio un problema al completar la tarea";

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



        public static ML.Result UpdateTaskCanceled(int idTask)
        {


            ML.Result result = new ML.Result();


            try
            {

                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    int query = context.Database.ExecuteSqlRaw($"TaskUpdateCanceled {idTask}");

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Tarea cancelada";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "ocurrio un problema al cancelar la tarea";
                    }




                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex= ex;
                result.Message= "Ocurrio un error: "+ ex.Message;
            }
            



            return result;




        }




         public static ML.Result UpdateTaskPending(int idTask)
         {

            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    int query = context.Database.ExecuteSqlRaw($"TaskUpdatePending {idTask}");

                    if (query > 0)
                    {

                        result.Correct = true;
                        result.Message = "Tarea actualizada";

                    }
                    else
                    {

                        result.Correct = false;
                        result.Message = "Ocurrio un problema al actualizar la tarea";

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





        public static ML.Result GetById(int idUsuario, int idTask)
        {

            ML.Result result = new ML.Result();


            using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
            {


                var query = context.Tasks.FromSqlRaw($"TaskGetById {idUsuario}, {idTask}");



                if (query.ToList().Count() > 0)
                {

                    var rowTask = query.ToList()[0];


                    result.Object = new object();


                    ML.Task task = new ML.Task();   

                    task.IdTask = rowTask.IdTask;
                    task.TaskName = rowTask.TaskName;
                    task.Descripcion = rowTask.Descripcion;
                    task.Prioridad = new ML.Prioridad();
                    task.Prioridad.IdPrioridad = (int)rowTask.IdPrioridad;
                    task.FechaCreacion = rowTask.FechaCreacion == null ? "" :  rowTask.FechaCreacion.Value.Date.ToString("dd-MM-yyyy");
                    task.FechaVencimiento = rowTask.FechaVencimiento == null ? "" :  rowTask.FechaVencimiento.Value.Date.ToString("dd-MM-yyyy");
                    task.Estatus = new ML.Estatus();
                    task.Estatus.IdEstatus = (int)rowTask.IdEstatus;


                    result.Correct = true;
                    result.Object = task;




                }
                else
                {
                    result.Correct = false;
                    result.Message = "No se encontraron resultados";
                }



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
