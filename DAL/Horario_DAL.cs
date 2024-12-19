using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Horario_DAL
    {

        //Create
        public static string Insert_Horario(Hora_VO fechaHora)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_InsertarGenero",
                                               "@NombreGenero", fechaHora
                                                        );
                if (respuesta != 0)
                {
                    salida = "Fecha y hora registrada con exito";
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
        public static List<Hora_VO> GetHorario(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Hora_VO> list = new List<Hora_VO>();
            try
            {
                DataSet ds_Hora = Metodos_Datos.execute_DataSet("SP_ListadoHorario", parametros);
                foreach (DataRow dr in ds_Hora.Tables[0].Rows)
                {
                    list.Add(new Hora_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
