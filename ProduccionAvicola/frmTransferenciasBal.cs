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
using reportman;

namespace ProduccionAvicola
{
    public partial class frmTransferenciasBal : Form
    {
        Company empresa = new Company();
        StockTransfer Transferencia;

        ReportManX rep = new ReportManX();

        SqlDataAdapter daArticulos;
        SqlDataAdapter daUbicaciones;
        SqlDataAdapter daOrigen;
        SqlDataAdapter daDestino;
        SqlDataAdapter daRetirado;

        string sql_retirado;
        string sql_articulos;
        string sql_ubicaciones;
        string sql_origen;
        string sql_destino;

        int docentry;
        string codart;

        DataRow NewRow;

        public frmTransferenciasBal()
        {
            InitializeComponent();
        }
        //################################################################################################
        //Conexion a SAP
        //################################################################################################
        private void conexion()
        {
            empresa.Server = Properties.Settings.Default.Properties["sap_server"].DefaultValue.ToString();
            empresa.CompanyDB = Properties.Settings.Default.Properties["sap_companydb"].DefaultValue.ToString();
            switch (Properties.Settings.Default.sap_servertype)
            {
                case "2005":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2005;
                    break;
                case "2014":
                    empresa.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                    break;
            };
            empresa.LicenseServer = Properties.Settings.Default.sap_server;
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.language = BoSuppLangs.ln_Spanish;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        //################################################################################################
        //Llenado de combos y consultas a la base de datos
        //################################################################################################
        private void llenar_origen()
        {
            sql_origen = "select a.absentry, a.bincode from obin a where a.bincode not like '%ubica%' and a.whscode = 'sil' order by a.bincode ";
            daOrigen = new SqlDataAdapter(sql_origen, Global.conn);

            if (ds.Tables.Contains("origen"))
            {
                ds.Tables["origen"].Clear();
            };

            daOrigen.Fill(ds, "origen");
            cbOrigen.DataSource = ds.Tables["origen"];
            cbOrigen.DisplayMember = "bincode";
            cbOrigen.ValueMember = "absentry";

            cbOrigen.SelectedIndex = -1;
        }
        private void llenar_destino()
        {
            sql_destino = "select whscode, whsname from owhs where whscode in ('pp', 'p', 'z') order by whsname";
            daDestino = new SqlDataAdapter(sql_destino, Global.conn);

            if (ds.Tables.Contains("destino"))
            {
                ds.Tables["destino"].Clear();
            };

            daDestino.Fill(ds, "destino");
            cbDestino.DataSource = ds.Tables["destino"];
            cbDestino.DisplayMember = "whsname";
            cbDestino.ValueMember = "whscode";

            cbDestino.SelectedIndex = -1;
        }
        private void llenar_ubicaciones()
        {
            sql_ubicaciones = "select a.absentry, a.bincode from obin a where a.bincode not like '%ubica%' and a.whscode = '" + cbDestino.SelectedValue.ToString() + "' ";
            daUbicaciones = new SqlDataAdapter(sql_ubicaciones, Global.conn);
            if (ds.Tables.Contains("ubicaciones"))
            {
                ds.Tables["ubicaciones"].Clear();
            };

            if (daUbicaciones.Fill(ds, "ubicaciones") > 0)
            {
                cbUbicaciones.DataSource = ds.Tables["ubicaciones"];
                cbUbicaciones.DisplayMember = "bincode";
                cbUbicaciones.ValueMember = "absentry";
            };
        }
        private void llenar_retirado()
        {
            sql_retirado = "select slpcode, slpname from oslp order by slpname ";
            daRetirado = new SqlDataAdapter(sql_retirado, Global.conn);

            if (ds.Tables.Contains("retirado"))
            {
                ds.Tables["retirado"].Clear();
            };

            daRetirado.Fill(ds, "retirado");
            cbRetirado.DataSource = ds.Tables["retirado"];
            cbRetirado.DisplayMember = "slpname";
            cbRetirado.ValueMember = "slpcode";

            cbRetirado.SelectedIndex = -1;
        }
        private void b_articulo()
        {        
            sql_articulos = "select a.itemcode, b.itemname, convert(numeric(15,2), a.onhandqty) as existencia, convert(numeric, (b.avgprice)) as costo ";
            sql_articulos = sql_articulos + " from oibq a inner join oitm b on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obin c on a.binabs = c.absentry ";
            sql_articulos = sql_articulos + " where a.itemcode = '" + codart + "'";
            sql_articulos = sql_articulos + " and c.absentry = " + cbOrigen.SelectedValue;
            sql_articulos = sql_articulos + " and a.onhandqty > 0 and a.whscode = 'sil' ";
            //sql_articulos = sql_articulos + " and b.itmsgrpcod in (128, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147) ";
            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);

            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };

