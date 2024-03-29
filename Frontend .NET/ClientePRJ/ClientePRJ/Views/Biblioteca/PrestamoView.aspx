<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="PrestamoView.aspx.cs" Inherits="ClientePRJ.Views.Biblioteca.PrestamoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdPrestamo" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idPrestamo,numeroPrestamo,fechaPrestamo,descripcionPrestamo"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdPrestamo_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="numeroPrestamo" HeaderText="Numero Prestamo" SortExpression="numeroPrestamo"  />
                        <asp:BoundField DataField="fechaPrestamo" HeaderText="Fecha" SortExpression="fechaPrestamo" />
                        <asp:BoundField DataField="descripcionPrestamo" HeaderText="Descripcion" SortExpression="descripcionPrestamo" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Ingrese numero, fecha o descripcion de Prestamo"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="id" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>

                
                
                <div class="mb-3 align-content-center">
                    <asp:Label ID="Fecha" runat="server" Text="Fecha" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaPrestamo" runat="server"  ></asp:Calendar>
                </div>

                  <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Descripcion" class="form-label"></asp:Label>
                    <asp:TextBox ID="descripcionPrestamo" runat="server" TextMode="multiline" Columns="50" Rows="5"/>
                </div>

               
              

                

                <h2>Detalle</h2>
                  <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Libros" class="form-label"></asp:Label>
                    <asp:DropDownList ID="libroList" runat="server" class="form-select"
                        AutoPostBack="True" onselectedindexchanged="llenarSueldo">
                    </asp:DropDownList>
                </div>

                    <asp:Label ID="Label1" runat="server" Text="Fecha Entrega" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaEntrega" runat="server"  ></asp:Calendar>
                    <asp:Label ID="Label3" runat="server" Text="Cantidad" class="form-label"></asp:Label>
                    <asp:TextBox ID="cantidadLibro" runat="server"></asp:TextBox>


                <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="btnAgregar_Click" class="btn btn-primary" />
                <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar" class="btn btn-warning" OnClick="btnModificarDetalle_Click" />
                <asp:Button ID="btnQuitarDetalle" runat="server" Text="Quitar" class="btn btn-danger" OnClick="btnQuitarDetalle_Click" />



                <div class="mb-3">
                    <asp:GridView ID="grdDetallesPrestamo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="idDetalleP,idLibro,tituloLibro,cantidadDetalleP,fechaEntregaDetalleP, totalLibro"
                        AutoGenerateSelectButton="True" OnRowDataBound="dtDetalle_RowDataBound" OnSelectedIndexChanged="grdDetalles_SelectedIndexChanged" ShowFooter="True" >
                        <Columns>                            
                            <asp:BoundField DataField="idDetalleP" HeaderText="ID" SortExpression="iddetalle" visible="false"/>
                            <asp:BoundField DataField="idLibro" HeaderText="LibroID" SortExpression="descripcionMotivo" />
                            <asp:BoundField DataField="tituloLibro" HeaderText="Libro" SortExpression="descripcionMotivo" />
                            <asp:BoundField DataField="cantidadDetalleP" HeaderText="Cantidad" SortExpression="descripcionMotivo" />
                          
                            <asp:BoundField DataField="fechaEntregaDetalleP" HeaderText="Fecha Entrega" SortExpression="valorRubro" />
                            <asp:BoundField DataField="totalLibro" HeaderText="Total" SortExpression="tipoMotivo" />
                        </Columns>
                    </asp:GridView>
                </div>



                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
              
                 <div class="mb-3">
                       Autogenerar Asiento Contable?
                <asp:CheckBox ID="checkBoxGenerarAsiento" runat="server" />
                 </div>
                </div>
            </div>
        </div>
    
    
</asp:Content>

