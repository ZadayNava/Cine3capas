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
    { //Read
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
    }
}
