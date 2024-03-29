<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="CatalogoView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.CatalogoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdCatalogo" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="id,descripcionCatalogo,tipoCatalogo,Valor_FDSC"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdCatalogo_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="descripcionCatalogo" HeaderText="Descripcion" SortExpression="descripcionCatalogo" />
                        <asp:BoundField DataField="tipoCatalogo" HeaderText="Tipo" SortExpression="tipoactivo" />
                        
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="id" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="descripcionCatalogo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="tipoCatalogo" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="M" Text="Tipo" />
                        <asp:ListItem Value="i">Ingreso</asp:ListItem>
                        <asp:ListItem Value="e">Egreso</asp:ListItem>
                    </asp:DropDownList>
                </div>
              
               

                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <div class="mb-3">
                    <asp:Label ID="max" runat="server" Text="Valor máximo de la tabla: " class="form-label"></asp:Label> <br />
          <asp:Label ID="min" runat="server" Text="Valor minimo de la tabla: " class="form-label"></asp:Label> <br />
          <asp:Label ID="promedio" runat="server" Text="Valor promedio de la tabla: " class="form-label"></asp:Label> <br />
                   
                </div>
</asp:Content>
