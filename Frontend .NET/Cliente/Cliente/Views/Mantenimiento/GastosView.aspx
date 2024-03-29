<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="GastosView.aspx.cs" Inherits="Cliente.Views.Mantenimiento.GastosView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-3">Gastos</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="grdGastos" runat="server" CssClass="table table-striped">
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
