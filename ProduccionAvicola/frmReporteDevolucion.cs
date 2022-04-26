using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using reportman;

namespace ProduccionAvicola
{
    public partial class frmReporteDevolucion : Form
    {
        ReportManX rep = new ReportManX();
        public frmReporteDevolucion()
        {
            InitializeComponent();
        }
        private void imprimir_reporte()
        {
            rep = new ReportManX();

            rep.filename = Application.StartupPath + "\\Reportes\\Devolucion.rep";

            rep.SetParamValue("FECHA", dtpDesde.Value.ToShortDateString());
            rep.SetDatabaseConnectionString("CONN", Global.str_conn_REP1);

            rep.Title = "Prestamos";
            rep.Preview = true;
            rep.Language = 1;
            rep.ShowPrintDialog = false;
            rep.Execute();

            this.Close();
        }
        private static frmReporteDevolucion frmDefInstance;
        public static frmReporteDevolucion DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmReporteDevolucion();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            imprimir_reporte();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