            if (daArticulos.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                txtDescripcion.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
            }
            else
            {
                txtArticulo.Text = "";
                txtDescripcion.Text = "";
                txtCantidad.Text = "";
                txtArticulo.Focus();
                return;
            };
        }
        private void limpiar_form()
        {
            dtpFecha.Value = DateTime.Now;
            cbOrigen.SelectedIndex = -1;
            cbDestino.SelectedIndex = -1;
            cbUbicaciones.SelectedIndex = -1;
            ds.Tables["grilla"].Clear();
            dgvTransferencias.DataSource = ds.Tables["grilla"];
            txtObservacion.Text = "";
            cbRetirado.SelectedIndex = -1;
            dtpFecha.Focus();
        }
        private void limpiar_detalle()
        {
            //cbPotreros.SelectedIndex = -1;
            txtArticulo.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            //cbPotreros.Focus();
            txtArticulo.Focus();
        }
        private void imprimir_ticket()
        {
            //docentry = 155817;

            rep = new ReportManX();

            rep.filename = Application.StartupPath + "\\Reportes\\Transferencias Ticket.rep";

            rep.SetParamValue("DOCENTRY", docentry);
            rep.SetDatabaseConnectionString("CON", Global.str_conn_REP);

            rep.Title = "Transferencias";
            rep.Preview = false;
            rep.Language = 1;
            rep.ShowPrintDialog = true;
            rep.Execute();

            this.Close();
        }
        //################################################################################################
        //Abrir una sola instancia del formulario
        //################################################################################################
        private static frmTransferenciasBal frmDefInstance;
        public static frmTransferenciasBal DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmTransferenciasBal();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        //################################################################################################
        //Captura de tecla presionada en el formulario
        //################################################################################################
        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            llenar_origen();
            llenar_destino();
            llenar_retirado();
            dgvTransferencias.AllowUserToAddRows = false;
        }
        //################################################################################################
        //Codigo de la botonera
        //################################################################################################
        private void btninsertar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Debe introducir cantidad");
                txtCantidad.Focus();
                return;
            }
            else if (double.Parse(txtCantidad.Text) > double.Parse(ds.Tables["articulos"].Rows[0]["existencia"].ToString()))
            {
                MessageBox.Show("Cantidad a Transferir supera la existencia actual");
                txtCantidad.Select();
                txtCantidad.Focus();
                return;
            }
            else if (txtArticulo.Text == "")
            {
                MessageBox.Show("Debe seleccionar articulo a transferir");
                txtArticulo.Focus();
                return;
            }
            //else if (cbPotreros.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Debe seleccionar el potrero al cual transferir");
            //    cbPotreros.Focus();
            //    return;
            //}
            else
            {
                NewRow = ds.Tables["grilla"].NewRow();
                NewRow["itemcode"] = txtArticulo.Text;
                NewRow["itemname"] = txtDescripcion.Text;
                NewRow["quantity"] = txtCantidad.Text;
                NewRow["bincode"] = cbUbicaciones.SelectedValue;
                //NewRow["cost"] = ds.Tables["articulos"].Rows[0]["costo"].ToString();
                ds.Tables["grilla"].Rows.Add(NewRow);

                limpiar_detalle();
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvTransferencias.CurrentCell.RowIndex != -1)
            {
                ds.Tables["grilla"].Rows[dgvTransferencias.CurrentCell.RowIndex].Delete();
            };
            ds.AcceptChanges();
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Validaciones
                if (dgvTransferencias.Rows.Count <= 0)
                {
                    MessageBox.Show("No existen detalles a guardar");
                    return;
                };

                if (cbOrigen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar estancia origen");
                    cbOrigen.Focus();
                    return;
                };

                if (cbDestino.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar estancia destino");
                    cbDestino.Focus();
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

                        Transferencia = empresa.GetBusinessObject(BoObjectTypes.oStockTransfer);
                        Transferencia.DocDate = dtpFecha.Value;
                        Transferencia.FromWarehouse = "SIL";// cbOrigen.SelectedValue.ToString();
                        Transferencia.ToWarehouse = cbDestino.SelectedValue.ToString();
                        Transferencia.SalesPersonCode = int.Parse(cbRetirado.SelectedValue.ToString());
                        Transferencia.Comments = txtObservacion.Text;

                        int i = 0;
                        foreach (DataRow dr in ds.Tables["grilla"].Rows)
                        {
                            Transferencia.Lines.BinAllocations.SetCurrentLine(i);
                            Transferencia.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
                            Transferencia.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = i;
                            Transferencia.Lines.BinAllocations.Quantity = double.Parse(dr["quantity"].ToString());
                            Transferencia.Lines.BinAllocations.BinAbsEntry = int.Parse(cbOrigen.SelectedValue.ToString());
                            Transferencia.Lines.BinAllocations.Add();

                            Transferencia.Lines.BinAllocations.SetCurrentLine(i);
                            Transferencia.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batToWarehouse;
                            Transferencia.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = i;
                            Transferencia.Lines.BinAllocations.Quantity = double.Parse(dr["quantity"].ToString());
                            Transferencia.Lines.BinAllocations.BinAbsEntry = int.Parse(dr["bincode"].ToString());
                            Transferencia.Lines.BinAllocations.Add();

                            Transferencia.Lines.SetCurrentLine(i);
                            Transferencia.Lines.ItemCode = dr["itemcode"].ToString();
                            Transferencia.Lines.ItemDescription = dr["itemname"].ToString();
                            Transferencia.Lines.WarehouseCode = cbDestino.SelectedValue.ToString();
                            Transferencia.Lines.Quantity = double.Parse(dr["quantity"].ToString());
                            Transferencia.Lines.Add();

                            i = i + 1;
                        };

                        if (Transferencia.Add() != 0)
                        {
                            if (empresa.InTransaction)
                            {
                                empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                            };
                            MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        docentry = int.Parse(empresa.GetNewObjectKey());

                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                        imprimir_ticket();
                        MessageBox.Show("Operación finalizada con éxito");
                        //this.Close();
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
                limpiar_form();
                Cursor.Current = Cursors.Default;
            };
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //################################################################################################
        //Moverse por el formularion con la tecla enter
        //################################################################################################
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            //e.Handled = true;

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbDestino_KeyDown(object sender, KeyEventArgs e)
        {
            // e.Handled = true;

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbUbicaciones_KeyDown(object sender, KeyEventArgs e)
        {
            //e.Handled = true;

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmBArticulos frm = new frmBArticulos();
                frm.sql = "select a.itemcode, c.itemname, convert(numeric(15,2), a.onhandqty) as quantity, '' as sysnumber, '' as distnumber ";
                frm.sql = frm.sql + " from oibq a ";
                frm.sql = frm.sql + " inner join obin b on a.binabs = b.absentry";
                frm.sql = frm.sql + " inner join oitm c on a.itemcode = c.itemcode";              
                frm.sql = frm.sql + " where a.onhandqty > 0 ";             
                frm.sql = frm.sql + " and a.whscode = 'sil' and a.itemcode like 'bal%'";
                frm.sql = frm.sql + " and b.bincode not like '%locat%'";
                frm.sql = frm.sql + " and b.absentry = " + cbOrigen.SelectedValue;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    codart = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    b_articulo();
                    SendKeys.Send("{Tab}");
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                codart = txtArticulo.Text;
                b_articulo();
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
        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDestino.SelectedIndex != -1)
            {
                llenar_ubicaciones();
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            };
        }
        private void cbRetirado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtObservacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbUbicaciones_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
    }
}
