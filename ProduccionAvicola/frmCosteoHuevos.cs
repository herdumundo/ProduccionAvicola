using System;
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
using System.Diagnostics;

namespace ProduccionAvicola
{
    public partial class frmCosteoHuevos : Form
    {
        //SAP
        Company empresa = new Company();        

        Documents Entrada;
        ProductionOrders OrdenProduccion;
        Documents EmisionProduccion;
        Documents ReciboProduccion;
        JournalEntries Asientos;

        SqlDataAdapter daCantidades;
        SqlDataAdapter daTotales;
        SqlDataAdapter daCuentas;
        SqlDataAdapter daDetCuentas;
        SqlDataAdapter daLotes;
        SqlDataAdapter daLotesSC;
        SqlDataAdapter daLotesMP;
        SqlDataAdapter daLotesDMP;
        SqlDataAdapter daTotalCla;
        SqlDataAdapter daTotalClaB;
        SqlDataAdapter daTotalClaH;
        SqlDataAdapter daTotalOvo;
        SqlDataAdapter daCarritos;
        SqlDataAdapter daTotalFS;
        SqlDataAdapter daComponentes;
        SqlDataAdapter daExistencias;

        string sql_existencias;
        string sql_componentes;
        string sql_totalFS;
        string sql_carritos;
        string sql_totalClaB;
        string sql_totalClaH;
        string sql_totalCla;
        string sql_totalOvo;
        string sql_lotesSC;
        string sql_lotesMP;
        string sql_lotesDMP;
        string sql_lotes;
        string sql_cuentas;
        string sql_detCuentas;
        string sql_cantidades;
        string sql_totales;

        string art_code;
        string tip_huevo;
        string clasif;
        string it;

        int cant_total;
        int cant_a;
        int cant_b;
        int cant_h;
        int cant_o;
        int cant_s;
        int ext_a;
        int ext_b;
        int ext_h;
        int ext_o;
        int ext_s;
        double tot_cuentas;
        double costo;
        int docentry;

        double cant_orden;
        double cant_asignada;
        double cant_disponible;

        double total_ctas;

        public frmCosteoHuevos()
        {
            InitializeComponent();
        }
        private void lotes_sin_clasificar()
        {
            sql_lotesSC = "select obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber, ";
            sql_lotesSC = sql_lotesSC + " convert(numeric(12, 2), obtq.quantity) as Quantity ";
            sql_lotesSC = sql_lotesSC + " from obtq with (nolock) ";
            sql_lotesSC = sql_lotesSC + " inner join obtn with (nolock) on OBTQ.ItemCode = OBTN.ItemCode ";
            sql_lotesSC = sql_lotesSC + " and OBTQ.SysNumber = OBTN.SysNumber ";
            sql_lotesSC = sql_lotesSC + " where obtq.Quantity > 0 and obtq.whscode in ('CCHA', 'CCHB', 'OVO', 'CCHH', 'FS001') ";
            sql_lotesSC = sql_lotesSC + " and obtn.itemcode = 'HVO-00001' ";
            //Comentar la linea de abajo cuando se implemente el costeo de los lotes retenidos
            //sql_lotesSC = sql_lotesSC + " and obtn.distnumber = '" + dtpFecha.Value.ToShortDateString() + "' ";
            sql_lotesSC = sql_lotesSC + " order by OBTN.SysNumber ";
            daLotesSC = new SqlDataAdapter(sql_lotesSC, Global.conn);
            if (ds.Tables.Contains("lotesSC"))
            {
                ds.Tables["lotesSC"].Clear();
            };
            daLotesSC.Fill(ds, "lotesSC");
        }
        private void lotes_maples()
        {
            sql_lotesMP = "select obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber, ";
            sql_lotesMP = sql_lotesMP + " convert(numeric(12, 2), obtq.quantity) as Quantity ";
            sql_lotesMP = sql_lotesMP + " from obtq with (nolock) ";
            sql_lotesMP = sql_lotesMP + " inner join obtn with (nolock) on OBTQ.ItemCode = OBTN.ItemCode ";
            sql_lotesMP = sql_lotesMP + " and OBTQ.SysNumber = OBTN.SysNumber ";
            sql_lotesMP = sql_lotesMP + " where obtq.Quantity > 0 and obtq.whscode = '"+ clasif + "'";
            sql_lotesMP = sql_lotesMP + " and obtn.itemcode = '" + it + "' ";
            //sql_lotesSC = sql_lotesSC + " and obtn.distnumber = '" + dtpFecha.Value.ToShortDateString() + "' ";
            sql_lotesMP = sql_lotesMP + " order by 5 desc, 2, 3 ";
            daLotesMP = new SqlDataAdapter(sql_lotesMP, Global.conn);
            if (ds.Tables.Contains("lotesMP"))
            {
                ds.Tables["lotesMP"].Clear();
            };
            daLotesMP.Fill(ds, "lotesMP");
        }
        private void lotes_disp_maples()
        {
            sql_lotesDMP = "select obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber, ";
            sql_lotesDMP = sql_lotesDMP + " convert(numeric(12, 2), obtq.quantity) as Quantity ";
            sql_lotesDMP = sql_lotesDMP + " from obtq with (nolock) ";
            sql_lotesDMP = sql_lotesDMP + " inner join obtn with (nolock) on OBTQ.ItemCode = OBTN.ItemCode ";
            sql_lotesDMP = sql_lotesDMP + " and OBTQ.SysNumber = OBTN.SysNumber ";
            sql_lotesDMP = sql_lotesDMP + " where obtq.Quantity > 500 and obtq.whscode = '" + clasif + "'";
            if (tip_huevo == "1" || tip_huevo == "2" || tip_huevo == "3")
            {
                sql_lotesDMP = sql_lotesDMP + " and obtn.itemcode in ('CART-00021') ";
            }
            else
            {
                sql_lotesDMP = sql_lotesDMP + " and obtn.itemcode in ('CART-00020') ";
            };
            
            sql_lotesDMP = sql_lotesDMP + " order by 5 desc, 2, 3 ";
            daLotesDMP = new SqlDataAdapter(sql_lotesDMP, Global.conn);
            if (ds.Tables.Contains("lotesDMP"))
            {
                ds.Tables["lotesDMP"].Clear();
            };
            daLotesDMP.Fill(ds, "lotesDMP");
        }
        private void consultar_cantidades_existentes()
        {
            ext_a = 0; ext_b = 0; ext_h = 0; ext_o = 0; ext_s = 0;

            sql_existencias = "select a.WhsCode as Clasificadora, convert(int, a.OnHand) as Cantidad ";
            sql_existencias = sql_existencias + " from OITW a with (nolock) ";
            sql_existencias = sql_existencias + " where a.OnHand > 0 and a.ItemCode = 'HVO-00001' ";
            sql_existencias = sql_existencias + " order by clasificadora ";

            daExistencias = new SqlDataAdapter(sql_existencias, Global.conn);

            if (ds.Tables.Contains("existencia"))
            {
                ds.Tables["existencia"].Clear();
            };
            daExistencias.Fill(ds, "existencia");

            foreach(DataRow dr in ds.Tables["existencia"].Rows)
            {
                if (dr["clasificadora"].ToString() == "CCHA")
                {
                    ext_a = ext_a + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "CCHB")
                {
                    ext_b = ext_b + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "CCHH")
                {
                    ext_h = ext_h + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "FS001")
                {
                    ext_s = ext_s + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "OVO")
                {
                    ext_o = ext_o + int.Parse(dr["cantidad"].ToString());
                };
            }
        }
        private void consultar_cantidades()
        {
            cant_a = 0;
            cant_b = 0;
            cant_h = 0;
            cant_o = 0;
            cant_s = 0;
            sql_cantidades = "select tipo_huevo, sum(cantidad) as cantidad, clasificadora ";
            sql_cantidades = sql_cantidades + " from v_lotes_general with (nolock) ";
            sql_cantidades = sql_cantidades + " where fecha = '" + dtpFecha.Value.ToShortDateString() + "' ";
            //sql_cantidades = sql_cantidades + " and tipo_huevo = 'D' ";
            sql_cantidades = sql_cantidades + " group by tipo_huevo, clasificadora ";

            daCantidades = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("cantidades"))
            {
                ds.Tables["cantidades"].Clear();
            };
            daCantidades.Fill(ds, "cantidades");
            dgvCantidades.DataSource = ds.Tables["cantidades"];

