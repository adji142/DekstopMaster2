namespace ISA.Trading.Pembelian
{
    partial class frmRptPembPerBarangFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPembPerBarangFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.cboGudang = new System.Windows.Forms.ComboBox();
            this.rdbTglTerima = new ISA.Trading.Controls.RangeDateBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHPPA = new System.Windows.Forms.RadioButton();
            this.rdoHrgBeli = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tgl.Terima:";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(194, 224);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 3;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "Gudang:";
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(85, 224);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 2;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cboGudang
            // 
            this.cboGudang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGudang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGudang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGudang.FormattingEnabled = true;
            this.cboGudang.Location = new System.Drawing.Point(118, 103);
            this.cboGudang.Name = "cboGudang";
            this.cboGudang.Size = new System.Drawing.Size(230, 22);
            this.cboGudang.TabIndex = 1;
            // 
            // rdbTglTerima
            // 
            this.rdbTglTerima.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTglTerima.FromDate = null;
            this.rdbTglTerima.Location = new System.Drawing.Point(113, 66);
            this.rdbTglTerima.Name = "rdbTglTerima";
            this.rdbTglTerima.Size = new System.Drawing.Size(257, 22);
            this.rdbTglTerima.TabIndex = 0;
            this.rdbTglTerima.ToDate = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHPPA);
            this.groupBox1.Controls.Add(this.rdoHrgBeli);
            this.groupBox1.Location = new System.Drawing.Point(116, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 60);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rdoHPPA
            // 
            this.rdoHPPA.AutoSize = true;
            this.rdoHPPA.Location = new System.Drawing.Point(17, 36);
            this.rdoHPPA.Name = "rdoHPPA";
            this.rdoHPPA.Size = new System.Drawing.Size(97, 18);
            this.rdoHPPA.TabIndex = 1;
            this.rdoHPPA.Text = "HPP Rata-rata";
            this.rdoHPPA.UseVisualStyleBackColor = true;
            // 
            // rdoHrgBeli
            // 
            this.rdoHrgBeli.AutoSize = true;
            this.rdoHrgBeli.Checked = true;
            this.rdoHrgBeli.Location = new System.Drawing.Point(17, 12);
            this.rdoHrgBeli.Name = "rdoHrgBeli";
            this.rdoHrgBeli.Size = new System.Drawing.Size(79, 18);
            this.rdoHrgBeli.TabIndex = 0;
            this.rdoHrgBeli.TabStop = true;
            this.rdoHrgBeli.Text = "Harga Beli";
            this.rdoHrgBeli.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptPembPerBarangFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(382, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cboGudang);
            this.Controls.Add(this.rdbTglTerima);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptPembPerBarangFilter";
            this.Text = "Laporan Pembelian per Barang";
            this.Title = "Laporan Pembelian per Barang";
            this.Load += new System.EventHandler(this.frmPembelianPerBarangFilter_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.rdbTglTerima, 0);
            this.Controls.SetChildIndex(this.cboGudang, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommandButton cmdYES;
        private System.Windows.Forms.ComboBox cboGudang;
        private ISA.Trading.Controls.RangeDateBox rdbTglTerima;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoHPPA;
        private System.Windows.Forms.RadioButton rdoHrgBeli;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
