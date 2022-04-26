using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPbobsCOM;
using System.Data.SqlClient;

namespace ProduccionAvicola
{
    public partial class frmConsumo : Form
    {
        Company empresa = new Company();
        Documents Salida;
        MaterialRevaluation Revalorizacion;

        SqlDataAdapter daLotes;
        SqlDataAdapter daArt;
        SqlDataAdapter daUbicaciones;
        SqlDataAdapter daDepositos;
        SqlDataAdapter daCostoLotes;
        SqlDataAdapter daCostoPol;
        SqlDataAdapter daValCarga;
        SqlDataAdapter daCCostos;

        string sql_ccostos;
        string sql_val_carga;
        string sql_lotes;
        string sql_articulos;
        string sql_ubicaciones;
        string sql_depositos;
        string sql_costos;
        string sql_costos_pol;

        string cod_deposito;
        string sys_number;

        double cost_total;
        double cant_total;
        double new_cost;
        public frmConsumo()
        {
            InitializeComponent();
        }
        private void ubicaciones()
        {
            sql_ubicaciones = "select absentry, bincode, whscode from obin with (nolock) ";
            if (rbFase1.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where whscode = 'P' ";
            }
            else
            {
                sql_ubicaciones = sql_ubicaciones + " where whscode = 'z' ";
            }
            sql_ubicaciones = sql_ubicaciones + " and bincode not like '%ubicación-de-sistema%' ";
            daUbicaciones = new SqlDataAdapter(sql_ubicaciones, Global.conn);
            if (ds.Tables.Contains("ubicaciones"))
            {
                ds.Tables["ubicaciones"].Clear();
            };
            daUbicaciones.Fill(ds, "ubicaciones");
            cbDepositos.DataSource = ds.Tables["ubicaciones"];
            cbDepositos.DisplayMember = "bincode";
            cbDepositos.ValueMember = "absentry";
        }
        private void deposito()
        {
            sql_depositos = "select whscode from obin with (nolock) where absentry = " + cbDepositos.SelectedValue;
            daDepositos = new SqlDataAdapter(sql_depositos, Global.conn);
            if (ds.Tables.Contains("depositos"))
            {
                ds.Tables["depositos"].Clear();
            };

            if (daDepositos.Fill(ds, "depositos") > 0)
            {
                cod_deposito = ds.Tables["depositos"].Rows[0]["whscode"].ToString();
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
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void lote_pollitos()
        {
            //Costo de lote de pollitos
            sql_costos_pol = "select a.itemcode, b.itemname, b.sysnumber, b.distnumber, b.costtotal, convert(numeric, a.onhandqty) as onhandqty, b.absentry, ";
            sql_costos_pol = sql_costos_pol + " convert(numeric, (b.costtotal/a.onhandqty)) as costo_uni, b.balance, b.quantity ";
            sql_costos_pol = sql_costos_pol + " from obbq a with (nolock) ";
            sql_costos_pol = sql_costos_pol + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_costos_pol = sql_costos_pol + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            sql_costos_pol = sql_costos_pol + " where a.itemcode like  'POLL%' ";
            if (rbFase1.Checked == true)
            {
                sql_costos_pol = sql_costos_pol + " and a.onhandqty > 0 and a.WhsCode = 'P' ";
            }
            else if (rbFase2.Checked == true)
            {
                sql_costos_pol = sql_costos_pol + " and a.onhandqty > 0 and a.WhsCode = 'Z' ";
            }
            sql_costos_pol = sql_costos_pol + " and a.binabs = " + cbDepositos.SelectedValue;
            daCostoPol = new SqlDataAdapter(sql_costos_pol, Global.conn);
            if (ds.Tables.Contains("cost_pol"))
            {
                ds.Tables["cost_pol"].Clear();
            };
            if (daCostoPol.Fill(ds, "cost_pol") > 0)
            {
                cost_total = double.Parse(ds.Tables["cost_pol"].Rows[0]["costtotal"].ToString());
                cant_total = double.Parse(ds.Tables["cost_pol"].Rows[0]["quantity"].ToString());
                lblLote.Text = ds.Tables["cost_pol"].Rows[0]["distnumber"].ToString();
                lblCantidad.Text = ds.Tables["cost_pol"].Rows[0]["onhandqty"].ToString();
            }
            else
            {
                MessageBox.Show("No existen costos para este articulo");
                return;
            };
        }
        private void centro_costos()
        {
            sql_ccostos = "select prccode from oprc with (nolock) where prcname = '" + cbDepositos.Text + "'";
            daCCostos = new SqlDataAdapter(sql_ccostos, Global.conn);

            if (ds.Tables.Contains("ccostos"))
            {
                ds.Tables["ccostos"].Clear();
            };

            if (daCCostos.Fill(ds, "ccostos") > 0)
            {

            }
            else
            {
                MessageBox.Show("No se ha definido Centro de Costo para el deposito seleccionado");
                return;
            };
        }
        private void frmConsumo_Load(object sender, EventArgs e)
        {
            ubicaciones();
            cbDepositos.SelectedIndex = -1;
        }
        private void rbFase1_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
        }
        private void rbFase2_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
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

                //validacion de duplicidad
                sql_val_carga = "select b.itemcode, b.quantity, a.docdate, e.bincode ";
                sql_val_carga = sql_val_carga + " from oige a with (nolock) ";
                sql_val_carga = sql_val_carga + " inner join ige1 b with (nolock) on a.docentry = b.docentry ";
                sql_val_carga = sql_val_carga + " inner join oilm c with (nolock) on a.docentry = c.docentry ";
                sql_val_carga = sql_val_carga + " inner join obtl d with (nolock) on c.messageid = d.messageid ";
                sql_val_carga = sql_val_carga + " inner join obin e with (nolock) on d.binabs = e.absentry ";
                sql_val_carga = sql_val_carga + " where a.docdate = '" + dtpFecha.Value.ToShortDateString() + "' ";
                sql_val_carga = sql_val_carga + " and b.itemcode = '" + txtArticulo.Text + "' ";
                sql_val_carga = sql_val_carga + " and b.quantity = " + txtCantidad.Text + " ";
                sql_val_carga = sql_val_carga + " and e.absentry = " + cbDepositos.SelectedValue;

                daValCarga = new SqlDataAdapter(sql_val_carga, Global.conn);

                if (ds.Tables.Contains("validacion"))
                {
                    ds.Tables["validacion"].Clear();
                };

                if (daValCarga.Fill(ds, "validacion") > 0)
                {
                    MessageBox.Show("Ya ha sido registrado este movimiento para el aviario " + ds.Tables["validacion"].Rows[0]["bincode"].ToString() + "! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                };
                                
                //Costo de balanceado
                sql_costos = "select a.itemcode, a.itemname,  ";
                sql_costos = sql_costos + " convert(numeric, (a.avgprice)) as costo_uni ";
                sql_costos = sql_costos + " from oitm a with (nolock) ";
                //sql_costos = sql_costos + " inner join oibq b on a.itemcode = b.itemcode ";
                sql_costos = sql_costos + " where a.itemcode = '" + ds.Tables["articulos"].Rows[0]["itemcode"].ToString() + "' ";
                //sql_costos = sql_costos + " and a.sysnumber = " + ds.Tables["lotes"].Rows[0]["sysnumber"].ToString() ;
                daCostoLotes = new SqlDataAdapter(sql_costos, Global.conn);
                if (ds.Tables.Contains("cost"))
                {
                    ds.Tables["cost"].Clear();
                };
                if (daCostoLotes.Fill(ds, "cost") > 0)
                {
                    //cost_total = double.Parse(ds.Tables["cost"].Rows[0]["costtotal"].ToString());
                    //cant_total = double.Parse(ds.Tables["cost"].Rows[0]["quantity"].ToString());
                }
                else
                {
                    MessageBox.Show("No existen costos para este articulo");
                    return;
                };

                //lote_pollitos();

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

                Salida = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                Salida.DocDate = dtpFecha.Value;

                //--##################################################################################--
                //--Asignacion de centro de costo 
                //--##################################################################################--

                Salida.Lines.CostingCode = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 1);
                Salida.Lines.CostingCode2 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 2);
                Salida.Lines.CostingCode3 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 3);
                Salida.Lines.CostingCode4 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 5);
                Salida.Lines.CostingCode5 = ds.Tables["ccostos"].Rows[0]["prccode"].ToString();


