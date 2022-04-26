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
    public partial class frmMTransferencias : Form
    {
        Company empresa = new Company();
        //ProductionOrders ordenfabricacion;

        SqlDataAdapter daArticulos;
        SqlDataAdapter daTransferencias;
        SqlDataAdapter daDestinos;

        string sql_transferencias;
        string sql_articulos;
        string sql_destinos;

        //int docentry;
        public frmMTransferencias()
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
            empresa.language = BoSuppLangs.ln_Spanish;
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
        private void llenar_destino()
        {
            sql_destinos = "select whscode, whsname ";
            sql_destinos = sql_destinos + " from owhs a with (nolock) ";
            sql_destinos = sql_destinos + " where a.whscode in ('CCHA','CCHB','CCHH','OVO','FS001')";
            sql_destinos = sql_destinos + " order by a.whsname ";

            daDestinos = new SqlDataAdapter(sql_destinos, Global.conn);

            if (ds.Tables.Contains("destino"))
            {
                ds.Tables["destino"].Clear();
            };

            if (daDestinos.Fill(ds, "destino") > 0)
            {
                cbFiltro.DataSource = ds.Tables["destino"];
                cbFiltro.DisplayMember = "whsname";
                cbFiltro.ValueMember = "whscode";
            }
        }
        private void filtro()
        {
            sql_transferencias = "select a.DocNum as nrodoc, convert(varchar, a.docdate, 103) as fecha, b.ItemCode as codarticulo, ";
            sql_transferencias = sql_transferencias + " b.Dscription as articulo, convert(int, e.quantity*-1) as cantidad, ";
            sql_transferencias = sql_transferencias + " b.WhsCode as Destino, c.SlpName as encargado, a.Comments as comentario, f.distnumber as lote ";
            sql_transferencias = sql_transferencias + " from owtr a with (nolock) ";
            sql_transferencias = sql_transferencias + " inner join wtr1 b with (nolock) on a.DocEntry = b.DocEntry ";
            sql_transferencias = sql_transferencias + " inner join oslp c with (nolock) on a.slpcode = c.SlpCode";
            sql_transferencias = sql_transferencias + " inner join oitl d with (nolock) on a.docnum = d.docentry and b.itemcode = d.itemcode and d.doctype = 67 ";
            sql_transferencias = sql_transferencias + " inner join itl1 e with (nolock) on d.logentry = e.logentry and d.itemcode = e.itemcode ";
            sql_transferencias = sql_transferencias + " inner join obtn f with (nolock) on e.itemcode = f.itemcode and e.sysnumber = f.sysnumber ";
            
            if (Global.deposito == "FC")
            {
                sql_transferencias = sql_transferencias + " where a.filler = 'FC' and b.itemcode like 'CART-0002%' ";                
            }
            else if (Global.deposito == "SIL")
            {
                sql_transferencias = sql_transferencias + " where c.whscode = 'SIL' and b.itmsgrpcod in (106, 153) and b.itemcode like 'B%' ";
            };
            if (rbArticulo.Checked == true)
            {
                sql_transferencias = sql_transferencias + " and b.itemcode = '" + cbFiltro.SelectedValue + "' ";
                sql_transferencias = sql_transferencias + " group by a.docnum, a.docdate, b.itemcode, b.dscription, e.quantity, b.whscode, c.slpname, a.comments, f.distnumber ";
                sql_transferencias = sql_transferencias + " having sum(e.Quantity) < 0 ";
                sql_transferencias = sql_transferencias + " order by a.docnum ";
            }
            else if (rbTransferencia.Checked == true)
            {
                sql_transferencias = sql_transferencias + " and a.docnum = " + txtFiltro.Text;
                sql_transferencias = sql_transferencias + " group by a.docnum, a.docdate, b.itemcode, b.dscription, e.quantity, b.whscode, c.slpname, a.comments, f.distnumber ";
                sql_transferencias = sql_transferencias + " having sum(e.Quantity) < 0 ";
                sql_transferencias = sql_transferencias + " order by a.docnum ";
            }
            else if (rbDestino.Checked == true)
            {
                sql_transferencias = sql_transferencias + " and a.towhscode = '" + cbFiltro.SelectedValue + "' ";
                sql_transferencias = sql_transferencias + " group by a.docnum, a.docdate, b.itemcode, b.dscription, e.quantity, b.whscode, c.slpname, a.comments, f.distnumber ";
                sql_transferencias = sql_transferencias + " having sum(e.Quantity) < 0 ";
                sql_transferencias = sql_transferencias + " order by a.docnum ";
            }
            else if (rbFecha.Checked == true)
            {
                sql_transferencias = sql_transferencias + " and a.docdate between '" + dtpDesde.Value.ToShortDateString() + "' ";
                sql_transferencias = sql_transferencias + " and '" + dtpHasta.Value.ToShortDateString() + "' ";
                sql_transferencias = sql_transferencias + " group by a.docnum, a.docdate, b.itemcode, b.dscription, e.quantity, b.whscode, c.slpname, a.comments, f.distnumber ";
                sql_transferencias = sql_transferencias + " having sum(e.Quantity) < 0 ";
                sql_transferencias = sql_transferencias + " order by a.docnum ";
            }
            else if (rbTodos.Checked == true)
            {
                sql_transferencias = sql_transferencias + " and a.filler = 'FC' and b.itemcode like 'CART-0002%' ";
                sql_transferencias = sql_transferencias + " group by a.docnum, a.docdate, b.itemcode, b.dscription, e.quantity, b.whscode, c.slpname, a.comments, f.distnumber ";
                sql_transferencias = sql_transferencias + " having sum(e.Quantity) < 0 ";
                sql_transferencias = sql_transferencias + " order by a.docnum ";
            };

            daTransferencias = new SqlDataAdapter(sql_transferencias, Global.conn);

            if (ds.Tables.Contains("trans"))
            {
                ds.Tables["trans"].Clear();
            };

            if (daTransferencias.Fill(ds, "trans") > 0)
            {
                dgvTransferencias.DataSource = ds.Tables["trans"];
                txtFiltro.Text = "";
                pbExpExcel.Visible = true;
            }
            else
            {
                dgvTransferencias.DataSource = null;
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
                Exportar OF = new Exportar(@".\TransferenciasMaples.xls");
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
            ExportaXLS(dgvTransferencias);
        }
        private static frmMTransferencias frmDefInstance;
        public static frmMTransferencias DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMTransferencias();
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
            filtro();
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
        private void rbTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTransferencia.Checked == true)
            {
                lblFiltro.Text = "Ingresar Nro. de Transferencia";
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
        private void frmMTransferencias_Load(object sender, EventArgs e)
        {
            dgvTransferencias.DataSource = null;
        }
        private void cmnuNuevo_Click(object sender, EventArgs e)
        {
            
            frmTransferencias frm = new frmTransferencias();
            ////frm.MdiParent = this.ParentForm;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                filtro();
            };
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
        private void rbDestino_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDestino.Checked == true)
            {
                lblFiltro.Text = "Seleccionar Destino";
                lblFiltro.Visible = true;
                cbFiltro.Visible = true;
                llenar_destino();
            }
            else
            {
                lblFiltro.Text = "";
                cbFiltro.Visible = false;
            }
        }
    }
}
