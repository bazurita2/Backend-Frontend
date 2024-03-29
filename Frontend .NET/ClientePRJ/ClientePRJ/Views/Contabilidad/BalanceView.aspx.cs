using ClientePRJ.BLL.Contabilidad;
using ClientePRJ.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ClientePRJ.Views.Contabilidad
{
    public partial class BalanceView : System.Web.UI.Page
    {
        private AsientoBLL asientoBLL = new AsientoBLL();
        private DetalleAsientoBLL detalleBLL = new DetalleAsientoBLL();
        private CuentaBLL cuentaBLL = new CuentaBLL();
        private static DataTable dtBalance;
        private static DataTable dtDetalles;
        private static DataTable dtCuentas;
        private static DataTable dtTotales;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dtCuentas = createDtCuentas();
                dtDetalles = createDtDetalle();
                dtTotales = createDtTotales();
            }
        }
        private DataTable createDtCuentas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idcuenta", typeof(int));
            dt.Columns.Add("numerocuenta", typeof(string));
            dt.Columns.Add("nombrecuenta", typeof(string));
            dt.Columns.Add("descripcioncuenta", typeof(string));
            dt.Columns.Add("totalcuenta", typeof(decimal));
            return dt;
        }
        private DataTable createDtDetalle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("iddetalle", typeof(int));
            dt.Columns.Add("idcuenta", typeof(int));
            dt.Columns.Add("debedetalle", typeof(decimal));
            dt.Columns.Add("haberdetalle", typeof(decimal));
            dt.Columns.Add("idasiento", typeof(int));

            return dt;
        }
        private void calcularEcuacionContable()
        {

            decimal activo = 0;
            decimal pasivo = 0;
            decimal patrimonio = 0;
            decimal total = 0;
            string tipo;

            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                tipo = dtCuentas.Rows[i]["numerocuenta"].ToString().Substring(0, 1);
                switch (tipo)
                {
                    case "1":
                        activo +=Decimal.Parse(dtCuentas.Rows[i]["totalcuenta"].ToString());
                        break;
                    case "2":
                        pasivo += Decimal.Parse(dtCuentas.Rows[i]["totalcuenta"].ToString());
                        break;
                    case "3":
                        patrimonio += Decimal.Parse(dtCuentas.Rows[i]["totalcuenta"].ToString());
                        break;
                    default:
                        break;
                }

            }
            total = activo - (pasivo + patrimonio);
            DataRow row = dtTotales.NewRow();
            row["totalactivo"] = activo;
            row["totalpasivo"] = pasivo;
            row["totalpatrimonio"] = patrimonio;
            row["total"] = total;
            dtTotales.Rows.Add(row);
            grdTotales.DataSource = dtTotales;
            grdTotales.DataBind();
        }
        private DataTable createDtTotales()
        {
            DataTable dtTotales = new DataTable();
            dtTotales.Columns.Add("totalactivo", typeof(decimal));
            dtTotales.Columns.Add("totalpasivo", typeof(decimal));
            dtTotales.Columns.Add("totalpatrimonio", typeof(decimal));
            dtTotales.Columns.Add("total", typeof(decimal));
            return dtTotales;
        }
        private void limpiarGrillas()
        {
            dtTotales = createDtTotales();
            dtDetalles = createDtDetalle();
            dtCuentas = createDtCuentas();

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarGrillas();
            dtCuentas = cuentaBLL.listar();

            DataView dvCuentas = dtCuentas.DefaultView;
            dvCuentas.Sort = "numerocuenta ASC";
            dtCuentas.Columns.Add("totalcuenta", typeof(string));
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();
            eliminarFilasNoBalance();

           dtDetalles = detalleBLL.listar();
            grdDetalles.DataSource = dtDetalles;
            grdDetalles.DataBind();
            filtrarFechas();
            asignarValoresCuentas();
            calcularEcuacionContable();
            calcularCuentasPadre();

        }

        private void filtrarFechas()
        {
            String idactual;
            AsientoBLL asientobll = new AsientoBLL();
            List<DataRow> rowsToDelete = new List<DataRow>();

            int esmayor;
            int esmenor;         
            foreach (DataRow item in dtDetalles.Rows)
            {

                idactual = item["idasiento"].ToString();

                
                //List<AsientoModel> lst = asientobll.getById(idactual);
                AsientoModel a = new AsientoModel();
                
                
                a = asientobll.getById(int.Parse(idactual));
                DateTime fechaAsiento = a.fechaasiento;
                DateTime fechaInicio = calendarBuscar.SelectedDate;
                DateTime fechaFin = calendarBuscarFin.SelectedDate;
                esmayor = DateTime.Compare(fechaAsiento, fechaInicio);
                esmenor = DateTime.Compare(fechaAsiento, fechaFin);
                if (!(esmayor >= 0 && esmenor <= 0))
                    rowsToDelete.Add(item);
            }
            if (rowsToDelete.Count > 0)
                foreach (DataRow item in rowsToDelete)
                {
                    dtDetalles.Rows.Remove(item);

                }
            dtDetalles.AcceptChanges();

        }
        
        private decimal calcularValorHijos(string numerocuenta, decimal totalCuenta)
        {

            string tipo = numerocuenta.Substring(0, 1);
            string numerocuentaActual;
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                numerocuentaActual = dtCuentas.Rows[i]["numerocuenta"].ToString();
                if (numerocuentaActual.Substring(0, 1).Equals(tipo))
                {
                    if (numerocuenta.Length < numerocuentaActual.Length&& (numerocuentaActual.Length - numerocuenta.Length == 2))
                    {
                        totalCuenta += decimal.Parse(numerocuentaActual = dtCuentas.Rows[i]["totalcuenta"].ToString());
                    }
                }

            }

            return totalCuenta;
        }
        private void calcularCuentasPadre()
        {
            decimal sumatotal = 0;
            decimal totalActual;
            string numCuenta;
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                numCuenta = dtCuentas.Rows[i]["numerocuenta"].ToString();
                totalActual = decimal.Parse(dtCuentas.Rows[i]["totalcuenta"].ToString());
                sumatotal = calcularValorHijos(numCuenta, totalActual);
                dtCuentas.Rows[i]["totalcuenta"] = sumatotal;

            }
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();

        }
        private void asignarValoresCuentas()
        {
            decimal totaldebe = 0;
            decimal totalhaber = 0;
            DataView dv1 = dtDetalles.DefaultView;
            string tipo;
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                totaldebe = 0;
                totalhaber = 0;
                dv1.RowFilter = "idcuenta='" + dtCuentas.Rows[i]["idcuenta"].ToString() + "'";
                tipo = dtCuentas.Rows[i]["numerocuenta"].ToString().Substring(0, 1);
                if (dv1.Count > 0)
                {

                    foreach (DataRowView row in dv1)
                    {
                        totaldebe += decimal.Parse((row["debedetalle"].ToString()));
                        totalhaber += decimal.Parse((row["haberdetalle"].ToString()));
                    }

                }
                else
                {
                    totaldebe = 0;
                    totalhaber = 0;
                }
                switch (tipo)
                {

                    case "1":
                        dtCuentas.Rows[i]["totalcuenta"] = (totaldebe - totalhaber);
                        break;
                    case "2":
                    case "3":
                        dtCuentas.Rows[i]["totalcuenta"] = (totalhaber - totaldebe);
                        break;
                    default:
                        break;
                }
            }

            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();
        }
        private void eliminarFilasNoBalance()
        {

            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow item in dtCuentas.Rows)
            {
                if (item["numerocuenta"].ToString().StartsWith("4") || item["numerocuenta"].ToString().StartsWith("5"))
                    rowsToDelete.Add(item);
            }
            foreach (DataRow item in rowsToDelete)
            {
                dtCuentas.Rows.Remove(item);

            }
            dtCuentas.AcceptChanges();
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();
        }
        protected void dtDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String cuenta = "";
            CuentaModel cm = new CuentaModel();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //_TotalDebe += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "debedetalle"));
                    //_TotalHaber += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "haberdetalle"));
                    cuenta = DataBinder.Eval(e.Row.DataItem, "idcuenta").ToString();
                    cm.nombrecuenta = cuentaBLL.getByIdDataTable(int.Parse(cuenta)).Rows[0]["nombrecuenta"].ToString();
                    e.Row.Cells[3].Text = cm.nombrecuenta;

                }

            }
            catch (Exception err)
            {
                string error = err.Message.ToString() + " - " + err.Source.ToString();
            }
        }
    }
}