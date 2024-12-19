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
