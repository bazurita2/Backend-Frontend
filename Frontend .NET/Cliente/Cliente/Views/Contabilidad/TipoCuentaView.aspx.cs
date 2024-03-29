
using Cliente.BLL.Contabilidad;
using Cliente.Models;
using Cliente.Models.Contabilidad;
using System;
using System.Web.UI.WebControls;

namespace Cliente.Views.Contabilidad
{
	public partial class TipoCuentaView : System.Web.UI.Page
	{
        private TipoCuentaBLL objBll = new TipoCuentaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
                estadoBotones(true);
            }
        }
        private void activarBoton(Button btn, bool estado)
        {
            btn.Enabled = estado;

            btn.CssClass = !estado ? "btn btn-secondary" : "btn btn-primary";
        }
        private void estadoBotones(bool estado)
        {
            activarBoton(btnGuardar, estado);
            activarBoton(btnEditar, !estado);
            activarBoton(btnCancelar, !estado);
            activarBoton(btnEliminar, !estado);


        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //llenarTabla();
            grdDatos.DataSource = objBll.getByNombreDataTable(txtBuscar.Text);
            grdDatos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoCuentaModel a = new TipoCuentaModel();
            a.nombretipocuenta = nombreTipoCuenta.Text.Trim();
            a.descripciontipocuenta = descripcionTipoCuenta.Text.Trim();           
            objBll.insertar(a);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);
        }

        protected void grdDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreTipoCuenta.Text = grdDatos.SelectedDataKey["nombretipocuenta"].ToString();
            descripcionTipoCuenta.Text = grdDatos.SelectedDataKey["descripciontipocuenta"].ToString();
            estadoBotones(false);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            TipoCuentaModel a = new TipoCuentaModel();
            a.idtipocuenta = grdDatos.SelectedDataKey["idtipocuenta"].ToString();
            a.nombretipocuenta = nombreTipoCuenta.Text.Trim();
            a.descripciontipocuenta = descripcionTipoCuenta.Text.Trim();            
            objBll.actualizar(a);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdDatos.SelectedDataKey["idtipocuenta"].ToString();
            objBll.eliminar(id);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);

        }

        private void llenarTabla()
        {
            grdDatos.DataSource = objBll.listar();
            grdDatos.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreTipoCuenta.Text = String.Empty;
            descripcionTipoCuenta.Text = String.Empty;            
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            estadoBotones(true);
        }
    }
}