                //Datos de salida, campos de usuario
                Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["cost_pol"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = ds.Tables["cost_pol"].Rows[0]["itemname"].ToString();//lblArticulo.Text;

                Salida.Lines.ItemCode = ds.Tables["cost"].Rows[0]["itemcode"].ToString();

                if (rbFase1.Checked == true)
                {
                    Salida.Lines.WarehouseCode = "P";
                }
                else if (rbFase2.Checked == true)
                {
                    Salida.Lines.WarehouseCode = "Z";
                }

                Salida.Lines.BinAllocations.BinAbsEntry = int.Parse(cbDepositos.SelectedValue.ToString());
                Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_bal_pollitos; //"5.12.03.03.01";
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.PriceAfterVAT = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.LineTotal = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.BatchNumbers.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.BatchNumbers.BatchNumber = ds.Tables["lotes"].Rows[0]["distnumber"].ToString();
                //Salida.Lines.BatchNumbers.Add();                
                Salida.Lines.Add();

                Salida.Comments = txtComentario.Text;

                if (Salida.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };
                                              
                new_cost = ((double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString())) + cost_total)/ cant_total;

                Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                Revalorizacion.DocDate = dtpFecha.Value;
                Revalorizacion.TaxDate = dtpFecha.Value;
                Revalorizacion.RevalType = "P";
                //Asignación de Centros de Costos
                //Revalorizacion.Lines.DistributionRule = "D";
                //Revalorizacion.Lines.DistributionRule2 = "D1";
                //Revalorizacion.Lines.DistributionRule3 = "D2";
                //Revalorizacion.Lines.DistributionRule4 = "4";
                //Revalorizacion.Lines.DistributionRule5 = "5";

