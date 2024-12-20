using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Sala_DAL
    {

        //Create
        public static string Insert_Sala(Sala_VO sala)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_InsertarSala",
                                               "@NomSala", sala.NomSala,
                                               "@tipoSala", sala.TipoSala,
                                               "@Asientos_Id", sala.Asientos_ID
                                                        );
                if (respuesta != 0)
                {
                    salida = "Sala registrado con exito";
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
        public static List<Sala_VO> GetSala(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Sala_VO> list = new List<Sala_VO>();
            try
            {
                DataSet ds_Sala = Metodos_Datos.execute_DataSet("SP_ListadoSalas", parametros);
                foreach (DataRow dr in ds_Sala.Tables[0].Rows)
                {
                    list.Add(new Sala_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Read
        public static Sala_VO GetSalaxID(int id)
        {
            //creo una lista de objetos vo
            Sala_VO list = new Sala_VO();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_sala = Metodos_Datos.execute_DataSet("SP_ListadoSalaxID", "@Id_Sala", id);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_sala.Tables[0].Rows)
                {
                    list = new Sala_VO(dr);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string Update_Sala (Sala_VO sala)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_UpdateSala",
                                               "@NomSala", sala.NomSala,
                                               "@tipoSala", sala.TipoSala,
                                               "@Asientos_ID", sala.Asientos_ID,
                                               "@Id", sala.Id_Sala
                    );

                if (respuesta != 0)
                {
                    salida = "Sala actualizada con exito";
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
        public static string DeleteSala(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_EliminarSala",
                    "@Id", id
                    );
                if (respuesta != 0)
                {
                    salida = "Sala elimiado con exito";
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
