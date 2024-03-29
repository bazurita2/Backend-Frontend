<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="MantenimientoActivoView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.MantenimientoActivoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-3">Mantenimiento</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <h3>Actividades</h3>
                <asp:GridView ID="grdDatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" 
                    DataKeyNames="idactividad,idempleado,nombreempleado,fechaactividad"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDatos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="idactividad" HeaderText="ID" SortExpression="idactividad" />
                        <asp:BoundField DataField="nombreempleado" HeaderText="Responsable" SortExpression="nombreempleado" />
                        <asp:BoundField DataField="fechaactividad" DataFormatString="{0:d}" HeaderText="Fecha"
                            SortExpression="fechaactividad" />                        
                    </Columns>
                </asp:GridView>
                <h3>Búsqueda</h3>
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Fecha"></asp:Label>
                    <asp:Calendar ID="calendarBuscar" runat="server"></asp:Calendar>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar Todo" class="btn btn-primary" OnClick="btnListar_Click" />
                </div>
                <hr />
                <h3>Asiento</h3>
                <div class="mb-3">
                    <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="idcuenta,debedetalle,haberdetalle"
                        OnRowDataBound="dtAsiento_RowDataBound" ShowFooter="True" >
                        <Columns>
                            <asp:BoundField HeaderText="Cuenta" />
                            <asp:BoundField DataField="debedetalle" HeaderText="Debe" SortExpression="debedetalle" />
                            <asp:BoundField DataField="haberdetalle" HeaderText="Haber" SortExpression="haberdetalle" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm">
                <div class="mb-3">
                    <asp:Label ID="lblFechaActividad" runat="server" Text="Fecha Actividad" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaActividad" runat="server"></asp:Calendar>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEmpleado" runat="server" Text="Responsable" class="form-label"></asp:Label>
                    <asp:DropDownList ID="cmbEmpleado" runat="server" class="form-select" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <hr />

                <div class="mb-3">
                    <asp:Label ID="lblActivo" runat="server" Text="Activo" class="form-label"></asp:Label>
                    <asp:DropDownList ID="cmbActivo" runat="server" class="form-select" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblActividad" runat="server" Text="Actividad" class="form-label"></asp:Label>
                    <asp:DropDownList ID="cmbCatActividad" runat="server" class="form-select" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblValor" runat="server" Text="Valor" class="form-label"></asp:Label>
                    <asp:TextBox ID="valor" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnAgregarDetalleActividad" runat="server" Text="Agregar" class="btn btn-secundary" OnClick="btnAgregarDetalleActividad_Click" />
                    <asp:Button ID="btnEditarDetalleActividad" runat="server" Text="Editar" class="btn btn-secundary" OnClick="btnEditarDetalleActividad_Click"  />
                    <asp:Button ID="btnQuitarDetalleActividad" runat="server" Text="Quitar" class="btn btn-secundary" OnClick="btnQuitarDetalleActividad_Click"  />
                </div>
                <hr />
                <h3>Detalle Actividades</h3>
                <div class="mb-3">
                    <asp:GridView ID="grdDetalleActividad" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                        DataKeyNames="iddetalle,idactivo,nombreactivo,idcatactividad,nombrecatactividad,valordetalleactividad"
                        AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDetalleActividad_SelectedIndexChanged">
                        <Columns>                      
                            <asp:BoundField DataField="nombreactivo" HeaderText="Activo" SortExpression="nombreactivo" />
                            <asp:BoundField DataField="nombrecatactividad" HeaderText="Actividad" SortExpression="nombrecatactividad" />
                            <asp:BoundField DataField="valordetalleactividad" HeaderText="Valor" SortExpression="valordetalleactividad" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTotal" runat="server" Text="Total" class="form-label"></asp:Label>
                    <asp:TextBox ID="valorTotal" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnCrearAsiento" runat="server" Text="Crear Asiento" class="btn btn-primary" OnClick="btnCrearAsiento_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>