namespace ISA.Finance.Tac
{
    partial class frmTAC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTAC));
            this.cmdProses = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pbSyncUpload = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.cmdWilayah = new System.Windows.Forms.Button();
            this.cmdToko = new System.Windows.Forms.Button();
            this.cmdSales = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Counter = new ISA.Controls.CommonTextBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdLaporan = new System.Windows.Forms.Button();
            this.cmdPlafon = new ISA.Controls.CommandButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGudang = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdProses
            // 
            this.cmdProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProses.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.cmdProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProses.Location = new System.Drawing.Point(132, 313);
            this.cmdProses.Name = "cmdProses";
            this.cmdProses.Size = new System.Drawing.Size(108, 43);
            this.cmdProses.TabIndex = 5;
            this.cmdProses.Text = "      PROSES";
            this.cmdProses.UseVisualStyleBackColor = true;
            this.cmdProses.Click += new System.EventHandler(this.cmdProses_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = global::ISA.Finance.Properties.Resources.Close32;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(474, 313);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(108, 43);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "     CLOSE";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pbSyncUpload
            // 
            this.pbSyncUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncUpload.Location = new System.Drawing.Point(12, 243);
            this.pbSyncUpload.Name = "pbSyncUpload";
            this.pbSyncUpload.Size = new System.Drawing.Size(709, 23);
            this.pbSyncUpload.TabIndex = 13;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(19, 292);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 14);
            this.lblProgress.TabIndex = 21;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(196, 269);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(22, 14);
            this.lblUpload.TabIndex = 23;
            this.lblUpload.Text = "0/9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Table Upload:";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Location = new System.Drawing.Point(658, 269);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(40, 14);
            this.lblUploadCount.TabIndex = 24;
            this.lblUploadCount.Text = "Count";
            this.lblUploadCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdWilayah
            // 
            this.cmdWilayah.Location = new System.Drawing.Point(389, 77);
            this.cmdWilayah.Name = "cmdWilayah";
            this.cmdWilayah.Size = new System.Drawing.Size(59, 23);
            this.cmdWilayah.TabIndex = 25;
            this.cmdWilayah.Text = "Wilayah";
            this.cmdWilayah.UseVisualStyleBackColor = true;
            this.cmdWilayah.Click += new System.EventHandler(this.cmdWilayah_Click);
            // 
            // cmdToko
            // 
            this.cmdToko.Location = new System.Drawing.Point(97, 77);
            this.cmdToko.Name = "cmdToko";
            this.cmdToko.Size = new System.Drawing.Size(59, 23);
            this.cmdToko.TabIndex = 26;
            this.cmdToko.Text = "Toko";
            this.cmdToko.UseVisualStyleBackColor = true;
            this.cmdToko.Click += new System.EventHandler(this.cmdToko_Click);
            // 
            // cmdSales
            // 
            this.cmdSales.Location = new System.Drawing.Point(389, 102);
            this.cmdSales.Name = "cmdSales";
            this.cmdSales.Size = new System.Drawing.Size(59, 23);
            this.cmdSales.TabIndex = 27;
            this.cmdSales.Text = "Sales";
            this.cmdSales.UseVisualStyleBackColor = true;
            this.cmdSales.Click += new System.EventHandler(this.cmdSales_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "TAC berdasarkan Wilayah tertentu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "TAC berdasarkan Toko-toko tertentu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "TAC berdasarkan Sales tertentu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 14);
            this.label5.TabIndex = 32;
            this.label5.Text = "TAC berdasarkan Kota-kota tertentu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Kota";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 34;
            this.label6.Text = " SETUP  TAC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "Table Update:";
            // 
            // Counter
            // 
            this.Counter.BackColor = System.Drawing.SystemColors.Menu;
            this.Counter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Counter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Counter.Enabled = false;
            this.Counter.Location = new System.Drawing.Point(99, 213);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(45, 13);
            this.Counter.TabIndex = 36;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Image = global::ISA.Finance.Properties.Resources.Ok32;
            this.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdate.Location = new System.Drawing.Point(360, 313);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(108, 43);
            this.cmdUpdate.TabIndex = 38;
            this.cmdUpdate.Text = "      UPDATE";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdLaporan
            // 
            this.cmdLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLaporan.Image = global::ISA.Finance.Properties.Resources.Printer32;
            this.cmdLaporan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLaporan.Location = new System.Drawing.Point(246, 313);
            this.cmdLaporan.Name = "cmdLaporan";
            this.cmdLaporan.Size = new System.Drawing.Size(108, 43);
            this.cmdLaporan.TabIndex = 39;
            this.cmdLaporan.Text = "      LAPORAN";
            this.cmdLaporan.UseVisualStyleBackColor = true;
            this.cmdLaporan.Click += new System.EventHandler(this.cmdLaporan_Click);
            // 
            // cmdPlafon
            // 
            this.cmdPlafon.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdPlafon.Enabled = false;
            this.cmdPlafon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPlafon.Image = ((System.Drawing.Image)(resources.GetObject("cmdPlafon.Image")));
            this.cmdPlafon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPlafon.Location = new System.Drawing.Point(621, 186);
            this.cmdPlafon.Name = "cmdPlafon";
            this.cmdPlafon.ReportName2 = "";
            this.cmdPlafon.Size = new System.Drawing.Size(100, 40);
            this.cmdPlafon.TabIndex = 40;
            this.cmdPlafon.Text = "YES";
            this.cmdPlafon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPlafon.UseVisualStyleBackColor = true;
            this.cmdPlafon.Visible = false;
            this.cmdPlafon.Click += new System.EventHandler(this.cmdPlafon_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 14);
            this.label8.TabIndex = 42;
            this.label8.Text = "KE GUDANG";
            // 
            // txtGudang
            // 
            this.txtGudang.Location = new System.Drawing.Point(98, 135);
            this.txtGudang.Name = "txtGudang";
            this.txtGudang.Size = new System.Drawing.Size(57, 20);
            this.txtGudang.TabIndex = 43;
            // 
            // frmTAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(732, 383);
            this.Controls.Add(this.txtGudang);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdPlafon);
            this.Controls.Add(this.cmdLaporan);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.Counter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSales);
            this.Controls.Add(this.cmdToko);
            this.Controls.Add(this.cmdWilayah);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbSyncUpload);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProses);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTAC";
            this.Text = "Transfer Antar Cabang  (TAC)";
            this.Title = "Transfer Antar Cabang  (TAC)";
            this.Load += new System.EventHandler(this.frmTAC_Load);
            this.Controls.SetChildIndex(this.cmdProses, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.pbSyncUpload, 0);
            this.Controls.SetChildIndex(this.lblProgress, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblUpload, 0);
            this.Controls.SetChildIndex(this.lblUploadCount, 0);
            this.Controls.SetChildIndex(this.cmdWilayah, 0);
            this.Controls.SetChildIndex(this.cmdToko, 0);
            this.Controls.SetChildIndex(this.cmdSales, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.Counter, 0);
            this.Controls.SetChildIndex(this.cmdUpdate, 0);
            this.Controls.SetChildIndex(this.cmdLaporan, 0);
            this.Controls.SetChildIndex(this.cmdPlafon, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtGudang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProses;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ProgressBar pbSyncUpload;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Button cmdWilayah;
        private System.Windows.Forms.Button cmdToko;
        private System.Windows.Forms.Button cmdSales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox Counter;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdLaporan;
        private ISA.Controls.CommandButton cmdPlafon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGudang;
    }
}
