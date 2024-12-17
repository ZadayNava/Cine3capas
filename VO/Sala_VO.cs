using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Sala_VO
    {
        private int _Id_Sala;
        private string _NomSala;
        private string _TipoSala;
        private int _Asientos_ID;

        public Sala_VO()
        {
            _Id_Sala = 0;
            _TipoSala = "";
            _NomSala = "";
            _Asientos_ID = 0;
        }

        public Sala_VO(DataRow dr)
        {
            _Id_Sala = int.Parse(dr["   Id_Sala"].ToString());
            _TipoSala = dr["TipoSala"].ToString();
            _NomSala = dr["NomSala"].ToString();
            _Asientos_ID = int.Parse(dr["Asientos_ID"].ToString());
        }

        public int Id_Sala { get => _Id_Sala; set => _Id_Sala = value; }
        public string NomSala { get => _NomSala; set => _NomSala = value; }
        public string TipoSala { get => _TipoSala; set => _TipoSala = value; }
        public int Asientos_ID { get => _Asientos_ID; set => _Asientos_ID = value; }
    }
}
