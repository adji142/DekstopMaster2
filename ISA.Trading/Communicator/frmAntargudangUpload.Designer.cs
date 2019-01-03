namespace ISA.Trading.Communicator
{
    partial class frmAntargudangUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntargudangUpload));
            this.lookupGudang = new ISA.Trading.Controls.LookupGudang();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DetailprogressBar = new System.Windows.Forms.ProgressBar();
            this.HeaderprogressBar = new System.Windows.Forms.ProgressBar();
            this.dataGridHeader = new System.Windows.Forms.DataGridView();
            this.dataGridDetail = new System.Windows.Forms.DataGridView();
            this.txtGudangAsal = new ISA.Controls.LookupGudang();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.cmdUpload = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookupGudang
            // 
            this.lookupGudang.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang.GudangID = "";
            this.lookupGudang.InitPerusahaan = null;
            this.lookupGudang.KodeCabang = null;
            this.lookupGudang.Location = new System.Drawing.Point(120, 152);
            this.lookupGudang.NamaGudang = "";
            this.lookupGudang.Name = "lookupGudang";
            this.lookupGudang.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang.TabIndex = 3;
            this.lookupGudang.Leave += new System.EventHandler(this.lookupGudang_Leave);
            this.lookupGudang.SelectData += new System.EventHandler(this.lookupGudang_SelectData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Dari Gudang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ke Gudang";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(313, 61);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.DetailprogressBar, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.HeaderprogressBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridHeader, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDetail, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 231);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 332);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hkrmagud";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Dkrmagud";
            // 
            // DetailprogressBar
            // 
            this.DetailprogressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailprogressBar.Location = new System.Drawing.Point(3, 311);
            this.DetailprogressBar.Name = "DetailprogressBar";
            this.DetailprogressBar.Size = new System.Drawing.Size(897, 18);
            this.DetailprogressBar.TabIndex = 4;
            // 
            // HeaderprogressBar
            // 
            this.HeaderprogressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderprogressBar.Location = new System.Drawing.Point(3, 145);
            this.HeaderprogressBar.Name = "HeaderprogressBar";
            this.HeaderprogressBar.Size = new System.Drawing.Size(897, 14);
            this.HeaderprogressBar.TabIndex = 5;
            // 
            // dataGridHeader
            // 
            this.dataGridHeader.AllowUserToAddRows = false;
            this.dataGridHeader.AllowUserToDeleteRows = false;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHeader.Location = new System.Drawing.Point(3, 23);
            this.dataGridHeader.Name = "dataGridHeader";
            this.dataGridHeader.ReadOnly = true;
            this.dataGridHeader.Size = new System.Drawing.Size(897, 116);
            this.dataGridHeader.TabIndex = 6;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.AllowUserToAddRows = false;
            this.dataGridDetail.AllowUserToDeleteRows = false;
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDetail.Location = new System.Drawing.Point(3, 189);
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.ReadOnly = true;
            this.dataGridDetail.Size = new System.Drawing.Size(897, 116);
            this.dataGridDetail.TabIndex = 7;
            // 
            // txtGudangAsal
            // 
            this.txtGudangAsal.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtGudangAsal.GudangID = "";
            this.txtGudangAsal.InitPerusahaan = null;
            this.txtGudangAsal.KodeCabang = null;
            this.txtGudangAsal.Location = new System.Drawing.Point(120, 96);
            this.txtGudangAsal.NamaGudang = "";
            this.txtGudangAsal.Name = "txtGudangAsal";
            this.txtGudangAsal.Size = new System.Drawing.Size(276, 54);
            this.txtGudangAsal.TabIndex = 2;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmdUpload);
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 569);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(922, 60);
            this.pnlButton.TabIndex = 50;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(667, 10);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 0;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(813, 10);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(123, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2013, 12, 12, 0, 0, 0, 0);
            // 
            // frmAntargudangUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(922, 629);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.txtGudangAsal);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupGudang);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAntargudangUpload";
            this.Text = "AntarGudang Upload";
            this.Title = "AntarGudang Upload";
            this.Load += new System.EventHandler(this.frmAntargudangUpload_Load);
            this.Controls.SetChildIndex(this.lookupGudang, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.txtGudangAsal, 0);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.LookupGudang lookupGudang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar DetailprogressBar;
        private System.Windows.Forms.ProgressBar HeaderprogressBar;
        private System.Windows.Forms.DataGridView dataGridHeader;
        private System.Windows.Forms.DataGridView dataGridDetail;
        private ISA.Controls.LookupGudang txtGudangAsal;
        private System.Windows.Forms.Panel pnlButton;
        private ISA.Trading.Controls.CommandButton cmdUpload;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
