<%@ Page Title="Reporte 1 Nomina" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="Reporte1View.aspx.cs" Inherits="Cliente.Views.Nomina.Reporte1View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm">
               <h1>Datos a pagar</h1>

                <div class="mb-3
                    <asp:Label ID="lblEstado" runat="server" Text="Empleado" class="form-label"></asp:Label>
                    <asp:DropDownList ID="idEmpleado" runat="server" class="form-select"
                        AutoPostBack="True"  onselectedindexchanged="llenarSelectFehas">
                    </asp:DropDownList>
                </div>

    
                <div class="mb-3
                    <asp:Label ID="Label1" runat="server" Text="Fecha de Nomina" class="form-label"></asp:Label>
                    <asp:DropDownList ID="fechasEmpleadoDropDown" runat="server" class="form-select"
                        AutoPostBack="True"  onselectedindexchanged="llenarDetalle">
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:GridView ID="grdDetallesNomina" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="id,idCatalogo,idNomina,valorRubro"
                        AutoGenerateSelectButton="True" OnRowDataBound="dtDetalle_RowDataBound" OnSelectedIndexChanged="grdDetalles_SelectedIndexChanged" ShowFooter="True">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="iddetalle" Visible="false" />
                            <asp:BoundField DataField="descCatalogo" HeaderText="Descripcion" SortExpression="descripcionMotivo" />
                            <asp:BoundField DataField="tipoCatalogo" HeaderText="Tipo" SortExpression="tipoMotivo" />
                            <asp:BoundField DataField="valorRubro" HeaderText="Valor" SortExpression="valorRubro" />
                        </Columns>
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
