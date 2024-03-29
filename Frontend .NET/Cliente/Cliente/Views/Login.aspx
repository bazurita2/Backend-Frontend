<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cliente.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
    <h2 class="text-center my-3">Login</h2>
        <div class="container w-50">
            <div class="row">
                <div class="col-sm">
                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <asp:Label ID="lblusuario" runat="server" Text="Usuario" class="form-label"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control"></asp:TextBox>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-4">
                        <asp:Label ID="lblContrasena" runat="server" Text="Contrasena" class="form-label"></asp:Label>
                        <asp:TextBox ID="txtContrasena" runat="server" class="form-control"></asp:TextBox>
                    </div>

                    <!-- Submit button -->
                    <asp:Button ID="btnValidar" runat="server" Text="Login" OnClick="btnValidar_Click" class="btn btn-primary btn-block mb-4" />
                </div>
            </div>
        </div>
    </form>

    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
</body>
</html>
