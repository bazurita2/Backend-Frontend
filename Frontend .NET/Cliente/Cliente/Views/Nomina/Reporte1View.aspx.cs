using Cliente.BLL.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Views.Nomina
{
    public partial class Reporte1View : System.Web.UI.Page
    {
        /*
         
        */
        private EmpleadoBLL bllEmpleado = new EmpleadoBLL();
        private NominaBLL bllNomina = new NominaBLL();
        private CatalogoBLL bllCatalogo = new CatalogoBLL();
        private RubroBLL bllRubro = new RubroBLL();
        private decimal TotalDetalle = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarSelect();
                 llenarSelectFehas(null,null);
                llenarDetalle(null, null);
            }
        }

        private void llenarSelect()
        {
            DataTable dt = bllEmpleado.listarEmpleado();

            dt.Columns.Add("nombreapellido", typeof(string), "nombre + ' ' + apellido");
            idEmpleado.DataSource = dt;
            idEmpleado.DataTextField = "nombreapellido";

            idEmpleado.DataValueField = "id";
            idEmpleado.DataBind();
       


        }

        protected void llenarSelectFehas(object sender, EventArgs e)
        {
            DataTable dt = bllNomina.listarNominasEmpleado(idEmpleado.SelectedValue);
            fechasEmpleadoDropDown.DataSource = dt;
            fechasEmpleadoDropDown.DataTextField = "fechaNomina";

            fechasEmpleadoDropDown.DataValueField = "id";
            fechasEmpleadoDropDown.DataBind();
            llenarDetalle(null, null);
        }

        protected void llenarDetalle(object sender, EventArgs e)
        {

            DataTable dt = bllRubro.getRubrosByIdNomina(fechasEmpleadoDropDown.SelectedValue);

            DataTable dtCatalogos = bllCatalogo.listarCatalogo();
            dt.Columns.Add("descCatalogo");
            dt.Columns.Add("tipoCatalogo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtCatalogos.Rows.Count; j++)
                {
                    if (dt.Rows[i]["idCatalogo"].ToString().Equals(dtCatalogos.Rows[j]["id"].ToString()))
                    {
                        dt.Rows[i]["descCatalogo"] = dtCatalogos.Rows[j]["descripcionCatalogo"].ToString() ;
                        if (dtCatalogos.Rows[j]["tipoCatalogo"].ToString().ToLower().Equals("e"))
                        {
                            dt.Rows[i]["tipoCatalogo"] ="Egreso";
                        }
                        else { dt.Rows[i]["tipoCatalogo"] = "Ingreso"; }
                       
                    }
                }
            }

            grdDetallesNomina.DataSource = dt;


            grdDetallesNomina.DataBind();
        }

        protected void dtDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "tipoCatalogo").ToString().ToLower()[0] == 'e')
                    {
                        TotalDetalle -= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "valorRubro"));
                    }
                    else
                    {
                        TotalDetalle += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "valorRubro"));
                    }



                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "TOTAL:";
                    e.Row.Cells[4].Text = TotalDetalle.ToString();
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
         //   valorDeRubro.Text = grdDetallesNomina.SelectedDataKey["valorRubro"].ToString();
        //    catalogoList.SelectedValue = grdDetallesNomina.SelectedDataKey["idCatalogo"].ToString();
        }
    }
}