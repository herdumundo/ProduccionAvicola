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
    public partial class frmLaboratorio : Form
    {
        Company empresa = new Company();
        Documents Salida;
        MaterialRevaluation Revalorizacion;

        SqlDataAdapter daAreas;
        SqlDataAdapter daListaMatLab;
        SqlDataAdapter daListaMatLDet;
        SqlDataAdapter daArticulos;
        SqlDataAdapter daAsiento;
        SqlDataAdapter daTAvesRecria;

        string sql_tavesrecria;
        string sql_asiento;
        string sql_articulos;
        string sql_listamatldet;
        string sql_listamtlab;
        string sql_areas;

        string sys_number;
                
        int tsalida;
        int taves;
        int docentry;
        double new_cost;

        DataRow NewRow;
        public frmLaboratorio()
        {
            InitializeComponent();
        }
        //################################################################################################
        //Abrir una sola instancia del formulario
        //################################################################################################
        private static frmLaboratorio frmDefInstance;
        public static frmLaboratorio DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmLaboratorio();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        //################################################################################################
        //Consultas a la base de datos
        //################################################################################################
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
        private void tavesrecria()
        {
            sql_tavesrecria = "select convert(int, sum(quantity - quantout)) as cant, absentry, balance/sum(Quantity-QuantOut) as cost ";
            sql_tavesrecria = sql_tavesrecria + " from obtn ";
            sql_tavesrecria = sql_tavesrecria + " where ItemCode = 'POLL-00001' ";
            sql_tavesrecria = sql_tavesrecria + " group by absentry, balance ";
            sql_tavesrecria = sql_tavesrecria + " having sum(quantity - quantout) > 0 ";

            daTAvesRecria = new SqlDataAdapter(sql_tavesrecria, Global.conn);

            if (ds.Tables.Contains("tavesrecria"))
            {
                ds.Tables["tavesrecria"].Clear();
            };
            if (daTAvesRecria.Fill(ds, "tavesrecria") > 0)
            {
               
            };
        }
        private void b_articulos()
        {
            if (sys_number == "0")
            {
                sql_articulos = "select b.itemcode, b.itemname, a.onhand ";
                sql_articulos = sql_articulos + " from oitw a ";
                sql_articulos = sql_articulos + " inner join oitm b on a.itemcode = b.itemcode ";
                sql_articulos = sql_articulos + " where a.whscode IN ('R', 'CV', 'LAB') and a.onhand > 0 ";
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtInsumos.Text + "' ";
            }
            else
            {
                sql_articulos = sql_articulos + " select b.sysnumber, b.itemcode, b.itemname, b.distnumber,  ";
                sql_articulos = sql_articulos + " convert(numeric(12,2), a.onhandqty) as quantity ";
                sql_articulos = sql_articulos + " from obbq a ";
                sql_articulos = sql_articulos + " inner join obtn b on a.snbmdabs = b.absentry  ";
                sql_articulos = sql_articulos + " inner join obin c on a.binabs = c.absentry  ";
                sql_articulos = sql_articulos + " where a.onhandqty > 0 and a.WhsCode = 'CV' and a.binabs = 64  ";
                sql_articulos = sql_articulos + " and b.sysnumber = " + sys_number;
                sql_articulos = sql_articulos + " and b.itemcode = '" + txtInsumos.Text + "' ";
            }

            sql_articulos = sql_articulos + " order by b.itemname ";

            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };
            if (daArticulos.Fill(ds, "articulos") > 0)
            {
                txtInsumos.Text = ds.Tables["articulos"].Rows[0]["itemcode"].ToString();
                lblInsumos.Text = ds.Tables["articulos"].Rows[0]["itemname"].ToString();
                //if (sys_number != "0")
                //{
                //    lblLoteVac.Text = ds.Tables["articulos"].Rows[0]["distnumber"].ToString();
                //};

                txtDosis.Focus();
            }
        }
        private void areas()
        {
            //sql_areas = "select * from [@areas] where code in ('PP', 'RC') ";
            sql_areas = "select prccode, substring(prcname, 21, len(prcname)) as prcname from oprc ";
            sql_areas = sql_areas + " where prccode like '242020%' ";
            daAreas = new SqlDataAdapter(sql_areas, Global.conn);
            
            if (ds.Tables.Contains("areas"))
            {
                ds.Tables["areas"].Clear();
            };

            if (daAreas.Fill(ds, "areas") > 0)
            {
                cbAreas.DataSource = ds.Tables["areas"];
                cbAreas.DisplayMember = "prcname";
                cbAreas.ValueMember = "prccode";
                cbAreas.SelectedIndex = -1;
            };
        }        
        private void limpiar_detalle()
        {
            txtInsumos.Text = "";
            lblInsumos.Text = "";
            txtDosis.Text = "";
            txtInsumos.Focus();
        }
        private void lista_mat_lab()
        {
            sql_listamtlab = "select * from [@LISTAMATLAB] order by 2 ";
            daListaMatLab = new SqlDataAdapter(sql_listamtlab, Global.conn);

            if (ds.Tables.Contains("lista"))
            {
                ds.Tables["lista"].Clear();
            };
            if (daListaMatLab.Fill(ds, "lista") > 0)
            {
                cbTest.DataSource = ds.Tables["lista"];
                cbTest.DisplayMember = "name";
                cbTest.ValueMember = "code";
                cbTest.SelectedIndex = -1; 
            };
        }
        private void detalle_mat_lab()
        {
            sql_listamatldet = "select code, lineid, u_codigo, convert(numeric(10,2), u_cant) as u_cant, u_descripcion from [@LISTAMATLDET] where code = '" + cbTest.SelectedValue + "' ";
            daListaMatLDet = new SqlDataAdapter(sql_listamatldet, Global.conn);

            if (ds.Tables.Contains("det"))
            {
                ds.Tables["det"].Clear();                
            };

            if (daListaMatLDet.Fill(ds, "det") > 0)
            {                
                foreach (DataRow drAN in ds.Tables["det"].Rows)
                {
                    NewRow = ds.Tables["listadet"].NewRow();
                    //NewRow["code"] = drAN["code"].ToString();
                    //NewRow["lineid"] = drAN["lineid"].ToString();
                    NewRow["u_codigo"] = drAN["u_codigo"].ToString();
                    NewRow["u_cant"] = drAN["u_cant"].ToString();
                    NewRow["u_descripcion"] = drAN["u_descripcion"].ToString();
                    ds.Tables["listadet"].Rows.Add(NewRow);
                };
            };

            dgvListaDet.DataSource = ds.Tables["listadet"];
        }
        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            areas();
            lista_mat_lab();
            dgvListaDet.AllowUserToAddRows = false;
        }
        private void cbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTest.SelectedIndex != -1)
            {
                ds.Tables["listadet"].Clear();
                detalle_mat_lab();
            };
        }
        private void txtInsumos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmBArticulos frm = new frmBArticulos();
                frm.sql = "select 0 as sysnumber, a.itemcode, b.itemname, ";
                frm.sql = frm.sql + " convert(numeric(12,2), a.onhand) as quantity ";
                frm.sql = frm.sql + " from oitw a ";
                frm.sql = frm.sql + " inner join oitm b on a.itemcode = b.itemcode ";
                frm.sql = frm.sql + " where a.onhand > 0 and a.itemcode like 'LAB%' ";

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtInsumos.Text = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    sys_number = frm.dgvArticulo.Rows[frm.dgvArticulo.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    b_articulos();
                }
            }
            else if (e.KeyCode == Keys.Enter && txtInsumos.Text != "")
            {
                b_articulos();
                SendKeys.Send("{Tab}");
            };
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Validaciones varias

                //Conexion a SAP
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

                //--##################################################################################--
                //--Registrar Salida de Vacunas
                //--##################################################################################--

                Salida = empresa.GetBusinessObject(BoObjectTypes.oInventoryGenExit);
                Salida.DocDate = dtpFecha.Value;
                Salida.Series = 73;
                Salida.Comments = txtComentario.Text;
                Salida.UserFields.Fields.Item("U_CODIGOLAB").Value = cbTest.SelectedValue.ToString();                                      

                int z = 0;
                foreach(DataRow drLista in ds.Tables["listadet"].Rows)
                {
                    //--##################################################################################--
                    //--Asignacion de centro de costo 
                    //--##################################################################################--

                    Salida.Lines.CostingCode = (ds.Tables["areas"].Rows[0]["prccode"].ToString()).Substring(0, 1);
                    Salida.Lines.CostingCode2 = (ds.Tables["areas"].Rows[0]["prccode"].ToString()).Substring(0, 2);
                    Salida.Lines.CostingCode3 = (ds.Tables["areas"].Rows[0]["prccode"].ToString()).Substring(0, 3);
                    Salida.Lines.CostingCode4 = (ds.Tables["areas"].Rows[0]["prccode"].ToString()).Substring(0, 5);
                    Salida.Lines.CostingCode5 = ds.Tables["areas"].Rows[0]["prccode"].ToString();

                    if (cbAreas.SelectedValue.ToString() == "24202002" || cbAreas.SelectedValue.ToString() == "24202003" || cbAreas.SelectedValue.ToString() == "24202007")
                    {
                        Salida.Lines.AccountCode = "10.01.11.99.11";
                    }
                    else
                    {
                        Salida.Lines.AccountCode = "5.01.01.04.07";
                    };

                    Salida.Lines.SetCurrentLine(z);
                    Salida.Lines.WarehouseCode = "LAB";
                    Salida.Lines.ItemCode = drLista["u_codigo"].ToString();
                    Salida.Lines.Quantity = double.Parse(drLista["u_cant"].ToString());
                    Salida.Lines.Add();

                    z = z + 1;
                };

                if (Salida.Add() != 0)
                {
                    if (empresa.InTransaction)
                    {
                        empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                    };
                    MessageBox.Show(empresa.GetLastErrorDescription());
                    return;
                };                

                //Recria revalorizacion de inventario
                if (cbAreas.SelectedValue.ToString() == "24202001")
                {
                    //Recuperar nro de operacion realizada
                    docentry = int.Parse(empresa.GetNewObjectKey());

                    tavesrecria();
                    //Datos asiento de operacion salida registrada

                    sql_asiento = " select convert(numeric, b.debit) as total from ojdt a with (nolock) ";
                    sql_asiento = sql_asiento + " inner join jdt1 b with (nolock) on a.transid = b.transid ";
                    sql_asiento = sql_asiento + " inner join oige c with (nolock) on a.baseref = c.docnum and a.transtype = 60 ";
                    sql_asiento = sql_asiento + " where b.account = '10.01.11.99.11' and c.docentry = " + docentry;

                    daAsiento = new SqlDataAdapter(sql_asiento, Global.conn);

                    if (ds.Tables.Contains("salida"))
                    {
                        ds.Tables["salida"].Clear();
                    };

                    if (daAsiento.Fill(ds, "salida") > 0)
                    {
                        tsalida = int.Parse(ds.Tables["salida"].Rows[0]["total"].ToString());
                    };

                    taves = 0;
                    foreach (DataRow dr in ds.Tables["tavesrecria"].Rows)
                    {
                        taves = taves + int.Parse(dr["cant"].ToString());
                    };

                    //--##################################################################################--
                    //--Calcular nuevo costo de pollitos segun el costo de los insumos utilizados
                    //--##################################################################################--

                    new_cost = double.Parse((tsalida / taves).ToString());

                    Revalorizacion = empresa.GetBusinessObject(BoObjectTypes.oMaterialRevaluation);
                    Revalorizacion.DocDate = dtpFecha.Value;
                    Revalorizacion.TaxDate = dtpFecha.Value;
                    Revalorizacion.RevalType = "P";
                    Revalorizacion.Lines.WarehouseCode = "P";
                    Revalorizacion.Lines.ItemCode = "POLL-00001";
                    Revalorizacion.Lines.RevaluationIncrementAccount = Properties.Settings.Default.cta_consumo_insumos_pollitos;
                    Revalorizacion.Lines.RevaluationDecrementAccount = Properties.Settings.Default.cta_consumo_insumos_pollitos;

                    int x = 0;
                    foreach (DataRow drLotes in ds.Tables["tavesrecria"].Rows)
                    {
                        Revalorizacion.Lines.SNBLines.SetCurrentLine(x);
                        Revalorizacion.Lines.SNBLines.SnbAbsEntry = int.Parse(drLotes["absentry"].ToString()); ;
                        Revalorizacion.Lines.SNBLines.NewCost = double.Parse(drLotes["cost"].ToString()) + new_cost;
                        Revalorizacion.Lines.SNBLines.Add();

                        z = z + 1;
                    };

                    if (Revalorizacion.Add() != 0)
                    {
                        if (empresa.InTransaction)
                        {
                            empresa.EndTransaction(BoWfTransOpt.wf_RollBack);
                        };
                        MessageBox.Show(empresa.GetLastErrorDescription());
                        return;
                    };
                };                
                                
                //Demas areas, cuenta de gastos

                empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                MessageBox.Show("Proceso finalizado");
                //imprimir();
                //limpiar_form();
                this.Close();
            }
            catch (Exception ex)
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
            };
        }
        private void btnInsMed_Click(object sender, EventArgs e)
        {
            if (txtInsumos.Text =="" || txtDosis.Text =="")
            {
                MessageBox.Show("Debe introducir datos de articulo o cantidad");
                return;
            }
            else
            {
                if (ds.Tables["listadet"].Rows.Count == 0)
                {
                    NewRow = ds.Tables["listadet"].NewRow();
                    NewRow["code"] = cbTest.SelectedValue.ToString();
                    //NewRow["lineid"] = drAN["lineid"].ToString();
                    NewRow["u_codigo"] = txtInsumos.Text;
                    NewRow["u_cant"] = txtDosis.Text;
                    NewRow["u_descripcion"] = lblInsumos.Text;
                    ds.Tables["listadet"].Rows.Add(NewRow);
                }
                else
                {

                    NewRow = ds.Tables["listadet"].NewRow();
                    NewRow["code"] = cbTest.SelectedValue.ToString();
                    //NewRow["lineid"] = drAN["lineid"].ToString();
                    NewRow["u_codigo"] = txtInsumos.Text;
                    NewRow["u_cant"] = txtDosis.Text;
                    NewRow["u_descripcion"] = lblInsumos.Text;
                    ds.Tables["listadet"].Rows.Add(NewRow);
                }
                limpiar_detalle();
            }
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbAreas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void cbTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtDosis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
        private void txtComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            };
        }
    }
}
