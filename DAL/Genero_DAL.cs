using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Genero_DAL
    {

        //Create
        public static string Insert_Genero(GeneroPelicula_VO genero)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_InsertarGenero",
                                               "@NombreGenero", genero.Nombre_Genero
                                                        );
                if (respuesta != 0)
                {
                    salida = "Genero registrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Read
        public static List<GeneroPelicula_VO> GetGenero(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<GeneroPelicula_VO> list = new List<GeneroPelicula_VO>();
            try
            {
                DataSet ds_Pelicula = Metodos_Datos.execute_DataSet("SP_ListadoGenero", parametros);
                foreach (DataRow dr in ds_Pelicula.Tables[0].Rows)
                {
                    list.Add(new GeneroPelicula_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //Read
        public static GeneroPelicula_VO GetGeneroxID(int id)
        {
            //creo una lista de objetos vo
            GeneroPelicula_VO list = new GeneroPelicula_VO();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Peliculas = Metodos_Datos.execute_DataSet("SP_ListadoGeneroxID", "@Id_Genero", id);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Peliculas.Tables[0].Rows)
                {
                    list = new GeneroPelicula_VO(dr);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string Update_Genero(GeneroPelicula_VO gen)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_UpdateGenero",
                                               "@Id_Genero", gen.Id_Genero,
                                               "@Nombre_Genero", gen.Nombre_Genero
                    );

                if (respuesta != 0)
                {
                    salida = "Genero actualizada con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Delete
        public static string DeleteGenero(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_EliminarGenero",
                    "@Id", id
                    );
                if (respuesta != 0)
                {
                    salida = "Genero elimiado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

    }
}
