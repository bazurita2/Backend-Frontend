using Cliente.BLL;
using Cliente.Models;
using System;

namespace Cliente.Views
{
    public partial class ActivoView : System.Web.UI.Page
    {
        private ActivoBLL BLL = new ActivoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
            }
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
            grdActivo.DataSource = BLL.listarActivo();
            grdActivo.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreActivo.Text = String.Empty;
            precioActivo.Text = String.Empty;
            tipoActivo.SelectedValue = "M";
            estadoActivo.SelectedValue = "N";
            fechaCompraActivo.SelectedDate = DateTime.UtcNow;
        }
    }
}