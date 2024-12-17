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
        private int _Cine_Id;
        private int _Pelicula_Id;
        private int _Horario_Id;
        private int _Sala_Id;
        private float _Costo;

        public Ticket_VO(){
            _Id_Ticket = 0;
            _Cine_Id = 0;
            _Pelicula_Id = 0;
            _Horario_Id = 0;
            _Sala_Id = 0;
            _Costo = 0;
        }

        public Ticket_VO(DataRow dr)
        {
            _Id_Ticket = int.Parse(dr["Id_Ticket"].ToString());
            _Cine_Id = int.Parse(dr["Cine_Id"].ToString());
            _Pelicula_Id = int.Parse(dr["Pelicula_Id"].ToString());
            _Horario_Id = int.Parse(dr["Horario_Id"].ToString());
            _Sala_Id = int.Parse(dr["Sala_Id"].ToString());
            _Costo = float.Parse(dr["Costo"].ToString());
        }

        public int Id_Ticket { get => _Id_Ticket; set => _Id_Ticket = value; }
        public int Cine_Id { get => _Cine_Id; set => _Cine_Id = value; }
        public int Pelicula_Id { get => _Pelicula_Id; set => _Pelicula_Id = value; }
        public int Horario_Id { get => _Horario_Id; set => _Horario_Id = value; }
        public int Sala_Id { get => _Sala_Id; set => _Sala_Id = value; }
        public float Costo { get => _Costo; set => _Costo = value; }
    }
}
