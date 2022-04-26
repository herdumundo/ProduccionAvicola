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
    public partial class frmLotesConv : Form
    {
        SqlDataAdapter daLotesConv;
        DataView dvLotes;
        public string sql;

        public frmLotesConv()
        {
            InitializeComponent();
        }

        private void dgvLotes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }

        private void frmLotesConv_Load(object sender, EventArgs e)
        {
            try
            {
                daLotesConv = new SqlDataAdapter(sql, Global.conn);

                if (ds.Tables.Contains("lotes"))
                {
                    ds.Tables["lotes"].Clear();
                };

                daLotesConv.Fill(ds, "lotes");
                dvLotes = new DataView(ds.Tables["lotes"]);
                dvLotes.Sort = "distnumber";
                dgvLotes.DataSource = dvLotes;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
