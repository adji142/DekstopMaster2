namespace ISA.Trading.Communicator
{
    partial class frmOrderSheetDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderSheetDownload));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.pnlProgBar = new System.Windows.Forms.Panel();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvHeader = new ISA.Controls.CustomGridView();
            this.dgvDetail = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDownload = new ISA.Trading.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlProgBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHeader, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.19973F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.80027F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 373);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cmdClose);
            this.pnlButton.Controls.Add(this.cmdDownload);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 507);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(784, 55);
            this.pnlButton.TabIndex = 21;
            // 
            // pnlProgBar
            // 
            this.pnlProgBar.Controls.Add(this.progressBar2);
            this.pnlProgBar.Controls.Add(this.progressBar1);
            this.pnlProgBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgBar.Location = new System.Drawing.Point(0, 429);
            this.pnlProgBar.Name = "pnlProgBar";
            this.pnlProgBar.Size = new System.Drawing.Size(784, 78);
            this.pnlProgBar.TabIndex = 22;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(12, 42);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(758, 23);
            this.progressBar2.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(758, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // dgvHeader
            // 
            this.dgvHeader.AllowUserToAddRows = false;
            this.dgvHeader.AllowUserToDeleteRows = false;
            this.dgvHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHeader.Location = new System.Drawing.Point(3, 3);
            this.dgvHeader.MultiSelect = false;
            this.dgvHeader.Name = "dgvHeader";
            this.dgvHeader.ReadOnly = true;
            this.dgvHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHeader.Size = new System.Drawing.Size(752, 117);
            this.dgvHeader.StandardTab = true;
            this.dgvHeader.TabIndex = 0;
            this.dgvHeader.SelectionRowChanged += new System.EventHandler(this.dgvHeader_SelectionRowChanged);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 126);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetail.Size = new System.Drawing.Size(752, 244);
            this.dgvDetail.StandardTab = true;
            this.dgvDetail.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(670, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDownload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDownload.Image = ((System.Drawing.Image)(resources.GetObject("cmdDownload.Image")));
            this.cmdDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDownload.Location = new System.Drawing.Point(522, 3);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(128, 40);
            this.cmdDownload.TabIndex = 7;
            this.cmdDownload.Text = "DOWNLOAD";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // frmOrderSheetDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pnlProgBar);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOrderSheetDownload";
            this.Text = "Download Order Sheet";
            this.Title = "Download Order Sheet";
            this.Load += new System.EventHandler(this.frmOrderSheetDownload_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.pnlButton, 0);
            this.Controls.SetChildIndex(this.pnlProgBar, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlProgBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlButton;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdDownload;
        private System.Windows.Forms.Panel pnlProgBar;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Controls.CustomGridView dgvDetail;
        private ISA.Controls.CustomGridView dgvHeader;
    }
}
