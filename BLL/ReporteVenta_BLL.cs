using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class ReporteVenta_BLL
    {

        //Read
        public static List<ReporteVenta_VO> GetReporte(params object[] parametros)
        {
            return ReporteVenta_DAL.GetReporte(parametros);
        }
    }
}
