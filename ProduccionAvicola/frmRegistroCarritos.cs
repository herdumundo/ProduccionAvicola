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

namespace ProduccionAvicola
{
    public partial class frmRegistroCarritos : Form
    {
        SqlDataAdapter daClasificacion;
        SqlDataAdapter daMedidas;
        SqlDataAdapter daCodigo;
        SqlDataAdapter daCantidades;

        string sql_cantidades;
        string sql_clasificacion;
        string sql_medidas;
        string sql;

        int codigo;
        public frmRegistroCarritos()
        {
            InitializeComponent();
        }

        private void limpiar_form()
        {
            lblCodLote.Text = "";
            txtNroCarrito.Text = "";
            cmbTipoHuevo.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            dtpFechaPuesta.Value = DateTime.Now;
            dtpHoraClasificacion.Value = DateTime.Now;
            cmbUnidadMedida.SelectedIndex = -1;
            txtCantidad.Text = "0";            
            txtComentario.Text = "";
            txtCajones.Text = "0";
            dtpFecha.Focus();
        }
        private void categoria()
        {
            sql_clasificacion = "select * from clasificaciones order by desc_clasificacion";
            daClasificacion = new SqlDataAdapter(sql_clasificacion, Global.conn_clasif);
            if (ds.Tables.Contains("categoria"))
            {
                ds.Tables["categoria"].Clear();
            };
            daClasificacion.Fill(ds, "categoria");
            cmbCategoria.DataSource = ds.Tables["categoria"];
            cmbCategoria.DisplayMember = "desc_clasificacion";
            cmbCategoria.ValueMember = "cod_clasificacion";
        }
        private void medidas()
        {
            sql_medidas = "select u_medida, desc_medida from medidas order by desc_medida";
            daMedidas = new SqlDataAdapter(sql_medidas, Global.conn_clasif);
            if (ds.Tables.Contains("medidas"))
            {
                ds.Tables["medidas"].Clear();
            };
            daMedidas.Fill(ds, "medidas");
            cmbUnidadMedida.DataSource = ds.Tables["medidas"];
            cmbUnidadMedida.DisplayMember = "desc_medida";
            cmbUnidadMedida.ValueMember = "u_medida";
        }
        private static frmRegistroCarritos frmDefInstance;
        public static frmRegistroCarritos DefInstance
        {
            get
            {
                if (frmDefInstance == null || frmDefInstance.IsDisposed)
                {
                    frmDefInstance = new frmRegistroCarritos();
                };
                return frmDefInstance;
            }
            set
            {
                frmDefInstance = value;
            }
        }
        private void frmRegistroCarritos_Load(object sender, EventArgs e)
        {
            categoria();
            medidas();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //--#########################################################--
            //--Validación de campos
            //--#########################################################--
            if (rbCCHA.Checked == false && rbCCHB.Checked == false)
            {
                MessageBox.Show("Debe seleccionar el centro de clasificación correcto");
                return;
            };

            if (txtNroCarrito.Text == "")
            {
                MessageBox.Show("El número de carrito no ha sido registrado");
                return;
            };
            if (cmbTipoHuevo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar tipo de huevo");
                return;
            };

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la categoria de huevo");
                return;
            };


