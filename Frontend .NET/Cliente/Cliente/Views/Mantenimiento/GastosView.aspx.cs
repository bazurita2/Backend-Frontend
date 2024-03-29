using Cliente.BLL.Mantenimiento;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cliente.Views.Mantenimiento
{
    public partial class GastosView : System.Web.UI.Page
    {
        private DetalleActividadBLL detalleActividadBLL = new DetalleActividadBLL();
        DataTable gastosDT = new DataTable();
        List<int> dimensiones = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDataTable();
        }

        public void initDataTable(int maxCol)
        {
            gastosDT.Columns.Add("Activos");
            for (int i = 0; i < maxCol; i++)
            {
                gastosDT.Columns.Add("Acttividad " + (i + 1));
            }
        }

        public void cargarDataTable()
        {
            dimensiones = detalleActividadBLL.getMaxColFilDetalleActividad();
            int maxCol = dimensiones[0];
            int maxFil = dimensiones[1];
            initDataTable(maxCol);
            string[,] tablaGastos = new string[maxFil, maxCol + 1];
            ActivoModel[] filaData = new ActivoModel[maxFil];
            string[,] columnaData = new string[maxFil, maxCol];
            string[] rowData = new string[maxCol + 1];

            List<ActivoModel> filaActivoData = detalleActividadBLL.getFilaActivo();
            //FILA
            for (int i = 0; i < maxFil; i++)
            {
                filaData[i] = filaActivoData[i];
            }

            List<string> columnaDetalleActividadData = new List<string>();
            //COLUMNA
            for (int i = 0; i < maxFil; i++)
            {
                columnaDetalleActividadData = detalleActividadBLL.getColumnaDetalleaActividad(filaData[i].idactivo);

                for (int j = 0; j < columnaDetalleActividadData.Count; j++)
                {
                    columnaData[i, j] = columnaDetalleActividadData[j].ToString();
                }


                //TABLA
                rowData = new String[columnaDetalleActividadData.Count + 1];
                for (int k = 0; k < columnaDetalleActividadData.Count + 1; k++)
                {
                    if (k == 0)
                    {
                        tablaGastos[i, k] = filaData[i].nombreactivo.ToString();
                    }
                    else
                    {
                        tablaGastos[i, k] = columnaData[i, k - 1];
                    }
                    System.Diagnostics.Debug.WriteLine("[" + i + "]" + "[" + k + "]=" + tablaGastos[i, k]);
                    rowData[k] = tablaGastos[i, k];
                    if (k == columnaDetalleActividadData.Count)
                    {
                        gastosDT.Rows.Add(rowData);
                    }
                }

            }
            grdGastos.DataSource = gastosDT;
            grdGastos.DataBind();

        }
    }
}