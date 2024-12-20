<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoReporteVenta.aspx.cs" Inherits="Cine3capas.Catalogos.ReporteVentas.ListadoReporteVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
     <h3>Listado de Reporte en Ventas</h3>
 </div>
 <div class="row">
     <asp:GridView ID="GVReporteVenta" runat="server"
         CssClass="table table-bordered table-striped table-condensed"
         AutoGenerateColumns="false"
         DataKeyNames="Id_Reporte"
         OnRowCommand="GVReporteVenta_RowCommand">
         <%--arriba se genera los eventos "onrow"--%>
         <Columns>
             <asp:BoundField DataField="Ticket_Id" HeaderText="# Ticket" ItemStyle-Width="50px" ReadOnly="true" />
             <asp:BoundField DataField="Estado_Ticket" HeaderText="Estatus" ItemStyle-Width="50px" />
             <asp:BoundField DataField="FechaHora" HeaderText="Fecha" ItemStyle-Width="50px" ReadOnly="true" />
         </Columns>
     </asp:GridView>
 </div>
</asp:Content>
