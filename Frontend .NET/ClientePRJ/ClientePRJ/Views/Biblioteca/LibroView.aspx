<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="LibroView.aspx.cs" Inherits="ClientePRJ.Views.Biblioteca.LibroView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdLibro" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idLibro, idAutor,ISBNLibro, tituloLibro, valorPrestamoLibro"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdLibro_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ISBNLibro" HeaderText="ISBN" SortExpression="ISBNLibro" />
                        <asp:BoundField DataField="nombreApellidoAutor" HeaderText="Autor" SortExpression="idAutor" />
                        <asp:BoundField DataField="tituloLibro" HeaderText="Titulo" SortExpression="tituloLibro" />
                        <asp:BoundField DataField="valorPrestamoLibro" HeaderText="Valor Prestamo" SortExpression="valorPrestamoLibro" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Ingrese Titulo o ISBN de Libro"></asp:Label>
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
                    <asp:Label ID="lblEstado" runat="server" Text="Autor" class="form-label"></asp:Label>
                    <asp:DropDownList ID="idAutor" runat="server" class="form-select"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="ISBN" class="form-label"></asp:Label>
                    <asp:TextBox ID="ISBNLibro" runat="server"></asp:TextBox>
                </div>
                 <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Titulo" class="form-label"></asp:Label>
                    <asp:TextBox ID="tituloLibro" runat="server"></asp:TextBox>
                </div>
                 <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Valor Prestamo" class="form-label"></asp:Label>
                    <asp:TextBox ID="valorPrestamoLibro" runat="server"></asp:TextBox>
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
