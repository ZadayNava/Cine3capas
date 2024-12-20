using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ReporteVenta_VO
    {
        private int _Id_Reporte;
        private int _Ticket_Id;
        private string _Estado_Ticket;
        private string _FechaHora;

        public ReporteVenta_VO()
        {
            Id_Reporte = 0;
            _Ticket_Id = 0;
            _Estado_Ticket = "";
            _FechaHora = "";

        }

        public ReporteVenta_VO(DataRow dr)
        {
            Id_Reporte = int.Parse(dr["Id_Reporte"].ToString());
            _Ticket_Id = int.Parse(dr["Ticket_Id"].ToString());
            _Estado_Ticket = dr["Estado_Ticket"].ToString();
            _FechaHora = dr["FechaHora"].ToString();
        }

        public int Ticket_Id { get => _Ticket_Id; set => _Ticket_Id = value; }
        public string Estado_Ticket { get => _Estado_Ticket; set => _Estado_Ticket = value; }
        public string FechaHora { get => _FechaHora; set => _FechaHora = value; }
        public int Id_Reporte { get => _Id_Reporte; set => _Id_Reporte = value; }
    }
}
