namespace ProduccionAvicola
{
    partial class frmLaboratorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaboratorio));
            this.ds = new System.Data.DataSet();
            this.art = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.listadet = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliMed = new System.Windows.Forms.Button();
            this.btnInsMed = new System.Windows.Forms.Button();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInsumos = new System.Windows.Forms.Label();
            this.txtInsumos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvListaDet = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.udescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTest = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAreas = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDet)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.art,
            this.listadet});
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
            // listadet
            // 
            this.listadet.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.listadet.TableName = "listadet";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "code";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "lineid";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "u_codigo";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "u_descripcion";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "u_cant";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(323, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(213, 424);
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
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dgvListaDet);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbTest);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbAreas);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliMed);
            this.groupBox2.Controls.Add(this.btnInsMed);
            this.groupBox2.Controls.Add(this.txtDosis);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblInsumos);
            this.groupBox2.Controls.Add(this.txtInsumos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(22, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnEliMed
            // 
            this.btnEliMed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliMed.BackgroundImage")));
            this.btnEliMed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliMed.Location = new System.Drawing.Point(495, 15);
            this.btnEliMed.Name = "btnEliMed";
            this.btnEliMed.Size = new System.Drawing.Size(31, 25);
            this.btnEliMed.TabIndex = 3;
            this.btnEliMed.TabStop = false;
            // 
            // btnInsMed
            // 
            this.btnInsMed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInsMed.BackgroundImage")));
            this.btnInsMed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsMed.Location = new System.Drawing.Point(458, 15);
            this.btnInsMed.Name = "btnInsMed";
            this.btnInsMed.Size = new System.Drawing.Size(31, 25);
            this.btnInsMed.TabIndex = 2;
            this.btnInsMed.Click += new System.EventHandler(this.btnInsMed_Click);
            // 
            // txtDosis
            // 
            this.txtDosis.Location = new System.Drawing.Point(413, 17);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(33, 20);
            this.txtDosis.TabIndex = 1;
            this.txtDosis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDosis_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Dosis:";
            // 
            // lblInsumos
            // 
            this.lblInsumos.BackColor = System.Drawing.Color.Yellow;
            this.lblInsumos.Location = new System.Drawing.Point(142, 17);
            this.lblInsumos.Name = "lblInsumos";
            this.lblInsumos.Size = new System.Drawing.Size(220, 20);
            this.lblInsumos.TabIndex = 11;
            this.lblInsumos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInsumos
            // 
            this.txtInsumos.Location = new System.Drawing.Point(58, 17);
            this.txtInsumos.Name = "txtInsumos";
            this.txtInsumos.Size = new System.Drawing.Size(74, 20);
            this.txtInsumos.TabIndex = 0;
            this.txtInsumos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInsumos_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Insumo:";
            // 
            // dgvListaDet
            // 
            this.dgvListaDet.AutoGenerateColumns = false;
            this.dgvListaDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.lineidDataGridViewTextBoxColumn,
            this.ucodigoDataGridViewTextBoxColumn,
            this.udescripcionDataGridViewTextBoxColumn,
            this.ucantDataGridViewTextBoxColumn});
            this.dgvListaDet.DataMember = "listadet";
            this.dgvListaDet.DataSource = this.ds;
            this.dgvListaDet.Location = new System.Drawing.Point(22, 182);
            this.dgvListaDet.Name = "dgvListaDet";
            this.dgvListaDet.RowHeadersVisible = false;
            this.dgvListaDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaDet.Size = new System.Drawing.Size(530, 141);
            this.dgvListaDet.TabIndex = 5;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Visible = false;
            // 
            // lineidDataGridViewTextBoxColumn
            // 
            this.lineidDataGridViewTextBoxColumn.DataPropertyName = "lineid";
            this.lineidDataGridViewTextBoxColumn.HeaderText = "#";
            this.lineidDataGridViewTextBoxColumn.Name = "lineidDataGridViewTextBoxColumn";
            this.lineidDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineidDataGridViewTextBoxColumn.Visible = false;
            this.lineidDataGridViewTextBoxColumn.Width = 50;
            // 
            // ucodigoDataGridViewTextBoxColumn
            // 
            this.ucodigoDataGridViewTextBoxColumn.DataPropertyName = "u_codigo";
            this.ucodigoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.ucodigoDataGridViewTextBoxColumn.Name = "ucodigoDataGridViewTextBoxColumn";
            this.ucodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ucodigoDataGridViewTextBoxColumn.Width = 120;
            // 
            // udescripcionDataGridViewTextBoxColumn
            // 
            this.udescripcionDataGridViewTextBoxColumn.DataPropertyName = "u_descripcion";
            this.udescripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.udescripcionDataGridViewTextBoxColumn.Name = "udescripcionDataGridViewTextBoxColumn";
            this.udescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.udescripcionDataGridViewTextBoxColumn.Width = 300;
            // 
            // ucantDataGridViewTextBoxColumn
            // 
            this.ucantDataGridViewTextBoxColumn.DataPropertyName = "u_cant";
            this.ucantDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.ucantDataGridViewTextBoxColumn.Name = "ucantDataGridViewTextBoxColumn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Ensayo:";
            // 
            // cbTest
            // 
            this.cbTest.FormattingEnabled = true;
            this.cbTest.Location = new System.Drawing.Point(70, 85);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(301, 21);
            this.cbTest.TabIndex = 3;
            this.cbTest.SelectedIndexChanged += new System.EventHandler(this.cbTest_SelectedIndexChanged);
            this.cbTest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTest_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(85, 339);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(467, 52);
            this.txtComentario.TabIndex = 6;
            this.txtComentario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComentario_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Area:";
            // 
            // cbAreas
            // 
            this.cbAreas.FormattingEnabled = true;
            this.cbAreas.Location = new System.Drawing.Point(70, 51);
            this.cbAreas.Name = "cbAreas";
            this.cbAreas.Size = new System.Drawing.Size(301, 21);
            this.cbAreas.TabIndex = 1;
            this.cbAreas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAreas_KeyDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // frmLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 459);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLaboratorio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ensayos Laboratorio";
            this.Load += new System.EventHandler(this.frmLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.art)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable art;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAreas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaDet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTest;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnEliMed;
        internal System.Windows.Forms.Button btnInsMed;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInsumos;
        private System.Windows.Forms.TextBox txtInsumos;
        private System.Windows.Forms.Label label4;
        private System.Data.DataTable listadet;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ucodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn udescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ucantDataGridViewTextBoxColumn;
    }
}