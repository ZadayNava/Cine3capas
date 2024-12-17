using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Configuracion
    {
        static string _cadenaConexion = @"Data Source = SADAY\SQLEXPRESS;
                                          Initial Catalog = Cine;
                                          Integrated Security = true;";

        //Encapsulamietos
        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}
