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
    public partial class frmDevHerramientas : Form
    {
        Company empresa = new Company();

        StockTransfer Transferencia;

        SqlDataAdapter daManejo_Articulo;
        SqlDataAdapter daManejo_Articulo1;
        SqlDataAdapter daEncargado;

        string sql_Encargado;
        string sql_man_Articulo;
        string sql_man_Articulo1;
        string Codigo;
        string sql_codigo;

        int Cantidad;
        int Encargado_cab;
        int Ubicacion_cab;

        int cantidad_a_devolver;
        int Cantidad_Prestada;

        int nro_transferencia;
        SqlDataAdapter daCodigo;
        double cantidad_actual;
        double cantidad_devolucion;

        double nroPrestamo;
        int docentry;

        public frmDevHerramientas()
        {
            InitializeComponent();
        }
        private static frmDevHerramientas frmDefInstance;
        public static frmDevHerramientas DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmDevHerramientas();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
            empresa.UserName = Global.usuario;
            empresa.Password = Global.password;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Debe cargar un código!");
                    txtCodigo.Focus();
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
                        Transferencia.DocDate = DateTime.Now.Date;
                        Transferencia.Comments = "Devolución de Herramientas";

                        //##### Asocia el encargado y la ubicacion en la transferencia #####//

                        if ((dvgGrilla1.CurrentCell as DataGridViewCheckBoxCell) != null)
                        {
                            int i = 0;
                            foreach (DataGridViewRow dr in dvgGrilla1.Rows)
                            {
                                bool ischecked = (bool)dr.Cells[0].EditedFormattedValue;

                                if (ischecked)
                                {
                                    Cantidad = int.Parse(dr.Cells[1].Value.ToString());
                                    Codigo = dr.Cells[3].Value.ToString();

                                    Transferencia.SalesPersonCode = Encargado_cab;

                                    Transferencia.FromWarehouse = "PREST";
                                    Transferencia.Lines.WarehouseCode = "01";

                                    Transferencia.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batFromWarehouse;
                                    Transferencia.Lines.BinAllocations.Quantity = Cantidad;
                                    Transferencia.Lines.BinAllocations.BinAbsEntry = Ubicacion_cab;

                                    Transferencia.Lines.BinAllocations.Add();

                                    Transferencia.Lines.SetCurrentLine(i);
                                    Transferencia.Lines.ItemCode = Codigo;

                                    Transferencia.Lines.Quantity = Cantidad;
                                    Transferencia.Lines.Add();

                                    i = i + 1;
                                };
                            }
                        }

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

                        Insertar_en_tabla();

                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);

                        MessageBox.Show("Operación finalizada con éxito");
                        this.Close();

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
        public void Calcular_Pendiente()
        {
            //Captura en un label la cantidad actual de la grilla
            lblCant_Prestamo.Text = this.dvgGrilla.CurrentRow.Cells[5].Value.ToString();
            cantidad_actual = int.Parse(lblCant_Prestamo.Text);

            lblnroPrestamo.Text = this.dvgGrilla.CurrentRow.Cells[6].Value.ToString();
            nroPrestamo = int.Parse(lblnroPrestamo.Text);

        }
        //Cuenta cuantos item van a ser devueltos
        private void contador()
        {
            if ((dvgGrilla1.CurrentCell as DataGridViewCheckBoxCell) != null)
            {

                double total = 0;
                foreach (DataGridViewRow dr2 in dvgGrilla1.Rows)
                {
                    bool ischecked = (bool)dr2.Cells[0].EditedFormattedValue;

                    if (ischecked)
                    {


                        total += Convert.ToDouble(dr2.Cells[1].Value);

                    }
                }
                lblContador.Text = Convert.ToString(total);
                cantidad_devolucion = total;

            }

        }
        private void Insertar_en_tabla()
        {

            //#############Procedimiento almacenado  cabecera #############################################################    

            SqlConnection conn_1 = new SqlConnection();
            conn_1.ConnectionString = Global.conn_clasif;

            contador();


            conn_1.Open();

            SqlCommand cmd = conn_1.CreateCommand();
            cmd.Connection = conn_1;


            try
            {
                cmd = new SqlCommand("pa_alta_devolucion_cab", conn_1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Transaction = sqlTran;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);

                SqlParameter nroTransferencia = new SqlParameter("@nroTransferencia", SqlDbType.Int);
                nroTransferencia.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(nroTransferencia);

                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter encargado = new SqlParameter("@encargado", SqlDbType.VarChar);
                encargado.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(encargado);
                SqlParameter tipo_mov = new SqlParameter("@tipo_mov", SqlDbType.Int);
                tipo_mov.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(tipo_mov);
                SqlParameter codEncargado = new SqlParameter("@codEncargado", SqlDbType.Int);
                codEncargado.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(codEncargado);
                SqlParameter estado = new SqlParameter("@estado", SqlDbType.VarChar);
                estado.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(estado);
                SqlParameter nroPrestamo = new SqlParameter("@nroPrestamo", SqlDbType.Int);
                nroPrestamo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(nroPrestamo);

                SqlParameter depOrigen = new SqlParameter("@depOrigen", SqlDbType.VarChar);
                depOrigen.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(depOrigen);
                SqlParameter depDestino = new SqlParameter("@depDestino", SqlDbType.VarChar);
                depDestino.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(depDestino);

                SqlParameter cantidadP = new SqlParameter("@cantidadP", SqlDbType.Int);
                cantidadP.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadP);
                SqlParameter cantidadD = new SqlParameter("@cantidadD", SqlDbType.Int);
                cantidadD.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadD);
                SqlParameter cantidadA = new SqlParameter("@cantidadA", SqlDbType.Int);
                cantidadA.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadA);

                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                nroTransferencia.Value = docentry;

                fecha.Value = dtpFecha.Value;
                codEncargado.Value = txtCodigo.Text;
                encargado.Value = txtDenominacion.Text;
                depOrigen.Value = "PREST";
                depDestino.Value = "Almacen General";
                estado.Value = "";
                tipo_mov.Value = 2;

                nroPrestamo.Value = lblnroPrestamo.Text;

                cantidadP.Value = this.dvgGrilla.CurrentRow.Cells[4].Value.ToString();
                cantidadD.Value = lblContador.Text;
                cantidadA.Value = cantidad_actual;

                mensaje.Value = "";

                cmd.ExecuteNonQuery();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                }

                //#####################Procedimiento almacenado detalle ######################################################

                cmd = new SqlCommand("pa_alta_devolucion_det", conn_1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Transaction = sqlTran;

                SqlParameter RetValue1 = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue1.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue1);

                SqlParameter nroTransferencia1 = new SqlParameter("@nroTransferencia", SqlDbType.Int);
                nroTransferencia1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(nroTransferencia1);

                SqlParameter nroTransferenciaOR = new SqlParameter("@nroTransferenciaOR", SqlDbType.Int);
                nroTransferenciaOR.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(nroTransferenciaOR);

                SqlParameter codArticulo = new SqlParameter("@codArticulo", SqlDbType.VarChar);
                codArticulo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(codArticulo);

                SqlParameter disponible = new SqlParameter("@disponible", SqlDbType.VarChar);
                disponible.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(disponible);

                SqlParameter cantidad = new SqlParameter("@cantidad", SqlDbType.Int);
                cantidad.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidad);
                SqlParameter cantidadD2 = new SqlParameter("@cantidadD2", SqlDbType.Int);
                cantidadD2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadD2);
                SqlParameter cantidadA2 = new SqlParameter("@cantidadA2", SqlDbType.Int);
                cantidadA2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadA2);
                SqlParameter cantidadP1 = new SqlParameter("@cantidadP1", SqlDbType.Int);
                cantidadP1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadP1);
                SqlParameter cantidadD1 = new SqlParameter("@cantidadD1", SqlDbType.Int);
                cantidadD1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadD1);
                SqlParameter cantidadA1 = new SqlParameter("@cantidadA1", SqlDbType.Int);
                cantidadA1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadA1);

                SqlParameter mensaje1 = new SqlParameter("@mensaje1", SqlDbType.VarChar, 100);
                mensaje1.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje1);


                if ((dvgGrilla1.CurrentCell as DataGridViewCheckBoxCell) != null)
                {

                    foreach (DataGridViewRow row in dvgGrilla1.Rows)
                    {
                        bool ischecked = (bool)row.Cells[0].EditedFormattedValue;

                        if (ischecked)
                        {

                            codArticulo.Value = row.Cells[3].Value.ToString();
                            nroTransferencia1.Value = docentry;
                            nroTransferenciaOR.Value = row.Cells[2].Value.ToString();

                            //Cuando se realiza un prestamo el articulo siempre esta 'no disponible' esta en (No).
                            disponible.Value = 'D';
                            cantidad.Value = Cantidad_Prestada;
                            cantidadD2.Value = cantidad_a_devolver;
                            cantidadA2.Value = cantidad_a_devolver;
                            cantidadP1.Value = this.dvgGrilla.CurrentRow.Cells[4].Value.ToString();
                            cantidadD1.Value = lblContador.Text;
                            cantidadA1.Value = cantidad_actual;

                            mensaje1.Value = "";
                            cmd.ExecuteNonQuery();
                        }
                    }

                }

                if (int.Parse(RetValue1.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje1.Value.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn_1.Close();
            }
        }
        //##### Despliega todos los articulos que se encuentran en prestamo #####//
        private void Cargar_Grilla_Cabecera()
        {

            sql_man_Articulo = "  select a.DocNum as Nro_Transferencia, a.filler as Dep_Origen, ";
            sql_man_Articulo = sql_man_Articulo + " a.toWhsCode as Dep_Destino, c.cantidadP as Cantidad, c.cantidadA, ";
            sql_man_Articulo = sql_man_Articulo + " c.nroTransferencia as NroPrestamo ";
            sql_man_Articulo = sql_man_Articulo + " from OWTR a with (nolock) ";
            sql_man_Articulo = sql_man_Articulo + " inner join " + Properties.Settings.Default.sap_companydb_cla + ".dbo.mov_herramientas c with (nolock) on a.SlpCode = c.codEncargado ";
            sql_man_Articulo = sql_man_Articulo + " and a.docnum = c.nrotransferencia ";
            sql_man_Articulo = sql_man_Articulo + " where  a.toWhsCode = 'Prest'  and c.estado <> 'C' and c.tipo_mov = 1  and a.SlpCode = '" + txtCodigo.Text + "'";
            sql_man_Articulo = sql_man_Articulo + " order by a.DocNum ";

            daManejo_Articulo = new SqlDataAdapter(sql_man_Articulo, Global.conn);

            if (ds.Tables.Contains("Articulo"))
            {
                ds.Tables["Articulo"].Clear();
            };

            daManejo_Articulo.Fill(ds, "Articulo");

            dvgGrilla.DataSource = ds.Tables["Articulo"];

        }
        //##### Despliega el detalle de cada prestamo prestamo #####//
        private void Cargar_Grilla_Detalle()
        {
            /*sql_man_Articulo1 = " select b.codArticulo, b.disponible, b.cantidad, a.nroTransferencia ";
            sql_man_Articulo1 = sql_man_Articulo1 + " from mov_herramientas ";
            sql_man_Articulo1 = sql_man_Articulo1 + " a inner join det_mov_herramientas b on a.nroTransferencia = b.nroTransferencia ";
            sql_man_Articulo1 = sql_man_Articulo1 + " where b.disponible = 'P' and  a.nroTransferencia=  '" + nro_transferencia + "'";*/

            sql_man_Articulo1 = "select distinct a.DocNum as Nro_Prestamo, b.ItemCode as Codigo,  b.Dscription as Herramienta, d.cantidadA as Cantidad, ";
            sql_man_Articulo1 = sql_man_Articulo1 + " d.cantidad as Cantidad_Prestamo ";
            sql_man_Articulo1 = sql_man_Articulo1 + " from OWTR a with (nolock) ";
            sql_man_Articulo1 = sql_man_Articulo1 + " inner join WTR1 b with (nolock) on a.docentry = b.docentry ";
            sql_man_Articulo1 = sql_man_Articulo1 + " inner join " + Properties.Settings.Default.sap_companydb_cla + ".dbo.mov_herramientas c with (nolock) on a.SlpCode = c.codEncargado ";
            sql_man_Articulo1 = sql_man_Articulo1 + " inner join " + Properties.Settings.Default.sap_companydb_cla + ".dbo.det_mov_herramientas d with (nolock) on c.nroTransferencia = d.nroTransferencia ";
            sql_man_Articulo1 = sql_man_Articulo1 + " and a.DocNum = c.nroTransferencia and b.ItemCode collate database_default  = d.codArticulo collate database_default ";
            sql_man_Articulo1 = sql_man_Articulo1 + " where d.disponible = 'P' and  c.nroTransferencia=  '" + nro_transferencia + "'";

            daManejo_Articulo1 = new SqlDataAdapter(sql_man_Articulo1, Global.conn);

            if (ds.Tables.Contains("Articulo1"))
            {
                ds.Tables["Articulo1"].Clear();
            };

            daManejo_Articulo1.Fill(ds, "Articulo1");

            dvgGrilla1.DataSource = ds.Tables["Articulo1"];
        }
        //##### Busca al encargado segun codigo, despliega el nombre y la ubicacion que le corresponde #####//
        private void Encargado()
        {
            sql_Encargado = "select a.AbsEntry as Codigo, a.BinCode as Ubicacion, b.WhsCode as Cod_Deposito, ";
            sql_Encargado = sql_Encargado + " b.WhsName as Deposito, a.SL1Code as Almacen, c.SlpCode as Cod_Encargado, ";
            sql_Encargado = sql_Encargado + " c.SlpName as Encargado ";
            sql_Encargado = sql_Encargado + " from OBIN a with (nolock) ";
            sql_Encargado = sql_Encargado + " inner join OWHS b with (nolock) on a.WhsCode = b.WhsCode ";
            sql_Encargado = sql_Encargado + " inner join OSLP c with (nolock) on a.SL1Code = c.U_AREA ";
            sql_Encargado = sql_Encargado + " where c.SlpCode = '" + txtCodigo.Text + "'";
            daEncargado = new SqlDataAdapter(sql_Encargado, Global.conn);

            if (ds.Tables.Contains("Encargado"))
            {
                ds.Tables["Encargado"].Rows.Clear();
            };

            daEncargado.Fill(ds, "Encargado");

            if (daEncargado.Fill(ds, "Encargado") > 0)
            {
                Encargado_cab = int.Parse(ds.Tables["Encargado"].Rows[0]["Cod_Encargado"].ToString());
                Ubicacion_cab = int.Parse(ds.Tables["Encargado"].Rows[0]["Codigo"].ToString());
                txtDenominacion.Text = ds.Tables["Encargado"].Rows[0]["Encargado"].ToString();
                txtNomUbi.Text = ds.Tables["Encargado"].Rows[0]["Ubicacion"].ToString();

                txtCodigo.Text = ds.Tables["Encargado"].Rows[0]["Cod_Encargado"].ToString();
                txtUbicacion.Text = ds.Tables["Encargado"].Rows[0]["Codigo"].ToString();

                Cargar_Grilla_Cabecera();
            }
            else
            {
                txtCodigo.Text = "";
                txtDenominacion.Text = "";
                txtNomUbi.Text = "";
                txtCodigo.Focus();
                return;
            };
        }
        private void Comparar_Valores()
        {
            //############ Verifica que la cantidad la cantidad requerida no sea mayor a la cantidad disponible ############//
            //############ Despliega mensaje en caso de que la cantidad dispoble sea menor ############//

            //lblCant_Disp.Text = this.dvgGrilla1.CurrentRow.Cells[5].Value.ToString();            
            //lblCant_Req.Text = this.dvgGrilla1.CurrentRow.Cells[1].Value.ToString();
                      

            //Cantidad_Prestada = int.Parse(lblCant_Disp.Text);
            //cantidad_a_devolver = int.Parse(lblCant_Req.Text);

            foreach (DataGridViewRow dr3 in dvgGrilla1.Rows)
            {
                bool ischecked = (bool)dr3.Cells[0].EditedFormattedValue;

                if (ischecked)
                {
                    Cantidad_Prestada = int.Parse(dr3.Cells[5].Value.ToString());
                    cantidad_a_devolver = int.Parse(dr3.Cells[1].Value.ToString());

                    if (cantidad_a_devolver > Cantidad_Prestada)
                    {
                        MessageBox.Show("La cantidad que desea devolver es mayor que la cantidad que prestó, favor verificar!");
                        Cargar_Grilla_Detalle();
                    };
                }
            }
            contador();
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            Encargado();            
        }
        private void txtDenominacion_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void dvgGrilla_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((dvgGrilla.CurrentCell as DataGridViewCheckBoxCell) != null)
            {

                foreach (DataGridViewRow dr in dvgGrilla.Rows)
                {
                    bool ischecked = (bool)dr.Cells[0].EditedFormattedValue;

                    if (ischecked)
                    {
                        nro_transferencia = int.Parse(dr.Cells[1].Value.ToString());
                    };
                };
            }
            Cargar_Grilla_Detalle();
            Calcular_Pendiente();
        }
        private void dvgGrilla1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dvgGrilla1.CurrentRow.Cells[1].Value != null)
            {
                Comparar_Valores();
            }
            else
            {
                //dvgGrilla1.EndEdit();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dvgGrilla1.CurrentRow.Cells[0];
                MessageBox.Show("Debe seleccionar la cantidad a Devolver");
                cell.TrueValue = 0;
                cell.Value = false;
                return;
            };
        }
    }
}
