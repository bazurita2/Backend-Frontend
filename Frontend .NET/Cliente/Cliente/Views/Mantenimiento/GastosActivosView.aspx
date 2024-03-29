<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="GastosActivosView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.GastosActivosView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-3">Gastos Activos</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="lblActivo" runat="server" Text="Activo" class="form-label"></asp:Label>
                <asp:DropDownList ID="nombresActivos" runat="server" class="form-select" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="col-sm mt-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm mt-3">
                <asp:GridView ID="grdGastoActivo" runat="server" CssClass="table table-striped">
                </asp:GridView>
            </div>
            <asp:Button ID="btnImprimirx" runat="server" Text="Imprimir" class="btn btn-primary" />
        </div>
    </div>
     <%--scripts--%>
        <script type="text/javascript">
            var btnparaimprimir = document.getElementById("<%=btnImprimirx.ClientID %>");
            btnparaimprimir.addEventListener("click", imprimir, false);

            function imprimir() {
                window.print()
            }
        </script>
</asp:Content>