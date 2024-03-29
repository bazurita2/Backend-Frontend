using ClientePRJ.BLL.Mantenimiento;
using ClientePRJ.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientePRJ.Views.Mantenimiento
{
    public partial class ActivoView : System.Web.UI.Page
    {
        private ActivoBLL BLL = new ActivoBLL();
        public static string longui = "200.044";
        public static string lat = "-20.800";
        protected void Page_Load(object sender, EventArgs e)
        {
            longui = "200.044";
            lat = "-20.800";
            llenarTabla();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdActivo.DataSource = BLL.getActivoByNombreDataTable(txtBuscar.Text);
            grdActivo.DataBind();
        }

        protected void btnBuscarTodo_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActivoModel a = new ActivoModel();
            a.nombreactivo = nombreActivo.Text.Trim();
            a.tipoactivo = tipoActivo.SelectedValue.ToString().Trim();
            a.estadoactivo = estadoActivo.SelectedValue.ToString().Trim();
            a.precioactivo = Double.Parse(precioActivo.Text.Trim());
            a.nombreactivo = nombreActivo.Text.Trim();
            a.fechacompraactivo = DateTime.Parse(fechaCompraActivo.SelectedDate.ToString());

            a.dataToString();

            BLL.insertarActivo(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void grdActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreActivo.Text = grdActivo.SelectedDataKey["nombreactivo"].ToString();
            precioActivo.Text = grdActivo.SelectedDataKey["precioactivo"].ToString();
            tipoActivo.SelectedValue = grdActivo.SelectedDataKey["tipoactivo"].ToString();
            estadoActivo.SelectedValue = grdActivo.SelectedDataKey["estadoactivo"].ToString();
            fechaCompraActivo.SelectedDate = DateTime.Parse(grdActivo.SelectedDataKey["fechacompraactivo"].ToString());
            //latitudactivo.Text = grdActivo.SelectedDataKey["latitudactivo"].ToString();
            //longitudactivo.Text = grdActivo.SelectedDataKey["longitudactivo"].ToString();
            //largo_bazb.Text = grdActivo.SelectedDataKey["largo_bazb"].ToString();
            //ancho_bazb.Text = grdActivo.SelectedDataKey["ancho_bazb"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ActivoModel a = new ActivoModel();
            a.idactivo = grdActivo.SelectedDataKey["idactivo"].ToString();
            a.nombreactivo = nombreActivo.Text.Trim();
            a.tipoactivo = tipoActivo.SelectedValue.ToString().Trim();
            a.estadoactivo = estadoActivo.SelectedValue.ToString().Trim();
            a.precioactivo = Double.Parse(precioActivo.Text.Trim());
            a.nombreactivo = nombreActivo.Text.Trim();
            a.fechacompraactivo = DateTime.Parse(fechaCompraActivo.SelectedDate.ToString());
            a.latitudactivo = latitudactivo.Text.Trim();
            a.longitudactivo = longitudactivo.Text.Trim();
            a.largo_bazb = largo_bazb.Text.Trim();
            a.ancho_bazb = ancho_bazb.Text.Trim();
            BLL.actualizarActivo(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdActivo.SelectedDataKey["idactivo"].ToString();
            BLL.eliminarActivo(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            DataTable dtTable = BLL.listarActivos();
            DataView dvCuentas = dtTable.DefaultView;
            dvCuentas.Sort = "idactivo ASC";
            grdActivo.DataSource = dtTable;
            grdActivo.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreActivo.Text = String.Empty;
            precioActivo.Text = String.Empty;
            tipoActivo.SelectedValue = "N";
            estadoActivo.SelectedValue = "N";
            fechaCompraActivo.SelectedDate = DateTime.UtcNow;
            latitudactivo.Text = String.Empty;
            longitudactivo.Text = String.Empty;
            largo_bazb.Text = String.Empty;
            ancho_bazb.Text = String.Empty;
        }
    }
}