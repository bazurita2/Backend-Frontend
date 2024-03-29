<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="ReporteView.aspx.cs" Inherits="ClientePRJ.Views.Biblioteca.ReporteView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

          <div class="col-sm-6" >
           <div class="col-mb-3 align-content-center">
            <asp:Label ID="Fecha" runat="server" Text="FechaMinima" class="form-label"></asp:Label>
            <asp:Calendar ID="fechaMinima" runat="server" onselectedindexchanged="LlenarTabla"></asp:Calendar>
        </div>
    </div>
    <div class="col-sm-6" >
       <div class="col-mb-3 align-content-center">
            <asp:Label ID="Label1" runat="server" Text="FechaMaxima" class="form-label"></asp:Label>
            <asp:Calendar ID="fechaMaxima" runat="server" onselectedindexchanged="LlenarTabla"></asp:Calendar>
        </div>
    </div>

   <div class="mb-3">
                    <asp:GridView ID="grdDetallesPrestamo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                        DataKeyNames="fechaEntregaDetalleP,cantidadDetalleP"
                        AutoGenerateSelectButton="False"   ShowFooter="True" >
                        <Columns>                            
                            <asp:BoundField DataField="fechaEntregaDetalleP" HeaderText="Fecha Entrega" SortExpression="iddetalle" visible="true"/>
                            <asp:BoundField DataField="cantidadDetalleP" HeaderText="Cantidad" SortExpression="descripcionMotivo" visible="true" />
                        </Columns>
                    </asp:GridView>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="LlenarTabla" class="btn btn-primary" />
                </div>

</asp:Content>
