using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cine3capas.Catalogos.Pelicula
{
    public partial class ListadoPeliculas : System.Web.UI.Page
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
            GVPeliculas.DataSource = Pelicula_BLL.GetPelicula();
            //mostramos los resultados resultados renderizado la informacion
            GVPeliculas.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioPeliculas.aspx");
        }

        protected void GVPeliculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //recuero el id del renglon afectado 
            int id_pelicula = int.Parse(GVPeliculas.DataKeys[e.RowIndex].Values["Id_Pelicula"].ToString());
            //invoco mi metodo para eliminar mi camion
            string respuesta = Pelicula_BLL.Delete_Pelicula(id_pelicula);
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

        protected void GVPeliculas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el clic que se detecta) tiene la propiedad "select"
            if (e.CommandName == "Select")
            {
                //recupero el indice en funcin de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente, se encuentra en ListadoCamiones.aspx.cs
                string id = GVPeliculas.DataKeys[varIndex].Values["Id_Pelicula"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"FormularioPeliculas.aspx?Id={id}");
            }
            if (e.CommandName == "Comprar")
            {
                //recupero el indice en funcin de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en funcion del indice que recuperamos anteriormente, se encuentra en ListadoCamiones.aspx.cs
                string id = GVPeliculas.DataKeys[varIndex].Values["Id_Pelicula"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"FormularioBoleto.aspx?Id={id}");
            }
        }

        protected void GVPeliculas_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVPeliculas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVPeliculas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}