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
    public partial class frmEntradacs : Form
    {
        //SAP
        Company empresa = new Company();
        Documents Entrada;

        SqlDataAdapter daLotes;
        SqlDataAdapter daTotalCla;
        string sql_lotes;
        string sql_totalCla;

        public frmEntradacs()
        {
            InitializeComponent();
        }

        private void consultar_cantidades()
        {
            sql_totalCla = "select isnull(SUM(cantidad), 0) as cantidad ";
            sql_totalCla = sql_totalCla + " from lotes ";
            //sql_totalCla = sql_totalCla + " where convert(varchar, fecha, 103) = '" + dtpFecha.Value.ToShortDateString() + "'";
            sql_totalCla = sql_totalCla + " /*and*/ where  clasificadora = '" + txtClasificadora.Text + "' ";
            sql_totalCla = sql_totalCla + " and tipo_huevo = '" + txtTipoHuevo.Text + "' ";
            sql_totalCla = sql_totalCla + " and estado = 'A' ";
            daTotalCla = new SqlDataAdapter(sql_totalCla, Global.conn_clasif);

            if (ds.Tables.Contains("totalClaA"))
            {
                ds.Tables["totalClaA"].Clear();
            };
            if (daTotalCla.Fill(ds, "totalClaA") > 0)
            {
                if (ds.Tables["totalClaA"].Rows[0]["cantidad"].ToString() != null)
                {
                    lblTotalClaA.Text = ds.Tables["totalClaA"].Rows[0]["cantidad"].ToString();
                }

            }
            else
            {
                MessageBox.Show("No existen datos a procesar");
                return;
            }
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
                SqlParameter tipoH = new SqlParameter("@tipo_huevo", SqlDbType.VarChar, 3);
                tipoH.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(tipoH);
                SqlParameter Clasif = new SqlParameter("@clasificadora", SqlDbType.VarChar, 3);
                Clasif.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(Clasif);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                tipoH.Value = txtTipoHuevo.Text;
                Clasif.Value = txtClasificadora.Text;
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
                throw new Exception(ex.Message);
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

                //--##################################################################################--
                //--Consulta de lotes por tipo de huevo
                //--##################################################################################--

                sql_lotes = "select cantidad, cod_lote, cod_carrito, fecha_puesta ";
                //sql_lotes = sql_lotes + "from lotes where convert(varchar, fecha, 103) = '" + dtpFecha.Value.ToShortDateString() + "'  ";
                sql_lotes = sql_lotes + " from lotes where ";
                sql_lotes = sql_lotes + " /*and */ tipo_huevo = '" + txtTipoHuevo.Text + "' ";
                sql_lotes = sql_lotes + " and estado = 'A' and clasificadora = '" + txtClasificadora.Text + "' ";
                daLotes = new SqlDataAdapter(sql_lotes, Global.conn_clasif);
                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };
                daLotes.Fill(ds, "lotes");

                Entrada = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                Entrada.DocDate = dtpFecha.Value;
                Entrada.TaxDate = dtpFecha.Value;
                

                //--##################################################################################--
                //--Linea para clasificadora A
                //--##################################################################################--
                if (txtTipoHuevo.Text == "GI")
                {
                    Entrada.Lines.ItemCode = "1";
                }
                else if (txtTipoHuevo.Text == "J")
                {
                    Entrada.Lines.ItemCode = "2";
                }
                else if (txtTipoHuevo.Text == "S")
                {
                    Entrada.Lines.ItemCode = "3";
                }
                else if (txtTipoHuevo.Text == "A")
                {
                    Entrada.Lines.ItemCode = "4";
                }
                else if (txtTipoHuevo.Text == "B")
                {
                    Entrada.Lines.ItemCode = "5";
                }
                else if (txtTipoHuevo.Text == "C")
                {
                    Entrada.Lines.ItemCode = "6";
                }
                else if (txtTipoHuevo.Text == "D")
                {
                    Entrada.Lines.ItemCode = "7";
                };

                
                if (txtClasificadora.Text == "A")
                {
                    Entrada.Lines.WarehouseCode = "CCHA";
                }
                else
                {
                    Entrada.Lines.WarehouseCode = "CCHB";
                };                
                Entrada.Lines.Quantity = double.Parse(lblTotalClaA.Text);
                Entrada.Lines.AccountCode = "3.04.01.01.01";
                Entrada.Lines.PriceAfterVAT = 225.14;//costo;
                Entrada.Lines.SetCurrentLine(0);
                Entrada.Lines.LineTotal = double.Parse(lblTotalClaA.Text) * 225.14;
                Entrada.Lines.Currency = "GS";

                foreach (DataRow drLotes in ds.Tables["lotes"].Rows)
                {
                    Entrada.Lines.BatchNumbers.Quantity = double.Parse(drLotes["cantidad"].ToString());
                    Entrada.Lines.BatchNumbers.BatchNumber = drLotes["cod_lote"].ToString();
                    Entrada.Lines.BatchNumbers.ManufacturerSerialNumber = drLotes["cod_carrito"].ToString();
                    Entrada.Lines.BatchNumbers.AddmisionDate = DateTime.Parse(drLotes["fecha_puesta"].ToString()); 
                    Entrada.Lines.BatchNumbers.Add();
                };

                Entrada.Lines.Add();

                if (Entrada.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };

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

        private void dtpFecha_Leave(object sender, EventArgs e)
        {
            consultar_cantidades();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntradacs_Load(object sender, EventArgs e)
        {

            
        }
    }
}
