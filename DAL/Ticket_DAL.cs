using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class Ticket_DAL
    {
        //Create
        public static string Insert_Ticket(Ticket_VO ticket)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_InsertarTicket",
                                               "@Cine_id", ticket.Sucursal.Id_Cine,
                                               "@Pelicula_id", ticket.Pelicula.Id_Pelicula,
                                               "@Horario_id", ticket.Hora.Id_Horario,
                                               "@Sala_id", ticket.Sala.Id_Sala,
                                               "@costo", ticket.Costo
                                                        );
                if (respuesta != 0)
                {
                    salida = "Ruta registrada con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Read
        public static List<Ticket_VO> GetTicket(params object[] parametros)
        {
            //creo una lista de objetos vo
            List<Ticket_VO> list = new List<Ticket_VO>();
            try
            {
                DataSet ds_Ticket = Metodos_Datos.execute_DataSet("SP_ListadoTickets", parametros);
                foreach (DataRow dr in ds_Ticket.Tables[0].Rows)
                {
                    list.Add(new Ticket_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Read
        public static Ticket_VO GetTicketxID(int id)
        {
            //creo una lista de objetos vo
            Ticket_VO list = new Ticket_VO();
            try
            {
                //creo un dataSet el cual recibira lo que devuelva la ejecucion del metodo "execute_DataSet" de la clase "metodos_datos"
                DataSet ds_Ticket = Metodos_Datos.execute_DataSet("SP_ImpresionBoleto", "@id_Ticket", id);
                //recorro cada renglon existente de nuestro ds creando obetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_Ticket.Tables[0].Rows)
                {
                    list = new Ticket_VO(dr);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update
        public static string Update_Ticket(Ticket_VO ticket)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_UpdateTicket",
                                               "@Cine_Id", ticket.Sucursal.Id_Cine,
                                               "@Sala_Id", ticket.Sala.Id_Sala,
                                               "@Horario_Id", ticket.Hora.Id_Horario,
                                               "@Pelicula_Id", ticket.Pelicula.Id_Pelicula,
                                               "@id", ticket.Id_Ticket
                    );

                if (respuesta != 0)
                {
                    salida = "Rutas actualizada con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Delete
        public static string DeleteTicket(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.execute_nonQuery("SP_CancelarTicket",
                    "@Id", id
                    );
                if (respuesta != 0)
                {
                    salida = "Rutas elimiado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
    }
}
