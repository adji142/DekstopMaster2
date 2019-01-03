namespace ISA.Finance.Piutang.Report
{
    partial class frmRpt1SaldoBersihPiutangNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt1SaldoBersihPiutangNota));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb1All = new System.Windows.Forms.RadioButton();
            this.rdb1Kredit = new System.Windows.Forms.RadioButton();
            this.rdb1Tunai = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb2JT = new System.Windows.Forms.RadioButton();
            this.rdb2Nota = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookupToko1 = new ISA.Controls.LookupToko();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LMinus = new System.Windows.Forms.CheckBox();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb1All);
            this.groupBox1.Controls.Add(this.rdb1Kredit);
            this.groupBox1.Controls.Add(this.rdb1Tunai);
            this.groupBox1.Location = new System.Drawing.Point(134, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 38);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdb1All
            // 
            this.rdb1All.AutoSize = true;
            this.rdb1All.Location = new System.Drawing.Point(202, 13);
            this.rdb1All.Name = "rdb1All";
            this.rdb1All.Size = new System.Drawing.Size(39, 18);
            this.rdb1All.TabIndex = 2;
            this.rdb1All.TabStop = true;
            this.rdb1All.Text = "All";
            this.rdb1All.UseVisualStyleBackColor = true;
            // 
            // rdb1Kredit
            // 
            this.rdb1Kredit.AutoSize = true;
            this.rdb1Kredit.Location = new System.Drawing.Point(108, 12);
            this.rdb1Kredit.Name = "rdb1Kredit";
            this.rdb1Kredit.Size = new System.Drawing.Size(58, 18);
            this.rdb1Kredit.TabIndex = 1;
            this.rdb1Kredit.TabStop = true;
            this.rdb1Kredit.Text = "Kredit";
            this.rdb1Kredit.UseVisualStyleBackColor = true;
            // 
            // rdb1Tunai
            // 
            this.rdb1Tunai.AutoSize = true;
            this.rdb1Tunai.Location = new System.Drawing.Point(7, 12);
            this.rdb1Tunai.Name = "rdb1Tunai";
            this.rdb1Tunai.Size = new System.Drawing.Size(54, 18);
            this.rdb1Tunai.TabIndex = 0;
            this.rdb1Tunai.TabStop = true;
            this.rdb1Tunai.Text = "Tunai";
            this.rdb1Tunai.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb2JT);
            this.groupBox2.Controls.Add(this.rdb2Nota);
            this.groupBox2.Location = new System.Drawing.Point(134, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 36);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rdb2JT
            // 
            this.rdb2JT.AutoSize = true;
            this.rdb2JT.Location = new System.Drawing.Point(108, 12);
            this.rdb2JT.Name = "rdb2JT";
            this.rdb2JT.Size = new System.Drawing.Size(83, 18);
            this.rdb2JT.TabIndex = 1;
            this.rdb2JT.TabStop = true;
            this.rdb2JT.Text = "Tanggal JT";
            this.rdb2JT.UseVisualStyleBackColor = true;
            // 
            // rdb2Nota
            // 
            this.rdb2Nota.AutoSize = true;
            this.rdb2Nota.Location = new System.Drawing.Point(7, 12);
            this.rdb2Nota.Name = "rdb2Nota";
            this.rdb2Nota.Size = new System.Drawing.Size(94, 18);
            this.rdb2Nota.TabIndex = 0;
            this.rdb2Nota.TabStop = true;
            this.rdb2Nota.Text = "Tanggal Nota";
            this.rdb2Nota.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proses s/d Tgl.";
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 504);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName2 = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 8;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(474, 504);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName2 = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 8;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Penjualan";
            // 
            // cboSort
            // 
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Location = new System.Drawing.Point(134, 145);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(334, 22);
            this.cboSort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Berdasarkan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Urut Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Filter";
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Catatan = "";
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.Grade = "";
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(134, 280);
            this.lookupToko1.LookUpType = ISA.Controls.LookupToko.EnumLookUpType.Aktif;
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Pasif = false;
            this.lookupToko1.Penanggungjawab = "";
            this.lookupToko1.Plafon = 0;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(300, 54);
            this.lookupToko1.TabIndex = 5;
            this.lookupToko1.Telp = "";
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = null;
            this.lookupToko1.Load += new System.EventHandler(this.lookupToko1_Load);
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(134, 220);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(300, 54);
            this.lookupSales1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nama Sales";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "Nama Toko";
            // 
            // LMinus
            // 
            this.LMinus.AutoSize = true;
            this.LMinus.Location = new System.Drawing.Point(48, 371);
            this.LMinus.Name = "LMinus";
            this.LMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LMinus.Size = new System.Drawing.Size(112, 18);
            this.LMinus.TabIndex = 7;
            this.LMinus.Text = "Cetak Saldo <=0";
            this.LMinus.UseVisualStyleBackColor = true;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(134, 20);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 335);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "WilID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(307, 338);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "s/d";
            // 
            // frmRpt1SaldoBersihPiutangNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(586, 556);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.LMinus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt1SaldoBersihPiutangNota";
            this.Text = "Saldo Piutang Nota JT";
            this.Load += new System.EventHandler(this.frmRpt1SaldoBersihPiutangNota_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboSort, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.LMinus, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb1All;
        private System.Windows.Forms.RadioButton rdb1Kredit;
        private System.Windows.Forms.RadioButton rdb1Tunai;
        private System.Windows.Forms.RadioButton rdb2JT;
        private System.Windows.Forms.RadioButton rdb2Nota;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.LookupToko lookupToko1;
        private ISA.Controls.LookupSales lookupSales1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox LMinus;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
    }
}
