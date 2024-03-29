using ClientePRJ.BLL;
using ClientePRJ.BLL.Contabilidad;
using ClientePRJ.DAL.Biblioteca;
using ClientePRJ.DAL.Contabilidad;
using ClientePRJ.Models.Biblioteca;
using ClientePRJ.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientePRJ.Views.Biblioteca
{
    public partial class PrestamoView : System.Web.UI.Page
    {
        private PrestamoBLL prestamoBLL = new PrestamoBLL();
        
        private LibroBLL libroBLL = new LibroBLL();
        private AsientoBLL acientoBLL = new AsientoBLL();
        private DetalleAsientoBLL detalleAsientoBLL = new DetalleAsientoBLL();
        private static decimal TotalDetalle = 0;
        private static double totalAsiento = 0;
        string numeroPrestamo = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
                llenarSelect();
                dtDetallePrestamo = createDtDetallePrestamo();
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


        private void llenarTabla()
        {
            grdPrestamo.DataSource = prestamoBLL.listarPrestamo();
            grdPrestamo.DataBind();

        }
        private static DataTable dtDetallePrestamo;
        private static DataTable dtLibro;

        private void llenarSelect()
        {
            dtLibro = libroBLL.listarLibro();
            libroList.DataSource = dtLibro;
            libroList.DataTextField = "tituloLibro";

            libroList.DataValueField = "idLibro";
            libroList.DataBind();
        }

        int idCabecera = 0;
        private void guardarDetallesAsiento()
        {
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           

            prestamoBLL.insertarPrestamo(llenarPrestamo());

            
        
            if (checkBoxGenerarAsiento.Checked)
            {
                Models.Contabilidad.AsientoModel asiento = new Models.Contabilidad.AsientoModel();
                asiento.observacionasiento = descripcionPrestamo.Text;
                asiento.fechaasiento = fechaPrestamo.SelectedDate;
                idCabecera = int.Parse(acientoBLL.insertar(asiento));

                DetalleAsientoModel obj = new DetalleAsientoModel();
                obj.idcuenta = int.Parse("11");
                obj.debedetalle = (decimal)TotalDetalle;
                obj.haberdetalle = 0;
                obj.idasiento = idCabecera;
                detalleAsientoBLL.insertar(obj);

                obj = obj = new DetalleAsientoModel();
                obj.idcuenta = int.Parse("13");
                obj.debedetalle = 0;
                obj.haberdetalle = (decimal)TotalDetalle;
                obj.idasiento = idCabecera;
                detalleAsientoBLL.insertar(obj);

                checkBoxGenerarAsiento.Checked = false;
                TotalDetalle = 0;
                totalAsiento = 0;
            }

            llenarTabla();
            limpiarDetalle();

            dtDetallePrestamo.Clear();
            grdDetallesPrestamo.DataBind();

        }

        protected PrestamoModel llenarPrestamo()
        {
            List<DetallePrestamoModel> detallesPrestamo = new List<DetallePrestamoModel>();

            for (int i = 0; i < dtDetallePrestamo.Rows.Count; i++)
            {
                DetallePrestamoModel detallePrestamo = new DetallePrestamoModel();
                string cantidadTmp = dtDetallePrestamo.Rows[i]["cantidadDetalleP"].ToString();
                detallePrestamo.cantidadDetalleP = Int32.Parse(cantidadTmp);
                detallePrestamo.idLibro = Int32.Parse(dtDetallePrestamo.Rows[i]["idLibro"].ToString());
                detallePrestamo.fechaEntregaDetalleP = DateTime.Parse(dtDetallePrestamo.Rows[i]["fechaEntregaDetalleP"].ToString()).ToString("yyyy-M-dd");
                detallesPrestamo.Add(detallePrestamo);
            }

            PrestamoModel prestamo = new PrestamoModel();
            prestamo.descripcionPrestamo = descripcionPrestamo.Text;
            prestamo.fechaPrestamo = DateTime.Parse(fechaPrestamo.SelectedDate.ToString()).ToString("yyyy-M-dd");
            prestamo.numeroPrestamo = 0;
            prestamo.detallesPrestamo = detallesPrestamo;

            return prestamo;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            prestamoBLL.eliminarPrestamo(grdPrestamo.SelectedDataKey["idPrestamo"].ToString());
            prestamoBLL.insertarPrestamo(llenarPrestamo());

            llenarTabla();
            limpiarDetalle();
            dtDetallePrestamo.Clear();
            grdDetallesPrestamo.DataBind();
            TotalDetalle = 0;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = "";
            if (grdPrestamo.SelectedDataKey["idPrestamo"].ToString() != null)
            {

                 id = grdPrestamo.SelectedDataKey["idPrestamo"].ToString();
            }
            prestamoBLL.eliminarPrestamo(id);
            llenarTabla();
            limpiarDetalle();
            dtDetallePrestamo.Clear();
            

        }

        protected void grdPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            idTransaccion.Text = grdPrestamo.SelectedDataKey["idTransaccion"].ToString();
            idEmpleado.Text = grdPrestamo.SelectedDataKey["idEmpleado"].ToString();
            estadoPrestamo.Text = grdPrestamo.SelectedDataKey["estadoPrestamo"].ToString();
            fechaPrestamo.SelectedDate = DateTime.Parse(grdPrestamo.SelectedDataKey["fechaPrestamo"].ToString());
            */




            descripcionPrestamo.Text = grdPrestamo.SelectedDataKey["descripcionPrestamo"].ToString();
            fechaPrestamo.SelectedDate = DateTime.Parse(grdPrestamo.SelectedDataKey["fechaPrestamo"].ToString()); 
            numeroPrestamo = grdPrestamo.SelectedDataKey["numeroPrestamo"].ToString();

            string id = grdPrestamo.SelectedDataKey["idPrestamo"].ToString();
            DataTable dtDetallePrestamoTmp = prestamoBLL.detallesDePrestamo(id);

          
            dtDetallePrestamoTmp.Columns.Add("tituloLibro", typeof(string));
            dtDetallePrestamoTmp.Columns.Add("totalLibro", typeof(string));


            dtDetallePrestamo.Clear();
           
            for(int i = 0; i < dtDetallePrestamoTmp.Rows.Count; i++)
            {
                DataRow dr = dtDetallePrestamo.NewRow();
                dr["idLibro"] = dtDetallePrestamoTmp.Rows[i]["idLibro"].ToString();
                for (int j = 0; j < dtLibro.Rows.Count; j++)
                {
                    if(dtLibro.Rows[j]["idLibro"].ToString().Equals(dr["idLibro"].ToString()))
                        dr["tituloLibro"] = dtLibro.Rows[j]["tituloLibro"].ToString();
                }
                   
                dr["fechaEntregaDetalleP"] = dtDetallePrestamoTmp.Rows[i]["fechaEntregaDetalleP"].ToString();
                dr["cantidadDetalleP"] = dtDetallePrestamoTmp.Rows[i]["cantidadDetalleP"].ToString();
                dr["totalLibro"] = getTotalCostoCantidadLibro(dr["idLibro"].ToString(), dr["cantidadDetalleP"].ToString());
                //dr["nombrecuenta"] = ddlcuenta.SelectedItem.ToString();
                dtDetallePrestamo.Rows.Add(dr);
            }

            grdDetallesPrestamo.DataSource = dtDetallePrestamo;
            grdDetallesPrestamo.DataBind();

        }

        protected string getTotalCostoCantidadLibro(string idLibro, string cantidad)
        {
            string totalString = "0";
            
           


            for(int i = 0; i < dtLibro.Rows.Count; i++)
            {
                if (dtLibro.Rows[i]["idLibro"].ToString().Equals(idLibro))
                {
                    float cantidadLibroFloat = float.Parse(cantidad);
                    float total = float.Parse(dtLibro.Rows[i]["valorPrestamoLibro"].ToString(), CultureInfo.InvariantCulture.NumberFormat) * cantidadLibroFloat;

                    totalString = total.ToString();
                    if (total > 2)
                    {
                        totalString = total.ToString();
                    }
                    return totalString;
                }
            }
            return totalString;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdPrestamo.DataSource = prestamoBLL.PrestamosByCoincidence(txtBuscar.Text);
            if (txtBuscar.Text.Length == 0)
            {
                grdPrestamo.DataSource = prestamoBLL.listarPrestamo();

            }
            grdPrestamo.DataBind();
        }

        protected void llenarSueldo(object sender, EventArgs e)
        { 
        }

     

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (checkMotivoNoRepetido())
            {
                DataRow dr = dtDetallePrestamo.NewRow();

                dr["idLibro"] = libroList.SelectedValue.ToString();
                dr["tituloLibro"] = libroList.SelectedItem.ToString();
                dr["fechaEntregaDetalleP"] = DateTime.Parse(fechaEntrega.SelectedDate.ToString()); ;
                dr["cantidadDetalleP"] = cantidadLibro.Text;

                
                dr["totalLibro"] = getTotalLibro();

                //dr["nombrecuenta"] = ddlcuenta.SelectedItem.ToString();
                dtDetallePrestamo.Rows.Add(dr);
                grdDetallesPrestamo.DataSource = dtDetallePrestamo;
                grdDetallesPrestamo.DataBind();
                limpiarDetalle();
            }
            else
            {
                string script = "alert('Motivo sin valor o ya agregado al detalle');";
              //  ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
        }

        protected string getTotalLibro()
        {
            float cost = 0;
            for (int i = 0; i < dtLibro.Rows.Count; i++)
            {
                string value = dtLibro.Rows[i]["idLibro"].ToString();
                if (value.Equals(libroList.SelectedValue.ToString()))
                {
                    cost = float.Parse(dtLibro.Rows[i]["valorPrestamoLibro"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    break;
                }
            }
            float cantidadLibroFloat = float.Parse(cantidadLibro.Text, CultureInfo.InvariantCulture.NumberFormat);
            float total = cost * cantidadLibroFloat;
            totalAsiento += (double)total;

            string totalString = total.ToString();
            if (total > 2)
            {
                totalString = total.ToString();
            }
            return totalString;
        }

        protected void limpiarDetalle()
        {

            cantidadLibro.Text = "0";
        }

        protected bool checkMotivoNoRepetido()
        {

            for (int i = 0; i < dtDetallePrestamo.Rows.Count; i++)
            {

                if (dtDetallePrestamo.Rows[i]["idLibro"].ToString().Equals(libroList.SelectedValue.ToString()))
                {
                    return false;
                }
            }
            if (cantidadLibro.Text == "")
            {
              
                return false;
            }
            return true;
        }

        protected void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            
            List<DataRow> rowsToEdit = new List<DataRow>();
            foreach (DataRow item in dtDetallePrestamo.Rows)
            {
                if (item["idLibro"].ToString().Equals(grdDetallesPrestamo.SelectedDataKey["idLibro"].ToString()))
                    rowsToEdit.Add(item);
            }



            foreach (DataRow item in rowsToEdit)
            {
                dtDetallePrestamo.Rows.Remove(item);
                DataRow dtnueva = dtDetallePrestamo.NewRow();
                dtnueva["idLibro"] = libroList.SelectedValue.ToString();
                dtnueva["tituloLibro"] = libroList.SelectedItem.ToString();
                dtnueva["cantidadDetalleP"] = cantidadLibro.Text.ToString();
                dtnueva["fechaEntregaDetalleP"] = DateTime.Parse(fechaEntrega.SelectedDate.ToString());
                dtnueva["totalLibro"] = getTotalLibro();

                dtDetallePrestamo.Rows.Add(dtnueva);

            }
            dtDetallePrestamo.AcceptChanges();
            grdDetallesPrestamo.DataSource = dtDetallePrestamo;
            grdDetallesPrestamo.DataBind();
            
            
        }

        protected void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            
            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow item in dtDetallePrestamo.Rows)
            {
                if (item["idLibro"].ToString().Equals(grdDetallesPrestamo.SelectedDataKey["idLibro"].ToString()))
                    rowsToDelete.Add(item);
            }
            foreach (DataRow item in rowsToDelete)
            {
                dtDetallePrestamo.Rows.Remove(item);

            }
            dtDetallePrestamo.AcceptChanges();
            grdDetallesPrestamo.DataSource = dtDetallePrestamo;
            grdDetallesPrestamo.DataBind();
            
        }

        protected void dtDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                        TotalDetalle += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "totalLibro"));
                    



                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "TOTAL:";
                    e.Row.Cells[5].Text = TotalDetalle.ToString();
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
            cantidadLibro.Text = grdDetallesPrestamo.SelectedDataKey["cantidadDetalleP"].ToString();
            libroList.SelectedValue = grdDetallesPrestamo.SelectedDataKey["idLibro"].ToString();
            CultureInfo provider = CultureInfo.InvariantCulture;
           // fechaEntrega.SelectedDate = DateTime.ParseExact(grdDetallesPrestamo.SelectedDataKey["fechaEntregaDetalleP"].ToString(), "dd/mm/yyyy  hh:mm:ss", provider);
            fechaEntrega.SelectedDate = DateTime.Parse(grdDetallesPrestamo.SelectedDataKey["fechaEntregaDetalleP"].ToString());
            fechaEntrega.DataBind();
        }
    }
}