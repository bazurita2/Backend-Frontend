using Cliente.BLL.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Views.Nomina
{
    public partial class Reporte2View : System.Web.UI.Page
    {
        
        private EmpleadoBLL bllEmpleado = new EmpleadoBLL();
        private NominaBLL bllNomina = new NominaBLL();
        private CatalogoBLL bllCatalogo = new CatalogoBLL();
        private RubroBLL bllRubro = new RubroBLL();

        // data
        string[,] data;
        DataTable dtCatalogos;
        DataTable dtNominas;
        DataTable dtEmpleados;
        protected void Page_Load(object sender, EventArgs e)
        {
         //   fechaMinima.SelectedDate = Convert.ToDateTime("2000-01-01T00:00:00-05:00");
         //   fechaMinima.DataBind();
          //  fechaMaxima.SelectedDate = DateTime.Today;
          //  fechaMaxima.DataBind();
            LlenarTabla(null,null);
        }

        protected void LlenarTabla(object sender, EventArgs e)
        {
            dtCatalogos = bllCatalogo.listarCatalogo();
            //   dtNominas = bllNomina.listarNominasByRangoFechas(fechaMinima.SelectedDate, fechaMaxima.SelectedDate);
             dtNominas = bllNomina.listarNomina();

         //   dtNominas = bllNomina.listarNominasByRangoFechas(Convert.ToDateTime("2000-01-01T00:00:00-05:00"), Convert.ToDateTime("2022-08-08T00:00:00-05:00"));
            dtEmpleados = bllEmpleado.listarEmpleado();
            data = new string[ dtNominas.Rows.Count , 2 + dtCatalogos.Rows.Count];
          
            for (int i = 0; i < dtNominas.Rows.Count; i++)
            {
                DateTime myDate = Convert.ToDateTime(dtNominas.Rows[i]["fechaNomina"].ToString());
                if (DateTime.Compare(  myDate, fechaMinima.SelectedDate) >= 0 && DateTime.Compare( myDate,fechaMaxima.SelectedDate) <= 0)
                {

                    for (int j = 0; j < dtEmpleados.Rows.Count; j++)
                    {
                        if (dtNominas.Rows[i]["idEmpleado"].ToString().Equals(dtEmpleados.Rows[j]["id"].ToString()))
                        {
                            data[i, 0] = dtEmpleados.Rows[j]["nombre"].ToString() + " " + dtEmpleados.Rows[j]["apellido"].ToString();
                            break;
                        }
                    }
                    data[i, 1] = dtNominas.Rows[i]["fechaNomina"].ToString();
                    DataTable dtRubros = bllRubro.getRubrosByIdNomina(dtNominas.Rows[i]["id"].ToString());
                    for (int j = 0; j < dtCatalogos.Rows.Count; j++)
                    {
                        for (int k = 0; k < dtRubros.Rows.Count; k++)
                        {
                            if (dtRubros.Rows[k]["idNomina"].ToString().Equals(dtNominas.Rows[i]["id"].ToString())
                                && dtRubros.Rows[k]["idCatalogo"].ToString().Equals(dtCatalogos.Rows[j]["id"].ToString()))
                            {
                                data[i, j + 2] = dtRubros.Rows[k]["valorRubro"].ToString();
                                break;
                            }
                            else
                            {
                                data[i, j + 2] = "0";
                            }
                        }

                    }

                }

            }

            DataTable dt = new DataTable();
            StringBuilder table = new StringBuilder();

            table.Append("<table class='table'>");
            table.Append("<tr>");

            table.Append("<th>");
            table.Append(dt.Columns.Add("Nombre", Type.GetType("System.String")));
            table.Append("</th>");

            table.Append("<th>");
            table.Append(dt.Columns.Add("Fecha", Type.GetType("System.String")));
            table.Append("</th>");

            for (int i = 0; i < dtCatalogos.Rows.Count; i++)
            {
                table.Append("<th>");
                table.Append(dt.Columns.Add(dtCatalogos.Rows[i]["descripcionCatalogo"].ToString(), Type.GetType("System.String")));
                table.Append("</th>");
            }
            table.Append("</tr>");

            for (int i = 0; i < dtNominas.Rows.Count; i++){
                if (data[i, 0]!= null)
                {
                    table.Append("<tr>");
                    dt.Rows.Add();
                    table.Append("<td>");
                    table.Append(dt.Rows[dt.Rows.Count - 1]["Nombre"] = data[i, 0]);
                    table.Append("</td>");

                    table.Append("<td>");
                    table.Append(dt.Rows[dt.Rows.Count - 1]["Fecha"] = data[i, 1]);
                    table.Append("</td>");

                    for (int j = 0; j < dtCatalogos.Rows.Count; j++)
                    {
                        table.Append("<td>");
                        table.Append(dt.Rows[dt.Rows.Count - 1][dtCatalogos.Rows[j]["descripcionCatalogo"].ToString()] = data[i, j + 2]);
                        table.Append("</td>");
                    }
                    table.Append("</tr>");
                }
                
            }

            table.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
        }

      


    }
}