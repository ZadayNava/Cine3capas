using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Pelicula_VO
    {
        private int _Id_Pelicula;
        private string _Nombre_Pelicula;
        private GeneroPelicula_VO _GeneroPelicula;
        private Clasificacion_VO _ClasifiicacionPelicula;

        public int Id_Pelicula { get => _Id_Pelicula; set => _Id_Pelicula = value; }
        public string Nombre_Pelicula { get => _Nombre_Pelicula; set => _Nombre_Pelicula = value; }
        public GeneroPelicula_VO GeneroPelicula { get => _GeneroPelicula; set => _GeneroPelicula = value; }
        public Clasificacion_VO ClasifiicacionPelicula { get => _ClasifiicacionPelicula; set => _ClasifiicacionPelicula = value; }

        public Pelicula_VO()
        {
            _Id_Pelicula = 0;
            _Nombre_Pelicula = "";
            _ClasifiicacionPelicula = new Clasificacion_VO();
            _GeneroPelicula = new GeneroPelicula_VO();

        }

        public Pelicula_VO(DataRow dr)
        {
            _Id_Pelicula = int.Parse(dr["Id_Pelicula"].ToString());
            _Nombre_Pelicula = dr["Nombre_Pelicula"].ToString();
            _ClasifiicacionPelicula = new Clasificacion_VO()
            {
                Id_Clasificacion1 = int.Parse(dr["Id_Clasificacion"].ToString()),
                Tipo_Clasificacion1 = dr["Tipo_Clasificacion"].ToString()
            };
            _GeneroPelicula = new GeneroPelicula_VO()
            {
                Id_Genero = int.Parse(dr["Id_Genero"].ToString()),
                Nombre_Genero = dr["Nombre_Genero"].ToString()
            };
        }

    }
}
