using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Horario_BLL
    {
        //Read
        public static List<Hora_VO> GetHorario(params object[] parametros)
        {
            return Horario_DAL.GetHorario(parametros);
        }


        //Update
        public static string Update_Ticket(Ticket_VO ticket)
        {
            return Ticket_DAL.Update_Ticket(ticket);
        }

        //Delete
        public static string Delete_Ticket(int id)
        {
            return Ticket_DAL.DeleteTicket(id);
        }
    }
}
