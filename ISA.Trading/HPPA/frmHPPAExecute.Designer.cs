namespace ISA.Trading.HPPA
{
    partial class frmHPPAExecute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPPAExecute));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.colBarangID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtyAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRpAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtyBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRpBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtyReturBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRpReturBeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtyAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRpAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarangID,
            this.colNamaBarang,
            this.colQtyAwal,
            this.colRpAwal,
            this.colQtyBeli,
            this.colRpBeli,
            this.colQtyReturBeli,
            this.colRpReturBeli,
            this.colHPP,
            this.colQtyAkhir,
            this.colRpAkhir,
            this.colTglAktif,
            this.Ket,
            this.Msg});
            this.customGridView1.Location = new System.Drawing.Point(9, 50);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(728, 196);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 252);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(728, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(637, 290);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 1;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(13, 282);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(39, 14);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "label1";
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(491, 291);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 0;
            this.commandButton2.Text = "YES";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
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
            this.colNamaBarang.DataPropertyName = "NamaStok";
            this.colNamaBarang.HeaderText = "Nama Barang";
            this.colNamaBarang.Name = "colNamaBarang";
            this.colNamaBarang.ReadOnly = true;
            this.colNamaBarang.Width = 300;
            // 
            // colQtyAwal
            // 
            this.colQtyAwal.DataPropertyName = "QtyAwal";
            dataGridViewCellStyle1.Format = "#,##0";
            this.colQtyAwal.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQtyAwal.HeaderText = "QtyAwal";
            this.colQtyAwal.Name = "colQtyAwal";
            this.colQtyAwal.ReadOnly = true;
            // 
            // colRpAwal
            // 
            this.colRpAwal.DataPropertyName = "RpAwal";
            dataGridViewCellStyle2.Format = "#,##0";
            this.colRpAwal.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRpAwal.HeaderText = "Rp Awal";
            this.colRpAwal.Name = "colRpAwal";
            this.colRpAwal.ReadOnly = true;
            // 
            // colQtyBeli
            // 
            this.colQtyBeli.DataPropertyName = "QtyBeli";
            dataGridViewCellStyle3.Format = "#,##0";
            this.colQtyBeli.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQtyBeli.HeaderText = "Qty Beli";
            this.colQtyBeli.Name = "colQtyBeli";
            this.colQtyBeli.ReadOnly = true;
            // 
            // colRpBeli
            // 
            this.colRpBeli.DataPropertyName = "RpBeli";
            dataGridViewCellStyle4.Format = "#,##0";
            this.colRpBeli.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRpBeli.HeaderText = "Rp Beli";
            this.colRpBeli.Name = "colRpBeli";
            this.colRpBeli.ReadOnly = true;
            // 
            // colQtyReturBeli
            // 
            this.colQtyReturBeli.DataPropertyName = "QtyReturBeli";
            dataGridViewCellStyle5.Format = "#,##0";
            this.colQtyReturBeli.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtyReturBeli.HeaderText = "Qty Retur Beli";
            this.colQtyReturBeli.Name = "colQtyReturBeli";
            this.colQtyReturBeli.ReadOnly = true;
            this.colQtyReturBeli.Visible = false;
            // 
            // colRpReturBeli
            // 
            this.colRpReturBeli.DataPropertyName = "RpReturBeli";
            dataGridViewCellStyle6.Format = "#,##0";
            this.colRpReturBeli.DefaultCellStyle = dataGridViewCellStyle6;
            this.colRpReturBeli.HeaderText = "Rp Retur Beli";
            this.colRpReturBeli.Name = "colRpReturBeli";
            this.colRpReturBeli.ReadOnly = true;
            this.colRpReturBeli.Visible = false;
            // 
            // colHPP
            // 
            this.colHPP.DataPropertyName = "HPP";
            dataGridViewCellStyle7.Format = "#,##0";
            this.colHPP.DefaultCellStyle = dataGridViewCellStyle7;
            this.colHPP.HeaderText = "HPP";
            this.colHPP.Name = "colHPP";
            this.colHPP.ReadOnly = true;
            // 
            // colQtyAkhir
            // 
            this.colQtyAkhir.DataPropertyName = "QtyAkhir";
            dataGridViewCellStyle8.Format = "#,##0";
            this.colQtyAkhir.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQtyAkhir.HeaderText = "Qty Akhir";
            this.colQtyAkhir.Name = "colQtyAkhir";
            this.colQtyAkhir.ReadOnly = true;
            // 
            // colRpAkhir
            // 
            this.colRpAkhir.DataPropertyName = "RpAkhir";
            dataGridViewCellStyle9.Format = "#,##0";
            this.colRpAkhir.DefaultCellStyle = dataGridViewCellStyle9;
            this.colRpAkhir.HeaderText = "Rp Akhir";
            this.colRpAkhir.Name = "colRpAkhir";
            this.colRpAkhir.ReadOnly = true;
            // 
            // colTglAktif
            // 
            this.colTglAktif.DataPropertyName = "TglAktif";
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            this.colTglAktif.DefaultCellStyle = dataGridViewCellStyle10;
            this.colTglAktif.HeaderText = "Tgl Aktif";
            this.colTglAktif.Name = "colTglAktif";
            this.colTglAktif.ReadOnly = true;
            // 
            // Ket
            // 
            this.Ket.DataPropertyName = "Ket";
            this.Ket.HeaderText = "Ket";
            this.Ket.Name = "Ket";
            this.Ket.ReadOnly = true;
            this.Ket.Visible = false;
            // 
            // Msg
            // 
            this.Msg.DataPropertyName = "Msg";
            this.Msg.HeaderText = "Msg";
            this.Msg.Name = "Msg";
            this.Msg.ReadOnly = true;
            this.Msg.Visible = false;
            // 
            // frmHPPAExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(746, 342);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHPPAExecute";
            this.Text = "HPPA";
            this.Title = "HPPA";
            this.Load += new System.EventHandler(this.frmHPPAExecute_Load);
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

        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label lblCount;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarangID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtyAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRpAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtyBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRpBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtyReturBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRpReturBeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtyAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRpAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Msg;
    }
}
