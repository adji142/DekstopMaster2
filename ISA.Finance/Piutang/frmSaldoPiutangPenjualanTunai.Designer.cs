namespace ISA.Finance.Piutang
{
    partial class frmSaldoPiutangPenjualanTunai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldoPiutangPenjualanTunai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idwil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nota Tunai dibawah ini belum lunas.  Segera ambil tindakan penyelesaian.";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglNota,
            this.NoNota,
            this.NamaToko,
            this.Kota,
            this.Idwil,
            this.RpNota,
            this.Saldo});
            this.dataGridView.Location = new System.Drawing.Point(9, 77);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(797, 283);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 6;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(707, 366);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglNota.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglNota.HeaderText = "Tgl Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            this.TglNota.Width = 85;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            this.NoNota.Width = 80;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            this.NamaToko.Width = 175;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Width = 140;
            // 
            // Idwil
            // 
            this.Idwil.DataPropertyName = "Idwil";
            this.Idwil.HeaderText = "Idwil";
            this.Idwil.Name = "Idwil";
            this.Idwil.ReadOnly = true;
            this.Idwil.Width = 70;
            // 
            // RpNota
            // 
            this.RpNota.DataPropertyName = "RpNota";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.RpNota.DefaultCellStyle = dataGridViewCellStyle2;
            this.RpNota.HeaderText = "Rp Nota";
            this.RpNota.Name = "RpNota";
            this.RpNota.ReadOnly = true;
            this.RpNota.Width = 80;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Saldo.HeaderText = "Saldo Piutang";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // frmSaldoPiutangPenjualanTunai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(814, 427);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSaldoPiutangPenjualanTunai";
            this.Text = "Saldo Piutang Penjualan Tunai";
            this.Title = "Saldo Piutang Penjualan Tunai";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmSaldoPiutangPenjualanTunai_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dataGridView, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView dataGridView;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idwil;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}
