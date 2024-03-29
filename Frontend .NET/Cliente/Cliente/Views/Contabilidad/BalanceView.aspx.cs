using Cliente.BLL.Contabilidad;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Views.Contabilidad
{
    public partial class BalanceView : System.Web.UI.Page
    {
        private AsientoBLL asientoBLL = new AsientoBLL();
        private DetalleAsientoBLL detalleBLL = new DetalleAsientoBLL();
        private CuentaBLL cuentaBLL = new CuentaBLL();
        private static DataTable dtBalance;
        private static DataTable dtDetalles;
        private static DataTable dtCuentas ;
        private static DataTable dtTotales ;
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
            dt.Columns.Add("idcuenta", typeof(string));
            dt.Columns.Add("numerocuenta", typeof(string));
            dt.Columns.Add("nombrecuenta", typeof(string));            
            dt.Columns.Add("descripcioncuenta", typeof(string));            
            dt.Columns.Add("totalcuenta", typeof(string));            
            return dt;
        }
        private DataTable createDtDetalle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("iddetalle", typeof(string));            
            dt.Columns.Add("idcuenta", typeof(string));
            dt.Columns.Add("debedetalle", typeof(string));
            dt.Columns.Add("haberdetalle", typeof(string));
            dt.Columns.Add("idasiento", typeof(string));

            return dt;
        }
        private void calcularEcuacionContable()
        {
            
            double activo = 0;
            double pasivo = 0;
            double patrimonio = 0;
            double total = 0;
            double valoraux=0;
            string tipo;

            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                tipo = dtCuentas.Rows[i]["numerocuenta"].ToString().Substring(0, 1);
                valoraux = 0;
                switch (tipo)
                {
                    case "1":
                        Double.TryParse(dtCuentas.Rows[i]["totalcuenta"].ToString(), out valoraux);
                        activo += valoraux;
                        break;
                    case "2":
                        Double.TryParse(dtCuentas.Rows[i]["totalcuenta"].ToString(), out valoraux);
                        pasivo += valoraux;
                        break;
                    case "3":
                        Double.TryParse(dtCuentas.Rows[i]["totalcuenta"].ToString(), out valoraux);
                        patrimonio += valoraux;
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
            dtTotales.Columns.Add("totalactivo", typeof(double));
            dtTotales.Columns.Add("totalpasivo", typeof(double));
            dtTotales.Columns.Add("totalpatrimonio", typeof(double));
            dtTotales.Columns.Add("total", typeof(double));            
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
            if (dtDetalles.Rows.Count>0)
            {
                filtrarFechas();
                asignarValoresCuentas();
                calcularEcuacionContable();
                calcularCuentasPadre();
            }
            

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
                List<AsientoModel> lst = asientobll.getById(idactual);
                AsientoModel a = new AsientoModel();
                a = asientobll.getById(idactual)[0];
                DateTime fechaAsiento = a.fechaasiento;
                DateTime fechaInicio = calendarBuscar.SelectedDate;
                DateTime fechaFin = calendarBuscarFin.SelectedDate;
                 esmayor = DateTime.Compare(fechaAsiento, fechaInicio);
                 esmenor = DateTime.Compare(fechaAsiento, fechaFin);
                if (!(esmayor >= 0 && esmenor <= 0))
                    rowsToDelete.Add(item);
            }
            if(rowsToDelete.Count>0)
            foreach (DataRow item in rowsToDelete)
            {
                dtDetalles.Rows.Remove(item);

            }
            dtDetalles.AcceptChanges();
            
        }
        private double calcularValorHijos(string numerocuenta,double totalCuenta)
        {
            
            string tipo = numerocuenta.Substring(0, 1);
            string numerocuentaActual;
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                numerocuentaActual = dtCuentas.Rows[i]["numerocuenta"].ToString();
                if (numerocuentaActual.Substring(0, 1).Equals(tipo))
                {
                    if (numerocuenta.Length < numerocuentaActual.Length)
                    {
                        totalCuenta += Double.Parse(numerocuentaActual = dtCuentas.Rows[i]["totalcuenta"].ToString());
                    }
                }
                
            }

                return totalCuenta;
        }
        private void calcularCuentasPadre()
        {
            double sumatotal = 0;            
            double totalActual ;            
            string numCuenta;
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {                
                numCuenta = dtCuentas.Rows[i]["numerocuenta"].ToString();
                totalActual = Double.Parse(dtCuentas.Rows[i]["totalcuenta"].ToString());
                sumatotal = calcularValorHijos(numCuenta,totalActual);
                dtCuentas.Rows[i]["totalcuenta"] = sumatotal;

            }
            grdDatos.DataSource = dtCuentas;
            grdDatos.DataBind();

        }
        private void asignarValoresCuentas()
        {
            double totaldebe = 0;
            double totalhaber= 0;
            DataView dv1 = dtDetalles.DefaultView;
            string tipo;
            //if(dv1.Count>0)
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                 totaldebe = 0;
                 totalhaber = 0;
                dv1.RowFilter="idcuenta='"+ dtCuentas.Rows[i]["idcuenta"].ToString() + "'";                
                tipo = dtCuentas.Rows[i]["numerocuenta"].ToString().Substring(0, 1);
                if (dv1.Count > 0)
                {

                    foreach (DataRowView row in dv1)
                    {
                        totaldebe += double.Parse((row["debedetalle"].ToString()));
                        totalhaber += double.Parse((row["haberdetalle"].ToString()));                        
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
                        dtCuentas.Rows[i]["totalcuenta"] = (totalhaber-totaldebe);
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
                if (item["numerocuenta"].ToString().StartsWith("4")|| item["numerocuenta"].ToString().StartsWith("5"))
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
                    cm.nombrecuenta = cuentaBLL.getByIdDataTable(cuenta).Rows[0]["nombrecuenta"].ToString();
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