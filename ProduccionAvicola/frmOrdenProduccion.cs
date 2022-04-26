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
using reportman;
using System.Globalization;

namespace ProduccionAvicola
{
    public partial class frmOrdenProduccion : Form
    {
        Company empresa = new Company();
        ProductionOrders ordenfabricacion;
        Documents EmisionProduccion;
        Documents ReciboProduccion;

        //Reportes
        ReportManX rep = new ReportManX();

        JulianCalendar jCalend = new JulianCalendar();

        string sql_depositos;
        string sql_componentes;
        string sql_articulos;
        string sql_orden_produccion;
        string sql_lotes;
        
        SqlDataAdapter daOrdenProduccion;
        SqlDataAdapter daDepositos;
        SqlDataAdapter daComponentes;
        SqlDataAdapter daArticulos;
        SqlDataAdapter daLotes;

        int docentry;
        string turnos;
        public frmOrdenProduccion()
        {
            InitializeComponent();
        }       
        
        private void buscar_articulos()
        {
            sql_articulos = "select a.itemcode, a.itemname ";
            sql_articulos = sql_articulos + "from oitm a ";
            sql_articulos = sql_articulos + "where a.itemcode = '" + txtArticulo.Text + "' ";
            if (Global.deposito == "FC")
            {
                sql_articulos = sql_articulos + " and a.itmsgrpcod = 107 and a.itemcode like 'cart-0002%' ";
            }
            else if (Global.deposito == "SIL")
            {
                sql_articulos = sql_articulos + " and a.itmsgrpcod = 106 and a.itemcode like 'B%' ";
            }

            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArticulos.Fill(ds, "articulos") > 0)
            {
                txtArticulo.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                if (txtArticulo.Text != "")
                {
                    SendKeys.Send("{Tab}");
                }
            }
            else
            {
                MessageBox.Show("Articulo Inexistente");
                txtArticulo.Text = "";
                lblArticulo.Text = "";
                txtArticulo.Focus();
            };
        }
        private void imprimir_ticket()
        {
            rep = new ReportManX();
            rep.filename = Application.StartupPath + "\\reportes\\OrdenProduccion.rep";
            rep.SetParamValue("DOCKEY", docentry);
            rep.SetDatabaseConnectionString("CONN", Global.str_conn_REP);

            rep.Title = "Orden de Producción";
            rep.Preview = false;
            rep.Language = 1;
            rep.ShowPrintDialog = false;     
                  
            rep.Execute();
        }
        private void depositos()
        {
            if (Global.deposito == "SIL")
            {
                sql_depositos = "select whscode, whsname from owhs where whscode = 'SIL'";
            }
            else if (Global.deposito =="FC")
            {
                sql_depositos = "select whscode, whsname from owhs where whscode = 'FC'";
            }
            if (ds.Tables.Contains("deposito"))
            {
                ds.Tables["deposito"].Rows.Clear();
            };
            daDepositos = new SqlDataAdapter(sql_depositos, Global.conn);
            daDepositos.Fill(ds, "deposito");
            cmbDeposito.DataSource = ds.Tables["deposito"];
            cmbDeposito.DisplayMember = "whsname";
            cmbDeposito.ValueMember = "whscode";
            cmbDeposito.SelectedIndex = 0;
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
            //empresa.DbUserName = Global.Decrypt(Properties.Settings.Default.sap_dbusername);
            //empresa.DbPassword = Global.Decrypt(Properties.Settings.Default.sap_dbpassword);
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void frmOrdenProduccion_Load(object sender, EventArgs e)
        {
            if (Global.deposito == "SIL")
            {

            }
            depositos();
            dgvLotes.AllowUserToAddRows = false;         
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;            

                //Validaciones
                if (txtArticulo.Text =="")
                {
                    MessageBox.Show("Debe introducir código de articulo a producir", "Orden de Produccion", MessageBoxButtons.OK);
                    txtArticulo.Focus();
                    return;
                };
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debe introducir cantidad a producir", "Orden de Produccion", MessageBoxButtons.OK);
                    txtCantidad.Focus();
                    return;
                };
                if (cmbDeposito.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar almacen destino", "Orden de Produccion", MessageBoxButtons.OK);
                    cmbDeposito.Focus();
                    return;
                };
                //if(cbSilo.SelectedIndex == -1)
                //{
                //    MessageBox.Show("Debe seleccionar linea de producción", "Orden de Produccion", MessageBoxButtons.OK);
                //    cbSilo.Focus();
                //    return;
                //}

                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription() + ", Código de error: " + empresa.GetLastErrorCode().ToString());
                        return;
                    }
                    else
                    {
                        empresa.StartTransaction();

                        sql_componentes = "select itt1.code, itt1.quantity, itt1.warehouse, itt1.father ";
                        sql_componentes = sql_componentes + " from oitm ";
                        sql_componentes = sql_componentes + " inner join itt1 on oitm.itemcode = itt1.father ";
                        sql_componentes = sql_componentes + " where oitm.itemcode = '" + txtArticulo.Text + "'";

                        if (ds.Tables.Contains("componentes"))
                        {
                            ds.Tables["componentes"].Rows.Clear();
                        };
                        daComponentes = new SqlDataAdapter(sql_componentes, Global.conn);
                        daComponentes.Fill(ds, "componentes");

                        ordenfabricacion = empresa.GetBusinessObject(BoObjectTypes.oProductionOrders);

                        if (txtArticulo.Text == "CART-00025")
                        {
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned;
                            ordenfabricacion.ProductionOrderType = BoProductionOrderTypeEnum.bopotSpecial;
                            ordenfabricacion.PlannedQuantity = double.Parse(txtCantidad.Text);
                            ordenfabricacion.PostingDate = dtpFecha.Value;//DateTime.Now;
                            ordenfabricacion.DueDate = dtpFecha.Value;//DateTime.Now;
                            ordenfabricacion.Warehouse = Global.deposito;
                            ordenfabricacion.ItemNo = txtArticulo.Text;
                            ordenfabricacion.UserFields.Fields.Item("U_maqlinea").Value = cbSiloMaq.Text;

                            ordenfabricacion.Lines.ItemNo = "CART-00024";
                            ordenfabricacion.Lines.BaseQuantity = 0.5;
                            ordenfabricacion.Lines.PlannedQuantity = double.Parse(txtCantidad.Text) * 0.5;
                            ordenfabricacion.Lines.Warehouse = Global.deposito;
                            ordenfabricacion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;

                            if (ordenfabricacion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            //Liberar orden de fabricación
                            docentry = int.Parse(empresa.GetNewObjectKey());

                            ordenfabricacion.GetByKey(docentry);
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposReleased;
                            if (ordenfabricacion.Update() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            EmisionProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                            EmisionProduccion.DocDate = dtpFecha.Value;

                            EmisionProduccion.Lines.BaseEntry = docentry;
                            EmisionProduccion.Lines.BaseLine = 0;
                            EmisionProduccion.Lines.BaseType = 0;
                            EmisionProduccion.Lines.WarehouseCode = Global.deposito;
                            EmisionProduccion.Lines.Quantity = double.Parse(txtCantidad.Text) * 0.5;


                            foreach (DataGridViewRow drL in dgvLotes.Rows)
                            {
                                bool ischecked = (bool)drL.Cells[4].EditedFormattedValue;

                                if(ischecked)
                                {
                                    EmisionProduccion.Lines.BatchNumbers.BatchNumber = drL.Cells[1].Value.ToString();
                                    EmisionProduccion.Lines.BatchNumbers.Quantity = double.Parse(drL.Cells[3].Value.ToString());
                                    EmisionProduccion.Lines.BatchNumbers.Add();
                                };                                
                            };

                            EmisionProduccion.Lines.Add();                             

                            if (EmisionProduccion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            ReciboProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                            ReciboProduccion.DocDate = dtpFecha.Value;      // fecha //
                            ReciboProduccion.DocDueDate = dtpFecha.Value;   // fecha //
                            ReciboProduccion.Lines.BaseType = 0;
                            ReciboProduccion.Lines.BaseEntry = docentry;
                            ReciboProduccion.Lines.TransactionType = BoTransactionTypeEnum.botrntComplete;
                            ReciboProduccion.Lines.Quantity = int.Parse(txtCantidad.Text);
                            ReciboProduccion.Lines.WarehouseCode = Global.deposito;

                            ReciboProduccion.Lines.BatchNumbers.Quantity = double.Parse(txtCantidad.Text);
                            ReciboProduccion.Lines.BatchNumbers.BatchNumber = turnos + cbSiloMaq.Text + dtpFecha.Value.DayOfYear.ToString();
                            ReciboProduccion.Lines.BatchNumbers.ManufacturerSerialNumber = turnos + cbSiloMaq.Text + dtpFecha.Value.DayOfYear.ToString();
                            ReciboProduccion.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;

                            //ReciboProduccion.Lines.BatchNumbers.
                            ReciboProduccion.Lines.BatchNumbers.Add();

                            if (ReciboProduccion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            //--##################################################################################--
                            //--Actualizamos la orden de produccion colocando el estado Cerrado
                            //--##################################################################################--

                            ordenfabricacion.GetByKey(docentry);
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposClosed;
                            if (ordenfabricacion.Update() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            empresa.EndTransaction(BoWfTransOpt.wf_Commit);

                            //MessageBox.Show("Proceso finalizado");
                            if (MessageBox.Show("Operación finalizada con éxito. Desea Imprimir la Orden de Producción?", "Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                //imprimir_ticket();
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                            else
                            {
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            };
                            //this.Close();
                            //imprimir_ticket();
                        }
                        else
                        {
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned;
                            ordenfabricacion.ProductionOrderType = BoProductionOrderTypeEnum.bopotStandard;
                            ordenfabricacion.ItemNo = txtArticulo.Text;
                            ordenfabricacion.PlannedQuantity = double.Parse(txtCantidad.Text);
                            ordenfabricacion.PostingDate = dtpFecha.Value; //fecha
                            ordenfabricacion.DueDate = dtpFecha.Value;     //fecha
                            ordenfabricacion.Warehouse = cmbDeposito.SelectedValue.ToString();
                            ordenfabricacion.UserFields.Fields.Item("U_maqlinea").Value = cbSiloMaq.Text;
                            //ordenfabricacion.UserFields.Fields.Item("U_MAQUINA").Value = cbSilo.Text;

                            foreach (DataRow drLineas in ds.Tables["componentes"].Rows)
                            {
                                ordenfabricacion.Lines.ItemNo = drLineas["code"].ToString();
                                ordenfabricacion.Lines.BaseQuantity = double.Parse(drLineas["quantity"].ToString());
                                ordenfabricacion.Lines.PlannedQuantity = double.Parse(txtCantidad.Text) * double.Parse(drLineas["quantity"].ToString());
                                ordenfabricacion.Lines.Warehouse = drLineas["warehouse"].ToString();
                                ordenfabricacion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;
                                ordenfabricacion.Lines.Add();
                            }

                            if (ordenfabricacion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            //Liberar orden de fabricación
                            docentry = int.Parse(empresa.GetNewObjectKey());

                            ordenfabricacion.GetByKey(docentry);
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposReleased;
                            if (ordenfabricacion.Update() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            //--##################################################################################--
                            //--Crear emision para produccion
                            //--##################################################################################--

                            sql_orden_produccion = "select a.DocNum, a.ItemCode, c.ItemName, a.Warehouse, e.WhsName, ";
                            sql_orden_produccion = sql_orden_produccion + " b.linenum, d.manbtchnum, ";
                            sql_orden_produccion = sql_orden_produccion + "convert(numeric, a.PlannedQty) as plannedqty, ";
                            sql_orden_produccion = sql_orden_produccion + "convert(numeric, a.CmpltQty) as cmpltqty, ";
                            sql_orden_produccion = sql_orden_produccion + "convert(numeric, (a.PlannedQty-a.CmpltQty)) as pendiente, ";
                            sql_orden_produccion = sql_orden_produccion + "b.ItemCode as art_lista, d.ItemName as art_lista_desc, convert(numeric(15,3), b.PlannedQty) as mat_plan, ";
                            sql_orden_produccion = sql_orden_produccion + "convert(numeric(15,3), b.IssuedQty) as mat_comp, ";
                            sql_orden_produccion = sql_orden_produccion + "convert(numeric(15,3), b.baseqty) as mat_cant_base, ";
                            sql_orden_produccion = sql_orden_produccion + "b.warehouse as dep_orig, a.u_maquina ";
                            sql_orden_produccion = sql_orden_produccion + "from OWOR a with (nolock) ";
                            sql_orden_produccion = sql_orden_produccion + "inner join WOR1 b with (nolock) on a.docentry = b.docentry ";
                            sql_orden_produccion = sql_orden_produccion + "inner join OITM c with (nolock) on a.itemcode = c.itemcode ";
                            sql_orden_produccion = sql_orden_produccion + "inner join OITM d with (nolock) on b.itemcode = d.itemcode and b.issuetype = 'M' ";
                            sql_orden_produccion = sql_orden_produccion + "inner join OWHS e with (nolock) on a.Warehouse = e.whscode ";
                            sql_orden_produccion = sql_orden_produccion + "where a.docentry = " + docentry;

                            daOrdenProduccion = new SqlDataAdapter(sql_orden_produccion, Global.conn);

                            if (ds.Tables.Contains("ordenes"))
                            {
                                ds.Tables["ordenes"].Clear();
                            };

                            if (daOrdenProduccion.Fill(ds, "ordenes") > 0)
                            {

                            };

                            EmisionProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                            EmisionProduccion.DocDate = dtpFecha.Value;

                            foreach (DataRow drM in ds.Tables["ordenes"].Rows)
                            {
                                EmisionProduccion.Lines.BaseEntry = docentry;
                                EmisionProduccion.Lines.BaseLine = int.Parse(drM["linenum"].ToString());
                                EmisionProduccion.Lines.BaseType = 0;
                                EmisionProduccion.Lines.WarehouseCode = drM["dep_orig"].ToString();//ds.Tables["ordenes"].Rows[0]["dep_orig"].ToString();
                                EmisionProduccion.Lines.Quantity = double.Parse(txtCantidad.Text) * double.Parse(drM["mat_cant_base"].ToString());

                                EmisionProduccion.Lines.Add();
                            }

                            if (EmisionProduccion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            ReciboProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                            ReciboProduccion.DocDate = dtpFecha.Value;      // fecha //
                            ReciboProduccion.DocDueDate = dtpFecha.Value;   // fecha //
                            ReciboProduccion.Lines.BaseType = 0;
                            ReciboProduccion.Lines.BaseEntry = docentry;
                            ReciboProduccion.Lines.TransactionType = BoTransactionTypeEnum.botrntComplete;
                            ReciboProduccion.Lines.Quantity = int.Parse(txtCantidad.Text);
                            ReciboProduccion.Lines.WarehouseCode = Global.deposito;

                            ReciboProduccion.Lines.BatchNumbers.Quantity = double.Parse(txtCantidad.Text);
                            ReciboProduccion.Lines.BatchNumbers.BatchNumber = turnos + cbSiloMaq.Text + dtpFecha.Value.DayOfYear.ToString("D3");
                            ReciboProduccion.Lines.BatchNumbers.ManufacturerSerialNumber = turnos + cbSiloMaq.Text + dtpFecha.Value.DayOfYear.ToString("D3");
                            ReciboProduccion.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;

                            //ReciboProduccion.Lines.BatchNumbers.
                            ReciboProduccion.Lines.BatchNumbers.Add();

                            if (ReciboProduccion.Add() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            //--##################################################################################--
                            //--Actualizamos la orden de produccion colocando el estado Cerrado
                            //--##################################################################################--

                            ordenfabricacion.GetByKey(docentry);
                            ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposClosed;
                            if (ordenfabricacion.Update() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };

                            empresa.EndTransaction(BoWfTransOpt.wf_Commit);

                            //MessageBox.Show("Proceso finalizado");
                            if (MessageBox.Show("Operación finalizada con éxito. Desea Imprimir la Orden de Producción?", "Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                //imprimir_ticket();
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                            else
                            {
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            };
                            //this.Close();
                            //imprimir_ticket();
                        };
                        
                    }
                }
            }
            catch (Exception ex)
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
                this.Close();
            }
        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //Llamar formulario de busqueda
                frmBArticulos frm = new frmBArticulos();
                frm.sql = "select a.itemcode, a.itemname, convert(numeric(12,2), b.onhand) as quantity, ";
                frm.sql = frm.sql + " '' as sysnumber, substring(a.codebars, 13, 3) as distnumber ";
                frm.sql = frm.sql + " from oitm a with (nolock) inner join oitw b with (nolock) on a.itemcode = b.itemcode ";
                if (Global.deposito == "SIL")
                {
                    frm.sql = frm.sql + " where a.itmsgrpcod in (106, 153) and b.whscode = 'SIL'";
                    frm.sql = frm.sql + " and a.itemname like 'B%' ";
                }
                else if (Global.deposito == "FC")
                {
                    frm.sql = frm.sql + " where a.itmsgrpcod = 107 and b.whscode = 'FC' and a.itemcode like 'cart-0002%' ";
                    frm.sql = frm.sql + " and a.itemname like 'CART%' ";
                }
                
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArticulo.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    buscar_articulos();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buscar_articulos();
            }
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
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
                if (txtArticulo.Text == "146" && int.Parse(txtCantidad.Text) % 180 > 0 )
                {
                    MessageBox.Show("Cantidad a producir debe ser multiplo de 180");
                    return;
                }
                else
                {
                    SendKeys.Send("{Tab}");
                };                
            }
        }
        private void cmbDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cbMaquinas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ('.')))
            {                
                e.Handled = true;
                return;
            }
        }
        private void cbTurnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbTurnos.Text == "Mañana")
                {
                    turnos = "1";
                }
                else if (cbTurnos.Text == "Tarde")
                {
                    turnos = "2";
                }
                else
                {
                    turnos = "3";
                };
                SendKeys.Send("{Tab}");
            }
        }
        private void cbTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTurnos.Text == "Mañana")
            {
                turnos = "1";
            }
            else if (cbTurnos.Text == "Tarde")
            {
                turnos = "2";
            }
            else
            {
                turnos = "3";
            };
        }
        private void llenar_grilla()
        {
            sql_lotes = "select b.sysnumber, b.distnumber, ";
            sql_lotes = sql_lotes + " convert(numeric(14,2), a.quantity) as quantity ";
            sql_lotes = sql_lotes + " from obtq a with (nolock) ";
            sql_lotes = sql_lotes + " inner join obtn b with (nolock) on a.itemcode = b.itemcode and a.sysnumber = b.sysnumber ";
            sql_lotes = sql_lotes + " inner join oitm c with (nolock) on a.itemcode = c.itemcode ";
            sql_lotes = sql_lotes + " where a.whscode = 'FC' ";
            sql_lotes = sql_lotes + " and b.itemcode = 'CART-00024' and a.quantity > 0 ";

            daLotes = new SqlDataAdapter(sql_lotes, Global.conn);

            if (ds.Tables.Contains("dtLotes"))
            {
                ds.Tables["dtLotes"].Clear();
            };

            if (daLotes.Fill(ds, "dtLotes") > 0)
            {
                dgvLotes.Visible = true;
                dgvLotes.DataSource = ds.Tables["dtLotes"];
            };
            
        }
        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            if (txtArticulo.Text == "CART-00025")
            {
                llenar_grilla();
            }
            else
            {
                dgvLotes.Visible = false;
            }
        }
        private void CalcularSeleccionados()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                double total = 0;
                //foreach (DataRow dr in ds.Tables["huevos"].Rows)
                foreach (DataGridViewRow row in dgvLotes.Rows)
                {
                    bool ischecked = (bool)row.Cells[4].EditedFormattedValue;

                    if (ischecked)
                    {
                        total = total + double.Parse(row.Cells[3].Value.ToString());
                    };
                };                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            };
        }
        private void dgvLotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvLotes.CurrentCell as DataGridViewCheckBoxCell) != null)
            {
                foreach (DataGridViewRow row in dgvLotes.Rows)
                {
                    bool ischecked = (bool)row.Cells[4].EditedFormattedValue;

                    if (ischecked)
                    {
                        CalcularSeleccionados();
                        //cantidad_acu = cantidad_acu + double.Parse(row.Cells[6].Value.ToString());
                    };
                };
            };           
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            lblDiadelAnho.Text = dtpFecha.Value.DayOfYear.ToString("D3"); 
        }

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            lblDiadelAnho.Text = dtpFecha.Value.DayOfYear.ToString("D3");
        }

        private void cbTurnos_Leave(object sender, EventArgs e)
        {
            lblDiadelAnho.Text = turnos + "-" + dtpFecha.Value.DayOfYear.ToString("D3");
        }

        private void cbSiloMaq_Leave(object sender, EventArgs e)
        {
            lblDiadelAnho.Text = turnos + cbSiloMaq.Text + dtpFecha.Value.DayOfYear.ToString("D3");
        }
    }
}
