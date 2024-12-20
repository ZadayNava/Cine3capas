using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cine3capas.Catalogos.ReporteVentas
{
    public partial class ListadoReporteVenta : System.Web.UI.Page
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
            GVReporteVenta.DataSource = ReporteVenta_BLL.GetReporte();
            GVReporteVenta.DataBind();
        }

        protected void GVReporteVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}