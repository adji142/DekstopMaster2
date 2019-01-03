namespace ISA.Trading.Master
{
    partial class frmTokoJW
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTokoJW));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GVHeader = new ISA.Controls.CustomGridView();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WilID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVDetail = new ISA.Controls.CustomGridView();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.panelPrint = new System.Windows.Forms.Panel();
            this.cmdCancelLap = new ISA.Controls.CommandButton();
            this.cmdPrintLap = new ISA.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TglAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OmsetMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JWBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JXBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JSBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JWFX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JXFX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JSFX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JWFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JXFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JSFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglExpired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).BeginInit();
            this.panelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(31, 51);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GVHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GVDetail);
            this.splitContainer1.Size = new System.Drawing.Size(641, 244);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 5;
            // 
            // GVHeader
            // 
            this.GVHeader.AllowUserToAddRows = false;
            this.GVHeader.AllowUserToDeleteRows = false;
            this.GVHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeToko,
            this.TokoID,
            this.NamaToko,
            this.WilID,
            this.Kota,
            this.Alamat});
            this.GVHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHeader.Location = new System.Drawing.Point(0, 0);
            this.GVHeader.MultiSelect = false;
            this.GVHeader.Name = "GVHeader";
            this.GVHeader.ReadOnly = true;
            this.GVHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVHeader.Size = new System.Drawing.Size(641, 122);
            this.GVHeader.StandardTab = true;
            this.GVHeader.TabIndex = 1;
            this.GVHeader.SelectionRowChanged += new System.EventHandler(this.GVHeader_SelectionRowChanged);
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.KodeToko.DefaultCellStyle = dataGridViewCellStyle1;
            this.KodeToko.HeaderText = "KodeToko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            this.KodeToko.Width = 150;
            // 
            // TokoID
            // 
            this.TokoID.DataPropertyName = "TokoID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TokoID.DefaultCellStyle = dataGridViewCellStyle2;
            this.TokoID.HeaderText = "TokoID";
            this.TokoID.Name = "TokoID";
            this.TokoID.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "NamaToko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 250;
            // 
            // WilID
            // 
            this.WilID.DataPropertyName = "WilID";
            this.WilID.HeaderText = "IDWIL";
            this.WilID.Name = "WilID";
            this.WilID.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // GVDetail
            // 
            this.GVDetail.AllowUserToAddRows = false;
            this.GVDetail.AllowUserToDeleteRows = false;
            this.GVDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglAktif,
            this.OmsetMax,
            this.JWBE,
            this.JXBE,
            this.JSBE,
            this.JWFX,
            this.JXFX,
            this.JSFX,
            this.JWFA,
            this.JXFA,
            this.JSFA,
            this.TglExpired,
            this.Keterangan,
            this.TglUpdate});
            this.GVDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVDetail.Location = new System.Drawing.Point(0, 0);
            this.GVDetail.MultiSelect = false;
            this.GVDetail.Name = "GVDetail";
            this.GVDetail.ReadOnly = true;
            this.GVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GVDetail.Size = new System.Drawing.Size(641, 118);
            this.GVDetail.StandardTab = true;
            this.GVDetail.TabIndex = 1;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(31, 309);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.ReportName2 = "";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 7;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(572, 309);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.ReportName2 = "";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // panelPrint
            // 
            this.panelPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPrint.Controls.Add(this.cmdCancelLap);
            this.panelPrint.Controls.Add(this.cmdPrintLap);
            this.panelPrint.Controls.Add(this.rangeDateBox1);
            this.panelPrint.Controls.Add(this.label2);
            this.panelPrint.Controls.Add(this.label1);
            this.panelPrint.Location = new System.Drawing.Point(153, 86);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(404, 189);
            this.panelPrint.TabIndex = 9;
            // 
            // cmdCancelLap
            // 
            this.cmdCancelLap.CommandType = ISA.Controls.CommandButton.enCommandType.No;
            this.cmdCancelLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancelLap.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelLap.Image")));
            this.cmdCancelLap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelLap.Location = new System.Drawing.Point(276, 132);
            this.cmdCancelLap.Name = "cmdCancelLap";
            this.cmdCancelLap.ReportName2 = "";
            this.cmdCancelLap.Size = new System.Drawing.Size(100, 40);
            this.cmdCancelLap.TabIndex = 4;
            this.cmdCancelLap.Text = "CANCEL";
            this.cmdCancelLap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancelLap.UseVisualStyleBackColor = true;
            this.cmdCancelLap.Click += new System.EventHandler(this.cmdCancelLap_Click);
            // 
            // cmdPrintLap
            // 
            this.cmdPrintLap.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrintLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrintLap.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintLap.Image")));
            this.cmdPrintLap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrintLap.Location = new System.Drawing.Point(21, 132);
            this.cmdPrintLap.Name = "cmdPrintLap";
            this.cmdPrintLap.ReportName2 = "";
            this.cmdPrintLap.Size = new System.Drawing.Size(100, 40);
            this.cmdPrintLap.TabIndex = 3;
            this.cmdPrintLap.Text = "PRINT";
            this.cmdPrintLap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrintLap.UseVisualStyleBackColor = true;
            this.cmdPrintLap.Click += new System.EventHandler(this.cmdPrintLap_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(90, 64);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 2;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tgl Aktif";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(141, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Print Toko JW";
            // 
            // TglAktif
            // 
            this.TglAktif.DataPropertyName = "TglAktif";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglAktif.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglAktif.HeaderText = "Tgl Aktif";
            this.TglAktif.Name = "TglAktif";
            this.TglAktif.ReadOnly = true;
            // 
            // OmsetMax
            // 
            this.OmsetMax.DataPropertyName = "OmsetMax";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.OmsetMax.DefaultCellStyle = dataGridViewCellStyle4;
            this.OmsetMax.HeaderText = "Omset Max";
            this.OmsetMax.Name = "OmsetMax";
            this.OmsetMax.ReadOnly = true;
            // 
            // JWBE
            // 
            this.JWBE.DataPropertyName = "JWBE";
            this.JWBE.HeaderText = "JW BE";
            this.JWBE.Name = "JWBE";
            this.JWBE.ReadOnly = true;
            this.JWBE.Width = 70;
            // 
            // JXBE
            // 
            this.JXBE.DataPropertyName = "JXBE";
            this.JXBE.HeaderText = "JX BE";
            this.JXBE.Name = "JXBE";
            this.JXBE.ReadOnly = true;
            this.JXBE.Width = 70;
            // 
            // JSBE
            // 
            this.JSBE.DataPropertyName = "JSBE";
            this.JSBE.HeaderText = "JS BE";
            this.JSBE.Name = "JSBE";
            this.JSBE.ReadOnly = true;
            this.JSBE.Width = 70;
            // 
            // JWFX
            // 
            this.JWFX.DataPropertyName = "JWFX";
            this.JWFX.HeaderText = "JW FX";
            this.JWFX.Name = "JWFX";
            this.JWFX.ReadOnly = true;
            this.JWFX.Width = 70;
            // 
            // JXFX
            // 
            this.JXFX.DataPropertyName = "JXFX";
            this.JXFX.HeaderText = "JX FX";
            this.JXFX.Name = "JXFX";
            this.JXFX.ReadOnly = true;
            this.JXFX.Width = 70;
            // 
            // JSFX
            // 
            this.JSFX.DataPropertyName = "JSFX";
            this.JSFX.HeaderText = "JS FX";
            this.JSFX.Name = "JSFX";
            this.JSFX.ReadOnly = true;
            this.JSFX.Width = 70;
            // 
            // JWFA
            // 
            this.JWFA.DataPropertyName = "JWFA";
            this.JWFA.HeaderText = "JW FA";
            this.JWFA.Name = "JWFA";
            this.JWFA.ReadOnly = true;
            this.JWFA.Width = 70;
            // 
            // JXFA
            // 
            this.JXFA.DataPropertyName = "JXFA";
            this.JXFA.HeaderText = "JX FA";
            this.JXFA.Name = "JXFA";
            this.JXFA.ReadOnly = true;
            this.JXFA.Width = 70;
            // 
            // JSFA
            // 
            this.JSFA.DataPropertyName = "JSFA";
            this.JSFA.HeaderText = "JS FA";
            this.JSFA.Name = "JSFA";
            this.JSFA.ReadOnly = true;
            this.JSFA.Width = 70;
            // 
            // TglExpired
            // 
            this.TglExpired.DataPropertyName = "TglExpired";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            this.TglExpired.DefaultCellStyle = dataGridViewCellStyle5;
            this.TglExpired.HeaderText = "Tgl Expired";
            this.TglExpired.Name = "TglExpired";
            this.TglExpired.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Width = 200;
            // 
            // TglUpdate
            // 
            this.TglUpdate.DataPropertyName = "TglUpdate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "dd-MMM-yyyy";
            this.TglUpdate.DefaultCellStyle = dataGridViewCellStyle6;
            this.TglUpdate.HeaderText = "Tgl Update";
            this.TglUpdate.Name = "TglUpdate";
            this.TglUpdate.ReadOnly = true;
            // 
            // frmTokoJW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 361);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelPrint);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTokoJW";
            this.Text = "Toko JW";
            this.Title = "Toko JW";
            this.Load += new System.EventHandler(this.frmTokoJW_Load);
            this.Controls.SetChildIndex(this.panelPrint, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVDetail)).EndInit();
            this.panelPrint.ResumeLayout(false);
            this.panelPrint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ISA.Controls.CustomGridView GVHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn WilID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private ISA.Controls.CustomGridView GVDetail;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Panel panelPrint;
        private ISA.Controls.CommandButton cmdCancelLap;
        private ISA.Controls.CommandButton cmdPrintLap;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn OmsetMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn JWBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JXBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JSBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JWFX;
        private System.Windows.Forms.DataGridViewTextBoxColumn JXFX;
        private System.Windows.Forms.DataGridViewTextBoxColumn JSFX;
        private System.Windows.Forms.DataGridViewTextBoxColumn JWFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn JXFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn JSFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglExpired;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglUpdate;

    }
}