                if (rbFase1.Checked == true)
                {
                    Revalorizacion.Lines.WarehouseCode = "P";
                }
                else if (rbFase2.Checked == true)
                {
                    Revalorizacion.Lines.WarehouseCode = "Z";
                }
                Revalorizacion.Lines.ItemCode = ds.Tables["cost_pol"].Rows[0]["itemcode"].ToString();
                
                Revalorizacion.Lines.SNBLines.SnbAbsEntry = int.Parse(ds.Tables["cost_pol"].Rows[0]["absentry"].ToString());
                Revalorizacion.Lines.SNBLines.NewCost = new_cost;
                Revalorizacion.Lines.RevaluationIncrementAccount = Properties.Settings.Default.cta_consumo_bal_pollitos; //"5.12.03.03.01";
                Revalorizacion.Lines.RevaluationDecrementAccount = Properties.Settings.Default.cta_consumo_bal_pollitos; //"5.12.03.03.01";

                if (Revalorizacion.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());                    
                    return;
                }
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
                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                if(empresa.Connected)
                {
                    empresa.Disconnect();
                };
                Cursor.Current = Cursors.Default;
                limpiar_form();
            }
        }
        private void limpiar_form()
        {
            txtArticulo.Text = "";
            txtCantidad.Text = "";
            rbFase1.Checked = true;
            cbDepositos.SelectedIndex = -1;
            lblArticulo.Text = "";
            dtpFecha.Value = DateTime.Now;
            lblLote.Text = "";
            lblCantidad.Text = "";
            txtComentario.Text = "";
            dtpFecha.Focus();
        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //Llamar formulario de busqueda
                frmBArticulos frm = new frmBArticulos();
                frm.sql = "select '' as sysnumber, a.itemcode, b.itemname, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhandqty) as quantity ";
                frm.sql = frm.sql + " from oibq a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                if (rbFase1.Checked == true)
                {
                    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'P' ";
                }
                else
                {
                    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'Z' ";
                }
                frm.sql = frm.sql + " and a.binabs = " + cbDepositos.SelectedValue;
                frm.sql = frm.sql + " and a.itemcode like 'BAL%' ";
                frm.sql = frm.sql + " order by b.itemname ";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[2].Value.ToString();                    
                    b_articulos();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buscar_articulos();
                };
            }
        }        
        private void buscar_articulos()
        {
            sql_articulos = "select a.itemcode, b.itemname, c.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from oibq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            if (rbFase1.Checked == true)
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'P' ";
            }
            else
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'Z' ";
            }
            sql_articulos = sql_articulos + " and a.binabs = " + cbDepositos.SelectedValue;
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            sql_articulos = sql_articulos + " order by b.itemname ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
            }
        }
        private void b_articulos()
        {
            sql_articulos = "select a.itemcode, b.itemname, c.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from oibq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            if (rbFase1.Checked == true)
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'P' ";
            }
            else
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'Z' ";
            }
            sql_articulos = sql_articulos + " and a.binabs = " + cbDepositos.SelectedValue;
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            sql_articulos = sql_articulos + " order by b.itemname ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
            }
        }
        private static frmConsumo frmDefInstance;
        public static frmConsumo DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmConsumo();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void rbFase1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void rbFase2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cbDepositos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cbDepositos_Leave(object sender, EventArgs e)
        {
            if (cbDepositos.SelectedIndex != -1)
            {
                centro_costos();
                lote_pollitos();
            }
        }
    }
}
