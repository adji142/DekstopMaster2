namespace ISA.Toko.Communicator
{
    partial class frmBonusPengajuanKe11Upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBonusPengajuanKe11Upload));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdUpload = new ISA.Toko.Controls.CommandButton();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeSales,
            this.Periode,
            this.Tanggal,
            this.NoACC,
            this.TglACC,
            this.RpBonus,
            this.RpACC});
            this.dataGridView1.Location = new System.Drawing.Point(9, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(689, 182);
            this.dataGridView1.TabIndex = 5;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "kd. Sales";
            this.KodeSales.Name = "KodeSales";
            // 
            // Periode
            // 
            this.Periode.DataPropertyName = "Periode";
            this.Periode.HeaderText = "Periode";
            this.Periode.Name = "Periode";
            // 
            // Tanggal
            // 
            this.Tanggal.DataPropertyName = "Tanggal";
            this.Tanggal.HeaderText = "Tanggal";
            this.Tanggal.Name = "Tanggal";
            // 
            // NoACC
            // 
            this.NoACC.DataPropertyName = "NoACC";
            this.NoACC.HeaderText = "No.ACC";
            this.NoACC.Name = "NoACC";
            // 
            // TglACC
            // 
            this.TglACC.DataPropertyName = "TglACC";
            this.TglACC.HeaderText = "Tgl.ACC";
            this.TglACC.Name = "TglACC";
            // 
            // RpBonus
            // 
            this.RpBonus.DataPropertyName = "RpBonus";
            this.RpBonus.HeaderText = "Rp.Bonus";
            this.RpBonus.Name = "RpBonus";
            // 
            // RpACC
            // 
            this.RpACC.DataPropertyName = "RpACC";
            this.RpACC.HeaderText = "Rp.ACC";
            this.RpACC.Name = "RpACC";
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(9, 314);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 6;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(598, 314);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 274);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(689, 16);
            this.progressBar1.TabIndex = 8;
            // 
            // frmBonusPengajuanKe11Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 366);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBonusPengajuanKe11Upload";
            this.Text = "ACC Bonus Upload";
            this.Title = "ACC Bonus Upload";
            this.Load += new System.EventHandler(this.frmBonusPengajuanKe11Upload_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ISA.Toko.Controls.CommandButton cmdUpload;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpACC;
    }
}
