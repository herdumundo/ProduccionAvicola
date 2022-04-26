using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPbobsCOM;
using System.Data.SqlClient;

namespace ProduccionAvicola
{
    public partial class frmREVMortandadRecria : Form
    {
        Company empresa = new Company();
        Documents Entrada;
        MaterialRevaluation Revalorizacion;

        SqlDataAdapter daSalida;
        SqlDataAdapter daCostos;
        string sql_costos;
        string sql_salida;

        double cost_total;
        double cant_total;
        double new_cost;

        public frmREVMortandadRecria()
        {
            InitializeComponent();
        }

        private void consulta_salida()
        {
            sql_salida = "select a.docnum, a.docdate, e.binabs, b.acctcode, b.price, b.linetotal, b.currency, h.sysnumber, ";
            sql_salida = sql_salida + " h.distnumber, b.itemcode, b.dscription, b.quantity, b.whscode, f.bincode, b.stockprice ";
            sql_salida = sql_salida + " from oige a with (nolock) ";
            sql_salida = sql_salida + " inner join ige1 b with (nolock) on a.docentry = b.docentry ";
            sql_salida = sql_salida + " inner join oitl c with (nolock) on a.docentry = c.docentry and b.itemcode = c.itemcode ";
            sql_salida = sql_salida + " inner join itl1 d with (nolock) on c.logentry = d.logentry ";
            sql_salida = sql_salida + " inner join obtl e with (nolock) on d.mdabsentry = e.snbmdabs and d.logentry = e.itlentry ";
            sql_salida = sql_salida + " inner join obin f with (nolock) on e.binabs = f.absentry ";
            sql_salida = sql_salida + " inner join obtn h with (nolock) on e.snbmdabs = h.absentry ";
            sql_salida = sql_salida + " where a.docnum = " + txtNroOperacion.Text;
            

            daSalida = new SqlDataAdapter(sql_salida, Global.conn);

            if (ds.Tables.Contains("salida"))
            {
                ds.Tables["salida"].Clear();
            };
            if (daSalida.Fill(ds, "salida") > 0)
            {
                
            }
            else
            {
                MessageBox.Show("Número de registro inexistente");
                return;
            };
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
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                

                //--##################################################################################--
                //--Comprobar conexion a base de datos
                //--##################################################################################--

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

                consulta_salida();

                //--##################################################################################--
                //--Consulta que devuelve costo y cantidad total de pollitas
                //--##################################################################################--

                sql_costos = "select a.itemcode, a.itemname, a.sysnumber, a.distnumber, a.balance, (a.quantity - a.quantout) as quantity, ";
                sql_costos = sql_costos + " a.costtotal, a.quantity as cant, ";
                sql_costos = sql_costos + " convert(numeric(12,2), (a.balance/(a.quantity-a.quantout))) as costo_uni, a.absentry  ";
                sql_costos = sql_costos + " from obtn a with (nolock) ";
                sql_costos = sql_costos + " where a.itemcode = '" + ds.Tables["salida"].Rows[0]["itemcode"].ToString() + "' ";
                sql_costos = sql_costos + " and a.sysnumber = " + ds.Tables["salida"].Rows[0]["sysnumber"].ToString();
                daCostos = new SqlDataAdapter(sql_costos, Global.conn);
                if (ds.Tables.Contains("cost"))
                {
                    ds.Tables["cost"].Clear();
                };
                if (daCostos.Fill(ds, "cost") > 0)
                {
                    cost_total = double.Parse(ds.Tables["cost"].Rows[0]["costtotal"].ToString());
                    cant_total = double.Parse(ds.Tables["cost"].Rows[0]["cant"].ToString());
                }
                else
                {
                    MessageBox.Show("No existen costos para este articulo");
                    return;
                };

                Entrada = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                Entrada.DocDate = DateTime.Parse(ds.Tables["salida"].Rows[0]["docdate"].ToString());
                Entrada.TaxDate = DateTime.Parse(ds.Tables["salida"].Rows[0]["docdate"].ToString());

                Entrada.Lines.ItemCode = ds.Tables["salida"].Rows[0]["itemcode"].ToString();
                Entrada.Lines.WarehouseCode = ds.Tables["salida"].Rows[0]["whscode"].ToString();

                Entrada.Lines.Quantity = double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString());
                Entrada.Lines.AccountCode = ds.Tables["salida"].Rows[0]["acctcode"].ToString();
                //Entrada.Lines.PriceAfterVAT = double.Parse(ds.Tables["salida"].Rows[0]["price"].ToString());
                Entrada.Lines.PriceAfterVAT = double.Parse(ds.Tables["salida"].Rows[0]["stockprice"].ToString());
                Entrada.Lines.SetCurrentLine(0);
                //Entrada.Lines.LineTotal = double.Parse(ds.Tables["salida"].Rows[0]["linetotal"].ToString());
                Entrada.Lines.LineTotal = double.Parse(ds.Tables["salida"].Rows[0]["stockprice"].ToString()) * double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString());
                Entrada.Lines.Currency = "GS";

                Entrada.Lines.BinAllocations.BinAbsEntry = int.Parse(ds.Tables["salida"].Rows[0]["binabs"].ToString());
                Entrada.Lines.BinAllocations.Quantity = double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString());                
                Entrada.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;

                Entrada.Lines.BatchNumbers.Quantity = double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString());
                Entrada.Lines.BatchNumbers.BatchNumber = ds.Tables["salida"].Rows[0]["distnumber"].ToString();
                Entrada.Lines.BatchNumbers.Add();

                Entrada.Lines.Add();

                if (Entrada.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                }

                new_cost = ((double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString()) * (cant_total + double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString()))) - ((double.Parse(ds.Tables["salida"].Rows[0]["quantity"].ToString()) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString())))) / (cant_total);

                Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                Revalorizacion.DocDate = DateTime.Parse(ds.Tables["salida"].Rows[0]["docdate"].ToString());
                //Revalorizacion.Comments = txtComentario.Text;
                Revalorizacion.RevalType = "P";
                Revalorizacion.Lines.WarehouseCode = ds.Tables["salida"].Rows[0]["whscode"].ToString();
                Revalorizacion.Lines.ItemCode = ds.Tables["cost"].Rows[0]["itemcode"].ToString();
                Revalorizacion.Lines.SNBLines.SnbAbsEntry = int.Parse(ds.Tables["cost"].Rows[0]["absentry"].ToString());
                Revalorizacion.Lines.SNBLines.NewCost = new_cost;
                Revalorizacion.Lines.RevaluationIncrementAccount = Properties.Settings.Default.cta_mortandad_pollitos; //"5.12.03.03.01";
                Revalorizacion.Lines.RevaluationDecrementAccount = Properties.Settings.Default.cta_mortandad_pollitos; //"5.12.03.03.01";

                if (Revalorizacion.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                }

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Proceso finalizado");
            }
            catch(Exception ex)
            {
                if (empresa.InTransaction)
                {
                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                };
                MessageBox.Show(ex.ToString());
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
    }
}
