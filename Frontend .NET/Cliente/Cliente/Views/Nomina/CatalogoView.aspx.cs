using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cliente.BLL.Nomina;
using clienteG2.Models;

namespace Cliente.Views.Mantenimiento
{
    public partial class CatalogoView : System.Web.UI.Page
    {
        private CatalogoBLL catalogoBLL= new CatalogoBLL();

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
            if(txtBuscar.Text.Length > 0)
            {
                grdCatalogo.DataSource = catalogoBLL.getCatalogoByNombreDataTable(txtBuscar.Text);
            }
            else
            {
                grdCatalogo.DataSource = catalogoBLL.listarCatalogo();
            }
          
            grdCatalogo.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogoModel a = new CatalogoModel();
            a.descripcionCatalogo = descripcionCatalogo.Text.Trim();
            a.tipoCatalogo = tipoCatalogo.SelectedValue.ToString().Trim();
            a.Valor_FDSC = 0;
            catalogoBLL.insertarCatalogo(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void grdCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            descripcionCatalogo.Text = grdCatalogo.SelectedDataKey["descripcionCatalogo"].ToString();
            tipoCatalogo.SelectedValue = grdCatalogo.SelectedDataKey["tipoCatalogo"].ToString();
           // Valor_FDSC.Text = grdCatalogo.SelectedDataKey["Valor_FDSC"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            CatalogoModel a = new CatalogoModel();
            a.id = grdCatalogo.SelectedDataKey["id"].ToString();
            a.descripcionCatalogo = descripcionCatalogo.Text.Trim();
            a.tipoCatalogo = tipoCatalogo.SelectedValue.ToString().Trim();
            a.Valor_FDSC = 0;
            catalogoBLL.actualizarCatalogo(a);
            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdCatalogo.SelectedDataKey["id"].ToString();
            catalogoBLL.eliminarCatalogo(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            grdCatalogo.DataSource = catalogoBLL.listarCatalogo();
            grdCatalogo.DataBind();

            List<CatalogoModel> catalogoModels = (List<CatalogoModel>)catalogoBLL.valoresCatalogo();
            int tmpMin = 0;
            if (catalogoModels.Count > 0)
            {
                tmpMin = catalogoModels[0].Valor_FDSC;
            }
           
            int tmpMax = 0;
            int tmpPromedio = 0;
            foreach (CatalogoModel c in catalogoModels)
            {
                if(tmpMin > c.Valor_FDSC)
                {
                    tmpMin = c.Valor_FDSC;
                }

                if (c.Valor_FDSC > tmpMax  )
                {
                    tmpMax = c.Valor_FDSC;
                }
                tmpPromedio += c.Valor_FDSC;

            }

            double tmpPromedioFinal = Convert.ToDouble(tmpPromedio) / Convert.ToDouble(catalogoModels.Count);
            max.Text = "Valor máximo de la tabla: " + tmpMax;
            min.Text = "Valor mínimo de la tabla: " + tmpMin;
            promedio.Text = "Promedio de la tabla: " + tmpPromedioFinal;
        }
        private void limpiarFormulario()
        {
            descripcionCatalogo.Text = String.Empty;
            tipoCatalogo.SelectedValue = "e";
           // Valor_FDSC.Text = String.Empty;

        }
    }
}