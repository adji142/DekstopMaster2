namespace ISA.Trading.Persediaan
{
    partial class frmRecalculateStokGudang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecalculateStokGudang));
            this.lblCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.colBarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(28, 304);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(39, 14);
            this.lblCount.TabIndex = 18;
            this.lblCount.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(27, 278);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(760, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarangID,
            this.colNamaBarang});
            this.customGridView1.Location = new System.Drawing.Point(27, 76);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(760, 196);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 16;
            this.customGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentClick);
            // 
            // colBarangID
            // 
            this.colBarangID.DataPropertyName = "BarangID";
            this.colBarangID.HeaderText = "Barang ID";
            this.colBarangID.Name = "colBarangID";
            this.colBarangID.ReadOnly = true;
            // 
            // colNamaBarang
            // 
            this.colNamaBarang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNamaBarang.DataPropertyName = "NamaStok";
            this.colNamaBarang.HeaderText = "Nama Barang";
            this.colNamaBarang.Name = "colNamaBarang";
            this.colNamaBarang.ReadOnly = true;
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(539, 336);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 0;
            this.commandButton2.Text = "YES";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(691, 336);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 1;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmRecalculateStokGudang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(803, 388);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRecalculateStokGudang";
            this.Text = "Calculate";
            this.Title = "Calculate";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRecalculateStokGudang_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRecalculateStokGudang_FormClosed);
            this.Resize += new System.EventHandler(this.frmRecalculateStokGudang_Resize);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label lblCount;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaBarang;

    }
}
