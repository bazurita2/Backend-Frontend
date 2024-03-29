<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="NominaView.aspx.cs" Inherits="Cliente.Views.Nomina.NominaView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdNomina" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="id,idTransaccion,idEmpleado,estadoNomina,fechaNomina"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdNomina_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="idTransaccion" HeaderText="idTransaccion" SortExpression="descripcionNomina" Visible="false" />
                        <asp:BoundField DataField="idEmpleado" HeaderText="idEmpleado" SortExpression="idEmpleado"  Visible="false"/>
                           <asp:BoundField DataField="nombreapellido" HeaderText="Empleado" SortExpression="idEmpleado" />
                         <asp:BoundField DataField="estadoNomina" HeaderText="Estado" SortExpression="estadoNomina" />
                          <asp:BoundField DataField="fechaNomina" HeaderText="Fecha" SortExpression="fechaNomina" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                 <asp:Button ID="ButtonLimpiar" runat="server" Text="Limpar Formulario" OnClick="btnLimpiar_Click" class="btn btn-primary" />
                
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="id" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                    <asp:TextBox ID="idTransaccion" Visible="false" runat="server"></asp:TextBox>
                <div class="mb-3">


                    <asp:Label ID="lblEstado" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="idEmpleado" runat="server" class="form-select"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
              

                 <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Tipo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="estadoNomina" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="P" Text="Passiva" />
                        <asp:ListItem Value="A" Text="Activa" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3 align-content-center">
                    <asp:Label ID="Fecha" runat="server" Text="Fecha" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaNomina" runat="server"  ></asp:Calendar>
                </div>

                <h2>Detalle</h2>
                  <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Motivos" class="form-label"></asp:Label>
                    <asp:DropDownList ID="catalogoList" runat="server" class="form-select"
                        AutoPostBack="True" onselectedindexchanged="llenarSueldo">
                    </asp:DropDownList>
                </div>

                     <asp:Label ID="Label3" runat="server" Text="Valor" class="form-label"></asp:Label>
                    <asp:TextBox ID="valorDeRubro" runat="server"></asp:TextBox>


                <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="btnAgregar_Click" class="btn btn-primary" />
                <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar" class="btn btn-warning" OnClick="btnModificarDetalle_Click" />
                <asp:Button ID="btnQuitarDetalle" runat="server" Text="Quitar" class="btn btn-danger" OnClick="btnQuitarDetalle_Click" />



                <div class="mb-3">
                    <asp:GridView ID="grdDetallesNomina" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="idRubro,idCatalogo,descripcionMotivo,tipoMotivo,valorRubro"
                        AutoGenerateSelectButton="True" OnRowDataBound="dtDetalle_RowDataBound" OnSelectedIndexChanged="grdDetalles_SelectedIndexChanged" ShowFooter="True" >
                        <Columns>                            
                            <asp:BoundField DataField="idRubro" HeaderText="ID" SortExpression="iddetalle" visible="false"/>
                         
                            <asp:BoundField DataField="idCatalogo" HeaderText="ID" SortExpression="iddetalle" visible="false"/>
                           
                            <asp:BoundField DataField="descripcionMotivo" HeaderText="Descripcion" SortExpression="descripcionMotivo" />
                            <asp:BoundField DataField="tipoMotivo" HeaderText="Tipo" SortExpression="tipoMotivo" />
                            <asp:BoundField DataField="valorRubro" HeaderText="Valor" SortExpression="valorRubro" />
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

