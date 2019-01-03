namespace ISA.Trading.Controls
{
    partial class frmLookupSpm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookupSpm));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.no_pol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_cust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jns_spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no_pol,
            this.spm,
            this.tahun,
            this.warna,
            this.nama_cust,
            this.kode,
            this.jns_spm,
            this.RowID,
            this.idcust});
            this.customGridView1.Location = new System.Drawing.Point(6, 56);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(709, 217);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 6;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // no_pol
            // 
            this.no_pol.DataPropertyName = "no_pol";
            this.no_pol.HeaderText = "No Polisi";
            this.no_pol.Name = "no_pol";
            this.no_pol.ReadOnly = true;
            this.no_pol.Width = 80;
            // 
            // spm
            // 
            this.spm.DataPropertyName = "spm";
            this.spm.HeaderText = "Sepeda Motor";
            this.spm.Name = "spm";
            this.spm.ReadOnly = true;
            this.spm.Width = 200;
            // 
            // tahun
            // 
            this.tahun.DataPropertyName = "tahun";
            this.tahun.HeaderText = "Tahun";
            this.tahun.Name = "tahun";
            this.tahun.ReadOnly = true;
            this.tahun.Width = 70;
            // 
            // warna
            // 
            this.warna.DataPropertyName = "warna";
            this.warna.HeaderText = "Warna";
            this.warna.Name = "warna";
            this.warna.ReadOnly = true;
            // 
            // nama_cust
            // 
            this.nama_cust.DataPropertyName = "nama_cust";
            this.nama_cust.HeaderText = "Customer";
            this.nama_cust.Name = "nama_cust";
            this.nama_cust.ReadOnly = true;
            this.nama_cust.Width = 200;
            // 
            // kode
            // 
            this.kode.DataPropertyName = "kode";
            this.kode.HeaderText = "Kode";
            this.kode.Name = "kode";
            this.kode.ReadOnly = true;
            this.kode.Visible = false;
            this.kode.Width = 60;
            // 
            // jns_spm
            // 
            this.jns_spm.DataPropertyName = "jns_spm";
            this.jns_spm.HeaderText = "Jenis";
            this.jns_spm.Name = "jns_spm";
            this.jns_spm.ReadOnly = true;
            this.jns_spm.Visible = false;
            this.jns_spm.Width = 150;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // idcust
            // 
            this.idcust.DataPropertyName = "idcust";
            this.idcust.HeaderText = "idcust";
            this.idcust.Name = "idcust";
            this.idcust.ReadOnly = true;
            this.idcust.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(615, 282);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmLookupSpm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(721, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLookupSpm";
            this.Text = "Data Sepeda Motor";
            this.Title = "Data Sepeda Motor";
            this.Load += new System.EventHandler(this.frmLookupSpm_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_pol;
        private System.Windows.Forms.DataGridViewTextBoxColumn spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn warna;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_cust;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn jns_spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcust;
        private ISA.Controls.CommandButton cmdClose;
    }
}
