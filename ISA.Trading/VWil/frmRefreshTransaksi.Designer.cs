namespace ISA.Trading.VWil
{
    partial class frmRefreshTransaksi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefreshTransaksi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblKeterangan = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTglTransaksi = new ISA.Trading.Controls.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdRefresh = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblKeterangan);
            this.groupBox1.Location = new System.Drawing.Point(31, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblKeterangan
            // 
            this.lblKeterangan.AutoSize = true;
            this.lblKeterangan.Location = new System.Drawing.Point(8, 22);
            this.lblKeterangan.Name = "lblKeterangan";
            this.lblKeterangan.Size = new System.Drawing.Size(49, 14);
            this.lblKeterangan.TabIndex = 0;
            this.lblKeterangan.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTglTransaksi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(31, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 56);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // txtTglTransaksi
            // 
            this.txtTglTransaksi.DateValue = null;
            this.txtTglTransaksi.Location = new System.Drawing.Point(293, 14);
            this.txtTglTransaksi.MaxLength = 10;
            this.txtTglTransaksi.Name = "txtTglTransaksi";
            this.txtTglTransaksi.Size = new System.Drawing.Size(81, 20);
            this.txtTglTransaksi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanggal transaksi";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefresh.Location = new System.Drawing.Point(437, 285);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(117, 43);
            this.cmdRefresh.TabIndex = 0;
            this.cmdRefresh.Text = "SAVE";
            this.cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(580, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRefreshTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdRefresh);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRefreshTransaksi";
            this.Text = "Refresh Transaksi";
            this.Title = "Refresh Transaksi";
            this.Load += new System.EventHandler(this.frmRefreshTransaksi_Load);
            this.Controls.SetChildIndex(this.cmdRefresh, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblKeterangan;
        private System.Windows.Forms.GroupBox groupBox2;
        private ISA.Trading.Controls.DateTextBox txtTglTransaksi;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommandButton cmdRefresh;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
