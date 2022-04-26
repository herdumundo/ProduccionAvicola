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
    public partial class frmCostosRecria : Form
    {
        //Variables SAP
        Company empresa = new Company();
        Documents Salida;
        MaterialRevaluation Revalorizacion;
        JournalEntries Asientos;

        SqlDataAdapter daTotalPollitas;
        SqlDataAdapter daTotalCostos;
        SqlDataAdapter daSaldoCta;

        string sql_totalcostos;
        string sql_totalpollitas;
        string sql_saldo_cta;

        double total_poll;
        double tcostos;
        double tvdistribuir;
        double new_cost;
        int docentry;

        int taves;

        public frmCostosRecria()
        {
            InitializeComponent();
        }
        private void total_pollitas()
        {
            /*sql_totalpollitas = "select convert(int, sum(quantity - quantout)) as cant, absentry, balance/sum(Quantity-QuantOut) as cost ";
            sql_totalpollitas = sql_totalpollitas + " from obtn with (nolock) ";
            sql_totalpollitas = sql_totalpollitas + " where ItemCode = 'POLL-00001' ";
            sql_totalpollitas = sql_totalpollitas + " group by absentry, balance ";
            sql_totalpollitas = sql_totalpollitas + " having sum(quantity - quantout) > 0 ";*/

            //sql_totalpollitas = "select convert(int, sum(b.quantity - b.quantout)) as cant, ";
            sql_totalpollitas = "select convert(int, sum(a.onhandqty)) as cant, ";
            sql_totalpollitas = sql_totalpollitas + " b.absentry, convert(numeric(12,2), b.balance/sum(a.onhandqty)) as cost, ";
            sql_totalpollitas = sql_totalpollitas + " b.distnumber , /*c.AbsEntry as ubi,*/ a.WhsCode ";
            sql_totalpollitas = sql_totalpollitas + " from OBBQ a with (nolock) ";
            sql_totalpollitas = sql_totalpollitas + " inner join obtn b with (nolock) on a.SnBMDAbs = b.AbsEntry ";
            sql_totalpollitas = sql_totalpollitas + " /*inner join obin c with (nolock) on a.BinAbs = c.AbsEntry */";
            sql_totalpollitas = sql_totalpollitas + " where b.ItemCode = 'POLL-00001' and a.OnHandQty > 0 ";
            sql_totalpollitas = sql_totalpollitas + " group by b.absentry, b.balance, b.distnumber, /*c.AbsEntry, */ a.whscode ";
            sql_totalpollitas = sql_totalpollitas + " having sum(quantity - quantout) > 0 ";

            daTotalPollitas = new SqlDataAdapter(sql_totalpollitas, Global.conn);

            if (ds.Tables.Contains("totalpollitas"))
            {
                ds.Tables["totalpollitas"].Clear();
            };
            
            if (daTotalPollitas.Fill(ds, "totalpollitas") > 0)
            {
                //total_poll = double.Parse(ds.Tables["totalpollitas"].Rows[0]["cant"].ToString());
            }
            else
            {
                MessageBox.Show("No existen lotes de pollitas disponibles");
                return;
            };
        }
        private void total_costos()
        {
            sql_totalcostos = "select b.AcctCode, c.acctname , convert(numeric(12,2), sum(b.Priceafvat)) as Total ";
            sql_totalcostos = sql_totalcostos + " from opch a with (nolock) ";
            sql_totalcostos = sql_totalcostos + " inner join pch1 b with (nolock) on a.docentry = b.DocEntry ";
            sql_totalcostos = sql_totalcostos + " inner join OACT c with (nolock) on b.acctcode = c.acctcode ";
            sql_totalcostos = sql_totalcostos + " where a.DocDate between '"+ dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";
            sql_totalcostos = sql_totalcostos + " and b.OcrCode3 = '411' and b.AcctCode like '5.%' and a.DocType = 's' ";
            sql_totalcostos = sql_totalcostos + " group by c.acctname, b.AcctCode ";
            sql_totalcostos = sql_totalcostos + " union all ";
            sql_totalcostos = sql_totalcostos + " select b.Account, c.acctname , convert(numeric(12,2), sum(b.Debit-b.Credit)) as Total ";            
            sql_totalcostos = sql_totalcostos + " from OJDT a with (nolock) ";
            sql_totalcostos = sql_totalcostos + " inner join JDT1 b with (nolock) on a.TransId = b.TransId ";
            sql_totalcostos = sql_totalcostos + " inner join OACT c with (nolock) on b.Account = c.acctcode ";
            sql_totalcostos = sql_totalcostos + " where a.TaxDate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";
            sql_totalcostos = sql_totalcostos + " and ocrcode3 in ( '411') and a.transtype = 30 and b.ContraAct in ('10.01.11.99.09') ";
            sql_totalcostos = sql_totalcostos + " group by b.Account, c.AcctName ";
            sql_totalcostos = sql_totalcostos + " order by 1 ";

            daTotalCostos = new SqlDataAdapter(sql_totalcostos, Global.conn);

            if (ds.Tables.Contains("totalcostos"))
            {
                ds.Tables["totalcostos"].Clear();
            };

            if (daTotalCostos.Fill(ds, "totalcostos")> 0)
            {
                dgvCostos.DataSource = ds.Tables["totalcostos"];
            };
        }
        private void calcular_cantidades()
        {
            tcostos = 0;
            tvdistribuir = 0;
            total_poll = 0;
            foreach (DataRow drTotalAves in ds.Tables["totalpollitas"].Rows)
            {
                txtTotalAves.Text = (double.Parse(txtTotalAves.Text) + double.Parse(drTotalAves["cant"].ToString())).ToString("N0");
            };
            foreach (DataRow drTotales in ds.Tables["totalcostos"].Rows)
            {
                txtTotalCostos.Text = (double.Parse(txtTotalCostos.Text) + double.Parse(drTotales["total"].ToString())).ToString("N2");
            };
            
            tcostos = double.Parse(txtTotalCostos.Text);
            total_poll = double.Parse(txtTotalAves.Text);

            txtValorADistribuir.Text = (tcostos / total_poll).ToString("N2");
            tvdistribuir = double.Parse(txtValorADistribuir.Text);
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
        private static frmCostosRecria frmDefInstance;
        public static frmCostosRecria DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmCostosRecria();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtTotalAves.Text != "" || txtTotalCostos.Text != "" || txtValorADistribuir.Text != "")
            {
                txtTotalAves.Text = "0";
                txtTotalCostos.Text = "0";
                txtValorADistribuir.Text = "0";
                dgvCostos.DataSource = null;

                total_costos();
                total_pollitas();
                calcular_cantidades();
            }
            else
            {
                total_costos();
                total_pollitas();
                calcular_cantidades();
            };            
        }
        private void frmCostosRecria_Load(object sender, EventArgs e)
        {
            dgvCostos.AllowUserToAddRows = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Validar que no exista una revalorizacion general dentro del rango de fechas

                empresa = new Company();

                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                        return;
                    };
                }

                empresa.StartTransaction();

                new_cost = double.Parse(txtTotalCostos.Text) / double.Parse(txtTotalAves.Text);

                int x = 0;
                string dep = "";
                string depo = "";
                double cant = 0;

                double total = 0;
                foreach (DataRow drCtaTotal in ds.Tables["totalcostos"].Rows)
                {
                    total = total + double.Parse(drCtaTotal["total"].ToString());
                };


                Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                Revalorizacion.DocDate = dtpHasta.Value;
                Revalorizacion.TaxDate = dtpHasta.Value;
                Revalorizacion.RevalType = "P";
                Revalorizacion.Lines.WarehouseCode = dep;
                Revalorizacion.Lines.ItemCode = "POLL-00001";
                Revalorizacion.Lines.RevaluationIncrementAccount = Properties.Settings.Default.cta_costos_recria;
                Revalorizacion.Lines.RevaluationDecrementAccount = Properties.Settings.Default.cta_costos_recria;

                int z = 0;
                double tot = 0;
                double total_costos = 0;
                double acum = 0;
                double total_aves = 0;
                double cant_lote = 0;

                total_costos = double.Parse(txtTotalCostos.Text);
                total_aves = double.Parse(txtTotalAves.Text);
                
                foreach (DataRow drLotes in ds.Tables["totalpollitas"].Rows)
                {
                    Revalorizacion.Lines.SNBLines.SetCurrentLine(z);
                    Revalorizacion.Lines.SNBLines.SnbAbsEntry = int.Parse(drLotes["absentry"].ToString());
                    Revalorizacion.Lines.SNBLines.NewCost = double.Parse(drLotes["cost"].ToString()) + new_cost;

                    Revalorizacion.Lines.SNBLines.Add();

                    total_aves = total_aves - cant_lote;
                    total_costos = total_costos -  tot;
                    z = z + 1;
                };

                if (Revalorizacion.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };

                docentry = int.Parse(empresa.GetNewObjectKey());

                Asientos = empresa.GetBusinessObject(BoObjectTypes.oJournalEntries);
                Asientos.TaxDate = dtpHasta.Value;
                Asientos.ReferenceDate = dtpHasta.Value;
                Asientos.DueDate = dtpHasta.Value;
                Asientos.Lines.AccountCode = Properties.Settings.Default.cta_costos_recria;
                Asientos.Lines.Debit = total;
                Asientos.Lines.Credit = 0;
                Asientos.Memo = "Costos Recria desde: " + dtpDesde.Value.ToShortDateString() + " hasta: " + dtpHasta.Value.ToShortDateString();
                Asientos.Lines.Add();
                                
                foreach (DataRow drCta in ds.Tables["totalcostos"].Rows)
                {
                    Asientos.Lines.AccountCode = drCta["acctcode"].ToString();
                    Asientos.Lines.ContraAccount = Properties.Settings.Default.cta_costos_recria;
                    Asientos.Lines.Credit = double.Parse(drCta["total"].ToString());
                    Asientos.Lines.Debit = 0;
                    Asientos.Lines.Add();
                };

                if (Asientos.Add() != 0)
                {
                    MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                };

                sql_saldo_cta = "select currtotal from oact with (nolock) where acctcode = '10.01.11.99.09' ";

                daSaldoCta = new SqlDataAdapter(sql_saldo_cta, Global.conn);

                if (ds.Tables.Contains("saldo"))
                {
                    ds.Tables["saldo"].Clear();
                };

                if (daSaldoCta.Fill(ds, "saldo") > 0)
                {
                    string cta_debito, cta_credito;
                    double saldo = double.Parse(ds.Tables["saldo"].Rows[0]["currtotal"].ToString());

                    if (saldo < 0)
                    {
                        cta_debito = Properties.Settings.Default.cta_costos_recria;
                        cta_credito = "5.50.01.01.02";
                    }
                    else
                    {
                        cta_credito = Properties.Settings.Default.cta_costos_recria;
                        cta_debito = "5.50.01.01.02";
                    };                    

                    Asientos = empresa.GetBusinessObject(BoObjectTypes.oJournalEntries);
                    Asientos.TaxDate = dtpHasta.Value;
                    Asientos.ReferenceDate = dtpHasta.Value;
                    Asientos.DueDate = dtpHasta.Value;
                    Asientos.Lines.AccountCode = cta_debito;
                    Asientos.Lines.Debit = saldo *-1;
                    Asientos.Lines.Credit = 0;
                    Asientos.Memo = "AS Reg Ctas: " + dtpDesde.Value.ToShortDateString() + " a " + dtpHasta.Value.ToShortDateString();
                    Asientos.Lines.Add();

                    Asientos.Lines.AccountCode = cta_credito;
                    Asientos.Lines.ContraAccount = cta_debito;
                    Asientos.Lines.Credit = saldo*-1;
                    Asientos.Lines.Debit = 0;
                    Asientos.Lines.Add();                    

                    if (Asientos.Add() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };
                }


                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                this.Close();
            }
            catch(Exception ex)
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
