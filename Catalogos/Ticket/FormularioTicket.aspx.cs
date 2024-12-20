using BLL;
using Cine3capas.Utildiades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Cine3capas.Catalogos.Ticket
{
    public partial class FormularioTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_DLL();
                //valido s se va a isertar o a actualizar 
                if (Request.QueryString["Id"] != null)
                {
                    int id_ticket = int.Parse(Request.QueryString["Id"].ToString());
                    Ticket_VO _ticket = Ticket_BLL.GetTicketxID(id_ticket);
                    if (_ticket.Id_Ticket != null)
                    {
                        //Relleno el formulario
                        titulo.Text = "Actualizar ticket";
                        ddlsucursal.SelectedValue = _ticket.Sucursal.Id_Cine.ToString();
                        ddlFechaHora.SelectedValue = _ticket.Hora.Id_Horario.ToString();
                        ddlTipoSala.SelectedValue = _ticket.Sala.Id_Sala.ToString();
                        ddlAsientoFila.SelectedValue = _ticket.Asiento.Id_Asiento.ToString();
                    }
                    else
                    {
                        //sweet alert
                        SweetAlert.Sweet_Alert("Ops...", "No pudimos encontrar el objeto que buscas", "info", this.Page, this.GetType(), "~/Catalogos/Ticket/ListadoTicket.aspx");
                    }
                }
                else
                {
                    //voy a insertar
                    if (Request.QueryString["Id_Peli"] != null)
                    {
                        int _id = Convert.ToInt32(Request.QueryString["Id_Peli"]);
                        int id_peli = int.Parse(Request.QueryString["Id_Peli"].ToString());
                        Pelicula_VO _peli = Pelicula_BLL.GetPeliculaxID(id_peli);

                        titulo.Text = _peli.Nombre_Pelicula;
                    }
                }
            }
        }
        public void cargar_DLL()
        {

            ListItem ddlsucursal_i = new ListItem("Seleccione una sucursal", "0");
            ddlsucursal.Items.Add(ddlsucursal_i);
            List<Sucursal_VO> list_s = Sucursal_BLL.GetSucursal();
            if (list_s.Count > 0)
            {
                foreach (var s in list_s)
                {
                    ListItem SU = new ListItem(
                        (s.Nombre_Cine),
                        s.Id_Cine.ToString()
                        );
                    ddlsucursal.Items.Add(SU);
                }
            }

            ListItem ddlFecha_i = new ListItem("Seleccione la fecha y hora", "0");
            ddlFechaHora.Items.Add(ddlFecha_i);
            List<Hora_VO> list_f = Horario_BLL.GetHorario();
            if (list_f.Count > 0)
            {
                foreach (var f in list_f)
                {
                    ListItem FI = new ListItem("Dia: " + f.Fecha_Funcion + " Hora: " + f.Horario_Funcion,
                        f.Id_Horario.ToString()
                        );
                    ddlFechaHora.Items.Add(FI);
                }
            }

            ListItem ddlSala_i = new ListItem("Seleccione la Sala", "0");
            ddlTipoSala.Items.Add(ddlSala_i);
            List<Sala_VO> list_sala = Sala_BLL.GetSala();
            if (list_sala.Count > 0)
            {
                foreach (var sa in list_sala)
                {
                    ListItem SALAI = new ListItem(
                        (sa.TipoSala),
                        sa.Id_Sala.ToString()
                        );
                    ddlTipoSala.Items.Add(SALAI);
                }
            }


            ListItem ddlAsiento_i = new ListItem("Seleccione la asieto y fila", "0");
            ddlAsientoFila.Items.Add(ddlAsiento_i);
            List<Asiento_VO> list_a = Asiento_BLL.GetAsiento();
            if (list_a.Count > 0)
            {
                foreach (var a in list_a)
                {
                    ListItem CI = new ListItem("Fila: " + a.Fila + " Asiento: " + a.NumAsientos,
                        a.Id_Asiento.ToString()
                        );
                    ddlAsientoFila.Items.Add(CI);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            //preparo mi objeto para enviar
            Ticket_VO _tick = new Ticket_VO();

            //variables para el sweet
            string titulo, msg, tipo, respuesta;
            try
            {
                //asigno mis valores del formulario al objeto
                int _id = Convert.ToInt32(Request.QueryString["Id_Peli"]);

                List<Asiento_VO> list_a = Asiento_BLL.GetAsiento();
                if (list_a.Count > 0)
                {
                    foreach (var d in list_a)
                    {
                        ListItem AsientoFila = new ListItem("Fila: " + d.Fila + " Asiento: " + d.NumAsientos, d.Id_Asiento.ToString());
                        ddlAsientoFila.Items.Add(AsientoFila);
                        //ddlFechaHora.Items.Add(FechaHora);
                    }
                }

                List<Hora_VO> list_h = Horario_BLL.GetHorario();
                if (list_h.Count > 0)
                {
                    foreach (var h in list_h)
                    {
                        ListItem FechaHora = new ListItem("Dia: " + h.Fecha_Funcion + " Hora: " + h.Horario_Funcion, h.Id_Horario.ToString());
                        ddlFechaHora.Items.Add(FechaHora);
                    }
                }

                _tick.Sucursal.Id_Cine = int.Parse(ddlsucursal.SelectedValue);
                _tick.Sala.Id_Sala = int.Parse(ddlTipoSala.SelectedValue);
                _tick.Hora.Id_Horario = int.Parse(ddlFechaHora.SelectedValue);
                _tick.Asiento.Id_Asiento = int.Parse(ddlAsientoFila.SelectedValue);
                _tick.Pelicula.Id_Pelicula = _id;

                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //voy a actualizar
                    _tick.Id_Ticket = int.Parse(Request.QueryString["Id"]);
                    respuesta = Ticket_BLL.Update_Ticket(_tick);
                }
                else
                {
                    //voy a insertar
                    respuesta = Ticket_BLL.Insert_Ticket(_tick);
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
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Ticket/ListadoTicket.aspx");
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