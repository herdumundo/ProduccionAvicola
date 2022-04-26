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
    public partial class frmMSolTransferencia : Form
    {
        SqlDataAdapter daSolicitudes;
        SqlDataAdapter daAviarios;

        string sql_aviarios;
        string sql_solicitudes;

        public frmMSolTransferencia()
        {
            InitializeComponent();
        }

        private void filtro()
        {
            sql_solicitudes = "select a.docentry, a.docnum, b.itemcode, b.dscription, a.docdate,  ";
            sql_solicitudes = sql_solicitudes + "a.towhscode, convert(int, b.quantity) as quantity, a.docduedate, c.prcname as aviario ";
            sql_solicitudes = sql_solicitudes + "from owtq a ";
            sql_solicitudes = sql_solicitudes + "inner join wtq1 b on a.docentry = b.docentry ";
            sql_solicitudes = sql_solicitudes + "inner join oprc c on b.ocrcode5 = c.prccode ";
            sql_solicitudes = sql_solicitudes + "where a.docstatus = 'O' ";

            daSolicitudes = new SqlDataAdapter(sql_solicitudes, Global.conn);

            if (ds.Tables.Contains("sol"))
            {
                ds.Tables["sol"].Clear();
            };

            if (daSolicitudes.Fill(ds, "sol")>0)
            {
                dgvSolicitudes.DataSource = ds.Tables["sol"];
            };

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            filtro();
        }

        private static frmMSolTransferencia frmDefInstance;
        public static frmMSolTransferencia DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmMSolTransferencia();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