            foreach (DataRow dr in ds.Tables["cantidades"].Rows)
            {
                if (dr["clasificadora"].ToString() == "A")
                {
                    cant_a = cant_a + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "B")
                {
                    cant_b = cant_b + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "H")
                {
                    cant_h = cant_h + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "S")
                {
                    cant_s = cant_s + int.Parse(dr["cantidad"].ToString());
                }
                else if (dr["clasificadora"].ToString() == "O")
                {
                    cant_o = cant_o + int.Parse(dr["cantidad"].ToString());
                };
            };

            lblTotalClaA.Text = cant_a.ToString();
            lblTotalClaB.Text = cant_b.ToString();
            lblTotalClaH.Text = cant_h.ToString();
            lblTotalFS.Text = cant_s.ToString();
            lblTotalOvo.Text = cant_o.ToString();
            txtHuevosSinClasificar.Text = (cant_a + cant_b + cant_h + cant_o + cant_s).ToString();
            cant_total = int.Parse(txtHuevosSinClasificar.Text);
            
        }
        private void consultar_cuentas()
        {
            total_ctas = 0;
            //sql_cuentas = "select sum(convert(numeric, currtotal)) as total ";
            //sql_cuentas = sql_cuentas + "from oact ";
            //sql_cuentas = sql_cuentas + "where AcctCode in ('10.01.11.99.02', '10.01.11.99.08', '10.01.11.99.05') ";
            //sql_cuentas = sql_cuentas + "group by acctcode ";
            sql_cuentas = "select (convert(numeric(15,2), isnull(sum(debit-credit),0))) as total ";
            //sql_cuentas = "select (convert(numeric(15,2), isnull(195235260,0))) as total ";
            sql_cuentas = sql_cuentas + " from OJDT a with (nolock)  ";
            sql_cuentas = sql_cuentas + " inner join JDT1 b with (nolock) on a.TransId = b.TransId ";
            sql_cuentas = sql_cuentas + " where b.Account in ('10.01.11.99.08', '10.01.11.99.05', '10.01.11.99.02', '10.01.11.99.11') ";
            //sql_cuentas = sql_cuentas + " and b.ContraAct not in ('10.01.11.99.99') ";
            //sql_cuentas = sql_cuentas + " and a.taxdate = '" + dtpFecha.Value.AddDays(-1).ToShortDateString() + "' ";
            sql_cuentas = sql_cuentas + " and a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' ";
            //sql_cuentas = sql_cuentas + " and a.taxdate in ('31/12/2015', '01/01/2016')";
            daCuentas = new SqlDataAdapter(sql_cuentas, Global.conn);

            if (ds.Tables.Contains("cuentas"))
            {
                ds.Tables["cuentas"].Clear();
            };

            if (daCuentas.Fill(ds, "cuentas") > 0)
            {
                if (double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString()) != 0.00)
                {
                    total_ctas = double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString());

                    sql_detCuentas = "select (convert(numeric, isnull(sum(debit-credit),0))) as total, b.account as acctcode ";
                    sql_detCuentas = sql_detCuentas + "from ojdt a with (nolock) ";
                    sql_detCuentas = sql_detCuentas + "inner join JDT1 b with (nolock) on a.transid = b.transid ";
                    sql_detCuentas = sql_detCuentas + "where b.account in ('10.01.11.99.02', '10.01.11.99.08', '10.01.11.99.05') ";
                    //sql_detCuentas = sql_detCuentas + "and b.ContraAct not in ('10.01.11.99.99') ";
                    //sql_detCuentas = sql_detCuentas + "and a.taxdate = '" + dtpFecha.Value.AddDays(-1).ToShortDateString() + "' ";
                    sql_detCuentas = sql_detCuentas + "and a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' ";
                    //sql_detCuentas = sql_detCuentas + " and a.taxdate in ('31/12/2015', '01/01/2016') ";
                    sql_detCuentas = sql_detCuentas + "group by b.account ";
                    daDetCuentas = new SqlDataAdapter(sql_detCuentas, Global.conn);

                    if (ds.Tables.Contains("detcuentas"))
                    {
                        ds.Tables["detcuentas"].Clear();
                    };
                    daDetCuentas.Fill(ds, "detcuentas");
                }
                else
                {
                    MessageBox.Show("No se han registrado movimientos de Producción Primaria");
                    return;
                }                
            };     
            
        }
        private void consultar_carritos()
        {
            sql_carritos = "select * from lotes ";
        }
        private void actualizar_estado()
        {            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("mod_lotes");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);          
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                fecha.Value = dtpFecha.Value.ToShortDateString();
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
               
            }
        }
        private void actualizar_embarques()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("upd_embarques");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                fecha.Value = dtpFecha.Value.ToShortDateString();
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
            finally
            {

            }
        }
        private void actualizar_embarques_cab()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("upd_embarques_cab");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                fecha.Value = dtpFecha.Value.ToShortDateString();
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
            finally
            {

            }
        }
        private void actualizar_transferencias()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("upd_transferencias_detalle");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                fecha.Value = dtpFecha.Value.ToShortDateString();
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
            finally
            {

            }
        }
        private void actualizar_transferencias_cab()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("upd_transferencias_cab");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                fecha.Value = dtpFecha.Value.ToShortDateString();
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
            finally
            {

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
        private static frmCosteoHuevos frmDefInstance;
        public static frmCosteoHuevos DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmCosteoHuevos();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {                
                Cursor.Current = Cursors.WaitCursor;

                //--##################################################################################--
                //--Validacion de datos 
                //--##################################################################################--

                if (txtHuevosSinClasificar.Text == "0")
                {
                    MessageBox.Show("No existen datos para procesamiento");
                    return;
                }
                //--##################################################################################--
                //--Comprobar conexion a base de datos
                //--##################################################################################--
                
                if (empresa.Connected == false)
                {
                    conexion();
                    if (empresa.Connect() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorDescription() + ", Código de error: " + empresa.GetLastErrorCode().ToString());
                        return;
                    };
                }

                empresa.StartTransaction();

                //--##################################################################################--
                //--Crear entrada de mercancias por el total de los huevos de la clasificadora
                //--##################################################################################--

                
                if (chkManual.Checked == true)
                {
                    tot_cuentas = double.Parse(txtCosto.Text) * int.Parse(txtHuevosSinClasificar.Text);
                }
                else
                {
                    tot_cuentas = double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString());
                };
                
                costo = tot_cuentas / cant_total;                               
                
                Entrada = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);                
                Entrada.DocDate = dtpFecha.Value;


                int xx = 0;

                //--##################################################################################--
                //--Linea para clasificadora A
                //--##################################################################################--
                if (int.Parse(lblTotalClaA.Text) != 0)
                {
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHA";
                    Entrada.Lines.Quantity = double.Parse(lblTotalClaA.Text) - ext_a;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(0);
                    Entrada.Lines.LineTotal = (double.Parse(lblTotalClaA.Text)-ext_a) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(xx);
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(lblTotalClaA.Text) - ext_a;
                    Entrada.Lines.BatchNumbers.BatchNumber = dtpFecha.Value.ToShortDateString();//DateTime.Now.Date.ToShortDateString();                
                    Entrada.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;//DateTime.Now.Date;
                    Entrada.Lines.BatchNumbers.Add();

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Entrada.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0,1);    
                    Entrada.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                    Entrada.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                    Entrada.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                    Entrada.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;

                    xx++;
                    Entrada.Lines.Add();
                };                

                //--##################################################################################--
                //--Linea para clasificadora B
                //--##################################################################################--
                if (int.Parse(lblTotalClaB.Text) != 0)
                {
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHB";
                    Entrada.Lines.Quantity = double.Parse(lblTotalClaB.Text) - ext_b;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);                                      
                    Entrada.Lines.LineTotal = (double.Parse(lblTotalClaB.Text) - ext_b) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(lblTotalClaB.Text) - ext_b;
                    Entrada.Lines.BatchNumbers.BatchNumber = dtpFecha.Value.ToShortDateString();//DateTime.Now.Date.ToShortDateString();
                    Entrada.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;//DateTime.Now.Date;                   
                    Entrada.Lines.BatchNumbers.Add();

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Entrada.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                    Entrada.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                    Entrada.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                    Entrada.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                    Entrada.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;

                    xx++;
                    Entrada.Lines.Add();
                };                
                
                //--##################################################################################--
                //--Linea para Ovoproductos
                //--##################################################################################--
                if (int.Parse(lblTotalOvo.Text) != 0)
                {
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "OVO";
                    Entrada.Lines.Quantity = double.Parse(lblTotalOvo.Text) - ext_o;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (double.Parse(lblTotalOvo.Text)-ext_o) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(lblTotalOvo.Text) - ext_o;
                    Entrada.Lines.BatchNumbers.BatchNumber = dtpFecha.Value.ToShortDateString();//DateTime.Now.Date.ToShortDateString();
                    Entrada.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;//DateTime.Now.Date;                   
                    Entrada.Lines.BatchNumbers.Add();

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Entrada.Lines.CostingCode = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                    Entrada.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                    Entrada.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                    Entrada.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                    Entrada.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_OVO;

                    xx++;
                    Entrada.Lines.Add();
                };

                //--##################################################################################--
                //--Linea para CCHH
                //--##################################################################################--
                if (int.Parse(lblTotalClaH.Text) != 0)
                {
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHH";
                    Entrada.Lines.Quantity = double.Parse(lblTotalClaH.Text) - ext_h;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (double.Parse(lblTotalClaH.Text) - ext_h) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(lblTotalClaH.Text) - ext_h;
                    Entrada.Lines.BatchNumbers.BatchNumber = dtpFecha.Value.ToShortDateString();//DateTime.Now.Date.ToShortDateString();
                    Entrada.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;//DateTime.Now.Date;                   
                    Entrada.Lines.BatchNumbers.Add();

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Entrada.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                    Entrada.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                    Entrada.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                    Entrada.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                    Entrada.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;

                    xx++;
                    Entrada.Lines.Add();
                };

                if (int.Parse(lblTotalFS.Text) != 0)
                {
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "FS001";
                    Entrada.Lines.Quantity = double.Parse(lblTotalFS.Text) - ext_s;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (double.Parse(lblTotalFS.Text) - ext_s) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(lblTotalFS.Text) - ext_s;
                    Entrada.Lines.BatchNumbers.BatchNumber = dtpFecha.Value.ToShortDateString();//DateTime.Now.Date.ToShortDateString();
                    Entrada.Lines.BatchNumbers.AddmisionDate = dtpFecha.Value;//DateTime.Now.Date;                   
                    Entrada.Lines.BatchNumbers.Add();

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Entrada.Lines.CostingCode = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                    Entrada.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                    Entrada.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                    Entrada.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                    Entrada.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_FS;

                    xx++;
                    Entrada.Lines.Add();
                };
                if (Entrada.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;               
                };

                docentry = int.Parse(empresa.GetNewObjectKey());

                lotes_sin_clasificar();

                foreach (DataRow dr in ds.Tables["cantidades"].Rows)
                {
                    switch(dr["tipo_huevo"].ToString())
                    {
                        case "G":
                            tip_huevo = "1";
                            break;
                        case "J":
                            tip_huevo = "2";
                            break;
                        case "S":
                            tip_huevo = "3";
                            break;
                        case "A":
                            tip_huevo = "4";
                            break;
                        case "B":
                            tip_huevo = "5";
                            break;
                        case "C":
                            tip_huevo = "6";
                            break;
                        case "D":
                            tip_huevo = "7";
                            break;
                        case "PI":
                            tip_huevo = "8";
                            break;
                        case "R":
                            tip_huevo = "9";
                            break;
                    }

                    switch (dr["clasificadora"].ToString())
                    {
                        case "A":
                            clasif = "CCHA";
                            break;
                        case "B":
                            clasif = "CCHB";
                            break;
                        case "O":
                            clasif = "OVO";
                            break;
                        case "H":
                            clasif = "CCHH";
                            break;
                        case "S":
                            clasif = "FS001";
                            break;
                    }
                    //sql_componentes = "select b.childnum, b.code, b.quantity, b.warehouse, b.father, a.qauntity as qtotal ";
                    sql_componentes = "select b.childnum, b.code, b.quantity, b.father, a.quantity as qtotal ";
                    sql_componentes = sql_componentes + " from oitt a with (nolock) ";
                    sql_componentes = sql_componentes + " inner join itt1 b with (nolock) on a.code = b.father ";
                    sql_componentes = sql_componentes + " where a.code = '" + tip_huevo + "'";
                    sql_componentes = sql_componentes + " order by 1 ";

                    if (ds.Tables.Contains("componentes"))
                    {
                        ds.Tables["componentes"].Rows.Clear();
                    };
                    daComponentes = new SqlDataAdapter(sql_componentes, Global.conn_clasif);
                    daComponentes.Fill(ds, "componentes");

                    OrdenProduccion = empresa.GetBusinessObject(BoObjectTypes.oProductionOrders);                    
                    
                    if (tip_huevo == "9")
                    {
                        OrdenProduccion.ProductionOrderType = BoProductionOrderTypeEnum.bopotSpecial;
                        OrdenProduccion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned;
                        OrdenProduccion.PlannedQuantity = double.Parse(dr["cantidad"].ToString());
                        OrdenProduccion.PostingDate = dtpFecha.Value;//DateTime.Now;
                        OrdenProduccion.DueDate = dtpFecha.Value;//DateTime.Now;
                        OrdenProduccion.Warehouse = clasif;
                        OrdenProduccion.ItemNo = tip_huevo;

                        OrdenProduccion.Lines.ItemNo = "HVO-00001";
                        OrdenProduccion.Lines.BaseQuantity = 1;
                        OrdenProduccion.Lines.PlannedQuantity = double.Parse(dr["cantidad"].ToString());
                        OrdenProduccion.Lines.Warehouse = clasif;
                        OrdenProduccion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;

                        if (dr["clasificadora"].ToString() == "O")
                        {
                            OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                            OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                            OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                            OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                            OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_OVO;
                        }
                        else if (dr["clasificadora"].ToString() == "S")
                        {
                            OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                            OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                            OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                            OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                            OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_FS;
                        }
                        else
                        {
                            OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                            OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                            OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                            OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                            OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_CCH;
                        };

                        OrdenProduccion.Lines.Add();
                    }
                    else
                    {
                        //OrdenProduccion.ProductionOrderType = BoProductionOrderTypeEnum.bopotStandard;
                        OrdenProduccion.ProductionOrderType = BoProductionOrderTypeEnum.bopotSpecial;
                        OrdenProduccion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned;
                        OrdenProduccion.PlannedQuantity = double.Parse(dr["cantidad"].ToString());
                        OrdenProduccion.PostingDate = dtpFecha.Value;//DateTime.Now;
                        OrdenProduccion.DueDate = dtpFecha.Value;//DateTime.Now;
                        OrdenProduccion.Warehouse = clasif;
                        OrdenProduccion.ItemNo = tip_huevo;
                        //--##################################################################################--
                        //--Dependiendo del tipo de huevo utilizado, asignamos el ItemNo en la orden de produccion
                        //--##################################################################################--

                        //int n = 0;
                        foreach (DataRow drLineas in ds.Tables["componentes"].Rows)
                        {
                            //OrdenProduccion.Lines.SetCurrentLine(n);    

                            OrdenProduccion.Lines.ItemNo = drLineas["code"].ToString();
                            OrdenProduccion.Lines.BaseQuantity = double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString());
                            OrdenProduccion.Lines.PlannedQuantity = Math.Ceiling((double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString())) * double.Parse(dr["cantidad"].ToString()));
                            OrdenProduccion.Lines.Warehouse = clasif; // drLineas["warehouse"].ToString();
                            OrdenProduccion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;

                            /*if ( drLineas["childnum"].ToString() == "1" && tip_huevo.Contains("123"))
                            {
                                //Consultar cantidad de maples depndiendo del tipo de huevo
                                lotes_disp_maples();
                                OrdenProduccion.Lines.ItemNo = ds.Tables["lotesDMP"].Rows[0]["itemcode"].ToString(); //drLineas["code"].ToString();
                                OrdenProduccion.Lines.BaseQuantity = double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString());
                                OrdenProduccion.Lines.PlannedQuantity = Math.Ceiling((double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString())) * double.Parse(dr["cantidad"].ToString()));
                                OrdenProduccion.Lines.Warehouse = clasif; // drLineas["warehouse"].ToString();
                                OrdenProduccion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;
                            }
                            else if (drLineas["childnum"].ToString() == "1" && !tip_huevo.Contains("123"))
                            {
                                OrdenProduccion.Lines.ItemNo = "CART-00020";
                                OrdenProduccion.Lines.BaseQuantity = double.Parse("144") / double.Parse(drLineas["qtotal"].ToString());
                                OrdenProduccion.Lines.PlannedQuantity = Math.Ceiling((double.Parse("144") / double.Parse(drLineas["qtotal"].ToString())) * double.Parse(dr["cantidad"].ToString()));
                                OrdenProduccion.Lines.Warehouse = clasif; // drLineas["warehouse"].ToString();
                                OrdenProduccion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;
                            }
                            else
                            {
                                OrdenProduccion.Lines.ItemNo = drLineas["code"].ToString();
                                OrdenProduccion.Lines.BaseQuantity = double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString());
                                OrdenProduccion.Lines.PlannedQuantity = Math.Ceiling((double.Parse(drLineas["quantity"].ToString()) / double.Parse(drLineas["qtotal"].ToString())) * double.Parse(dr["cantidad"].ToString()));
                                OrdenProduccion.Lines.Warehouse = clasif; // drLineas["warehouse"].ToString();
                                OrdenProduccion.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;
                            };       */



                            if (dr["clasificadora"].ToString() == "O")
                            {
                                OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                                OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                                OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                                OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                                OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_OVO;
                            }
                            else if (dr["clasificadora"].ToString() == "S")
                            {
                                OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                                OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                                OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                                OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                                OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_FS;
                            }
                            else
                            {
                                OrdenProduccion.Lines.DistributionRule = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                                OrdenProduccion.Lines.DistributionRule2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                                OrdenProduccion.Lines.DistributionRule3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                                OrdenProduccion.Lines.DistributionRule4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                                OrdenProduccion.Lines.DistributionRule5 = Properties.Settings.Default.centro_costo_CCH;
                            };

                            OrdenProduccion.Lines.Add();
                            //n++;
                        };
                    };

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    if (OrdenProduccion.Add() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };

                    docentry = int.Parse(empresa.GetNewObjectKey());

                    OrdenProduccion.GetByKey(docentry);
                    OrdenProduccion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposReleased;

                    if (OrdenProduccion.Update() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };                                       
                    //--##################################################################################--
                    //--Crear emision para produccion
                    //--##################################################################################--

                    EmisionProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                    EmisionProduccion.DocDate = dtpFecha.Value;
                                        
                    if (tip_huevo == "9")
                    {
                        EmisionProduccion.Lines.BaseEntry = docentry;
                        EmisionProduccion.Lines.BaseLine = 0;
                        EmisionProduccion.Lines.BaseType = 0;
                        EmisionProduccion.Lines.WarehouseCode = clasif;

                        EmisionProduccion.Lines.Quantity = double.Parse(dr["cantidad"].ToString());

                        #region lotes_emision
                        cant_orden = double.Parse(dr["cantidad"].ToString());
                        cant_asignada = 0;
                        int ilotes = 0;

                        //--##################################################################################--
                        //--Consumir huevos del lote de huevos sin clasificar
                        //--##################################################################################--

                        while (cant_asignada < cant_orden)
                        {
                            if (ds.Tables["lotesSC"].Rows[ilotes]["itemcode"].ToString() == Properties.Settings.Default.cod_huevo_SC && ds.Tables["lotesSC"].Rows[ilotes]["whscode"].ToString() == clasif)
                            {
                                cant_disponible = double.Parse(ds.Tables["lotesSC"].Rows[ilotes]["quantity"].ToString());
                                if (cant_disponible > 0)
                                {
                                    EmisionProduccion.Lines.BatchNumbers.BatchNumber = ds.Tables["lotesSC"].Rows[ilotes]["DistNumber"].ToString();
                                    if (cant_disponible >= (cant_orden - cant_asignada))
                                    {
                                        //--##################################################################################--
                                        //--Si la cantidad disponible de lotes es mayor o igual al requerido, se asigna el requerido y se descuenta.
                                        //--##################################################################################--

                                        EmisionProduccion.Lines.BatchNumbers.Quantity = cant_orden - cant_asignada;
                                        ds.Tables["lotesSC"].Rows[ilotes]["Quantity"] = cant_disponible - EmisionProduccion.Lines.BatchNumbers.Quantity;
                                        double valor_nuevo = int.Parse(ds.Tables["lotesSC"].Rows[ilotes]["Quantity"].ToString());
                                        ds.Tables["lotesSC"].AcceptChanges();
                                        valor_nuevo = int.Parse(ds.Tables["lotesSC"].Rows[ilotes]["Quantity"].ToString());
                                        cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;
                                        EmisionProduccion.Lines.BatchNumbers.Add();
                                        ilotes++;
                                    }
                                    else
                                    {
                                        //--##################################################################################--
                                        //--Si la cantidad disponible de lotes es menor al querido, se asigna los disponibles y se pasa a otro lote.
                                        //--##################################################################################--

                                        EmisionProduccion.Lines.BatchNumbers.Quantity = cant_disponible;
                                        cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;

                                        ds.Tables["lotesSC"].Rows[ilotes]["Quantity"] = 0;
                                        ds.Tables["lotesSC"].AcceptChanges();
                                        EmisionProduccion.Lines.BatchNumbers.Add();
                                        ilotes++;
                                    };
                                }
                                else
                                {
                                    ilotes++;
                                };
                            }
                            else
                            {
                                ilotes++;
                            };
                        }
                        #endregion
                        EmisionProduccion.Lines.Add();
                    }
                    else
                    {
                        string lcomps = "";
                        foreach (DataRow drComp in ds.Tables["componentes"].Rows)
                        {
                            string lcomp = drComp["childnum"].ToString();
                            
                            if (!lcomps.Contains(lcomp))
                            {
                                if (lcomp == "0")
                                {
                                    EmisionProduccion.Lines.BaseEntry = docentry;
                                    EmisionProduccion.Lines.BaseLine = 0;
                                    EmisionProduccion.Lines.BaseType = 0;
                                    EmisionProduccion.Lines.WarehouseCode = clasif;

                                    EmisionProduccion.Lines.Quantity = double.Parse(dr["cantidad"].ToString());

                                    cant_orden = double.Parse(dr["cantidad"].ToString());
                                    cant_asignada = 0;
                                    int ilotes = 0;

                                    //--##################################################################################--
                                    //--Consumir huevos del lote de huevos sin clasificar
                                    //--##################################################################################--
                                    #region lotes_emision
                                    while (cant_asignada < cant_orden)
                                    {
                                        if (ds.Tables["lotesSC"].Rows[ilotes]["itemcode"].ToString() == Properties.Settings.Default.cod_huevo_SC && ds.Tables["lotesSC"].Rows[ilotes]["whscode"].ToString() == clasif)
                                        {
                                            cant_disponible = double.Parse(ds.Tables["lotesSC"].Rows[ilotes]["quantity"].ToString());
                                            if (cant_disponible > 0)
                                            {
                                                EmisionProduccion.Lines.BatchNumbers.BatchNumber = ds.Tables["lotesSC"].Rows[ilotes]["DistNumber"].ToString();
                                                if (cant_disponible >= (cant_orden - cant_asignada))
                                                {
                                                    //--##################################################################################--
                                                    //--Si la cantidad disponible de lotes es mayor o igual al requerido, se asigna el requerido y se descuenta.
                                                    //--##################################################################################--

                                                    EmisionProduccion.Lines.BatchNumbers.Quantity = cant_orden - cant_asignada;
                                                    ds.Tables["lotesSC"].Rows[ilotes]["Quantity"] = cant_disponible - EmisionProduccion.Lines.BatchNumbers.Quantity;
                                                    double valor_nuevo = int.Parse(ds.Tables["lotesSC"].Rows[ilotes]["Quantity"].ToString());
                                                    ds.Tables["lotesSC"].AcceptChanges();
                                                    valor_nuevo = int.Parse(ds.Tables["lotesSC"].Rows[ilotes]["Quantity"].ToString());
                                                    cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;
                                                    EmisionProduccion.Lines.BatchNumbers.Add();
                                                    ilotes++;
                                                }
                                                else
                                                {
                                                    //--##################################################################################--
                                                    //--Si la cantidad disponible de lotes es menor al querido, se asigna los disponibles y se pasa a otro lote.
                                                    //--##################################################################################--

                                                    EmisionProduccion.Lines.BatchNumbers.Quantity = cant_disponible;
                                                    cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;

                                                    ds.Tables["lotesSC"].Rows[ilotes]["Quantity"] = 0;
                                                    ds.Tables["lotesSC"].AcceptChanges();
                                                    EmisionProduccion.Lines.BatchNumbers.Add();
                                                    ilotes++;
                                                };
                                            }
                                            else
                                            {
                                                ilotes++;
                                            };
                                        }
                                        else
                                        {
                                            ilotes++;
                                        };
                                    }
                                    #endregion

                                    //--##################################################################################--
                                    //--Asignacion de centro de costo 
                                    //--##################################################################################--

                                    if (dr["clasificadora"].ToString() == "O")
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_OVO;
                                    }
                                    else if (dr["clasificadora"].ToString() == "S")
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_FS;
                                    }
                                    else
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;
                                    };
                                    EmisionProduccion.Lines.Add();

                                    lcomps = lcomps + lcomp;
                                }
                                else 
                                {
                                    EmisionProduccion.Lines.BaseEntry = docentry;
                                    EmisionProduccion.Lines.BaseLine = int.Parse(lcomp);
                                    EmisionProduccion.Lines.BaseType = 0;
                                    EmisionProduccion.Lines.WarehouseCode = clasif;
                                    
                                    EmisionProduccion.Lines.Quantity = Math.Ceiling((double.Parse(drComp["quantity"].ToString()) / double.Parse(drComp["qtotal"].ToString())) * double.Parse(dr["cantidad"].ToString()));
                                    
                                    cant_orden = EmisionProduccion.Lines.Quantity;

                                    cant_asignada = 0;
                                    int ilotes = 0;

                                    it = drComp["code"].ToString();
                                    lotes_maples();

                                    #region maples

                                    while (cant_asignada < cant_orden)
                                    {
                                        if (ilotes == 11)
                                        {
                                            string strItemcode = it;
                                            string strClasifi = dr["clasificadora"].ToString();
                                            //string strICode = ds.Tables["lotesMP"].Rows[ilotes]["itemcode"].ToString();
                                            Debugger.Break();
                                        }

                                        if (ds.Tables["lotesMP"].Rows[ilotes]["itemcode"].ToString() == it)
                                        {
                                            cant_disponible = double.Parse(ds.Tables["lotesMP"].Rows[ilotes]["quantity"].ToString());
                                            if (cant_disponible > 0)
                                            {
                                                EmisionProduccion.Lines.BatchNumbers.BatchNumber = ds.Tables["lotesMP"].Rows[ilotes]["distnumber"].ToString();
                                                if (cant_disponible >= (cant_orden - cant_asignada))
                                                {
                                                    EmisionProduccion.Lines.BatchNumbers.Quantity = cant_orden - cant_asignada;
                                                    ds.Tables["lotesMP"].Rows[ilotes]["quantity"] = cant_disponible - EmisionProduccion.Lines.BatchNumbers.Quantity;
                                                    double valor_nuevo = int.Parse(ds.Tables["lotesMP"].Rows[ilotes]["quantity"].ToString());
                                                    ds.Tables["lotesMP"].AcceptChanges();
                                                    valor_nuevo = int.Parse(ds.Tables["lotesMP"].Rows[ilotes]["quantity"].ToString());
                                                    cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;
                                                    EmisionProduccion.Lines.BatchNumbers.Add();
                                                    ilotes++;
                                                }
                                                else
                                                {
                                                    EmisionProduccion.Lines.BatchNumbers.Quantity = cant_disponible;
                                                    cant_asignada = cant_asignada + EmisionProduccion.Lines.BatchNumbers.Quantity;

                                                    ds.Tables["lotesMP"].Rows[ilotes]["quantity"] = 0;
                                                    ds.Tables["lotesMP"].AcceptChanges();
                                                    EmisionProduccion.Lines.BatchNumbers.Add();
                                                    ilotes++;
                                                };
                                            }
                                            else
                                            {
                                                ilotes++;
                                            };
                                        }
                                        else
                                        {
                                            ilotes++;
                                        };
                                    }
                      
                                    #endregion

                                    //--##################################################################################--
                                    //--Asignacion de centro de costo 
                                    //--##################################################################################--

                                    if (dr["clasificadora"].ToString() == "O")
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_OVO;
                                    }
                                    else if (dr["clasificadora"].ToString() == "S")
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_FS;
                                    }
                                    else
                                    {
                                        EmisionProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                                        EmisionProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                                        EmisionProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                                        EmisionProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                                        EmisionProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;
                                    };
                                    EmisionProduccion.Lines.Add();

                                    lcomps = lcomps + lcomp;
                                }                               
                            }                           
                        }                         
                    };                    

                    if (EmisionProduccion.Add() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };

                    //--##################################################################################--
                    //--Crear recibo de produccion
                    //--##################################################################################--
                    ReciboProduccion = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                    ReciboProduccion.DocDate = dtpFecha.Value;
                    ReciboProduccion.Lines.BaseType = 0;
                    ReciboProduccion.Lines.BaseEntry = docentry;
                    ReciboProduccion.Lines.TransactionType = BoTransactionTypeEnum.botrntComplete;
                    ReciboProduccion.Lines.Quantity = double.Parse(dr["cantidad"].ToString());
                    ReciboProduccion.Lines.WarehouseCode = clasif;

                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    if (dr["clasificadora"].ToString() == "O")
                    {
                        ReciboProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_OVO.Substring(0, 1);
                        ReciboProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 2);
                        ReciboProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 3);
                        ReciboProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_OVO.Substring(0, 5);
                        ReciboProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_OVO;
                    }
                    else if (dr["clasificadora"].ToString() == "S")
                    {
                        ReciboProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_FS.Substring(0, 1);
                        ReciboProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_FS.Substring(0, 2);
                        ReciboProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_FS.Substring(0, 3);
                        ReciboProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_FS.Substring(0, 5);
                        ReciboProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_FS;
                    }
                    else
                    {
                        ReciboProduccion.Lines.CostingCode = Properties.Settings.Default.centro_costo_CCH.Substring(0, 1);
                        ReciboProduccion.Lines.CostingCode2 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 2);
                        ReciboProduccion.Lines.CostingCode3 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 3);
                        ReciboProduccion.Lines.CostingCode4 = Properties.Settings.Default.centro_costo_CCH.Substring(0, 5);
                        ReciboProduccion.Lines.CostingCode5 = Properties.Settings.Default.centro_costo_CCH;
                    };


                    //--##################################################################################--
                    //--Consulta de lotes por tipo de huevo
                    //--##################################################################################--

                    sql_lotes = "select cantidad, cod_lote, cod_carrito, fecha_puesta, cod_clasificacion, estado_liberacion ";
                    sql_lotes = sql_lotes + "from lotes with (nolock) where convert(varchar, fecha, 103) = '" + dtpFecha.Value.ToShortDateString() + "' ";
                    sql_lotes = sql_lotes + " and tipo_huevo = '" + dr["tipo_huevo"].ToString() + "' ";
                    sql_lotes = sql_lotes + " and tipo_huevo not in ('RP') ";
                    sql_lotes = sql_lotes + " and estado = 'A' and clasificadora = '" + dr["clasificadora"].ToString() + "' ";
                    sql_lotes = sql_lotes + " and estado_liberacion = 'L' ";
                    sql_lotes = sql_lotes + " union all ";
                    sql_lotes = sql_lotes + " select cantidad, cod_lote, cod_carrito, fecha_puesta, cod_clasificacion, estado_liberacion ";
                    sql_lotes = sql_lotes + " from lotes with (nolock) where convert(varchar, fecha, 103) = '" + dtpFecha.Value.ToShortDateString() + "' ";
                    sql_lotes = sql_lotes + " and tipo_huevo = '" + dr["tipo_huevo"].ToString() + "' ";
                    sql_lotes = sql_lotes + " and tipo_huevo not in ('RP') ";
                    sql_lotes = sql_lotes + " and estado = 'A' and clasificadora = '" + dr["clasificadora"].ToString() + "' ";
                    sql_lotes = sql_lotes + " and RIGHT(estado_liberacion, 1) = 'L' ";
                    sql_lotes = sql_lotes + " and cod_lote in (select distinct cod_lote ";
                    sql_lotes = sql_lotes + " from lotes_retenidos with (nolock) where disposicion in (8,9,27,30) and estado_liberacion = 'L' and movimiento = 'A' ";
                    //sql_lotes = sql_lotes + " and convert(varchar, fecha, 103) = '" + dtpFecha.Value.ToShortDateString() + "' ";
                    sql_lotes = sql_lotes + " and clasificadora = '" + dr["clasificadora"].ToString() + "') ";


                    daLotes = new SqlDataAdapter(sql_lotes, Global.conn_clasif);
                    if (ds.Tables.Contains("lotes"))
                    {
                        ds.Tables["lotes"].Clear();
                    };
                    daLotes.Fill(ds, "lotes");

                    //--##################################################################################--
                    //--Creamos un datareader del dataset lotes para cargar los lotes en el recibo de produccion
                    //--##################################################################################--

                    foreach (DataRow drLotes in ds.Tables["lotes"].Rows)
                    {
                        ReciboProduccion.Lines.BatchNumbers.Quantity = double.Parse(drLotes["cantidad"].ToString());
                        ReciboProduccion.Lines.BatchNumbers.BatchNumber = drLotes["cod_lote"].ToString();
                        ReciboProduccion.Lines.BatchNumbers.ManufacturerSerialNumber = drLotes["cod_carrito"].ToString();
                        ReciboProduccion.Lines.BatchNumbers.AddmisionDate = DateTime.Parse(drLotes["fecha_puesta"].ToString());
                        ReciboProduccion.Lines.BatchNumbers.InternalSerialNumber = drLotes["cod_clasificacion"].ToString();
                        ReciboProduccion.Lines.BatchNumbers.UserFields.Fields.Item("U_estliberacion").Value = drLotes["estado_liberacion"].ToString();

                        //ReciboProduccion.Lines.BatchNumbers.
                        ReciboProduccion.Lines.BatchNumbers.Add();
                    }

                    if (ReciboProduccion.Add() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };

                    //--##################################################################################--
                    //--Actualizamos la orden de produccion colocando el estado Cerrado
                    //--##################################################################################--

                    OrdenProduccion.GetByKey(docentry);
                    OrdenProduccion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposClosed;
                    if (OrdenProduccion.Update() != 0)
                    {
                        MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };
                };

                //--##################################################################################--
                //--Registrar asiento contable. Cuentas de Costos vs Cuenta Regularizadora
                //--##################################################################################--

                Asientos = empresa.GetBusinessObject(BoObjectTypes.oJournalEntries);
                Asientos.TaxDate = dtpFecha.Value.AddDays(-1);
                Asientos.ReferenceDate = dtpFecha.Value.AddDays(-1);
                Asientos.DueDate = dtpFecha.Value.AddDays(-1);
                Asientos.Lines.AccountCode = "10.01.11.99.99"; //Cuenta regularizadora
                Asientos.Lines.Debit = double.Parse(txtHuevosSinClasificar.Text) * costo; //Suma de las cuentas de gastos o total cuenta regularizadora
                Asientos.Lines.Credit = 0;
                Asientos.Memo = "Costeo de huevo fecha " + dtpFecha.Value.ToShortDateString();
                Asientos.Lines.Add();

                //--##################################################################################--
                //--Consulta de cuentas de consumo
                //--##################################################################################--

                if (chkManual.Checked == true)
                {
                    ////Carga manual 
                    Asientos.Lines.AccountCode = "10.01.11.99.02";
                    Asientos.Lines.ContraAccount = "10.01.11.99.99";
                    Asientos.Lines.Credit = double.Parse(txtHuevosSinClasificar.Text) * costo;
                    Asientos.Lines.Debit = 0;
                    Asientos.Lines.Add();

                    Asientos.Lines.AccountCode = "10.01.11.99.05";
                    Asientos.Lines.ContraAccount = "10.01.11.99.99";
                    Asientos.Lines.Credit = double.Parse("0");
                    Asientos.Lines.Debit = 0;
                    Asientos.Lines.Add();

                    Asientos.Lines.AccountCode = "10.01.11.99.08";
                    Asientos.Lines.ContraAccount = "10.01.11.99.99";
                    Asientos.Lines.Credit = double.Parse("0");
                    Asientos.Lines.Debit = 0;
                    Asientos.Lines.Add();
                }
                else
                {
                    foreach (DataRow drCta in ds.Tables["detcuentas"].Rows)
                    {
                        Asientos.Lines.AccountCode = drCta["acctcode"].ToString();
                        Asientos.Lines.ContraAccount = "10.01.11.99.99";
                        Asientos.Lines.Credit = double.Parse(drCta["total"].ToString());
                        Asientos.Lines.Debit = 0;
                        Asientos.Lines.Add();
                    };
                };

                
                if (Asientos.Add() != 0)
                {
                    MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //--##################################################################################--
                //--Actualizar estado de registros de lotes a 'C' para cerrar los mismos
                //--##################################################################################--
                actualizar_transferencias();
                actualizar_transferencias_cab();
                actualizar_embarques();
                actualizar_embarques_cab();
                actualizar_estado();

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");               
                this.Close();
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCosteoHuevos_Load(object sender, EventArgs e)
        {
            
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultar_cantidades();
            consultar_cantidades_existentes();
            consultar_cuentas();
            txtCosto.Text = (total_ctas / cant_total).ToString("N2");
            //actualizar_embarques();
        }
        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManual.Checked == true)
            {
                txtCosto.ReadOnly = false;
                txtCosto.Focus();
            }
            else
            {
                txtCosto.ReadOnly = true;
                txtCosto.Text = (total_ctas / cant_total).ToString("N2");
            };
        }
    }
}
