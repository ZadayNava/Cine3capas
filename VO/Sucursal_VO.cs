using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Sucursal_VO
    {
        private int _Id_Cine;
        private string _Nombre_Cine;
        private string _Ubicacion_Cine;

        public int Id_Cine { get => _Id_Cine; set => _Id_Cine = value; }
        public string Nombre_Cine { get => _Nombre_Cine; set => _Nombre_Cine = value; }
        public string Ubicacion_Cine { get => _Ubicacion_Cine; set => _Ubicacion_Cine = value; }

        public Sucursal_VO()
        {
            _Id_Cine = 0;
            _Nombre_Cine = "";
            _Ubicacion_Cine = "";
        }

        public Sucursal_VO(DataRow dr)
        {
            _Id_Cine = int.Parse(dr["Id_Cine"].ToString());
            _Nombre_Cine = dr["Nombre_Cine"].ToString();
            _Ubicacion_Cine = dr["Ubicacion_Cine"].ToString();
        }
    }
}
