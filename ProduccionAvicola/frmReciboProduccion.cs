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
namespace ProduccionAvicola
{
    public partial class frmReciboProduccion : Form
    {
        Company empresa = new Company();
        ProductionOrders OrdenProduccion;
        Documents ReciboProduccion;
        Documents EmisionProduccion;

        //Reportes
        ReportManX rep = new ReportManX();

        SqlDataAdapter daOrdenProduccion;
        SqlDataAdapter daLotes;
        SqlDataAdapter daOrdenes;
        SqlDataAdapter daUbicacion;
        SqlDataAdapter daVerificacionLote;

        string sql_verificacion_lote;
        string sql_ordenes;
        string sql_lotes;
        string sql_orden_produccion;
        string sql_ubicacion;

        string ubic;
        int absentry;
        string art_loteado;
        string verif_lote;

        double cant_orden;
        double cant_asignada;
        double cant_disponible;

        public int doc_entry;
        int docentry;
        public frmReciboProduccion()
        {
            InitializeComponent();
        }
        private void consulta_oprod()
        {
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
            sql_orden_produccion = sql_orden_produccion + "where a.docnum = " + txtNroOrden.Text;

            daOrdenProduccion = new SqlDataAdapter(sql_orden_produccion, Global.conn);

            if (ds.Tables.Contains("ordenes"))
            {
                ds.Tables["ordenes"].Clear();
            };

            if (daOrdenProduccion.Fill(ds, "ordenes") > 0)
            {
                txtNroOrden.Text = ds.Tables["ordenes"].Rows[0]["docnum"].ToString();
                txtArticulo.Text = ds.Tables["ordenes"].Rows[0]["itemcode"].ToString();
                lblArticulo.Text = ds.Tables["ordenes"].Rows[0]["itemname"].ToString();
                lblDeposito.Text = ds.Tables["ordenes"].Rows[0]["whsname"].ToString();
                txtPlanificado.Text = ds.Tables["ordenes"].Rows[0]["plannedqty"].ToString();
                txtRecibido.Text = ds.Tables["ordenes"].Rows[0]["cmpltqty"].ToString();
                txtPendiente.Text = ds.Tables["ordenes"].Rows[0]["pendiente"].ToString();
                if (int.Parse(txtPendiente.Text) == 0)
                {
                    txtCantidadRecepcion.Enabled = false;
                    MessageBox.Show("Orden de Producción ha sido completada");
                    return;
                }
                else
                {
                    txtCantidadRecepcion.Enabled = true;
                    txtCantidadRecepcion.Focus();
                }
            };
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void txtNroOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //Llamar formulario de busqueda
            }
            else if (e.KeyCode == Keys.Enter)
            {
                consulta_oprod();
            }
        }
        private void frmReciboProduccion_Load(object sender, EventArgs e)
        {
            if (doc_entry != 0)
            {
                txtNroOrden.Text = doc_entry.ToString();
                consulta_oprod();
            }
        }
        private void txtCantidadRecepcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.Parse(txtCantidadRecepcion.Text) > int.Parse(txtPendiente.Text))
                {
                    MessageBox.Show("Cantidad a recibir mayor a cantidad Pendiente");
                    txtCantidadRecepcion.Text = "";
                    txtCantidadRecepcion.Focus();
                    return;
                };
                //else
                //{
                //    txtCantidadEmision.Text = (int.Parse(txtCantidadRecepcion.Text) * double.Parse(ds.Tables["ordenes"].Rows[0]["mat_cant_base"].ToString())).ToString();
                //    lblArticuloLista.Text = ds.Tables["ordenes"].Rows[0]["art_lista"].ToString() + '-' + ds.Tables["ordenes"].Rows[0]["art_lista_desc"].ToString();
                //}
            }
        }       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (dtpFecha.Value > DateTime.Now)
                {
                    MessageBox.Show("La fecha de Recepción no puede ser posterior a la fecha actual", "Recibo de Producción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dtpFecha.Focus();
                    return;
                };

                if (txtCantidadRecepcion.Text == "" || txtCantidadRecepcion.Text == "0")
                { 
                    MessageBox.Show("Favor cargar primeramente Cantidad a Recibir", "Recibo de Producción", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCantidadRecepcion.Text = "";
                    txtCantidadRecepcion.Focus();
                    return;
                };

                if (double.Parse(txtCantidadRecepcion.Text) > double.Parse(txtPendiente.Text))
                {
                    MessageBox.Show("Cantidad a Recibir supera la cantidad pendiente de recepción. Seleccione una cantidad que no supere " + txtPendiente.Text + " unidades.", "Recibo de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCantidadRecepcion.Focus();
                    return;
                };


                //if (double.Parse(txtCantSeleccionada.Text) > double.Parse(txtCantidadEmision.Text))
                //{
                //    MessageBox.Show("Cantidad seleccionada supera la cantidad necesaria. Ingrese una cantidad que no supere la cantidad necesaria", "Recibo de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //};

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
                        Cursor.Current = Cursors.WaitCursor;
                        empresa.StartTransaction();

                        ReciboProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                        ReciboProduccion.DocDate = dtpFecha.Value;      // fecha //
                        ReciboProduccion.DocDueDate = dtpFecha.Value;   // fecha //
                        ReciboProduccion.Lines.BaseType = 0;
                        ReciboProduccion.Lines.BaseEntry = int.Parse(txtNroOrden.Text);
                        ReciboProduccion.Lines.TransactionType = BoTransactionTypeEnum.botrntComplete;
                        ReciboProduccion.Lines.Quantity = int.Parse(txtCantidadRecepcion.Text);
                        ReciboProduccion.Lines.WarehouseCode = ds.Tables["ordenes"].Rows[0]["warehouse"].ToString();

                        if (ReciboProduccion.Add() != 0)
                        {
                            MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        docentry = int.Parse(empresa.GetNewObjectKey());

                        EmisionProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);

                        EmisionProduccion.DocDate = dtpFecha.Value;

                        foreach (DataRow drM in ds.Tables["ordenes"].Rows)
                        {
                            EmisionProduccion.Lines.BaseEntry = int.Parse(txtNroOrden.Text);
                            EmisionProduccion.Lines.BaseLine = int.Parse(drM["linenum"].ToString());
                            EmisionProduccion.Lines.BaseType = 0;
                            EmisionProduccion.Lines.WarehouseCode = drM["dep_orig"].ToString();//ds.Tables["ordenes"].Rows[0]["dep_orig"].ToString();
                            EmisionProduccion.Lines.Quantity = double.Parse(txtCantidadRecepcion.Text) * double.Parse(drM["mat_cant_base"].ToString());
                                                        
                            EmisionProduccion.Lines.Add();
                        }

                        if (EmisionProduccion.Add() != 0)
                        {
                            MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };

                        //--##################################################################################--
                        //--Consulta de cantidad pendiente de Orden de Producción
                        //--##################################################################################--

                        sql_ordenes = "select convert(numeric, a.PlannedQty) as plannedqty, ";
                        sql_ordenes = sql_ordenes + "convert(numeric, a.CmpltQty) as cmpltqty, ";
                        sql_ordenes = sql_ordenes + "convert(numeric, (a.PlannedQty-a.CmpltQty)) as pendiente ";
                        sql_ordenes = sql_ordenes + "from OWOR a with (nolock) ";
                        sql_ordenes = sql_ordenes + "where a.docnum = " + txtNroOrden.Text;
                        daOrdenes = new SqlDataAdapter(sql_ordenes, Global.conn);
                        if (ds.Tables.Contains("ord"))
                        {
                            ds.Tables["ord"].Clear();
                        };
                        daOrdenes.Fill(ds, "ord");

                        if (int.Parse(ds.Tables["ord"].Rows[0]["pendiente"].ToString()) == 0)
                        {
                            //--##################################################################################--
                            //--Actualizamos la orden de produccion colocando el estado Cerrado
                            //--##################################################################################--

                            OrdenProduccion = empresa.GetBusinessObject(BoObjectTypes.oProductionOrders);
                            OrdenProduccion.GetByKey(int.Parse(txtNroOrden.Text));
                            OrdenProduccion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposClosed;
                            if (OrdenProduccion.Update() != 0)
                            {
                                MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };
                        };                                             
                        
                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);

                        //MessageBox.Show("Proceso finalizado");
                        if (MessageBox.Show("Operación finalizada con éxito. Desea Imprimir el Recibo de Producción?", "Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            empresa.language = BoSuppLangs.ln_Spanish;
            empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
            empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void txtCantidadRecepcion_Leave(object sender, EventArgs e)
        {
            if (txtCantidadRecepcion.Text != "")
            {
                //txtCantidadEmision.Text = (int.Parse(txtCantidadRecepcion.Text) * double.Parse(ds.Tables["ordenes"].Rows[0]["mat_cant_base"].ToString())).ToString();
                //lblArticuloLista.Text = ds.Tables["ordenes"].Rows[0]["art_lista"].ToString() + '-' + ds.Tables["ordenes"].Rows[0]["art_lista_desc"].ToString();
            }
            else
            {
                MessageBox.Show("Debe introducir un valor para cantidad recibida");
                return;
            };
        }

        private void txtCantidadRecepcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ('.')))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
