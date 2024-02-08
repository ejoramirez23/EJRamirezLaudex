using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {


        public static ML.Result GetAll()
        {



            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {

                    var query = context.Estatuses.FromSqlRaw($"EstatusGetAll");

                    if (query.ToList().Count() > 0)
                    {

                        result.Objects = new List<object>();


                        foreach (var item in query.ToList())
                        {

                            ML.Estatus estatus = new ML.Estatus();

                            estatus.IdEstatus = item.IdEstatus;
                            estatus.EstatusName = item.Estatus1;


                            result.Objects.Add(estatus);

                        }


                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron estatus";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error: " + result.Ex.Message;
            }





            return result;



        }


    }
}
