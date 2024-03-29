using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cliente.BLL;
using Cliente.BLL.Nomina;
using Cliente.Models;
using clienteG2.Models;

namespace Cliente.Views.Nomina
{
    public partial class EmpleadoView : System.Web.UI.Page
    {
        private EmpleadoBLL bllEmpleado = new EmpleadoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //llenarTabla();
            if (txtBuscar.Text.Length > 0)
            {
                grdEmpleado.DataSource = bllEmpleado.getEmpleadoByNombreDataTable(txtBuscar.Text);
            }
            else
            {
                grdEmpleado.DataSource = bllEmpleado.listarEmpleado();
            }
            grdEmpleado.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EmpleadoModel a = new EmpleadoModel();
            a.id = idEmpleado.Text.Trim();
            a.nombre = nombreEmpleado.Text.Trim();
            a.apellido = apellidoEmpleado.Text.Trim();
            a.cedula = cedulaEmpleado.Text.Trim();
            a.fechaIngreso = DateTime.Parse(fechaIngresoEmpleado.SelectedDate.ToString());
            a.sueldo = sueldoEmpleado.Text.Trim();
            bllEmpleado.insertarEmpleado(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void grdEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreEmpleado.Text = grdEmpleado.SelectedDataKey["nombre"].ToString();
            apellidoEmpleado.Text = grdEmpleado.SelectedDataKey["apellido"].ToString();
            cedulaEmpleado.Text = grdEmpleado.SelectedDataKey["cedula"].ToString();
            fechaIngresoEmpleado.SelectedDate = DateTime.Parse(grdEmpleado.SelectedDataKey["fechaIngreso"].ToString());
            sueldoEmpleado.Text = grdEmpleado.SelectedDataKey["sueldo"].ToString();
            usuarioEmpleado.Text = grdEmpleado.SelectedDataKey["usuario"].ToString();
            contrasenaEmpleado.Text = grdEmpleado.SelectedDataKey["contrasena"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EmpleadoModel a = new EmpleadoModel();
            a.id = grdEmpleado.SelectedDataKey["id"].ToString();
            a.nombre = nombreEmpleado.Text.Trim();
            a.apellido = apellidoEmpleado.Text.Trim();
            a.cedula = cedulaEmpleado.Text.Trim();
            a.fechaIngreso = DateTime.Parse(fechaIngresoEmpleado.SelectedDate.ToString());
            a.sueldo = sueldoEmpleado.Text.Trim();
            a.usuario = usuarioEmpleado.Text.Trim();
            a.contrasena = contrasenaEmpleado.Text.Trim();

            bllEmpleado.actualizarEmpleado(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdEmpleado.SelectedDataKey["id"].ToString();
            bllEmpleado.eliminarEmpleado(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            grdEmpleado.DataSource = bllEmpleado.listarEmpleado();
            grdEmpleado.DataBind();
        }
        private void limpiarFormulario()
        {
            nombreEmpleado.Text = String.Empty;
            apellidoEmpleado.Text = String.Empty;
            cedulaEmpleado.Text = String.Empty;
            fechaIngresoEmpleado.SelectedDate = DateTime.UtcNow;
            sueldoEmpleado.Text = String.Empty;
        }
    }
}