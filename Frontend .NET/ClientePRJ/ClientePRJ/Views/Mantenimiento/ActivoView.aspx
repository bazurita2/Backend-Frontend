<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="ActivoView.aspx.cs" Inherits="ClientePRJ.Views.Mantenimiento.ActivoView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <div id="map" style="height: 400px; width=100%"></div>
        <script>
            function initMap() {
                var coord1 = { lat: -0.22985, lng: -78.52495 };
                var map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 11,
                    center: coord1
                });// base de datos
                var coord_1 = { lat: <%= latitudactivo %>, lng: <%= longitudactivo %>};
                var posiciones = [coord_1];
                for (i = 0; i <= 1; i++) {
                    var marker = new google.maps.Marker({
                        position: posiciones[i],
                        map: map
                    });
                }
            }


        </script>
        <script async defer
                src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA-jMl_9mehFfhiNoWUCJjNpjTIFSi2rtE&callback=initMap">
        </script>
        </div>
    <h2 class="text-center my-3">Medicamentos</h2>
    <div class="container"> 
        <asp:GridView ID="grdActivo" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    DataKeyNames="idactivo,nombreactivo,tipoactivo,estadoactivo,precioactivo,fechacompraactivo,latitudactivo,longitudactivo,largo_bazb,ancho_bazb"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdActivo_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="nombreactivo" HeaderText="Nombre" SortExpression="nombreactivo" />
                        <asp:BoundField DataField="tipoactivo" HeaderText="Tipo" SortExpression="tipoactivo" />
                        <asp:BoundField DataField="estadoactivo" HeaderText="Estado" SortExpression="estadoactivo" />
                        <asp:BoundField DataField="precioactivo" HeaderText="Precio" SortExpression="precioactivo" />
                        <asp:BoundField DataField="fechacompraactivo" DataFormatString="{0:d}" HeaderText="Fecha Compra"
                            SortExpression="FechaEmision" />
                        <asp:BoundField DataField="latitudactivo" HeaderText="Latitud" SortExpression="latitudactivo" />
                        <asp:BoundField DataField="longitudactivo" HeaderText="Longitud" SortExpression="longitudactivo" />
                        <asp:BoundField DataField="largo_bazb" HeaderText="largo_bazb" SortExpression="largo_bazb" />
                        <asp:BoundField DataField="ancho_bazb" HeaderText="largo_bazb" SortExpression="ancho_bazb" />
                    </Columns>
                </asp:GridView>
                <div class="mb-3">
                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar por nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary"/>
                    <asp:Button ID="btnBuscarTodo" runat="server" Text="Buscar Todo" OnClick="btnBuscarTodo_Click" class="btn btn-primary"/>
                </div>
                <h4 class="text-center my-3">CRUD</h4>
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" Visible="false" class="form-label"></asp:Label>
                    <asp:TextBox ID="idActivo" runat="server" Visible="false" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" class="form-label"></asp:Label>
                    <asp:TextBox ID="nombreActivo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo Medicamento" class="form-label"></asp:Label>
                    <asp:DropDownList ID="tipoActivo" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="O" Text="Oral" />
                        <asp:ListItem Value="T" Text="Topica" />
                        <asp:ListItem Value="R" Text="Rectal" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado Medicamento" class="form-label"></asp:Label>
                    <asp:DropDownList ID="estadoActivo" runat="server" class="form-select"
                        AutoPostBack="True">
                        <asp:ListItem Value="N" Text="Nuevo" />
                        <asp:ListItem Value="E" Text="Expirado" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio Medicamento" class="form-label"></asp:Label>
                    <asp:TextBox ID="precioActivo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha Compra Medicamento" class="form-label"></asp:Label>
                    <asp:Calendar ID="fechaCompraActivo" runat="server"  ></asp:Calendar>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Latitud Medicamento" class="form-label"></asp:Label>
                    <asp:TextBox ID="latitudactivo" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Longitud Medicamento" class="form-label"></asp:Label>
                    <asp:TextBox ID="longitudactivo" runat="server"></asp:TextBox>
                </div>
        <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Largo Medicamento" class="form-label"></asp:Label>
                    <asp:TextBox ID="largo_bazb" runat="server"></asp:TextBox>
                </div>
        <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Ancho Medicamento" class="form-label"></asp:Label>
                    <asp:TextBox ID="ancho_bazb" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEditar" runat="server" Text="Actualizar" OnClick="btnEditar_Click" class="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-primary" />
                </div>
            </div>
</asp:Content>