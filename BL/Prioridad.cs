using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Prioridad
    {


        public static ML.Result GetAll()
        {



            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {

                    var query = context.Prioridads.FromSqlRaw($"PrioridadGetAll");

                    if (query.ToList().Count() > 0)
                    {

                        result.Objects = new List<object>();


                        foreach (var item in query.ToList())
                        {

                            ML.Prioridad prioridad = new ML.Prioridad();    

                            prioridad.IdPrioridad = item.IdPrioridad;
                            prioridad.PrioridadName = item.Prioridad1;


                            result.Objects.Add(prioridad);
                            
                        }


                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron prioridades";
                    }

                }


            }
            catch(Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error: " + result.Ex.Message;
            }





            return result;



        }


    }
}
