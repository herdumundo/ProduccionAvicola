namespace ProduccionAvicola
{
    partial class frmMRegistroCarritos
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbEstado = new System.Windows.Forms.RadioButton();
            this.rbNCarrito = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rbTipoHuevo = new System.Windows.Forms.RadioButton();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgvCarritos = new System.Windows.Forms.DataGridView();
            this.cmsCarritos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.ds = new System.Data.DataSet();
            this.art = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.rbClasificadora = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritos)).BeginInit();
            this.cmsCarritos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHasta);
            this.groupBox1.Controls.Add(this.lblDesde);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.lblFiltro);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmbFiltro);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.White;
            this.lblFiltro.Location = new System.Drawing.Point(367, 16);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(153, 23);
            this.lblFiltro.TabIndex = 6;
            this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFiltro.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTodos);
            this.groupBox2.Controls.Add(this.rbClasificadora);
            this.groupBox2.Controls.Add(this.rbFecha);
            this.groupBox2.Controls.Add(this.rbEstado);
            this.groupBox2.Controls.Add(this.rbNCarrito);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.rbTipoHuevo);
            this.groupBox2.Location = new System.Drawing.Point(7, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 81);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(6, 50);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 4;
            this.rbFecha.TabStop = true;
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbEstado
            // 
            this.rbEstado.AutoSize = true;
            this.rbEstado.Location = new System.Drawing.Point(228, 22);
            this.rbEstado.Name = "rbEstado";
            this.rbEstado.Size = new System.Drawing.Size(58, 17);
            this.rbEstado.TabIndex = 3;
            this.rbEstado.TabStop = true;
            this.rbEstado.Text = "Estado";
            this.rbEstado.UseVisualStyleBackColor = true;
            this.rbEstado.CheckedChanged += new System.EventHandler(this.rbEstado_CheckedChanged);
            // 
            // rbNCarrito
            // 
            this.rbNCarrito.AutoSize = true;
            this.rbNCarrito.Location = new System.Drawing.Point(127, 22);
            this.rbNCarrito.Name = "rbNCarrito";
            this.rbNCarrito.Size = new System.Drawing.Size(70, 17);
            this.rbNCarrito.TabIndex = 2;
            this.rbNCarrito.TabStop = true;
            this.rbNCarrito.Text = "N° Carrito";
            this.rbNCarrito.UseVisualStyleBackColor = true;
            this.rbNCarrito.CheckedChanged += new System.EventHandler(this.rbNCarrito_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(128, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "N° Carrito";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rbTipoHuevo
            // 
            this.rbTipoHuevo.AutoSize = true;
            this.rbTipoHuevo.Location = new System.Drawing.Point(7, 22);
            this.rbTipoHuevo.Name = "rbTipoHuevo";
            this.rbTipoHuevo.Size = new System.Drawing.Size(96, 17);
            this.rbTipoHuevo.TabIndex = 0;
            this.rbTipoHuevo.TabStop = true;
            this.rbTipoHuevo.Text = "Tipo de Huevo";
            this.rbTipoHuevo.UseVisualStyleBackColor = true;
            this.rbTipoHuevo.CheckedChanged += new System.EventHandler(this.rbTipoHuevo_CheckedChanged);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(367, 45);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(153, 21);
            this.cmbFiltro.TabIndex = 4;
            this.cmbFiltro.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(554, 57);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(554, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(367, 45);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(153, 20);
            this.txtFiltro.TabIndex = 7;
            this.txtFiltro.Visible = false;
            // 
            // dgvCarritos
            // 
            this.dgvCarritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarritos.ContextMenuStrip = this.cmsCarritos;
            this.dgvCarritos.Location = new System.Drawing.Point(13, 116);
            this.dgvCarritos.Name = "dgvCarritos";
            this.dgvCarritos.Size = new System.Drawing.Size(637, 268);
            this.dgvCarritos.TabIndex = 1;
            // 
            // cmsCarritos
            // 
            this.cmsCarritos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuNuevo});
            this.cmsCarritos.Name = "cmsCarritos";
            this.cmsCarritos.Size = new System.Drawing.Size(110, 26);
            // 
            // cmnuNuevo
            // 
            this.cmnuNuevo.Name = "cmnuNuevo";
            this.cmnuNuevo.Size = new System.Drawing.Size(109, 22);
            this.cmnuNuevo.Text = "&Nuevo";
            this.cmnuNuevo.Click += new System.EventHandler(this.cmnuNuevo_Click);
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
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(423, 71);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(97, 20);
            this.dtpHasta.TabIndex = 8;
            this.dtpHasta.Visible = false;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(423, 45);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(97, 20);
            this.dtpDesde.TabIndex = 9;
            this.dtpDesde.Visible = false;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(355, 51);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Visible = false;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(355, 77);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 11;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Visible = false;
            // 
            // rbClasificadora
            // 
            this.rbClasificadora.AutoSize = true;
            this.rbClasificadora.Location = new System.Drawing.Point(127, 50);
            this.rbClasificadora.Name = "rbClasificadora";
            this.rbClasificadora.Size = new System.Drawing.Size(85, 17);
            this.rbClasificadora.TabIndex = 5;
            this.rbClasificadora.TabStop = true;
            this.rbClasificadora.Text = "Clasificadora";
            this.rbClasificadora.UseVisualStyleBackColor = true;
            this.rbClasificadora.CheckedChanged += new System.EventHandler(this.rbClasificadora_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(228, 50);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 6;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // frmMRegistroCarritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 396);
            this.ControlBox = false;
            this.Controls.Add(this.dgvCarritos);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMRegistroCarritos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Carritos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritos)).EndInit();
            this.cmsCarritos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCarritos;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEstado;
        private System.Windows.Forms.RadioButton rbNCarrito;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rbTipoHuevo;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Data.DataSet ds;
        private System.Data.DataTable art;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.ContextMenuStrip cmsCarritos;
        private System.Windows.Forms.ToolStripMenuItem cmnuNuevo;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.RadioButton rbClasificadora;
        private System.Windows.Forms.RadioButton rbTodos;
    }
}