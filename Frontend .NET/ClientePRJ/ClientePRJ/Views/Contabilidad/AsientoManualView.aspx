<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="AsientoManualView.aspx.cs" Inherits="ClientePRJ.Views.Contabilidad.AsientoManualView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <h3>Asientos Contables</h3>
                <asp:GridView ID="grdDatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idasiento,fechaasiento,observacionasiento"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdDatos_SelectedIndexChanged">
                    <Columns>
                       <asp:BoundField DataField="fechaasiento" DataFormatString="{0:d}" HeaderText="Fecha Asiento"
                            SortExpression="FechaEmision" />                        
                        <asp:BoundField DataField="observacionasiento" HeaderText="Observación" SortExpression="observacionasiento" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm">
                <div class="mb-4">
                    <h3>Búsqueda</h3>
                    <asp:Label ID="lblBuscar" runat="server" Text="Fecha Inicio"></asp:Label>
                    <asp:Calendar ID="calendarBuscar" runat="server"></asp:Calendar>
                    <asp:Label ID="Label4" runat="server" Text="Fecha Fin"></asp:Label>
                    <asp:Calendar ID="calendarBuscarFin" runat="server"></asp:Calendar>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar Todo" class="btn btn-primary" OnClick="btnListar_Click" />
                </div>
                <h3>Ingreso Asientos</h3>
                <div class="mb-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaAsiento" runat="server"></asp:Calendar>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Observación" class="form-label"></asp:Label>
                    <asp:TextBox ID="observacionAsiento" runat="server"></asp:TextBox>
                </div>
                <hr />
                <%--detalles--%>
                <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Cuenta" class="form-label"></asp:Label>
                    <asp:DropDownList ID="ddlcuenta" runat="server" class="form-select"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Debe" class="form-label"></asp:Label>
                    <asp:TextBox ID="debeAsiento" runat="server"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Haber" class="form-label"></asp:Label>
                    <asp:TextBox ID="haberAsiento" runat="server"></asp:TextBox>
                     
                </div>
                <div class="mb-3">

                    <asp:Button ID="btnAgregarDetalle" runat="server" Text="Agregar" class="btn btn-secundary" OnClick="btnAgregarDetalle_Click" />
                    <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar" class="btn btn-secundary" OnClick="btnModificarDetalle_Click"  />
                    <asp:Button ID="btnQuitarDetalle" runat="server" Text="Quitar" class="btn btn-secundary" OnClick="btnQuitarDetalle_Click"  />
                </div>
                <div class="mb-3">
                    <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="iddetalleasiento,idcuenta,debedetalle,haberdetalle"
                        AutoGenerateSelectButton="True" OnRowDataBound="dtDetalle_RowDataBound" OnSelectedIndexChanged="grdDetalles_SelectedIndexChanged" ShowFooter="True" >
                        <Columns>                            
                            <asp:BoundField DataField="iddetalleasiento" HeaderText="ID" SortExpression="iddetalle" visible="false"/>
                            <%--<asp:BoundField DataField="nombrecuenta" HeaderText="Cuenta" SortExpression="nombrecuenta" />--%>
                            <asp:BoundField HeaderText="Cuenta" />
                            <asp:BoundField DataField="debedetalle" HeaderText="Debe" SortExpression="debedetalle" />
                            <asp:BoundField DataField="haberdetalle" HeaderText="Haber" SortExpression="haberdetalle" />
                        </Columns>
                    </asp:GridView>
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