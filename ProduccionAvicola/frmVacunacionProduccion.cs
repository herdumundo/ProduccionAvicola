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
    public partial class frmVacunacionProduccion : Form
    {
        Company empresa = new Company();
        Documents Salida;

        SqlDataAdapter daLotes;
        SqlDataAdapter daUbicaciones;
        SqlDataAdapter daCostoPon;
        SqlDataAdapter daArt;
        SqlDataAdapter daCCostos;

        string sql_ccostos;
        string sql_lotes;
        string sql_ubicaciones;
        string sql_costos_pon;
        string sql_articulos;

        string sys_number;

        double cost_total;
        double cant_total;
        double new_cost;
        public frmVacunacionProduccion()
        {
            InitializeComponent();
        }
        private void lote_ponedoras()
        {
            sql_lotes = "select b.distnumber, convert(numeric, a.onhandqty) as onhandqty, b.itemcode, b.itemname ";
            sql_lotes = sql_lotes + " from obbq a with (nolock) ";
            sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_lotes = sql_lotes + " inner join obin c with (nolock) on a.binabs = c.absentry ";

            //if (rbAVPA.Checked == true)
            //{
            //    sql_lotes = sql_lotes + " where a.onhandqty > 0 and a.whscode = 'AVP1' ";
            //}
            //else if (rbAVPB.Checked == true)
            //{
            //    sql_lotes = sql_lotes + " where a.onhandqty > 0 and a.whscode = 'AVP2' ";
            //}
            //else
            //{
            sql_lotes = sql_lotes + " where a.onhandqty > 0 and a.whscode = 'PP' ";
            //};

            sql_lotes = sql_lotes + " and a.binabs = " + cbDepositos.SelectedValue;
            daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
            if (ds.Tables.Contains("lote_pon"))
            {
                ds.Tables["lote_pon"].Clear();
            };

            if (rbAVPTradic.Checked == true || rbAVPH.Checked == true)
            {
                //Llamar formulario de busqueda
                frmLotesConv frm = new frmLotesConv();
                frm.sql = "select distnumber, convert(numeric(12,2), a.onhandqty) as onhandqty, b.itemcode, b.itemname ";
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
                    daLotes = new SqlDataAdapter(frm.sql, Global.conn);
                    daLotes.Fill(ds, "lote_pon");
                }
            }
            else
            {
                if (daLotes.Fill(ds, "lote_pon") > 0)
                {
                    lblLote.Text = ds.Tables["lote_pon"].Rows[0]["distnumber"].ToString();
                    lblCantidad.Text = ds.Tables["lote_pon"].Rows[0]["onhandqty"].ToString();
                }
                else
                {
                    MessageBox.Show("No existen lotes de ponedoras en este Aviario");
                    //cbDepositos.Focus();
                    return;
                };
            };            
        }
        private void ubicaciones()
        {
            sql_ubicaciones = "select absentry, bincode, whscode, ";
            sql_ubicaciones = sql_ubicaciones + " convert(numeric, substring(bincode, 5, 3)) as aviario from obin with (nolock) ";
            if (rbAVPA.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where bincode like 'PP-A%' ";
            }
            else if (rbAVPB.Checked == true)
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
        private void frmVacunacionProduccion_Load(object sender, EventArgs e)
        {
            ubicaciones();
            cbDepositos.SelectedIndex = -1;            
        }
        private void limpiar_form()
        {
            txtArticulo.Text = "";
            txtCantidad.Text = "";
            rbAVPA.Checked = true;
            cbDepositos.SelectedIndex = -1;
            lblArticulo.Text = "";
            dtpFecha.Value = DateTime.Now;
            lblLote.Text = "";
            lblCantidad.Text = "";
            txtComentario.Text = "";
            dtpFecha.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click_OLD(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //--##################################################################################--
                //--Consulta de costo de lote de vacuna a ser utilizada
                //--##################################################################################--

                sql_lotes = "select distinct b.sysnumber, b.itemcode, b.itemname, b.distnumber, ";
                sql_lotes = sql_lotes + " convert(numeric(12,2), a.Quantity) as quantity,  ";
                sql_lotes = sql_lotes + " case when convert(numeric, (b.balance/a.quantity)) = 0 then c.AvgPrice  ";
                sql_lotes = sql_lotes + " else convert(numeric, (b.balance/a.quantity))end as costo_uni ";
                sql_lotes = sql_lotes + " from oibt a with (nolock) ";
                sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.BatchNum = b.DistNumber ";
                sql_lotes = sql_lotes + " inner join OITM c with (nolock) on a.ItemCode = c.ItemCode ";
                sql_lotes = sql_lotes + " where a.quantity > 0 and a.WhsCode = 'CV' ";
                sql_lotes = sql_lotes + " and b.itemcode like 'V%'";
                sql_lotes = sql_lotes + " and a.sysnumber =" + sys_number;
                sql_lotes = sql_lotes + " and b.itemcode = '" + txtArticulo.Text + "' ";
                sql_lotes = sql_lotes + " order by b.itemname ";

                daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };
                daLotes.Fill(ds, "lotes");                               


                //--##################################################################################--
                //--Inicio de Procesos en SAP
                //--##################################################################################--

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

                //--##################################################################################--
                //--Registrar Salida de Vacunas
                //--##################################################################################--

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
                Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["lote_pon"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = ds.Tables["lote_pon"].Rows[0]["itemname"].ToString();//lblArticulo.Text;

                Salida.Lines.ItemCode = ds.Tables["lotes"].Rows[0]["itemcode"].ToString();
                

                Salida.Lines.WarehouseCode = "CV";
                                
                Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                Salida.Lines.BinAllocations.BinAbsEntry = 63;
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_vacuna_ponedoras;
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.PriceAfterVAT = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["lotes"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.LineTotal = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["lotes"].Rows[0]["costo_uni"].ToString());
                Salida.Lines.BatchNumbers.Quantity = int.Parse(txtCantidad.Text);
                Salida.Lines.BatchNumbers.BatchNumber = lblLoteVac.Text;//ds.Tables["lotes"].Rows[0]["distnumber"].ToString();
                Salida.Lines.BatchNumbers.Add();
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
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString(), "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //--##################################################################################--
                //--Consulta de costo de lote de vacuna a ser utilizada
                //--##################################################################################--

                sql_lotes = "select distinct b.sysnumber, b.itemcode, b.itemname, b.distnumber, ";
                sql_lotes = sql_lotes + " convert(numeric(12,2), a.Quantity) as quantity,  ";
                sql_lotes = sql_lotes + " case when convert(numeric, (b.balance/a.quantity)) = 0 then c.AvgPrice  ";
                sql_lotes = sql_lotes + " else convert(numeric, (b.balance/a.quantity))end as costo_uni ";
                sql_lotes = sql_lotes + " from oibt a with (nolock) ";
                sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.BatchNum = b.DistNumber ";
                sql_lotes = sql_lotes + " inner join OITM c with (nolock) on a.ItemCode = c.ItemCode ";
                sql_lotes = sql_lotes + " where a.quantity > 0 and a.WhsCode = 'CV' ";
                sql_lotes = sql_lotes + " and b.itemcode like 'V%'";
                sql_lotes = sql_lotes + " and a.sysnumber =" + sys_number;
                sql_lotes = sql_lotes + " and b.itemcode = '" + txtArticulo.Text + "' ";
                sql_lotes = sql_lotes + " order by b.itemname ";

                daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };
                daLotes.Fill(ds, "lotes");


                //--##################################################################################--
                //--Inicio de Procesos en SAP
                //--##################################################################################--

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

                //--##################################################################################--
                //--Registrar Salida de Vacunas
                //--##################################################################################--

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
                Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["lote_pon"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = ds.Tables["lote_pon"].Rows[0]["itemname"].ToString();//lblArticulo.Text;

                //Salida.Lines.ItemCode = ds.Tables["lotes"].Rows[0]["itemcode"].ToString();
                Salida.Lines.ItemCode = txtArticulo.Text.Trim();

                Salida.Lines.WarehouseCode = "CV";

                Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                Salida.Lines.BinAllocations.BinAbsEntry = 63;
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_vacuna_ponedoras;
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.PriceAfterVAT = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["lotes"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.LineTotal = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["lotes"].Rows[0]["costo_uni"].ToString());

                if (lblLoteVac.Text != "")
                {
                    Salida.Lines.BatchNumbers.Quantity = int.Parse(txtCantidad.Text);
                    Salida.Lines.BatchNumbers.BatchNumber = lblLoteVac.Text;//ds.Tables["lotes"].Rows[0]["distnumber"].ToString();
                    Salida.Lines.BatchNumbers.Add();
                }

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
                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString(), "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //--##################################################################################--
                //--Llamada a formulario de busqueda de articulos, filtrando solo las vacunas
                //--##################################################################################--
                frmBArticulos frm = new frmBArticulos();
                frm.sql = "select 0 as sysnumber, a.itemcode, b.itemname,'' as distnumber,";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhand) as quantity ";
                frm.sql = frm.sql + " from oitw a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " where a.onhand > 0 and a.WhsCode IN ('CV') ";
                frm.sql = frm.sql + " and (b.ItemCode like 'INRE%') ";

                frm.sql = frm.sql + " union all ";

                frm.sql = frm.sql + "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhandqty) as quantity ";
                frm.sql = frm.sql + " from obbq a with (nolock) ";
                frm.sql = frm.sql + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
                frm.sql = frm.sql + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
                frm.sql = frm.sql + " and a.binabs = 63 " ;
                frm.sql = frm.sql + " and b.itemcode like 'V%' ";
                frm.sql = frm.sql + " order by b.itemname ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    sys_number = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    b_articulos();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buscar_articulos();
                    SendKeys.Send("{Tab}");
                }
            }
        }
        private void b_articulos()
        {
            if (sys_number == "0")
            {
                sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
                sql_articulos = sql_articulos + " from oitw a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where a.whscode IN ('R', 'CV') and a.onhand > 0 ";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            }
            else
            {
                sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from obbq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
                sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
                sql_articulos = sql_articulos + " and a.binabs = 63";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
                sql_articulos = sql_articulos + " and b.sysnumber = " + sys_number;
            }

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

                if (sys_number != "0")
                {
                    lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                };

                //lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();

                txtCantidad.Focus();
            }
        }
        private void b_articulos_old()
        {
            sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from obbq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
            sql_articulos = sql_articulos + " and a.binabs = 63";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            sql_articulos = sql_articulos + " and b.sysnumber = " + sys_number;
            sql_articulos = sql_articulos + " order by b.sysnumber ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                txtCantidad.Focus();
            }
        }
        private void buscar_articulos()
        {
            sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from obbq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
            sql_articulos = sql_articulos + " and a.binabs = 63 ";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            //sql_articulos = sql_articulos + " and b.sysnumber = '" + sys_number + "' ";
            sql_articulos = sql_articulos + " order by b.sysnumber ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
            }
            else
            {
                sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
                sql_articulos = sql_articulos + " from oitw a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where (a.whscode = 'CV') and a.onhand > 0 ";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
                daArt = new SqlDataAdapter(sql_articulos, Global.conn);
                if (ds.Tables.Contains("articulos"))
                {
                    ds.Tables["articulos"].Clear();
                };
                if (daArt.Fill(ds, "articulos") > 0)
                {
                    txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                    lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                    lblLoteVac.Text = "";
                }
            }
        }

        private void buscar_articulos_OLD1()
        {

            if (string.IsNullOrEmpty(sys_number) || sys_number == "0")
            {
                sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
                sql_articulos = sql_articulos + " from oitw a with (nolock) ";
                sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where (a.whscode = 'CV') and a.onhand > 0 ";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            }
            else
            {
                sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from obbq a with (nolock) ";
                sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
                sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
                sql_articulos = sql_articulos + " and a.binabs = 63 ";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
                //sql_articulos = sql_articulos + " and b.sysnumber = '" + sys_number + "' ";
                sql_articulos = sql_articulos + " order by b.sysnumber ";
            }

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();

                if (!string.IsNullOrEmpty(sys_number) && sys_number != "0")
                {
                    lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                }
            }
        }
        private void buscar_articulos_OLD()
        {
            sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from obbq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
            sql_articulos = sql_articulos + " and a.binabs = 63 ";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            sql_articulos = sql_articulos + " and b.sysnumber = '" + sys_number + "' ";
            sql_articulos = sql_articulos + " order by b.sysnumber ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
            }
        }
        private static frmVacunacionProduccion frmDefInstance;
        public static frmVacunacionProduccion DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmVacunacionProduccion();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void cbDepositos_Leave(object sender, EventArgs e)
        {
            if (cbDepositos.SelectedIndex != -1)
            {
                lote_ponedoras();
                centro_costos();
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
        private void rbAVPTradic_CheckedChanged(object sender, EventArgs e)
        {
            ubicaciones();
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
        private void rbAVPTradic_KeyDown(object sender, KeyEventArgs e)
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
