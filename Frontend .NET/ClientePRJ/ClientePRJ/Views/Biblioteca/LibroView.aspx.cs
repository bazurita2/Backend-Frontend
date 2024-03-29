using ClientePRJ.BLL;
using ClientePRJ.Models.Biblioteca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientePRJ.Views.Biblioteca
{
    public partial class LibroView : System.Web.UI.Page
    {
        private LibroBLL libroBLL = new LibroBLL();
        private AutorBLL autorBLL = new AutorBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarTabla();
                llenarSelect();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {




            DataTable dtLibro = libroBLL.LibrosByCoincidence(txtBuscar.Text);
            if (txtBuscar.Text.Length == 0)
            {
                dtLibro = libroBLL.listarLibro();

            }

            DataTable dtAutores = autorBLL.listarAutor();
            dtLibro.Columns.Add("nombreApellidoAutor");


            for (int i = 0; i < dtLibro.Rows.Count; i++)
            {
                for (int j = 0; j < dtAutores.Rows.Count; j++)
                {
                    if (dtLibro.Rows[i]["idAutor"].ToString().Equals(dtAutores.Rows[j]["idAutor"].ToString()))
                    {
                        dtLibro.Rows[i]["nombreApellidoAutor"] = dtAutores.Rows[j]["nombreAutor"].ToString() + " " + dtAutores.Rows[j]["apellidoAutor"].ToString();
                    }
                }
            }
            grdLibro.DataSource = dtLibro;
            grdLibro.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LibroModel l = new LibroModel();

            l.ISBNLibro = ISBNLibro.Text.Trim();
            l.idAutor= Int32.Parse(idAutor.Text.Trim());
            l.tituloLibro = tituloLibro.Text.Trim();
            l.valorPrestamoLibro = (valorPrestamoLibro.Text.Trim());

            libroBLL.insertarLibro(l);

            llenarTabla();
            limpiarFormulario();
        }

        protected void grdLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            id.Text = grdLibro.SelectedDataKey["idLibro"].ToString();
            ISBNLibro.Text = grdLibro.SelectedDataKey["ISBNLibro"].ToString();
            tituloLibro.Text = grdLibro.SelectedDataKey["tituloLibro"].ToString();
            idAutor.Text = grdLibro.SelectedDataKey["idAutor"].ToString();
            valorPrestamoLibro.Text = grdLibro.SelectedDataKey["valorPrestamoLibro"].ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LibroModel a = new LibroModel();

            a.idLibro = Int32.Parse(grdLibro.SelectedDataKey["idLibro"].ToString());
            a.ISBNLibro = ISBNLibro.Text.Trim();
            a.idAutor = Int32.Parse(idAutor.Text.Trim());
            a.tituloLibro = tituloLibro.Text.Trim();
            a.valorPrestamoLibro = (valorPrestamoLibro.Text.Trim());

            libroBLL.actualizarLibro(a);

            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdLibro.SelectedDataKey["idLibro"].ToString();
            libroBLL.eliminarLibro(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {

            DataTable dtAutores = autorBLL.listarAutor();
            DataTable dtLibro = libroBLL.listarLibro();
            dtLibro.Columns.Add("nombreApellidoAutor");


            for (int i = 0; i < dtLibro.Rows.Count; i++)
            {
                for (int j = 0; j < dtAutores.Rows.Count; j++)
                {
                    if (dtLibro.Rows[i]["idAutor"].ToString().Equals(dtAutores.Rows[j]["idAutor"].ToString()))
                    {
                        dtLibro.Rows[i]["nombreApellidoAutor"] = dtAutores.Rows[j]["nombreAutor"].ToString() + " " + dtAutores.Rows[j]["apellidoAutor"].ToString();
                    }
                }
            }
            grdLibro.DataSource = dtLibro;
            grdLibro.DataBind();

   
        }


        private static DataTable dtAutor;
        private void llenarSelect()
        {
            dtAutor = autorBLL.listarAutor();

            dtAutor.Columns.Add("nombreApellidoAutor", typeof(string), "nombreAutor + ' ' + apellidoAutor");
            idAutor.DataSource = dtAutor;
            idAutor.DataTextField = "nombreApellidoAutor";

            idAutor.DataValueField = "idAutor";
            idAutor.DataBind();
        }

        private void limpiarFormulario()
        {
            id.Text = String.Empty;
            ISBNLibro.Text = String.Empty;
            tituloLibro.Text = String.Empty;
            valorPrestamoLibro.Text = String.Empty;



        }
    }
}