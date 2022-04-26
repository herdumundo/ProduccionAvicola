namespace ProduccionAvicola
{
    partial class frmMTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMTransferencias));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMerma = new System.Windows.Forms.ToolStripMenuItem();
            this.ds = new System.Data.DataSet();
            this.transferencias = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dgvTransferencias = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLineaMaq = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.pbExpExcel = new System.Windows.Forms.PictureBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbDestino = new System.Windows.Forms.RadioButton();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbArticulo = new System.Windows.Forms.RadioButton();
            this.pbMasGrande = new System.Windows.Forms.PictureBox();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.nrodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codarticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferencias)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpExcel)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasGrande)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuNuevo,
            this.cmnuRecepcion,
            this.cmnuCancelar,
            this.cmnuCerrar,
            this.cmnuMerma});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 114);
            // 
            // cmnuNuevo
            // 
            this.cmnuNuevo.Name = "cmnuNuevo";
            this.cmnuNuevo.Size = new System.Drawing.Size(161, 22);
            this.cmnuNuevo.Text = "&Nuevo";
            this.cmnuNuevo.Click += new System.EventHandler(this.cmnuNuevo_Click);
            // 
            // cmnuRecepcion
            // 
            this.cmnuRecepcion.Enabled = false;
            this.cmnuRecepcion.Name = "cmnuRecepcion";
            this.cmnuRecepcion.Size = new System.Drawing.Size(161, 22);
            this.cmnuRecepcion.Text = "&Recepción";
            this.cmnuRecepcion.Visible = false;
            // 
            // cmnuCancelar
            // 
            this.cmnuCancelar.Enabled = false;
            this.cmnuCancelar.Name = "cmnuCancelar";
            this.cmnuCancelar.Size = new System.Drawing.Size(161, 22);
            this.cmnuCancelar.Text = "&Cancelar";
            this.cmnuCancelar.Visible = false;
            // 
            // cmnuCerrar
            // 
            this.cmnuCerrar.Enabled = false;
            this.cmnuCerrar.Name = "cmnuCerrar";
            this.cmnuCerrar.Size = new System.Drawing.Size(161, 22);
            this.cmnuCerrar.Text = "C&errar";
            this.cmnuCerrar.Visible = false;
            // 
            // cmnuMerma
            // 
            this.cmnuMerma.Enabled = false;
            this.cmnuMerma.Name = "cmnuMerma";
            this.cmnuMerma.Size = new System.Drawing.Size(161, 22);
            this.cmnuMerma.Text = "Registrar Merma";
            this.cmnuMerma.Visible = false;
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.transferencias});
            // 
            // transferencias
            // 
            this.transferencias.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn4,
            this.dataColumn7,
            this.dataColumn8});
            this.transferencias.TableName = "transferencias";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "nrodoc";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "fecha";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "codarticulo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "articulo";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "cantidad";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "destino";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "encargado";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "comentario";
            // 
            // dgvTransferencias
            // 
            this.dgvTransferencias.AllowUserToDeleteRows = false;
            this.dgvTransferencias.AutoGenerateColumns = false;
            this.dgvTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrodoc,
            this.fecha,
            this.codarticulo,
            this.articulo,
            this.lote,
            this.cantidad,
            this.destino,
            this.encargado,
            this.comentario});
            this.dgvTransferencias.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTransferencias.DataMember = "transferencias";
            this.dgvTransferencias.DataSource = this.ds;
            this.dgvTransferencias.Location = new System.Drawing.Point(13, 108);
            this.dgvTransferencias.Name = "dgvTransferencias";
            this.dgvTransferencias.ReadOnly = true;
            this.dgvTransferencias.RowHeadersVisible = false;
            this.dgvTransferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferencias.Size = new System.Drawing.Size(736, 339);
            this.dgvTransferencias.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLineaMaq);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.pbExpExcel);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.lblFiltro);
            this.groupBox1.Controls.Add(this.cbFiltro);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pbMasGrande);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cbLineaMaq
            // 
            this.cbLineaMaq.FormattingEnabled = true;
            this.cbLineaMaq.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "C1",
            "C2"});
            this.cbLineaMaq.Location = new System.Drawing.Point(401, 59);
            this.cbLineaMaq.Name = "cbLineaMaq";
            this.cbLineaMaq.Size = new System.Drawing.Size(177, 21);
            this.cbLineaMaq.TabIndex = 5;
            this.cbLineaMaq.Visible = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(533, 59);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(83, 20);
            this.dtpHasta.TabIndex = 14;
            this.dtpHasta.Visible = false;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(364, 60);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(83, 20);
            this.dtpDesde.TabIndex = 13;
            this.dtpDesde.Visible = false;
            // 
            // pbExpExcel
            // 
            this.pbExpExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExpExcel.BackgroundImage")));
            this.pbExpExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExpExcel.Location = new System.Drawing.Point(307, 33);
            this.pbExpExcel.Name = "pbExpExcel";
            this.pbExpExcel.Size = new System.Drawing.Size(27, 23);
            this.pbExpExcel.TabIndex = 11;
            this.pbExpExcel.TabStop = false;
            this.pbExpExcel.Visible = false;
            this.pbExpExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbExpExcel_MouseMove);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(440, 59);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 10;
            this.txtFiltro.Visible = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.BackColor = System.Drawing.Color.SkyBlue;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(360, 23);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(257, 23);
            this.lblFiltro.TabIndex = 9;
            this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFiltro.Visible = false;
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(363, 59);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(254, 21);
            this.cbFiltro.TabIndex = 8;
            this.cbFiltro.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(634, 61);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(634, 19);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFecha);
            this.groupBox2.Controls.Add(this.rbTodos);
            this.groupBox2.Controls.Add(this.rbDestino);
            this.groupBox2.Controls.Add(this.rbTransferencia);
            this.groupBox2.Controls.Add(this.rbArticulo);
            this.groupBox2.Location = new System.Drawing.Point(20, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 65);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(7, 43);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(55, 17);
            this.rbFecha.TabIndex = 4;
            this.rbFecha.Text = "Fecha";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(76, 43);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(81, 17);
            this.rbTodos.TabIndex = 3;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Registrados";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbDestino
            // 
            this.rbDestino.AutoSize = true;
            this.rbDestino.Location = new System.Drawing.Point(167, 20);
            this.rbDestino.Name = "rbDestino";
            this.rbDestino.Size = new System.Drawing.Size(61, 17);
            this.rbDestino.TabIndex = 2;
            this.rbDestino.Text = "Destino";
            this.rbDestino.UseVisualStyleBackColor = true;
            this.rbDestino.CheckedChanged += new System.EventHandler(this.rbDestino_CheckedChanged);
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Location = new System.Drawing.Point(76, 20);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(90, 17);
            this.rbTransferencia.TabIndex = 1;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            this.rbTransferencia.CheckedChanged += new System.EventHandler(this.rbTransferencia_CheckedChanged);
            // 
            // rbArticulo
            // 
            this.rbArticulo.AutoSize = true;
            this.rbArticulo.Location = new System.Drawing.Point(7, 20);
            this.rbArticulo.Name = "rbArticulo";
            this.rbArticulo.Size = new System.Drawing.Size(62, 17);
            this.rbArticulo.TabIndex = 0;
            this.rbArticulo.Text = "Artículo";
            this.rbArticulo.UseVisualStyleBackColor = true;
            this.rbArticulo.CheckedChanged += new System.EventHandler(this.rbArticulo_CheckedChanged);
            // 
            // pbMasGrande
            // 
            this.pbMasGrande.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMasGrande.BackgroundImage")));
            this.pbMasGrande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMasGrande.Location = new System.Drawing.Point(297, 27);
            this.pbMasGrande.Name = "pbMasGrande";
            this.pbMasGrande.Size = new System.Drawing.Size(46, 36);
            this.pbMasGrande.TabIndex = 12;
            this.pbMasGrande.TabStop = false;
            this.pbMasGrande.Visible = false;
            this.pbMasGrande.Click += new System.EventHandler(this.pbMasGrande_Click);
            this.pbMasGrande.MouseLeave += new System.EventHandler(this.pbMasGrande_MouseLeave);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Column1";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "lote";
            // 
            // nrodoc
            // 
            this.nrodoc.DataPropertyName = "nrodoc";
            this.nrodoc.HeaderText = "N° Doc";
            this.nrodoc.Name = "nrodoc";
            this.nrodoc.ReadOnly = true;
            this.nrodoc.Width = 80;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 80;
            // 
            // codarticulo
            // 
            this.codarticulo.DataPropertyName = "codarticulo";
            this.codarticulo.HeaderText = "Código";
            this.codarticulo.Name = "codarticulo";
            this.codarticulo.ReadOnly = true;
            // 
            // articulo
            // 
            this.articulo.DataPropertyName = "articulo";
            this.articulo.HeaderText = "Articulo";
            this.articulo.Name = "articulo";
            this.articulo.ReadOnly = true;
            this.articulo.Width = 200;
            // 
            // lote
            // 
            this.lote.DataPropertyName = "lote";
            this.lote.HeaderText = "Lote";
            this.lote.Name = "lote";
            this.lote.ReadOnly = true;
            this.lote.Width = 80;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 80;
            // 
            // destino
            // 
            this.destino.DataPropertyName = "destino";
            this.destino.HeaderText = "Destino";
            this.destino.Name = "destino";
            this.destino.ReadOnly = true;
            this.destino.Width = 80;
            // 
            // encargado
            // 
            this.encargado.DataPropertyName = "encargado";
            this.encargado.HeaderText = "Encargado";
            this.encargado.Name = "encargado";
            this.encargado.ReadOnly = true;
            this.encargado.Width = 120;
            // 
            // comentario
            // 
            this.comentario.DataPropertyName = "comentario";
            this.comentario.HeaderText = "Comentario";
            this.comentario.Name = "comentario";
            this.comentario.ReadOnly = true;
            this.comentario.Width = 150;
            // 
            // frmMTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 459);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTransferencias);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMTransferencias";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencias de Maples";
            this.Load += new System.EventHandler(this.frmMTransferencias_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferencias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpExcel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasGrande)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmnuNuevo;
        private System.Windows.Forms.ToolStripMenuItem cmnuRecepcion;
        private System.Windows.Forms.ToolStripMenuItem cmnuCancelar;
        private System.Windows.Forms.ToolStripMenuItem cmnuCerrar;
        private System.Windows.Forms.ToolStripMenuItem cmnuMerma;
        private System.Data.DataSet ds;
        private System.Data.DataTable transferencias;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.DataGridView dgvTransferencias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbLineaMaq;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.PictureBox pbMasGrande;
        private System.Windows.Forms.PictureBox pbExpExcel;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbDestino;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbArticulo;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codarticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn encargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario;
    }
}