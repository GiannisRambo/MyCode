namespace OrderMatchCSharp
{
    partial class MatchingEngine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.lblOrderBook = new System.Windows.Forms.Label();
            this.dgBids = new System.Windows.Forms.DataGridView();
            this.dsOrders = new System.Data.DataSet();
            this.dtBuyOrders = new System.Data.DataTable();
            this.buyPrice = new System.Data.DataColumn();
            this.buySize = new System.Data.DataColumn();
            this.buyCellStyle = new System.Data.DataColumn();
            this.buyOrderId = new System.Data.DataColumn();
            this.dcBuySymbol = new System.Data.DataColumn();
            this.dcBuyClientID = new System.Data.DataColumn();
            this.dtSellOrders = new System.Data.DataTable();
            this.sellPrice = new System.Data.DataColumn();
            this.sellSize = new System.Data.DataColumn();
            this.sellCellStyle = new System.Data.DataColumn();
            this.sellOrderId = new System.Data.DataColumn();
            this.dcSellSymbol = new System.Data.DataColumn();
            this.dcSellClientID = new System.Data.DataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTickers = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgAsks = new System.Windows.Forms.DataGridView();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.txtConnections = new System.Windows.Forms.TextBox();
            this.lblConnections = new System.Windows.Forms.Label();
            this.lblClient1 = new System.Windows.Forms.Label();
            this.lblClient2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBuyOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSellOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAsks)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStopServer
            // 
            this.btnStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopServer.Location = new System.Drawing.Point(270, 6);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(114, 64);
            this.btnStopServer.TabIndex = 0;
            this.btnStopServer.Text = "Exit";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // lblOrderBook
            // 
            this.lblOrderBook.AutoSize = true;
            this.lblOrderBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderBook.Location = new System.Drawing.Point(12, 9);
            this.lblOrderBook.Name = "lblOrderBook";
            this.lblOrderBook.Size = new System.Drawing.Size(131, 25);
            this.lblOrderBook.TabIndex = 1;
            this.lblOrderBook.Text = "Order Book";
            // 
            // dgBids
            // 
            this.dgBids.AllowUserToAddRows = false;
            this.dgBids.AllowUserToDeleteRows = false;
            this.dgBids.AllowUserToResizeColumns = false;
            this.dgBids.AllowUserToResizeRows = false;
            this.dgBids.AutoGenerateColumns = false;
            this.dgBids.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgBids.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgBids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ClientID});
            this.dgBids.DataMember = "ALLBuyOrders";
            this.dgBids.DataSource = this.dsOrders;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = null;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBids.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgBids.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgBids.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBids.EnableHeadersVisualStyles = false;
            this.dgBids.Location = new System.Drawing.Point(0, 78);
            this.dgBids.MultiSelect = false;
            this.dgBids.Name = "dgBids";
            this.dgBids.ReadOnly = true;
            this.dgBids.RowHeadersVisible = false;
            this.dgBids.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgBids.RowTemplate.ReadOnly = true;
            this.dgBids.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgBids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgBids.Size = new System.Drawing.Size(494, 295);
            this.dgBids.TabIndex = 3;
            this.dgBids.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBids_CellFormatting);
            // 
            // dsOrders
            // 
            this.dsOrders.DataSetName = "dsOrders";
            this.dsOrders.Tables.AddRange(new System.Data.DataTable[] {
            this.dtBuyOrders,
            this.dtSellOrders});
            // 
            // dtBuyOrders
            // 
            this.dtBuyOrders.Columns.AddRange(new System.Data.DataColumn[] {
            this.buyPrice,
            this.buySize,
            this.buyCellStyle,
            this.buyOrderId,
            this.dcBuySymbol,
            this.dcBuyClientID});
            this.dtBuyOrders.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "OrderID"}, true)});
            this.dtBuyOrders.PrimaryKey = new System.Data.DataColumn[] {
        this.buyOrderId};
            this.dtBuyOrders.TableName = "ALLBuyOrders";
            // 
            // buyPrice
            // 
            this.buyPrice.ColumnName = "Price";
            this.buyPrice.DataType = typeof(double);
            // 
            // buySize
            // 
            this.buySize.ColumnName = "Size";
            this.buySize.DataType = typeof(int);
            // 
            // buyCellStyle
            // 
            this.buyCellStyle.ColumnMapping = System.Data.MappingType.Attribute;
            this.buyCellStyle.ColumnName = "CellStyle";
            this.buyCellStyle.DataType = typeof(int);
            // 
            // buyOrderId
            // 
            this.buyOrderId.AllowDBNull = false;
            this.buyOrderId.ColumnName = "OrderID";
            // 
            // dcBuySymbol
            // 
            this.dcBuySymbol.ColumnName = "Symbol";
            // 
            // dcBuyClientID
            // 
            this.dcBuyClientID.Caption = "ClientID";
            this.dcBuyClientID.ColumnName = "ClientID";
            // 
            // dtSellOrders
            // 
            this.dtSellOrders.Columns.AddRange(new System.Data.DataColumn[] {
            this.sellPrice,
            this.sellSize,
            this.sellCellStyle,
            this.sellOrderId,
            this.dcSellSymbol,
            this.dcSellClientID});
            this.dtSellOrders.TableName = "ALLSellOrders";
            // 
            // sellPrice
            // 
            this.sellPrice.ColumnName = "Price";
            this.sellPrice.DataType = typeof(double);
            // 
            // sellSize
            // 
            this.sellSize.ColumnName = "Size";
            this.sellSize.DataType = typeof(int);
            // 
            // sellCellStyle
            // 
            this.sellCellStyle.ColumnName = "CellStyle";
            this.sellCellStyle.DataType = typeof(int);
            // 
            // sellOrderId
            // 
            this.sellOrderId.ColumnName = "OrderId";
            // 
            // dcSellSymbol
            // 
            this.dcSellSymbol.ColumnName = "Symbol";
            // 
            // dcSellClientID
            // 
            this.dcSellClientID.Caption = "ClientID";
            this.dcSellClientID.ColumnName = "ClientID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buy Orders";
            // 
            // cbTickers
            // 
            this.cbTickers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTickers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTickers.FormattingEnabled = true;
            this.cbTickers.Location = new System.Drawing.Point(37, 37);
            this.cbTickers.Name = "cbTickers";
            this.cbTickers.Size = new System.Drawing.Size(121, 33);
            this.cbTickers.TabIndex = 6;
            this.cbTickers.SelectedIndexChanged += new System.EventHandler(this.cbTickers_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "Sell Orders";
            // 
            // dgAsks
            // 
            this.dgAsks.AllowUserToAddRows = false;
            this.dgAsks.AllowUserToDeleteRows = false;
            this.dgAsks.AllowUserToResizeColumns = false;
            this.dgAsks.AllowUserToResizeRows = false;
            this.dgAsks.AutoGenerateColumns = false;
            this.dgAsks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgAsks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgAsks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAsks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgAsks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAsks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column1});
            this.dgAsks.DataMember = "ALLSellOrders";
            this.dgAsks.DataSource = this.dsOrders;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = null;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAsks.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgAsks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgAsks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgAsks.EnableHeadersVisualStyles = false;
            this.dgAsks.Location = new System.Drawing.Point(0, 78);
            this.dgAsks.MultiSelect = false;
            this.dgAsks.Name = "dgAsks";
            this.dgAsks.ReadOnly = true;
            this.dgAsks.RowHeadersVisible = false;
            this.dgAsks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgAsks.RowTemplate.ReadOnly = true;
            this.dgAsks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAsks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgAsks.Size = new System.Drawing.Size(498, 295);
            this.dgAsks.TabIndex = 3;
            this.dgAsks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBids_CellFormatting);
            // 
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "Sell Price";
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "Sell Price";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sellPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(605, 15);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(394, 115);
            this.txtConsole.TabIndex = 11;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(17, 37);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(14, 13);
            this.rb1.TabIndex = 12;
            this.rb1.TabStop = true;
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(164, 37);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(100, 17);
            this.rb2.TabIndex = 13;
            this.rb2.Text = "Show All Orders";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // txtConnections
            // 
            this.txtConnections.BackColor = System.Drawing.SystemColors.Control;
            this.txtConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnections.ForeColor = System.Drawing.Color.Red;
            this.txtConnections.Location = new System.Drawing.Point(152, 9);
            this.txtConnections.Name = "txtConnections";
            this.txtConnections.Size = new System.Drawing.Size(48, 31);
            this.txtConnections.TabIndex = 15;
            this.txtConnections.Text = "0";
            this.txtConnections.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblConnections
            // 
            this.lblConnections.AutoSize = true;
            this.lblConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnections.Location = new System.Drawing.Point(3, 14);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(150, 20);
            this.lblConnections.TabIndex = 16;
            this.lblConnections.Text = "# of Connections:";
            // 
            // lblClient1
            // 
            this.lblClient1.AutoSize = true;
            this.lblClient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(85)))), ((int)(((byte)(201)))));
            this.lblClient1.Location = new System.Drawing.Point(206, 16);
            this.lblClient1.Name = "lblClient1";
            this.lblClient1.Size = new System.Drawing.Size(93, 24);
            this.lblClient1.TabIndex = 17;
            this.lblClient1.Text = "CLIENT1";
            this.lblClient1.Visible = false;
            // 
            // lblClient2
            // 
            this.lblClient2.AutoSize = true;
            this.lblClient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(85)))), ((int)(((byte)(201)))));
            this.lblClient2.Location = new System.Drawing.Point(305, 16);
            this.lblClient2.Name = "lblClient2";
            this.lblClient2.Size = new System.Drawing.Size(93, 24);
            this.lblClient2.TabIndex = 18;
            this.lblClient2.Text = "CLIENT2";
            this.lblClient2.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 130);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgBids);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgAsks);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 375);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(552, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Log:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblConnections);
            this.panel1.Controls.Add(this.lblClient1);
            this.panel1.Controls.Add(this.txtConnections);
            this.panel1.Controls.Add(this.lblClient2);
            this.panel1.Location = new System.Drawing.Point(1, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 48);
            this.panel1.TabIndex = 22;
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.Width = 85;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn1.HeaderText = "Price";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Size";
            this.dataGridViewTextBoxColumn2.HeaderText = "Size";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CellStyle";
            this.dataGridViewTextBoxColumn3.HeaderText = "CellStyle";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "ClientID";
            this.ClientID.HeaderText = "ClientID";
            this.ClientID.Name = "ClientID";
            this.ClientID.ReadOnly = true;
            this.ClientID.Width = 175;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Symbol";
            this.dataGridViewTextBoxColumn5.HeaderText = "Symbol";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 85;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn6.HeaderText = "Price";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Size";
            this.dataGridViewTextBoxColumn7.HeaderText = "Size";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CellStyle";
            this.dataGridViewTextBoxColumn8.HeaderText = "CellStyle";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "OrderId";
            this.dataGridViewTextBoxColumn9.HeaderText = "OrderId";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ClientID";
            this.Column1.HeaderText = "ClientID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 175;
            // 
            // MatchingEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1001, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.cbTickers);
            this.Controls.Add(this.lblOrderBook);
            this.Controls.Add(this.btnStopServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MatchingEngine";
            this.Text = "MatchingEngine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgBids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBuyOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSellOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAsks)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Label lblOrderBook;
        private System.Windows.Forms.DataGridView dgBids;
        private System.Data.DataSet dsOrders;
        private System.Data.DataTable dtBuyOrders;
        private System.Data.DataColumn buyPrice;
        private System.Data.DataColumn buySize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTickers;
        private System.Data.DataColumn buyCellStyle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgAsks;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
        private System.Data.DataColumn buyOrderId;
        private System.Data.DataTable dtSellOrders;
        private System.Data.DataColumn sellPrice;
        private System.Data.DataColumn sellSize;
        private System.Data.DataColumn sellCellStyle;
        private System.Data.DataColumn sellOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellStyleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellStyleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Data.DataColumn dcBuySymbol;
        private System.Data.DataColumn dcSellSymbol;
        private System.Windows.Forms.TextBox txtConnections;
        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.Label lblClient1;
        private System.Windows.Forms.Label lblClient2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Data.DataColumn dcBuyClientID;
        private System.Data.DataColumn dcSellClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

