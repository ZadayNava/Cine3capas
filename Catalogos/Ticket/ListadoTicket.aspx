<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoTicket.aspx.cs" Inherits="Cine3capas.Catalogos.Ticket.ListadoTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
    <div class="row">
        <h3>Listado de Tickets</h3>
    </div>
    <div class="row">
        <asp:GridView ID="GVTicket" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Id_Ticket"
            OnRowDeleting="GVTicket_RowDeleting"
            OnRowCommand ="GVTicket_RowCommand"
            >
            <%--arriba se genera los eventos "onrow"--%>
            <Columns>
                <asp:BoundField DataField="Id_Ticket" HeaderText="Numero Pelicula"  ItemStyle-Width="50px" ReadOnly="true"/>
                <asp:BoundField DataField="Pelicula.Nombre_Pelicula" HeaderText="Nombre Pelicula" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Hora.Fecha_Funcion" HeaderText="Fecha" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Hora.Horario_Funcion" HeaderText="Hora" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Sucursal.Nombre_Cine" HeaderText="Cine" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Sala.NomSala" HeaderText="Sala" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Asiento.Fila" HeaderText="Fila" ItemStyle-Width="50px"/>
                <asp:BoundField DataField="Asiento.NumAsientos" HeaderText="NumAsientos" ItemStyle-Width="50px"/>
                <%--<asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Modificar" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px"/>--%>
                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px"/>
            </Columns>

        </asp:GridView>
    </div>
</div>
</asp:Content>
