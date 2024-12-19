<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoGeneroPelicula.aspx.cs" Inherits="Cine3capas.Catalogos.GeneroPelicula.ListadoGeneroPelicula" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <h3>Listado de Generos</h3>
    <p>
        <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
    </p>
</div>
<div class="row">
    <asp:GridView ID="GVGeneroPelicula" runat="server"
        CssClass="table table-bordered table-striped table-condensed"
        AutoGenerateColumns="false"
        DataKeyNames="Id_Genero"
        OnRowDeleting="GVGeneroPelicula_RowDeleting"
        OnRowCommand="GVGeneroPelicula_RowCommand">
        <%--arriba se genera los eventos "onrow"--%>
        <Columns>
            <asp:BoundField DataField="Id_Genero" HeaderText="Numero de Genero" ItemStyle-Width="50px" ReadOnly="true" />
            <asp:BoundField DataField="Nombre_Genero" HeaderText="Genero de peliculas" ItemStyle-Width="50px" />
            <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
