using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Asiento_VO
    {
        private int _Id_Asiento;
        private int _NumAsientos;
        private string _Fila;
        private int _Sala_Id;

        public Asiento_VO()
        {
            _Id_Asiento = 0;
            _NumAsientos = 0;
            _Fila = "";
            _Sala_Id  = 0;
        }

        public Asiento_VO(DataRow dr)
        {
            _Id_Asiento = int.Parse(dr["Id_Asiento"].ToString());
            _NumAsientos = int.Parse(dr["NumAsientos"].ToString());
            _Fila = dr["Fila"].ToString();
            _Sala_Id  = int.Parse(dr["Sala_Id"].ToString());
        }

        public int Id_Asiento { get => _Id_Asiento; set => _Id_Asiento = value; }
        public int NumAsientos { get => _NumAsientos; set => _NumAsientos = value; }
        public string Fila { get => _Fila; set => _Fila = value; }
        public int Sala_Id { get => _Sala_Id; set => _Sala_Id = value; }
    }
}
