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
    /// Descripción breve de SalaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SalaService : System.Web.Services.WebService
    {

        [WebMethod]

        //Read
        public List<Sala_VO> GetSala(params object[] parametros)
        {
            return Sala_BLL.GetSala(parametros);
        }

        [WebMethod]
        //Delete
        public string Delete_Sala(int id)
        {
            return Sala_BLL.Delete_Sala(id);
        }

        [WebMethod]
        //Create
        public string Insert_Sala(Sala_VO sala)
        {
            return Sala_BLL.Insert_Sala(sala);
        }

    }
}
