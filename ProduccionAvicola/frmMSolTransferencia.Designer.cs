namespace ProduccionAvicola
{
    partial class frmMSolTransferencia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMerma = new System.Windows.Forms.ToolStripMenuItem();
            this.ds = new System.Data.DataSet();
            this.solicitudes = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbEstado = new System.Windows.Forms.RadioButton();
            this.rbOrden = new System.Windows.Forms.RadioButton();
            this.rbArticulo = new System.Windows.Forms.RadioButton();
            this.docnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.towhscode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aviario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docduedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // 
            // cmnuRecepcion
            // 
            this.cmnuRecepcion.Enabled = false;
            this.cmnuRecepcion.Name = "cmnuRecepcion";
            this.cmnuRecepcion.Size = new System.Drawing.Size(161, 22);
            this.cmnuRecepcion.Text = "&Recepción";
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
            // 
            // cmnuMerma
            // 
            this.cmnuMerma.Enabled = false;
            this.cmnuMerma.Name = "cmnuMerma";
            this.cmnuMerma.Size = new System.Drawing.Size(161, 22);
            this.cmnuMerma.Text = "Registrar Merma";
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.solicitudes});
            // 
            // solicitudes
            // 
            this.solicitudes.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn10,
            this.dataColumn12});
            this.solicitudes.TableName = "solicitudes";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "docnum";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "docdate";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "itemcode";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "dscription";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "quantity";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "docduedate";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "towhscode";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "aviario";
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.AutoGenerateColumns = false;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docnumDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.dscription,
            this.docdate,
            this.towhscode,
            this.aviario,
            this.quantity,
            this.docduedate});
            this.dgvSolicitudes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSolicitudes.DataMember = "solicitudes";
            this.dgvSolicitudes.DataSource = this.ds;
            this.dgvSolicitudes.Location = new System.Drawing.Point(13, 108);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.RowHeadersVisible = false;
            this.dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.Size = new System.Drawing.Size(736, 339);
            this.dgvSolicitudes.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
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
            this.groupBox2.Controls.Add(this.rbTodos);
            this.groupBox2.Controls.Add(this.rbEstado);
            this.groupBox2.Controls.Add(this.rbOrden);
            this.groupBox2.Controls.Add(this.rbArticulo);
            this.groupBox2.Location = new System.Drawing.Point(20, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 65);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(415, 19);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(78, 17);
            this.rbTodos.TabIndex = 3;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Pendientes";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbEstado
            // 
            this.rbEstado.AutoSize = true;
            this.rbEstado.Location = new System.Drawing.Point(277, 19);
            this.rbEstado.Name = "rbEstado";
            this.rbEstado.Size = new System.Drawing.Size(58, 17);
            this.rbEstado.TabIndex = 2;
            this.rbEstado.Text = "Estado";
            this.rbEstado.UseVisualStyleBackColor = true;
            // 
            // rbOrden
            // 
            this.rbOrden.AutoSize = true;
            this.rbOrden.Location = new System.Drawing.Point(124, 19);
            this.rbOrden.Name = "rbOrden";
            this.rbOrden.Size = new System.Drawing.Size(54, 17);
            this.rbOrden.TabIndex = 1;
            this.rbOrden.Text = "Orden";
            this.rbOrden.UseVisualStyleBackColor = true;
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
            // 
            // docnumDataGridViewTextBoxColumn
            // 
            this.docnumDataGridViewTextBoxColumn.DataPropertyName = "docnum";
            this.docnumDataGridViewTextBoxColumn.HeaderText = "Solicitud";
            this.docnumDataGridViewTextBoxColumn.Name = "docnumDataGridViewTextBoxColumn";
            this.docnumDataGridViewTextBoxColumn.ReadOnly = true;
            this.docnumDataGridViewTextBoxColumn.Width = 60;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "itemcode";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "Código";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // dscription
            // 
            this.dscription.DataPropertyName = "dscription";
            this.dscription.HeaderText = "Articulo";
            this.dscription.Name = "dscription";
            this.dscription.ReadOnly = true;
            this.dscription.Width = 180;
            // 
            // docdate
            // 
            this.docdate.DataPropertyName = "docdate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.docdate.DefaultCellStyle = dataGridViewCellStyle1;
            this.docdate.HeaderText = "Fecha";
            this.docdate.Name = "docdate";
            this.docdate.ReadOnly = true;
            this.docdate.Width = 90;
            // 
            // towhscode
            // 
            this.towhscode.DataPropertyName = "towhscode";
            this.towhscode.HeaderText = "Destino";
            this.towhscode.Name = "towhscode";
            this.towhscode.ReadOnly = true;
            // 
            // aviario
            // 
            this.aviario.DataPropertyName = "aviario";
            this.aviario.HeaderText = "Pintero/Aviario";
            this.aviario.Name = "aviario";
            this.aviario.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 60;
            // 
            // docduedate
            // 
            this.docduedate.DataPropertyName = "docduedate";
            this.docduedate.HeaderText = "Fecha Necesaria";
            this.docduedate.Name = "docduedate";
            this.docduedate.ReadOnly = true;
            this.docduedate.Width = 120;
            // 
            // frmMSolTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 459);
            this.ControlBox = false;
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMSolTransferencia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Solicitudes de Translado de Balanceados Aves";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Data.DataTable solicitudes;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn12;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbEstado;
        private System.Windows.Forms.RadioButton rbOrden;
        private System.Windows.Forms.RadioButton rbArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn docnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn docdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn towhscode;
        private System.Windows.Forms.DataGridViewTextBoxColumn aviario;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn docduedate;
    }
}