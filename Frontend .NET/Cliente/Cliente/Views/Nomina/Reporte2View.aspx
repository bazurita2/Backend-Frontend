<%@ Page Title="Reporte 2 View" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="Reporte2View.aspx.cs" Inherits="Cliente.Views.Nomina.Reporte2View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-sm-6">
            <div class="col-mb-3 align-content-center">
                <asp:Label ID="Fecha" runat="server" Text="FechaMinima" class="form-label"></asp:Label>
                <asp:Calendar ID="fechaMinima" runat="server" onselectedindexchanged="LlenarTabla"></asp:Calendar>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="col-mb-3 align-content-center">
                <asp:Label ID="Label1" runat="server" Text="FechaMaxima" class="form-label"></asp:Label>
                <asp:Calendar ID="fechaMaxima" runat="server" onselectedindexchanged="LlenarTabla"></asp:Calendar>
            </div>
        </div>



    </div>
    <asp:Button ID="btnImprimirx" runat="server" Text="Imprimir" class="btn btn-primary" />
    <div class="mb-3">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
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
