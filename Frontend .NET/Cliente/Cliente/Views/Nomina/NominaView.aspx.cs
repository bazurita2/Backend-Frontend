using Cliente.BLL.Contabilidad;
using Cliente.BLL.Nomina;
using Cliente.DAL.Nomina;
using Cliente.Models.Nomina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cliente.Views.Nomina
{
    public partial class NominaView : System.Web.UI.Page
    {
        private AsientoBLL bllAciento = new AsientoBLL();
        private DetalleAsientoBLL bllDetalleAciento = new DetalleAsientoBLL();

        private NominaBLL bllNomina = new NominaBLL();

        private EmpleadoBLL bllEmpleado = new EmpleadoBLL();
        private CatalogoBLL bllCatalogo = new CatalogoBLL();
        private RubroBLL bllRubro = new RubroBLL();

        private static String idNominaActual = "";
        private static String idRubroActualToEdit = "";


        private NominaRubros nominaRubros = new NominaRubros();
        private static DataTable dtDetalleNomina;
        private decimal TotalDetalle = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarSelect();
                llenarTabla();
                dtDetalleNomina = createDtDetalleNomina();
            }
        }

        private DataTable createDtDetalleNomina()
        {
            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("iddetalle", typeof(String));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dt.Columns.Add("idRubro", typeof(string));
            dt.Columns.Add("idCatalogo", typeof(string));
            dt.Columns.Add("descripcionMotivo", typeof(string));
            dt.Columns.Add("tipoMotivo", typeof(string));
            dt.Columns.Add("valorRubro", typeof(string));
            return dt;
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            idNominaActual = "";
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            

            if(txtBuscar.Text != "") {
                DataTable dtEmp = bllEmpleado.listarEmpleado();
                DataTable dtNomina = bllNomina.listarNominaFiltradaPorEmpleado(txtBuscar.Text);
                dtNomina.Columns.Add("nombreapellido");
                for (int i = 0; i < dtNomina.Rows.Count; i++)
                {
                    for (int j = 0; j < dtEmp.Rows.Count; j++)
                    {
                        if (dtNomina.Rows[i]["idEmpleado"].ToString().Equals(dtEmp.Rows[j]["id"].ToString()))
                        {
                            dtNomina.Rows[i]["nombreapellido"] = dtEmp.Rows[j]["nombre"].ToString() + " " + dtEmp.Rows[j]["apellido"].ToString();
                        }
                    }
                }
                grdNomina.DataSource = dtNomina;
                grdNomina.DataBind();
            }
            else
            {
                DataTable dtEmp = bllEmpleado.listarEmpleado();
                DataTable dtNomina = bllNomina.listarNomina();
                dtNomina.Columns.Add("nombreapellido");
                for (int i = 0; i < dtNomina.Rows.Count; i++)
                {
                    for (int j = 0; j < dtEmp.Rows.Count; j++)
                    {
                        if (dtNomina.Rows[i]["idEmpleado"].ToString().Equals(dtEmp.Rows[j]["id"].ToString()))
                        {
                            dtNomina.Rows[i]["nombreapellido"] = dtEmp.Rows[j]["nombre"].ToString() + " " + dtEmp.Rows[j]["apellido"].ToString();
                        }
                    }
                }
                grdNomina.DataSource = dtNomina;
                grdNomina.DataBind();
            }
            

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if(dtDetalleNomina.Rows.Count > 0)
            {
                NominaModel a = new NominaModel();
                a.id = id.Text.Trim();
                a.idTransaccion = idTransaccion.Text.Trim();
                a.idEmpleado = idEmpleado.Text.Trim();
                a.estadoNomina = estadoNomina.Text.Trim();
                a.fechaNomina = DateTime.Parse(fechaNomina.SelectedDate.ToString());


                nominaRubros.nomina = a;
                AgregarDetallesAModel();
                bllNomina.insertarNomina(nominaRubros);
                if (checkBoxGenerarAsiento.Checked)
                {

                    for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
                    {
                        String sueldo = "";
                        String observacion = "Pago nomina de empleado " + idEmpleado.SelectedItem;
                        if (dtDetalleNomina.Rows[i]["descripcionMotivo"].ToString().Equals("Sueldo"))
                        {
                            sueldo = dtDetalleNomina.Rows[i]["valorRubro"].ToString();
                            Models.Contabilidad.AsientoModel asiento = new Models.Contabilidad.AsientoModel();
                            asiento.observacionasiento = observacion;
                            asiento.fechaasiento = fechaNomina.SelectedDate;
                            bllAciento.insertar(asiento);
                            List<Models.Contabilidad.AsientoModel> lista = bllAciento.listarToList();
                            String idasiento = lista[lista.Count - 1].idasiento;

                            Models.Contabilidad.DetalleAsientoModel obj = new Models.Contabilidad.DetalleAsientoModel();
                            // Debe
                            obj.iddetalleasiento = null;
                            obj.idcuenta = "62ce0a7b4c37cba9c30c334e";
                            obj.debedetalle = sueldo;
                            obj.haberdetalle = "0";
                            obj.idasiento = idasiento;
                            bllDetalleAciento.insertar(obj);
                            // Haber
                            obj = new Models.Contabilidad.DetalleAsientoModel();
                            obj.iddetalleasiento = null;
                            obj.idcuenta = "62ce0b124c37cba9c30c3352";
                            obj.debedetalle = "0";
                            obj.haberdetalle = sueldo;
                            obj.idasiento = idasiento;
                            bllDetalleAciento.insertar(obj);

                            checkBoxGenerarAsiento.Checked = false;
                            /*
                             for (int i = 0; i < dtDetalle.Rows.Count; i++)
                            {
                                DetalleAsientoModel obj = new DetalleAsientoModel();
                                obj.idcuenta = dtDetalle.Rows[i]["idcuenta"].ToString();
                                obj.debedetalle = dtDetalle.Rows[i]["debedetalle"].ToString();
                                obj.haberdetalle = dtDetalle.Rows[i]["haberdetalle"].ToString();
                                obj.idasiento = idasiento;
                                objDetalleBll.insertar(obj);



                            }
                            */
                            break;
                        }
                    }
           
                }
                llenarTabla();
                limpiarFormulario();
            }
            else
            {
                string script = "alert('Debe ingresar almenos uno motivo');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
          
        }

        protected void llenarSueldo(object sender, EventArgs e)
        {
            valorDeRubro.Text = "";
            for (int i = 0; i < dtCatalogo.Rows.Count; i++)
            {
                if (catalogoList.SelectedItem.ToString().Equals("Sueldo"))
                {
                    for (int j = 0; j < dtEmpleado.Rows.Count; j++)
                    {
                        if (idEmpleado.SelectedValue.ToString().Equals(dtEmpleado.Rows[i]["id"].ToString()))
                        {
                            valorDeRubro.Text = dtEmpleado.Rows[i]["sueldo"].ToString();
                        }
                    }
                    break;
                }
               
            }


        
        }

        protected void AgregarDetallesAModel()
        {

            List<RubroModel> listaRubrosTmp = new List<RubroModel>();

            for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
            {
                RubroModel rubro = new RubroModel();
                rubro.idCatalogo = dtDetalleNomina.Rows[i]["idCatalogo"].ToString();
                rubro.valorRubro = dtDetalleNomina.Rows[i]["valorRubro"].ToString();
                listaRubrosTmp.Add(rubro);
            }

            IEnumerable<RubroModel> rubros = listaRubrosTmp;
            nominaRubros.rubrosToInsert = rubros;   
        }

        protected void grdNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalDetalle = 0;
            limpiarFormulario();
            limpiarDetalle();
            idTransaccion.Text = grdNomina.SelectedDataKey["idTransaccion"].ToString();
            idEmpleado.Text = grdNomina.SelectedDataKey["idEmpleado"].ToString();
            estadoNomina.Text = grdNomina.SelectedDataKey["estadoNomina"].ToString();
            fechaNomina.SelectedDate = DateTime.Parse(grdNomina.SelectedDataKey["fechaNomina"].ToString());

            DataTable rubrosDt = bllRubro.getRubrosByIdNomina(grdNomina.SelectedDataKey["id"].ToString());
            idNominaActual = grdNomina.SelectedDataKey["id"].ToString();

            for (int i = 0; i < rubrosDt.Rows.Count; i++)
            {
                DataRow dr = dtDetalleNomina.NewRow();
                dr["idRubro"] = rubrosDt.Rows[i]["id"].ToString();
                dr["idCatalogo"] = rubrosDt.Rows[i]["idCatalogo"].ToString();
                for (int j = 0; j < dtCatalogo.Rows.Count; j++)
                {
                    if (dtCatalogo.Rows[j]["id"].ToString().Equals(rubrosDt.Rows[i]["idCatalogo"].ToString()))
                    {
                        dr["descripcionMotivo"] = dtCatalogo.Rows[j]["descripcionCatalogo"].ToString();
                        dr["tipoMotivo"] = dtCatalogo.Rows[j]["tipoCatalogo"].ToString();
                        break;
                    }
                }
                  
                dr["valorRubro"] = rubrosDt.Rows[i]["valorRubro"].ToString();


                //dr["nombrecuenta"] = ddlcuenta.SelectedItem.ToString();
                dtDetalleNomina.Rows.Add(dr);
                grdDetallesNomina.DataSource = dtDetalleNomina;
                grdDetallesNomina.DataBind();
            }

            grdDetallesNomina.DataSource = dtDetalleNomina;
            grdDetallesNomina.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            NominaModel a = new NominaModel();
            a.id = grdNomina.SelectedDataKey["id"].ToString();
            a.idTransaccion = idTransaccion.Text.Trim();
            a.idEmpleado = idEmpleado.Text.Trim();
            a.estadoNomina = estadoNomina.Text.Trim();
            a.fechaNomina = DateTime.Parse(fechaNomina.SelectedDate.ToString());


            bllNomina.actualizarNomina(a);
            DataTable dtDetalleEnBase = bllRubro.getRubrosByIdNomina(idNominaActual);
            for (int h = 0; h < dtDetalleEnBase.Rows.Count; h++)
            {
                bllRubro.eliminarRubro(dtDetalleEnBase.Rows[h]["id"].ToString());
            }

                for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
            {
                RubroModel rubro = new RubroModel();
                rubro.idCatalogo = dtDetalleNomina.Rows[i]["idCatalogo"].ToString();
                rubro.idNomina = a.id;
                rubro.valorRubro = dtDetalleNomina.Rows[i]["valorRubro"].ToString();
                bllRubro.insertarRubro(rubro);
            }

            /*
            for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
            {
                RubroModel rubro = new RubroModel();
                rubro.id = dtDetalleNomina.Rows[i]["idRubro"].ToString();
                rubro.idCatalogo = dtDetalleNomina.Rows[i]["idCatalogo"].ToString();
                rubro.idNomina =  idNominaActual;
                rubro.valorRubro = dtDetalleNomina.Rows[i]["valorRubro"].ToString();
                bllRubro.actualizarRubro(rubro)
            }
            */

            /*
            DataTable dtDetalleEnBase = bllRubro.getRubrosByIdNomina(idNominaActual);
            List<String> rubrosToDelete = new List<String>();
            for (int h = 0; h < dtDetalleEnBase.Rows.Count; h++)
            {
                bool encontre = false;
                for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
                {
                    if (dtDetalleNomina.Rows[i]["idRubro"].ToString().Equals(dtDetalleEnBase.Rows[i]["id"]))
                    {
                        RubroModel rubro = new RubroModel();
                        rubro.id = dtDetalleNomina.Rows[i]["idRubro"].ToString();
                        rubro.idCatalogo = dtDetalleNomina.Rows[i]["idCatalogo"].ToString();
                        rubro.idNomina = idNominaActual;
                        rubro.valorRubro = dtDetalleNomina.Rows[i]["valorRubro"].ToString();
                        bllRubro.actualizarRubro(rubro);
                        encontre = true;
                        break;
                    }

                    if (!encontre)
                    {
                        rubrosToDelete.Add(dtDetalleEnBase.Rows[i]["id"].ToString());
                    }
                    
                }
            }
            // eliminar
            foreach(String id in rubrosToDelete)
            {
                bllRubro.eliminarRubro(id);
            }

            // insertar nuevo
            for (int h = 0; h < dtDetalleNomina.Rows.Count; h++)
            {
                if(dtDetalleNomina.Rows[h]["idRubro"].ToString().Equals("")){
                    RubroModel rubro = new RubroModel();
                    rubro.idCatalogo = dtDetalleNomina.Rows[h]["idCatalogo"].ToString();
                    rubro.idNomina = idNominaActual;
                    rubro.valorRubro = dtDetalleNomina.Rows[h]["valorRubro"].ToString();
                    bllRubro.insertarRubro(rubro);
                }
            }
            */



            llenarTabla();
            limpiarFormulario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = grdNomina.SelectedDataKey["id"].ToString();
            bllNomina.eliminarNomina(id);
            llenarTabla();
            limpiarFormulario();

        }

        private void llenarTabla()
        {
            DataTable dtEmp = bllEmpleado.listarEmpleado();

            DataTable dtNomina = bllNomina.listarNomina();
            dtNomina.Columns.Add("nombreapellido");


            for (int i = 0; i < dtNomina.Rows.Count; i++)
            {
                for (int j = 0; j < dtEmp.Rows.Count; j++)
                {
                    if (dtNomina.Rows[i]["idEmpleado"].ToString().Equals(dtEmp.Rows[j]["id"].ToString()))
                    {
                        dtNomina.Rows[i]["nombreapellido"] = dtEmp.Rows[j]["nombre"].ToString() + " " + dtEmp.Rows[j]["apellido"].ToString();
                    }
                }
            }

            grdNomina.DataSource = dtNomina;

            
            grdNomina.DataBind();
        }

        private static DataTable dtCatalogo;
        private static DataTable dtEmpleado;
        private void llenarSelect()
        {
             dtEmpleado = bllEmpleado.listarEmpleado();

            dtEmpleado.Columns.Add("nombreapellido", typeof(string), "nombre + ' ' + apellido");
            idEmpleado.DataSource = dtEmpleado;
            idEmpleado.DataTextField = "nombreapellido";

            idEmpleado.DataValueField = "id";
            idEmpleado.DataBind();

            dtCatalogo = bllCatalogo.listarCatalogo();
            catalogoList.DataSource = dtCatalogo;
            catalogoList.DataTextField = "descripcionCatalogo";

            catalogoList.DataValueField = "id";
            catalogoList.DataBind();
        }
        private void limpiarFormulario()
        {
            dtDetalleNomina.Clear();
            idTransaccion.Text = String.Empty;
            grdDetallesNomina.DataSource = null;
            grdDetallesNomina.DataBind();
            fechaNomina.SelectedDate = DateTime.UtcNow;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /*
            tblAdd.Visible = true;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            Label1.Visible = true;
            Label2.Visible = false;

            BindTable();
            */
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if(dtCatalogo == null)
            {
                dtCatalogo = bllCatalogo.listarCatalogo();
            }
            string tmpTipo = "";
            for (int i = 0; i < dtCatalogo.Rows.Count; i++)
            {
                if (dtCatalogo.Rows[i]["id"].ToString().Equals(catalogoList.SelectedValue.ToString()))
                {
                    tmpTipo = dtCatalogo.Rows[i]["tipoCatalogo"].ToString();
                }
            }

            if (checkMotivoNoRepetido())
            {
                DataRow dr = dtDetalleNomina.NewRow();
                dr["idRubro"] = idRubroActualToEdit;
                dr["idCatalogo"] = catalogoList.SelectedValue.ToString();
                dr["descripcionMotivo"] = catalogoList.SelectedItem.ToString();
                dr["tipoMotivo"] = tmpTipo;
                dr["valorRubro"] = valorDeRubro.Text;


                //dr["nombrecuenta"] = ddlcuenta.SelectedItem.ToString();
                dtDetalleNomina.Rows.Add(dr);
                grdDetallesNomina.DataSource = dtDetalleNomina;
                grdDetallesNomina.DataBind();
                limpiarDetalle();
            }
            else
            {
                string script = "alert('Motivo sin valor o ya agregado al detalle');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

            }


        }

        protected void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            List<DataRow> rowsToEdit = new List<DataRow>();
            foreach (DataRow item in dtDetalleNomina.Rows)
            {
                if (item["idCatalogo"].ToString().Equals(grdDetallesNomina.SelectedDataKey["idCatalogo"].ToString()))
                    rowsToEdit.Add(item);
            }


            string tmpTipo = "";
            for (int i = 0; i < dtCatalogo.Rows.Count; i++)
            {
                if (dtCatalogo.Rows[i]["id"].ToString().Equals(catalogoList.SelectedValue.ToString()))
                {
                    tmpTipo = dtCatalogo.Rows[i]["tipoCatalogo"].ToString();
                }
            }

            foreach (DataRow item in rowsToEdit)
            {
                dtDetalleNomina.Rows.Remove(item);
                DataRow dtnueva = dtDetalleNomina.NewRow();

                dtnueva["idRubro"] = idRubroActualToEdit;
                dtnueva["idCatalogo"] = catalogoList.SelectedValue.ToString();
                dtnueva["descripcionMotivo"] = catalogoList.SelectedItem.ToString();
                dtnueva["tipoMotivo"] = tmpTipo;
                dtnueva["valorRubro"] = valorDeRubro.Text;

                dtDetalleNomina.Rows.Add(dtnueva);

            }
            dtDetalleNomina.AcceptChanges();
            grdDetallesNomina.DataSource = dtDetalleNomina;
            grdDetallesNomina.DataBind();
        }

        protected void btnQuitarDetalle_Click(object sender, EventArgs e)
        {

            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow item in dtDetalleNomina.Rows)
            {
                if (item["idCatalogo"].ToString().Equals(grdDetallesNomina.SelectedDataKey["idCatalogo"].ToString()))
                    rowsToDelete.Add(item);
            }
            foreach (DataRow item in rowsToDelete)
            {
                dtDetalleNomina.Rows.Remove(item);

            }
            dtDetalleNomina.AcceptChanges();
            grdDetallesNomina.DataSource = dtDetalleNomina;
            grdDetallesNomina.DataBind();
        }

        protected bool checkMotivoNoRepetido()
        {

            for (int i = 0; i < dtDetalleNomina.Rows.Count; i++)
            {

                if (dtDetalleNomina.Rows[i]["idCatalogo"].ToString().Equals(catalogoList.SelectedValue.ToString()))
                {
                    return false;
                }
            }
            if(valorDeRubro.Text == "")
            {
                /*
                if(Convert.ToDecimal(valorDeRubro.Text) <= 0)
                {
                    return false;
                }
                */
                return false;
            }
            return true;
        }
        protected void limpiarDetalle()
        {

            valorDeRubro.Text = "0";
        }

        protected void dtDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if(DataBinder.Eval(e.Row.DataItem, "tipoMotivo").ToString().ToLower().Equals("e"))
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

            valorDeRubro.Text = grdDetallesNomina.SelectedDataKey["valorRubro"].ToString();
            catalogoList.SelectedValue = grdDetallesNomina.SelectedDataKey["idCatalogo"].ToString();
            idRubroActualToEdit = grdDetallesNomina.SelectedDataKey["idRubro"].ToString();
        }

    }
}