using Cliente.BLL.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Models.Contabilidad
{
    public partial class CuentaView : System.Web.UI.Page
    {
        private CuentaBLL objBll = new CuentaBLL();
        private TipoCuentaBLL objBLLTipoCuenta = new TipoCuentaBLL();
        private static DataTable dtCuentas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
                cargarCombos();
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
        private void cargarCombos()
        {
            tipocuenta.DataSource = objBLLTipoCuenta.listar();
            tipocuenta.DataTextField = "nombretipocuenta";                            // FieldName of Table in DataBase
            tipocuenta.DataValueField = "idtipocuenta";
            tipocuenta.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dtCuentas= objBll.getByNombreDataTable(txtBuscar.Text);            
            DataView dvCuentas = dtCuentas.DefaultView;
            dvCuentas.Sort = "numerocuenta ASC";            
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CuentaModel a = new CuentaModel();
            a.idtipocuenta = tipocuenta.SelectedValue.ToString().Trim();
            a.numerocuenta = numeroCuenta.Text.Trim();
            a.nombrecuenta = nombreCuenta.Text.Trim();
            a.descripcioncuenta = descripcionCuenta.Text.Trim();
            objBll.insertar(a);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);
        }

        protected void grdDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreCuenta.Text = grdDatos.SelectedDataKey["nombrecuenta"].ToString();
            descripcionCuenta.Text = grdDatos.SelectedDataKey["descripcioncuenta"].ToString();
            numeroCuenta.Text = grdDatos.SelectedDataKey["numerocuenta"].ToString();
            tipocuenta.SelectedValue = grdDatos.SelectedDataKey["idtipocuenta"].ToString();
            estadoBotones(false);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            CuentaModel a = new CuentaModel();
            a.idcuenta = grdDatos.SelectedDataKey["idcuenta"].ToString();
            a.idtipocuenta = tipocuenta.SelectedValue.ToString();
            a.numerocuenta = numeroCuenta.Text.Trim();
            a.nombrecuenta = nombreCuenta.Text.Trim();
            a.descripcioncuenta = descripcionCuenta.Text.Trim();
            objBll.actualizar(a);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdDatos.SelectedDataKey["idcuenta"].ToString();
            objBll.eliminar(id);
            llenarTabla();
            limpiarFormulario();
            estadoBotones(true);

        }

        private void llenarTabla()
        {
            dtCuentas= objBll.listar();            
            DataView dvCuentas = dtCuentas.DefaultView;
            dvCuentas.Sort = "numerocuenta ASC";            
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreCuenta.Text = String.Empty;
            descripcionCuenta.Text = String.Empty;
            numeroCuenta.Text = String.Empty;
            tipocuenta.SelectedIndex = 0;
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