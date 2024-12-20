﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class Ticket_BLL
    {

        //Create
        public static string Insert_Ticket(Ticket_VO ticket)
        {
            return Ticket_DAL.Insert_Ticket(ticket);
        }

        //Read
        public static List<Ticket_VO> GetTicket(params object[] parametros)
        {
            return Ticket_DAL.GetTicket(parametros);
        }

        //ReadxID
        public static Ticket_VO GetTicketxID(int id)
        {
            return Ticket_DAL.GetTicketxID(id);
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
