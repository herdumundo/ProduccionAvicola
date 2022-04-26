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
    public partial class frmInsumosCCH : Form
    {
        Company empresa = new Company();
        Documents Salida;

        SqlDataAdapter daArt;
        SqlDataAdapter daDepositos;
        SqlDataAdapter daCCostos;

        string sql_ccostos;
        string sql_articulos;
        string sql_depositos;

        string cod_deposito;

        public frmInsumosCCH()
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
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void limpiar_form()
        {
            txtArticulo.Text = "";
            txtCantidad.Text = "";
            cbDepositos.SelectedIndex = -1;
            lblArticulo.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtComentario.Text = "";
            dtpFecha.Focus();
        }
        private void deposito()
        {
            //sql_depositos = "select whscode, whsname from owhs where whscode in ('CCHA', 'CCHB', 'OVO') ";
            sql_depositos = "select whscode, whsname from owhs with (nolock) where whscode in ('OVO') ";
            daDepositos = new SqlDataAdapter(sql_depositos, Global.conn);
            if (ds.Tables.Contains("depositos"))
            {
                ds.Tables["depositos"].Clear();
            };

            if (daDepositos.Fill(ds, "depositos") > 0)
            {
                //cod_deposito = ds.Tables["depositos"].Rows[0]["whscode"].ToString();
                cbDepositos.DataSource = ds.Tables["depositos"];
                cbDepositos.DisplayMember = "whsname";
                cbDepositos.ValueMember = "whscode";
                cbDepositos.SelectedIndex = 0;
            }
        }
        private void b_articulos()
        {
            sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
            sql_articulos = sql_articulos + " from oitw a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " where a.whscode IN ('CCHA', 'CCHB', 'OVO') and a.onhand > 0 ";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";            
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
                txtCantidad.Focus();
            }
        }
        private void buscar_articulos()
        {
            sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
            sql_articulos = sql_articulos + " from oitw a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " where a.whscode in ('CCHA', 'CCHB', 'OVO') and a.onhand > 0 ";
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "' ";
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
                //lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
            }
        }
        private void centro_costos()
        {
            //sql_ccostos = "select prccode from oprc where prcname = '" + cbDepositos.SelectedValue + "'";
            sql_ccostos = "select prccode from oprc with (nolock) where prccode = '43201002' ";
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe introducir cantidad a consumir.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCantidad.Focus();
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
                //--Registrar Salida de Insumos
                //--##################################################################################--

                Salida = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                Salida.DocDate = dtpFecha.Value;

                //--##################################################################################--
                //--Asignacion de centro de costo 
                //--##################################################################################--
                centro_costos();

                Salida.Lines.CostingCode = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 1);
                Salida.Lines.CostingCode2 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 2);
                Salida.Lines.CostingCode3 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 3);
                Salida.Lines.CostingCode4 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 5);
                Salida.Lines.CostingCode5 = ds.Tables["ccostos"].Rows[0]["prccode"].ToString();

                //Datos de salida, campos de usuario
                //Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["cost_pol"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;

                Salida.Lines.ItemCode = txtArticulo.Text;

                Salida.Lines.WarehouseCode = cbDepositos.SelectedValue.ToString();
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_consumo_cch;
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                Salida.Comments = txtComentario.Text;

                Salida.Lines.Add();                

                if (Salida.Add() != 0)
                {
                    string text = empresa.GetLastErrorCode().ToString();
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    if (empresa.GetLastErrorCode().ToString() == "-10")
                    {
                        MessageBox.Show("El articulo que desea consumir recae en inventario negativo");
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
        private static frmInsumosCCH frmDefInstance;
        public static frmInsumosCCH DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmInsumosCCH();
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
            //if (cbDepositos.SelectedIndex != -1)
            //{
            //    centro_costos();
            //};
        }

        private void frmInsumosCCH_Load(object sender, EventArgs e)
        {
            deposito();
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbDepositos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
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
                frm.sql = "select 0 as sysnumber, a.itemcode, b.itemname,'' as distnumber,";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhand) as quantity ";
                frm.sql = frm.sql + " from oitw a ";
                frm.sql = frm.sql + " inner join oitm b on a.itemcode = b.itemcode ";
                //frm.sql = frm.sql + " where a.onhand > 0 and a.WhsCode in ('CCHA', 'CCHB', 'OVO') ";
                frm.sql = frm.sql + " where a.onhand > 0 and a.WhsCode in ('" + cbDepositos.SelectedValue.ToString()  + "') ";
                frm.sql = frm.sql + " and (b.ItemCode like 'LAB%') ";
                frm.sql = frm.sql + " order by 2, b.itemname ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[1].Value.ToString();
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
    }
}
