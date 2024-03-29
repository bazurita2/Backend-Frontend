<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="BalanceView.aspx.cs" Inherits="Cliente.Views.Contabilidad.BalanceView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server" EnableScriptGlobalization="True" EnablePartialRendering="True" LoadScriptsBeforeUI="True">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <Triggers>

            <asp:PostBackTrigger ControlID="btnBuscar" />            
            <asp:PostBackTrigger ControlID="btnImprimirx" />
        </Triggers>
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-sm">
                        <h3>Balance General</h3>
                        <asp:GridView ID="grdTotales" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="totalactivo" HeaderText="Activo" SortExpression="totalactivo" />
                                <asp:BoundField DataField="totalpasivo" HeaderText="Pasivo" SortExpression="totalpasivo" />
                                <asp:BoundField DataField="totalpatrimonio" HeaderText="Patrimonio" SortExpression="totalpatrimonio" />
                                <asp:BoundField DataField="total" HeaderText="Activo-(Pasivo+Patrimonio)" SortExpression="total" />
                                <%--<asp:BoundField HeaderText="Total" />--%>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="grdDatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="numerocuenta" HeaderText="Número" SortExpression="numerocuenta" />
                                <asp:BoundField DataField="nombrecuenta" HeaderText="Cuenta" SortExpression="nombrecuenta" />
                                <asp:BoundField DataField="totalcuenta" HeaderText="Total" SortExpression="totalcuenta" />
                                <%--<asp:BoundField HeaderText="Total" />--%>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="false" Visible="false"
                            OnRowDataBound="dtDetalle_RowDataBound" 
                            DataKeyNames="iddetalle"
                            CssClass="table table-striped">
                            <Columns>
                                <%--<asp:BoundField DataField="iddetalle" HeaderText="iddetalle" SortExpression="iddetalle" />--%>
                                <%--<asp:BoundField DataField="idasiento" HeaderText="idasiento" SortExpression="idasiento" />--%>
                                <asp:BoundField DataField="idcuenta" HeaderText="Cuenta" SortExpression="idcuenta" />
                                <asp:BoundField DataField="debedetalle" HeaderText="Debe" SortExpression="debedetalle" />
                                <asp:BoundField DataField="haberdetalle" HeaderText="Haber" SortExpression="haberdetalle" />
                                <asp:BoundField HeaderText="Cuenta" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-sm">
                        <div class="mb-3">
                            <h3>Búsqueda</h3>
                            <asp:Label ID="lblBuscar" runat="server" Text="Fecha Inicio"></asp:Label>
                            <asp:Calendar ID="calendarBuscar" runat="server"></asp:Calendar>
                             <asp:Label ID="Label1" runat="server" Text="Fecha Fin"></asp:Label>
                            <asp:Calendar ID="calendarBuscarFin" runat="server"></asp:Calendar>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />                            
                            <asp:Button ID="btnImprimirx" runat="server" Text="Imprimir" class="btn btn-primary" />

                        </div>
                    </div>
                </div>
            </div>
            <%--scripts--%>
            <script type="text/javascript">
                var btnparaimprimir = document.getElementById("<%=btnImprimirx.ClientID %>");
                btnparaimprimir.addEventListener("click",imprimir,false );

                function imprimir() {
                    window.print()
                }
            </script>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>