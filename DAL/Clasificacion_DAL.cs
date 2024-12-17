using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public  class Clasificacion_DAL
    {

        //Read
        public static List<Clasificacion_VO> GetClasififcacion(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Clasificacion_VO> list = new List<Clasificacion_VO>();
            try
            {
                DataSet ds_Pelicula = Metodos_Datos.execute_DataSet("SP_ListadoClasificicacion", parametros);
                foreach (DataRow dr in ds_Pelicula.Tables[0].Rows)
                {
                    list.Add(new Clasificacion_VO(dr));
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
