namespace ProduccionAvicola
{
    partial class frmBLotes
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
            this.ds = new System.Data.DataSet();
            this.lot = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.sysnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whscode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MnfSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.lot});
            // 
            // lot
            // 
            this.lot.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.lot.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "sysnumber"}, true)});
            this.lot.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.lot.TableName = "lot";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "sysnumber";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "whscode";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "itemcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lote:";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(63, 8);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(209, 20);
            this.txtLote.TabIndex = 1;
            this.txtLote.TextChanged += new System.EventHandler(this.txtLote_TextChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(389, 307);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(289, 307);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 3;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            this.dgvLotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLotes.AutoGenerateColumns = false;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sysnumber,
            this.whscode,
            this.itemcode,
            this.distnumber,
            this.quantity,
            this.MnfSerial});
            this.dgvLotes.DataMember = "lot";
            this.dgvLotes.DataSource = this.ds;
            this.dgvLotes.Location = new System.Drawing.Point(13, 47);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(554, 237);
            this.dgvLotes.TabIndex = 2;
            this.dgvLotes.DoubleClick += new System.EventHandler(this.dgvLotes_DoubleClick);
            this.dgvLotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLotes_KeyDown);
            this.dgvLotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvLotes_KeyUp);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "distnumber";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "quantity";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "MnfSerial";
            // 
            // sysnumber
            // 
            this.sysnumber.DataPropertyName = "sysnumber";
            this.sysnumber.HeaderText = "Nº Sistema";
            this.sysnumber.Name = "sysnumber";
            this.sysnumber.ReadOnly = true;
            // 
            // whscode
            // 
            this.whscode.DataPropertyName = "whscode";
            this.whscode.HeaderText = "Almacen";
            this.whscode.Name = "whscode";
            this.whscode.ReadOnly = true;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "Cod Articulo";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // distnumber
            // 
            this.distnumber.DataPropertyName = "distnumber";
            this.distnumber.HeaderText = "Lote";
            this.distnumber.Name = "distnumber";
            this.distnumber.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // MnfSerial
            // 
            this.MnfSerial.DataPropertyName = "MnfSerial";
            this.MnfSerial.HeaderText = "Carrito";
            this.MnfSerial.Name = "MnfSerial";
            this.MnfSerial.ReadOnly = true;
            // 
            // frmBLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 339);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.dgvLotes);
            this.Name = "frmBLotes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Lotes";
            this.Load += new System.EventHandler(this.frmBLotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable lot;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        public System.Windows.Forms.DataGridView dgvLotes;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn whscode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn distnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MnfSerial;
    }
}