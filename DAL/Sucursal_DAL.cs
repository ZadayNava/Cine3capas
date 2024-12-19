using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Sucursal_DAL
    {
        //Read
        public static List<Sucursal_VO> GetSucursal(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Sucursal_VO> list = new List<Sucursal_VO>();
            try
            {
                DataSet ds_Sucursal = Metodos_Datos.execute_DataSet("SP_ListadoSucursal", parametros);
                foreach (DataRow dr in ds_Sucursal.Tables[0].Rows)
                {
                    list.Add(new Sucursal_VO(dr));
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
