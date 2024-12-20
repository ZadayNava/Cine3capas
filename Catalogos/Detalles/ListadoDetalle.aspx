<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoDetalle.aspx.cs" Inherits="Cine3capas.Catalogos.Detalles.ListadoDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Listado de Detalles</h2>
    </div>
    <div class="row">
        <h4>Listado de Sucursal</h4>
        <asp:GridView ID="GVSucursal" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Id_Cine"
            <%--arriba se genera los eventos "onrow"--%>
            <Columns>
                <asp:BoundField DataField="Id_Genero" HeaderText="Numero de Genero" ItemStyle-Width="50px" ReadOnly="true" />
                <asp:BoundField DataField="Nombre_Genero" HeaderText="Genero de peliculas" ItemStyle-Width="50px" />
                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
    <h4>Listado de Asiento</h4>
    <asp:GridView ID="GridView2" runat="server"
        CssClass="table table-bordered table-striped table-condensed"
        AutoGenerateColumns="false"
        DataKeyNames="Id_Cine"
        <%--arriba se genera los eventos "onrow"--%>
        <Columns>
            <asp:BoundField DataField="Id_Genero" HeaderText="Numero de Genero" ItemStyle-Width="50px" ReadOnly="true" />
            <asp:BoundField DataField="Nombre_Genero" HeaderText="Genero de peliculas" ItemStyle-Width="50px" />
            <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
    <div class="row">
    <h4>Listado de Horarios</h4>
    <asp:GridView ID="GridView1" runat="server"
        CssClass="table table-bordered table-striped table-condensed"
        AutoGenerateColumns="false"
        DataKeyNames="Id_Cine"
        <%--arriba se genera los eventos "onrow"--%>
        <Columns>
            <asp:BoundField DataField="Id_Genero" HeaderText="Numero de Genero" ItemStyle-Width="50px" ReadOnly="true" />
            <asp:BoundField DataField="Nombre_Genero" HeaderText="Genero de peliculas" ItemStyle-Width="50px" />
            <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
