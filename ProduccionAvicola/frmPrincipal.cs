using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProduccionAvicola
{
    public partial class frmPrincipal : Form
    {
        SqlDataAdapter daUsuario;
        SqlDataAdapter daCotizacion;

        string sql_cotizacion;
        string sql_usuario;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckCotizacion()
        {
            bool resp = true;
            sql_cotizacion = "select * from ortt with (nolock) where currency = 'USD' and ratedate = '" + DateTime.Now.ToShortDateString() + "'";
            daCotizacion = new SqlDataAdapter(sql_cotizacion, Global.conn);
            if (ds.Tables.Contains("cotizacion"))
            {
                ds.Tables["cotizacion"].Clear();
            };
            if (daCotizacion.Fill(ds, "cotizacion") == 0)
            {
                resp = false;
            }
            else
            {
                resp = true;
            };
            return resp;
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                tsslFecha.Text = DateTime.Now.Date.ToShortDateString();
                tsslUsuario.Text = Global.usuario;
                tsslEmpresa.Text = Global.nombreempresa;
                tsslVersionSistema.Text = Global.versionsistema;
                tsslIP.Text = Global.usuario_win;

                sql_usuario = "select user_code, u_name, warehouse, saleperson ";
                sql_usuario = sql_usuario + " from ousr with (nolock) ";
                sql_usuario = sql_usuario + " inner join oudg with (nolock) on ousr.dfltsgroup = oudg.code ";
                sql_usuario = sql_usuario + " where ousr.user_code = '" + Global.usuario + "'";
                daUsuario = new SqlDataAdapter(sql_usuario, Global.conn);
                if (ds.Tables.Contains("usuario"))
                {
                    ds.Tables["usuario"].Clear();
                };
                if (daUsuario.Fill(ds, "usuario") > 0)
                {
                    Global.nombre_usuario = ds.Tables["usuario"].Rows[0]["u_name"].ToString();
                    tsslUsuario.Text = ds.Tables["usuario"].Rows[0]["u_name"].ToString();
                    Global.deposito = ds.Tables["usuario"].Rows[0]["warehouse"].ToString();
                    tsslSucursal.Text = "001";
                };
                if (CheckCotizacion() == false)
                {
                    MessageBox.Show("No esta registrada la cotización del dia, no podrá realizar: Facturaciones, Transferencias, Entradas, Salidas.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                };                

                if (Global.deposito == "PP")
                {
                    //tsBHRecria.Visible = false;
                    //tsBHProduccion.Visible = true;
                    mnuClasificadora.Enabled = false;
                    mnuProduccion.Enabled = true;
                    mnuRecria.Enabled = false;
                    mnuTesoreria.Enabled = false;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = false;
                    mnuSustentabilidad.Enabled = false;
                    //frmPrincipal.ActiveForm.BackgroundImage = global::ProduccionAvicola.Properties.Resources.fondoPP;
                }
                else if (Global.deposito == "P" || Global.deposito == "Z")
                {
                    //tsBHRecria.Visible = true;
                    //tsBHProduccion.Visible = false;
                    mnuClasificadora.Enabled = false;
                    mnuProduccion.Enabled = false;
                    mnuRecria.Enabled = true;
                    mnuTesoreria.Enabled = false;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = false;
                    mnuMaples.Enabled = false;
                    mnuSustentabilidad.Enabled = false;
                    //frmPrincipal.ActiveForm.BackgroundImage = global::ProduccionAvicola.Properties.Resources.fondoRecria;
                }
                else if (Global.deposito == "CCHA" || Global.deposito == "CCHB" || Global.deposito == "OVO" || Global.deposito == "CCHH")
                {
                    mnuClasificadora.Enabled = true;
                    mnuProduccion.Enabled = false;
                    mnuRecria.Enabled = false;
                    mnuTesoreria.Enabled = false;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = false;
                    mnuMaples.Enabled = false;
                    mnuSustentabilidad.Enabled = false;
                    //frmPrincipal.ActiveForm.BackgroundImage = global::ProduccionAvicola.Properties.Resources.fondoCCH;
                    //Image myimage = new Bitmap(@".\Resources\ovoproductos.jpg");
                    //this.BackgroundImage = myimage;
                    //this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (Global.deposito == "01")
                {
                    mnuClasificadora.Enabled = false;
                    mnuProduccion.Enabled = false;
                    mnuRecria.Enabled = false;
                    mnuTesoreria.Enabled = true;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = false;
                    mnuMaples.Enabled = false;
                    mnuSustentabilidad.Enabled = false;
                }
                else if (Global.deposito == "FC")
                {
                    mnuClasificadora.Enabled = false;
                    mnuProduccion.Enabled = false;
                    mnuRecria.Enabled = false;
                    mnuTesoreria.Enabled = true;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = false;
                    mnuMaples.Enabled = true;
                    mnuSustentabilidad.Enabled = false;
                }
                else
                {
                    mnuClasificadora.Enabled = false;
                    mnuProduccion.Enabled = false;
                    mnuRecria.Enabled = false;
                    mnuTesoreria.Enabled = false;
                    mnuLogistica.Enabled = false;
                    mnuMantenimiento.Enabled = true;
                    mnuMaples.Enabled = false;
                    mnuSustentabilidad.Enabled = true;      
                }
            }
        }
        private void mnuRConsumo_Click(object sender, EventArgs e)
        {
            frmConsumo.DefInstance.MdiParent = this;
            frmConsumo.DefInstance.Show();
        }
        private void mnuRMortandad_Click(object sender, EventArgs e)
        {
            frmMortandadRecria.DefInstance.MdiParent = this;
            frmMortandadRecria.DefInstance.Show();
        }
        private void mnuRSanitacion_Click(object sender, EventArgs e)
        {
            frmVacunacionRecria.DefInstance.MdiParent = this;
            frmVacunacionRecria.DefInstance.Show();
        }
        private void mnuPConsumo_Click(object sender, EventArgs e)
        {
            frmConsumoProduccion.DefInstance.MdiParent = this;
            frmConsumoProduccion.DefInstance.Show();
        }
        private void mnuPMortandad_Click(object sender, EventArgs e)
        {
            frmMortandadProduccion.DefInstance.MdiParent = this;
            frmMortandadProduccion.DefInstance.Show();
        }
        private void mnuCosteoHuevos_Click(object sender, EventArgs e)
        {
            //frmCosteoHuevos.DefInstance.MdiParent = this;
            //frmCosteoHuevos.DefInstance.Show();
            frmCosteoHuevosNew.DefInstance.MdiParent = this;
            frmCosteoHuevosNew.DefInstance.Show();
        }
        private void mnuRegistroCarritos_Click(object sender, EventArgs e)
        {
            frmMRegistroCarritos.DefInstance.MdiParent = this;
            frmMRegistroCarritos.DefInstance.Show();
        }
        private void mnuPVacunacion_Click(object sender, EventArgs e)
        {
            frmVacunacionProduccion.DefInstance.MdiParent = this;
            frmVacunacionProduccion.DefInstance.Show();
        }
        private void mnuEmbarque_Click(object sender, EventArgs e)
        {
            frmEmbarqueHuevos.DefInstance.MdiParent = this;
            frmEmbarqueHuevos.DefInstance.Show();
        }
        private void mnuEntrada_Click(object sender, EventArgs e)
        {
            frmEntradacs frm = new frmEntradacs();
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuRevMortandad_Click(object sender, EventArgs e)
        {
            frmREVMortandadRecria frm = new frmREVMortandadRecria();
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuPagosPersonal_Click(object sender, EventArgs e)
        {
            frmPagosPersonal.DefInstance.MdiParent = this;
            frmPagosPersonal.DefInstance.Show();
        }
        private void mnuInsumos_Click(object sender, EventArgs e)
        {
            frmInsumosRecria.DefInstance.MdiParent = this;
            frmInsumosRecria.DefInstance.Show();
        }
        private void mnuDepPrestamo_Click(object sender, EventArgs e)
        {
            frmPrestHerramientas.DefInstance.MdiParent = this;
            frmPrestHerramientas.DefInstance.Show();
        }
        private void mnuDepDevoluciones_Click(object sender, EventArgs e)
        {
            frmDevHerramientas.DefInstance.MdiParent = this;
            frmDevHerramientas.DefInstance.Show();
        }
        private void mnuLogRepHistorialEnc_Click(object sender, EventArgs e)
        {
            frmReporteEncargado.DefInstance.MdiParent = this;
            frmReporteEncargado.DefInstance.Show();
        }
        private void mnuLogRepDevoluciones_Click(object sender, EventArgs e)
        {
            frmReporteDevolucion.DefInstance.MdiParent = this;
            frmReporteDevolucion.DefInstance.Show();
        }
        private void mnuLogRepPrestamos_Click(object sender, EventArgs e)
        {
            frmReportePrestamo.DefInstance.MdiParent = this;
            frmReportePrestamo.DefInstance.Show();
        }
        private void mnuInsumosCCH_Click(object sender, EventArgs e)
        {
            frmInsumosCCH.DefInstance.MdiParent = this;
            frmInsumosCCH.DefInstance.Show();
        }

        private void mnuOT_Click(object sender, EventArgs e)
        {
            frmOrdenTrabajo.DefInstance.MdiParent = this;
            frmOrdenTrabajo.DefInstance.Show();
        }

        private void tsbConsumo_Click(object sender, EventArgs e)
        {
            frmConsumo.DefInstance.MdiParent = this;
            frmConsumo.DefInstance.Show();
        }

        private void tsbMortandad_Click(object sender, EventArgs e)
        {
            frmMortandadRecria.DefInstance.MdiParent = this;
            frmMortandadRecria.DefInstance.Show();
        }

        private void tsbVacunacion_Click(object sender, EventArgs e)
        {
            frmVacunacionRecria.DefInstance.MdiParent = this;
            frmVacunacionRecria.DefInstance.Show();
        }

        private void tsbInsumos_Click(object sender, EventArgs e)
        {
            frmInsumosRecria.DefInstance.MdiParent = this;
            frmInsumosRecria.DefInstance.Show();
        }

        private void mnuDepTransferencias_Click(object sender, EventArgs e)
        {
            frmTransferencias.DefInstance.MdiParent = this;
            frmTransferencias.DefInstance.Show();
        }

        private void mnuLabEnsayos_Click(object sender, EventArgs e)
        {
            frmLaboratorio.DefInstance.MdiParent = this;
            frmLaboratorio.DefInstance.Show();
        }

        private void mnuCostosIndirectos_Click(object sender, EventArgs e)
        {
            frmCostosRecria.DefInstance.MdiParent = this;
            frmCostosRecria.DefInstance.Show();
        }

        private void mnuTransferencias_Click(object sender, EventArgs e)
        {
            frmTransferenciasBal.DefInstance.MdiParent = this;
            frmTransferenciasBal.DefInstance.Show();
        }

        private void mnuSolTranslado_Click(object sender, EventArgs e)
        {
            frmMSolTransferencia.DefInstance.MdiParent = this;
            frmMSolTransferencia.DefInstance.Show();
        }

        private void mnuCRepCecos_Click(object sender, EventArgs e)
        {
            frmRepCecos.DefInstance.MdiParent = this;
            frmRepCecos.DefInstance.Show();
        }

        private void mnuMOrdenesFabricacion_Click(object sender, EventArgs e)
        {
            frmMOrdenesProduccion.DefInstance.MdiParent = this;
            frmMOrdenesProduccion.DefInstance.Show();
        }

        private void mnuAsientosCecos_Click(object sender, EventArgs e)
        {
            frmActualizarCECOS.DefInstance.MdiParent = this;
            frmActualizarCECOS.DefInstance.Show();
        }

        private void mnuMTransferencias_Click(object sender, EventArgs e)
        {
            frmMTransferencias.DefInstance.MdiParent = this;
            frmMTransferencias.DefInstance.Show();
        }

        private void mnuMMermas_Click(object sender, EventArgs e)
        {
            frmMermas.DefInstance.MdiParent = this;
            frmMermas.DefInstance.Show();
        }

        private void mnuRRepCecos_Click(object sender, EventArgs e)
        {
            frmRepCecos.DefInstance.MdiParent = this;
            frmRepCecos.DefInstance.Show();
        }

        private void mnuSRepCecos_Click(object sender, EventArgs e)
        {
            frmRepCecos.DefInstance.MdiParent = this;
            frmRepCecos.DefInstance.Show();
        }

        private void costeoHuevosViejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCosteoHuevos.DefInstance.MdiParent = this;
            frmCosteoHuevos.DefInstance.Show();
        }
    }
}
