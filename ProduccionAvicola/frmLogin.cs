using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPbobsCOM;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;

namespace ProduccionAvicola
{
    public partial class frmLogin : Form
    {
        Company empresa = new Company();
        public string nombreempresa;
        SqlDataAdapter daUsuario;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUsuario.Text == "")
                {
                    MessageBox.Show("Introduzca el Usuario");
                    tbUsuario.Focus();
                    return;
                };
                if (tbPassword.Text == "")
                {
                    MessageBox.Show("Introduzca la Contraseña");
                    tbPassword.Focus();
                    return;
                };
                
                Cursor.Current = Cursors.WaitCursor;
                empresa.Server = Properties.Settings.Default.Properties["sap_server"].DefaultValue.ToString();
                empresa.CompanyDB = Properties.Settings.Default.Properties["sap_companydb"].DefaultValue.ToString();
                empresa.LicenseServer = Properties.Settings.Default.Properties["sap_server"].DefaultValue.ToString(); ;// "172.16.1.100";
                switch (Properties.Settings.Default.sap_servertype)
                {
                    case "2005":
                        empresa.DbServerType = BoDataServerTypes.dst_MSSQL2005;
                        break;
                    case "2008":
                        empresa.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                        break;
                    case "2014":
                        empresa.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                        break;
                };
                empresa.DbUserName = Properties.Settings.Default.sap_dbusername;
                empresa.DbPassword = Properties.Settings.Default.sap_dbpassword;
                empresa.UserName = tbUsuario.Text;

                if (ds.Tables.Contains("usuario"))
                {
                    ds.Tables["usuario"].Clear();
                };
                daUsuario = new SqlDataAdapter("select * from ousr a with (nolock) inner join oudg b with (nolock) on a.user_code = b.code where a.user_code = '" + tbUsuario.Text + "'", Global.conn);
                daUsuario.Fill(ds, "usuario");

                empresa.Password = tbPassword.Text;

                if (empresa.Connect() != 0)
                {
                    MessageBox.Show("No puede iniciar sesión, verifique el usuario y la contraseña. Detalle: " + empresa.GetLastErrorDescription().ToString() + '-' + empresa.GetLastErrorCode().ToString());
                    tbPassword.Focus();
                }
                else
                {
                    Global.usuario = tbUsuario.Text;
                    Global.password = tbPassword.Text;
                    Global.nombreempresa = empresa.CompanyName;
                    Global.versionsistema = Properties.Settings.Default.version_sistema;
                    Global.usuario_win = SystemInformation.UserName;
                    Global.deposito = ds.Tables["usuario"].Rows[0]["warehouse"].ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                };
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
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
    }
}
