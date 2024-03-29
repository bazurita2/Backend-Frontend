<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="CuentaView.aspx.cs" Inherits="ClientePRJ.Views.Contabilidad.CuentaView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <h3>Cuentas Contables</h3>
                <asp:GridView ID="grdDatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idcuenta,idtipocuenta,numerocuenta,nombrecuenta,descripcioncuenta"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDatos_SelectedIndexChanged">
                    <Columns>
                        <%-- <asp:BoundField DataField="idtipocuenta" HeaderText="TipoCuenta" SortExpression="idtipocuenta" />--%>
                        <asp:BoundField DataField="numerocuenta" HeaderText="Número Cuenta" SortExpression="numerocuenta" />
                        <asp:BoundField DataField="nombrecuenta" HeaderText="Nombre" SortExpression="nombrecuenta" />
                        <asp:BoundField DataField="descripcioncuenta" HeaderText="Descripción" SortExpression="descripcioncuenta" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <h3>Búsqueda</h3>
                    <asp:Label ID="lblBuscar" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar Todo" class="btn btn-primary" OnClick="btnListar_Click" />
                </div>
                <h3>Ingreso</h3>
                 <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="tipocuenta" runat="server" class="form-select"
                        AutoPostBack="True">
                     
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Número" class="form-label"></asp:Label>
                    <asp:TextBox ID="numeroCuenta" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreCuenta" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Descripcion" runat="server" Text="Descripción" class="form-label"></asp:Label>
                    <asp:TextBox ID="descripcionCuenta" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">

                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>