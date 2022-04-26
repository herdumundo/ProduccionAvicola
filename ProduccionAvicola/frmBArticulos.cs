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
    public partial class frmBArticulos : Form
    {
        SqlDataAdapter daArticulos;
        DataView dvArticulos;
        public string sql;
        public frmBArticulos()
        {
            InitializeComponent();
        }
        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtArticulo.Text != "" && ds.Tables.Contains("articulos"))
                {
                    dvArticulos.RowFilter = "itemname like '%" + txtArticulo.Text + "%' or itemcode like '%" + txtArticulo.Text + "%'";
                    dvArticulos.Sort = "itemname";
                    dgvArticulo.DataSource = dvArticulos;
                };
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void dgvArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            };
        }

        private void dgvArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }

        private void frmBArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                daArticulos = new SqlDataAdapter(sql, Global.conn);

                if (ds.Tables.Contains("articulos"))
                {
                    ds.Tables["articulos"].Clear();
                };

                daArticulos.Fill(ds, "articulos");
                dvArticulos = new DataView(ds.Tables["articulos"]);
                dvArticulos.Sort = "itemname";
                dgvArticulo.DataSource = dvArticulos;
                txtArticulo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void dgvArticulos_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.Rows.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
