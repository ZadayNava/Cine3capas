using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Pelicula_DAL
    {

        //Create
        public static string Insert_Pelicula(Pelicula_VO pelicula)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_InsertarPelicula",
                                               "@Clasificacion_Id", pelicula.ClasifiicacionPelicula.Id_Clasificacion1,
                                               "@NombrePelicula", pelicula.Nombre_Pelicula,
                                               "@Genero_Id", pelicula.GeneroPelicula.Id_Genero
                                                        );
                if (respuesta != 0)
                {
                    salida = "Ruta registrada con exito";
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
        public static List<Pelicula_VO> GetPelicula(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Pelicula_VO> list = new List<Pelicula_VO>();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Pelicula = Metodos_Datos.execute_DataSet("SP_ListadoPeliculas", parametros);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Pelicula.Tables[0].Rows)
                {
                    list.Add(new Pelicula_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Read
        public static Pelicula_VO GetPeliculaxID(int id)
        {
            //creo una lista de objetos vo
            Pelicula_VO list = new Pelicula_VO();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Peliculas = Metodos_Datos.execute_DataSet("SP_ListadoPeliculasxID", "@Id_Pelicula", id);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Peliculas.Tables[0].Rows)
                {
                    list = new Pelicula_VO(dr);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string Update_Pelicula(Pelicula_VO Pelicula)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_UpdatePelciula",
                                               "@Clasificacion_id", Pelicula.ClasifiicacionPelicula.Id_Clasificacion1,
                                               "@NombrePelicula", Pelicula.Nombre_Pelicula,
                                               "@Genero_id", Pelicula.GeneroPelicula.Id_Genero,
                                               "@Id", Pelicula.Id_Pelicula
                    );

                if (respuesta != 0)
                {
                    salida = "Rutas actualizada con exito";
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
        public static string DeletePelicula(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_EliminarPelicula",
                    "@Id", id
                    );
                if (respuesta != 0)
                {
                    salida = "Rutas elimiado con exito";
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
