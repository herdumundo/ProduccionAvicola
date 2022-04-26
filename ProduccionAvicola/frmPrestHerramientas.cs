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
    public partial class frmPrestHerramientas : Form
    {
        //Variables SAP
        Company empresa = new Company();

        StockTransfer Transferencia;

        SqlDataAdapter daManejo_Articulo;
        SqlDataAdapter daEncargado;
        SqlDataAdapter daCodigo;
        SqlDataAdapter da_Datos;

        string sql_Encargado;
        string sql_man_Articulo;
        public int linenum;

        string Herramienta;
        string Codigo;
        int Cantidad;
        int docentry;

        int Encargado_cab;
        int Ubicacion_cab;
        int Cantidad_Disponible;
        string sql_codigo;
        public String Variable;
        string sql_Datos;
        int Cod_Encargado;

        public frmPrestHerramientas()
        {
            InitializeComponent();
        }

        private static frmPrestHerramientas frmDefInstance;
        public static frmPrestHerramientas DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmPrestHerramientas();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
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
        //##### Suma la columna de cantidad de la grilla Prestamo
        private void Suma()
        {
            double total = 0;
            foreach (DataGridViewRow row in dvgPrestamo.Rows)
            {
                total += Convert.ToDouble(row.Cells[2].Value);

            }
            lblContador.Text = Convert.ToString(total);
        }
        //##### Elige el articulo de acuerdo al grupo 121 que corresponde a herramientas #####//          
        private void Elige_Articulo()
        {
            sql_man_Articulo = "select a.ItemCode as Codigo, a.ItemName as Herramienta, convert(numeric, b.OnHand) as Disponible from OITM a inner join OITW b on a.itemcode = b.itemcode where b.WhsCode = '01' and ItmsGrpCod = 121 and b.OnHand > 0 and A.ItemName like  '%" + txtArticulo.Text + "%'";
            daManejo_Articulo = new SqlDataAdapter(sql_man_Articulo, Global.conn);

            if (ds.Tables.Contains("Articulo"))
            {
                ds.Tables["Articulo"].Clear();
            };

            daManejo_Articulo.Fill(ds, "Articulo");

            dvgGrilla.DataSource = ds.Tables["Articulo"];
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Elige_Articulo();

        }
        //##### Recorre la grilla y pasa todas las filas que estan chequeadas a la otra grilla #####//
        public void Procesar()
        {
            foreach (DataGridViewRow row in dvgGrilla.Rows)
            {
                bool ischecked = (bool)row.Cells[0].EditedFormattedValue;

                if (ischecked)
                {

                    Codigo = row.Cells[1].Value.ToString();
                    Herramienta = row.Cells[2].Value.ToString();

                    dvgPrestamo.Rows.Add(Codigo, Herramienta);

                }

            };

            Limpiar_Check();

        }
        private void Limpiar_Check()
        {
            //foreach (DataGridViewRow rows in dvgGrilla.Rows)
            //{
            //    DataGridViewCheckBoxCell cellSelecion = rows.Cells[0] as DataGridViewCheckBoxCell;
            //        {
            foreach (DataGridViewRow rows in dvgGrilla.Rows)
            {
                bool ischecked = (bool)rows.Cells[0].EditedFormattedValue;

                if (ischecked)
                {
                    dvgGrilla.Rows.Remove(rows);
                }


            }

        }
        private void Insertar_en_tabla()
        {

            //#############Procedimiento almacenado  cabecera #############################################################    

            SqlConnection conn_1 = new SqlConnection();
            conn_1.ConnectionString = Global.conn_clasif;


            conn_1.Open();

            SqlCommand cmd = conn_1.CreateCommand();
            cmd.Connection = conn_1;


            try
            {
                cmd = new SqlCommand("pa_alta_prestamo_cab", conn_1);
                cmd.CommandType = CommandType.StoredProcedure;

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
                depOrigen.Value = "Almacen General";
                depDestino.Value = "PREST";
                estado.Value = 'A';
                tipo_mov.Value = 1;
                nroPrestamo.Value = 0;
                cantidadP.Value = lblContador.Text;
                cantidadD.Value = 0;
                cantidadA.Value = lblContador.Text;

                mensaje.Value = "";

                cmd.ExecuteNonQuery();

                if (int.Parse(RetValue.Value.ToString()) != 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                }

                //#####################Procedimiento almacenado detalle ######################################################

                cmd = new SqlCommand("pa_alta_prestamo_det", conn_1);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter RetValue1 = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue1.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue1);

                SqlParameter nroTransferencia1 = new SqlParameter("@nroTransferencia", SqlDbType.Int);
                nroTransferencia1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(nroTransferencia1);

                SqlParameter codArticulo = new SqlParameter("@codArticulo", SqlDbType.VarChar);
                codArticulo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(codArticulo);

                SqlParameter disponible = new SqlParameter("@disponible", SqlDbType.VarChar);
                disponible.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(disponible);

                SqlParameter cantidad = new SqlParameter("@cantidad", SqlDbType.Int);
                cantidad.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidad);

                SqlParameter cantidadD3 = new SqlParameter("@cantidadD3", SqlDbType.Int);
                cantidadD3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadD3);

                SqlParameter cantidadA2 = new SqlParameter("@cantidadA2", SqlDbType.Int);
                cantidadA2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidadA2);


                SqlParameter mensaje1 = new SqlParameter("@mensaje1", SqlDbType.VarChar, 100);
                mensaje1.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje1);

                foreach (DataGridViewRow row in dvgPrestamo.Rows)
                {

                    codArticulo.Value = row.Cells["Column1"].Value.ToString();
                    nroTransferencia1.Value = docentry;
                    //Cuando se realiza un prestamo el articulo siempre esta 'Prestado' esta en (P).
                    disponible.Value = 'P';
                    cantidad.Value = Cantidad;
                    cantidadD3.Value = 0;
                    cantidadA2.Value = row.Cells[2].Value.ToString();
                    mensaje1.Value = "";
                    cmd.ExecuteNonQuery();

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
        private void btnPasar_Click(object sender, EventArgs e)
        {
            Procesar();

        }
        private void dvgGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dvgGrilla.CurrentCell as DataGridViewCheckBoxCell) != null)
            {
                foreach (DataGridViewRow row in dvgGrilla.Rows)
                {
                    bool ischecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (ischecked)
                    {
                        Codigo = row.Cells[1].Value.ToString();
                        Herramienta = row.Cells[2].Value.ToString();
                    }
                };

            }

        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Validaciones

                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Debe cargar un código!");
                    txtCodigo.Focus();
                    return;

                }


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
                        Transferencia.Comments = "Prestamo de Herramientas";
                        Transferencia.FromWarehouse = "01";
                        Transferencia.ToWarehouse = "PREST";
                        Transferencia.SalesPersonCode = Encargado_cab;


                        //##### Socia el encargado y la ubicacion en la transferencia #####//

                        int i = 0;
                        foreach (DataGridViewRow dr in dvgPrestamo.Rows)
                        {
                            Cantidad = int.Parse(dr.Cells[2].Value.ToString());
                            Codigo = dr.Cells[0].Value.ToString();

                            Transferencia.Lines.BinAllocations.BinActionType = BinActionTypeEnum.batToWarehouse;
                            Transferencia.Lines.BinAllocations.SerialAndBatchNumbersBaseLine = i;
                            Transferencia.Lines.BinAllocations.Quantity = Cantidad;
                            Transferencia.Lines.BinAllocations.BinAbsEntry = Ubicacion_cab;

                            Transferencia.Lines.BinAllocations.Add();

                            Transferencia.Lines.SetCurrentLine(i);
                            Transferencia.Lines.ItemCode = Codigo;

                            Transferencia.Lines.Quantity = Cantidad;
                            Transferencia.Lines.Add();

                            i = i + 1;
                        };

                        //############ Verifica que la cantidad la cantidad requerida no sea mayor a la cantidad disponible ############//
                        //############ Despliega mensaje en caso de que la cantidad dispoble sea menor ############//

                        lblCant_Dis.Text = this.dvgGrilla.CurrentRow.Cells[3].Value.ToString();
                        lblCant_Req.Text = this.dvgPrestamo.CurrentRow.Cells[2].Value.ToString();

                        Cantidad_Disponible = int.Parse(this.dvgGrilla.CurrentRow.Cells[3].Value.ToString());

                        if (Cantidad_Disponible < Cantidad)
                        {
                            MessageBox.Show("La cantidad disponible es menor a la cantidad requerida, favor verificar!");
                            return;

                        };

                        Suma();

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
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //##### Busca al encargado segun codigo, despliega el nombre y la ubicacion que le corresponde #####//
        private void Encargado()
        {
            sql_Encargado = "select a.AbsEntry as Codigo, a.BinCode as Ubicacion, b.WhsCode as Cod_Deposito, ";
            sql_Encargado = sql_Encargado + " b.WhsName as Deposito, a.SL1Code as Almacen, c.SlpCode as Cod_Encargado, ";
            sql_Encargado = sql_Encargado + " c.SlpName as Encargado ";
            sql_Encargado = sql_Encargado + " from OBIN a ";
            sql_Encargado = sql_Encargado + " inner join OWHS b on a.WhsCode = b.WhsCode ";
            sql_Encargado = sql_Encargado + " inner join OSLP c on a.SL1Code = c.U_AREA ";
            sql_Encargado = sql_Encargado + " where c.SlpCode = '" + Cod_Encargado + "'";
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

            };

        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            //if (txtArticulo.Text != "")
            //{
            Elige_Articulo();
            //};            
        }
        private void txtDenominacion_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        //Eliminar con click derecho de la grilla
        private void cmnuEliminar_Click(object sender, EventArgs e)
        {
            if (dvgPrestamo.CurrentCell.RowIndex != -1)
            {
                dvgPrestamo.Rows.RemoveAt(dvgPrestamo.CurrentCell.RowIndex);
            };

        }
        private void Cargar_Grilla_Encargado()
        {
            sql_Datos = "select a.SlpCode as Codigo, a.SlpName as Encargado ";
            sql_Datos = sql_Datos + " from OSLP a ";
            sql_Datos = sql_Datos + " inner join obin b on a.u_area = b.sl1code order by 1";

            da_Datos = new SqlDataAdapter(sql_Datos, Global.conn);

            if (ds.Tables.Contains("Datos"))
            {
                ds.Tables["Datos"].Rows.Clear();
            };

            da_Datos.Fill(ds, "Datos");
            dvgEncargado.DataSource = ds.Tables["Datos"];

        }
        //##### Configura la tecla F2 #####//     
        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F2))
            {
                dvgEncargado.Visible = true;
                Cargar_Grilla_Encargado();
            }
            else
            {
                dvgEncargado.Visible = false;
            }
        }
        private void dvgEncargado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dvgEncargado.CurrentCell as DataGridViewCheckBoxCell) != null)
            {

                foreach (DataGridViewRow row in dvgEncargado.Rows)
                {

                    bool ischecked = (bool)row.Cells[0].EditedFormattedValue;

                    if (ischecked)
                    {
                        Cod_Encargado = int.Parse(row.Cells[1].Value.ToString());
                        Encargado();
                        dvgEncargado.Visible = false;
                    }
                }                
            }

        }
        private void txtCodigo_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void Recargar_Encargado()
        {
            sql_Encargado = "select a.AbsEntry as Codigo, a.BinCode as Ubicacion, b.WhsCode as Cod_Deposito, ";
            sql_Encargado = sql_Encargado + " b.WhsName as Deposito, a.SL1Code as Almacen, c.SlpCode as Cod_Encargado, ";
            sql_Encargado = sql_Encargado + " c.SlpName as Encargado ";
            sql_Encargado = sql_Encargado + " from OBIN a ";
            sql_Encargado = sql_Encargado + " inner join OWHS b on a.WhsCode = b.WhsCode ";
            sql_Encargado = sql_Encargado + " inner join OSLP c on a.SL1Code = c.U_AREA ";
            sql_Encargado = sql_Encargado + " where c.SlpCode = '" + txtCodigo.Text.ToString() + "'";
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

                txtArticulo.Focus();
            }
            else
            {
                txtCodigo.Text = "";
                txtDenominacion.Text = "";
                txtNomUbi.Text = "";
                txtUbicacion.Text = "";
                txtCodigo.Focus();
                return;
            };
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            Recargar_Encargado();
        }
        private void frmPrestHerramientas_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }
        private void Limpiar_Form()
        {
            txtCodigo.Clear();
            txtDenominacion.Clear();
            txtNomUbi.Clear();
            txtUbicacion.Clear();

            //#####Recorre la grilla y limpia los checks#####//

            foreach (DataGridViewRow row in dvgEncargado.Rows)
            {

                DataGridViewCheckBoxCell cellSelecion = row.Cells[0] as DataGridViewCheckBoxCell;

                cellSelecion.Value = false;
            }

            txtCodigo.Focus();
            return;


        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            Limpiar_Form();
        }
    }
}
