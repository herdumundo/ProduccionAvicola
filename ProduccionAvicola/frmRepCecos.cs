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
    public partial class frmRepCecos : Form
    {
        ReportManX rep = new ReportManX();
        public frmRepCecos()
        {
            InitializeComponent();
        }
        private void imprimir()
        {
            rep = new ReportManX();

            if (Global.deposito == "P" || Global.deposito == "Z")
            {
                rep.filename = Application.StartupPath + "\\Reportes\\Centros de Costos Rec.rep";
            }
            else if (Global.deposito == "PP")
            {
                rep.filename = Application.StartupPath + "\\Reportes\\Centros de Costos PP.rep";
            }
            else if (Global.deposito == "CCHA" || Global.deposito == "CCHB" || Global.deposito == "CCHH" || Global.deposito == "OVO")
            {
                rep.filename = Application.StartupPath + "\\Reportes\\Centros de Costos CCH.rep";
            }
            else
            {
                rep.filename = Application.StartupPath + "\\Reportes\\Centros de Costos SUS.rep";
            };

            rep.SetParamValue("DESDE", dtpDesde.Value.ToShortDateString());
            rep.SetParamValue("HASTA", dtpHasta.Value.ToShortDateString());
            rep.SetDatabaseConnectionString("CONN", Global.str_conn_REP);

            rep.Title = "Reporte Centros de Costos";
            rep.Preview = true;
            rep.Language = 1;
            //rep.ShowPrintDialog = false;
            rep.Execute();

            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        //################################################################################################
        //Abrir una sola instancia del formulario
        //################################################################################################
        private static frmRepCecos frmDefInstance;
        public static frmRepCecos DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmRepCecos();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void dtpDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }

        private void dtpHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
    }
}
