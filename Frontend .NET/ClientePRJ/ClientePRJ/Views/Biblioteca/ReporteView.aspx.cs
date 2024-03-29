using ClientePRJ.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientePRJ.Views.Biblioteca
{
    public partial class ReporteView : System.Web.UI.Page
    {
        
        PrestamoBLL prestamoBLL = new PrestamoBLL();    
        DataTable dtRepo = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // dtRepo = createDtDetallePrestamo();
                /*
                   DataView dv = new DataView();
                   dv.RowFilter = "fechaEntregaDetalleP = 2022-11-15"; // query example = "id = 10"
                   //prestamoBLL.detallesTotal();
                   dv.
                   grdDetallesPrestamo.DataSource = dv;
                   grdDetallesPrestamo.DataBind();
                */

                LlenarTabla(null,null);
            }
        }

        private DataTable createDtDetallePrestamo()
        {

            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("idDetalleP", typeof(String));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dt.Columns.Add("idLibro", typeof(string));
            dt.Columns.Add("tituloLibro", typeof(string));
            dt.Columns.Add("cantidadDetalleP", typeof(string));
            dt.Columns.Add("fechaEntregaDetalleP", typeof(string));
            dt.Columns.Add("totalLibro", typeof(string));
            return dt;
        }

        protected void LlenarTabla(object sender, EventArgs e)
        {
            grdDetallesPrestamo.DataSource = prestamoBLL.detallesTotal();
            DataView dv = ((DataTable)grdDetallesPrestamo.DataSource).DefaultView;
            string fechaMin = DateTime.Parse(fechaMinima.SelectedDate.ToString()).ToString("yyyy-M-dd");
            string fechaMax = DateTime.Parse(fechaMaxima.SelectedDate.ToString()).ToString("yyyy-M-dd");
            dv.RowFilter = "fechaEntregaDetalleP > '" + fechaMin + "' AND fechaEntregaDetalleP < '"+ fechaMax + "'";
            //fechaEntregaDetalleP = '"+ DateTime.Parse(fechaMinima.SelectedDate.ToString()).ToString("yyyy-M-dd")+ "'
            // AND fechaEntregaDetalleP < '"+ DateTime.Parse(fechaMaxima.SelectedDate.ToString()).ToString("yyyy-M-dd") +"'
            grdDetallesPrestamo.DataSource = dv;
            grdDetallesPrestamo.DataBind();
        }
    }
}