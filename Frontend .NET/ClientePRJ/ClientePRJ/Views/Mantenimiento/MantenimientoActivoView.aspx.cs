using ClientePRJ.BLL.Contabilidad;
using ClientePRJ.BLL.Mantenimiento;
using ClientePRJ.Models.Contabilidad;
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
    public partial class MantenimientoActivo : System.Web.UI.Page
    {
        ActivoBLL activoBLL = new ActivoBLL();
        CatalogoActividadBLL catalogoActividadBLL = new CatalogoActividadBLL();
        ActividadBLL actividadBLL = new ActividadBLL();
        DetalleActividadBLL detalleActividadBLL = new DetalleActividadBLL();

        private AsientoBLL asientoBLL = new AsientoBLL();
        private DetalleAsientoBLL objDetalleBll = new DetalleAsientoBLL();
        private CuentaBLL objBllCuenta = new CuentaBLL();
        private static DataTable dtDetalle;
        private static DataTable dtAsiento;
        private decimal _TotalDebe = 0;
        private decimal _TotalHaber = 0;
        private int idCabecera = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCatActividades();
                cargarResponsables();
                cargarActivos();
                llenarTabla();
                estadoBotones(true);
                dtDetalle = createDtDetalle();
                dtAsiento = createDtAsiento();
            }
        }

        public void cargarCatActividades()
        {
            cmbCatActividad.DataSource = catalogoActividadBLL.getAllCatalogoActividades();
            cmbCatActividad.DataTextField = "nombrecatactividad";
            cmbCatActividad.DataValueField = "idcatactividad";
            cmbCatActividad.DataBind();
        }

        public void cargarResponsables()
        {
            cmbResponsable.DataSource = actividadBLL.getAllResponsablesActividades();
            cmbResponsable.DataBind();
        }

        public void cargarActivos()
        {
            cmbActivo.DataSource = activoBLL.getAllActivos();
            cmbActivo.DataTextField = "nombreactivo";
            cmbActivo.DataValueField = "idactivo";
            cmbActivo.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////

        private void llenarTabla()
        {
            DataTable grdActividad = actividadBLL.listarActividades();
            DataView dvCuentas = grdActividad.DefaultView;
            dvCuentas.Sort = "idactividad ASC";
            grdDatos.DataSource = grdActividad;
            grdDatos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            DataTable grdActividad = actividadBLL.getActividadesByFecha(DateTime.Parse(calendarBuscar.SelectedDate.ToString()));
            grdDatos.DataSource = grdActividad;
            grdDatos.DataBind();
            
        }

        protected void btnBuscar2_Click(object sender, EventArgs e)
        {

            DataTable grdActividad = actividadBLL.getActividadesByResponsable(txtResponsable.Text);
            grdDatos.DataSource = grdActividad;
            grdDatos.DataBind();

        }
        protected void grdDetalleActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbActivo.SelectedValue = grdDetalleActividad.SelectedDataKey["idactivo"].ToString();
            cmbCatActividad.SelectedValue = grdDetalleActividad.SelectedDataKey["idcatactividad"].ToString();
            valor.Text = grdDetalleActividad.SelectedDataKey["valordetalleactividad"].ToString();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        protected void grdDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechaActividad.SelectedDate = DateTime.Parse(grdDatos.SelectedDataKey["fechaactividad"].ToString());
            List<DetalleActividadModel> lista = detalleActividadBLL
                .getAllDetallesActividadesByActividadId(grdDatos.SelectedDataKey["idactividad"].ToString());

            DataTable grdCatActividad = catalogoActividadBLL.listarCatalogosActividades();
            DataTable grdActivo = activoBLL.listarActivos();
            dtDetalle = createDtDetalle();

            foreach (DetalleActividadModel item in lista)
            {
                DataRow row = dtDetalle.NewRow();
                foreach (DataRow row1 in grdCatActividad.Rows)
                {
                    if (item.idcatactividad.ToString() == row1["idcatactividad"].ToString())
                    {
                        foreach (DataRow row2 in grdActivo.Rows)
                        {
                            System.Diagnostics.Debug.WriteLine(row2["idactivo"].ToString());
                            if (item.idactivo.ToString() == row2["idactivo"].ToString())
                            {
                                //System.Diagnostics.Debug.WriteLine("iddetalleactividad " + item.iddetalleactividad);
                                row["idactivo"] = row2["idactivo"];
                                row["nombreactivo"] = row2["nombreactivo"];
                                row["idcatactividad"] = row1["idcatactividad"];
                                row["nombrecatactividad"] = row1["nombrecatactividad"];
                                row["valordetalleactividad"] = item.valordetalleactividad.ToString();
                                dtDetalle.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            calcularTotal(dtDetalle);
            grdDetalleActividad.DataSource = dtDetalle;
            grdDetalleActividad.DataBind();
            estadoBotones(false);
        }

        protected void btnAgregarDetalleActividad_Click(object sender, EventArgs e)
        {
            if (validarDetalle())
            {
                DataRow dr = dtDetalle.NewRow();
                dr["idactivo"] = cmbActivo.SelectedValue.ToString();
                dr["nombreactivo"] = cmbActivo.SelectedItem.ToString();
                dr["idcatactividad"] = cmbCatActividad.SelectedValue.ToString();
                dr["nombrecatactividad"] = cmbCatActividad.SelectedItem.ToString();
                dr["valordetalleactividad"] = valor.Text.ToString();
                dtDetalle.Rows.Add(dr);
                calcularTotal(dtDetalle);
                grdDetalleActividad.DataSource = dtDetalle;
                grdDetalleActividad.DataBind();
                limpiarDetalle();
            }
            else
            {
                string script = "alert('Detalle no es válido');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

            }
        }

        protected void btnEditarDetalleActividad_Click(object sender, EventArgs e)
        {
            List<DataRow> rowsToEdit = new List<DataRow>();
            foreach (DataRow item in dtDetalle.Rows)
            {
                System.Diagnostics.Debug.WriteLine(item["iddetalle"].ToString());
                if (item["iddetalle"].ToString().Equals(grdDetalleActividad.SelectedDataKey["iddetalle"].ToString()))
                    rowsToEdit.Add(item);
            }
            foreach (DataRow item in rowsToEdit)
            {
                dtDetalle.Rows.Remove(item);
                DataRow dr = dtDetalle.NewRow();
                dr["idactivo"] = cmbActivo.SelectedValue.ToString();
                dr["nombreactivo"] = cmbActivo.SelectedItem.ToString();
                dr["idcatactividad"] = cmbCatActividad.SelectedValue.ToString();
                dr["nombrecatactividad"] = cmbCatActividad.SelectedItem.ToString();
                dr["valordetalleactividad"] = valor.Text.ToString();
                dtDetalle.Rows.Add(dr);
            }
            dtDetalle.AcceptChanges();
            calcularTotal(dtDetalle);
            grdDetalleActividad.DataSource = dtDetalle;
            grdDetalleActividad.DataBind();
            limpiarDetalle();
        }
        protected void btnQuitarDetalleActividad_Click(object sender, EventArgs e)
        {
            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow item in dtDetalle.Rows)
            {
                if (item["iddetalle"].ToString().Equals(grdDetalleActividad.SelectedDataKey["iddetalle"].ToString()))
                {
                    rowsToDelete.Add(item);
                }

            }
            foreach (DataRow item in rowsToDelete)
            {
                dtDetalle.Rows.Remove(item);

            }
            dtDetalle.AcceptChanges();
            calcularTotal(dtDetalle);
            grdDetalleActividad.DataSource = dtDetalle;
            grdDetalleActividad.DataBind();
            limpiarDetalle();
        }

        private DataTable createDtDetalle()
        {
            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("iddetalle");
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;

            dt.Columns.Add("idactivo");
            dt.Columns.Add("nombreactivo");
            dt.Columns.Add("idcatactividad");
            dt.Columns.Add("nombrecatactividad");
            dt.Columns.Add("valordetalleactividad");
            return dt;
        }

        private void guardarDetalles()
        {
            ActividadModel actividad = actividadBLL.getLastActividad();
            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                DetalleActividadModel obj = new DetalleActividadModel();
                obj.iddetalleactividad = null;
                obj.idactividad = actividad.idactividad;
                obj.idcatactividad = dtDetalle.Rows[i]["idcatactividad"].ToString();
                obj.idactivo = dtDetalle.Rows[i]["idactivo"].ToString();
                obj.valordetalleactividad = Double.Parse(dtDetalle.Rows[i]["valordetalleactividad"].ToString());
                detalleActividadBLL.insertarDetalleActividad(obj);
            }
        }

        private void actualizarDetalles()
        {
            string idactividad = grdDatos.SelectedDataKey["idactividad"].ToString();
            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                DetalleActividadModel obj = new DetalleActividadModel();
                obj.iddetalleactividad = null;
                obj.idactividad = idactividad;
                obj.idcatactividad = dtDetalle.Rows[i]["idcatactividad"].ToString();
                obj.idactivo = dtDetalle.Rows[i]["idactivo"].ToString();
                obj.valordetalleactividad = Double.Parse(dtDetalle.Rows[i]["valordetalleactividad"].ToString());
                detalleActividadBLL.insertarDetalleActividad(obj);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActividadModel a = new ActividadModel();
            a.idactividad = null;
            a.fechaactividad = DateTime.Parse(fechaActividad.SelectedDate.ToString());
            a.responsableactividad = cmbResponsable.SelectedValue.ToString();
            actividadBLL.insertarActividad(a);
            guardarDetalles();
            llenarTabla();
            limpiarTotal();
            limpiarFormulario();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ActividadModel a = new ActividadModel();
            a.idactividad = grdDatos.SelectedDataKey["idactividad"].ToString();
            a.fechaactividad = DateTime.Parse(fechaActividad.SelectedDate.ToString());
            a.responsableactividad = cmbResponsable.SelectedValue.ToString();
            actividadBLL.actualizarActividad(a);
            eliminarDetalles(a.idactividad);
            actualizarDetalles();
            llenarTabla();
            limpiarTotal();
            limpiarFormulario();
        }
        private void activarBoton(Button btn, bool estado)
        {
            btn.Enabled = estado;
            btn.CssClass = !estado ? "btn btn-secondary" : "btn btn-primary";
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdDatos.SelectedDataKey["idactividad"].ToString();
            eliminarDetalles(id);
            actividadBLL.eliminarActividad(id);
            llenarTabla();
            limpiarTotal();
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            fechaActividad.SelectedDate = DateTime.Now;
            dtAsiento = createDtAsiento();
            grdDetalles.DataSource = null;
            grdDetalles.DataBind();
            dtDetalle = createDtDetalle();
            grdDetalleActividad.DataSource = null;
            grdDetalleActividad.DataBind();

            limpiarDetalle();
            estadoBotones(true);
        }
        private void limpiarDetalle()
        {
            valor.Text = "0";
        }
        private void limpiarTotal()
        {
            valorTotal.Text = "0";
        }
        private void estadoBotones(bool estado)
        {
            activarBoton(btnGuardar, estado);
            activarBoton(btnEditar, !estado);
            activarBoton(btnCancelar, !estado);
            activarBoton(btnEliminar, !estado);
            activarBoton(btnCrearAsiento, !estado);
        }
        private Boolean validarDetalle()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(valor.Text)) esValido = false;
            return esValido;
        }

        private void eliminarDetalles(String idcabecera)
        {
            detalleActividadBLL.deleteDetalleActividadPorCabecera(idcabecera);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarTotal();
            limpiarDetalle();
            limpiarFormulario();
            estadoBotones(true);
        }

        private void calcularTotal(DataTable dtDetalle)
        {
            double total = 0;
            foreach (DataRow row in dtDetalle.Rows)
            {
                total += Double.Parse(row["valordetalleactividad"].ToString());
            }
            valorTotal.Text = total.ToString();
        }

        /////////////////////////////////////////////////////////////////////////////

        protected void dtAsiento_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Cells[0].Text = cm.nombrecuenta;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "TOTAL:";
                    e.Row.Cells[1].Text = _TotalDebe.ToString();
                    e.Row.Cells[2].Text = _TotalHaber.ToString();
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception err)
            {
                string error = err.Message.ToString() + " - " + err.Source.ToString();
            }
            
        }

        private void guardarDetallesAsiento()
        {
            for (int i = 0; i < dtAsiento.Rows.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("idcuenta " + dtAsiento.Rows[i]["idcuenta"].ToString());
                DetalleAsientoModel obj = new DetalleAsientoModel();
                obj.idcuenta = int.Parse(dtAsiento.Rows[i]["idcuenta"].ToString());
                obj.debedetalle = decimal.Parse(dtAsiento.Rows[i]["debedetalle"].ToString());
                obj.haberdetalle = decimal.Parse(dtAsiento.Rows[i]["haberdetalle"].ToString());
                obj.idasiento = idCabecera;
                objDetalleBll.insertar(obj);
            }
            
        }

        private DataTable createDtAsiento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idcuenta", typeof(int));
            dt.Columns.Add("debedetalle", typeof(decimal));
            dt.Columns.Add("haberdetalle", typeof(decimal));
            return dt;
        }

        protected void btnCrearAsiento_Click(object sender, EventArgs e)
        {
            agregarAsientos();
            AsientoModel a = new AsientoModel();
            a.fechaasiento = DateTime.Parse(fechaActividad.SelectedDate.ToString());
            a.observacionasiento = "Mantenimiento Activos";
            idCabecera=int.Parse(asientoBLL.insertar(a));
            guardarDetallesAsiento();
        }
        private void agregarAsientos()
        {
            dtAsiento = createDtAsiento();

            DataRow dr = dtAsiento.NewRow();
            
            dr["idcuenta"] = 9;
            dr["debedetalle"] = Decimal.Parse(valorTotal.Text);
            dr["haberdetalle"] = 0;

            dtAsiento.Rows.Add(dr);

            dr = dtAsiento.NewRow();

            dr["idcuenta"] = 13;
            dr["debedetalle"] = 0;
            dr["haberdetalle"] = Decimal.Parse(valorTotal.Text);

            dtAsiento.Rows.Add(dr);
            grdDetalles.DataSource = dtAsiento;

            grdDetalles.DataBind();
        }
    }
}