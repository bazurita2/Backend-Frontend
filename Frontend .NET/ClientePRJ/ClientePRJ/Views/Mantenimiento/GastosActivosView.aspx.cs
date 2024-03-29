using ClientePRJ.BLL.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientePRJ.Views.Mantenimiento
{
    public partial class GastosActivos : System.Web.UI.Page
    {
        private ActivoBLL activoBLL = new ActivoBLL();
        private CatalogoActividadBLL catalogoActividadBLL = new CatalogoActividadBLL();
        private DetalleActividadBLL detalleActividadBLL = new DetalleActividadBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarActivos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            double total = 0;
            DataTable catalogoActividadDT = catalogoActividadBLL.listarCatalogosActividades();
            //System.Diagnostics.Debug.WriteLine("SELECT: " + nombresActivos.SelectedValue);
            DataTable detalleActividadDT = detalleActividadBLL.getDetalleActividadByActivoDataTable(nombresActivos.SelectedValue);
            DataTable gastoActivoDT = new DataTable();
            gastoActivoDT.Columns.Add("nombrecatactividad");
            gastoActivoDT.Columns.Add("descripcioncatactividad");
            gastoActivoDT.Columns.Add("valordetalleactividad");
            foreach (DataRow row1 in detalleActividadDT.Rows)
            {
                DataRow row = gastoActivoDT.NewRow();
                foreach (DataRow row2 in catalogoActividadDT.Rows)
                {
                    //System.Diagnostics.Debug.WriteLine(row1["idcatactividad"].ToString() +"="+ row2["idcatactividad"].ToString());
                    if (row1["idcatactividad"].ToString() == row2["idcatactividad"].ToString())
                    {
                        row["nombrecatactividad"] = row2["nombrecatactividad"];
                        row["descripcioncatactividad"] = row2["descripcioncatactividad"];
                        row["valordetalleactividad"] = row1["valordetalleactividad"];
                        total += Double.Parse(row1["valordetalleactividad"].ToString());
                        gastoActivoDT.Rows.Add(row);

                    }
                }
            }
            DataRow rowTotal = gastoActivoDT.NewRow();
            rowTotal["nombrecatactividad"] = "";
            rowTotal["descripcioncatactividad"] = "TOTAL:";
            rowTotal["valordetalleactividad"] = total;
            gastoActivoDT.Rows.Add(rowTotal);
            grdGastoActivo.DataSource = gastoActivoDT;
            grdGastoActivo.DataBind();
        }

        public void cargarActivos()
        {
            nombresActivos.DataSource = activoBLL.listarNombresActivos();
            nombresActivos.DataTextField = "nombreactivo";
            nombresActivos.DataValueField = "idactivo";
            nombresActivos.DataBind();
        }

    }
}