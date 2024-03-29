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
    public partial class CatalogoActividadView : System.Web.UI.Page
    {
        private CatalogoActividadBLL BLL = new CatalogoActividadBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdActividad.DataSource = BLL.getCatalogoActividadByNombreDataTable(txtBuscar.Text);
            grdActividad.DataBind();
        }

        protected void btnBuscarTodo_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogoActividadModel c = new CatalogoActividadModel();
            c.nombrecatactividad = nombreCatActividad.Text.Trim();
            c.descripcioncatactividad = descripcionCatActividad.Text.Trim();
            BLL.insertarCatalogoActividad(c);
            llenarTabla();
            limpiarFormulario();
        }

        protected void grdActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreCatActividad.Text = grdActividad.SelectedDataKey["nombrecatactividad"].ToString();
            descripcionCatActividad.Text = grdActividad.SelectedDataKey["descripcioncatactividad"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            CatalogoActividadModel c = new CatalogoActividadModel();
            c.idcatactividad = grdActividad.SelectedDataKey["idcatactividad"].ToString();
            c.nombrecatactividad = nombreCatActividad.Text.Trim();
            c.descripcioncatactividad = descripcionCatActividad.Text.Trim();
            BLL.actualizarCatalogoActividad(c);
            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdActividad.SelectedDataKey["idcatactividad"].ToString();
            BLL.eliminarCatalogoActividad(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            DataTable dtTable = BLL.listarCatalogosActividades();
            DataView dvCuentas = dtTable.DefaultView;
            dvCuentas.Sort = "idcatactividad ASC";
            grdActividad.DataSource = dtTable;
            grdActividad.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreCatActividad.Text = String.Empty;
            descripcionCatActividad.Text = String.Empty;

        }
    }
}