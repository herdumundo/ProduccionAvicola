namespace ProduccionAvicola
{
    partial class frmOrdenProduccion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.sysnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consumir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ds = new System.Data.DataSet();
            this.dtHuevos = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dtLotes = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.cbTurnos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSiloMaq = new System.Windows.Forms.ComboBox();
            this.lblSiloMaq = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeposito = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDiadelAnho = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHuevos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDiadelAnho);
            this.groupBox1.Controls.Add(this.dgvLotes);
            this.groupBox1.Controls.Add(this.cbTurnos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbSiloMaq);
            this.groupBox1.Controls.Add(this.lblSiloMaq);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbDeposito);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.lblArticulo);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AutoGenerateColumns = false;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sysnumber,
            this.distnumber,
            this.quantity,
            this.Consumir,
            this.Check});
            this.dgvLotes.DataMember = "dtLotes";
            this.dgvLotes.DataSource = this.ds;
            this.dgvLotes.Location = new System.Drawing.Point(265, 83);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLotes.Size = new System.Drawing.Size(312, 148);
            this.dgvLotes.TabIndex = 12;
            this.dgvLotes.Visible = false;
            this.dgvLotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLotes_CellContentClick);
            // 
            // sysnumber
            // 
            this.sysnumber.DataPropertyName = "sysnumber";
            this.sysnumber.HeaderText = "N°";
            this.sysnumber.Name = "sysnumber";
            this.sysnumber.Visible = false;
            this.sysnumber.Width = 40;
            // 
            // distnumber
            // 
            this.distnumber.DataPropertyName = "distnumber";
            this.distnumber.HeaderText = "Lote";
            this.distnumber.Name = "distnumber";
            this.distnumber.ReadOnly = true;
            this.distnumber.Width = 80;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 70;
            // 
            // Consumir
            // 
            this.Consumir.DataPropertyName = "consumir";
            this.Consumir.HeaderText = "Consumir";
            this.Consumir.Name = "Consumir";
            this.Consumir.Width = 70;
            // 
            // Check
            // 
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.Width = 60;
            // 
            // ds
            // 
            this.ds.DataSetName = "NewDataSet";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.dtHuevos,
            this.dtLotes});
            // 
            // dtHuevos
            // 
            this.dtHuevos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn3,
            this.dataColumn4});
            this.dtHuevos.TableName = "huevos";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ItemCode";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ItemName";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "OnHand";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dtLotes
            // 
            this.dtLotes.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn2,
            this.dataColumn5,
            this.dataColumn6});
            this.dtLotes.TableName = "dtLotes";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "sysnumber";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "distnumber";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "quantity";
            // 
            // cbTurnos
            // 
            this.cbTurnos.FormattingEnabled = true;
            this.cbTurnos.Items.AddRange(new object[] {
            "Mañana",
            "Tarde",
            "Noche"});
            this.cbTurnos.Location = new System.Drawing.Point(82, 166);
            this.cbTurnos.Name = "cbTurnos";
            this.cbTurnos.Size = new System.Drawing.Size(177, 21);
            this.cbTurnos.TabIndex = 4;
            this.cbTurnos.SelectedIndexChanged += new System.EventHandler(this.cbTurnos_SelectedIndexChanged);
            this.cbTurnos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTurnos_KeyDown);
            this.cbTurnos.Leave += new System.EventHandler(this.cbTurnos_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Turno:";
            // 
            // cbSiloMaq
            // 
            this.cbSiloMaq.FormattingEnabled = true;
            this.cbSiloMaq.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "C1",
            "C2"});
            this.cbSiloMaq.Location = new System.Drawing.Point(82, 206);
            this.cbSiloMaq.Name = "cbSiloMaq";
            this.cbSiloMaq.Size = new System.Drawing.Size(177, 21);
            this.cbSiloMaq.TabIndex = 5;
            this.cbSiloMaq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaquinas_KeyDown);
            this.cbSiloMaq.Leave += new System.EventHandler(this.cbSiloMaq_Leave);
            // 
            // lblSiloMaq
            // 
            this.lblSiloMaq.AutoSize = true;
            this.lblSiloMaq.Location = new System.Drawing.Point(16, 212);
            this.lblSiloMaq.Name = "lblSiloMaq";
            this.lblSiloMaq.Size = new System.Drawing.Size(51, 13);
            this.lblSiloMaq.TabIndex = 9;
            this.lblSiloMaq.Text = "Máquina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Depósito:";
            // 
            // cmbDeposito
            // 
            this.cmbDeposito.FormattingEnabled = true;
            this.cmbDeposito.Location = new System.Drawing.Point(82, 125);
            this.cmbDeposito.Name = "cmbDeposito";
            this.cmbDeposito.Size = new System.Drawing.Size(177, 21);
            this.cmbDeposito.TabIndex = 3;
            this.cmbDeposito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDeposito_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(82, 88);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(81, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblArticulo
            // 
            this.lblArticulo.BackColor = System.Drawing.Color.SkyBlue;
            this.lblArticulo.Location = new System.Drawing.Point(169, 51);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(408, 20);
            this.lblArticulo.TabIndex = 4;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtArticulo
            // 
            this.txtArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArticulo.Location = new System.Drawing.Point(82, 51);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(81, 20);
            this.txtArticulo.TabIndex = 1;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
            this.txtArticulo.Leave += new System.EventHandler(this.txtArticulo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Artículo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(82, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecha_KeyDown);
            this.dtpFecha.Leave += new System.EventHandler(this.dtpFecha_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(186, 269);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(301, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDiadelAnho
            // 
            this.lblDiadelAnho.BackColor = System.Drawing.Color.SkyBlue;
            this.lblDiadelAnho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiadelAnho.Location = new System.Drawing.Point(191, 21);
            this.lblDiadelAnho.Name = "lblDiadelAnho";
            this.lblDiadelAnho.Size = new System.Drawing.Size(136, 20);
            this.lblDiadelAnho.TabIndex = 13;
            this.lblDiadelAnho.Text = "0";
            this.lblDiadelAnho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOrdenProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 310);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenProduccion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Producción";
            this.Load += new System.EventHandler(this.frmOrdenProduccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHuevos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeposito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Data.DataSet ds;
        private System.Data.DataTable dtHuevos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.ComboBox cbSiloMaq;
        private System.Windows.Forms.Label lblSiloMaq;
        private System.Windows.Forms.ComboBox cbTurnos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Data.DataTable dtLotes;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn distnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consumir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Label lblDiadelAnho;
    }
}