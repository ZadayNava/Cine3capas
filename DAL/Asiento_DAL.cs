using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Asiento_DAL
    {
        //Create
        public static string Insert_Asiento(Asiento_VO asiento)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("[SP_InsertarAsientos]",
                                               "@NumAsientos", asiento.NumAsientos,
                                               "@fila", asiento.Fila,
                                               "@Sala_Id", asiento.Sala_Id
                                                        );
                if (respuesta != 0)
                {
                    salida = "Asiento registrado con exito";
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
        public static List<Asiento_VO> GetAsiento(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Asiento_VO> list = new List<Asiento_VO>();
            try
            {
                DataSet ds_Asiento = Metodos_Datos.execute_DataSet("SP_ListadoAsientos", parametros);
                foreach (DataRow dr in ds_Asiento.Tables[0].Rows)
                {
                    list.Add(new Asiento_VO(dr));
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
