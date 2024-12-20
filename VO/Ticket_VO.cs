using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Ticket_VO
    {

        private int _Id_Ticket;
        private Pelicula_VO _Pelicula;
        private Hora_VO _Hora;
        private Sala_VO _Sala;
        private Asiento_VO _Asiento;
        private Sucursal_VO _sucursal;

        public Ticket_VO(){
            _Id_Ticket = 0;
            _sucursal = new Sucursal_VO();
            _Asiento = new Asiento_VO();
            _Pelicula = new Pelicula_VO();
            _Hora = new Hora_VO();
            _Sala = new Sala_VO();
        }

        public Ticket_VO(DataRow dr)
        {
            _Id_Ticket = int.Parse(dr["Id_Ticket"].ToString());

            _sucursal = new Sucursal_VO
            {
                Id_Cine = int.Parse(dr["Id_Cine"].ToString()),
                Nombre_Cine = dr["Nombre_Cine"].ToString()
            };

            _Asiento = new Asiento_VO { 
                Id_Asiento = int.Parse(dr["Id_Asiento"].ToString()),
                Fila = dr["Fila"].ToString(),
                NumAsientos = int.Parse(dr["NumAsientos"].ToString())
            };

            _Pelicula = new Pelicula_VO { 
                Id_Pelicula = int.Parse(dr["Id_Pelicula"].ToString()),
                Nombre_Pelicula = dr["Nombre_Pelicula"].ToString()
            };

            _Hora = new Hora_VO { 
                Id_Horario = int.Parse(dr["Id_Horario"].ToString()),
                Fecha_Funcion = DateTime.Parse(dr["Fecha_Funcion"].ToString()).ToShortDateString(),
                Horario_Funcion = dr["Horario_Funcion"].ToString()

            };

            _Sala = new Sala_VO {
                Id_Sala = int.Parse(dr["Id_Sala"].ToString()),
                NomSala = dr["NomSala"].ToString()
            };

        }

        public int Id_Ticket { get => _Id_Ticket; set => _Id_Ticket = value; }
        public Hora_VO Hora { get => _Hora; set => _Hora = value; }
        public Sala_VO Sala { get => _Sala; set => _Sala = value; }
        public Asiento_VO Asiento { get => _Asiento; set => _Asiento = value; }
        public Pelicula_VO Pelicula { get => _Pelicula; set => _Pelicula = value; }
        public Sucursal_VO Sucursal { get => _sucursal; set => _sucursal = value; }
    }
}
