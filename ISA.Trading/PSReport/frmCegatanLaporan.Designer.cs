namespace ISA.Trading.PSReport
{
    partial class frmCegatanLaporan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCegatanLaporan));
            this.cmdGetPinKunjungan = new System.Windows.Forms.Button();
            this.cmdGetPinCI = new System.Windows.Forms.Button();
            this.txtci = new System.Windows.Forms.TextBox();
            this.txtkunj = new System.Windows.Forms.TextBox();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdyes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdGetPinKunjungan
            // 
            this.cmdGetPinKunjungan.Location = new System.Drawing.Point(268, 186);
            this.cmdGetPinKunjungan.Name = "cmdGetPinKunjungan";
            this.cmdGetPinKunjungan.Size = new System.Drawing.Size(100, 40);
            this.cmdGetPinKunjungan.TabIndex = 5;
            this.cmdGetPinKunjungan.Text = "Pengajuan";
            this.cmdGetPinKunjungan.UseVisualStyleBackColor = true;
            this.cmdGetPinKunjungan.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdGetPinCI
            // 
            this.cmdGetPinCI.Location = new System.Drawing.Point(268, 381);
            this.cmdGetPinCI.Name = "cmdGetPinCI";
            this.cmdGetPinCI.Size = new System.Drawing.Size(100, 40);
            this.cmdGetPinCI.TabIndex = 6;
            this.cmdGetPinCI.Text = "Pengajuan";
            this.cmdGetPinCI.UseVisualStyleBackColor = true;
            this.cmdGetPinCI.Click += new System.EventHandler(this.cmdGetPinCI_Click);
            // 
            // txtci
            // 
            this.txtci.Location = new System.Drawing.Point(114, 391);
            this.txtci.Name = "txtci";
            this.txtci.Size = new System.Drawing.Size(100, 20);
            this.txtci.TabIndex = 7;
            // 
            // txtkunj
            // 
            this.txtkunj.Location = new System.Drawing.Point(114, 207);
            this.txtkunj.Name = "txtkunj";
            this.txtkunj.Size = new System.Drawing.Size(100, 20);
            this.txtkunj.TabIndex = 8;
            this.txtkunj.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(223, 462);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 88;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdyes
            // 
            this.cmdyes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdyes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdyes.Image = global::ISA.Trading.Properties.Resources.Ok32;
            this.cmdyes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdyes.Location = new System.Drawing.Point(55, 462);
            this.cmdyes.Name = "cmdyes";
            this.cmdyes.Size = new System.Drawing.Size(82, 40);
            this.cmdyes.TabIndex = 89;
            this.cmdyes.Text = "OK";
            this.cmdyes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdyes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdyes.UseVisualStyleBackColor = true;
            this.cmdyes.Click += new System.EventHandler(this.cmdyes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 14);
            this.label1.TabIndex = 90;
            this.label1.Text = "Point - point permasalahan yang dapat menyebabkan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 14);
            this.label2.TabIndex = 91;
            this.label2.Text = " proses laporan ini meminta inputan PIN :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 14);
            this.label3.TabIndex = 92;
            this.label3.Text = ">> Adanya data Kunjungan Sales yang masih ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 14);
            this.label4.TabIndex = 93;
            this.label4.Text = "berada dibawah target";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 94;
            this.label5.Text = "Pengajuan PIN ke HO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 14);
            this.label6.TabIndex = 95;
            this.label6.Text = ">> Adanya Toko Customer Inti yang tidak bertransaksi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 14);
            this.label7.TabIndex = 96;
            this.label7.Text = "selama dua bulan terakhir";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 14);
            this.label8.TabIndex = 97;
            this.label8.Text = "Pengajuan PIN ke HO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(62, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 18);
            this.label9.TabIndex = 98;
            this.label9.Text = "PIN";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(62, 391);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 18);
            this.label10.TabIndex = 99;
            this.label10.Text = "PIN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(224, 14);
            this.label11.TabIndex = 101;
            this.label11.Text = "satu bulan terhitung dari tanggal terima";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(287, 14);
            this.label12.TabIndex = 100;
            this.label12.Text = ">> Adanya Stok barang yang tidak bergerak selama";
            // 
            // frmCegatanLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 533);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdyes);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtkunj);
            this.Controls.Add(this.txtci);
            this.Controls.Add(this.cmdGetPinCI);
            this.Controls.Add(this.cmdGetPinKunjungan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCegatanLaporan";
            this.Text = "Pengajuan PIN";
            this.Title = "Pengajuan PIN";
            this.Load += new System.EventHandler(this.frmCegatanLaporan_Load);
            this.Controls.SetChildIndex(this.cmdGetPinKunjungan, 0);
            this.Controls.SetChildIndex(this.cmdGetPinCI, 0);
            this.Controls.SetChildIndex(this.txtci, 0);
            this.Controls.SetChildIndex(this.txtkunj, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdyes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetPinKunjungan;
        private System.Windows.Forms.Button cmdGetPinCI;
        private System.Windows.Forms.TextBox txtci;
        private System.Windows.Forms.TextBox txtkunj;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Button cmdyes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}