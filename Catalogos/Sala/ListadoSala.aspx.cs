using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cine3capas.Catalogos.Sala
{
    public partial class ListadoSala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        public void cargarGrid()
        {
            //cargar la informacion desde la BLL al GV
            GVSala.DataSource = Sala_BLL.GetSala();
            //mostramos los resultados resultados renderizado la informacion
            GVSala.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSala.aspx");
        }

        protected void GVSala_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //recuero el id del renglon afectado 
            int id_Sala = int.Parse(GVSala.DataKeys[e.RowIndex].Values["Id_Sala"].ToString());
            //invoco mi metodo para eliminar mi camion
            string respuesta = Sala_BLL.Delete_Sala(id_Sala);
            //preparamos el sweet alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";

            }
            //debemos importar el usign de "using <nombre_de_tu_proyecto>.Utilidades;"
            SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            //Recargamos la pagina
            cargarGrid();
        }

        protected void GVSala_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el clic que se detecta) tiene la propiedad "select"
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcin de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente, se encuentra en ListadoCamiones.aspx.cs
                string id = GVSala.DataKeys[varIndex].Values["Id_Sala"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"FormularioSala.aspx?Id={id}");
            }
        }
    }
}