using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BL
{
    public class Usuario
    {

        public static ML.Result Add(ML.Usuario usuario)
        {


            ML.Result result = new ML.Result();


            try
            {


                using(DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {


                    int query = context.Database.ExecuteSqlRaw($"AddUsuario '{usuario.Nombre}', '{usuario.ApellidoP}' , '{usuario.ApellidoM}'  , '{usuario.UserName}'  , '{usuario.Email}' , '{usuario.Pass}' ");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Usuario registrado exitosamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al registrar usuario";
                    }


                }




            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = result.Ex.Message;
            }


            return result;



        }

    }
}