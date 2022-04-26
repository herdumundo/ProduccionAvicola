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
    public partial class frmMRegistroCarritos : Form
    {
        SqlDataAdapter daFiltro;
        SqlDataAdapter daTipoHuevo;
        SqlDataAdapter daEstado;

        string sql_filtro;
        string sql_tipohuevo;
        string sql_estado;

        public frmMRegistroCarritos()
        {
            InitializeComponent();
        }
        private void tipo_huevo()
        {
            sql_tipohuevo = "select distinct tipo_huevo from lotes with (nolock) order by tipo_huevo ";
            daTipoHuevo = new SqlDataAdapter(sql_tipohuevo, Global.conn_clasif);
            if (ds.Tables.Contains("tipo_huevos"))
            {
                ds.Tables["tipo_huevos"].Clear();
            };
            daTipoHuevo.Fill(ds, "tipo_huevos");
            cmbFiltro.DataSource = ds.Tables["tipo_huevos"];
            cmbFiltro.DisplayMember = "tipo_huevo";
            cmbFiltro.ValueMember = "tipo_huevo";
        }
        private void estado()
        {
            sql_estado = "select distinct estado from lotes with (nolock) order by estado ";
            daEstado = new SqlDataAdapter(sql_estado, Global.conn_clasif);
            if (ds.Tables.Contains("estado"))
            {
                ds.Tables["estado"].Clear();
            };
            daEstado.Fill(ds, "estado");
            cmbFiltro.DataSource = ds.Tables["estado"];
            cmbFiltro.DisplayMember = "estado";
            cmbFiltro.ValueMember = "estado";
        }

        private void clasificadora()
        {
            sql_estado = "select distinct clasificadora from lotes order by clasificadora ";
            daEstado = new SqlDataAdapter(sql_estado, Global.conn_clasif);
            if (ds.Tables.Contains("clasificadora"))
            {
                ds.Tables["clasificadora"].Clear();
            };
            daEstado.Fill(ds, "clasificadora");
            cmbFiltro.DataSource = ds.Tables["clasificadora"];
            cmbFiltro.DisplayMember = "clasificadora";
            cmbFiltro.ValueMember = "clasificadora";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private static frmMRegistroCarritos frmDefInstance;
        public static frmMRegistroCarritos DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMRegistroCarritos();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }

        private void cmnuNuevo_Click(object sender, EventArgs e)
        {
            //frmRegistroCarritos.DefInstance.MdiParent = this;
            frmRegistroCarritos.DefInstance.Show();
        }

        private void rbTipoHuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTipoHuevo.Checked == true)
            {
                lblFiltro.Text = "Tipo de Huevo";
                lblFiltro.Visible = true;
                tipo_huevo();
                cmbFiltro.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;
            }
        }

        private void rbNCarrito_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNCarrito.Checked == true)
            {
                lblFiltro.Text = "Número de Carrito";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            sql_filtro = "select * from lotes ";
            if (rbNCarrito.Checked == true)
            {                
                sql_filtro = sql_filtro + " where cod_carrito = " + txtFiltro.Text;
                sql_filtro = sql_filtro + " order by cod_carrito ";
            }
            else if (rbTipoHuevo.Checked == true)
            {
                sql_filtro = sql_filtro + " where tipo_huevo = '" + cmbFiltro.Text + "' ";
                sql_filtro = sql_filtro + " order by tipo_huevo ";
            }
            else if (rbEstado.Checked == true)
            {
                sql_filtro = sql_filtro + " where estado = '" + cmbFiltro.Text + "' ";
                sql_filtro = sql_filtro + " order by estado ";
            }
            else if (rbFecha.Checked == true)
            {
                sql_filtro = sql_filtro + " where fecha between '" + dtpDesde.Value.Date.ToShortDateString() +"' and '" + dtpHasta.Value.Date.ToShortDateString() + "' ";
                sql_filtro = sql_filtro + " order by fecha ";
            }
            else if (rbClasificadora.Checked == true)
            {
                sql_filtro = sql_filtro + " where clasificadora = '" + cmbFiltro.Text + "' ";
                sql_filtro = sql_filtro + " order by clasificadora ";
            }

            daFiltro = new SqlDataAdapter(sql_filtro, Global.conn_clasif);
            if (ds.Tables.Contains("filtro"))
            {
                ds.Tables["filtro"].Clear();
            };
            if (daFiltro.Fill(ds, "filtro") > 0 )
            {
                dgvCarritos.DataSource = ds.Tables["filtro"];
            };            
        }

        private void rbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEstado.Checked == true)
            {
                lblFiltro.Text = "Estado";
                lblFiltro.Visible = true;
                estado();
                cmbFiltro.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;
            }
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFecha.Checked == true)
            {
                lblFiltro.Text = "Fecha de Operación";
                lblFiltro.Visible = true;
                lblDesde.Visible = true;
                lblHasta.Visible = true;
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                lblDesde.Visible = false;
                lblHasta.Visible = false;
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
            }
        }

        private void rbClasificadora_CheckedChanged(object sender, EventArgs e)
        {
            if (rbClasificadora.Checked == true)
            {
                lblFiltro.Text = "Clasificadora";
                lblFiltro.Visible = true;
                clasificadora();
                cmbFiltro.Visible = true;
            }
            else
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
                lblFiltro.Text = "";
                lblFiltro.Visible = false;
                cmbFiltro.Visible = false;
                txtFiltro.Visible = false;
                lblDesde.Visible = false;
                lblHasta.Visible = false;
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
            };
        }
    }
}
