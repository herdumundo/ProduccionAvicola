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
    public partial class frmBClientes : Form
    {
        SqlDataAdapter daClientes;

        DataView dvClientes;

        public string sql;
        public frmBClientes()
        {
            InitializeComponent();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCliente.Text != "" && ds.Tables.Contains("clientes"))
                {
                    dvClientes.RowFilter = "cardname like '%" + txtCliente.Text + "%' or cardcode like '%" + txtCliente.Text + "%'";
                    dvClientes.Sort = "cardname";
                    dgvClientes.DataSource = dvClientes;
                };
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            };
        }

        private void dgvClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }

        private void frmBClientes_Load(object sender, EventArgs e)
        {
            try
            {
                daClientes = new SqlDataAdapter(sql, Global.conn);

                if (ds.Tables.Contains("clientes"))
                {
                    ds.Tables["clientes"].Clear();
                };

                daClientes.Fill(ds, "clientes");
                dvClientes = new DataView(ds.Tables["clientes"]);
                dvClientes.Sort = "cardname";
                dgvClientes.DataSource = dvClientes;
                txtCliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
