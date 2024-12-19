using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Cine3capas.Catalogos.Pelicula
{
    public partial class FormularioPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                cargar_DLL();
                //valido s se va a isertar o a actualizar 
                if (Request.QueryString["Id"] != null)
                {
                    int id_pelicula = int.Parse(Request.QueryString["Id"].ToString());
                    Pelicula_VO _peli = Pelicula_BLL.GetPeliculaxID(id_pelicula);
                    if (_peli.Id_Pelicula != null)
                    {
                        //Relleno el formulario
                        Titulo.Text = "Actualizar Pelicula";
                        subTitulo.Text = "Pelicula #" + id_pelicula;
                        ddlGenero.SelectedValue = _peli.GeneroPelicula.Nombre_Genero.ToString();
                        ddlClasificacion.SelectedValue = _peli.ClasifiicacionPelicula.Tipo_Clasificacion1.ToString();
                        txtNombre.Text = _peli.Nombre_Pelicula.ToString();
                    }
                    else
                    {
                        //sweet alert
                        SweetAlert.Sweet_Alert("Ops...", "No pudimos encontrar el objeto que buscas", "info", this.Page, this.GetType(), "~/Catalogos/Pelicula/ListadoPeliculas.aspx");
                    }
                }
                else
                {
                    //voy a insertar
                    Titulo.Text = "Agregar nueva Pelicula";
                    subTitulo.Text = "";

                }
            }

        }

        protected void cargar_DLL()
        {
            ListItem ddlgenero_i = new ListItem("Seleccione un genero", "0");
            ddlGenero.Items.Add(ddlgenero_i);
            List<GeneroPelicula_VO> list_g = Genero_BLL.GetGenero();
            if (list_g.Count > 0)
            {
                foreach (var g in list_g)
                {
                    ListItem GI = new ListItem(
                        (g.Nombre_Genero),
                        g.Id_Genero.ToString()
                        );
                    ddlGenero.Items.Add(GI);
                }
            }

            ListItem ddlClasificacion_i = new ListItem("Seleccione la clasificacion", "0");
            ddlClasificacion.Items.Add(ddlClasificacion_i);
            List<Clasificacion_VO> list_c = Clasificacion_BLL.GetClasificacion();
            if (list_c.Count > 0)
            {
                foreach (var c in list_c)
                {
                    ListItem CI = new ListItem(
                        (c.Tipo_Clasificacion1),
                        c.Id_Clasificacion1.ToString()
                        );
                    ddlClasificacion.Items.Add(CI);
                }
            }
        }
        protected void btngurdar_Click(object sender, EventArgs e)
        {
            //preparo mi objeto para enviar
            Pelicula_VO _peli = new Pelicula_VO();
            //variables para el sweet
            string titulo, msg, tipo, respuesta;
            try
            {
                //asigno mis valores del formulario al objeto
                _peli.Nombre_Pelicula = txtNombre.Text;
                _peli.GeneroPelicula.Id_Genero = int.Parse(ddlGenero.SelectedValue);
                _peli.ClasifiicacionPelicula.Id_Clasificacion1 = int.Parse(ddlClasificacion.SelectedValue);
                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //voy a actualizar
                    _peli.Id_Pelicula = int.Parse(Request.QueryString["Id"]);
                    respuesta = Pelicula_BLL.Update_Pelicua(_peli);
                }
                else
                {
                    //voy a insertar
                    respuesta = Pelicula_BLL.Insert_Pelicula(_peli);
                }

                //Preparo mis sweet alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    msg = respuesta;
                    tipo = "error";
                    //sweet alert
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "OK!";
                    msg = respuesta;
                    tipo = "success";
                    //sweet alert
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Pelicula/ListadoPeliculas.aspx");
                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                msg = ex.Message;
                tipo = "error";
                //sweet alert
                SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            }
        }
    }
}