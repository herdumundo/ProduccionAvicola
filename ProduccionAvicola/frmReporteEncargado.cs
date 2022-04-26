using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using reportman;

namespace ProduccionAvicola
{
    public partial class frmReporteEncargado : Form
    {
        ReportManX rep = new ReportManX();
        SqlDataAdapter daEncargado;
        string sql_Encargado;
        int Encargado_cab;
        int Ubicacion_cab;

        public frmReporteEncargado()
        {
            InitializeComponent();
        }
        private static frmReporteEncargado frmDefInstance;
        public static frmReporteEncargado DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmReporteEncargado();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void imprimir_reporte()
        {
            rep = new ReportManX();

            rep.filename = Application.StartupPath + "\\Reportes\\Prestamo_Encargado.rep";

            rep.SetParamValue("CODE", txtCodigo.Text);
            rep.SetDatabaseConnectionString("CONN", Global.str_conn_REP1);

            rep.Title = "Prestamos";
            rep.Preview = true;
            rep.Language = 1;
            rep.ShowPrintDialog = false;
            rep.Execute();

            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            imprimir_reporte();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Recargar_Encargado()
        {
            sql_Encargado = "select a.AbsEntry as Codigo, a.BinCode as Ubicacion, b.WhsCode as Cod_Deposito, b.WhsName as Deposito, a.SL1Code as Almacen, c.SlpCode as Cod_Encargado, c.SlpName as Encargado from OBIN a with (nolock) inner join OWHS b with (nolock) on a.WhsCode = b.WhsCode inner join OSLP c on a.BinCode = c.U_AREA where c.SlpCode = '" + txtCodigo.Text.ToString() + "'";
            daEncargado = new SqlDataAdapter(sql_Encargado, Global.conn);

            if (ds.Tables.Contains("Encargado"))
            {
                ds.Tables["Encargado"].Rows.Clear();
            };

            daEncargado.Fill(ds, "Encargado");

            if (daEncargado.Fill(ds, "Encargado") > 0)
            {
                Encargado_cab = int.Parse(ds.Tables["Encargado"].Rows[0]["Cod_Encargado"].ToString());
                Ubicacion_cab = int.Parse(ds.Tables["Encargado"].Rows[0]["Codigo"].ToString());
                txtDenominacion.Text = ds.Tables["Encargado"].Rows[0]["Encargado"].ToString();
                txtNomUbi.Text = ds.Tables["Encargado"].Rows[0]["Ubicacion"].ToString();

                txtCodigo.Text = ds.Tables["Encargado"].Rows[0]["Cod_Encargado"].ToString();
                txtUbicacion.Text = ds.Tables["Encargado"].Rows[0]["Codigo"].ToString();

            };
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            Limpiar_Form();
        }
        private void Limpiar_Form()
        {
            txtCodigo.Clear();
            txtDenominacion.Clear();
            txtNomUbi.Clear();
            txtUbicacion.Clear();
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            Recargar_Encargado();
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void frmReporteEncargado_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }
    }
}
