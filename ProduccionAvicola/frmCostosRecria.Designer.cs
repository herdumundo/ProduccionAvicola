namespace ProduccionAvicola
{
    partial class frmCostosRecria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds = new System.Data.DataSet();
            this.costos = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalCostos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalAves = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCostos = new System.Windows.Forms.DataGridView();
            this.acctcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acctname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorADistribuir = new System.Windows.Forms.TextBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.costos});
            // 
            // costos
            // 
            this.costos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.costos.TableName = "costos";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "acctcode";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "acctname";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "total";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTotalCostos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTotalAves);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvCostos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtValorADistribuir);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Total Costos:";
            // 
            // txtTotalCostos
            // 
            this.txtTotalCostos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCostos.Location = new System.Drawing.Point(92, 373);
            this.txtTotalCostos.Multiline = true;
            this.txtTotalCostos.Name = "txtTotalCostos";
            this.txtTotalCostos.ReadOnly = true;
            this.txtTotalCostos.Size = new System.Drawing.Size(97, 23);
            this.txtTotalCostos.TabIndex = 35;
            this.txtTotalCostos.Text = "0";
            this.txtTotalCostos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Total Aves:";
            // 
            // txtTotalAves
            // 
            this.txtTotalAves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAves.Location = new System.Drawing.Point(92, 339);
            this.txtTotalAves.Multiline = true;
            this.txtTotalAves.Name = "txtTotalAves";
            this.txtTotalAves.ReadOnly = true;
            this.txtTotalAves.Size = new System.Drawing.Size(97, 24);
            this.txtTotalAves.TabIndex = 33;
            this.txtTotalAves.Text = "0";
            this.txtTotalAves.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(477, 16);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(304, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(97, 20);
            this.dtpHasta.TabIndex = 1;
            this.dtpHasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpHasta_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Hasta:";
            // 
            // dgvCostos
            // 
            this.dgvCostos.AutoGenerateColumns = false;
            this.dgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acctcode,
            this.acctname,
            this.total});
            this.dgvCostos.DataMember = "costos";
            this.dgvCostos.DataSource = this.ds;
            this.dgvCostos.Location = new System.Drawing.Point(22, 45);
            this.dgvCostos.Name = "dgvCostos";
            this.dgvCostos.RowHeadersVisible = false;
            this.dgvCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCostos.Size = new System.Drawing.Size(530, 288);
            this.dgvCostos.TabIndex = 3;
            // 
            // acctcode
            // 
            this.acctcode.DataPropertyName = "acctcode";
            this.acctcode.HeaderText = "Nro. Cuenta";
            this.acctcode.Name = "acctcode";
            this.acctcode.Width = 90;
            // 
            // acctname
            // 
            this.acctname.DataPropertyName = "acctname";
            this.acctname.HeaderText = "Nombre Cuenta";
            this.acctname.Name = "acctname";
            this.acctname.Width = 310;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.total.DefaultCellStyle = dataGridViewCellStyle3;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.Width = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Valor a Distribuir:";
            // 
            // txtValorADistribuir
            // 
            this.txtValorADistribuir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorADistribuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorADistribuir.Location = new System.Drawing.Point(455, 339);
            this.txtValorADistribuir.Multiline = true;
            this.txtValorADistribuir.Name = "txtValorADistribuir";
            this.txtValorADistribuir.ReadOnly = true;
            this.txtValorADistribuir.Size = new System.Drawing.Size(97, 24);
            this.txtValorADistribuir.TabIndex = 6;
            this.txtValorADistribuir.Text = "0";
            this.txtValorADistribuir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 19);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(97, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDesde_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(197, 427);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(316, 427);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Ca&ncelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCostosRecria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 462);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCostosRecria";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costos Indirectos Recria";
            this.Load += new System.EventHandler(this.frmCostosRecria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValorADistribuir;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCostos;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Data.DataTable costos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalCostos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalAves;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn acctcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn acctname;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}