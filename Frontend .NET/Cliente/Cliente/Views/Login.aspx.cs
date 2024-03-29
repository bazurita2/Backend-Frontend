using Cliente.BLL;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Views
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioBLL BLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {
            IEnumerable<UsuarioModel> lista = BLL.listarUsuarios();
            foreach(UsuarioModel usr in lista)
            {
                if (usr.usuarioempleado.ToString() == txtUsuario.Text && usr.claveempleado.ToString() == txtContrasena.Text)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Views/Mantenimiento/ActivoView.aspx"));
                }
            }
        }
    }
}