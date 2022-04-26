using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProduccionAvicola
{
    public partial class frmBLotes : Form
    {
        SqlDataAdapter daLotes;
        DataView dvLotes;
        public string sql;

        public frmBLotes()
        {
            InitializeComponent();
        }
        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLote.Text != "" && ds.Tables.Contains("lotes"))
                {
                    dvLotes.RowFilter = "itemcode like '%" + txtLote.Text + "%' or mnfserial like '%" + txtLote.Text + "%'";
                    dvLotes.Sort = "distnumber";
                    dgvLotes.DataSource = dvLotes;
                };
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void dgvLotes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvLotes.Rows.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }
        private void dgvLotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvLotes.Rows.Count > 0)
            {
                e.Handled = true;
            };
        }
        private void frmBLotes_Load(object sender, EventArgs e)
        {
            try
            {
                daLotes = new SqlDataAdapter(sql, Global.conn);

                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };

                daLotes.Fill(ds, "lotes");
                dvLotes = new DataView(ds.Tables["lotes"]);
                dvLotes.Sort = "distnumber";
                dgvLotes.DataSource = dvLotes;
                txtLote.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.Rows.Count > 0 )
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }
        private void dgvLotes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLotes.Rows.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
