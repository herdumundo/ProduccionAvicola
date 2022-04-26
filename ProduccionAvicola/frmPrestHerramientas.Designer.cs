namespace ProduccionAvicola
{
    partial class frmPrestHerramientas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrestHerramientas));
            this.cmsHerramientas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.ds = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPasar = new System.Windows.Forms.Button();
            this.dvgPrestamo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgGrilla = new System.Windows.Forms.DataGridView();
            this.cellSelecion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramientaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disponibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCant_Dis = new System.Windows.Forms.Label();
            this.lblCant_Req = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDenominacion = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtNomUbi = new System.Windows.Forms.TextBox();
            this.dvgEncargado = new System.Windows.Forms.DataGridView();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtDatos = new System.Data.DataTable();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codEncargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encarg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPrestamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEncargado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsHerramientas
            // 
            this.cmsHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuEliminar});
            this.cmsHerramientas.Name = "cmsCarritos";
            this.cmsHerramientas.Size = new System.Drawing.Size(118, 26);
            // 
            // cmnuEliminar
            // 
            this.cmnuEliminar.Name = "cmnuEliminar";
            this.cmnuEliminar.Size = new System.Drawing.Size(117, 22);
            this.cmnuEliminar.Text = "Eliminar";
            this.cmnuEliminar.Click += new System.EventHandler(this.cmnuEliminar_Click);
            // 
            // ds
            // 
            this.ds.DataSetName = "NewDataSet";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dtDatos});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "dtArticulos";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Codigo";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Herramienta";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Disponible";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(766, 5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(159, 31);
            this.dtpFecha.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnPasar);
            this.groupBox2.Controls.Add(this.dvgPrestamo);
            this.groupBox2.Controls.Add(this.dvgGrilla);
            this.groupBox2.Location = new System.Drawing.Point(30, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 208);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnPasar
            // 
            this.btnPasar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPasar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPasar.BackgroundImage")));
            this.btnPasar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPasar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPasar.Location = new System.Drawing.Point(416, 17);
            this.btnPasar.Name = "btnPasar";
            this.btnPasar.Size = new System.Drawing.Size(65, 41);
            this.btnPasar.TabIndex = 1;
            this.btnPasar.UseVisualStyleBackColor = false;
            this.btnPasar.Click += new System.EventHandler(this.btnPasar_Click);
            // 
            // dvgPrestamo
            // 
            this.dvgPrestamo.AllowUserToAddRows = false;
            this.dvgPrestamo.AllowUserToDeleteRows = false;
            this.dvgPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPrestamo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dvgPrestamo.ContextMenuStrip = this.cmsHerramientas;
            this.dvgPrestamo.Location = new System.Drawing.Point(495, 17);
            this.dvgPrestamo.Name = "dvgPrestamo";
            this.dvgPrestamo.RowHeadersVisible = false;
            this.dvgPrestamo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgPrestamo.Size = new System.Drawing.Size(384, 173);
            this.dvgPrestamo.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Herramienta";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cantidad";
            this.Column3.Name = "Column3";
            // 
            // dvgGrilla
            // 
            this.dvgGrilla.AllowUserToAddRows = false;
            this.dvgGrilla.AllowUserToDeleteRows = false;
            this.dvgGrilla.AutoGenerateColumns = false;
            this.dvgGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellSelecion,
            this.codigoDataGridViewTextBoxColumn,
            this.herramientaDataGridViewTextBoxColumn,
            this.disponibleDataGridViewTextBoxColumn});
            this.dvgGrilla.DataMember = "dtArticulos";
            this.dvgGrilla.DataSource = this.ds;
            this.dvgGrilla.Location = new System.Drawing.Point(12, 17);
            this.dvgGrilla.Name = "dvgGrilla";
            this.dvgGrilla.RowHeadersVisible = false;
            this.dvgGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGrilla.Size = new System.Drawing.Size(390, 173);
            this.dvgGrilla.TabIndex = 0;
            this.dvgGrilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgGrilla_CellContentClick);
            // 
            // cellSelecion
            // 
            this.cellSelecion.HeaderText = "";
            this.cellSelecion.Name = "cellSelecion";
            this.cellSelecion.Width = 30;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 60;
            // 
            // herramientaDataGridViewTextBoxColumn
            // 
            this.herramientaDataGridViewTextBoxColumn.DataPropertyName = "Herramienta";
            this.herramientaDataGridViewTextBoxColumn.HeaderText = "Herramienta";
            this.herramientaDataGridViewTextBoxColumn.Name = "herramientaDataGridViewTextBoxColumn";
            this.herramientaDataGridViewTextBoxColumn.ReadOnly = true;
            this.herramientaDataGridViewTextBoxColumn.Width = 220;
            // 
            // disponibleDataGridViewTextBoxColumn
            // 
            this.disponibleDataGridViewTextBoxColumn.DataPropertyName = "Disponible";
            this.disponibleDataGridViewTextBoxColumn.HeaderText = "Disponible";
            this.disponibleDataGridViewTextBoxColumn.Name = "disponibleDataGridViewTextBoxColumn";
            this.disponibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.disponibleDataGridViewTextBoxColumn.Width = 80;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.lblCant_Dis);
            this.groupBox5.Controls.Add(this.lblCant_Req);
            this.groupBox5.Controls.Add(this.btnClean);
            this.groupBox5.Controls.Add(this.txtCodigo);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.dvgEncargado);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(30, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(895, 172);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Encargado:";
            // 
            // lblCant_Dis
            // 
            this.lblCant_Dis.AutoSize = true;
            this.lblCant_Dis.Location = new System.Drawing.Point(906, 133);
            this.lblCant_Dis.Name = "lblCant_Dis";
            this.lblCant_Dis.Size = new System.Drawing.Size(51, 20);
            this.lblCant_Dis.TabIndex = 5;
            this.lblCant_Dis.Text = "label2";
            // 
            // lblCant_Req
            // 
            this.lblCant_Req.AutoSize = true;
            this.lblCant_Req.Location = new System.Drawing.Point(909, 108);
            this.lblCant_Req.Name = "lblCant_Req";
            this.lblCant_Req.Size = new System.Drawing.Size(51, 20);
            this.lblCant_Req.TabIndex = 4;
            this.lblCant_Req.Text = "label1";
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClean.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClean.BackgroundImage")));
            this.btnClean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Location = new System.Drawing.Point(126, 21);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(32, 30);
            this.btnClean.TabIndex = 1;
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(20, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtCodigo, "Presione F2 para seleccionar encargados");
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown_1);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDenominacion);
            this.groupBox3.Controls.Add(this.txtUbicacion);
            this.groupBox3.Controls.Add(this.txtNomUbi);
            this.groupBox3.Location = new System.Drawing.Point(377, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 143);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Enabled = false;
            this.txtDenominacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenominacion.Location = new System.Drawing.Point(31, 19);
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(361, 29);
            this.txtDenominacion.TabIndex = 0;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Enabled = false;
            this.txtUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUbicacion.Location = new System.Drawing.Point(31, 89);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(361, 29);
            this.txtUbicacion.TabIndex = 2;
            // 
            // txtNomUbi
            // 
            this.txtNomUbi.Enabled = false;
            this.txtNomUbi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUbi.Location = new System.Drawing.Point(31, 54);
            this.txtNomUbi.Name = "txtNomUbi";
            this.txtNomUbi.Size = new System.Drawing.Size(361, 29);
            this.txtNomUbi.TabIndex = 1;
            // 
            // dvgEncargado
            // 
            this.dvgEncargado.AllowUserToAddRows = false;
            this.dvgEncargado.AutoGenerateColumns = false;
            this.dvgEncargado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEncargado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.codEncargado,
            this.encarg});
            this.dvgEncargado.DataMember = "dtDatos";
            this.dvgEncargado.DataSource = this.ds;
            this.dvgEncargado.Location = new System.Drawing.Point(20, 54);
            this.dvgEncargado.Name = "dvgEncargado";
            this.dvgEncargado.RowHeadersVisible = false;
            this.dvgEncargado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvgEncargado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgEncargado.Size = new System.Drawing.Size(351, 103);
            this.dvgEncargado.TabIndex = 2;
            this.dvgEncargado.Visible = false;
            this.dvgEncargado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgEncargado_CellContentClick);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btCancelar.BackgroundImage")));
            this.btCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(820, 519);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(108, 49);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAceptar.BackgroundImage")));
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Location = new System.Drawing.Point(685, 519);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(108, 49);
            this.btAceptar.TabIndex = 4;
            this.btAceptar.UseVisualStyleBackColor = false;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblContador);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Herramienta:";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(899, 34);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(51, 20);
            this.lblContador.TabIndex = 60;
            this.lblContador.Text = "label2";
            this.lblContador.Visible = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticulo.Location = new System.Drawing.Point(102, 23);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(268, 29);
            this.txtArticulo.TabIndex = 0;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
            this.txtArticulo.Leave += new System.EventHandler(this.txtArticulo_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscar.Location = new System.Drawing.Point(376, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(84, 58);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtDatos
            // 
            this.dtDatos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn4,
            this.dataColumn5});
            this.dtDatos.TableName = "dtDatos";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "codigo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "encargado";
            // 
            // Column4
            // 
            this.Column4.FalseValue = "0";
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.TrueValue = "1";
            this.Column4.Width = 50;
            // 
            // codEncargado
            // 
            this.codEncargado.DataPropertyName = "codigo";
            this.codEncargado.HeaderText = "Codigo";
            this.codEncargado.Name = "codEncargado";
            this.codEncargado.Width = 60;
            // 
            // encarg
            // 
            this.encarg.DataPropertyName = "encargado";
            this.encarg.HeaderText = "Encargado";
            this.encarg.Name = "encarg";
            this.encarg.Width = 250;
            // 
            // frmPrestHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(958, 584);
            this.ControlBox = false;
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrestHerramientas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préstamo de Herramientas";
            this.Load += new System.EventHandler(this.frmPrestHerramientas_Load);
            this.cmsHerramientas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPrestamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEncargado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsHerramientas;
        private System.Windows.Forms.ToolStripMenuItem cmnuEliminar;
        private System.Data.DataSet ds;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPasar;
        private System.Windows.Forms.DataGridView dvgPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dvgGrilla;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDenominacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtNomUbi;
        private System.Windows.Forms.DataGridView dvgEncargado;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblCant_Dis;
        private System.Windows.Forms.Label lblCant_Req;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cellSelecion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramientaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disponibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Data.DataTable dtDatos;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEncargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn encarg;
    }
}