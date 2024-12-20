using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class ReporteVenta_DAL
    {

        //Read
        public static List<ReporteVenta_VO> GetReporte(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<ReporteVenta_VO> list = new List<ReporteVenta_VO>();
            try
            {
                DataSet ds_Reporte = Metodos_Datos.execute_DataSet("SP_ReporteVenta", parametros);
                foreach (DataRow dr in ds_Reporte.Tables[0].Rows)
                {
                    list.Add(new ReporteVenta_VO(dr));
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
