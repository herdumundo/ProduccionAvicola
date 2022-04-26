namespace ProduccionAvicola
{
    partial class frmReciboProduccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds = new System.Data.DataSet();
            this.dtHuevos = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dtLotes = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCantSeleccionada = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.sysnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnfserial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whscodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblArticuloLista = new System.Windows.Forms.Label();
            this.txtCantidadEmision = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCantidadRecepcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPendiente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.lblDeposito = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroOrden = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanificado = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHuevos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotes)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10});
            this.dtLotes.TableName = "dtLotes";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "sysnumber";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "whscode";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "itemcode";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "distnumber";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "quantity";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "mnfserial";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "estado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCantSeleccionada);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgvLotes);
            this.groupBox2.Controls.Add(this.lblArticuloLista);
            this.groupBox2.Controls.Add(this.txtCantidadEmision);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtCantidadRecepcion);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(11, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 42);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtCantSeleccionada
            // 
            this.txtCantSeleccionada.BackColor = System.Drawing.Color.Red;
            this.txtCantSeleccionada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantSeleccionada.Enabled = false;
            this.txtCantSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantSeleccionada.Location = new System.Drawing.Point(172, 44);
            this.txtCantSeleccionada.Name = "txtCantSeleccionada";
            this.txtCantSeleccionada.ReadOnly = true;
            this.txtCantSeleccionada.Size = new System.Drawing.Size(81, 20);
            this.txtCantSeleccionada.TabIndex = 21;
            this.txtCantSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Cantidad  Seleccionada:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Asignar Lote:";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvLotes.AutoGenerateColumns = false;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sysnumberDataGridViewTextBoxColumn,
            this.mnfserial,
            this.whscodeDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.distnumberDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.consumir,
            this.Seleccionar,
            this.estado});
            this.dgvLotes.DataMember = "dtLotes";
            this.dgvLotes.DataSource = this.ds;
            this.dgvLotes.Location = new System.Drawing.Point(24, 72);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(506, 117);
            this.dgvLotes.TabIndex = 1;
            // 
            // sysnumberDataGridViewTextBoxColumn
            // 
            this.sysnumberDataGridViewTextBoxColumn.DataPropertyName = "sysnumber";
            this.sysnumberDataGridViewTextBoxColumn.HeaderText = "sysnumber";
            this.sysnumberDataGridViewTextBoxColumn.Name = "sysnumberDataGridViewTextBoxColumn";
            this.sysnumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // mnfserial
            // 
            this.mnfserial.DataPropertyName = "mnfserial";
            this.mnfserial.HeaderText = "Carrito";
            this.mnfserial.Name = "mnfserial";
            this.mnfserial.Width = 60;
            // 
            // whscodeDataGridViewTextBoxColumn
            // 
            this.whscodeDataGridViewTextBoxColumn.DataPropertyName = "whscode";
            this.whscodeDataGridViewTextBoxColumn.HeaderText = "whscode";
            this.whscodeDataGridViewTextBoxColumn.Name = "whscodeDataGridViewTextBoxColumn";
            this.whscodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // distnumberDataGridViewTextBoxColumn
            // 
            this.distnumberDataGridViewTextBoxColumn.DataPropertyName = "distnumber";
            this.distnumberDataGridViewTextBoxColumn.HeaderText = "Nº Lote";
            this.distnumberDataGridViewTextBoxColumn.Name = "distnumberDataGridViewTextBoxColumn";
            this.distnumberDataGridViewTextBoxColumn.Width = 220;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N0";
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 60;
            // 
            // consumir
            // 
            this.consumir.DataPropertyName = "consumir";
            this.consumir.HeaderText = "Consumir";
            this.consumir.Name = "consumir";
            this.consumir.Width = 60;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Check";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Seleccionar.Width = 50;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.Width = 50;
            // 
            // lblArticuloLista
            // 
            this.lblArticuloLista.BackColor = System.Drawing.Color.SkyBlue;
            this.lblArticuloLista.Location = new System.Drawing.Point(259, 102);
            this.lblArticuloLista.Name = "lblArticuloLista";
            this.lblArticuloLista.Size = new System.Drawing.Size(227, 23);
            this.lblArticuloLista.TabIndex = 16;
            this.lblArticuloLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArticuloLista.Visible = false;
            // 
            // txtCantidadEmision
            // 
            this.txtCantidadEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadEmision.Enabled = false;
            this.txtCantidadEmision.Location = new System.Drawing.Point(172, 103);
            this.txtCantidadEmision.Name = "txtCantidadEmision";
            this.txtCantidadEmision.ReadOnly = true;
            this.txtCantidadEmision.Size = new System.Drawing.Size(81, 20);
            this.txtCantidadEmision.TabIndex = 16;
            this.txtCantidadEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidadEmision.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cantidad  a Emitir:";
            this.label10.Visible = false;
            // 
            // txtCantidadRecepcion
            // 
            this.txtCantidadRecepcion.Location = new System.Drawing.Point(172, 13);
            this.txtCantidadRecepcion.Name = "txtCantidadRecepcion";
            this.txtCantidadRecepcion.Size = new System.Drawing.Size(81, 20);
            this.txtCantidadRecepcion.TabIndex = 0;
            this.txtCantidadRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidadRecepcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidadRecepcion_KeyDown);
            this.txtCantidadRecepcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadRecepcion_KeyPress);
            this.txtCantidadRecepcion.Leave += new System.EventHandler(this.txtCantidadRecepcion_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cantidad  a Recibir:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(288, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(173, 233);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPendiente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRecibido);
            this.groupBox1.Controls.Add(this.lblDeposito);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNroOrden);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPlanificado);
            this.groupBox1.Controls.Add(this.lblArticulo);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Pendiente:";
            // 
            // txtPendiente
            // 
            this.txtPendiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPendiente.Enabled = false;
            this.txtPendiente.Location = new System.Drawing.Point(403, 129);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.ReadOnly = true;
            this.txtPendiente.Size = new System.Drawing.Size(81, 20);
            this.txtPendiente.TabIndex = 14;
            this.txtPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Recibida:";
            // 
            // txtRecibido
            // 
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibido.Enabled = false;
            this.txtRecibido.Location = new System.Drawing.Point(248, 129);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.ReadOnly = true;
            this.txtRecibido.Size = new System.Drawing.Size(81, 20);
            this.txtRecibido.TabIndex = 12;
            this.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDeposito
            // 
            this.lblDeposito.BackColor = System.Drawing.Color.SkyBlue;
            this.lblDeposito.Location = new System.Drawing.Point(82, 78);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(402, 23);
            this.lblDeposito.TabIndex = 11;
            this.lblDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "N° Orden:";
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.Location = new System.Drawing.Point(82, 22);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.ReadOnly = true;
            this.txtNroOrden.Size = new System.Drawing.Size(81, 20);
            this.txtNroOrden.TabIndex = 0;
            this.txtNroOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroOrden_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Depósito:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Planificada:";
            // 
            // txtPlanificado
            // 
            this.txtPlanificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlanificado.Enabled = false;
            this.txtPlanificado.Location = new System.Drawing.Point(82, 129);
            this.txtPlanificado.Name = "txtPlanificado";
            this.txtPlanificado.ReadOnly = true;
            this.txtPlanificado.Size = new System.Drawing.Size(81, 20);
            this.txtPlanificado.TabIndex = 5;
            this.txtPlanificado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblArticulo
            // 
            this.lblArticulo.BackColor = System.Drawing.Color.SkyBlue;
            this.lblArticulo.Location = new System.Drawing.Point(169, 50);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(315, 23);
            this.lblArticulo.TabIndex = 4;
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtArticulo
            // 
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticulo.Enabled = false;
            this.txtArticulo.Location = new System.Drawing.Point(82, 51);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.ReadOnly = true;
            this.txtArticulo.Size = new System.Drawing.Size(81, 20);
            this.txtArticulo.TabIndex = 2;
            this.txtArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Artículo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(251, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // frmReciboProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 269);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReciboProduccion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo de Producción";
            this.Load += new System.EventHandler(this.frmReciboProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHuevos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLotes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable dtHuevos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable dtLotes;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCantSeleccionada;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnfserial;
        private System.Windows.Forms.DataGridViewTextBoxColumn whscodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.Label lblArticuloLista;
        private System.Windows.Forms.TextBox txtCantidadEmision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCantidadRecepcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPendiente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroOrden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanificado;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}