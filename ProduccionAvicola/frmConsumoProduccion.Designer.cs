namespace ProduccionAvicola
{
    partial class frmConsumoProduccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumoProduccion));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTanque = new System.Windows.Forms.Label();
            this.cmbTanque = new System.Windows.Forms.ComboBox();
            this.rbAVPTradic = new System.Windows.Forms.RadioButton();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbAVPB = new System.Windows.Forms.RadioButton();
            this.rbAVPA = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDepositos = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ds = new System.Data.DataSet();
            this.art = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.rbAVPH = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(327, 323);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(217, 323);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbAVPH);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblTanque);
            this.groupBox1.Controls.Add(this.cmbTanque);
            this.groupBox1.Controls.Add(this.rbAVPTradic);
            this.groupBox1.Controls.Add(this.lblUnidadMedida);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.rbAVPB);
            this.groupBox1.Controls.Add(this.rbAVPA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.lblArticulo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDepositos);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Artículo";
            // 
            // lblTanque
            // 
            this.lblTanque.AutoSize = true;
            this.lblTanque.Location = new System.Drawing.Point(278, 83);
            this.lblTanque.Name = "lblTanque";
            this.lblTanque.Size = new System.Drawing.Size(44, 13);
            this.lblTanque.TabIndex = 16;
            this.lblTanque.Text = "Tanque";
            this.lblTanque.Visible = false;
            // 
            // cmbTanque
            // 
            this.cmbTanque.FormattingEnabled = true;
            this.cmbTanque.Location = new System.Drawing.Point(340, 80);
            this.cmbTanque.Name = "cmbTanque";
            this.cmbTanque.Size = new System.Drawing.Size(212, 21);
            this.cmbTanque.TabIndex = 5;
            this.cmbTanque.Visible = false;
            // 
            // rbAVPTradic
            // 
            this.rbAVPTradic.AutoSize = true;
            this.rbAVPTradic.Location = new System.Drawing.Point(177, 53);
            this.rbAVPTradic.Name = "rbAVPTradic";
            this.rbAVPTradic.Size = new System.Drawing.Size(72, 17);
            this.rbAVPTradic.TabIndex = 3;
            this.rbAVPTradic.Text = "PP Tradic";
            this.rbAVPTradic.UseVisualStyleBackColor = true;
            this.rbAVPTradic.CheckedChanged += new System.EventHandler(this.rbAVPTradic_CheckedChanged);
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.BackColor = System.Drawing.Color.Yellow;
            this.lblUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadMedida.Location = new System.Drawing.Point(201, 204);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(70, 23);
            this.lblUnidadMedida.TabIndex = 15;
            this.lblUnidadMedida.Text = "Kgr";
            this.lblUnidadMedida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(99, 243);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(453, 52);
            this.txtComentario.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCantidad);
            this.groupBox2.Controls.Add(this.lblLote);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(22, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 49);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.Yellow;
            this.lblCantidad.Location = new System.Drawing.Point(439, 18);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(85, 23);
            this.lblCantidad.TabIndex = 12;
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLote
            // 
            this.lblLote.BackColor = System.Drawing.Color.Yellow;
            this.lblLote.Location = new System.Drawing.Point(117, 18);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(132, 23);
            this.lblLote.TabIndex = 10;
            this.lblLote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lote de Ponedoras";
            // 
            // rbAVPB
            // 
            this.rbAVPB.AutoSize = true;
            this.rbAVPB.Location = new System.Drawing.Point(100, 53);
            this.rbAVPB.Name = "rbAVPB";
            this.rbAVPB.Size = new System.Drawing.Size(49, 17);
            this.rbAVPB.TabIndex = 2;
            this.rbAVPB.Text = "PP B";
            this.rbAVPB.UseVisualStyleBackColor = true;
            this.rbAVPB.CheckedChanged += new System.EventHandler(this.rbAVPB_CheckedChanged);
            this.rbAVPB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAVPB_KeyDown);
            // 
            // rbAVPA
            // 
            this.rbAVPA.AutoSize = true;
            this.rbAVPA.Checked = true;
            this.rbAVPA.Location = new System.Drawing.Point(22, 53);
            this.rbAVPA.Name = "rbAVPA";
            this.rbAVPA.Size = new System.Drawing.Size(49, 17);
            this.rbAVPA.TabIndex = 1;
            this.rbAVPA.TabStop = true;
            this.rbAVPA.Text = "PP A";
            this.rbAVPA.UseVisualStyleBackColor = true;
            this.rbAVPA.CheckedChanged += new System.EventHandler(this.rbAVPA_CheckedChanged);
            this.rbAVPA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAVPA_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(99, 206);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(97, 20);
            this.txtCantidad.TabIndex = 7;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            // 
            // lblArticulo
            // 
            this.lblArticulo.BackColor = System.Drawing.Color.Yellow;
            this.lblArticulo.Location = new System.Drawing.Point(201, 167);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(351, 23);
            this.lblArticulo.TabIndex = 6;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Artículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aviario";
            // 
            // cbDepositos
            // 
            this.cbDepositos.FormattingEnabled = true;
            this.cbDepositos.Location = new System.Drawing.Point(340, 52);
            this.cbDepositos.Name = "cbDepositos";
            this.cbDepositos.Size = new System.Drawing.Size(212, 21);
            this.cbDepositos.TabIndex = 4;
            this.cbDepositos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDepositos_KeyDown);
            this.cbDepositos.Leave += new System.EventHandler(this.cbDepositos_Leave);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(70, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(97, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecha_KeyDown);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(99, 168);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(97, 20);
            this.txtArticulo.TabIndex = 6;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.art});
            // 
            // art
            // 
            this.art.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.art.TableName = "art";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "itemcode";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "itemname";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "quantity";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "precio";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "total";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "impuesto";
            // 
            // rbAVPH
            // 
            this.rbAVPH.AutoSize = true;
            this.rbAVPH.Location = new System.Drawing.Point(22, 76);
            this.rbAVPH.Name = "rbAVPH";
            this.rbAVPH.Size = new System.Drawing.Size(50, 17);
            this.rbAVPH.TabIndex = 18;
            this.rbAVPH.Text = "PP H";
            this.rbAVPH.UseVisualStyleBackColor = true;
            this.rbAVPH.CheckedChanged += new System.EventHandler(this.rbAVPH_CheckedChanged);
            this.rbAVPH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbAVPH_KeyDown);
            // 
            // frmConsumoProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(605, 355);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsumoProduccion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumo - Producción";
            this.Load += new System.EventHandler(this.frmConsumoProduccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAVPB;
        private System.Windows.Forms.RadioButton rbAVPA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDepositos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label1;
        private System.Data.DataSet ds;
        private System.Data.DataTable art;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.RadioButton rbAVPTradic;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.Label lblTanque;
        private System.Windows.Forms.ComboBox cmbTanque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbAVPH;
    }
}