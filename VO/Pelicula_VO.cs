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
        private int _Genero_Id;
        private int _Clasificacion_Id;

        public int Id_Pelicula { get => _Id_Pelicula; set => _Id_Pelicula = value; }
        public string Nombre_Pelicula { get => _Nombre_Pelicula; set => _Nombre_Pelicula = value; }
        public int Genero_Id { get => _Genero_Id; set => _Genero_Id = value; }
        public int Clasificacion_Id { get => _Clasificacion_Id; set => _Clasificacion_Id = value; }

        public Pelicula_VO()
        {
            _Id_Pelicula = 0;
            _Nombre_Pelicula = "";
            _Genero_Id = 0;
            _Clasificacion_Id = 0;

        }

        public Pelicula_VO(DataRow dr)
        {
            _Id_Pelicula = int.Parse(dr["Id_Pelicula"].ToString());
            _Nombre_Pelicula = dr["Nombre_Pelicula"].ToString();
            _Genero_Id = int.Parse(dr["Genero_Id"].ToString());
            _Clasificacion_Id = int.Parse(dr["Clasificacion_Id"].ToString());
        }

    }
}
