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
using System.IO;
using System.Collections;
using System.Diagnostics;


namespace ProduccionAvicola
{
    public partial class frmMOrdenesProduccion : Form
    {
        Company empresa = new Company();
        ProductionOrders ordenfabricacion;

        SqlDataAdapter daArticulos;
        SqlDataAdapter daOrden;
        SqlDataAdapter daEstado;
        SqlDataAdapter daOrdenes;

        string sql_ordenes;
        string sql_articulos;
        string sql_orden;
        string sql_estado;

        int docentry;
        public frmMOrdenesProduccion()
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
        private void articulos()
        {
            sql_articulos = "select a.itemcode, a.itemname ";
            sql_articulos = sql_articulos + " from oitm a with (nolock)  ";
            sql_articulos = sql_articulos + " where a.itemname like 'cart%' and a.itemcode like 'cart-0002%' ";
            sql_articulos = sql_articulos + " order by a.itemcode ";
            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("articulos"))
            {
                ds.Tables["articulos"].Clear();
            };

            if (daArticulos.Fill(ds, "articulos") > 0)
            {
                cbFiltro.DataSource = ds.Tables["articulos"];
                cbFiltro.DisplayMember = "itemname";
                cbFiltro.ValueMember = "itemcode";
            }
        }
        private void estado()
        {
            sql_articulos = "select distinct a.status, ";
            sql_articulos = sql_articulos + " case when a.Status = 'R' then 'Liberado' ";
            sql_articulos = sql_articulos + " when a.Status  = 'L' then 'Cerrado' ";
            sql_articulos = sql_articulos + " when a.Status  = 'C' then 'Cancelado' ";
            sql_articulos = sql_articulos + " when a.Status  = 'P' then 'Planificado' end as estado ";
            sql_articulos = sql_articulos + " from owor a ";
            sql_articulos = sql_articulos + " where a.type = 'S'";
            sql_articulos = sql_articulos + " order by a.status ";
            daArticulos = new SqlDataAdapter(sql_articulos, Global.conn);
            if (ds.Tables.Contains("estado"))
            {
                ds.Tables["estado"].Clear();
            };

            if (daArticulos.Fill(ds, "estado") > 0)
            {
                cbFiltro.DataSource = ds.Tables["estado"];
                cbFiltro.DisplayMember = "estado";
                cbFiltro.ValueMember = "status";
            }
        }
        private void filtro()
        {
            sql_ordenes = "select a.DocNum, a.PostDate, a.Status as estado, a.Type as tipo, a.ItemCode, b.ItemName, ";
            sql_ordenes = sql_ordenes + " CONVERT(numeric, a.plannedqty) as plannedqty, ";
            sql_ordenes = sql_ordenes + " CONVERT(numeric, a.cmpltqty) as cmpltqty, ";
            sql_ordenes = sql_ordenes + " CONVERT(numeric, a.plannedqty - a.cmpltqty) as pendiente, ";
            sql_ordenes = sql_ordenes + " a.Warehouse, c.WhsName, a.u_maqlinea, f.distnumber as lote, ";
            sql_ordenes = sql_ordenes + " case substring(f.distnumber, 0, 2) WHEN 1 then 'MAÑANA' WHEN 2 THEN 'TARDE' else 'NOCHE' end  as turno ";
            sql_ordenes = sql_ordenes + " from owor a";
            sql_ordenes = sql_ordenes + " inner join OITM b on a.ItemCode = b.ItemCode /*and b.itmsgrpcod= 102*/ ";            
            sql_ordenes = sql_ordenes + " inner join OWHS c on a.Warehouse = c.WhsCode ";
            sql_ordenes = sql_ordenes + " inner join oitl d on a.docnum = d.baseentry and d.doctype = 59 ";
            sql_ordenes = sql_ordenes + " inner join itl1 e on d.logentry = e.logentry ";
            sql_ordenes = sql_ordenes + " inner join obtn f on e.itemcode = f.itemcode and e.sysnumber = f.sysnumber ";
            /*sql_ordenes = sql_ordenes + "";
            sql_ordenes = sql_ordenes + "";
            sql_ordenes = sql_ordenes + "";*/


            if (Global.deposito == "FC")
            {
                sql_ordenes = sql_ordenes + " where c.whscode = 'FC' and b.itemcode like 'CART-0002%' ";
            }
            else if (Global.deposito == "SIL")
            {
                sql_ordenes = sql_ordenes + " where c.whscode = 'SIL' and b.itmsgrpcod in (106, 153) and b.itemcode like 'B%' ";
            };
            if (rbArticulo.Checked == true)
            {
                sql_ordenes = sql_ordenes + " and a.itemcode = '" + cbFiltro.SelectedValue + "' ";
                sql_ordenes = sql_ordenes + " and a.status in ('L') ";
                sql_ordenes = sql_ordenes + " order by a.docnum ";
            }
            else if (rbOrden.Checked == true)
            {
                sql_ordenes = sql_ordenes + " and a.docnum = " + txtFiltro.Text;                
                sql_ordenes = sql_ordenes + " order by a.docnum ";
            }
            else if (rbLineaMaq.Checked == true)
            {
                sql_ordenes = sql_ordenes + " and a.u_maqlinea = '" + cbLineaMaq.Text + "' ";                
                sql_ordenes = sql_ordenes + " order by a.docnum ";
            }
            else if (rbFecha.Checked == true)
            {
                sql_ordenes = sql_ordenes + " and a.postdate between '" + dtpDesde.Value.ToShortDateString() + "' ";
                sql_ordenes = sql_ordenes + " and '" + dtpHasta.Value.ToShortDateString() + "' ";
                sql_ordenes = sql_ordenes + " order by a.docnum ";
            }
            else if (rbTodos.Checked == true)
            {
                sql_ordenes = sql_ordenes + " and a.status in ('L') ";
                sql_ordenes = sql_ordenes + " order by a.docnum ";
            };

            daOrdenes = new SqlDataAdapter(sql_ordenes, Global.conn);

            if (ds.Tables.Contains("ord"))
            {
                ds.Tables["ord"].Clear();
            };

            if (daOrdenes.Fill(ds, "ord") > 0)
            {
                dgvOrdenes.DataSource = ds.Tables["ord"];
                txtFiltro.Text = "";
                pbExpExcel.Visible = true;
            }
            else
            {
                dgvOrdenes.DataSource = null;
                MessageBox.Show("No existen resultados para el filtro seleccionado");
                txtFiltro.Text = "";
                pbExpExcel.Visible = false;
                return;
            };
        }
        public void ExportaXLS(DataGridView dG)
        {
            try
            {
                ArrayList titulos = new ArrayList();
                DataTable datosTabla = new DataTable();
                //Especificar ruta del archivo con extensión de EXCEL.   
                Exportar OF = new Exportar(@".\OrdenesFabMaples.xls");
                //obtenemos los titulos del grid y creamos las columnas de la tabla   
                foreach (DataGridViewColumn item in dG.Columns)
                {
                    titulos.Add(item.HeaderText);
                    datosTabla.Columns.Add();
                }
                //se crean los renglones de la tabla   
                foreach (DataGridViewRow item in dG.Rows)
                {
                    DataRow rowx = datosTabla.NewRow();
                    datosTabla.Rows.Add(rowx);
                }
                //se pasan los datos del dataGridView a la tabla   
                foreach (DataGridViewColumn item in dG.Columns)
                {
                    foreach (DataGridViewRow itemx in dG.Rows)
                    {
                        datosTabla.Rows[itemx.Index][item.Index] = dG[item.Index, itemx.Index].Value;
                    }
                }
                OF.Export(titulos, datosTabla);
                Process.Start(OF.xpath);
                //MessageBox.Show("Proceso Completo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        class Exportar
        {

            StreamWriter w;

            string ruta;

            public string xpath
            {

                get { return ruta; }

                set { value = ruta; }

            }

            public Exportar(string path)
            {

                ruta = @path;

            }

            public void Export(ArrayList titulos, DataTable datos)
            {

                try
                {

                    FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);

                    w = new StreamWriter(fs);

                    string comillas = char.ConvertFromUtf32(34);

                    StringBuilder html = new StringBuilder();


                    html.Append(@"<html>");

                    html.Append(@"<head>");

                    html.Append(@"<meta http-equiv=" + comillas + "Content-Type" + comillas + "content=" + comillas + "text/html; charset=utf-8" + comillas + "/>");

                    html.Append(@"<title>Actividades</title>");

                    html.Append(@"</head>");

                    html.Append(@"<body>");

                    html.Append(@"<table border = 1>");

                    html.Append(@"<tr> <b>");

                    foreach (object item in titulos)
                    {

                        html.Append(@"<th>" + item.ToString() + "</th>");

                    }

                    html.Append(@"</b> </tr>");

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {

                        html.Append(@"<tr>");

                        for (int j = 0; j < datos.Columns.Count; j++)
                        {

                            switch (datos.Rows[i][j].ToString())
                            {

                                case "Detenido por el cliente":

                                    html.Append(@"<td bgcolor = Red><font color = White>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "Libre p/ejecutar":

                                    html.Append(@"<td bgcolor = Blue><font color = White>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "Pendiente por ROWAN":

                                    html.Append(@"<td bgcolor = Black><font color = White>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "Sin comprar":

                                    html.Append(@"<td bgcolor = Orange><font color = Black>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "Sin llegar":

                                    html.Append(@"<td bgcolor = Yellow><font color = Black>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "Terminado":

                                    html.Append(@"<td bgcolor = Green><font color = White>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "En Espera":

                                    html.Append(@"<td bgcolor = 8000FF><font color = White>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                case "En proceso":

                                    html.Append(@"<td bgcolor = 00FFFF><font color = Black>" + datos.Rows[i][j].ToString() + "</Font></td>");

                                    break;

                                default:

                                    html.Append(@"<td>" + datos.Rows[i][j].ToString() + "</td>");

                                    break;

                            }

                        }

                        html.Append(@"</tr>");

                    }

                    html.Append(@"</body>");

                    html.Append(@"</html>");

                    w.Write(html.ToString());

                    w.Close();

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        private void pbMasGrande_Click(object sender, EventArgs e)
        {
            ExportaXLS(dgvOrdenes);
        }
        private static frmMOrdenesProduccion frmDefInstance;
        public static frmMOrdenesProduccion DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMOrdenesProduccion();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        //Código de la botonera
        private void pbExpExcel_MouseMove(object sender, MouseEventArgs e)
        {
            pbMasGrande.Visible = true;
            pbExpExcel.Visible = false;
        }
        private void pbMasGrande_MouseLeave(object sender, EventArgs e)
        {
            pbMasGrande.Visible = false;
            pbExpExcel.Visible = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "" && rbArticulo.Checked == true)
            {
                filtro();
            }
            else
            {
                filtro();
            };            
        }
        //Al elegir opcion de filtro 
        private void rbArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticulo.Checked == true)
            {
                lblFiltro.Text = "Seleccionar Cod. Artículo";
                lblFiltro.Visible = true;
                articulos();
                cbFiltro.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                cbFiltro.Visible = false;
            }
        }
        private void rbOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrden.Checked == true)
            {
                lblFiltro.Text = "Ingresar Nro. de Orden";
                lblFiltro.Visible = true;
                txtFiltro.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                txtFiltro.Visible = false;
            }
        }
        private void rbEstado_CheckedChanged(object sender, EventArgs e)
        {

        }
        //Código de menú contextual
        private void cmnuCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Validación de cantidades para cierre de Orden de Producción
                int j;
                int pend;
                j = dgvOrdenes.CurrentRow.Index;
                docentry = int.Parse(dgvOrdenes.Rows[j].Cells[0].Value.ToString());
                pend = int.Parse(dgvOrdenes.Rows[j].Cells[8].Value.ToString());
                if (pend != 0)
                {
                    MessageBox.Show("La orden tiene cantidad pendiente. No puede ser cerrada");
                    return;
                };


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
                        int i;
                        i = dgvOrdenes.CurrentRow.Index;
                        docentry = int.Parse(dgvOrdenes.Rows[i].Cells[0].Value.ToString());

                        ordenfabricacion = empresa.GetBusinessObject(BoObjectTypes.oProductionOrders);
                        ordenfabricacion.GetByKey(docentry);
                        ordenfabricacion.ProductionOrderStatus = BoProductionOrderStatusEnum.boposClosed;
                        if (ordenfabricacion.Update() != 0)
                        {
                            MessageBox.Show(empresa.GetLastErrorCode() + " " + empresa.GetLastErrorDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        };
                        empresa.EndTransaction(BoWfTransOpt.wf_Commit);
                        MessageBox.Show("Proceso finalizado");
                        filtro();
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
            }
        }
        //Código de la grilla
        private void dgvOrdenes_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgvOrdenes.DataSource != null)
            {
                int i;
                string estado;
                int pend;
                i = dgvOrdenes.CurrentRow.Index;
                docentry = int.Parse(dgvOrdenes.Rows[i].Cells[0].Value.ToString());
                estado = dgvOrdenes.Rows[i].Cells[2].Value.ToString();
                //pend = int.Parse(dgvOrdenes.Rows[i].Cells[8].Value.ToString());
                if (estado == "C")
                {
                    cmnuRecepcion.Enabled = false;
                    cmnuCerrar.Enabled = false;
                    cmnuCancelar.Enabled = false;
                    cmnuMerma.Enabled = true;
                }
                else if (estado == "L")
                {
                    cmnuRecepcion.Enabled = false;
                    cmnuCerrar.Enabled = false;
                    cmnuCancelar.Enabled = false;
                    cmnuMerma.Enabled = true;
                }
                else
                {
                    if (dgvOrdenes.Rows[0].Cells[0].Value != null)
                    {
                        cmnuCancelar.Enabled = true;
                        cmnuCerrar.Enabled = true;
                        cmnuRecepcion.Enabled = true;
                        cmnuMerma.Enabled = true;
                    }
                }
            }
            else
            {
                cmnuRecepcion.Enabled = false;
                cmnuCerrar.Enabled = false;
                cmnuCancelar.Enabled = false;
            };
        }
        private void frmMOrdenesProduccion_Load(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = null;
        }
        private void cmnuNuevo_Click(object sender, EventArgs e)
        {
            frmOrdenProduccion frm = new frmOrdenProduccion();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                filtro();
            };
        }
        private void cmnuRecepcion_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvOrdenes.CurrentRow.Index;

            frmReciboProduccion frm = new frmReciboProduccion();
            frm.doc_entry = int.Parse(dgvOrdenes.Rows[i].Cells[0].Value.ToString());
            string estado = dgvOrdenes.Rows[i].Cells[2].Value.ToString();
            if (estado == "C")
            {
                MessageBox.Show("La orden se encuentra Cancelada");
                return;
            }
            else if (estado == "L")
            {
                MessageBox.Show("la orden ya ha sido completada");
                return;
            }
            else
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    filtro();
                };
            };
        }
        private void cmnuCancelar_Click(object sender, EventArgs e)
        {
            int i;
            string estado;
            int pend;
            i = dgvOrdenes.CurrentRow.Index;
            docentry = int.Parse(dgvOrdenes.Rows[i].Cells[0].Value.ToString());
            estado = dgvOrdenes.Rows[i].Cells[2].Value.ToString();
            pend = int.Parse(dgvOrdenes.Rows[i].Cells[8].Value.ToString());
            if (pend != 0)
            {
                MessageBox.Show("La orden ya posee movimientos. No puede ser cancelada");
                return;
            }
            else
            {

            }
        }
        private void cmnuMerma_Click(object sender, EventArgs e)
        {
            //frmMermas frm = new frmMermas();
            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{
            //    //filtro();
            //};
        }
        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFecha.Checked == true)
            {
                lblFiltro.Text = "Seleccionar Rango de Fecha";
                lblFiltro.Visible = true;
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
            }
        }
        private void rbLineaMaq_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLineaMaq.Checked == true)
            {
                lblFiltro.Text = "Seleccionar Linea / Maquina";
                lblFiltro.Visible = true;
                cbLineaMaq.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                cbLineaMaq.Visible = false;
            }
        }
    }
}
