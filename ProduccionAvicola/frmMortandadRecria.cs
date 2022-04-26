﻿using System;
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
    public partial class frmMortandadRecria : Form
    {
        Company empresa = new Company();
        Documents Salida;
        MaterialRevaluation Revalorizacion;

        SqlDataAdapter daLotes;
        SqlDataAdapter daArt;
        SqlDataAdapter daUbicaciones;
        SqlDataAdapter daDepositos;
        SqlDataAdapter daCostoLotes;
        SqlDataAdapter daMotivos;
        SqlDataAdapter daCCostos;

        string sql_ccostos;
        string sql_motivos;
        string sql_lotes;
        string sql_articulos;
        string sql_ubicaciones;
        string sql_depositos;
        string sql_costos;

        string cod_deposito;
        string sys_number;

        double cost_total;
        double cant_total;
        double new_cost;
        public frmMortandadRecria()
        {
            InitializeComponent();
        }
        private void lote_pollitas()
        {
            sql_lotes = "select b.distnumber, convert(numeric, a.onhandqty) as onhandqty ";
            sql_lotes = sql_lotes + " from obbq a with (nolock) ";
            sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_lotes = sql_lotes + " inner join obin c with (nolock) on a.binabs = c.absentry ";

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
                MessageBox.Show("No existen costos para este articulo");
                return;
            };
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
        private void motivos()
        {
            sql_motivos = "select code, name from [@MERMA] with (nolock) ";            
            daMotivos = new SqlDataAdapter(sql_motivos, Global.conn);
            if (ds.Tables.Contains("motivos"))
            {
                ds.Tables["motivos"].Clear();
            };
            daMotivos.Fill(ds, "motivos");
            cbMotivos.DataSource = ds.Tables["motivos"];
            cbMotivos.DisplayMember = "name";
            cbMotivos.ValueMember = "code";
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
                //Validaciones de campos
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe introducir cantidad de aves muertas.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCantidad.Focus();
                    return;
                };

                Cursor.Current = Cursors.WaitCursor;

                //--##################################################################################--
                //--Consulta que devuelve costo y cantidad total de pollitas
                //--##################################################################################--

                sql_costos = "select a.itemcode, a.itemname, a.sysnumber, a.distnumber, a.balance, (a.quantity - a.quantout) as quantity, ";
                sql_costos = sql_costos + " a.costtotal, a.quantity as cant, ";
                sql_costos = sql_costos + " convert(numeric(12,2), (a.balance/(a.quantity-a.quantout))) as costo_uni, a.absentry  ";
                sql_costos = sql_costos + " from obtn a with (nolock) ";
                sql_costos = sql_costos + " where a.itemcode = '" + ds.Tables["articulos"].Rows[0]["itemcode"].ToString() + "' ";
                sql_costos = sql_costos + " and a.sysnumber = " + ds.Tables["articulos"].Rows[0]["sysnumber"].ToString();
                daCostoLotes = new SqlDataAdapter(sql_costos, Global.conn);
                if (ds.Tables.Contains("cost"))
                {
                    ds.Tables["cost"].Clear();
                };
                if (daCostoLotes.Fill(ds, "cost") > 0)
                {
                    cost_total = double.Parse(ds.Tables["cost"].Rows[0]["costtotal"].ToString());
                    cant_total = double.Parse(ds.Tables["cost"].Rows[0]["cant"].ToString());
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

                //--##################################################################################--
                //--Realizar salida de inventario
                //--##################################################################################--

                Salida = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                Salida.DocDate = dtpFecha.Value;

                //--##################################################################################--
                //--Campos de usuario salida
                //--##################################################################################--

                Salida.UserFields.Fields.Item("U_cod_art").Value = ds.Tables["cost"].Rows[0]["itemcode"].ToString();//txtArticulo.Text;
                Salida.UserFields.Fields.Item("U_Codigo_lote").Value = lblLote.Text;
                Salida.UserFields.Fields.Item("U_Desc_art").Value = ds.Tables["cost"].Rows[0]["itemname"].ToString();//lblArticulo.Text;
                if (cbMotivos.SelectedIndex != -1)
                {
                    Salida.UserFields.Fields.Item("U_MOTIVO").Value = cbMotivos.SelectedValue;
                };

                //--##################################################################################--
                //--Asignacion de centro de costo 
                //--##################################################################################--

                Salida.Lines.CostingCode = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 1);
                Salida.Lines.CostingCode2 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 2);
                Salida.Lines.CostingCode3 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 3);
                Salida.Lines.CostingCode4 = (ds.Tables["ccostos"].Rows[0]["prccode"].ToString()).Substring(0, 5);
                Salida.Lines.CostingCode5 = ds.Tables["ccostos"].Rows[0]["prccode"].ToString();

                //--##################################################################################--
                //--Comentarios de la operacion realizada
                //--##################################################################################--

                Salida.Comments = txtComentario.Text;

                Salida.Lines.ItemCode = ds.Tables["cost"].Rows[0]["itemcode"].ToString();


                //--##################################################################################--
                //--Dependiendo del almacen seleccionado en los radiobuttons se selecciona WarehouseCode
                //--##################################################################################--

                if (rbFase1.Checked == true)
                {
                    Salida.Lines.WarehouseCode = "P";
                }
                else if (rbFase2.Checked == true)
                {
                    Salida.Lines.WarehouseCode = "Z";
                }

                //--##################################################################################--
                //--Dependiendo de la ubicación seleccionada en el combobox, se asigna BinAllocations
                //--##################################################################################--

                Salida.Lines.BinAllocations.BinAbsEntry = int.Parse(cbDepositos.SelectedValue.ToString());
                Salida.Lines.BinAllocations.Quantity = int.Parse(txtCantidad.Text);
                Salida.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = 0;
                Salida.Lines.Currency = "GS";
                Salida.Lines.AccountCode = Properties.Settings.Default.cta_mortandad_pollitos; //"5.12.03.03.01";
                Salida.Lines.Quantity = int.Parse(txtCantidad.Text);
                //Salida.Lines.PriceAfterVAT = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());
                //Salida.Lines.LineTotal = double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString());
                Salida.Lines.BatchNumbers.Quantity = int.Parse(txtCantidad.Text);
                Salida.Lines.BatchNumbers.BatchNumber = ds.Tables["cost"].Rows[0]["distnumber"].ToString();
                Salida.Lines.BatchNumbers.Add();
                Salida.Lines.Add();

                if (Salida.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };

                //new_cost = ((double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString())) + cost_total) / (cant_total - double.Parse(txtCantidad.Text));
                new_cost = ((double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString()) * cant_total) + ((double.Parse(txtCantidad.Text) * double.Parse(ds.Tables["cost"].Rows[0]["costo_uni"].ToString()))))/(cant_total);


                Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                Revalorizacion.DocDate = dtpFecha.Value;
                Revalorizacion.TaxDate = dtpFecha.Value;
                Revalorizacion.Comments = txtComentario.Text;
                Revalorizacion.RevalType = "P";
                //--##################################################################################--
                //--Asignacion de Centros de beneficio
                //--##################################################################################--s
                //Revalorizacion.Lines.DistributionRule = "D";
                //Revalorizacion.Lines.DistributionRule2 = "D1";
                //Revalorizacion.Lines.DistributionRule3 = "D2";
                //Revalorizacion.Lines.DistributionRule4 = "4";
                //Revalorizacion.Lines.DistributionRule5 = "5";


                //--##################################################################################--
                //--Asignar warehousecode dependiendo de la seleccion de los radiobuttons
                //--##################################################################################--
                if (rbFase1.Checked == true)
                {
                    Revalorizacion.Lines.WarehouseCode = "P";
                }
                else if (rbFase2.Checked == true)
                {
                    Revalorizacion.Lines.WarehouseCode = "Z";
                }
                
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
                if (empresa.Connected)
                {
                    empresa.Disconnect();
                };                
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
                frm.sql = "select b.sysnumber, b.itemcode, b.itemname, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhandqty) as quantity ";
                frm.sql = frm.sql + " from obbq a with (nolock) ";
                frm.sql = frm.sql + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
                frm.sql = frm.sql + " inner join obin c with (nolock) on a.binabs = c.absentry ";
                if (rbFase1.Checked == true)
                {
                    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'P' ";
                }
                else
                {
                    frm.sql = frm.sql + " where a.onhandqty > 0 and a.WhsCode = 'Z' ";
                }
                frm.sql = frm.sql + " and a.binabs = " + cbDepositos.SelectedValue;
                frm.sql = frm.sql + " and b.itemcode like 'POL%' ";
                frm.sql = frm.sql + " order by b.itemname ";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    sys_number = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[1].Value.ToString();
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
        private void buscar_articulos()
        {
            sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from obbq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
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
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'" ; 
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
            }
            else
            {
                MessageBox.Show("Articulo inexistente");
                return;
            }
        }
        private void b_articulos()
        {
            sql_articulos = "select b.sysnumber, b.itemcode, b.itemname, b.distnumber, b.absentry, ";
            sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
            sql_articulos = sql_articulos + " from obbq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join obtn b with (nolock) on a.snbmdabs = b.absentry ";
            sql_articulos = sql_articulos + " inner join obin c with (nolock) on a.binabs = c.absentry ";
            if (rbFase1.Checked == true)
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'P' ";
            }
            else
            {
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'Z' ";
            }
            sql_articulos = sql_articulos + " and b.itemcode = '" + txtArticulo.Text + "'";
            sql_articulos = sql_articulos + " and b.sysnumber = " + sys_number;

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
        private void frmMortandadRecria_Load(object sender, EventArgs e)
        {
            ubicaciones();
            motivos();
            cbMotivos.SelectedIndex = -1;
            cbDepositos.SelectedIndex = -1;
        }

        private static frmMortandadRecria frmDefInstance;
        public static frmMortandadRecria DefInstance 
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMortandadRecria();
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
            if (e.KeyCode == Keys.Enter && txtCantidad.Text != "")
            {
                if (int.Parse(txtCantidad.Text) > 100)
                {
                    if (MessageBox.Show("Cantidad de aves muertas superior a 100. Es correcta la cantidad?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SendKeys.Send("{Tab}");
                    }
                    else
                    {
                        txtCantidad.Text = "";
                        txtCantidad.Focus();
                        txtCantidad.Select();
                    }
                }
                else
                {
                    SendKeys.Send("{Tab}");
                }
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

        private void cbMotivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                if (int.Parse(txtCantidad.Text) > 100)
                {
                    if (MessageBox.Show("Cantidad de aves muertas superior a 100. Es correcta la cantidad?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SendKeys.Send("{Tab}");
                    }
                    else
                    {
                        txtCantidad.Text = "";
                        txtCantidad.Focus();
                        txtCantidad.Select();
                    }
                }
                else if (int.Parse(txtCantidad.Text) == 0)
                {
                    MessageBox.Show("Cantidad de aves muertas no puede ser 0.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCantidad.Select();
                    txtCantidad.Focus();
                    return;
                }
            }          
        }

        private void cbMotivos_Leave(object sender, EventArgs e)
        {
            if (cbMotivos.SelectedIndex != -1)
            {
                txtComentario.Text = cbMotivos.Text.Substring(0, 1) + "-" + dtpFecha.Value.Year + dtpFecha.Value.Month.ToString() + dtpFecha.Value.Day + "-" + cbDepositos.Text;
            }  
        }
    }
}
