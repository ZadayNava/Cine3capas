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
