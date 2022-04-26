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
    public partial class frmMermas : Form
    {
        Company empresa = new Company();
        Documents Salida;
        
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
        string codart;
        string sysnum; 
        double cost_total;
        double cant_total;
        double new_cost;

        DataRow NewRow;
        public frmMermas()
        {
            InitializeComponent();
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
        private static frmMermas frmDefInstance;
        public static frmMermas DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMermas();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void b_articulos()
        {            
            /*sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
            sql_articulos = sql_articulos + " from oitw a ";
            sql_articulos = sql_articulos + " inner join oitm b on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " where a.whscode IN ('FC') and a.onhand > 0 ";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";*/

            sql_articulos = " select a.itemcode, b.itemname, convert(numeric(15,2), a.quantity) as existencia, convert(numeric, (b.avgprice)) as costo, c.distnumber ";
            sql_articulos = sql_articulos + " from obtq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obtn c with (nolock) on a.itemcode = c.itemcode and a.sysnumber = c.sysnumber ";
            sql_articulos = sql_articulos + " where a.whscode = 'FC' ";
            sql_articulos = sql_articulos + " and a.quantity > 0 ";
            sql_articulos = sql_articulos + " and a.sysnumber = " + sysnum;
            sql_articulos = sql_articulos + " and a.itemcode = '" + codart + "' ";

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
                lblLote.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
            };
        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //--##################################################################################--
                //--Llamada a formulario de busqueda de articulos, filtrando solo las vacunas
                //--##################################################################################--
                frmBArticulos frm = new frmBArticulos();

                frm.sql = "select a.itemcode, b.itemname, convert(numeric(15,2), a.quantity) as quantity, ";
                frm.sql = frm.sql + " a.sysnumber, c.distnumber ";
                frm.sql = frm.sql + " from obtq a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " inner join obtn c on a.itemcode = c.itemcode and a.sysnumber = c.sysnumber ";
                frm.sql = frm.sql + " where a.quantity > 0 and a.WhsCode = 'FC' ";
                frm.sql = frm.sql + " and b.itemcode like '%cart-0002%' ";
                frm.sql = frm.sql + " order by 2 ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    codart = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    sysnum = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    b_articulos();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {                    
                    b_articulos();
                };
            }
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Validaciones
                if (dgvUtilizacion.Rows.Count <= 0)
                {
                    MessageBox.Show("No existen detalles a guardar");
                    return;
                };

                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        empresa.StartTransaction();

                        Salida = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                        Salida.DocDate = dtpFecha.Value;
                        Salida.Comments = txtComentario.Text;

                        int i = 0;
                        string art = "";
                        string arti = "";
                        double cant = 0;
                        foreach (DataRow dr in ds.Tables["grilla"].Rows)
                        {
                            art = dr["itemcode"].ToString();
                            if (!arti.Contains(art))
                            {
                                Salida.Lines.SetCurrentLine(i);
                                Salida.Lines.WarehouseCode = "FC";
                                Salida.Lines.Currency = "GS";
                                Salida.Lines.AccountCode = "5.01.03.05.01";
                                Salida.Lines.ItemCode = dr["itemcode"].ToString();

                                foreach (DataRow drS in ds.Tables["grilla"].Select("itemcode = '" + art + "'"))
                                {
                                    cant = cant + double.Parse(drS["quantity"].ToString());
                                };

                                Salida.Lines.Quantity = cant;//int.Parse(dr["quantity"].ToString());

                                Salida.Lines.CostingCode = (Properties.Settings.Default.centro_costo_FC).Substring(0, 1);
                                Salida.Lines.CostingCode2 = (Properties.Settings.Default.centro_costo_FC).Substring(0, 2);
                                Salida.Lines.CostingCode3 = (Properties.Settings.Default.centro_costo_FC).Substring(0, 3);
                                Salida.Lines.CostingCode4 = (Properties.Settings.Default.centro_costo_FC).Substring(0, 5);
                                Salida.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_FC;

                                foreach (DataRow drA in ds.Tables["grilla"].Select("itemcode = '" + art + "'"))
                                {
                                    Salida.Lines.BatchNumbers.Quantity = int.Parse(drA["quantity"].ToString());
                                    Salida.Lines.BatchNumbers.BatchNumber = drA["lote"].ToString();
                                    Salida.Lines.BatchNumbers.Add();
                                };

                                Salida.Lines.Add();
                                arti = arti + art;
                                i = i + 1;
                            };
                        };

                        if (Salida.Add() != 0)
                        {
                            if (empresa.InTransaction)
                            {
                                empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                            };
                            MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        //docentry = int.Parse(empresa.GetNewObjectKey());

                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                        //imprimir_ticket();
                        MessageBox.Show("Operación finalizada con éxito");
                        this.Close();
                    }
                }
            }
            catch (Exception exec)
            {
                if (empresa.InTransaction)
                {
                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                };
                MessageBox.Show(exec.Message.ToString());
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {

            if (txtArticulo.Text == "")
            {
                txtArticulo.Focus();
                return;
            }
            else if (txtCantidad.Text == "" || txtCantidad.Text == "0")
            {
                MessageBox.Show("Debe introducir cantidad valida");
                txtCantidad.Focus();
                return;
            }
            else
            {
                NewRow = ds.Tables["grilla"].NewRow();
                NewRow["itemcode"] = txtArticulo.Text;
                NewRow["itemname"] = lblArticulo.Text;
                NewRow["quantity"] = txtCantidad.Text;
                NewRow["lote"] = lblLote.Text;
                ds.Tables["grilla"].Rows.Add(NewRow);

                limpiar_detalle();
            };
        }
        private void limpiar_detalle()
        {            
            txtArticulo.Text = "";
            lblArticulo.Text = "";
            lblLote.Text = "";
            txtCantidad.Text = "";
            txtArticulo.Focus();
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUtilizacion.CurrentCell.RowIndex != -1)
            {
                ds.Tables["grilla"].Rows[dgvUtilizacion.CurrentCell.RowIndex].Delete();
            };
            ds.AcceptChanges();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ('.')))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
