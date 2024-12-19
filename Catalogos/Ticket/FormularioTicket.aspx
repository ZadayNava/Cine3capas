<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioTicket.aspx.cs" Inherits="Cine3capas.Catalogos.Ticket.FormularioTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>
                <asp:Label ID="titulo" runat="server" Text=""></asp:Label>
            </h3>

            <%--DLL-Drop Down List--%>

            <asp:Label ID="lblsucursal" runat="server" Text="Sucursal"></asp:Label>
            <asp:DropDownList ID="ddlsucursal" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblFechaHora" runat="server" Text="Fecha/Hora"></asp:Label>
            <asp:DropDownList ID="ddlFechaHora" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblTipoSala" runat="server" Text="Tipo Sala"></asp:Label>
            <asp:DropDownList ID="ddlTipoSala" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblAsientoFila" runat="server" Text="Asiento/Fila"></asp:Label>
            <asp:DropDownList ID="ddlAsientoFila" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <br />
            <br />
            <asp:Button ID="btnGuardar" CssClass="btn btn-success btn-sm" runat="server" Text="Comprar" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
