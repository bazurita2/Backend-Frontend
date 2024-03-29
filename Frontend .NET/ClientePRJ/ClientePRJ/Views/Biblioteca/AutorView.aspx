<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="AutorView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.CatalogoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdAutor" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idAutor,codigoAutor,nombreAutor,apellidoAutor"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdAutor_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="codigoAutor" HeaderText="Codigo" SortExpression="codigoAutor" />
                        <asp:BoundField DataField="nombreAutor" HeaderText="Nombre" SortExpression="nombreAutor" />
                         <asp:BoundField DataField="apellidoAutor" HeaderText="Apellido" SortExpression="apellidoAutor" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Codigo de autor"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                </div>
                 <div class="mb-3">
                      <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="id" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                </div>
                 <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Apellido" class="form-label"></asp:Label>
                    <asp:TextBox ID="apellido" runat="server"></asp:TextBox>
                </div>
               
                
               

                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                </div>
            </div>
        </div>
    
    <!--
    <div class="mb-3">
          <asp:Label ID="max" runat="server" Text="Valor máximo de la tabla: " class="form-label"></asp:Label> <br />
          <asp:Label ID="min" runat="server" Text="Valor minimo de la tabla: " class="form-label"></asp:Label> <br />
          <asp:Label ID="promedio" runat="server" Text="Valor promedio de la tabla: " class="form-label"></asp:Label> <br />               
    </div>
    -->
</asp:Content>
