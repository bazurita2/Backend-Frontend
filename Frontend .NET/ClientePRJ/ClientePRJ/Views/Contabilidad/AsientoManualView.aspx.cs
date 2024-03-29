using ClientePRJ.BLL.Contabilidad;
using ClientePRJ.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ClientePRJ.Views.Contabilidad
{
    public partial class AsientoManualView : System.Web.UI.Page
    {
        private AsientoBLL objBll = new AsientoBLL();
        private DetalleAsientoBLL objDetalleBll = new DetalleAsientoBLL();
        private CuentaBLL objBllCuenta = new CuentaBLL();
        private static DataTable dtDetalle;
        private decimal _TotalDebe = 0;
        private decimal _TotalHaber = 0;
        private int idCabecera = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
                cargarCombos();
                iniciarControles();
                estadoBotones(true);
                dtDetalle = createDtDetalle();
            }
        }

        private DataTable createDtDetalle()
        {
            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("iddetalleasiento", typeof(int));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dt.Columns.Add("idcuenta", typeof(int));
            dt.Columns.Add("debedetalle", typeof(decimal));
            dt.Columns.Add("haberdetalle", typeof(decimal));
            //dt.Columns.Add("nombrecuenta", typeof(string));
            return dt;
        }

        private void cargarCombos()
        {
            String value;
            String nombre;
            DataTable dtcuenta = objBllCuenta.listar();
            foreach (DataRow row in dtcuenta.Rows)
            {
                value = row["idcuenta"].ToString();
                nombre = row["nombrecuenta"].ToString() + "[" + row["numerocuenta"].ToString() + "]";
                ListItem i;
                i = new ListItem(nombre, value);
                ddlcuenta.Items.Add(i);
            }
            //ddlcuenta.DataSource = objBllCuenta.listar();
            //ddlcuenta.DataTextField = "nombrecuenta";                            // FieldName of Table in DataBase
            //ddlcuenta.DataValueField = "idcuenta";
            //ddlcuenta.DataBind();
            //ddlcuenta.data
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //llenarTabla();
            grdDatos.DataSource = objBll.getByFechas(
                DateTime.Parse(calendarBuscar.SelectedDate.ToString()),
                DateTime.Parse(calendarBuscarFin.SelectedDate.ToString())
                );
            grdDatos.DataBind();
        }

        private void guardarDetalles()
        {
           
            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                DetalleAsientoModel obj = new DetalleAsientoModel();
                obj.idcuenta =int.Parse(dtDetalle.Rows[i]["idcuenta"].ToString());
                obj.debedetalle = decimal.Parse(dtDetalle.Rows[i]["debedetalle"].ToString());
                obj.haberdetalle = decimal.Parse(dtDetalle.Rows[i]["haberdetalle"].ToString());
                obj.idasiento = idCabecera;
                objDetalleBll.insertar(obj);
            }
        }
        private void ActualizarDetalles()
        {


            int idasiento = int.Parse(grdDatos.SelectedDataKey["idasiento"].ToString());
            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                DetalleAsientoModel obj = new DetalleAsientoModel();
                obj.idcuenta = int.Parse(dtDetalle.Rows[i]["idcuenta"].ToString());
                obj.debedetalle = decimal.Parse(dtDetalle.Rows[i]["debedetalle"].ToString());
                obj.haberdetalle =decimal.Parse(dtDetalle.Rows[i]["haberdetalle"].ToString());
                obj.idasiento = idasiento;
                objDetalleBll.insertar(obj);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarAsiento())
            {
                AsientoModel a = new AsientoModel();
                a.fechaasiento = DateTime.Parse(fechaAsiento.SelectedDate.ToString());
                a.observacionasiento = observacionAsiento.Text.Trim();
                var prueba= objBll.insertar(a);
                idCabecera = int.Parse(prueba);
                guardarDetalles();
                llenarTabla();
                limpiarFormulario();
            }
            else
            {
                string script = "alert('Asiento no es válido');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }

        protected void grdDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            observacionAsiento.Text = grdDatos.SelectedDataKey["observacionasiento"].ToString();
            fechaAsiento.SelectedDate = DateTime.Parse(grdDatos.SelectedDataKey["fechaasiento"].ToString());
            dtDetalle = objDetalleBll.getById(int.Parse(grdDatos.SelectedDataKey["idasiento"].ToString()));
            grdDetalles.DataSource = dtDetalle;
            grdDetalles.DataBind();
            estadoBotones(false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (validarAsiento())
            {
                AsientoModel a = new AsientoModel();
                a.idasiento = int.Parse(grdDatos.SelectedDataKey["idasiento"].ToString());
                a.fechaasiento = DateTime.Parse(fechaAsiento.SelectedDate.ToString());
                a.observacionasiento = observacionAsiento.Text.Trim();
                objBll.actualizar(a);
                eliminarDetalles(a.idasiento);
                ActualizarDetalles();
                llenarTabla();
                limpiarFormulario();
            }
            else
            {
                string script = "alert('Asiento no es válido');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }

        private void activarBoton(Button btn, bool estado)
        {
            btn.Enabled = estado;

            btn.CssClass = !estado ? "btn btn-secondary" : "btn btn-primary";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grdDatos.SelectedDataKey["idasiento"].ToString());
            eliminarDetalles(id);
            objBll.eliminar(id);
            llenarTabla();
            limpiarFormulario();
        }

        private void llenarTabla()
        {
            grdDatos.DataSource = objBll.listar();
            grdDatos.DataBind();
        }

        private void limpiarFormulario()
        {
            fechaAsiento.SelectedDate = DateTime.Now;
            observacionAsiento.Text = String.Empty;
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();

            limpiarDetalle();
        }

        private void limpiarDetalle()
        {
            debeAsiento.Text = "0";
            haberAsiento.Text = "0";
            ddlcuenta.SelectedIndex = 0;
        }

        private void iniciarControles()
        {
            debeAsiento.Text = "0";
            haberAsiento.Text = "0";
        }

        private void estadoBotones(bool estado)
        {
            activarBoton(btnGuardar, estado);
            activarBoton(btnEditar, !estado);
            activarBoton(btnCancelar, !estado);
            activarBoton(btnEliminar, !estado);
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private Boolean validarDetalle()
        {
            Boolean esValido = true;
            if (debeAsiento.Text.Equals("0") && haberAsiento.Text.Equals("0")) esValido = false;
            return esValido;
        }

        private Boolean validarAsiento()
        {
            Boolean esvalido = true;
            if (grdDetalles.Rows.Count == 0)
            {
                esvalido = false;
                return false;
            }

            if (grdDetalles.FooterRow.Cells[3].Text != grdDetalles.FooterRow.Cells[4].Text) esvalido = false;
            return esvalido;
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (validarDetalle())
            {
                DataRow dr = dtDetalle.NewRow();

                dr["debedetalle"] = debeAsiento.Text;
                dr["haberdetalle"] = haberAsiento.Text;
                dr["idcuenta"] = ddlcuenta.SelectedValue.ToString();
                //dr["nombrecuenta"] = ddlcuenta.SelectedItem.ToString();
                dtDetalle.Rows.Add(dr);
                grdDetalles.DataSource = dtDetalle;
                grdDetalles.DataBind();
                limpiarDetalle();
            }
            else
            {
                string script = "alert('Detalle no es válido');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }

        protected void dtDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String cuenta = "";
            CuentaModel cm = new CuentaModel();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _TotalDebe += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "debedetalle"));
                    _TotalHaber += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "haberdetalle"));
                    cuenta = DataBinder.Eval(e.Row.DataItem, "idcuenta").ToString();
                    cm.nombrecuenta = objBllCuenta.getByIdDataTable(int.Parse(cuenta)).Rows[0]["nombrecuenta"].ToString();
                    e.Row.Cells[2].Text = cm.nombrecuenta;
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "TOTAL:";
                    e.Row.Cells[3].Text = _TotalDebe.ToString();
                    e.Row.Cells[4].Text = _TotalHaber.ToString();
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception err)
            {
                string error = err.Message.ToString() + " - " + err.Source.ToString();
            }
        }

        protected void grdDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            debeAsiento.Text = grdDetalles.SelectedDataKey["debedetalle"].ToString();
            haberAsiento.Text = grdDetalles.SelectedDataKey["haberdetalle"].ToString();
            ddlcuenta.SelectedValue = grdDetalles.SelectedDataKey["idcuenta"].ToString();
        }

        private void eliminarDetalles(int idcabecera)
        {
            objDetalleBll.eliminarPorCabecera(idcabecera);
        }

        protected void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow item in dtDetalle.Rows)
            {
                if (item["iddetalleasiento"].ToString().Equals(grdDetalles.SelectedDataKey["iddetalleasiento"].ToString()))
                    rowsToDelete.Add(item);
            }
            foreach (DataRow item in rowsToDelete)
            {
                dtDetalle.Rows.Remove(item);
            }
            dtDetalle.AcceptChanges();
            grdDetalles.DataSource = dtDetalle;
            grdDetalles.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDetalle();
            limpiarFormulario();
        }

        protected void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            List<DataRow> rowsToEdit = new List<DataRow>();
            foreach (DataRow item in dtDetalle.Rows)
            {
                if (item["iddetalleasiento"].ToString().Equals(grdDetalles.SelectedDataKey["iddetalleasiento"].ToString()))
                    rowsToEdit.Add(item);
            }
            foreach (DataRow item in rowsToEdit)
            {
                dtDetalle.Rows.Remove(item);
                DataRow dtnueva = dtDetalle.NewRow();
                dtnueva["idcuenta"] = ddlcuenta.SelectedValue.ToString();
                dtnueva["debedetalle"] = debeAsiento.Text.ToString();
                dtnueva["haberdetalle"] = haberAsiento.Text.ToString();
                dtDetalle.Rows.Add(dtnueva);
            }
            dtDetalle.AcceptChanges();
            grdDetalles.DataSource = dtDetalle;
            grdDetalles.DataBind();
        }
    }
}