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





        public static ML.Result GetById(ML.Usuario usuario)
        {


            ML.Result result = new ML.Result();


            try
            {


                using (DL.EjramirezLaudexContext context = new DL.EjramirezLaudexContext())
                {

                    var query = context.Usuarios.FromSqlRaw($"GetById '{usuario.Email}'");


                    if (query.ToList().Count() > 0)
                    {

                        var row = query.ToList()[0];
                        
                        if(row.Pass == usuario.Pass)
                        {

                            result.Object = new object();

                            ML.Usuario User = new ML.Usuario();

                            User.IdUsuario = row.IdUsuario;
                            User.Nombre = row.Nombre;
                            User.ApellidoP = row.ApellidoP;
                            User.ApellidoM = row.ApellidoM; 
                            User.UserName = row.UserName;   
                            User.Email = row.Email;

                            result.Object = User;

                            result.Correct = true;

                        }
                        else
                        {

                            result.Correct = false;
                            result.Message = "Contraseña invalida, porfavor verifica";

                        }


                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "El usuario no fue encontrado, porfavor registrate primero";
                    }


                        
                }




            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = result.Ex.Message;
            }


            return result;



        }


















    }
}