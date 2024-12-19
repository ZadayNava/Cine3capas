using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cine3capas.Catalogos.GeneroPelicula
{
    public partial class ListadoGeneroPelicula : System.Web.UI.Page
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
            GVGeneroPelicula.DataSource = Genero_BLL.GetGenero();
            //mostramos los resultados resultados renderizado la informacion
            GVGeneroPelicula.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioGenero.aspx");
        }

        protected void GVGeneroPelicula_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //recuero el id del renglon afectado 
            int id_Genero = int.Parse(GVGeneroPelicula.DataKeys[e.RowIndex].Values["Id_Genero"].ToString());
            //invoco mi metodo para eliminar mi camion
            string respuesta = Genero_BLL.Delete_Genero(id_Genero);
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

        protected void GVGeneroPelicula_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el clic que se detecta) tiene la propiedad "select"
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcin de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente, se encuentra en ListadoCamiones.aspx.cs
                string id = GVGeneroPelicula.DataKeys[varIndex].Values["Id_Genero"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"FormularioGenero.aspx?Id={id}");
            }
        }
    }
}