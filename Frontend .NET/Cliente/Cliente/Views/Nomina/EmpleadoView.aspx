<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="EmpleadoView.aspx.cs" Inherits="Cliente.Views.Nomina.EmpleadoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdEmpleado" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="id,nombre,apellido,cedula,fechaIngreso,sueldo,usuario,contrasena"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdEmpleado_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="Tipo" SortExpression="tipo" />
                        <asp:BoundField DataField="cedula" HeaderText="Estado" SortExpression="estado" />   
                        <asp:BoundField DataField="fechaIngreso" DataFormatString="{0:d}" HeaderText="Fecha Ingreso"
                            SortExpression="FechaEmision" />
                        <asp:BoundField DataField="sueldo" HeaderText="Sueldo" SortExpression="precio" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Nombre o Apellido"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="idEmpleado" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                    <asp:TextBox ID="usuarioEmpleado" runat="server" Visible="false" class="form-control"></asp:TextBox>
                    <asp:TextBox ID="contrasenaEmpleado" runat="server" Visible="false" class="form-control"></asp:TextBox>
                
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreEmpleado" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Apellido" class="form-label"></asp:Label>
                    <asp:TextBox ID="apellidoEmpleado" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Cedula" class="form-label"></asp:Label>
                    <asp:TextBox ID="cedulaEmpleado" runat="server"></asp:TextBox>
                </div>
               
             
                <div class="mb-3 align-content-center">
                    <asp:Label ID="Fecha" runat="server" Text="Fecha Ingreso" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaIngresoEmpleado" runat="server"  ></asp:Calendar>
                </div>
                    <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Sueldo" class="form-label"></asp:Label>
                    <asp:TextBox ID="sueldoEmpleado" runat="server"></asp:TextBox>
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
