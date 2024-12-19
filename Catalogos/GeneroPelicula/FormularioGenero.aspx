<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioGenero.aspx.cs" Inherits="Cine3capas.Catalogos.GeneroPelicula.FormularioGenero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%--formulario--%>
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="btngurdar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btngurdar_Click" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
