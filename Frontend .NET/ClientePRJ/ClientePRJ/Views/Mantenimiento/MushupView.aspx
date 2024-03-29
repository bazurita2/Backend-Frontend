<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/_Layout.Master" AutoEventWireup="true" CodeBehind="MushupView.aspx.cs" Inherits="ClientePRJ.Views.Mantenimiento.MushupView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
#map {
height: 400px;
width: 100%;
}
</style>
<h3>My Google Maps Demo</h3>
<form name="myForm" action="" method="GET">
  Enter something in the box: <br>
  lat: <input type="text" name="inputbox" value="">
  lng: <input type="text" name="inputbox2" value="">
  <input type="button" name="button" value="Click" onClick="initMap(this.form)">
</form>
<div id="map"></div>

<script>
    function initMap(form) {
        var coord1 = { lat: -25.363, lng: 131.044 };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: coord1
        });
        // base de datos
        let e1 = document.getElementsByName("inputbox")[0];
        let e2 = document.getElementsByName("inputbox2")[0];
        alert("You typed: " + e1.value + " " + e2.value);
        //var coord_3 = new google.maps.LatLng(parseFloat(latitud3),parseFloat(latitud3));
        var coord_1 = new google.maps.LatLng(parseFloat(e1.value), parseFloat(e2.value));
        //var coord_1 = {lat: -20.800, lng: 200.044};
        //var coord_2 = {lat: -30.900, lng: 400.044};
        //var coord_3 = {lat: -40.600, lng: 250.044};
        //var posiciones=[coord_1];
        var marker = new google.maps.Marker({
            position: coord_1,
            map: map
        });
        //alert ("FIN");
    }
</script>
<script async defer
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA-jMl_9mehFfhiNoWUCJjNpjTIFSi2rtE&callback=initMap">
</script>

</asp:Content>
