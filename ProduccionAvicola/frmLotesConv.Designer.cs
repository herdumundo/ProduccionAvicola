namespace ProduccionAvicola
{
    partial class frmLotesConv
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
            this.lotes = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.distnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onhandqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.lotes});
            // 
            // lotes
            // 
            this.lotes.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.lotes.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "distnumber"}, true)});
            this.lotes.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.lotes.TableName = "lotes";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "distnumber";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "onhandqty";
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
            this.distnumber,
            this.onhandqty,
            this.sysnumber,
            this.itemcode});
            this.dgvLotes.DataMember = "lotes";
            this.dgvLotes.DataSource = this.ds;
            this.dgvLotes.Location = new System.Drawing.Point(25, 30);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(210, 166);
            this.dgvLotes.TabIndex = 22;
            this.dgvLotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvLotes_KeyUp);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(144, 202);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 25;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(44, 202);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 24;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "sysnumber";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "itemcode";
            // 
            // distnumber
            // 
            this.distnumber.DataPropertyName = "distnumber";
            this.distnumber.HeaderText = "Código Lote";
            this.distnumber.Name = "distnumber";
            this.distnumber.ReadOnly = true;
            // 
            // onhandqty
            // 
            this.onhandqty.DataPropertyName = "onhandqty";
            this.onhandqty.HeaderText = "Cantidad";
            this.onhandqty.Name = "onhandqty";
            this.onhandqty.ReadOnly = true;
            // 
            // sysnumber
            // 
            this.sysnumber.DataPropertyName = "sysnumber";
            this.sysnumber.HeaderText = "Sysnumber";
            this.sysnumber.Name = "sysnumber";
            this.sysnumber.ReadOnly = true;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "Código";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // frmLotesConv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 237);
            this.ControlBox = false;
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.dgvLotes);
            this.Name = "frmLotesConv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotes Aves - Convencionales";
            this.Load += new System.EventHandler(this.frmLotesConv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet ds;
        private System.Data.DataTable lotes;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        public System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn distnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn onhandqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sysnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
    }
}