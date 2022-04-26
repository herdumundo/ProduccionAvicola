namespace ProduccionAvicola
{
    partial class frmEmbarqueHuevos
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOVO = new System.Windows.Forms.RadioButton();
            this.txtFactRes = new System.Windows.Forms.TextBox();
            this.chkFactRes = new System.Windows.Forms.CheckBox();
            this.cbChoferes = new System.Windows.Forms.ComboBox();
            this.cbCamiones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCCHB = new System.Windows.Forms.RadioButton();
            this.rbCCHA = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCarritos = new System.Windows.Forms.DataGridView();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppserial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnuCarritos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.ds = new System.Data.DataSet();
            this.carritos = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNroCarrito = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblJumbo = new System.Windows.Forms.Label();
            this.lblSuper = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblGigante = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCJ = new System.Windows.Forms.Label();
            this.lblCB = new System.Windows.Forms.Label();
            this.lblCA = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCS = new System.Windows.Forms.Label();
            this.cbDepositos = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritos)).BeginInit();
            this.cmnuCarritos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carritos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(198, 566);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDepositos);
            this.groupBox1.Controls.Add(this.rbOVO);
            this.groupBox1.Controls.Add(this.txtFactRes);
            this.groupBox1.Controls.Add(this.chkFactRes);
            this.groupBox1.Controls.Add(this.cbChoferes);
            this.groupBox1.Controls.Add(this.cbCamiones);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbCCHB);
            this.groupBox1.Controls.Add(this.rbCCHA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbOVO
            // 
            this.rbOVO.AutoSize = true;
            this.rbOVO.Location = new System.Drawing.Point(763, 22);
            this.rbOVO.Name = "rbOVO";
            this.rbOVO.Size = new System.Drawing.Size(48, 17);
            this.rbOVO.TabIndex = 33;
            this.rbOVO.TabStop = true;
            this.rbOVO.Text = "OVO";
            this.rbOVO.UseVisualStyleBackColor = true;
            // 
            // txtFactRes
            // 
            this.txtFactRes.Location = new System.Drawing.Point(455, 98);
            this.txtFactRes.Name = "txtFactRes";
            this.txtFactRes.Size = new System.Drawing.Size(100, 20);
            this.txtFactRes.TabIndex = 6;
            this.txtFactRes.Visible = false;
            this.txtFactRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFactRes_KeyDown);
            this.txtFactRes.Leave += new System.EventHandler(this.txtFactRes_Leave);
            // 
            // chkFactRes
            // 
            this.chkFactRes.AutoSize = true;
            this.chkFactRes.Location = new System.Drawing.Point(455, 74);
            this.chkFactRes.Name = "chkFactRes";
            this.chkFactRes.Size = new System.Drawing.Size(105, 17);
            this.chkFactRes.TabIndex = 4;
            this.chkFactRes.Text = "Factura Reserva";
            this.chkFactRes.UseVisualStyleBackColor = true;
            this.chkFactRes.CheckedChanged += new System.EventHandler(this.chkFactRes_CheckedChanged);
            this.chkFactRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkFactRes_KeyDown);
            // 
            // cbChoferes
            // 
            this.cbChoferes.FormattingEnabled = true;
            this.cbChoferes.Location = new System.Drawing.Point(104, 110);
            this.cbChoferes.Name = "cbChoferes";
            this.cbChoferes.Size = new System.Drawing.Size(307, 21);
            this.cbChoferes.TabIndex = 5;
            this.cbChoferes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbChoferes_KeyDown);
            this.cbChoferes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbChoferes_KeyPress);
            // 
            // cbCamiones
            // 
            this.cbCamiones.FormattingEnabled = true;
            this.cbCamiones.Location = new System.Drawing.Point(105, 80);
            this.cbCamiones.Name = "cbCamiones";
            this.cbCamiones.Size = new System.Drawing.Size(213, 21);
            this.cbCamiones.TabIndex = 3;
            this.cbCamiones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCamiones_KeyDown);
            this.cbCamiones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCamiones_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Clasificadora";
            // 
            // rbCCHB
            // 
            this.rbCCHB.AutoSize = true;
            this.rbCCHB.Location = new System.Drawing.Point(693, 22);
            this.rbCCHB.Name = "rbCCHB";
            this.rbCCHB.Size = new System.Drawing.Size(54, 17);
            this.rbCCHB.TabIndex = 2;
            this.rbCCHB.Text = "CCHB";
            this.rbCCHB.UseVisualStyleBackColor = true;
            this.rbCCHB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbCCHB_KeyDown);
            // 
            // rbCCHA
            // 
            this.rbCCHA.AutoSize = true;
            this.rbCCHA.Checked = true;
            this.rbCCHA.Location = new System.Drawing.Point(633, 22);
            this.rbCCHA.Name = "rbCCHA";
            this.rbCCHA.Size = new System.Drawing.Size(54, 17);
            this.rbCCHA.TabIndex = 1;
            this.rbCCHA.TabStop = true;
            this.rbCCHA.Text = "CCHA";
            this.rbCCHA.UseVisualStyleBackColor = true;
            this.rbCCHA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbCCHA_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Chofer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Camión:";
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.Yellow;
            this.lblCliente.Location = new System.Drawing.Point(210, 50);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(366, 20);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(104, 50);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 2;
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(105, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(99, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecha_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Embarque:";
            // 
            // dgvCarritos
            // 
            this.dgvCarritos.AutoGenerateColumns = false;
            this.dgvCarritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcode,
            this.itemname,
            this.suppserial,
            this.batchnum,
            this.quantity,
            this.indate});
            this.dgvCarritos.ContextMenuStrip = this.cmnuCarritos;
            this.dgvCarritos.DataMember = "carritos";
            this.dgvCarritos.DataSource = this.ds;
            this.dgvCarritos.Location = new System.Drawing.Point(12, 205);
            this.dgvCarritos.Name = "dgvCarritos";
            this.dgvCarritos.ReadOnly = true;
            this.dgvCarritos.RowHeadersVisible = false;
            this.dgvCarritos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarritos.Size = new System.Drawing.Size(411, 330);
            this.dgvCarritos.TabIndex = 2;
            this.dgvCarritos.TabStop = false;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "Código";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "Artículo";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            // 
            // suppserial
            // 
            this.suppserial.DataPropertyName = "suppserial";
            this.suppserial.HeaderText = "Nro Carrito";
            this.suppserial.Name = "suppserial";
            this.suppserial.ReadOnly = true;
            // 
            // batchnum
            // 
            this.batchnum.DataPropertyName = "batchnum";
            this.batchnum.HeaderText = "Cod. Lote";
            this.batchnum.Name = "batchnum";
            this.batchnum.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // indate
            // 
            this.indate.DataPropertyName = "indate";
            this.indate.HeaderText = "Fecha Puesta";
            this.indate.Name = "indate";
            this.indate.ReadOnly = true;
            // 
            // cmnuCarritos
            // 
            this.cmnuCarritos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuEliminar});
            this.cmnuCarritos.Name = "cmnuCarritos";
            this.cmnuCarritos.Size = new System.Drawing.Size(118, 26);
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
            this.ds.DataSetName = "ds";
            this.ds.Tables.AddRange(new System.Data.DataTable[] {
            this.carritos});
            // 
            // carritos
            // 
            this.carritos.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.carritos.TableName = "carritos";
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
            this.dataColumn3.ColumnName = "suppserial";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "batchnum";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "quantity";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "indate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNroCarrito);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtNroCarrito
            // 
            this.txtNroCarrito.Location = new System.Drawing.Point(104, 13);
            this.txtNroCarrito.Name = "txtNroCarrito";
            this.txtNroCarrito.Size = new System.Drawing.Size(100, 20);
            this.txtNroCarrito.TabIndex = 0;
            this.txtNroCarrito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroCarrito_KeyDown);
            this.txtNroCarrito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCarrito_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "N° de Carrito:";
            // 
            // lblJumbo
            // 
            this.lblJumbo.BackColor = System.Drawing.Color.Yellow;
            this.lblJumbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumbo.Location = new System.Drawing.Point(460, 205);
            this.lblJumbo.Name = "lblJumbo";
            this.lblJumbo.Size = new System.Drawing.Size(66, 50);
            this.lblJumbo.TabIndex = 5;
            this.lblJumbo.Text = "0";
            this.lblJumbo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSuper
            // 
            this.lblSuper.BackColor = System.Drawing.Color.Yellow;
            this.lblSuper.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuper.Location = new System.Drawing.Point(460, 260);
            this.lblSuper.Name = "lblSuper";
            this.lblSuper.Size = new System.Drawing.Size(66, 50);
            this.lblSuper.TabIndex = 6;
            this.lblSuper.Text = "0";
            this.lblSuper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblA
            // 
            this.lblA.BackColor = System.Drawing.Color.Yellow;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.Location = new System.Drawing.Point(460, 317);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(66, 50);
            this.lblA.TabIndex = 7;
            this.lblA.Text = "0";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            this.lblB.BackColor = System.Drawing.Color.Yellow;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.Location = new System.Drawing.Point(460, 373);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(66, 50);
            this.lblB.TabIndex = 8;
            this.lblB.Text = "0";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD
            // 
            this.lblD.BackColor = System.Drawing.Color.SteelBlue;
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD.Location = new System.Drawing.Point(571, 317);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(66, 50);
            this.lblD.TabIndex = 13;
            this.lblD.Text = "0";
            this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblC
            // 
            this.lblC.BackColor = System.Drawing.Color.SteelBlue;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC.Location = new System.Drawing.Point(571, 260);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(66, 50);
            this.lblC.TabIndex = 12;
            this.lblC.Text = "0";
            this.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGigante
            // 
            this.lblGigante.BackColor = System.Drawing.Color.SteelBlue;
            this.lblGigante.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGigante.Location = new System.Drawing.Point(571, 205);
            this.lblGigante.Name = "lblGigante";
            this.lblGigante.Size = new System.Drawing.Size(66, 50);
            this.lblGigante.TabIndex = 11;
            this.lblGigante.Text = "0";
            this.lblGigante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Yellow;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(429, 373);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 50);
            this.label19.TabIndex = 20;
            this.label19.Text = "B";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Yellow;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(429, 317);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 50);
            this.label20.TabIndex = 19;
            this.label20.Text = "A";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Yellow;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(429, 260);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 50);
            this.label21.TabIndex = 18;
            this.label21.Text = "S";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Yellow;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(429, 205);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 50);
            this.label22.TabIndex = 17;
            this.label22.Text = "J";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(542, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 50);
            this.label10.TabIndex = 23;
            this.label10.Text = "D";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(542, 260);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 50);
            this.label17.TabIndex = 22;
            this.label17.Text = "C";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(542, 205);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 50);
            this.label18.TabIndex = 21;
            this.label18.Text = "GI";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Carritos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(562, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Cajones";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(299, 566);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(542, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 50);
            this.label6.TabIndex = 30;
            this.label6.Text = "J";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(542, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 50);
            this.label8.TabIndex = 29;
            this.label8.Text = "B";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(542, 373);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 50);
            this.label12.TabIndex = 28;
            this.label12.Text = "A";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCJ
            // 
            this.lblCJ.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCJ.Location = new System.Drawing.Point(571, 485);
            this.lblCJ.Name = "lblCJ";
            this.lblCJ.Size = new System.Drawing.Size(66, 50);
            this.lblCJ.TabIndex = 27;
            this.lblCJ.Text = "0";
            this.lblCJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCB
            // 
            this.lblCB.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCB.Location = new System.Drawing.Point(571, 428);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(66, 50);
            this.lblCB.TabIndex = 26;
            this.lblCB.Text = "0";
            this.lblCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCA
            // 
            this.lblCA.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCA.Location = new System.Drawing.Point(571, 373);
            this.lblCA.Name = "lblCA";
            this.lblCA.Size = new System.Drawing.Size(66, 50);
            this.lblCA.TabIndex = 25;
            this.lblCA.Text = "0";
            this.lblCA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(542, 542);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 50);
            this.label13.TabIndex = 32;
            this.label13.Text = "S";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCS
            // 
            this.lblCS.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCS.Location = new System.Drawing.Point(571, 542);
            this.lblCS.Name = "lblCS";
            this.lblCS.Size = new System.Drawing.Size(66, 50);
            this.lblCS.TabIndex = 31;
            this.lblCS.Text = "0";
            this.lblCS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDepositos
            // 
            this.cbDepositos.FormattingEnabled = true;
            this.cbDepositos.Location = new System.Drawing.Point(284, 19);
            this.cbDepositos.Name = "cbDepositos";
            this.cbDepositos.Size = new System.Drawing.Size(156, 21);
            this.cbDepositos.TabIndex = 1;
            this.cbDepositos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDepositos_KeyDown);
            // 
            // frmEmbarqueHuevos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 615);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblCS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCJ);
            this.Controls.Add(this.lblCB);
            this.Controls.Add(this.lblCA);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.lblGigante);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblSuper);
            this.Controls.Add(this.lblJumbo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvCarritos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmbarqueHuevos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embarque de Huevos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmbarqueHuevos_FormClosed);
            this.Load += new System.EventHandler(this.frmEmbarqueHuevos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritos)).EndInit();
            this.cmnuCarritos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carritos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCarritos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNroCarrito;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblJumbo;
        private System.Windows.Forms.Label lblSuper;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblGigante;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancelar;
        private System.Data.DataSet ds;
        private System.Data.DataTable carritos;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppserial;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn indate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmnuCarritos;
        private System.Windows.Forms.ToolStripMenuItem cmnuEliminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbCCHB;
        private System.Windows.Forms.RadioButton rbCCHA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCJ;
        private System.Windows.Forms.Label lblCB;
        private System.Windows.Forms.Label lblCA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCS;
        private System.Windows.Forms.ComboBox cbChoferes;
        private System.Windows.Forms.ComboBox cbCamiones;
        private System.Windows.Forms.TextBox txtFactRes;
        private System.Windows.Forms.CheckBox chkFactRes;
        private System.Windows.Forms.RadioButton rbOVO;
        private System.Windows.Forms.ComboBox cbDepositos;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crvEmbarq;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crvEmbarq;
    }
}