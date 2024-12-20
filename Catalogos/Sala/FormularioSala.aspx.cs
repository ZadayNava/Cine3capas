using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Cine3capas.Catalogos.Sala
{
    public partial class FormularioSala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cargar_DLL();
                //voy a insertar
                Titulo.Text = "Agregar nueva Pelicula";
            }

        }

        protected void cargar_DLL()
        {
            ListItem ddlAsiento_i = new ListItem("Seleccione un Asiento", "0");
            ddlAsiento.Items.Add(ddlAsiento_i);
            List<Asiento_VO> list_a = Asiento_BLL.GetAsiento();
            if (list_a.Count > 0)
            {
                foreach (var s in list_a)
                {
                    ListItem GI = new ListItem(
                        (s.Id_Asiento.ToString())
                        );
                    ddlAsiento.Items.Add(GI);
                }
            }

        }

        protected void btngurdar_Click(object sender, EventArgs e)
        {

            //preparo mi objeto para enviar
            Sala_VO _sala = new Sala_VO();
            //variables para el sweet
            string titulo, msg, tipo, respuesta;
            try
            {
                //asigno mis valores del formulario al objeto
                _sala.NomSala = txtNombre.Text;
                _sala.TipoSala = txtTipoSala.Text;

                List<Asiento_VO> list_a = Asiento_BLL.GetAsiento();
                if (list_a.Count > 0)
                {
                    foreach (var d in list_a)
                    {
                        ListItem AsientoFila = new ListItem(" Asiento: " + d.NumAsientos, d.Id_Asiento.ToString());
                        ddlAsiento.Items.Add(AsientoFila);
                        //ddlFechaHora.Items.Add(FechaHora);
                    }
                }
                _sala.Asientos_ID = int.Parse(ddlAsiento.SelectedValue);
                //voy a insertar
                respuesta = Sala_BLL.Insert_Sala(_sala);
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