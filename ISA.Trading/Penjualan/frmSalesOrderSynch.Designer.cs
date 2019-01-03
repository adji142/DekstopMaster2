namespace ISA.Trading.Penjualan
{
    partial class frmSalesOrderSynch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrderSynch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.progbProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.btnClose = new ISA.Controls.CommandButton();
            this.btnDownload = new ISA.Controls.CommandButton();
            this.GV01 = new ISA.Controls.CustomGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglPIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoPIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglAccPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoAccPiutang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GV02 = new ISA.Controls.CustomGridView();
            this.col2Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col2id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2TglPil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2NoPil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2TglOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2NoOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Toko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV01)).BeginInit();
            this.mainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV02)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tgl.Order";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(325, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Controls.Add(this.progbProgress);
            this.pnlProgress.Controls.Add(this.label2);
            this.pnlProgress.Location = new System.Drawing.Point(9, 10);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(301, 88);
            this.pnlProgress.TabIndex = 12;
            this.pnlProgress.Visible = false;
            // 
            // progbProgress
            // 
            this.progbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progbProgress.Location = new System.Drawing.Point(22, 38);
            this.progbProgress.Name = "progbProgress";
            this.progbProgress.Size = new System.Drawing.Size(256, 23);
            this.progbProgress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Progress";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(80, 60);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(239, 23);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(9, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.ReportName2 = "";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(651, 362);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ReportName2 = "";
            this.btnDownload.Size = new System.Drawing.Size(128, 40);
            this.btnDownload.TabIndex = 10;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btn_Clicked);
            // 
            // GV01
            // 
            this.GV01.AllowUserToAddRows = false;
            this.GV01.AllowUserToDeleteRows = false;
            this.GV01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GV01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV01.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colid,
            this.colTglPIL,
            this.colNoPIL,
            this.colTglSO,
            this.colNoSO,
            this.colTglAccPiutang,
            this.colNoAccPiutang,
            this.colToko,
            this.colSalesman,
            this.colTotal});
            this.GV01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV01.Location = new System.Drawing.Point(3, 3);
            this.GV01.MultiSelect = false;
            this.GV01.Name = "GV01";
            this.GV01.ReadOnly = true;
            this.GV01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GV01.Size = new System.Drawing.Size(756, 234);
            this.GV01.StandardTab = true;
            this.GV01.TabIndex = 8;
            this.GV01.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_CellContentClick);
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.Frozen = true;
            this.colCheck.HeaderText = "#";
            this.colCheck.Name = "colCheck";
            this.colCheck.ReadOnly = true;
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.Width = 30;
            // 
            // colid
            // 
            this.colid.DataPropertyName = "id";
            this.colid.HeaderText = "ID";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Visible = false;
            // 
            // colTglPIL
            // 
            this.colTglPIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTglPIL.DataPropertyName = "tglpickinglist";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.colTglPIL.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTglPIL.HeaderText = "Tgl.PiL";
            this.colTglPIL.Name = "colTglPIL";
            this.colTglPIL.ReadOnly = true;
            this.colTglPIL.Width = 69;
            // 
            // colNoPIL
            // 
            this.colNoPIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNoPIL.DataPropertyName = "nopickinglist";
            this.colNoPIL.HeaderText = "No.PiL";
            this.colNoPIL.Name = "colNoPIL";
            this.colNoPIL.ReadOnly = true;
            this.colNoPIL.Width = 66;
            // 
            // colTglSO
            // 
            this.colTglSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTglSO.DataPropertyName = "tglso";
            dataGridViewCellStyle2.Format = "dd-MM-yyyy";
            this.colTglSO.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTglSO.HeaderText = "Tgl.SO";
            this.colTglSO.Name = "colTglSO";
            this.colTglSO.ReadOnly = true;
            this.colTglSO.Width = 67;
            // 
            // colNoSO
            // 
            this.colNoSO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNoSO.DataPropertyName = "noso";
            this.colNoSO.HeaderText = "No.SO";
            this.colNoSO.Name = "colNoSO";
            this.colNoSO.ReadOnly = true;
            this.colNoSO.Width = 64;
            // 
            // colTglAccPiutang
            // 
            this.colTglAccPiutang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTglAccPiutang.DataPropertyName = "tglaccpiutang";
            dataGridViewCellStyle3.Format = "dd-MM-yyyy";
            this.colTglAccPiutang.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTglAccPiutang.HeaderText = "Tgl.Acc Piutang";
            this.colTglAccPiutang.Name = "colTglAccPiutang";
            this.colTglAccPiutang.ReadOnly = true;
            this.colTglAccPiutang.Width = 106;
            // 
            // colNoAccPiutang
            // 
            this.colNoAccPiutang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNoAccPiutang.DataPropertyName = "noaccpiutang";
            this.colNoAccPiutang.HeaderText = "No.Acc Piutang";
            this.colNoAccPiutang.Name = "colNoAccPiutang";
            this.colNoAccPiutang.ReadOnly = true;
            this.colNoAccPiutang.Width = 104;
            // 
            // colToko
            // 
            this.colToko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colToko.DataPropertyName = "namatoko";
            this.colToko.HeaderText = "Toko";
            this.colToko.Name = "colToko";
            this.colToko.ReadOnly = true;
            // 
            // colSalesman
            // 
            this.colSalesman.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSalesman.DataPropertyName = "namasales";
            this.colSalesman.HeaderText = "Salesman";
            this.colSalesman.Name = "colSalesman";
            this.colSalesman.ReadOnly = true;
            this.colSalesman.Width = 86;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTotal.DataPropertyName = "total";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 58;
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.tabPage1);
            this.mainTab.Controls.Add(this.tabPage2);
            this.mainTab.Location = new System.Drawing.Point(9, 89);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(770, 267);
            this.mainTab.TabIndex = 13;
            this.mainTab.SelectedIndexChanged += new System.EventHandler(this.Tab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GV01);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(762, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sales Order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GV02);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(762, 240);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ASET Order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GV02
            // 
            this.GV02.AllowUserToAddRows = false;
            this.GV02.AllowUserToDeleteRows = false;
            this.GV02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GV02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV02.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col2Check,
            this.col2id,
            this.col2TglPil,
            this.col2NoPil,
            this.col2TglOrder,
            this.col2NoOrder,
            this.col2Toko,
            this.col2Total});
            this.GV02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GV02.Location = new System.Drawing.Point(3, 3);
            this.GV02.MultiSelect = false;
            this.GV02.Name = "GV02";
            this.GV02.ReadOnly = true;
            this.GV02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GV02.Size = new System.Drawing.Size(756, 234);
            this.GV02.StandardTab = true;
            this.GV02.TabIndex = 9;
            this.GV02.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_CellContentClick);
            // 
            // col2Check
            // 
            this.col2Check.DataPropertyName = "check";
            this.col2Check.Frozen = true;
            this.col2Check.HeaderText = "#";
            this.col2Check.Name = "col2Check";
            this.col2Check.ReadOnly = true;
            this.col2Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col2Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col2Check.Width = 30;
            // 
            // col2id
            // 
            this.col2id.DataPropertyName = "id";
            this.col2id.HeaderText = "ID";
            this.col2id.Name = "col2id";
            this.col2id.ReadOnly = true;
            this.col2id.Visible = false;
            // 
            // col2TglPil
            // 
            this.col2TglPil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col2TglPil.DataPropertyName = "tglpickinglist";
            dataGridViewCellStyle5.Format = "dd-MM-yyyy";
            this.col2TglPil.DefaultCellStyle = dataGridViewCellStyle5;
            this.col2TglPil.HeaderText = "Tgl.PiL";
            this.col2TglPil.Name = "col2TglPil";
            this.col2TglPil.ReadOnly = true;
            this.col2TglPil.Width = 69;
            // 
            // col2NoPil
            // 
            this.col2NoPil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col2NoPil.DataPropertyName = "nopickinglist";
            this.col2NoPil.HeaderText = "No.PiL";
            this.col2NoPil.Name = "col2NoPil";
            this.col2NoPil.ReadOnly = true;
            this.col2NoPil.Width = 66;
            // 
            // col2TglOrder
            // 
            this.col2TglOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col2TglOrder.DataPropertyName = "docdate";
            dataGridViewCellStyle6.Format = "dd-MM-yyyy";
            this.col2TglOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.col2TglOrder.HeaderText = "Tgl.Order";
            this.col2TglOrder.Name = "col2TglOrder";
            this.col2TglOrder.ReadOnly = true;
            this.col2TglOrder.Width = 84;
            // 
            // col2NoOrder
            // 
            this.col2NoOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col2NoOrder.DataPropertyName = "docno";
            this.col2NoOrder.HeaderText = "No.Order";
            this.col2NoOrder.Name = "col2NoOrder";
            this.col2NoOrder.ReadOnly = true;
            this.col2NoOrder.Width = 81;
            // 
            // col2Toko
            // 
            this.col2Toko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col2Toko.DataPropertyName = "namatoko";
            this.col2Toko.HeaderText = "Toko";
            this.col2Toko.Name = "col2Toko";
            this.col2Toko.ReadOnly = true;
            // 
            // col2Total
            // 
            this.col2Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col2Total.DataPropertyName = "total";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.col2Total.DefaultCellStyle = dataGridViewCellStyle7;
            this.col2Total.HeaderText = "Total";
            this.col2Total.Name = "col2Total";
            this.col2Total.ReadOnly = true;
            this.col2Total.Width = 58;
            // 
            // frmSalesOrderSynch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(792, 414);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDownload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSalesOrderSynch";
            this.Text = "Order Wiser Synch";
            this.Title = "Order Wiser Synch";
            this.Load += new System.EventHandler(this.frmSalesOrderSynch_Load);
            this.Controls.SetChildIndex(this.btnDownload, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.mainTab, 0);
            this.Controls.SetChildIndex(this.pnlProgress, 0);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV01)).EndInit();
            this.mainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GV02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private ISA.Controls.CommandButton btnDownload;
        private ISA.Controls.CommandButton btnClose;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar progbProgress;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CustomGridView GV01;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ISA.Controls.CustomGridView GV02;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglPIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoPIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglAccPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoAccPiutang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col2Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2TglPil;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2NoPil;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2TglOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2NoOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Toko;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Total;
    }
}
