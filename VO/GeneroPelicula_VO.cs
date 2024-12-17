using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public   class GeneroPelicula_VO
    {
        private int _Id_Genero;
        private string _Nombre_Genero;

        public GeneroPelicula_VO()
        {
            Id_Genero = 0;
            Nombre_Genero = "";
        }

        public GeneroPelicula_VO(DataRow dr)
        {
            Id_Genero = int.Parse(dr["Id_Genero"].ToString());
            Nombre_Genero = dr["Nombre_Genero"].ToString();
        }

        public int Id_Genero { get => _Id_Genero; set => _Id_Genero = value; }
        public string Nombre_Genero { get => _Nombre_Genero; set => _Nombre_Genero = value; }
    }
}
