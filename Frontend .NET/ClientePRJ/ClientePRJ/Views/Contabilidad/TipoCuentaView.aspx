<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="TipoCuentaView.aspx.cs" Inherits="ClientePRJ.Views.Contabilidad.TipoCuentaView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdDatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idtipocuenta,nombretipocuenta,descripciontipocuenta"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDatos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="nombretipocuenta" HeaderText="Nombre" SortExpression="nombretipocuenta" />
                        <asp:BoundField DataField="descripciontipocuenta" HeaderText="Tipo" SortExpression="descripciontipocuenta" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar Todo" class="btn btn-primary" OnClick="btnListar_Click"  />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="idTipoCuenta" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreTipoCuenta" runat="server"></asp:TextBox>
                </div>
                
                <div class="mb-3">
                    <asp:Label ID="Descripcion" runat="server" Text="Descripción" class="form-label"></asp:Label>
                    <asp:TextBox ID="descripcionTipoCuenta" runat="server"></asp:TextBox>
                </div>
               
                <div class="mb-3">

                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  class="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>