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
    public partial class frmPagosPersonal : Form
    {
        Company empresa;
        Payments pago;

        SqlDataAdapter daFacturas;
        SqlDataAdapter daDetFacturas;
        string sqlDetFacturas;
        string sqlFactura;

        string Clie;

        public frmPagosPersonal()
        {
            InitializeComponent();
        }

        private void frmPagosPersonal_Load(object sender, EventArgs e)
        {

        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ////Total Huevos
            //sqlFactura = "select convert(numeric(12,0), sum(a.doctotal)) as doctotal ";
            //sqlFactura = sqlFactura + " from oinv a ";
            //sqlFactura = sqlFactura + " inner join ocrd b on a.cardcode = b.cardcode ";
            //sqlFactura = sqlFactura + " inner join inv1 c on a.docentry = b.docentry ";
            //sqlFactura = sqlFactura + " inner join oitm d on c.itemcode = d.itemcode and d.itmsgrpcod = 101 ";
            //sqlFactura = sqlFactura + " where a.u_liiv = '1' and a.paidtodate < a.doctotal and a.groupnum <> -1 ";
            //sqlFactura = sqlFactura + " and b.u_canal = 03 ";
            //sqlFactura = sqlFactura + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";

            //daFacturas = new SqlDataAdapter(sqlFactura, Global.conn);
            //daFacturas.Fill(ds, "totalH");

            //txtTotalHuevos.Text = ds.Tables["totalH"].Rows[0]["doctotal"].ToString();

            ////Total Gallinas
            //sqlFactura = "select convert(numeric(12,0), sum(a.doctotal)) as doctotal ";
            //sqlFactura = sqlFactura + " from oinv a ";
            //sqlFactura = sqlFactura + " inner join ocrd b on a.cardcode = b.cardcode ";
            //sqlFactura = sqlFactura + " inner join inv1 c on a.docentry = b.docentry ";
            //sqlFactura = sqlFactura + " inner join oitm d on c.itemcode = d.itemcode and d.itmsgrpcod = 108 ";
            //sqlFactura = sqlFactura + " where a.u_liiv = '1' and a.paidtodate < a.doctotal and a.groupnum <> -1 ";
            //sqlFactura = sqlFactura + " and b.u_canal = 03 ";
            //sqlFactura = sqlFactura + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";

            //daFacturas = new SqlDataAdapter(sqlFactura, Global.conn);
            //daFacturas.Fill(ds, "totalG");

            //txtTotalGallinas.Text = ds.Tables["totalG"].Rows[0]["doctotal"].ToString();

            //Total General txtTotal
            sqlFactura = "select convert(numeric(12,0), isnull(sum(a.doctotal), 0)) as doctotal ";
            sqlFactura = sqlFactura + " from oinv a with (nolock) ";
            sqlFactura = sqlFactura + " inner join ocrd b with (nolock) on a.cardcode = b.cardcode ";
            sqlFactura = sqlFactura + " where a.u_liiv = '1' and a.paidtodate < a.doctotal and a.groupnum <> -1 ";
            sqlFactura = sqlFactura + " and b.u_canal = 03 ";
            sqlFactura = sqlFactura + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";

            daFacturas = new SqlDataAdapter(sqlFactura, Global.conn);
            daFacturas.Fill(ds, "total");


            int total;
            total = int.Parse(ds.Tables["total"].Rows[0]["doctotal"].ToString());

            txtTotal.Text = total.ToString("N0");


            //Llenado de grilla
            sqlFactura = "select a.CardCode, a.CardName, ";
            sqlFactura = sqlFactura + " convert(numeric(12, 0), sum(a.DocTotal)) as DocTotal, ";
            sqlFactura = sqlFactura + " convert(numeric(12, 0), sum(a.PaidToDate)) as PaidToDate ";
            sqlFactura = sqlFactura + " from OINV a with (nolock) ";
            sqlFactura = sqlFactura + " inner join OCRD b with (nolock) on a.cardcode = b.cardcode ";
            sqlFactura = sqlFactura + " where a.U_LIIV = '1' and a.PaidToDate < a.DocTotal and a.GroupNum <> -1 ";
            sqlFactura = sqlFactura + " and b.u_canal = 03 ";
            sqlFactura = sqlFactura + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";
            //sqlFactura = sqlFactura + " and a.cardcode in ('C5504335','C4331626') ";
            sqlFactura = sqlFactura + " group by a.cardcode, a.cardname ";

            daFacturas = new SqlDataAdapter(sqlFactura, Global.conn);
            daFacturas.Fill(ds, "facturas");

            dgv.DataSource = ds.Tables["facturas"];
        }        
        private void detalles()
        {
            try
            {
                if (ds.Tables.Contains("detfacturas"))
                {
                    ds.Tables["detfacturas"].Clear();
                };

                sqlFactura = "select a.DocEntry, a.DocNum, a.Docdate, a.CardCode, a.CardName, ";
                sqlFactura = sqlFactura + " convert(numeric(12, 0), a.DocTotal) as DocTotal, ";
                sqlFactura = sqlFactura + " convert(numeric(12, 0), a.PaidToDate) as PaidToDate ";
                sqlFactura = sqlFactura + " from OINV a with (nolock) ";
                sqlFactura = sqlFactura + " inner join OCRD b on a.cardcode = b.cardcode ";
                sqlFactura = sqlFactura + " where a.U_LIIV = '1' and a.PaidToDate < a.DocTotal and a.GroupNum <> -1 ";
                sqlFactura = sqlFactura + " and b.u_canal = 03 ";
                sqlFactura = sqlFactura + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' and '" + dtpHasta.Value.ToShortDateString() + "' ";
                sqlFactura = sqlFactura + " and a.cardcode = '" + Clie + "' ";
                daFacturas = new SqlDataAdapter(sqlFactura, Global.conn);

                daFacturas.Fill(ds, "detfacturas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private static frmPagosPersonal frmDefInstance;
        public static frmPagosPersonal DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmPagosPersonal();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void btProcesar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                empresa = new Company();
                empresa.Server = Properties.Settings.Default.sap_server;
                empresa.CompanyDB = Properties.Settings.Default.sap_companydb;
                empresa.LicenseServer = Properties.Settings.Default.sap_server;
                switch (Properties.Settings.Default.sap_servertype)
                {
                    case "2008":
                        empresa.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                        break;
                    case "2014":
                        empresa.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                        break;
                };
                empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
                empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
                empresa.UserName = Global.usuario;
                empresa.Password = Global.password;

                if (empresa.Connect() != 0)
                {
                    MessageBox.Show(empresa.GetLastErrorDescription() + "; Código de error: " + empresa.GetLastErrorCode().ToString());
                    return;
                };

                
                empresa.StartTransaction();

                progressBar1.Maximum = ds.Tables["facturas"].Rows.Count;

                foreach (DataRow dr in ds.Tables["facturas"].Rows)
                {
                    progressBar1.Value++;

                    pago = empresa.GetBusinessObject(BoObjectTypes.oIncomingPayments);
                    pago.Series = 21;
                    pago.DocDate = dtpFechaPago.Value; //DateTime.Parse(dr["Docdate"].ToString());
                    pago.CardCode = dr["cardcode"].ToString();
                    pago.DocCurrency = "GS";
                    pago.CashAccount = "1.01.01.01.03";
                    pago.CashSum = double.Parse(dr["DocTotal"].ToString());
                    
                    Clie = dr["cardcode"].ToString();

                    detalles();
                    
                    for (int i = 0; i < ds.Tables["detfacturas"].Rows.Count; ++i)
                    {
                        pago.Invoices.SetCurrentLine(i);
                        pago.Invoices.DocEntry = int.Parse(ds.Tables["detfacturas"].Rows[i]["docentry"].ToString());
                        pago.Invoices.SumApplied = double.Parse(ds.Tables["detfacturas"].Rows[i]["doctotal"].ToString());
                        pago.Invoices.Add();
                    }; 
                    
                    if (pago.Add() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };                              
                };

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Importación finalizada", "Interface CAST", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exc)
            {
                if (empresa.Connected)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);

                    };
                };
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (empresa.Connected)
                {
                    empresa.Disconnect();
                };
                Cursor.Current = Cursors.Default;
            };
        }
    }
}
