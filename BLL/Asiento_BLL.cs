using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Asiento_BLL
    {

        //Create
        public static string Insert_Pelicula(Pelicula_VO Pelicula)
        {
            return Pelicula_DAL.Insert_Pelicula(Pelicula);
        }

        //Read
        public static List<Asiento_VO> GetAsiento(params object[] parametros)
        {
            return Asiento_DAL.GetAsiento(parametros);
        }
        //Delete
        public static string Delete_Genero(int id)
        {
            return Genero_DAL.DeleteGenero(id);
        }
    }
}
