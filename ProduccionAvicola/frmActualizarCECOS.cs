using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SAPbobsCOM;

namespace ProduccionAvicola
{
    public partial class frmActualizarCECOS : Form
    {
        //SAP
        Company empresa = new Company();

        Documents Entrada;
        ProductionOrders OrdenProduccion;
        Documents EmisionProduccion;
        Documents ReciboProduccion;
        JournalEntries Asientos;

        SqlDataAdapter daAsientos;

        string sql_asientos;
        public frmActualizarCECOS()
        {
            InitializeComponent();
        }
        private static frmActualizarCECOS frmDefInstance;
        public static frmActualizarCECOS DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmActualizarCECOS();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void conexion()
        {
            empresa.Server = Properties.Settings.Default.Properties["sap_server"].DefaultValue.ToString();
            empresa.CompanyDB = Properties.Settings.Default.Properties["sap_companydb"].DefaultValue.ToString();
            switch (Properties.Settings.Default.sap_servertype)
            {
                case "2008":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                    break;
                case "2014":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                    break;
            };
            empresa.LicenseServer = Properties.Settings.Default.sap_server;
            empresa.language = BoSuppLangs.ln_Spanish;
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (cbAreas.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un área para realizar la actualización", "Error de Sisteam");
                    cbAreas.Focus();
                    return;
                };

                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription() + ", Código de error: " + empresa.GetLastErrorCode().ToString());
                        return;
                    };
                }

                empresa.StartTransaction();
                
                if (cbAreas.Text == "RECRIA")
                {
                    sql_asientos = "select c.TransId, b.OcrCode5, d.Account, 1 as Line_id  ";
                    sql_asientos = sql_asientos + " from OIGE a with (nolock) ";
                    sql_asientos = sql_asientos + " inner join IGE1 b with (nolock) on a.DocEntry = b.DocEntry";
                    sql_asientos = sql_asientos + " inner join OJDT c with (nolock) on a.DocNum = c.BaseRef and c.TransType = 60 ";
                    sql_asientos = sql_asientos + " inner join JDT1 d with (nolock) on c.TransId = d.TransId ";
                    sql_asientos = sql_asientos + " where a.DocDate between '" + dtpDesde.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and '" + dtpHasta.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and len(b.OcrCode5) > 0 ";
                    sql_asientos = sql_asientos + " and len(d.OcrCode5) = 0 ";
                    sql_asientos = sql_asientos + " and b.whscode in ('p', 'r', 'z') and d.Line_ID = 1 ";
                }
                else if (cbAreas.Text == "PROD. PRIMARIA")
                {
                    sql_asientos = "select c.TransId, b.OcrCode5, d.Account, 1 as Line_id ";
                    sql_asientos = sql_asientos + " from OIGE a with (nolock) ";
                    sql_asientos = sql_asientos + " inner join IGE1 b with (nolock) on a.DocEntry = b.DocEntry";
                    sql_asientos = sql_asientos + " inner join OJDT c with (nolock) on a.DocNum = c.BaseRef and c.TransType = 60 ";
                    sql_asientos = sql_asientos + " inner join JDT1 d with (nolock) on c.TransId = d.TransId ";
                    sql_asientos = sql_asientos + " where a.DocDate between '" + dtpDesde.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and '" + dtpHasta.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and len(b.OcrCode5) > 0 ";
                    sql_asientos = sql_asientos + " and len(d.OcrCode5) = 0 ";
                    sql_asientos = sql_asientos + " and b.whscode = 'pp' and d.Line_ID = 1 ";
                }
                else
                {
                    sql_asientos = "select a.transid, c.OcrCode5, c.AcctCode, b.line_id ";
                    sql_asientos = sql_asientos + " from OJDT a with (nolock) ";
                    sql_asientos = sql_asientos + " inner join JDT1 b with (nolock) on a.TransId = b.TransId ";
                    sql_asientos = sql_asientos + " inner join PCH1 c with (nolock) on a.CreatedBy = c.DocEntry and b.Account = c.AcctCode ";
                    sql_asientos = sql_asientos + " inner join OOCR d with (nolock) on c.ocrcode5 = d.ocrcode and d.active = 'Y' ";
                    //sql_asientos = sql_asientos + " where a.TransId = 886296 and ";
                    sql_asientos = sql_asientos + " where a.taxdate between '" + dtpDesde.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and '" + dtpHasta.Value.ToShortDateString() + "' ";
                    sql_asientos = sql_asientos + " and len(b.OcrCode5) = 0 and b.Debit > 0 ";
                    sql_asientos = sql_asientos + " and b.Account not in ('1.01.04.03.01') ";
                    sql_asientos = sql_asientos + " and year(a.taxdate) = 2020 and a.TransType in (18) ";
                    sql_asientos = sql_asientos + " group by a.transid, b.Account, c.OcrCode5, c.AcctCode, b.Line_ID, b.OcrCode5 ";
                    sql_asientos = sql_asientos + " order by 2 ";
                }

                daAsientos = new SqlDataAdapter(sql_asientos, Global.conn);
                if (ds.Tables.Contains("asientos"))
                {
                    ds.Tables["asientos"].Clear();
                };
                daAsientos.Fill(ds, "asientos");


                pbAsientos.Maximum = ds.Tables["asientos"].Rows.Count;
                pbAsientos.Value = 0;

                foreach (DataRow drAsientos in ds.Tables["asientos"].Rows)
                {
                    pbAsientos.Value++;
                    Asientos = empresa.GetBusinessObject(BoObjectTypes.oJournalEntries);
                    Asientos.GetByKey(int.Parse(drAsientos["transid"].ToString()));

                    Asientos.Lines.SetCurrentLine(int.Parse(drAsientos["line_id"].ToString()));
                    Asientos.Lines.CostingCode = (drAsientos["ocrcode5"].ToString()).Substring(0, 1);
                    Asientos.Lines.CostingCode2 = (drAsientos["ocrcode5"].ToString()).Substring(0, 2);
                    Asientos.Lines.CostingCode3 = (drAsientos["ocrcode5"].ToString()).Substring(0, 3);
                    Asientos.Lines.CostingCode4 = (drAsientos["ocrcode5"].ToString()).Substring(0, 5);
                    Asientos.Lines.CostingCode5 = drAsientos["ocrcode5"].ToString();

                    if (Asientos.Update() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };
                }

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                this.Close();

            }
            catch (Exception ex)
            {
                if (empresa.InTransaction)
                {
                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                };
                MessageBox.Show(ex.Message.ToString(), "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (empresa.Connected)
                {
                    empresa.Disconnect();
                };
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
