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
    public partial class frmEmbarqueHuevos : Form
    {
        Company empresa = new Company();
        Documents Entrega;

        ReportManX rep = new ReportManX();

        SqlDataAdapter daClientes;
        SqlDataAdapter daLotes;
        SqlDataAdapter daPrecios;
        SqlDataAdapter daCamiones;
        SqlDataAdapter daChoferes;
        SqlDataAdapter daDetFactRes;
        SqlDataAdapter daCarritos;
        SqlDataAdapter daCodigoCar;
        SqlDataAdapter daDepositos;
        DataRow NewRow;

        //ReportDocument cryRpt = new ReportDocument();    

        string key_factura;
        string cod_art = "";
        string sql_lotes;
        string sql_clientes;
        string sql_precios;
        string sql_camiones;
        string sql_choferes;
        string sql_det_factres;
        string sql_car;
        string sql_depositos;

        string nrocarrito;

        //Variables de calculos
        int cajon_1 = 0;
        int carrito_2 = 0;
        int cajon_2 = 0;
        int carrito_3 = 0;
        int cajon_3 = 0;
        int carrito_4 = 0;
        int cajon_4 = 0;
        int carrito_5 = 0;
        int cajon_5 = 0;
        int carrito_6 = 0;
        int cajon_6 = 0;
        int carrito_7 = 0;
        int cajon_7 = 0;

        string item = "";

        string DEP;
        string listaPrecio;        

        double pr_art;
        double cant;

        int codigocar;
        int uom_venta;
        int carrito;
        public frmEmbarqueHuevos()
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
        private void lotes()
        {
            sql_lotes = "select itemcode, itemname, sysnumber, batchnum, convert(numeric, quantity) as quantity, ";            
            sql_lotes = sql_lotes + " suppserial, convert(varchar, indate, 103) as indate";
            sql_lotes = sql_lotes + " from OIBT with (nolock) ";
            sql_lotes = sql_lotes + " where Quantity > 0 and suppserial = '" + txtNroCarrito.Text + "' ";
            sql_lotes = sql_lotes + " and indate <= '" + dtpFecha.Value.ToShortDateString() + "' ";
            sql_lotes = sql_lotes + " and whscode = '" + cbDepositos.SelectedValue.ToString() + "' ";
            if (chkFactRes.Checked == true)
            {
                sql_lotes = sql_lotes + " and itemcode in (" + item + ") ";
            }            
            //if (rbCCHA.Checked == true)
            //{
            //    sql_lotes = sql_lotes + " and whscode = 'CCHA' ";
            //}
            //else if (rbCCHB.Checked == true)
            //{
            //    sql_lotes = sql_lotes + " and whscode = 'CCHB' ";
            //}
            //else if (rbOVO.Checked == true)
            //{
            //    sql_lotes = sql_lotes + " and whscode = 'OVO' ";
            //};

            daLotes = new SqlDataAdapter(sql_lotes, Global.conn);
            if (ds.Tables.Contains("lotes"))
            {
                ds.Tables["lotes"].Clear();
            };
            if (daLotes.Fill(ds, "lotes") > 0)
            {
                cod_art = ds.Tables["lotes"].Rows[0]["itemcode"].ToString();
            }
            else
            {
                MessageBox.Show("No existe Carrito");
                return;
            }
        }
        private void fact_det_reserva()
        {
            sql_det_factres = "select b.DocEntry, b.LineNum, b.ItemCode, b.Quantity ";
            sql_det_factres = sql_det_factres + " from oinv a with (nolock) ";
            sql_det_factres = sql_det_factres + " inner join inv1 b with (nolock) on a.docentry = b.docentry ";
            sql_det_factres = sql_det_factres + " where b.invntsttus = 'O' and a.numatcard = '" + txtFactRes.Text + "' ";
            sql_det_factres = sql_det_factres + " and b.whscode = '" + cbDepositos.SelectedValue.ToString() + "'";
            //if (rbCCHA.Checked == true)
            //{
            //    sql_det_factres = sql_det_factres + " and b.whscode = 'CCHA' ";
            //}
            //else if (rbCCHB.Checked == true)
            //{
            //    sql_det_factres = sql_det_factres + " and b.whscode = 'CCHB' ";
            //}
            //else
            //{
            //    sql_det_factres = sql_det_factres + " and b.whscode = 'OVO' ";
            //};

            daDetFactRes = new SqlDataAdapter(sql_det_factres, Global.conn);

            if (ds.Tables.Contains("det_factura"))
            {
                ds.Tables["det_factura"].Clear();
            };

            if (daDetFactRes.Fill(ds, "det_factura") > 0)
            {
                foreach (DataRow drItem in ds.Tables["det_factura"].Rows)
                {
                    if (item == "")
                    {
                        item = drItem["itemcode"].ToString();
                    }
                    else
                    {
                        item = item + ",'" + drItem["itemcode"].ToString() + "'";
                    };                    
                };
                //SendKeys.Send("{Tab}");
                txtNroCarrito.Focus();
            }
            else
            {
                MessageBox.Show("No existe Factura Reserva Nro.: " + txtFactRes.Text + " o ya ha sido cerrada!. Favor verificar.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFactRes.Text = "";
                txtFactRes.Focus();
                return;
            }
        }
        //Llenado de combos
        private void llenar_depositos()
        {
            sql_depositos = "select whscode, whsname from owhs with (nolock) where whscode in ('CCHA', 'CCHB', 'CCHH', 'OVO', 'SALON') order by whsname ";
            daDepositos = new SqlDataAdapter(sql_depositos, Global.conn);

            if (ds.Tables.Contains("deposito"))
            {
                ds.Tables["deposito"].Clear();
            };

            daDepositos.Fill(ds, "deposito");
            cbDepositos.DataSource = ds.Tables["deposito"];
            cbDepositos.DisplayMember = "whsname";
            cbDepositos.ValueMember = "whscode";

            //cbOrigen.SelectedIndex = -1;
        }
        private void camiones()
        {
            sql_camiones = "select code, (code + ' - ' + name ) as name from [@camiones] with (nolock) order by code";
            daCamiones = new SqlDataAdapter(sql_camiones, Global.conn);
            if (ds.Tables.Contains("camiones"))
            {
                ds.Tables["camiones"].Clear();
            };

            if (daCamiones.Fill(ds, "camiones") > 0)
            {
                //daCamiones.Fill(ds, "camiones");
                cbCamiones.DataSource = ds.Tables["camiones"];
                cbCamiones.DisplayMember = "name";
                cbCamiones.ValueMember = "code";
            }
        }
        private void choferes()
        {
            sql_choferes = "select * from [@choferes] with (nolock) order by name";
            daChoferes = new SqlDataAdapter(sql_choferes, Global.conn);
            if (ds.Tables.Contains("choferes"))
            {
                ds.Tables["choferes"].Clear();
            };

            if (daChoferes.Fill(ds, "choferes") > 0)
            {
                //daChoferes.Fill(ds, "choferes");
                cbChoferes.DataSource = ds.Tables["choferes"];
                cbChoferes.DisplayMember = "name";
                cbChoferes.ValueMember = "code";
            }
        }
        private void consulta_precio()
        {
            sql_precios = "select a.itemcode, a.itemname, numinsale, suomentry, ";
            sql_precios = sql_precios + " case when e.price is null then(";
            sql_precios = sql_precios + " case when d.uomentry is null then b.price else convert(numeric, isnull(d.price, 0)) end) ";
            sql_precios = sql_precios + " else e.price end as price, ";
            sql_precios = sql_precios + " taxcodear as impuesto ";
            sql_precios = sql_precios + " from oitm a with (nolock) ";
            sql_precios = sql_precios + " inner join itm1 b with (nolock) on a.itemcode = b.itemcode ";
            sql_precios = sql_precios + " inner join oitw c with (nolock) on a.itemcode = c.itemcode ";
            sql_precios = sql_precios + " left outer join itm9 d with (nolock) on a.itemcode = d.itemcode and d.pricelist = b.pricelist ";
            sql_precios = sql_precios + " left outer join spp1 e with (nolock) on a.itemcode = e.itemcode and e.listnum = b.pricelist ";
            sql_precios = sql_precios + " and getdate() between e.fromdate and e.todate ";
            sql_precios = sql_precios + " where a.itemcode = '" + item + "' ";
            sql_precios = sql_precios + " and b.pricelist = " + listaPrecio;

            daPrecios = new SqlDataAdapter(sql_precios, Global.conn);

            if (ds.Tables.Contains("precios"))
            {
                ds.Tables["precios"].Clear();
            };
            if (daPrecios.Fill(ds, "precios") > 0)
            {
                pr_art = double.Parse(ds.Tables["precios"].Rows[0]["price"].ToString());
                uom_venta = int.Parse(ds.Tables["precios"].Rows[0]["SUoMEntry"].ToString());
            };

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            //Validación de campos obligatorios
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe introducir código de Cliente");
                txtCliente.Focus();
                return;
            };

            if (cbChoferes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe introducir datos de Chofer");
                cbChoferes.Focus();
                return;
            };

            if (cbCamiones.SelectedIndex  == -1)
            {
                MessageBox.Show("Debe introducir datos de Camión");
                cbCamiones.Focus();
                return;
            };

            if (chkFactRes.Checked == true && txtFactRes.Text != "")
            {
                foreach (DataRow drdet in ds.Tables["det_factura"].Rows)
                {
                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode <> '" + drdet["itemcode"].ToString() + "'"))
                    {

                    };
                };
            }


            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

                //fact_det_reserva();

                Entrega = empresa.GetBusinessObject(BoObjectTypes.oDeliveryNotes);

                Entrega.DocDate = dtpFecha.Value;
                Entrega.CardCode = txtCliente.Text;
                Entrega.DocType = BoDocumentTypes.dDocument_Items;
                Entrega.UserFields.Fields.Item("U_Cod_Chofer").Value = cbChoferes.SelectedValue; //ds.Tables["choferes"].Rows[0]["code"].ToString();
                Entrega.UserFields.Fields.Item("U_Cod_Camion").Value = cbCamiones.SelectedValue; //ds.Tables["camiones"].Rows[0]["code"].ToString();

                DEP = cbDepositos.SelectedValue.ToString();

                //if (rbCCHA.Checked == true)
                //{
                //    DEP = "CCHA";
                //}
                //else if (rbCCHB.Checked == true)
                //{
                //    DEP = "CCHB";
                //}
                //else
                //{
                //    DEP = "OVO";
                //};

                if(cajon_1 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "1";
                    item = "1";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '1'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '1'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }

                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '1'"))
                    {                        
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_2 != 0 || cajon_2 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "2";
                    item = "2";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '2'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '2'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }

                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '2'"))
                    {
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_3 != 0 || cajon_3 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "3";
                    item = "3";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '3'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '3'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }
                    
                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '3'"))
                    {                        
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_4 != 0 || cajon_4 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "4";
                    item = "4";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '4'"))
                    {
                        cant  =  cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;
                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '4'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };                        
                    }
                                        
                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '4'"))
                    {                        
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_5 != 0 || cajon_5 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "5";
                    item = "5";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '5'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '5'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }

                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '5'"))
                    {                       
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_6 != 0 || cajon_6 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "6";
                    item = "6";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                   
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '6'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '6'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }

                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '6'"))
                    {
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }
                if (carrito_7 != 0 || cajon_7 != 0)
                {
                    cant = 0;
                    Entrega.Lines.ItemCode = "7";
                    item = "7";
                    consulta_precio();
                    Entrega.Lines.WarehouseCode = DEP;
                    foreach (DataRow drA in ds.Tables["carritos"].Select("itemcode = '7'"))
                    {
                        cant = cant + double.Parse(drA["quantity"].ToString());
                    }
                    Entrega.Lines.UoMEntry = uom_venta;
                    Entrega.Lines.Quantity = (cant / 12);
                    Entrega.Lines.PriceAfterVAT = pr_art;

                    if (chkFactRes.Checked == true && txtFactRes.Text != "")
                    {
                        foreach (DataRow drdet in ds.Tables["det_factura"].Select("itemcode = '7'"))
                        {
                            Entrega.Lines.BaseType = 13;
                            Entrega.Lines.BaseLine = int.Parse(drdet["linenum"].ToString());
                            Entrega.Lines.BaseEntry = int.Parse(drdet["docentry"].ToString());
                        };
                    }

                    foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '7'"))
                    {                        
                        Entrega.Lines.BatchNumbers.Quantity = double.Parse(dr["quantity"].ToString());
                        Entrega.Lines.BatchNumbers.BatchNumber = dr["batchnum"].ToString();
                        Entrega.Lines.BatchNumbers.Add();
                    };
                    Entrega.Lines.Add();
                }                

                if (Entrega.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };

                key_factura = empresa.GetNewObjectKey();

                //##########################################################################################3
                //Registro de carritos cargados, envio a Transitorio
                //##########################################################################################3

                foreach (DataRow dr in ds.Tables["carritos"].Rows)
                {
                    nrocarrito = dr["suppserial"].ToString();
                    string sql_existe = "select * from carritos where codcarrito = '" + nrocarrito + "' ";
                    daCarritos = new SqlDataAdapter(sql_existe, Global.conn_vimar);

                    if (ds.Tables.Contains("car"))
                    {
                        ds.Tables["car"].Clear();
                    };

                    if (daCarritos.Fill(ds, "car") > 0)
                    {
                        actualizar_carritos();
                    }
                    else
                    {
                        alta_carritos();
                    };
                };
                                
                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                imprimir();                
                limpiar_form();
                this.Close();
            }
            catch(Exception ex)
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
                Cursor.Current = Cursors.Default;                
            }
        }
        private void alta_carritos()
        {
            recuperar_codigo_carrito();
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = Global.conn_vimar;

            SqlCommand cmd2 = new SqlCommand("pa_alta_carritos_mae_emb");
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Connection = conn2;

            SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
            RetValue.Direction = ParameterDirection.ReturnValue;
            cmd2.Parameters.Add(RetValue);
            SqlParameter id_carrito = new SqlParameter("@id_carrito", SqlDbType.Int);
            id_carrito.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(id_carrito);
            SqlParameter codCarrito = new SqlParameter("@codCarrito", SqlDbType.Int);
            codCarrito.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(codCarrito);
            SqlParameter estado = new SqlParameter("@estado", SqlDbType.VarChar, 30);
            estado.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(estado);
            SqlParameter almacen = new SqlParameter("@almacen", SqlDbType.Int);
            almacen.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(almacen);
            SqlParameter fechaC = new SqlParameter("@fechaC", SqlDbType.DateTime);
            fechaC.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(fechaC);
            SqlParameter nromov = new SqlParameter("@nromov", SqlDbType.Int);
            nromov.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(nromov);
            SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
            mensaje.Direction = ParameterDirection.InputOutput;
            cmd2.Parameters.Add(mensaje);

            id_carrito.Value = codigocar;
            codCarrito.Value = nrocarrito;
            estado.Value = "A";

            switch (cbDepositos.SelectedValue.ToString())
            {
                case "CCHA":
                    almacen.Value = 6;
                    break;
                case "CCHB":
                    almacen.Value = 7;
                    break;
                case "OVO":
                    almacen.Value = 8;
                    break;
                case "CCHH":
                    almacen.Value = 13;
                    break;
                case "SALON":
                    almacen.Value = 14;
                    break;
            };
            
            fechaC.Value = dtpFecha.Value;
            nromov.Value = key_factura;
            mensaje.Value = "";

            conn2.Open();
            cmd2.ExecuteNonQuery();
            conn2.Dispose();

            if (int.Parse(RetValue.Value.ToString()) == 0)
            {
                //MessageBox.Show(mensaje.Value.ToString());
            }
            else
            {
                MessageBox.Show(mensaje.Value.ToString());
            }
        }
        private void actualizar_carritos()
        {
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = Global.conn_vimar;

            SqlCommand cmd2 = new SqlCommand("pa_mod_carritos_emb");
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Connection = conn2;

            SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
            RetValue.Direction = ParameterDirection.ReturnValue;
            cmd2.Parameters.Add(RetValue);
            SqlParameter codCarrito = new SqlParameter("@codCarrito", SqlDbType.Int);
            codCarrito.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(codCarrito);
            SqlParameter almacen = new SqlParameter("@almacen", SqlDbType.Int);
            almacen.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(almacen);
            SqlParameter fechaC = new SqlParameter("@fechaC", SqlDbType.DateTime);
            fechaC.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(fechaC);
            SqlParameter nromov = new SqlParameter("@nromov", SqlDbType.Int);
            nromov.Direction = ParameterDirection.Input;
            cmd2.Parameters.Add(nromov);
            SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
            mensaje.Direction = ParameterDirection.InputOutput;
            cmd2.Parameters.Add(mensaje);

            codCarrito.Value = nrocarrito;
            switch (cbDepositos.SelectedValue.ToString())
            {
                case "CCHA":
                    almacen.Value = 6;
                    break;
                case "CCHB":
                    almacen.Value = 7;
                    break;
                case "OVO":
                    almacen.Value = 8;
                    break;
                case "CCHH":
                    almacen.Value = 13;
                    break;
                case "SALON":
                    almacen.Value = 14;
                    break;
            };
            fechaC.Value = dtpFecha.Value;
            nromov.Value = key_factura;
            mensaje.Value = "";

            conn2.Open();
            cmd2.ExecuteNonQuery();
            conn2.Dispose();

            if (int.Parse(RetValue.Value.ToString()) == 0)
            {
                //MessageBox.Show(mensaje.Value.ToString());
            }
            else
            {
                MessageBox.Show(mensaje.Value.ToString());
            }
        }
        private void recuperar_codigo_carrito()
        {
            sql_car = "select isnull(max(id_carrito), 0) + 1 as codigo from carritos with (nolock) ";
            daCodigoCar = new SqlDataAdapter(sql_car, Global.conn_vimar);
            if (ds.Tables.Contains("car"))
            {
                ds.Tables["car"].Clear();
            }
            daCodigoCar.Fill(ds, "car");
            codigocar = int.Parse(ds.Tables["car"].Rows[0]["codigo"].ToString());
        }
        private void imprimir()
        {
            rep = new ReportManX();

            rep.filename = Application.StartupPath + "\\Reportes\\Embarque.rep";

            rep.SetParamValue("DOCENTRY", key_factura);
            rep.SetDatabaseConnectionString("CONN", Global.str_conn_REP);

            rep.Title = "Embarque de Huevos Clasificados";
            rep.Preview = false;
            rep.Language = 1;
            rep.ShowPrintDialog = true;
            rep.Execute();

            this.Close();
        }
        private void limpiar_form()
        {
            dtpFecha.Value = DateTime.Now;
            txtCliente.Text = "";
            lblCliente.Text = "";
            ds.Tables["carritos"].Clear();
            dgvCarritos.DataSource = null;
            lblJumbo.Text = "0";
            lblSuper.Text = "0";
            lblA.Text = "0";
            lblB.Text = "0";
            lblC.Text = "0";
            lblD.Text = "0";
            lblGigante.Text = "0";
            lblCA.Text = "0";
            lblCB.Text = "0";
            lblCJ.Text = "0";
            lblCS.Text = "0";
            cbDepositos.SelectedIndex = -1;
            dtpFecha.Focus();
        }
        private static frmEmbarqueHuevos frmDefInstance;
        public static frmEmbarqueHuevos DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmEmbarqueHuevos();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F2)
            //{
            //    //Llamada a formulario de busqueda
            //    frmBClientes frm = new frmBClientes();

            //    frm.sql = "select cardcode, cardname, lictradnum from ocrd where cardtype = 'C' ";
            //    frm.sql = frm.sql + " and cardname like 'VIMAR%' order by cardname ";

            //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        txtCliente.Text = frm.dgvClientes.Rows[frm.dgvClientes.CurrentCell.RowIndex].Cells[0].Value.ToString();
            //        b_clientes();
            //    }
            //}
            //else
            //{
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                //b_clientes();
            }
            //}
        }
        private void b_clientes()
        {
            //sql_clientes = "select cardcode, cardname, listnum from ocrd where cardtype = 'C' and cardcode = '" + txtCliente.Text + "' ";
            sql_clientes = "select cardcode, cardname, listnum from ocrd with (nolock) where cardtype = 'C' and cardname like 'VIMAR%' ";
            daClientes = new SqlDataAdapter(sql_clientes, Global.conn);
            if (ds.Tables.Contains("clientes"))
            {
                ds.Tables["clientes"].Clear();
            };
            if (daClientes.Fill(ds, "clientes") > 0)
            {
                txtCliente.Text = ds.Tables["clientes"].Rows[0]["cardcode"].ToString();
                lblCliente.Text = ds.Tables["clientes"].Rows[0]["cardname"].ToString();
                listaPrecio = ds.Tables["clientes"].Rows[0]["listnum"].ToString();
            };
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //imprimir();
            this.Close();
        }
        private void txtNroCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNroCarrito.Text == "")
                {
                    MessageBox.Show("Debe introducir un Número de Carrito valido");
                    return;
                }
                else
                {
                    foreach (DataRow dr in ds.Tables["carritos"].Rows)
                    {
                        if (dr["suppserial"].ToString() == txtNroCarrito.Text)
                        {
                            txtNroCarrito.Text = "";
                            return;
                        }
                    };                   

                    if (ds.Tables["carritos"].Rows.Count == 0)
                    {
                        lotes();    

                        foreach (DataRow drL in ds.Tables["lotes"].Rows)
                        {
                            if (drL["itemcode"].ToString() == "")
                            {
                                txtNroCarrito.Text = "";
                                return;
                            }
                            NewRow = ds.Tables["carritos"].NewRow();
                            NewRow["itemcode"] = drL["itemcode"].ToString();
                            NewRow["itemname"] = drL["itemname"].ToString();
                            NewRow["suppserial"] = drL["suppserial"].ToString();
                            NewRow["batchnum"] = drL["batchnum"].ToString();
                            NewRow["quantity"] = drL["quantity"].ToString();
                            NewRow["indate"] = drL["indate"].ToString();
                            ds.Tables["carritos"].Rows.Add(NewRow);
                        }                        
                    }
                    else
                    {
                        lotes();
                        
                        foreach (DataRow drL in ds.Tables["lotes"].Rows)
                        {
                            if (drL["itemcode"].ToString() == "")
                            {
                                txtNroCarrito.Text = "";
                                return;
                            }
                            NewRow = ds.Tables["carritos"].NewRow();
                            NewRow["itemcode"] = drL["itemcode"].ToString();
                            NewRow["itemname"] = drL["itemname"].ToString();
                            NewRow["suppserial"] = drL["suppserial"].ToString();
                            NewRow["batchnum"] = drL["batchnum"].ToString();
                            NewRow["quantity"] = drL["quantity"].ToString();
                            NewRow["indate"] = drL["indate"].ToString();
                            ds.Tables["carritos"].Rows.Add(NewRow);                            
                        }                        
                    }
                    cantidades();                    
                    txtNroCarrito.Text = "";
                    cod_art = "";
                }
            }
        }
        private void cantidades()
        {
            cajon_1 = 0;
            cajon_2 = 0;
            cajon_3 = 0;
            cajon_4 = 0;
            cajon_5 = 0;
            cajon_6 = 0;
            cajon_7 = 0;
            carrito_2 = 0;
            carrito_3 = 0;
            carrito_4 = 0;
            carrito_5 = 0;
            carrito_6 = 0;
            carrito_7 = 0;
            foreach (DataRow dr in ds.Tables["carritos"].Rows)
            {
                if (dr["itemcode"].ToString() == "1")
                {
                    cajon_1 = cajon_1 + int.Parse(dr["quantity"].ToString());                    
                }
                else if (dr["itemcode"].ToString() == "2")
                {                    
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_2 = carrito_2 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_2 = cajon_2 + int.Parse(dr["quantity"].ToString());
                    };                    
                }
                else if (dr["itemcode"].ToString() == "3")
                {
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_3 = carrito_3 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_3 = cajon_3 + int.Parse(dr["quantity"].ToString());
                    };                    
                }
                else if (dr["itemcode"].ToString() == "4")
                {
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_4 = carrito_4 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_4 = cajon_4 + int.Parse(dr["quantity"].ToString());
                    };                    
                }
                else if (dr["itemcode"].ToString() == "5")
                {
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_5 = carrito_5 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_5 = cajon_5 + int.Parse(dr["quantity"].ToString());
                    };
                }
                else if (dr["itemcode"].ToString() == "6")
                {
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_6 = carrito_6 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_6 = cajon_6 + int.Parse(dr["quantity"].ToString());
                    };
                }
                else if (dr["itemcode"].ToString() == "7")
                {
                    if (dr["quantity"].ToString() == "4320")
                    {
                        carrito_7 = carrito_7 + int.Parse(dr["quantity"].ToString());
                    }
                    else
                    {
                        cajon_7 = cajon_7 + int.Parse(dr["quantity"].ToString());
                    };
                }
            }
           
            lblGigante.Text = (cajon_1 / 180).ToString();
            lblJumbo.Text = (carrito_2 / 4320).ToString();
            lblCJ.Text = (cajon_2 / 360).ToString();
            lblSuper.Text = (carrito_3 / 4320).ToString();
            lblCS.Text = (cajon_3 / 360).ToString();
            lblA.Text = (carrito_4 / 4320).ToString();
            lblCA.Text = (cajon_4 / 360).ToString();
            lblB.Text = (carrito_5 / 4320).ToString();
            lblCB.Text = (cajon_5 / 360).ToString();
            lblC.Text = ((carrito_6 + cajon_6) / 360).ToString();
            lblD.Text = ((carrito_7 + cajon_7) / 360).ToString();

        }
        private void cantidades_menos()
        {
            //foreach (DataRow dr in ds.Tables["carritos"].Select("itemcode = '1'"))
            //{
            //    cantidad_1 = dr[""]
            //};
        }
        private void cmnuEliminar_Click(object sender, EventArgs e)
        {
            //int i;
            //i = dgvCarritos.CurrentRow.Index;
            //carrito = int.Parse(dgvCarritos.Rows[i].Cells[2].Value.ToString());

            if (dgvCarritos.CurrentCell.RowIndex != -1)
            {
                ds.Tables["carritos"].Rows[dgvCarritos.CurrentCell.RowIndex].Delete();
            };
            ds.AcceptChanges();
            cantidades();
        }
        private void txtNroCarrito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;                
                return;
            };
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void rbCCHA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void rbCCHB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cbCamiones_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cbChoferes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void frmEmbarqueHuevos_Load(object sender, EventArgs e)
        {
            b_clientes();
            camiones();
            choferes();
            llenar_depositos();
        }
        private void chkFactRes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFactRes.Checked == true)
            {
                txtFactRes.Visible = true;
            }
            else
            {
                txtFactRes.Visible = false;
            }
        }
        private void chkFactRes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtFactRes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFactRes.Text != "")
                {
                    fact_det_reserva();
                }
                else
                {
                    MessageBox.Show("Debe introducir un número de Factura Reserva valido.", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                };
            }            
        }
        private void txtFactRes_Leave(object sender, EventArgs e)
        {
            if (txtFactRes.Text != "")
            {
                fact_det_reserva();
            }              
        }
        private void cbCamiones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void crvEmbarq_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cbChoferes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void frmEmbarqueHuevos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.cryRpt != null)
            //{
            //    this.cryRpt.Close();
            //    this.cryRpt.Dispose();
            //}
        }

        private void cbDepositos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
