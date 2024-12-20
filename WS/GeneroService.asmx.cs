using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace Cine3capas.WS
{
    /// <summary>
    /// Descripción breve de GeneroService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GeneroService : System.Web.Services.WebService
    {

        [WebMethod]
        //Create
        public  string Insert_Genero(GeneroPelicula_VO genero)
        {
            return Genero_BLL.Insert_Genero(genero);
        }

        [WebMethod]
        //Read
        public  List<GeneroPelicula_VO> GetGenero(params object[] parametros)
        {
            return Genero_BLL.GetGenero(parametros);
        }

        [WebMethod]
        //Delete
        public  string Delete_Genero(int id)
        {
            return Genero_BLL.Delete_Genero(id);
        }
    }
}
