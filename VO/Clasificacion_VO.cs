using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Clasificacion_VO
    {

        private int _Id_Clasificacion;
        private string _Tipo_Clasificacion;
        private string _Descripcion;

        public Clasificacion_VO()
        {
            _Id_Clasificacion = 0;
            _Tipo_Clasificacion = "";
            _Descripcion = "";
        }

        public Clasificacion_VO(DataRow dr)
        {
            _Id_Clasificacion = int.Parse(dr["Id_Clasificacion"].ToString());
            _Tipo_Clasificacion = dr["Tipo_Clasificacion"].ToString();
            _Descripcion = dr["Descripcion"].ToString();
        }

        public int Id_Clasificacion1 { get => _Id_Clasificacion; set => _Id_Clasificacion = value; }
        public string Tipo_Clasificacion1 { get => _Tipo_Clasificacion; set => _Tipo_Clasificacion = value; }
        public string Descripcion1 { get => _Descripcion; set => _Descripcion = value; }
    }
}