            recuperar_codigo();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Global.conn_clasif;
            try
            {
                SqlCommand cmd = new SqlCommand("pa_alta_lotes");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = conn;

                SqlParameter RetValue = new SqlParameter("Return Value", SqlDbType.Int);
                RetValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetValue);
                SqlParameter cod_interno = new SqlParameter("@cod_interno", SqlDbType.Int);
                cod_interno.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_interno);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.DateTime);
                fecha.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha);
                SqlParameter cod_carrito = new SqlParameter("@cod_carrito", SqlDbType.VarChar, 20);
                cod_carrito.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_carrito);
                SqlParameter tipo_huevo = new SqlParameter("@tipo_huevo", SqlDbType.VarChar, 2);
                tipo_huevo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(tipo_huevo);
                SqlParameter cod_clasificacion = new SqlParameter("@cod_clasificacion", SqlDbType.VarChar, 3);
                cod_clasificacion.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_clasificacion);
                SqlParameter fecha_puesta = new SqlParameter("@fecha_puesta", SqlDbType.DateTime);
                fecha_puesta.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(fecha_puesta);
                SqlParameter hora_clasificacion = new SqlParameter("@hora_clasificacion", SqlDbType.DateTime);
                hora_clasificacion.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(hora_clasificacion);
                SqlParameter cod_lote = new SqlParameter("@cod_lote", SqlDbType.VarChar, 30);
                cod_lote.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cod_lote);
                SqlParameter resp_clasificacion = new SqlParameter("@resp_clasificacion", SqlDbType.VarChar, 50);
                resp_clasificacion.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(resp_clasificacion);
                SqlParameter resp_control_calidad = new SqlParameter("@resp_control_calidad", SqlDbType.VarChar, 50);
                resp_control_calidad.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(resp_control_calidad);
                SqlParameter hora_control_calidad = new SqlParameter("@hora_control_calidad", SqlDbType.DateTime);
                hora_control_calidad.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(hora_control_calidad);
                SqlParameter u_medida = new SqlParameter("@u_medida", SqlDbType.VarChar, 3);
                u_medida.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(u_medida);
                SqlParameter cantidad = new SqlParameter("@cantidad", SqlDbType.Decimal, 18);
                cantidad.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(cantidad);
                SqlParameter estado = new SqlParameter("@estado", SqlDbType.VarChar, 1);
                estado.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(estado);
                SqlParameter clasificadora = new SqlParameter("@clasificadora", SqlDbType.VarChar, 1);
                clasificadora.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(clasificadora);
                SqlParameter mensaje = new SqlParameter("@mensaje", SqlDbType.VarChar, 100);
                mensaje.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(mensaje);

                cod_interno.Value = codigo;
                fecha.Value = dtpFecha.Value;
                cod_carrito.Value = txtNroCarrito.Text;
                tipo_huevo.Value = cmbTipoHuevo.Text;
                cod_clasificacion.Value = cmbCategoria.SelectedValue;
                fecha_puesta.Value = dtpFechaPuesta.Value;
                hora_clasificacion.Value = dtpHoraClasificacion.Value;
                cod_lote.Value = lblCodLote.Text;
                resp_clasificacion.Value = "prueba";
                resp_control_calidad.Value = "prueba_control";
                hora_control_calidad.Value = dtpHoraClasificacion.Value;
                u_medida.Value = cmbUnidadMedida.SelectedValue;
                cantidad.Value = txtCantidad.Text;
                estado.Value = "C";
                if (rbCCHA.Checked == true)
                {
                    clasificadora.Value = "A"; //Cambiar por combobox
                }
                else
                {
                    clasificadora.Value = "B"; //Cambiar por combobox
                }
                
                mensaje.Value = "";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();

                if (int.Parse(RetValue.Value.ToString()) == 0)
                {
                    MessageBox.Show(mensaje.Value.ToString());
                }
                else
                {
                    MessageBox.Show(mensaje.Value.ToString());
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                limpiar_form();
            }
        }
        private void cmbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtNroCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cmbTipoHuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cmbClasificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void dtpFechaPuesta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void dtpHoraClasificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void cmbUnidadMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void recuperar_codigo()
        {
            sql = "select isnull(max(cod_interno), 0) + 1 as codigo from lotes";
            daCodigo = new SqlDataAdapter(sql, Global.conn_clasif);
            if (ds.Tables.Contains("lotes"))
            {
                ds.Tables["lotes"].Clear();
            }
            daCodigo.Fill(ds, "lotes");
            codigo = int.Parse(ds.Tables["lotes"].Rows[0]["codigo"].ToString());
        }
        private void calcular_cantidad()
        {
            sql_cantidades = "select cant_bulto from medidas where u_medida = '" + cmbUnidadMedida.SelectedValue + "'";
            daCantidades = new SqlDataAdapter(sql_cantidades, Global.conn_clasif);
            if (ds.Tables.Contains("cantidades"))
            {
                ds.Tables["cantidades"].Clear();
            };
            daCantidades.Fill(ds, "cantidades");
            txtCantidad.Text = ds.Tables["cantidades"].Rows[0]["cant_bulto"].ToString();
        }
        private void generar_lote()
        {
            lblCodLote.Text = txtNroCarrito.Text + "_" + dtpFechaPuesta.Value.ToShortDateString() + "_" + cmbTipoHuevo.Text + "_" + cmbCategoria.SelectedValue;
        }
        private void cmbUnidadMedida_Leave(object sender, EventArgs e)
        {
            if (cmbUnidadMedida.SelectedIndex != -1 )
            {
                calcular_cantidad();
                generar_lote();
            }
        }

        private void cmbTipoHuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoHuevo.Text == "GI" || cmbTipoHuevo.Text == "C" || cmbTipoHuevo.Text == "D")
            {
                txtCajones.Visible = true;
            }
            else
            {
                txtCajones.Visible = false;
            }
            
        }

        private void txtCajones_TextChanged(object sender, EventArgs e)
        {
            if (txtCajones.Text != "0" && txtCajones.Text != "")
            {
                txtCantidad.Text = (int.Parse(txtCajones.Text) * int.Parse(txtCantidad.Text)).ToString();
            }

        }
    }
}
