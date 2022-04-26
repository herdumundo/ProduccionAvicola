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

namespace ProduccionAvicola
{
    public partial class frmCosteoHuevosNew : Form
    {
        //SAP
        Company empresa = new Company();

        Documents Entrada;
        ProductionOrders OrdenProduccion;
        Documents EmisionProduccion;
        Documents ReciboProduccion;
        JournalEntries Asientos;

        SqlDataAdapter daCantidades;
        SqlDataAdapter daCantidadesAgrp;
        SqlDataAdapter daMaples;
        SqlDataAdapter daMaplesReq;
        SqlDataAdapter daMaplesStock;
        SqlDataAdapter daTotales;
        SqlDataAdapter daCuentas;
        SqlDataAdapter daDetCuentas;
        SqlDataAdapter daDetCuentasFA;
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
        string strFecha = "";

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

        bool blnMaplesExt = true;

        #region ... A ...

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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
       
        #endregion

        #region ... B ...

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Este proceso puede tardar varios minutos. ¿Desea continuar?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                strFecha = convertirFecha(dtpFecha.Text);

                Cursor.Current = Cursors.WaitCursor;

                //--##################################################################################--
                //--Validacion de datos 
                //--##################################################################################--


                if (cant_total == 0)
                {
                    MessageBox.Show("No existen datos para procesamiento", "¡¡¡ ATENCION USUARIO !!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (double.Parse(txtCosto.Text) <= 0)
                {
                    MessageBox.Show("El Costo del huevo no puede ser menor o igual a cero (0)", "¡¡¡ ATENCION USUARIO !!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!blnMaplesExt)
                {
                    MessageBox.Show("Las cantidades requeridas de maples no están cubiertas. \nPor favor verifique en la pestaña Información Maples", "¡¡¡ ATENCION USUARIO !!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                tsProgBar.Maximum = 100;
                tsProgBar.Value = 0;

                empresa.StartTransaction();

                #region ... Creación entrada de Mercancías por el total de los huevos de la clasificadora ...

                //--##################################################################################--
                //--Crear entrada de mercancias por el total de los huevos de la clasificadora
                //--##################################################################################--


                if (chkManual.Checked == true)
                {
                    tot_cuentas = double.Parse(txtCosto.Text) * cant_total;
                }
                else
                {
                    tot_cuentas = double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString());
                };

                costo = tot_cuentas / cant_total;

                tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar ";
                //tsProgBar.Value++;
                fillProgressBar();

                Entrada = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);
                Entrada.DocDate = dtpFecha.Value;


                int xx = 0;

                //--##################################################################################--
                //--Linea para clasificadora A
                //--##################################################################################--

                if (cant_a != 0)
                {
                    tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar al Almacén CCHA...";
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHA";
                    Entrada.Lines.Quantity = cant_a - ext_a;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(0);
                    Entrada.Lines.LineTotal = (cant_a - ext_a) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(xx);
                    Entrada.Lines.BatchNumbers.Quantity = cant_a - ext_a;
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
                //--Linea para clasificadora B
                //--##################################################################################--

                if (cant_b != 0)
                {
                    tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar al Almacén CCHB...";
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHB";
                    Entrada.Lines.Quantity = cant_b - ext_b;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (cant_b - ext_b) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = cant_b - ext_b;
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

                if (cant_o != 0)
                {
                    tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar al Almacén OVO...";
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "OVO";
                    Entrada.Lines.Quantity = cant_o - ext_o;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (cant_o - ext_o) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = cant_o - ext_o;
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

                if (cant_h != 0)
                {
                    tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar al Almacén CCHH...";
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "CCHH";
                    Entrada.Lines.Quantity = cant_h - ext_h;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (cant_h - ext_h) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = cant_h - ext_h;
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

                if (cant_s != 0)
                {
                    tsStatLabl.Text = "Creando Entrada de Huevos Sin Clasificar al Almacén FS001...";
                    Entrada.Lines.ItemCode = "HVO-00001";
                    Entrada.Lines.WarehouseCode = "FS001";
                    Entrada.Lines.Quantity = cant_s - ext_s;
                    Entrada.Lines.AccountCode = "10.01.11.99.99";
                    Entrada.Lines.PriceAfterVAT = costo;
                    Entrada.Lines.SetCurrentLine(xx);
                    Entrada.Lines.LineTotal = (cant_s - ext_s) * costo;
                    Entrada.Lines.Currency = "GS";
                    Entrada.Lines.BatchNumbers.SetCurrentLine(0);
                    Entrada.Lines.BatchNumbers.Quantity = cant_s - ext_s;
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

                #endregion

                #region ... Creación de la Orden de Producción ...

                lotes_sin_clasificar();

                foreach (DataRow dr in ds.Tables["cantidadesAgrp"].Rows)
                {
                    switch (dr["tipo_huevo"].ToString())
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

                    //tsProgBar.Value++;
                    fillProgressBar();
                    tsStatLabl.Text = "Creando Ordenes, Emisiones y Recibos de Producción";
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

                    //tsProgBar.Value++;
                    tsStatLabl.Text = "Creando Emisión de Producción...";
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
                                        //if (clasif == "CCHB")
                                        //{
                                        //    System.Diagnostics.Debugger.Break();
                                        //}

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
                                        if (ds.Tables["lotesMP"].Rows[ilotes]["itemcode"].ToString() == it)
                                        {
                                            cant_disponible = double.Parse(ds.Tables["lotesMP"].Rows[ilotes]["quantity"].ToString());
                                            if (cant_disponible > 0)
                                            {
                                                EmisionProduccion.Lines.BatchNumbers.BatchNumber = ds.Tables["lotesMP"].Rows[ilotes]["distnumber"].ToString();

                                                String lot= ds.Tables["lotesMP"].Rows[ilotes]["distnumber"].ToString();
                                                if (cant_disponible >= (cant_orden - cant_asignada))
                                                {
                                                    EmisionProduccion.Lines.BatchNumbers.Quantity = cant_orden - cant_asignada;
                                                    ds.Tables["lotesMP"].Rows[ilotes]["quantity"] = cant_disponible - EmisionProduccion.Lines.BatchNumbers.Quantity;
                                                    String asdasd = ds.Tables["lotesMP"].Rows[ilotes]["quantity"].ToString();
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
                    //tsProgBar.Value++;

                    double totalCantidad = double.Parse(dr["cantidad"].ToString());
                    double lotesCantidad = 0;
                    tsStatLabl.Text = "Creando Recibo de Producción...";
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

                    sql_lotes = "select cantidad, cod_lote, cod_carrito, fecha_puesta, cod_clasificacion, estado_liberacion "
                    + "from lotes with (nolock) where convert(varchar, fecha, 103) = '" + strFecha + "' "
                    + " and tipo_huevo = '" + dr["tipo_huevo"].ToString() + "' "
                    + " and tipo_huevo not in ('RP', 'SC') "
                    + " and estado = 'A' and clasificadora = '" + dr["clasificadora"].ToString() + "' "
                    + " and estado_liberacion = 'L' "
                    + " union all "
                    + " select cantidad, cod_lote, cod_carrito, fecha_puesta, cod_clasificacion, estado_liberacion "
                    + " from lotes with (nolock) where convert(varchar, fecha, 103) = '" + strFecha + "' "
                    + " and tipo_huevo = '" + dr["tipo_huevo"].ToString() + "' "
                    + " and tipo_huevo not in ('RP', 'SC') "
                    + " and estado = 'A' and clasificadora = '" + dr["clasificadora"].ToString() + "' "
                    + " and RIGHT(estado_liberacion, 1) = 'L' "
                    + " and cod_lote in (select distinct cod_lote "
                    + " from lotes_retenidos with (nolock) where disposicion in (8,9,27,30) and estado_liberacion = 'L' and movimiento = 'A' "
                    + " and clasificadora = '" + dr["clasificadora"].ToString() + "') ";

                    //if (dr["tipo_huevo"].ToString() == "A" && dr["clasificadora"].ToString() == "B")
                    //{
                    //    System.Diagnostics.Debugger.Break();
                    //}
                    daLotes = new SqlDataAdapter(" exec [mae_cch_lotes_costeo] @fecha='" + strFecha + "',@tipo_huevo='" + dr["tipo_huevo"].ToString() + "',@clasificadora='" + dr["clasificadora"].ToString() + "' ", Global.conn_clasif);

                    if (ds.Tables.Contains("lotes"))
                    {
                        ds.Tables["lotes"].Clear();
                    };
                    daLotes.Fill(ds, "lotes");

                    //--##################################################################################--
                    //--Creamos un datareader del dataset lotes para cargar los lotes en el recibo de produccion
                    //--##################################################################################--
                    bool blnTemporal = false;

                    foreach (DataRow drLotes in ds.Tables["lotes"].Rows)
                    {
                        if (drLotes["cod_lote"].ToString() == "600208_20210723_FCO_1" &&
                            dr["clasificadora"].ToString() == "B" && dr["tipo_huevo"].ToString() == "G" && blnTemporal == false)
                        {
                            lotesCantidad = lotesCantidad + double.Parse(drLotes["cantidad"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.Quantity = double.Parse(drLotes["cantidad"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.BatchNumber = drLotes["cod_lote"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.ManufacturerSerialNumber = drLotes["cod_carrito"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.AddmisionDate = DateTime.Parse(drLotes["fecha_puesta"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.InternalSerialNumber = drLotes["cod_clasificacion"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.UserFields.Fields.Item("U_estliberacion").Value = drLotes["estado_liberacion"].ToString();
                            blnTemporal = true;
                        }
                        else if (drLotes["cod_lote"].ToString() == "600208_20210723_FCO_1" &&
                                 dr["clasificadora"].ToString() == "B" && dr["tipo_huevo"].ToString() == "G" && 
                                 blnTemporal == true)
                        {

                        }
                        else
                        {
                            lotesCantidad = lotesCantidad + double.Parse(drLotes["cantidad"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.Quantity = double.Parse(drLotes["cantidad"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.BatchNumber = drLotes["cod_lote"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.ManufacturerSerialNumber = drLotes["cod_carrito"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.AddmisionDate = DateTime.Parse(drLotes["fecha_puesta"].ToString());
                            ReciboProduccion.Lines.BatchNumbers.InternalSerialNumber = drLotes["cod_clasificacion"].ToString();
                            ReciboProduccion.Lines.BatchNumbers.UserFields.Fields.Item("U_estliberacion").Value = drLotes["estado_liberacion"].ToString();
                        }

                        //ReciboProduccion.Lines.BatchNumbers.
                        ReciboProduccion.Lines.BatchNumbers.Add();
                    }

                    //if (dr["clasificadora"].ToString() == "B")
                    //{
                        // MessageBox.Show("Total cantidad: " + totalCantidad.ToString() + " Total Lotes: " + lotesCantidad.ToString());

                        //if (totalCantidad == 51840)
                        //{
                        //    System.Diagnostics.Debugger.Break();
                        //}
                    //}

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

                #endregion

                #region ... Registrar asiento contable. Cuentas de Costos vs Cuenta Regularizadora ...
                double dblResto = 0;
                double dblDebito = 0;
                double dblDebitoTruncate = 0;
                double dblCredito = 0;
                double dblCreditoTotal = 0;
                //--##################################################################################--
                //--Registrar asiento contable. Cuentas de Costos vs Cuenta Regularizadora
                //--##################################################################################--
                //tsProgBar.Value++;
                fillProgressBar();
                tsStatLabl.Text = "Creando Asiento Cuenta Regularizadora...";
                Asientos = empresa.GetBusinessObject(BoObjectTypes.oJournalEntries);
                Asientos.TaxDate = dtpFecha.Value;//.AddDays(-1);
                Asientos.ReferenceDate = dtpFecha.Value;//.AddDays(-1);
                Asientos.DueDate = dtpFecha.Value;//.AddDays(-1);

                if (chkManual.Checked == true)
                {
                    #region //Carga manual 
                    //Carga manual 
                    Asientos.Lines.AccountCode = "10.01.11.99.02";
                    Asientos.Lines.ContraAccount = "10.01.11.99.99";
                    Asientos.Lines.Credit = Math.Round((cant_total * costo), 0);
                    dblCreditoTotal = Asientos.Lines.Credit;
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
                    #endregion

                    #region EN REVISION
                    //foreach (DataRow drCta in ds.Tables["detcuentas"].Rows)
                    //{
                    //    if (drCta["acctcode"].ToString().Trim() != "T")
                    //    {
                    //        Asientos.Lines.AccountCode = drCta["acctcode"].ToString();
                    //        Asientos.Lines.ContraAccount = "10.01.11.99.99";
                    //        dblCredito = ((cant_total * costo) * double.Parse(drCta["TOTAL CUENTAS"].ToString()));
                    //        Asientos.Lines.Credit = Math.Round(dblCredito, 0);//Math.Round(dblCreditoTruncate,2, MidpointRounding.AwayFromZero); //Math.Round(((cant_total * costo) * double.Parse(drCta["TOTAL CUENTAS"].ToString())),2, MidpointRounding.AwayFromZero);
                    //        dblCreditoTotal += Asientos.Lines.Credit;
                    //        //dblCredito = ((cant_total * costo) * double.Parse(drCta["TOTAL CUENTAS"].ToString()));
                    //        //dblCreditoTruncate = Math.Truncate(dblCredito * 100) / 100;
                    //        //Asientos.Lines.Credit = Math.Round(dblCreditoTruncate, 0);//Math.Round(dblCreditoTruncate,2, MidpointRounding.AwayFromZero); //Math.Round(((cant_total * costo) * double.Parse(drCta["TOTAL CUENTAS"].ToString())),2, MidpointRounding.AwayFromZero);
                    //        //dblResto -= Asientos.Lines.Credit; // Math.Round(((cant_total * costo) * double.Parse(drCta["TOTAL CUENTAS"].ToString())), 2);
                    //        Asientos.Lines.Debit = 0;
                    //        Asientos.Lines.Add();

                    //    }
                    //};
                    #endregion
                }
                else
                {
                    foreach (DataRow drCta in ds.Tables["detcuentas"].Rows)
                    {
                        if (drCta["acctcode"].ToString().Trim() != "T")
                        {
                            Asientos.Lines.AccountCode = drCta["acctcode"].ToString();
                            Asientos.Lines.ContraAccount = "10.01.11.99.99";
                            Asientos.Lines.Credit = Math.Round(double.Parse(drCta["total"].ToString()),0);
                            dblCreditoTotal += Asientos.Lines.Credit;
                            Asientos.Lines.Debit = 0;
                            Asientos.Lines.Add();
                        }
                    };
                };

                Asientos.Lines.AccountCode = "10.01.11.99.99"; //Cuenta regularizadora
                //dblDebito = cant_total * costo;
                //dblDebitoTruncate = Math.Truncate(dblDebito * 100) / 100;
                //Asientos.Lines.Debit = Math.Round(dblDebitoTruncate, 0);//Math.Round(dblDebitoTruncate,2, MidpointRounding.AwayFromZero); //  Math.Round(cant_total * costo, 2,  MidpointRounding.AwayFromZero); //Suma de las cuentas de gastos o total cuenta regularizadora
                Asientos.Lines.Debit = dblCreditoTotal;
                Asientos.Lines.Credit = 0;
                //dblResto = Asientos.Lines.Debit;
                Asientos.Memo = "Costeo de huevo fecha " + dtpFecha.Value.ToShortDateString();
                Asientos.Lines.Add();

                //--##################################################################################--
                //--Consulta de cuentas de consumo
                //--##################################################################################--

                //Asientos.SaveXML("C:\\kk\\Asiento.xml");
                if (Asientos.Add() != 0)
                {
                    MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                #region ... Actualiza el estado de registros de lotes a 'C' para cerrar los mismos ...
         
                //--##################################################################################--
                //--Actualizar estado de registros de lotes a 'C' para cerrar los mismos
                //--##################################################################################--
                //tsProgBar.Value++;
                fillProgressBar();
                tsStatLabl.Text = "Actualizando transferencias...";
                actualizar_transferencias();
                actualizar_transferencias_cab();

                //tsProgBar.Value++;
                fillProgressBar();
                tsStatLabl.Text = "Actualizando Embarques...";
                actualizar_embarques();
                actualizar_embarques_cab();

                //tsProgBar.Value++;
                fillProgressBar();
                tsStatLabl.Text = "Actualizando Estado...";
                actualizar_estado();

                //tsProgBar.Value = tsProgBar.Maximum;
                #endregion

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                fillProgressBar(1);
                MessageBox.Show("Proceso finalizado");
                this.Close();
            }

            catch (Exception ex)
            {
                if (empresa.InTransaction)
                {
                    empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                };

                MessageBox.Show(ex.Message.ToString() + " " + ex.StackTrace.ToString(),
                                "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            blnMaplesExt = true;

            consultar_cantidades();

            consultar_cantidades_existentes();

            consultar_cuentas();

            if (cant_total == 0)
            {
                txtCosto.Text = "0";
            }
            else
            {
                txtCosto.Text = (total_ctas / cant_total).ToString("N2");
            }


            //if (cant_total > 0 && double.Parse(txtCosto.Text) > 0 && blnMaplesExt)
            //{
            //    btnAceptar.Enabled = true;
            //}

            //actualizar_embarques();
        }

        #endregion

        #region ... C ...

        private void cambiaColoresColumna(DataGridView dgv, int rowdgv, int coldgvS, int coldgvR)
        {
            int intSto = int.Parse(dgvMaplesRequStock[coldgvS, rowdgv].Value.ToString());
            int intReq = int.Parse(dgvMaplesRequStock[coldgvR, rowdgv].Value.ToString());

            if (intSto >= intReq)
            {
                dgvMaplesRequStock.Rows[rowdgv].Cells[coldgvS].Style.BackColor = Color.Green;
                dgvMaplesRequStock.Rows[rowdgv].Cells[coldgvS].Style.ForeColor = Color.White;
            }
            else
            {
                dgvMaplesRequStock.Rows[rowdgv].Cells[coldgvS].Style.BackColor = Color.Red;
                dgvMaplesRequStock.Rows[rowdgv].Cells[coldgvS].Style.ForeColor = Color.White;
                blnMaplesExt = false;
            }
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

            foreach (DataRow dr in ds.Tables["existencia"].Rows)
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

            strFecha = convertirFecha(dtpFecha.Text);
            sql_cantidades = "";

            sql_cantidades = "WITH " +
                             "totales(tipohuevo, CCHA, CCHB, CCHO, CCHH, CCFS, Totales) AS " +
                             "(SELECT tipo_huevo, ISNULL(A, 0) AS CCHA, ISNULL(B, 0) AS CCHB, " +
                             "                    ISNULL(O, 0) AS CCHO, ISNULL(H, 0) AS CCHH, " +
                             "                    ISNULL(S, 0) AS S, ISNULL(A, 0) + ISNULL(B, 0) + ISNULL(O, 0) + ISNULL(H, 0) + ISNULL(S, 0) AS TOTAL " +
                             "FROM(SELECT tipo_huevo, clasificadora, SUM(cantidad) as cantidad " +
                             "     FROM v_lotes_general with(nolock) " +
                             "     WHERE clasificadora IN('A', 'B', 'O', 'H', 'S') AND fecha = '" + strFecha + "' AND tipo_huevo <> 'SC' " +
                             "     GROUP BY tipo_huevo, clasificadora) AS SourceTable PIVOT(SUM([CANTIDAD]) FOR[clasificadora] IN([A],[B],[O],[H],[S])) AS pvt), " +
                             "detalles(tipohuevo, CCHA, CCHB, CCHO, CCHH, CCFS, Totales) AS " +
                             "(SELECT tipo_huevo, ISNULL([A], 0)CCHA, ISNULL([B], 0)CCHB, " +
                             "                    ISNULL([O], 0)CCHO, ISNULl([H], 0)CCHH, " +
                             "                    ISNULL([S],0)CCFS, ISNULL(A, 0) + ISNULL(B, 0) + ISNULL(O, 0) + ISNULL(H, 0) + ISNULL(S, 0) AS TOTAL " +
                             "FROM(SELECT tipo_huevo, clasificadora, SUM(cantidad) as cantidad " +
                             "     FROM v_lotes_general with(nolock) " +
                             "     WHERE clasificadora IN('A', 'B', 'O', 'H', 'S') AND fecha = '" + strFecha + "' AND tipo_huevo <> 'SC' " +
                             "     GROUP BY grouping sets(tipo_huevo, clasificadora)) AS TABLA PIVOT(SUM(cantidad) FOR[clasificadora] IN([A],[B],[O],[H],[S])) as P) " +
                             "SELECT tipohuevo, CCHA, CCHB, CCHO, CCHH, CCFS, Totales FROM totales " +
                             "UNION " +
                             "SELECT 'Totales',SUM(CCHA),SUM(CCHB),SUM(CCHO),SUM(CCHH),SUM(CCFS),SUM(Totales) FROM detalles " +
                             "Order by tipohuevo";

            daCantidades = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("cantidades"))
            {
                ds.Tables["cantidades"].Clear();
            };

            daCantidades.Fill(ds, "cantidades");

            if (ds.Tables["cantidades"].Rows.Count <= 1)
            {
                return;
            }

            dgvCantidades.DataSource = ds.Tables["cantidades"];

            sql_cantidades = "WITH " +
                             "totales(tipohuevo, CodMaple, CCHA, CCHB, CCHO, CCHH, CCFS, Totales, Porc) AS " +
                             "(SELECT tipo_huevo, CodMaple, CEILING(ISNULL(A, 0) * PorcMap) AS CCHA, " +
                             "CEILING(ISNULL(B, 0) * PorcMap) AS CCHB, " +
                             "CEILING(ISNULL(O, 0) * PorcMap) AS CCHO, " +
                             "CEILING(ISNULL(H, 0) * PorcMap) AS CCHH, " +
                             "CEILING(ISNULL(S, 0) * PorcMap) AS S, " +
                             "CEILING((ISNULL(A, 0) + ISNULL(B, 0) + ISNULL(O, 0) + ISNULL(H, 0) + ISNULL(S, 0)) * PorcMap) AS TOTAL, " +
                             "PorcMap " +
                             "FROM(SELECT tipo_huevo, CodMaple, clasificadora, SUM(cantidad) as cantidad, PorcMap " +
                             "FROM v_lotes_general with(nolock) INNER JOIN v_PorcMaples with(nolock) ON tipo_huevo = CodeA " +
                             "WHERE clasificadora IN('A', 'B', 'O', 'H', 'S') AND fecha = '" + strFecha + "' " +
                             "GROUP BY tipo_huevo, clasificadora, PorcMap, CodMaple) AS SourceTable PIVOT(SUM([CANTIDAD]) FOR[clasificadora] IN([A],[B],[O],[H],[S])) AS pvt) " +
                             "SELECT tipohuevo, CodMaple, CCHA, CCHB, CCHO, CCHH, CCFS, Totales, Porc  FROM totales ";

            daMaples = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("MaplesxClasif"))
            {
                ds.Tables["MaplesxClasif"].Clear();
            };

            daMaples.Fill(ds, "MaplesxClasif");
            dgvMaplesTipoHuevo.DataSource = ds.Tables["MaplesxClasif"];

            //sql_cantidades = "WITH " +
            //                 "totales(tipohuevo, CodMaple, CCHA, CCHB, CCHO, CCHH, CCFS, Totales, MAPA) AS " +
            //                 "(SELECT tipo_huevo, CodMaple, CEILING(ISNULL(A, 0) * PorcMap) AS CCHA, " +
            //                 "CEILING(ISNULL(B, 0) * PorcMap) AS CCHB, " +
            //                 "CEILING(ISNULL(O, 0) * PorcMap) AS CCHO, " +
            //                 "CEILING(ISNULL(H, 0) * PorcMap) AS CCHH, " +
            //                 "CEILING(ISNULL(S, 0) * PorcMap) AS S, " +
            //                 "CEILING((ISNULL(A, 0) + ISNULL(B, 0) + ISNULL(O, 0) + ISNULL(H, 0) + ISNULL(S, 0)) * PorcMap) AS TOTAL, " +
            //                 "PorcMap " +
            //                 "FROM(SELECT tipo_huevo, CodMaple, clasificadora, SUM(cantidad) as cantidad, PorcMap " +
            //                 "     FROM v_lotes_general with(nolock) INNER JOIN v_PorcMaples with(nolock) ON tipo_huevo = CodeA " +
            //                 "     WHERE clasificadora IN('A', 'B', 'O', 'H', 'S') AND fecha = '" + strFecha + "' " +
            //                 "GROUP BY tipo_huevo, clasificadora, PorcMap, CodMaple) AS SourceTable PIVOT(SUM([CANTIDAD]) FOR[clasificadora] IN([A],[B],[O],[H],[S])) AS pvt) " +
            //                 "SELECT CodMaple, SUM(CCHA) AS CCHA, SUM(CCHB) AS CCHB, SUM(CCHO) AS CCHO, SUM(CCHH) AS CCHH, SUM(CCFS) AS CCFS  FROM totales " +
            //                 "GROUP BY CodMaple ";

            sql_cantidades = "WITH " +
                             "totales(tipohuevo, CodMaple, CCHA, CCHB, CCHO, CCHH, CCFS, MAPA) AS " +
                             "(SELECT tipo_huevo, CodMaple, CEILING(ISNULL(A, 0)) AS CCHA, " +
                             "CEILING(ISNULL(B, 0)) AS CCHB, " +
                             "CEILING(ISNULL(O, 0)) AS CCHO, " +
                             "CEILING(ISNULL(H, 0)) AS CCHH, " +
                             "CEILING(ISNULL(S, 0)) AS S,  " +
                             "PorcMap " +
                             "FROM(SELECT tipo_huevo, CodMaple, clasificadora, CEILING(((SUM(cantidad) / qtotal) * quantity)) as cantidad, PorcMap " +
                             "     FROM v_lotes_general with(nolock) INNER JOIN v_PorcMaples with(nolock) ON tipo_huevo = CodeA " +
                             "     WHERE clasificadora IN('A', 'B', 'O', 'H', 'S') AND fecha = '" + strFecha + "' " +
                             "GROUP BY tipo_huevo, clasificadora, PorcMap, CodMaple, qtotal, quantity) AS SourceTable PIVOT(SUM([CANTIDAD]) FOR[clasificadora] IN([A],[B],[O],[H],[S])) AS pvt) " +
                             "SELECT CodMaple, SUM(CCHA) AS CCHA, SUM(CCHB) AS CCHB, SUM(CCHO) AS CCHO, SUM(CCHH) AS CCHH, SUM(CCFS) AS CCFS  FROM totales " +
                             "GROUP BY CodMaple  ";

            daMaplesReq = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("MaplesReq"))
            {
                ds.Tables["MaplesReq"].Clear();
            };

            daMaplesReq.Fill(ds, "MaplesReq");
            //dgvMaplesRequStock.DataSource = ds.Tables["MaplesReq"];

            int rowDGV = 0;

            foreach (DataRow rowReq in ds.Tables["MaplesReq"].Rows)
            {
                dgvMaplesRequStock.Rows.Add();
                dgvMaplesRequStock.Rows[rowDGV].Cells[0].Value = rowReq["CodMaple"];
                dgvMaplesRequStock.Rows[rowDGV].Cells[1].Value = rowReq["CCHA"];
                dgvMaplesRequStock.Rows[rowDGV].Cells[3].Value = rowReq["CCHB"];
                dgvMaplesRequStock.Rows[rowDGV].Cells[5].Value = rowReq["CCHO"];
                dgvMaplesRequStock.Rows[rowDGV].Cells[7].Value = rowReq["CCHH"];
                dgvMaplesRequStock.Rows[rowDGV].Cells[9].Value = rowReq["CCFS"];
                rowDGV++;
            }

            sql_cantidades = "SELECT * FROM v_mae_stock_maples_clasificadora";

            daMaplesStock = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("MaplesStock"))
            {
                ds.Tables["MaplesStock"].Clear();
            };

            daMaplesStock.Fill(ds, "MaplesStock");

            rowDGV = 0;

            foreach (DataRow rowStock in ds.Tables["MaplesStock"].Rows)
            {
                if (rowStock["CodMaple"].ToString() == "CART-00021")
                {
                    rowDGV = 1;
                }

                dgvMaplesRequStock[2, rowDGV].Value = rowStock["CCHA"];
                cambiaColoresColumna(dgvMaplesRequStock, rowDGV, 2, 1);

                dgvMaplesRequStock[4, rowDGV].Value = rowStock["CCHB"];
                cambiaColoresColumna(dgvMaplesRequStock, rowDGV, 4, 3);

                dgvMaplesRequStock[6, rowDGV].Value = rowStock["CCHO"];
                cambiaColoresColumna(dgvMaplesRequStock, rowDGV, 6, 5);

                dgvMaplesRequStock[8, rowDGV].Value = rowStock["CCHH"];
                cambiaColoresColumna(dgvMaplesRequStock, rowDGV, 8, 7);

                dgvMaplesRequStock[10, rowDGV].Value = rowStock["CCFS"];
                cambiaColoresColumna(dgvMaplesRequStock, rowDGV, 10, 9);

            }

            dgvMaplesRequStock.Refresh();

            sql_cantidades = "select tipo_huevo, sum(cantidad) as cantidad, clasificadora " +
                             "from v_lotes_general with (nolock) " +
                             "where fecha = '" + strFecha + "' and clasificadora is not null AND tipo_huevo <> 'SC' " +
                             "group by tipo_huevo, clasificadora ";
            //     sql_cantidades = sql_cantidades + " where fecha = '" + dtpFecha.Value.ToShortDateString() + "' ";
            // sql_cantidades = sql_cantidades + " where fecha = '01/04/2021' ";
            //sql_cantidades = sql_cantidades + " and tipo_huevo = 'D' ";

            daCantidadesAgrp = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);

            if (ds.Tables.Contains("cantidadesAgrp"))
            {
                ds.Tables["cantidadesAgrp"].Clear();
            };

            daCantidadesAgrp.Fill(ds, "cantidadesAgrp");

            foreach (DataRow dr in ds.Tables["cantidadesAgrp"].Rows)
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

            cant_total = (cant_a + cant_b + cant_h + cant_o + cant_s);

            //lblTotalClaA.Text = cant_a.ToString();
            //lblTotalClaB.Text = cant_b.ToString();
            //lblTotalClaH.Text = cant_h.ToString();
            //lblTotalFS.Text = cant_s.ToString();
            //lblTotalOvo.Text = cant_o.ToString();
            //txtHuevosSinClasificar.Text = (cant_a + cant_b + cant_h + cant_o + cant_s).ToString();
            //cant_total = int.Parse(txtHuevosSinClasificar.Text);

        }

        private void consultar_cuentas()
        {
            total_ctas = 0;
            strFecha = convertirFecha(dtpFecha.Text);
            sql_cuentas = "select (convert(numeric(15,2), isnull(sum(debit-credit),0))) as total "
            + " from OJDT a with (nolock)  "
            + " inner join JDT1 b with (nolock) on a.TransId = b.TransId "
            + " where b.Account in ('10.01.11.99.08', '10.01.11.99.05', '10.01.11.99.02') "
            + " and a.taxdate = '" + strFecha + "' ";
            //+ " and a.taxdate = '" + dtpFecha.Value.ToShortDateString() + "' ";
            daCuentas = new SqlDataAdapter(sql_cuentas, Global.conn);

            if (ds.Tables.Contains("cuentas"))
            {
                ds.Tables["cuentas"].Clear();
            };

            dgvCuentas.Rows.Clear();

            if (daCuentas.Fill(ds, "cuentas") > 0)
            {
                if (double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString()) != 0.00)
                {
                    total_ctas = double.Parse(ds.Tables["cuentas"].Rows[0]["total"].ToString());

                    //sql_detCuentas = "select (convert(numeric, isnull(sum(debit-credit),0))) as total, b.account as acctcode ";
                    //sql_detCuentas = sql_detCuentas + "from ojdt a with (nolock) ";
                    //sql_detCuentas = sql_detCuentas + "inner join JDT1 b with (nolock) on a.transid = b.transid ";
                    //sql_detCuentas = sql_detCuentas + "where b.account in ('10.01.11.99.02', '10.01.11.99.08', '10.01.11.99.05') ";
                    //sql_detCuentas = sql_detCuentas + "and b.ContraAct not in ('10.01.11.99.99') ";
                    //sql_detCuentas = sql_detCuentas + "and a.taxdate = '" + dtpFecha.Value.AddDays(-1).ToShortDateString() + "' ";
                    //sql_detCuentas = sql_detCuentas + "and a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' ";
                    //sql_detCuentas = sql_detCuentas + " and a.taxdate in ('31/12/2015', '01/01/2016') ";
                    //sql_detCuentas = sql_detCuentas + "group by b.account ";

                    //sql_detCuentas = "select b.account as acctcode, c.AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total " +
                    //                 "from ojdt a with(nolock) inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "inner join OACT c with(nolock) on b.account = c.AcctCode " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.08', '10.01.11.99.05') and a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' " +
                    //                 "group by b.Account, c.AcctName " +
                    //                 "UNION ALL " +
                    //                 "SELECT ' ' as acctcode, SPACE(50) + 'TOTAL' as AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total " +
                    //                 "from ojdt a with(nolock) " +
                    //                 "inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                    //                 "a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' ";

                    //sql_detCuentas = "select b.account as acctcode, c.AcctName, " +
                    //                 "(convert(numeric, isnull(sum(debit - credit), 0))) as total, " +
                    //                 "(convert(numeric, isnull(sum(debit - credit), 0))) / (SELECT(convert(numeric, isnull(sum(debit - credit), 0))) " +
                    //                 "                                                      from ojdt a with(nolock) " +
                    //                 "                                                      inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "                                                      where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                    //                 "                                                      a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "') AS 'TOTAL CUENTAS' " +
                    //                 "from ojdt a with(nolock) inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "                         inner join OACT c with(nolock) on b.account = c.AcctCode " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.08', '10.01.11.99.05') and a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' " +
                    //                 "group by b.Account, c.AcctName " +
                    //                 "UNION ALL " +
                    //                 "SELECT ' ' as acctcode, SPACE(50) + 'TOTAL' as AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total, '100' AS 'TOTAL CUENTAS' " +
                    //                 "from ojdt a with(nolock)  " +
                    //                 "inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                    //                 "a.taxdate < '" + dtpFecha.Value.ToShortDateString() + "' ";

                    sql_detCuentas = "select b.account as acctcode, c.AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total, " +
                                      "      ROUND((convert(numeric, isnull(sum(debit - credit), 0))) / (SELECT(convert(numeric, isnull(sum(debit - credit), 0))) " +
                                     "                                                                   from ojdt a with(nolock) " +
                                     "                                                                   inner join JDT1 b with(nolock) on a.transid = b.transid " +
                                     "                                                                   where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                                     "                                                                   a.taxdate = '" + strFecha + "'),4) AS 'TOTAL CUENTAS' " +
                                     "from ojdt a with(nolock) inner join JDT1 b with(nolock) on a.transid = b.transid " +
                                     "inner join OACT c with(nolock) on b.account = c.AcctCode " +
                                     "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and a.taxdate = '" + strFecha + "' " +
                                     "group by b.Account, c.AcctName " +
                                     "UNION ALL " +
                                     "SELECT 'T ' as acctcode, SPACE(50) + 'TOTAL' as AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total, '100' AS 'TOTAL CUENTAS' " +
                                     "from ojdt a with(nolock) " +
                                     "inner join JDT1 b with(nolock) on a.transid = b.transid " +
                                     "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                                     "a.taxdate = '" + strFecha + "' " +
                                     "order by acctcode ";

                    daDetCuentas = new SqlDataAdapter(sql_detCuentas, Global.conn);

                    if (ds.Tables.Contains("detcuentas"))
                    {
                        ds.Tables["detcuentas"].Clear();
                    };
                    daDetCuentas.Fill(ds, "detcuentas");

                    //dgvCuentas.DataSource = ds.Tables["detcuentas"];
                    int rowDGV = 0;

                    dgvCuentas.Rows.Clear();

                    foreach (DataRow rowReq in ds.Tables["detcuentas"].Rows)
                    {

                        dgvCuentas.Rows.Add();

                        if (rowReq["acctcode"].ToString().Trim() != "T")
                        {
                            dgvCuentas.Rows[rowDGV].Cells[0].Value = rowReq["acctcode"];
                        }

                        string strPorc = rowReq["TOTAL CUENTAS"].ToString();
                        int intPos = strPorc.IndexOf(",");
                        string strEntero = "";

                        if (intPos > 0)
                        {
                            string[] word = strPorc.Split(',');
                            strEntero = word[0] + "." + word[1].Substring(0, 4);
                        }

                        dgvCuentas.Rows[rowDGV].Cells[1].Value = rowReq["AcctName"];
                        dgvCuentas.Rows[rowDGV].Cells[2].Value = rowReq["total"];

                        if (rowReq["acctcode"].ToString().Trim() == "T")
                        {
                            dgvCuentas.Rows[rowDGV].Cells[3].Value = strEntero;                  //rowReq["TOTAL CUENTAS"];
                        }
                        else
                        {
                            dgvCuentas.Rows[rowDGV].Cells[3].Value = (double.Parse(rowReq["TOTAL CUENTAS"].ToString()) * 100).ToString();
                        }
                        rowDGV++;
                    }

                    #region ... OJO CON ESTO ...
                    //sql_detCuentas = "select b.account as acctcode, c.AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total, " +
                    //                  "      ROUND((convert(numeric, isnull(sum(debit - credit), 0))) / (SELECT(convert(numeric, isnull(sum(debit - credit), 0))) " +
                    //                 "                                                                   from ojdt a with(nolock) " +
                    //                 "                                                                   inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "                                                                   where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                    //                 "                                                                   a.taxdate < '" + strFecha + "'),4) AS 'TOTAL CUENTAS' " +
                    //                 "from ojdt a with(nolock) inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "inner join OACT c with(nolock) on b.account = c.AcctCode " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and a.taxdate < '" + strFecha + "' " +
                    //                 "group by b.Account, c.AcctName " +
                    //                 "UNION ALL " +
                    //                 "SELECT 'T ' as acctcode, SPACE(50) + 'TOTAL' as AcctName, (convert(numeric, isnull(sum(debit - credit), 0))) as total, '100' AS 'TOTAL CUENTAS' " +
                    //                 "from ojdt a with(nolock) " +
                    //                 "inner join JDT1 b with(nolock) on a.transid = b.transid " +
                    //                 "where b.account in ('10.01.11.99.02', '10.01.11.99.05', '10.01.11.99.08') and " +
                    //                 "a.taxdate < '" + strFecha + "' " +
                    //                 "order by acctcode ";

                    //daDetCuentasFA = new SqlDataAdapter(sql_detCuentas, Global.conn);

                    //if (ds.Tables.Contains("detcuentasFA"))
                    //{
                    //    ds.Tables["detcuentasFA"].Clear();
                    //};

                    //daDetCuentasFA.Fill(ds, "detcuentasFA");

                    ////dgvCuentas.DataSource = ds.Tables["detcuentas"];
                    //rowDGV = 0;

                    //dgvCtasFA.Rows.Clear();

                    //foreach (DataRow rowReq in ds.Tables["detcuentasFA"].Rows)
                    //{

                    //    dgvCtasFA.Rows.Add();

                    //    if (rowReq["acctcode"].ToString().Trim() != "T")
                    //    {
                    //        dgvCtasFA.Rows[rowDGV].Cells[0].Value = rowReq["acctcode"];
                    //    }

                    //    string strPorc = rowReq["TOTAL CUENTAS"].ToString();
                    //    int intPos = strPorc.IndexOf(",");
                    //    string strEntero = "";

                    //    if (intPos > 0)
                    //    {
                    //        string[] word = strPorc.Split(',');
                    //        strEntero = word[0] + "." + word[1].Substring(0, 4);
                    //    }

                    //    dgvCtasFA.Rows[rowDGV].Cells[1].Value = rowReq["AcctName"];
                    //    dgvCtasFA.Rows[rowDGV].Cells[2].Value = rowReq["total"];

                    //    if (rowReq["acctcode"].ToString().Trim() == "T")
                    //    {
                    //        dgvCtasFA.Rows[rowDGV].Cells[3].Value = strEntero;                  //rowReq["TOTAL CUENTAS"];
                    //    }
                    //    else
                    //    {
                    //        dgvCtasFA.Rows[rowDGV].Cells[3].Value = (double.Parse(rowReq["TOTAL CUENTAS"].ToString()) * 100).ToString();
                    //    }
                    //    rowDGV++;
                    //}
                    #endregion

                }
                else
                {
                    MessageBox.Show("No se han registrado movimientos de Producción Primaria");
                    return;
                }
            };

        }

        private string convertirFecha(string strF)
        {
            string xFecha = "";
            DateTime dtFecha = DateTime.Parse(strF);

            xFecha = dtFecha.Day.ToString().PadLeft(2, '0') + "/" + dtFecha.Month.ToString().PadLeft(2, '0') + "/" + dtFecha.Year.ToString();

            return xFecha;
        }

        #endregion

        #region ... F ...

        public frmCosteoHuevosNew()
        {
            InitializeComponent();
        }

        private static frmCosteoHuevosNew frmDefInstance;

        public static frmCosteoHuevosNew DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmCosteoHuevosNew();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }

        private void frmCosteoHuevos_Load(object sender, EventArgs e)
        {

        }

        private void fillProgressBar(int intTipo = 0)
        {
            if (intTipo == 1)
            {
                if (tsProgBar.Value < tsProgBar.Maximum)
                {
                    tsProgBar.Value = tsProgBar.Maximum;
                }

            }
            else
            {
                if (tsProgBar.Value < tsProgBar.Maximum)
                {
                    tsProgBar.Value++;
                }
            }
        }

        #endregion

        #region ... L ...

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
            sql_lotesMP = "" +
                "   select " +
             "       obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber,   convert(int, obtq.quantity) as Quantity  " +
           //    "       obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber,   convert(numeric(12, 2), obtq.quantity) as Quantity  " +
             "   from " +
                "       obtq with (nolock)   " +
                "       inner join obtn with (nolock) on OBTQ.ItemCode = OBTN.ItemCode   and OBTQ.SysNumber = OBTN.SysNumber  " +
                "   where" +
                "       obtq.Quantity > 0 and obtq.whscode = '" + clasif + "'  and obtn.itemcode = '" + it + "'  order by 5 desc, 2, 3 ";
            daLotesMP = new SqlDataAdapter(sql_lotesMP, Global.conn);
            if (ds.Tables.Contains("lotesMP"))
            {
                ds.Tables["lotesMP"].Clear();
            };
            daLotesMP.Fill(ds, "lotesMP");
        }

        private void lotes_disp_maples()
        {
            sql_lotesDMP = "" +
                "   select " +
                "       obtn.sysnumber, OBTQ.WhsCode, obtn.itemcode, obtn.DistNumber,  convert(numeric(12, 2), obtq.quantity) as Quantity  " +
                "   from " +
                "       obtq with (nolock)  " +
                "       inner join obtn with (nolock) on OBTQ.ItemCode = OBTN.ItemCode  and OBTQ.SysNumber = OBTN.SysNumber   " +
                "   where " +
                "       obtq.Quantity > 500 and obtq.whscode = '" + clasif + "'";
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

        #endregion

        

    }
}
