using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Sucursal_BLL
    {
        //Read
        public static List<Sucursal_VO> GetSucursal(params object[] parametros)
        {
            return Sucursal_DAL.GetSucursal(parametros);
        }
    }
}
