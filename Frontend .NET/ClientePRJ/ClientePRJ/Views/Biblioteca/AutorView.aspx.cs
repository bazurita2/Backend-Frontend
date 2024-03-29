using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientePRJ.BLL;
using ClientePRJ.Models.Biblioteca;

namespace Cliente.Views.Mantenimiento
{
    public partial class CatalogoView : System.Web.UI.Page
    {
        private AutorBLL autorBLL= new AutorBLL();
        string codigo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdAutor.DataSource = autorBLL.AutoresByCoincidence(txtBuscar.Text);
            if(txtBuscar.Text.Length == 0)
            {
                grdAutor.DataSource = autorBLL.listarAutor();

            }
            grdAutor.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AutorModel a = new AutorModel();

            a.codigoAutor = "";
            a.nombreAutor = nombre.Text.Trim();
            a.apellidoAutor = apellido.Text.Trim();
            autorBLL.insertarAutor(a);
            
            llenarTabla();
            limpiarFormulario();
        }

        protected void grdAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            id.Text = grdAutor.SelectedDataKey["idAutor"].ToString();
            codigo = grdAutor.SelectedDataKey["codigoAutor"].ToString();
            nombre.Text = grdAutor.SelectedDataKey["nombreAutor"].ToString();
            apellido.Text = grdAutor.SelectedDataKey["apellidoAutor"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            AutorModel a = new AutorModel();
            
            a.idAutor = Int32.Parse(grdAutor.SelectedDataKey["idAutor"].ToString());
            a.codigoAutor =grdAutor.SelectedDataKey["codigoAutor"].ToString();

            a.nombreAutor = nombre.Text.Trim();
            a.apellidoAutor = apellido.Text.Trim();
        
            autorBLL.actualizarAutor(a);
            
            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdAutor.SelectedDataKey["idAutor"].ToString();
            autorBLL.eliminarAutor(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            grdAutor.DataSource = autorBLL.listarAutor();
            grdAutor.DataBind();

            /*
            List<AutorModel> catalogoModels = (List<AutorModel>)autorBLL.valoresCatalogo();
            int tmpMin = 0;
            if (catalogoModels.Count > 0)
            {
                tmpMin = catalogoModels[0].Valor_FDSC;
            }
           
            int tmpMax = 0;
            int tmpPromedio = 0;
            foreach (AutorModel c in catalogoModels)
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
            */
        }
        private void limpiarFormulario()
        {
            nombre.Text = String.Empty;
            apellido.Text = String.Empty;


        }
    }
}