using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Clasificacion_BLL
    {

        //Read
        public static List<Clasificacion_VO> GetClasificacion(params object[] parametros)
        {
            return Clasificacion_DAL.GetClasififcacion(parametros);
        }
    }
}
