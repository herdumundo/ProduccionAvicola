namespace ProduccionAvicola
{
    partial class frmMOrdenesProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMOrdenesProduccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds = new System.Data.DataSet();
            this.ordenes = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMerma = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLineaMaq = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.pbMasGrande = new System.Windows.Forms.PictureBox();
            this.pbExpExcel = new System.Windows.Forms.PictureBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbLineaMaq = new System.Windows.Forms.RadioButton();
            this.rbOrden = new System.Windows.Forms.RadioButton();
            this.rbArticulo = new System.Windows.Forms.RadioButton();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.docnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.u_maqlinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plannedqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpltqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whsnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasGrande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpExcel)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.ordenes});
            // 
            // ordenes
            // 
            this.ordenes.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14});
            this.ordenes.TableName = "ordenes";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "docnum";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "postdate";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "estado";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "tipo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "itemcode";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "itemname";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "plannedqty";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "cmpltqty";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "pendiente";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "warehouse";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "whsname";
            // 
            // dataColumn12
            // 
            this.dataColumn12.Caption = "u_maqlinea";
            this.dataColumn12.ColumnName = "u_maqlinea";
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
            this.cmnuRecepcion.Click += new System.EventHandler(this.cmnuRecepcion_Click);
            // 
            // cmnuCancelar
            // 
            this.cmnuCancelar.Enabled = false;
            this.cmnuCancelar.Name = "cmnuCancelar";
            this.cmnuCancelar.Size = new System.Drawing.Size(161, 22);
            this.cmnuCancelar.Text = "&Cancelar";
            this.cmnuCancelar.Visible = false;
            this.cmnuCancelar.Click += new System.EventHandler(this.cmnuCancelar_Click);
            // 
            // cmnuCerrar
            // 
            this.cmnuCerrar.Enabled = false;
            this.cmnuCerrar.Name = "cmnuCerrar";
            this.cmnuCerrar.Size = new System.Drawing.Size(161, 22);
            this.cmnuCerrar.Text = "C&errar";
            this.cmnuCerrar.Visible = false;
            this.cmnuCerrar.Click += new System.EventHandler(this.cmnuCerrar_Click);
            // 
            // cmnuMerma
            // 
            this.cmnuMerma.Enabled = false;
            this.cmnuMerma.Name = "cmnuMerma";
            this.cmnuMerma.Size = new System.Drawing.Size(161, 22);
            this.cmnuMerma.Text = "Registrar Merma";
            this.cmnuMerma.Visible = false;
            this.cmnuMerma.Click += new System.EventHandler(this.cmnuMerma_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLineaMaq);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.pbMasGrande);
            this.groupBox1.Controls.Add(this.pbExpExcel);
            this.groupBox1.Controls.Add(this.txtFiltro);
            this.groupBox1.Controls.Add(this.lblFiltro);
            this.groupBox1.Controls.Add(this.cbFiltro);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 90);
            this.groupBox1.TabIndex = 0;
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
            this.groupBox2.Controls.Add(this.rbLineaMaq);
            this.groupBox2.Controls.Add(this.rbOrden);
            this.groupBox2.Controls.Add(this.rbArticulo);
            this.groupBox2.Location = new System.Drawing.Point(20, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 65);
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
            // rbLineaMaq
            // 
            this.rbLineaMaq.AutoSize = true;
            this.rbLineaMaq.Location = new System.Drawing.Point(140, 20);
            this.rbLineaMaq.Name = "rbLineaMaq";
            this.rbLineaMaq.Size = new System.Drawing.Size(103, 17);
            this.rbLineaMaq.TabIndex = 2;
            this.rbLineaMaq.Text = "Linea / Maquina";
            this.rbLineaMaq.UseVisualStyleBackColor = true;
            this.rbLineaMaq.CheckedChanged += new System.EventHandler(this.rbLineaMaq_CheckedChanged);
            // 
            // rbOrden
            // 
            this.rbOrden.AutoSize = true;
            this.rbOrden.Location = new System.Drawing.Point(76, 20);
            this.rbOrden.Name = "rbOrden";
            this.rbOrden.Size = new System.Drawing.Size(54, 17);
            this.rbOrden.TabIndex = 1;
            this.rbOrden.Text = "Orden";
            this.rbOrden.UseVisualStyleBackColor = true;
            this.rbOrden.CheckedChanged += new System.EventHandler(this.rbOrden_CheckedChanged);
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
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AutoGenerateColumns = false;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docnumDataGridViewTextBoxColumn,
            this.postdateDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.turno,
            this.u_maqlinea,
            this.lote,
            this.tipoDataGridViewTextBoxColumn,
            this.plannedqtyDataGridViewTextBoxColumn,
            this.cmpltqtyDataGridViewTextBoxColumn,
            this.pendienteDataGridViewTextBoxColumn,
            this.warehouseDataGridViewTextBoxColumn,
            this.whsnameDataGridViewTextBoxColumn});
            this.dgvOrdenes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOrdenes.DataMember = "ordenes";
            this.dgvOrdenes.DataSource = this.ds;
            this.dgvOrdenes.Location = new System.Drawing.Point(12, 108);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersVisible = false;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(736, 339);
            this.dgvOrdenes.TabIndex = 1;
            this.dgvOrdenes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvOrdenes_MouseDown);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "turno";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "lote";
            // 
            // docnumDataGridViewTextBoxColumn
            // 
            this.docnumDataGridViewTextBoxColumn.DataPropertyName = "docnum";
            this.docnumDataGridViewTextBoxColumn.HeaderText = "N° Orden";
            this.docnumDataGridViewTextBoxColumn.Name = "docnumDataGridViewTextBoxColumn";
            this.docnumDataGridViewTextBoxColumn.ReadOnly = true;
            this.docnumDataGridViewTextBoxColumn.Width = 80;
            // 
            // postdateDataGridViewTextBoxColumn
            // 
            this.postdateDataGridViewTextBoxColumn.DataPropertyName = "postdate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.postdateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.postdateDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.postdateDataGridViewTextBoxColumn.Name = "postdateDataGridViewTextBoxColumn";
            this.postdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.postdateDataGridViewTextBoxColumn.Width = 80;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "Código";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "itemname";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Artículo";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // turno
            // 
            this.turno.DataPropertyName = "turno";
            this.turno.HeaderText = "Turno";
            this.turno.Name = "turno";
            this.turno.ReadOnly = true;
            this.turno.Width = 70;
            // 
            // u_maqlinea
            // 
            this.u_maqlinea.DataPropertyName = "u_maqlinea";
            this.u_maqlinea.HeaderText = "Linea";
            this.u_maqlinea.Name = "u_maqlinea";
            this.u_maqlinea.ReadOnly = true;
            this.u_maqlinea.Width = 60;
            // 
            // lote
            // 
            this.lote.DataPropertyName = "lote";
            this.lote.HeaderText = "Lote";
            this.lote.Name = "lote";
            this.lote.ReadOnly = true;
            this.lote.Width = 70;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Visible = false;
            // 
            // plannedqtyDataGridViewTextBoxColumn
            // 
            this.plannedqtyDataGridViewTextBoxColumn.DataPropertyName = "plannedqty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.plannedqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.plannedqtyDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.plannedqtyDataGridViewTextBoxColumn.Name = "plannedqtyDataGridViewTextBoxColumn";
            this.plannedqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.plannedqtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // cmpltqtyDataGridViewTextBoxColumn
            // 
            this.cmpltqtyDataGridViewTextBoxColumn.DataPropertyName = "cmpltqty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.cmpltqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmpltqtyDataGridViewTextBoxColumn.HeaderText = "Completada";
            this.cmpltqtyDataGridViewTextBoxColumn.Name = "cmpltqtyDataGridViewTextBoxColumn";
            this.cmpltqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.cmpltqtyDataGridViewTextBoxColumn.Visible = false;
            this.cmpltqtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // pendienteDataGridViewTextBoxColumn
            // 
            this.pendienteDataGridViewTextBoxColumn.DataPropertyName = "pendiente";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.pendienteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.pendienteDataGridViewTextBoxColumn.HeaderText = "Pendiente";
            this.pendienteDataGridViewTextBoxColumn.Name = "pendienteDataGridViewTextBoxColumn";
            this.pendienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.pendienteDataGridViewTextBoxColumn.Visible = false;
            this.pendienteDataGridViewTextBoxColumn.Width = 80;
            // 
            // warehouseDataGridViewTextBoxColumn
            // 
            this.warehouseDataGridViewTextBoxColumn.DataPropertyName = "warehouse";
            this.warehouseDataGridViewTextBoxColumn.HeaderText = "Cód. Dep.";
            this.warehouseDataGridViewTextBoxColumn.Name = "warehouseDataGridViewTextBoxColumn";
            this.warehouseDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseDataGridViewTextBoxColumn.Visible = false;
            // 
            // whsnameDataGridViewTextBoxColumn
            // 
            this.whsnameDataGridViewTextBoxColumn.DataPropertyName = "whsname";
            this.whsnameDataGridViewTextBoxColumn.HeaderText = "Deposito";
            this.whsnameDataGridViewTextBoxColumn.Name = "whsnameDataGridViewTextBoxColumn";
            this.whsnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.whsnameDataGridViewTextBoxColumn.Visible = false;
            this.whsnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // frmMOrdenesProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 459);
            this.ControlBox = false;
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMOrdenesProduccion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de Producción";
            this.Load += new System.EventHandler(this.frmMOrdenesProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasGrande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpExcel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable ordenes;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmnuNuevo;
        private System.Windows.Forms.ToolStripMenuItem cmnuRecepcion;
        private System.Windows.Forms.ToolStripMenuItem cmnuCancelar;
        private System.Windows.Forms.ToolStripMenuItem cmnuCerrar;
        private System.Windows.Forms.ToolStripMenuItem cmnuMerma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbLineaMaq;
        private System.Windows.Forms.RadioButton rbOrden;
        private System.Windows.Forms.RadioButton rbArticulo;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.PictureBox pbMasGrande;
        private System.Windows.Forms.PictureBox pbExpExcel;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cbLineaMaq;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn docnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn u_maqlinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plannedqtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpltqtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn whsnameDataGridViewTextBoxColumn;
    }
}