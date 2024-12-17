using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Genero_DAL
    {

        //Read
        public static List<GeneroPelicula_VO> GetGenero(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<GeneroPelicula_VO> list = new List<GeneroPelicula_VO>();
            try
            {
                DataSet ds_Pelicula = Metodos_Datos.execute_DataSet("SP_ListadoGenero", parametros);
                foreach (DataRow dr in ds_Pelicula.Tables[0].Rows)
                {
                    list.Add(new GeneroPelicula_VO(dr));
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
