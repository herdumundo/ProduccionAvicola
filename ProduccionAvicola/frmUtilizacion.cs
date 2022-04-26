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
    public partial class frmUtilizacion : Form
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
        SqlDataAdapter daCCostos;

        string sql_ccostos;
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
        public frmUtilizacion()
        {
            InitializeComponent();
        }
        private void lote_pollitas()
        {
            sql_lotes = "select b.distnumber, convert(numeric, a.onhandqty) as onhandqty ";
            sql_lotes = sql_lotes + " from obbq a ";
            sql_lotes = sql_lotes + " inner join obtn b on a.snbmdabs = b.absentry ";
            sql_lotes = sql_lotes + " inner join obin c on a.binabs = c.absentry ";

            if (rbFase1.Checked == true)
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and a.whscode = 'P' ";
            }
            else
            {
                sql_lotes = sql_lotes + " where a.onhandqty > 0 and a.whscode = 'Z' ";
            }
            sql_lotes = sql_lotes + " and a.binabs = " + cbDepositos.SelectedValue;
            daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
            if (ds.Tables.Contains("lote_poll"))
            {
                ds.Tables["lote_poll"].Clear();
            };
            if (daLotes.Fill(ds, "lote_poll") > 0)
            {
                lblLote.Text = ds.Tables["lote_poll"].Rows[0]["distnumber"].ToString();
                lblCantidad.Text = ds.Tables["lote_poll"].Rows[0]["onhandqty"].ToString();
            }
            else
            {
                MessageBox.Show("No existen lotes de pollitas en este Aviario");
                //cbDepositos.Focus();
                return;
            };
        }
        private void ubicaciones()
        {
            sql_ubicaciones = "select absentry, bincode, whscode from obin ";
            if (rbFase1.Checked == true)
            {
                sql_ubicaciones = sql_ubicaciones + " where whscode = 'P' ";
            }
            else
            {
                sql_ubicaciones = sql_ubicaciones + " where whscode = 'Z' ";
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
            sql_ccostos = "select prccode from oprc where prcname = '" + cbDepositos.Text + "'";
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
        private void frmInsumosRecria_Load(object sender, EventArgs e)
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
        private void limpiar_form()
        {
            //txtArticulo.Text = "";
            //txtCantidad.Text = "";
            rbFase1.Checked = true;
            cbDepositos.SelectedIndex = -1;
            //lblArticulo.Text = "";
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                //if (txtCantidad.Text == "")
                //{
                //    MessageBox.Show("Debe introducir cantidad a consumir.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    txtCantidad.Focus();
                //    return;
                //};

                //--##################################################################################--//
                //--Consulta de costo de lote de vacuna a ser utilizada                               --//
                //--##################################################################################--//

                sql_lotes = "select distinct 0 as sysnumber, b.itemcode, b.itemname, '' as distnumber, ";
                sql_lotes = sql_lotes + " convert(numeric(12,2), a.onhand) as quantity,  ";
                sql_lotes = sql_lotes + " b.AvgPrice as costo_uni ";
                sql_lotes = sql_lotes + " from oitw a ";                
                sql_lotes = sql_lotes + " inner join OITM b on a.ItemCode = b.ItemCode ";
                sql_lotes = sql_lotes + " where a.onhand > 0 and a.WhsCode in ('R', 'CV')  ";
                sql_lotes = sql_lotes + " and (b.itemcode like 'INRE%' or b.itemcode like 'LENA%' or b.itemcode like 'REAC%') ";
                //sql_lotes = sql_lotes + " and b.itemcode = '" + txtArticulo.Text + "' ";

                sql_lotes = sql_lotes + " union all ";

                sql_lotes = sql_lotes + " select distinct b.sysnumber, b.itemcode, b.itemname, b.distnumber, ";
                sql_lotes = sql_lotes + " convert(numeric(12,2), a.Quantity) as quantity,  ";
                sql_lotes = sql_lotes + " case when convert(numeric, (b.balance/a.quantity)) = 0 then c.AvgPrice  ";
                sql_lotes = sql_lotes + " else convert(numeric, (b.balance/a.quantity))end as costo_uni ";
                sql_lotes = sql_lotes + " from oibt a ";
                sql_lotes = sql_lotes + " inner join obtn b on a.BatchNum = b.DistNumber and a.ItemCode = b.ItemCode ";
                sql_lotes = sql_lotes + " inner join OITM c on a.ItemCode = c.ItemCode ";
                sql_lotes = sql_lotes + " where a.quantity > 0 and a.WhsCode = 'CV' ";
                sql_lotes = sql_lotes + " and b.itemcode like 'VITA%'";
                sql_lotes = sql_lotes + " and a.sysnumber =" + sys_number;
                //sql_lotes = sql_lotes + " and b.itemcode = '" + txtArticulo.Text + "' ";
                sql_lotes = sql_lotes + " order by b.itemname ";

                daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };
                daLotes.Fill(ds, "lotes");

                //--##################################################################################--
                //--Consulta de costo de pollitos
                //--##################################################################################--

                sql_costos_pol = "select a.itemcode, b.itemname, b.sysnumber, b.distnumber, b.costtotal, a.onhandqty, b.absentry, ";
                sql_costos_pol = sql_costos_pol + " convert(numeric, (b.costtotal/a.onhandqty)) as costo_uni, b.balance, b.quantity ";
                sql_costos_pol = sql_costos_pol + " from obbq a ";
                sql_costos_pol = sql_costos_pol + " inner join obtn b on a.snbmdabs = b.absentry ";
                sql_costos_pol = sql_costos_pol + " inner join obin c on a.binabs = c.absentry ";
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
                }
                else
                {
                    MessageBox.Show("No existen costos para este articulo");
                    return;
                };


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
                Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["cost_pol"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = ds.Tables["cost_pol"].Rows[0]["itemname"].ToString();//lblArticulo.Text;

                Salida.Lines.ItemCode = ds.Tables["lotes"].Rows[0]["itemcode"].ToString();

                //Almacen de Recria
                //if (txtArticulo.Text.Contains("VITA"))
                //{
                //    Salida.Lines.WarehouseCode = "CV";
                //    Salida.Lines.BinAllocations.Quantity = double.Parse(txtCantidad.Text);
                //    Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                //    Salida.Lines.BinAllocations.BinAbsEntry = 64;

                //    Salida.Lines.Currency = "GS";
                //    Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_insumos_pollitos;
                //    Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //    Salida.Comments = txtComentario.Text;

                //    Salida.Lines.BatchNumbers.Quantity = double.Parse(txtCantidad.Text);
                //    Salida.Lines.BatchNumbers.BatchNumber = ds.Tables["lotes"].Rows[0]["distnumber"].ToString();
                //    Salida.Lines.BatchNumbers.Add();
                //    Salida.Lines.Add();
                //}
                //else if (txtArticulo.Text.Contains("REAC"))
                //{
                //    Salida.Lines.WarehouseCode = "CV";
                //    Salida.Lines.BinAllocations.Quantity = double.Parse(txtCantidad.Text);
                //    Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                //    Salida.Lines.BinAllocations.BinAbsEntry = 64;

                //    Salida.Lines.Currency = "GS";
                //    Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_insumos_pollitos;
                //    Salida.Lines.Quantity = double.Parse(txtCantidad.Text);
                //    Salida.Comments = txtComentario.Text;
                //}
                //else
                //{
                //    Salida.Lines.WarehouseCode = "R";
                //    Salida.Lines.Currency = "GS";
                //    Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_insumos_pollitos;
                //    Salida.Lines.Quantity = double.Parse(txtCantidad.Text);
                //    Salida.Comments = txtComentario.Text; 
                //};                
                
                if (Salida.Add() != 0)
                {
                    string text = empresa.GetLastErrorCode().ToString();
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    if (empresa.GetLastErrorCode().ToString() == "-10")
                    {
                        MessageBox.Show("El articulo que desea consumir recae en inventario negativo para la ubicación 64");
                        return;
                    }
                    else if (empresa.GetLastErrorCode().ToString() == "-5002")
                    {
                        MessageBox.Show("La cantidad a consumir debe ser mayor a 0");
                        return;
                    }
                    else
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription());
                        return;
                    };                    
                };

                //--##################################################################################--
                //--Calcular nuevo costo de pollitos segun el consumo de vacunas
                //--##################################################################################--

                //new_cost = ((double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["lotes"].Rows[0]["costo_uni"].ToString())) / cant_total) + (cost_total / cant_total);

                //--##################################################################################--
                //--Realizar la revalorizacion del lote de pollitos
                //--##################################################################################--

                Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                Revalorizacion.DocDate = dtpFecha.Value;
                Revalorizacion.TaxDate = dtpFecha.Value;
                Revalorizacion.RevalType = "P";

                //--##################################################################################--
                //--Asignacion de centros de costo en revalorizacion
                //--##################################################################################--

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
                Revalorizacion.Lines.RevaluationIncrementAccount = Properties.Settings.Default.cta_consumo_insumos_pollitos; //"5.12.03.03.01";
                Revalorizacion.Lines.RevaluationDecrementAccount = Properties.Settings.Default.cta_consumo_insumos_pollitos; //"5.12.03.03.01";

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
                MessageBox.Show("Proceso finalizado");
                limpiar_form();
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
                //empresa.EndTransaction(BoWfTransOpt.wf_Commit);
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
                frm.sql = frm.sql + " from oitw a ";
                frm.sql = frm.sql + " inner join oitm b on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " where a.onhand > 0 and a.WhsCode = 'R'  ";
                frm.sql = frm.sql + " and (b.ItemCode like 'inre%' or b.ItemCode like 'LENA%') ";
                frm.sql = frm.sql + " and a.ItemCode not in ('INRE-00003','INRE-00004','INRE-00005','INRE-00008', 'INRE-00009') ";
                
                frm.sql = frm.sql + " union all ";

                frm.sql = frm.sql + " select b.sysnumber, b.itemcode, b.itemname, b.distnumber, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhandqty) as quantity ";
                frm.sql = frm.sql + " from obbq a ";
                frm.sql = frm.sql + " inner join obtn b on a.snbmdabs = b.absentry ";
                frm.sql = frm.sql + " inner join obin c on a.binabs = c.absentry ";
                frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'CV' ";
                frm.sql = frm.sql + " and a.binabs = 64 ";
                frm.sql = frm.sql + " and b.ItemCode like 'Vita%' ";

                frm.sql = frm.sql + " union all ";

                frm.sql = frm.sql + " select 0 as sysnumber, a.itemcode, b.itemname,'' as distnumber, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhand) as quantity ";
                frm.sql = frm.sql + " from oitw a ";
                frm.sql = frm.sql + " inner join oitm b on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " inner join obin c on a.WhsCode = c.WhsCode ";
                frm.sql = frm.sql + " where a.onhand > 0 and a.WhsCode = 'CV' ";
                frm.sql = frm.sql + " and c.AbsEntry = 64 ";
                frm.sql = frm.sql + " and b.ItemName like 'AGU%' ";

                frm.sql = frm.sql + " order by 2, b.itemname ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[1].Value.ToString();
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
                sql_articulos = sql_articulos + " from oitw a ";
                sql_articulos = sql_articulos + " inner join oitm b on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where a.whscode IN ('R', 'CV') and a.onhand > 0 ";
                //sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            }
            else
            {
                sql_articulos = sql_articulos + " select b.sysnumber, b.itemcode, b.itemname, b.distnumber,  ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from obbq a ";
                sql_articulos = sql_articulos + " inner join obtn b on a.snbmdabs = b.absentry  ";
                sql_articulos = sql_articulos + " inner join obin c on a.binabs = c.absentry  ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' and a.binabs = 64  ";
                sql_articulos = sql_articulos + " and b.sysnumber = " + sys_number;
                //sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            }           

            sql_articulos = sql_articulos + " order by b.itemname ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                //txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                //lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                if (sys_number != "0")
                {
                    //lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                };
                
                //txtCantidad.Focus();
            }
        }
        private void buscar_articulos()
        {
            sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
            sql_articulos = sql_articulos + " from oitw a ";
            sql_articulos = sql_articulos + " inner join oitm b on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " where (a.whscode = 'R' or a.whscode = 'CV') and a.onhand > 0 ";
            //sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            sql_articulos = sql_articulos + " union all ";
            sql_articulos = sql_articulos + " select b.itemcode, b.itemname, a.onhandqty as onhand ";
            sql_articulos = sql_articulos + " from oibq a ";
            sql_articulos = sql_articulos + " inner join oitm b on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obin c on a.binabs = c.absentry ";
            sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.binabs = 64 ";
            sql_articulos = sql_articulos + " and b.itemcode like 'VITA%' ";
            //sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
            sql_articulos = sql_articulos + " order by b.itemname ";

            daArt = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArt.Fill(ds, "articulos") > 0)
            {
                //txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                //lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                //lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
            }
        }
        private static frmInsumosRecria frmDefInstance;
        public static frmInsumosRecria DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmInsumosRecria();
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
                lote_pollitas();
                centro_costos();
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
        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
