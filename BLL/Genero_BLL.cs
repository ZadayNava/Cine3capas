using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Genero_BLL
    {

        //Read
        public static List<GeneroPelicula_VO> GetGenero(params object[] parametros)
        {
            return Genero_DAL.GetGenero(parametros);
        }
    }
}
