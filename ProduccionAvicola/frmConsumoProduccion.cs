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
    public partial class frmConsumoProduccion : Form
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
        public frmConsumoProduccion()
        {
            InitializeComponent();
        }
       
        private void ubicaciones()
        {
            sql_ubicaciones = "select absentry, bincode, whscode, ";
            sql_ubicaciones = sql_ubicaciones + " convert(numeric, substring(bincode, 5, 3)) as aviario from obin with (nolock) ";
            if (rbAVPA.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-A%' ";
            }
            else if  (rbAVPB.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-B%' ";
            }
            else if (rbAVPH.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-H%' ";
            }
            else
            {
                sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-C%' ";
            };

            sql_ubicaciones = sql_ubicaciones + " and bincode not like '%ubicación-de-sistema%' ";
            sql_ubicaciones = sql_ubicaciones + " order by 4";

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
        private void tanques()
        {
            sql_ubicaciones = "select absentry, bincode, whscode from obin with (nolock) ";
            sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-T%' ";
            sql_ubicaciones = sql_ubicaciones + " and bincode not like '%ubicación-de-sistema%' ";
            daUbicaciones = new SqlDataAdapter(sql_ubicaciones, Global.conn);
            if (ds.Tables.Contains("tanques"))
            {
                ds.Tables["tanques"].Clear();
            };
            daUbicaciones.Fill(ds, "tanques");
            cmbTanque.DataSource = ds.Tables["tanques"];
            cmbTanque.DisplayMember = "bincode";
            cmbTanque.ValueMember = "absentry";
        }
        private void lote_ponedoras()
        {
            sql_lotes = "select b.distnumber, convert(numeric, a.onhandqty) as onhandqty, b.itemcode, b.itemname ";
            sql_lotes = sql_lotes + " from obbq a with (nolock) ";
            sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_lotes = sql_lotes + " inner join obin c with (nolock) on a.binabs = c.absentry ";

            if (rbAVPA.Checked == true)
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and c.bincode like 'PP-A%' ";
            }
            else if (rbAVPB.Checked == true)
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and c.bincode like 'PP-B%' ";
            }
            else if (rbAVPH.Checked == true)
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and c.bincode like 'PP-H%' ";
            }
            else
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and c.bincode like 'PP-C%' ";
            };

            sql_lotes = sql_lotes + " and a.binabs = " + cbDepositos.SelectedValue;
            daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
            if (ds.Tables.Contains("lote_pon"))
            {
                ds.Tables["lote_pon"].Clear();
            };

            if (rbAVPTradic.Checked == true|| rbAVPH.Checked == true)
            {
                //Llamar formulario de busqueda
                frmLotesConv frm = new frmLotesConv();
                frm.sql = "select distnumber, convert(numeric(12,2), a.onhandqty) as onhandqty ";
                frm.sql = frm.sql + " from obbq a with (nolock) ";
                frm.sql = frm.sql + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
                frm.sql = frm.sql + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                frm.sql = frm.sql + " where a.onhandqty > 0 ";
                frm.sql = frm.sql + " and a.binabs = " + cbDepositos.SelectedValue;
                frm.sql = frm.sql + " and b.itemcode like 'PON%' ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lblLote.Text = frm.dgvLotes.Rows[frm.dgvLotes.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    lblCantidad.Text = frm.dgvLotes.Rows[frm.dgvLotes.CurrentCell.RowIndex].Cells[1].Value.ToString();
                }
            }
            else
            {
                if (daLotes.Fill(ds, "lote_pon") > 0)
                {
                    //cant_total = 0;
                    //foreach (DataRow dr in ds.Tables["lote_pon"].Rows)
                    //{
                    //    cant_total = cant_total + int.Parse(dr["onhandqty"].ToString());
                    lblLote.Text = ds.Tables["lote_pon"].Rows[0]["distnumber"].ToString();
                    lblCantidad.Text = (ds.Tables["lote_pon"].Rows[0]["onhandqty"].ToString());
                    //};
                }
                else
                {
                    MessageBox.Show("No existen costos para este articulo");
                    return;
                };
            };                        
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
        private void frmConsumoProduccion_Load(object sender, EventArgs e)
        {
            ubicaciones();
            cbDepositos.SelectedIndex = -1;
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
                //if (txtArticulo.Text != "MATP-00013" || txtArticulo.Text != "MATP-00053")
                if (!(lblArticulo.Text.Contains("CALCICO")))
                {
                    
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
                Salida.UserFields.Fields.Item("U_cod_art").Value = txtArticulo.Text;//ds.Tables["lote_pon"].Rows[0]["itemcode"].ToString(); //txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = lblArticulo.Text;//ds.Tables["lote_pon"].Rows[0]["itemname"].ToString(); //lblArticulo.Text;

                Salida.Lines.ItemCode = ds.Tables["cost"].Rows[0]["itemcode"].ToString();                

                Salida.Lines.WarehouseCode = "PP";
                //if (txtArticulo.Text != "MATP-00013" || txtArticulo.Text != "MATP-00053")
                if (!(lblArticulo.Text.Contains("CALCICO")))
                {
                    if (rbAVPTradic.Checked == true)
                    {
                        Salida.Lines.BinAllocations.BinAbsEntry = int.Parse(cmbTanque.SelectedValue.ToString());
                    }
                    else
                    {
                        Salida.Lines.BinAllocations.BinAbsEntry = int.Parse(cbDepositos.SelectedValue.ToString());
                    }
                    
                    Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                    Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                }        
                else
                {
                    Salida.Lines.BinAllocations.BinAbsEntry = 10;
                    Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                    Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;                    
                };
                        
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_bal_ponedoras; //"5.12.03.03.01";
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.PriceAfterVAT = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.LineTotal = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());                
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

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                limpiar_form();
            }
            catch (Exception ex)
            {
                if (empresa.InTransaction)
                {
                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                };
                MessageBox.Show(ex.Message.ToString(), "Error de Sistema" , MessageBoxButtons.OK ,MessageBoxIcon.Error);
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
        private void limpiar_form()
        {
            txtArticulo.Text = "";
            txtCantidad.Text = "";
            rbAVPA.Checked = true;
            cbDepositos.SelectedIndex = -1;
            lblArticulo.Text = "";
            //dtpFecha.Value = DateTime.Now;
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
                //if (rbAVPA.Checked == true)
                //{
                //    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'AVP1' ";
                //}
                //else if (rbAVPB.Checked == true)
                //{
                //    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'AVP2' ";
                //}
                //else
                //{
                //    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'AVP3' ";
                //};
                frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
                if (rbAVPTradic.Checked == true)
                {
                    frm.sql = frm.sql + " and a.binabs = " + cmbTanque.SelectedValue;
                }
                else
                {
                    frm.sql = frm.sql + " and a.binabs = " + cbDepositos.SelectedValue;
                }
                frm.sql = frm.sql + " and a.itemcode like 'BAL%' ";
                frm.sql = frm.sql + " union all ";
                frm.sql = frm.sql + " select '' as sysnumber, a.itemcode, b.itemname, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhandqty) as quantity ";
                frm.sql = frm.sql + " from oibq a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
                frm.sql = frm.sql + " and  b.itemname like '%CALCI%' ";
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
            if (txtArticulo.Text == "MATP-00013" || txtArticulo.Text == "MATP-00053")
            {
                sql_articulos = "select a.itemcode, b.itemname, '' AS absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from oibq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
            }
            else
            {
                sql_articulos = "select a.itemcode, b.itemname, c.absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from oibq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
                if (rbAVPTradic.Checked == true)
                {
                    sql_articulos = sql_articulos + " and a.binabs = " + cmbTanque.SelectedValue;
                }
                else
                {
                    sql_articulos = sql_articulos + " and a.binabs = " + cbDepositos.SelectedValue;
                }
            }            
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
            if (txtArticulo.Text == "MATP-00013" || txtArticulo.Text == "MATP-00053")
            {
                sql_articulos = "select a.itemcode, b.itemname, '' as absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from oibq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
            }
            else
            {
                sql_articulos = "select a.itemcode, b.itemname, c.absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from oibq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'PP' ";
                if (rbAVPTradic.Checked == true)
                {
                    sql_articulos = sql_articulos + " and a.binabs = " + cmbTanque.SelectedValue;
                }
                else
                {
                    sql_articulos = sql_articulos + " and a.binabs = " + cbDepositos.SelectedValue;
                }
            }            
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
        private static frmConsumoProduccion frmDefInstance;
        public static frmConsumoProduccion DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmConsumoProduccion();
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
        private void rbAVPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void rbAVPB_KeyDown(object sender, KeyEventArgs e)
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
        private void rbAVPA_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
        }
        private void rbAVPB_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
        }
        private void cbDepositos_Leave(object sender, EventArgs e)
        {
            if (cbDepositos.SelectedIndex != -1)
            {
                lote_ponedoras();
                centro_costos();
            }
        }
        private void rbAVPTradic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAVPTradic.Checked == true)
            {
                ubicaciones();
                tanques();
                lblTanque.Visible = true;
                cmbTanque.Visible = true;
            }            
            else
            {
                lblTanque.Visible = false;
                cmbTanque.Visible = false;
            }
        }

        private void rbAVPH_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
        }

        private void rbAVPH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
