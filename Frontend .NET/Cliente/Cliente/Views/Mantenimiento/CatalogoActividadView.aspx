<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="CatalogoActividadView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.CatalogoActividadView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-3">Actividades</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdActividad" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idcatactividad,nombrecatactividad,descripcioncatactividad"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdActividad_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="nombrecatactividad" HeaderText="Nombre" SortExpression="nombrecatactividad" />
                        <asp:BoundField DataField="descripcioncatactividad" HeaderText="Descripcion" SortExpression="descripcioncatactividad" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
                    <asp:Button ID="btnBuscarTodo" runat="server" Text="Buscar Todo" OnClick="btnBuscarTodo_Click" class="btn btn-primary"/>
                </div>
                <h4 class="text-center my-3">CRUD</h4>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="idCatActividad" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreCatActividad" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" class="form-label"></asp:Label>
                    <asp:TextBox ID="descripcionCatActividad" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
