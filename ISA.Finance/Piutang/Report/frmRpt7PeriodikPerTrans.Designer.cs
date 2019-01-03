namespace ISA.Finance.Piutang.Report
{
    partial class frmRpt7PeriodikPerTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt7PeriodikPerTrans));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb2Piutang = new System.Windows.Forms.RadioButton();
            this.rdb1Accounting = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb2TunaiKredit = new System.Windows.Forms.RadioButton();
            this.rdb2Kredit = new System.Windows.Forms.RadioButton();
            this.rdb2Tunai = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(113, 80);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 2;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kode Transaksi";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "WilID";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tanggal";
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(147, 117);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Jenis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "Urut ";
            // 
            // cboSort
            // 
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Location = new System.Drawing.Point(147, 220);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(196, 22);
            this.cboSort.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb2Piutang);
            this.groupBox2.Controls.Add(this.rdb1Accounting);
            this.groupBox2.Location = new System.Drawing.Point(147, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 52);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // rdb2Piutang
            // 
            this.rdb2Piutang.AutoSize = true;
            this.rdb2Piutang.Location = new System.Drawing.Point(115, 20);
            this.rdb2Piutang.Name = "rdb2Piutang";
            this.rdb2Piutang.Size = new System.Drawing.Size(66, 18);
            this.rdb2Piutang.TabIndex = 1;
            this.rdb2Piutang.TabStop = true;
            this.rdb2Piutang.Text = "Piutang";
            this.rdb2Piutang.UseVisualStyleBackColor = true;
            // 
            // rdb1Accounting
            // 
            this.rdb1Accounting.AutoSize = true;
            this.rdb1Accounting.Location = new System.Drawing.Point(14, 19);
            this.rdb1Accounting.Name = "rdb1Accounting";
            this.rdb1Accounting.Size = new System.Drawing.Size(87, 18);
            this.rdb1Accounting.TabIndex = 0;
            this.rdb1Accounting.TabStop = true;
            this.rdb1Accounting.Text = "Accounting";
            this.rdb1Accounting.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 31;
            this.label7.Text = "Versi Laporan";
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 351);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 7;
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
            this.commandButton2.Location = new System.Drawing.Point(404, 351);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 8;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb2TunaiKredit);
            this.groupBox1.Controls.Add(this.rdb2Kredit);
            this.groupBox1.Controls.Add(this.rdb2Tunai);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(147, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 33);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rdb2TunaiKredit
            // 
            this.rdb2TunaiKredit.AutoSize = true;
            this.rdb2TunaiKredit.Location = new System.Drawing.Point(161, 8);
            this.rdb2TunaiKredit.Name = "rdb2TunaiKredit";
            this.rdb2TunaiKredit.Size = new System.Drawing.Size(101, 18);
            this.rdb2TunaiKredit.TabIndex = 2;
            this.rdb2TunaiKredit.TabStop = true;
            this.rdb2TunaiKredit.Text = "Tunai && Kredit";
            this.rdb2TunaiKredit.UseVisualStyleBackColor = true;
            // 
            // rdb2Kredit
            // 
            this.rdb2Kredit.AutoSize = true;
            this.rdb2Kredit.Location = new System.Drawing.Point(97, 8);
            this.rdb2Kredit.Name = "rdb2Kredit";
            this.rdb2Kredit.Size = new System.Drawing.Size(58, 18);
            this.rdb2Kredit.TabIndex = 1;
            this.rdb2Kredit.TabStop = true;
            this.rdb2Kredit.Text = "Kredit";
            this.rdb2Kredit.UseVisualStyleBackColor = true;
            // 
            // rdb2Tunai
            // 
            this.rdb2Tunai.AutoSize = true;
            this.rdb2Tunai.Location = new System.Drawing.Point(18, 8);
            this.rdb2Tunai.Name = "rdb2Tunai";
            this.rdb2Tunai.Size = new System.Drawing.Size(54, 18);
            this.rdb2Tunai.TabIndex = 0;
            this.rdb2Tunai.TabStop = true;
            this.rdb2Tunai.Text = "Tunai";
            this.rdb2Tunai.UseVisualStyleBackColor = true;
            // 
            // frmRpt7PeriodikPerTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(516, 403);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboSort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.MaximizeBox = false;
            this.Name = "frmRpt7PeriodikPerTrans";
            this.Text = "Laporan Transaksi";
            this.Load += new System.EventHandler(this.frmRpt7PeriodikPerTrans_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboSort, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Finance.Controls.KodeTransComboBox kodeTransComboBox1;
        private System.Windows.Forms.Label label1;
        //private ISA.Controls.WilIDComboBox wilIDComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.LookupSales lookupSales1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb2Piutang;
        private System.Windows.Forms.RadioButton rdb1Accounting;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb2TunaiKredit;
        private System.Windows.Forms.RadioButton rdb2Kredit;
        private System.Windows.Forms.RadioButton rdb2Tunai;
    }
}
