using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Sala_BLL
    {
        //Read
        public static List<Sala_VO> GetSala(params object[] parametros)
        {
            return Sala_DAL.GetSala(parametros);
        }
        //Delete
        public static string Delete_Sala(int id)
        {
            return Sala_DAL.DeleteSala(id);
        }

        //Create
        public static string Insert_Sala(Sala_VO sala)
        {
            return Sala_DAL.Insert_Sala(sala);
        }

    }
}
