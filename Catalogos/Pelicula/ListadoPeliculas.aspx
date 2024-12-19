<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoPeliculas.aspx.cs" Inherits="Cine3capas.Catalogos.Pelicula.ListadoPeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Listado de Peliculas</h3>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVPeliculas" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="Id_Pelicula"
                OnRowDeleting="GVPeliculas_RowDeleting"
                OnRowCommand="GVPeliculas_RowCommand">
                <%--arriba se genera los eventos "onrow"--%>
                <Columns>
                    <asp:BoundField DataField="Id_Pelicula" HeaderText="Numero de Pelicula" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Nombre_Pelicula" HeaderText="Listado Peliculas" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="GeneroPelicula.Nombre_Genero" HeaderText="Genero" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="ClasifiicacionPelicula.Tipo_Clasificacion1" HeaderText="Clasificacion" ItemStyle-Width="50px" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Modificar" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:ButtonField ButtonType="Button" CommandName="Comprar" HeaderText="Boleto" Text="Comprar" ControlStyle-CssClass="btn btn-success btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
