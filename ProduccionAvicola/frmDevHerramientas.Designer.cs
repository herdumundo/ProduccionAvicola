namespace ProduccionAvicola
{
    partial class frmDevHerramientas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevHerramientas));
            this.ds = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.lblnro_transferencia = new System.Windows.Forms.Label();
            this.lblnroPrestamo = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblCant_Prestamo = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtNomUbi = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominacion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dvgGrilla1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.a_devolver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgGrilla = new System.Windows.Forms.DataGridView();
            this.cellSelecion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nroTransferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depOrigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depDestinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroPrestamoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aDevolver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCant_Disp = new System.Windows.Forms.Label();
            this.lblCant_Req = new System.Windows.Forms.Label();
            this.lblCant_a_Devol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "NewDataSet";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn9,
            this.dataColumn10});
            this.dataTable1.TableName = "dtArticulo";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Nro_Transferencia";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Dep_Origen";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Dep_Destino";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Cantidad";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "cantidadA";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "NroPrestamo";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn11,
            this.dataColumn12});
            this.dataTable2.TableName = "dtArticulo1";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "codigo";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "disponible";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "cantidad_prestamo";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "nro_transferencia";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "cantidadA";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "herramienta";
            // 
            // lblnro_transferencia
            // 
            this.lblnro_transferencia.AutoSize = true;
            this.lblnro_transferencia.Location = new System.Drawing.Point(285, 260);
            this.lblnro_transferencia.Name = "lblnro_transferencia";
            this.lblnro_transferencia.Size = new System.Drawing.Size(89, 13);
            this.lblnro_transferencia.TabIndex = 72;
            this.lblnro_transferencia.Text = "nro_transferencia";
            this.lblnro_transferencia.Visible = false;
            // 
            // lblnroPrestamo
            // 
            this.lblnroPrestamo.AutoSize = true;
            this.lblnroPrestamo.Location = new System.Drawing.Point(213, 260);
            this.lblnroPrestamo.Name = "lblnroPrestamo";
            this.lblnroPrestamo.Size = new System.Drawing.Size(66, 13);
            this.lblnroPrestamo.TabIndex = 71;
            this.lblnroPrestamo.Text = "nroPrestamo";
            this.lblnroPrestamo.Visible = false;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(154, 260);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(50, 13);
            this.lblContador.TabIndex = 70;
            this.lblContador.Text = "Contador";
            this.lblContador.Visible = false;
            // 
            // lblCant_Prestamo
            // 
            this.lblCant_Prestamo.AutoSize = true;
            this.lblCant_Prestamo.Location = new System.Drawing.Point(66, 260);
            this.lblCant_Prestamo.Name = "lblCant_Prestamo";
            this.lblCant_Prestamo.Size = new System.Drawing.Size(79, 13);
            this.lblCant_Prestamo.TabIndex = 69;
            this.lblCant_Prestamo.Text = "Cant_Prestamo";
            this.lblCant_Prestamo.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.txtNomUbi);
            this.groupBox5.Controls.Add(this.txtUbicacion);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtDenominacion);
            this.groupBox5.Controls.Add(this.txtCodigo);
            this.groupBox5.Location = new System.Drawing.Point(28, 47);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(811, 100);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Encargado";
            // 
            // txtNomUbi
            // 
            this.txtNomUbi.Enabled = false;
            this.txtNomUbi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUbi.Location = new System.Drawing.Point(425, 35);
            this.txtNomUbi.Name = "txtNomUbi";
            this.txtNomUbi.ReadOnly = true;
            this.txtNomUbi.Size = new System.Drawing.Size(220, 29);
            this.txtNomUbi.TabIndex = 2;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Enabled = false;
            this.txtUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUbicacion.Location = new System.Drawing.Point(651, 35);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(134, 29);
            this.txtUbicacion.TabIndex = 3;
            this.txtUbicacion.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Codigo:";
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Enabled = false;
            this.txtDenominacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenominacion.Location = new System.Drawing.Point(186, 35);
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.ReadOnly = true;
            this.txtDenominacion.Size = new System.Drawing.Size(233, 29);
            this.txtDenominacion.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(80, 35);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblnro_transferencia);
            this.groupBox1.Controls.Add(this.dvgGrilla1);
            this.groupBox1.Controls.Add(this.lblnroPrestamo);
            this.groupBox1.Controls.Add(this.dvgGrilla);
            this.groupBox1.Controls.Add(this.lblContador);
            this.groupBox1.Controls.Add(this.lblCant_Prestamo);
            this.groupBox1.Location = new System.Drawing.Point(28, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Articulos";
            // 
            // dvgGrilla1
            // 
            this.dvgGrilla1.AllowUserToAddRows = false;
            this.dvgGrilla1.AllowUserToDeleteRows = false;
            this.dvgGrilla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGrilla1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.a_devolver});
            this.dvgGrilla1.Location = new System.Drawing.Point(435, 19);
            this.dvgGrilla1.Name = "dvgGrilla1";
            this.dvgGrilla1.RowHeadersVisible = false;
            this.dvgGrilla1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGrilla1.Size = new System.Drawing.Size(350, 178);
            this.dvgGrilla1.TabIndex = 1;
            this.dvgGrilla1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgGrilla1_CellContentClick_1);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "check";
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 30;
            // 
            // a_devolver
            // 
            this.a_devolver.DataPropertyName = "a_devolver";
            this.a_devolver.HeaderText = "A Devolver";
            this.a_devolver.Name = "a_devolver";
            this.a_devolver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.a_devolver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.a_devolver.Width = 70;
            // 
            // dvgGrilla
            // 
            this.dvgGrilla.AllowUserToAddRows = false;
            this.dvgGrilla.AllowUserToDeleteRows = false;
            this.dvgGrilla.AutoGenerateColumns = false;
            this.dvgGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGrilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellSelecion,
            this.nroTransferenciaDataGridViewTextBoxColumn,
            this.depOrigenDataGridViewTextBoxColumn,
            this.depDestinoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.cantidadADataGridViewTextBoxColumn,
            this.nroPrestamoDataGridViewTextBoxColumn});
            this.dvgGrilla.DataMember = "dtArticulo";
            this.dvgGrilla.DataSource = this.ds;
            this.dvgGrilla.Location = new System.Drawing.Point(15, 19);
            this.dvgGrilla.MultiSelect = false;
            this.dvgGrilla.Name = "dvgGrilla";
            this.dvgGrilla.RowHeadersVisible = false;
            this.dvgGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGrilla.Size = new System.Drawing.Size(401, 178);
            this.dvgGrilla.TabIndex = 0;
            this.dvgGrilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgGrilla_CellContentClick_1);
            // 
            // cellSelecion
            // 
            this.cellSelecion.HeaderText = "";
            this.cellSelecion.Name = "cellSelecion";
            this.cellSelecion.Width = 30;
            // 
            // nroTransferenciaDataGridViewTextBoxColumn
            // 
            this.nroTransferenciaDataGridViewTextBoxColumn.DataPropertyName = "Nro_Transferencia";
            this.nroTransferenciaDataGridViewTextBoxColumn.HeaderText = "N° Transferencia";
            this.nroTransferenciaDataGridViewTextBoxColumn.Name = "nroTransferenciaDataGridViewTextBoxColumn";
            this.nroTransferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroTransferenciaDataGridViewTextBoxColumn.Width = 110;
            // 
            // depOrigenDataGridViewTextBoxColumn
            // 
            this.depOrigenDataGridViewTextBoxColumn.DataPropertyName = "Dep_Origen";
            this.depOrigenDataGridViewTextBoxColumn.HeaderText = "Origen";
            this.depOrigenDataGridViewTextBoxColumn.Name = "depOrigenDataGridViewTextBoxColumn";
            this.depOrigenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depDestinoDataGridViewTextBoxColumn
            // 
            this.depDestinoDataGridViewTextBoxColumn.DataPropertyName = "Dep_Destino";
            this.depDestinoDataGridViewTextBoxColumn.HeaderText = "Destino";
            this.depDestinoDataGridViewTextBoxColumn.Name = "depDestinoDataGridViewTextBoxColumn";
            this.depDestinoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 80;
            // 
            // cantidadADataGridViewTextBoxColumn
            // 
            this.cantidadADataGridViewTextBoxColumn.DataPropertyName = "cantidadA";
            this.cantidadADataGridViewTextBoxColumn.HeaderText = "cantidadA";
            this.cantidadADataGridViewTextBoxColumn.Name = "cantidadADataGridViewTextBoxColumn";
            this.cantidadADataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadADataGridViewTextBoxColumn.Visible = false;
            // 
            // nroPrestamoDataGridViewTextBoxColumn
            // 
            this.nroPrestamoDataGridViewTextBoxColumn.DataPropertyName = "NroPrestamo";
            this.nroPrestamoDataGridViewTextBoxColumn.HeaderText = "NroPrestamo";
            this.nroPrestamoDataGridViewTextBoxColumn.Name = "nroPrestamoDataGridViewTextBoxColumn";
            this.nroPrestamoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroPrestamoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(718, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 29);
            this.dtpFecha.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(746, 376);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 37);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(647, 376);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(93, 37);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // aDevolver
            // 
            this.aDevolver.HeaderText = "A Devolver";
            this.aDevolver.Name = "aDevolver";
            // 
            // lblCant_Disp
            // 
            this.lblCant_Disp.AutoSize = true;
            this.lblCant_Disp.Location = new System.Drawing.Point(492, 385);
            this.lblCant_Disp.Name = "lblCant_Disp";
            this.lblCant_Disp.Size = new System.Drawing.Size(56, 13);
            this.lblCant_Disp.TabIndex = 75;
            this.lblCant_Disp.Text = "Cant_Disp";
            this.lblCant_Disp.Visible = false;
            // 
            // lblCant_Req
            // 
            this.lblCant_Req.AutoSize = true;
            this.lblCant_Req.Location = new System.Drawing.Point(565, 385);
            this.lblCant_Req.Name = "lblCant_Req";
            this.lblCant_Req.Size = new System.Drawing.Size(55, 13);
            this.lblCant_Req.TabIndex = 74;
            this.lblCant_Req.Text = "Cant_Req";
            this.lblCant_Req.Visible = false;
            // 
            // lblCant_a_Devol
            // 
            this.lblCant_a_Devol.AutoSize = true;
            this.lblCant_a_Devol.Location = new System.Drawing.Point(401, 386);
            this.lblCant_a_Devol.Name = "lblCant_a_Devol";
            this.lblCant_a_Devol.Size = new System.Drawing.Size(63, 13);
            this.lblCant_a_Devol.TabIndex = 73;
            this.lblCant_a_Devol.Text = "Cant_Devol";
            this.lblCant_a_Devol.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "nro_transferencia";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "nroPrestamo";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Contador";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Cant_Prestamo";
            this.label5.Visible = false;
            // 
            // frmDevHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(858, 437);
            this.ControlBox = false;
            this.Controls.Add(this.lblCant_Disp);
            this.Controls.Add(this.lblCant_Req);
            this.Controls.Add(this.lblCant_a_Devol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDevHerramientas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución Herramientas";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.Label lblnro_transferencia;
        private System.Windows.Forms.Label lblnroPrestamo;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblCant_Prestamo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtNomUbi;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDenominacion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dvgGrilla1;
        private System.Windows.Forms.DataGridView dvgGrilla;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cellSelecion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroTransferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depOrigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depDestinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroPrestamoDataGridViewTextBoxColumn;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn a_devolver;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDevolver;
        private System.Windows.Forms.Label lblCant_Disp;
        private System.Windows.Forms.Label lblCant_Req;
        private System.Windows.Forms.Label lblCant_a_Devol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}