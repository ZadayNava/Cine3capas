using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Hora_VO
    {
        private int _Id_Horario;
        private string _Fecha_Funcion;
        private string _Horario_Funcion;

        public int Id_Horario { get => _Id_Horario; set => _Id_Horario = value; }
        public string Fecha_Funcion { get => _Fecha_Funcion; set => _Fecha_Funcion = value; }
        public string Horario_Funcion { get => _Horario_Funcion; set => _Horario_Funcion = value; }

        public Hora_VO() 
        {
            _Id_Horario = 0;
            _Fecha_Funcion = "";
            _Horario_Funcion = "";
        }

        public Hora_VO(DataRow dr)
        {
            _Id_Horario = int.Parse(dr["Id_Horario"].ToString());
            _Fecha_Funcion = DateTime.Parse(dr["Fecha_Funcion"].ToString()).ToShortDateString();
            _Horario_Funcion = dr["Horario_Funcion"].ToString();
        }

    }
}
