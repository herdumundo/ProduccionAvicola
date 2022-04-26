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
    public partial class frmTransferencias : Form
    {
        Company empresa = new Company();
        StockTransfer Transferencia;

        SqlDataAdapter daArticulos;
        SqlDataAdapter daPotreros;
        SqlDataAdapter daOrigen;
        SqlDataAdapter daDestino;
        SqlDataAdapter daRetirado;

        string sql_retirado;
        string sql_articulos;
        string sql_potreros;
        string sql_origen;
        string sql_destino;

        int docentry;
        string codart;
        string sysnum;

        DataRow NewRow;

        public frmTransferencias()
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
            empresa.language = BoSuppLangs.ln_Spanish;
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        //################################################################################################
        //Llenado de combos y consultas a la base de datos
        //################################################################################################
        private void llenar_origen()
        {
            sql_origen = "select whscode, whsname from owhs with (nolock) where whscode = '" + Global.deposito + "' order by whsname ";
            daOrigen = new SqlDataAdapter(sql_origen, Global.conn);

            if (ds.Tables.Contains("origen"))
            {
                ds.Tables["origen"].Clear();
            };

            daOrigen.Fill(ds, "origen");
            cbOrigen.DataSource = ds.Tables["origen"];
            cbOrigen.DisplayMember = "whsname";
            cbOrigen.ValueMember = "whscode";

            //cbOrigen.SelectedIndex = -1;
        }
        private void llenar_destino()
        {
            sql_destino = "select whscode, whsname from owhs with (nolock) ";
            sql_destino = sql_destino + " where whscode not in ('" + Global.deposito + "') ";
            if (Global.deposito == "FC")
            {
                sql_destino = sql_destino + " and whscode in ('CCHA', 'CCHB', 'CCHH', 'FS001', 'OVO') ";
            };            
            
            sql_destino = sql_destino + " order by whsname";
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
        private void llenar_retirado()
        {
            sql_retirado = "select slpcode, slpname from oslp where u_area = 'FC' order by slpname ";
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
            /*sql_articulos = "select a.itemcode, b.itemname, convert(numeric(15,2), a.onhand) as existencia, convert(numeric, (b.avgprice)) as costo ";
            sql_articulos = sql_articulos + " from oitw a with (nolock) inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " where a.itemcode = '" + codart + "'";
            sql_articulos = sql_articulos + " and b.itemname like 'cart%' ";
            sql_articulos = sql_articulos + " and a.onhand > 0 and a.whscode = 'fc' ";
            //sql_articulos = sql_articulos + " and b.itmsgrpcod in (128, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147) ";*/

            
            sql_articulos = " select a.itemcode, b.itemname, convert(numeric(15,2), a.quantity) as existencia, convert(numeric, (b.avgprice)) as costo, c.distnumber ";
            sql_articulos = sql_articulos + " from obtq a with (nolock) ";
            sql_articulos = sql_articulos + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
            sql_articulos = sql_articulos + " inner join obtn c with (nolock) on a.itemcode = c.itemcode and a.sysnumber = c.sysnumber ";
            sql_articulos = sql_articulos + " where a.whscode = '" + cbOrigen.SelectedValue + "' ";
            sql_articulos = sql_articulos + " and a.quantity > 0 ";
            sql_articulos = sql_articulos + " and a.sysnumber = " + sysnum; 
            sql_articulos = sql_articulos + " and a.itemcode = '" + codart + "' ";

            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);

            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };

            if (daArticulos.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                txtDescripcion.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                txtLote.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                SendKeys.Send("{Tab}");
            }
            else
            {
                txtArticulo.Text = "";
                txtArticulo.Focus();
                return;
            };
        }
        private void limpiar_form()
        {
            dtpFecha.Value = DateTime.Now;
            cbOrigen.SelectedIndex = 0;
            cbDestino.SelectedIndex = -1;
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
            txtLote.Text = "";
            //cbPotreros.Focus();
            txtArticulo.Focus();
        }
        //################################################################################################
        //Abrir una sola instancia del formulario
        //################################################################################################
        private static frmTransferencias frmDefInstance;
        public static frmTransferencias DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmTransferencias();
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
            if (txtCantidad.Text == "" || int.Parse(txtCantidad.Text) == 0)
            {
                MessageBox.Show("Debe introducir cantidad valida");
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
                NewRow["bincode"] = "";// cbPotreros.SelectedValue;
                NewRow["lote"] = txtLote.Text;// ds.Tables["articulos"].Rows[0]["lote"].ToString();
                ds.Tables["grilla"].Rows.Add(NewRow);

                limpiar_detalle();
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvTransferencias.Rows.Count > 0 )
            {
                if (dgvTransferencias.CurrentCell.RowIndex != -1)
                {
                    ds.Tables["grilla"].Rows[dgvTransferencias.CurrentCell.RowIndex].Delete();
                };
                ds.AcceptChanges();
            };            
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

                if (cbRetirado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar encargado de transferencia");
                    cbRetirado.Focus();
                    return;
                }
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
                        Transferencia.FromWarehouse = cbOrigen.SelectedValue.ToString();
                        Transferencia.ToWarehouse = cbDestino.SelectedValue.ToString();
                        Transferencia.SalesPersonCode = int.Parse(cbRetirado.SelectedValue.ToString());
                        Transferencia.Comments = txtObservacion.Text;

                        int i = 0;
                        string art = "";
                        string arti = "";
                        double cant = 0;
                        foreach (DataRow dr in ds.Tables["grilla"].Rows)
                        {
                            art = dr["itemcode"].ToString();
                            if (!arti.Contains(art))
                            {
                                Transferencia.Lines.SetCurrentLine(i);
                                Transferencia.Lines.ItemCode = dr["itemcode"].ToString();
                                Transferencia.Lines.ItemDescription = dr["itemname"].ToString();
                                Transferencia.Lines.WarehouseCode = cbDestino.SelectedValue.ToString();

                                cant = 0;
                                foreach (DataRow drS in ds.Tables["grilla"].Select("itemcode = '" + art + "'"))
                                {
                                    cant = cant + double.Parse(drS["quantity"].ToString());
                                };
                                Transferencia.Lines.Quantity = cant; //double.Parse(dr["quantity"].ToString());
                                                               
                                foreach (DataRow drA in ds.Tables["grilla"].Select("itemcode = '"+ art + "'"))
                                {
                                    //Transferencia.Lines.SetCurrentLine(n);
                                    Transferencia.Lines.BatchNumbers.Quantity = int.Parse(drA["quantity"].ToString());
                                    Transferencia.Lines.BatchNumbers.BatchNumber = drA["lote"].ToString();
                                    Transferencia.Lines.BatchNumbers.Add();                                   
                                };

                                Transferencia.Lines.Add();
                                arti = arti + art;
                                i = i + 1;                                
                            }                    
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

                        actualizar_lotes_maples();

                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                        //imprimir_ticket();
                        MessageBox.Show("Operación finalizada con éxito");
                        limpiar_form();
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
                Cursor.Current = Cursors.Default;
            };
        }

        private void actualizar_lotes_maples()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("pa_alta_lotes_maples");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter cod_articulo = new SqlParameter("@cod_articulo", SqlDbType.VarChar, 30);
                cod_articulo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_articulo);
                SqlParameter clasificadora = new SqlParameter("@clasificadora", SqlDbType.VarChar, 5);
                clasificadora.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(clasificadora);
                SqlParameter cod_lote = new SqlParameter("@cod_lote", SqlDbType.VarChar, 10);
                cod_lote.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_lote);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter cant = new SqlParameter("@cantidad", SqlDbType.Decimal, 10);
                cant.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cant);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                string sql_transf;
                SqlDataAdapter daTransf;

                sql_transf = "select a.docdate as fecha, b.ItemCode as codarticulo,";
                sql_transf = sql_transf + " convert(int, e.quantity) as cantidad, ";
                sql_transf = sql_transf + " b.WhsCode as clasificadora, f.distnumber as lote ";
                sql_transf = sql_transf + " from owtr a with (nolock) ";
                sql_transf = sql_transf + " inner join wtr1 b with (nolock) on a.DocEntry = b.DocEntry ";
                sql_transf = sql_transf + " inner join oitl d with (nolock) on a.docnum = d.docentry and b.itemcode = d.itemcode and d.doctype = 67 ";
                sql_transf = sql_transf + " inner join itl1 e with (nolock) on d.logentry = e.logentry and d.itemcode = e.itemcode ";
                sql_transf = sql_transf + " inner join obtn f with (nolock) on e.itemcode = f.itemcode and e.sysnumber = f.sysnumber ";
                sql_transf = sql_transf + " where a.docentry = " + docentry;
                sql_transf = sql_transf + " group by a.docdate, b.ItemCode, convert(int, e.quantity), b.WhsCode, f.distnumber ";
                sql_transf = sql_transf + " having sum(e.quantity) > 0 ";

                daTransf = new SqlDataAdapter(sql_transf, Global.conn);

                if (ds.Tables.Contains("transf"))
                {
                    ds.Tables["transf"].Clear();
                };

                conn.Open();

                if (daTransf.Fill(ds, "transf") > 0 )
                {
                    foreach(DataRow dr in ds.Tables["transf"].Rows)
                    {
                        cod_articulo.Value = dr["codarticulo"].ToString();
                        clasificadora.Value = dr["clasificadora"].ToString();
                        cod_lote.Value = dr["lote"].ToString();
                        cant.Value = dr["cantidad"].ToString();
                        fecha.Value = dr["fecha"].ToString();
                        mensaje.Value = "";

                        
                        cmd.ExecuteNonQuery();
                        

                        if (int.Parse(RetValue.Value.ToString()) != 0)
                        {
                            MessageBox.Show(mensaje.Value.ToString());
                        };
                    }
                }

                conn.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
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
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmBArticulos frm = new frmBArticulos();
                /*frm.sql = "select a.itemcode, b.itemname, convert(numeric(15,2), a.onhand) as quantity, ";
                frm.sql = frm.sql + " '' as sysnumber, '' as distnumber ";
                frm.sql = frm.sql + " from oitw a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode";
                //frm.sql = frm.sql + " where a.onhand > 0 and b.itmsgrpcod not between 101 and 119 ";
                frm.sql = frm.sql + " where a.onhand > 0 ";
                //and b.itmsgrpcod in (128, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147) ";*/
                frm.sql = "select a.itemcode, b.itemname, convert(numeric(15,2), a.quantity) as quantity, ";
                frm.sql = frm.sql + " a.sysnumber, c.distnumber ";
                frm.sql = frm.sql + " from obtq a with (nolock) ";
                frm.sql = frm.sql + " inner join oitm b with (nolock) on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " inner join obtn c on a.itemcode = c.itemcode and a.sysnumber = c.sysnumber ";
                //frm.sql = frm.sql + " where a.whscode = " + cbOrigen.SelectedValue;
                frm.sql = frm.sql + " and a.quantity > 0 and b.itemcode like '%cart-0002%' ";

                if (Global.deposito == "FC")
                {
                    frm.sql = frm.sql + " and a.whscode = 'FC'";
                }
                else
                {
                    frm.sql = frm.sql + " and a.whscode = '01'";
                };

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    codart = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    sysnum = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    b_articulo();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                codart = txtArticulo.Text;
                b_articulo();
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
                //llenar_potreros();
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
        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ('.')))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
