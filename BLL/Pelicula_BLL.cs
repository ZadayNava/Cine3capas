using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Pelicula_BLL
    {

        //Create
        public static string Insert_Pelicula(Pelicula_VO Pelicula)
        {
            return Pelicula_DAL.Insert_Pelicula(Pelicula);
        }

        //Read
        public static List<Pelicula_VO> GetPelicula(params object[] parametros)
        {
            return Pelicula_DAL.GetPelicula(parametros);
        }

        //ReadxID
        public static Pelicula_VO GetPeliculaxID(int id)
        {
            return Pelicula_DAL.GetPeliculaxID(id);
        }

        //Update
        public static string Update_Pelicua(Pelicula_VO Pelicula)
        {
            return Pelicula_DAL.Update_Pelicula(Pelicula);
        }

        //Delete
        public static string Delete_Pelicula(int id)
        {
            return Pelicula_DAL.DeletePelicula(id);
        }
    }
}
