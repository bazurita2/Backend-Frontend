<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="ActivoView.aspx.cs" Inherits="Cliente.Views.ActivoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-3">Activos</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdActivo" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idactivo,nombreactivo,tipoactivo,estadoactivo,precioactivo,fechacompraactivo"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdActivo_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="nombreactivo" HeaderText="Nombre" SortExpression="nombreactivo" />
                        <asp:BoundField DataField="tipoactivo" HeaderText="Tipo" SortExpression="tipoactivo" />
                        <asp:BoundField DataField="estadoactivo" HeaderText="Estado" SortExpression="estadoactivo" />
                        <asp:BoundField DataField="precioactivo" HeaderText="Precio" SortExpression="precioactivo" />
                        <asp:BoundField DataField="fechacompraactivo" DataFormatString="{0:d}" HeaderText="Fecha Compra"
                            SortExpression="FechaEmision" />
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
                    <asp:TextBox ID="idActivo" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreActivo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="tipoActivo" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="M" Text="Maquinaria" />
                        <asp:ListItem Value="E" Text="Equipo" />
                        <asp:ListItem Value="V" Text="Vehiculo" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEstado" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="estadoActivo" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="N" Text="Nuevo" />
                        <asp:ListItem Value="U" Text="Usado" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio" class="form-label"></asp:Label>
                    <asp:TextBox ID="precioActivo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaCompraActivo" runat="server"  ></asp:Calendar>
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