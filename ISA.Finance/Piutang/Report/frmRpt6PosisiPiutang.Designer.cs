namespace ISA.Finance.Piutang.Report
{
    partial class frmRpt6PosisiPiutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt6PosisiPiutang));
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb1KodePos = new System.Windows.Forms.RadioButton();
            this.rdb1Wilayah = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.wilIDComboBox1 = new ISA.Controls.WilIDComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKodePos = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb2TunaiKredit = new System.Windows.Forms.RadioButton();
            this.rdb2Kredit = new System.Windows.Forms.RadioButton();
            this.rdb2Tunai = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.cboTrans = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(388, 329);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 9;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 329);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 8;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Periode Bulan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Laporan Berdasarkan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb1KodePos);
            this.groupBox1.Controls.Add(this.rdb1Wilayah);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(174, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 31);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdb1KodePos
            // 
            this.rdb1KodePos.AutoSize = true;
            this.rdb1KodePos.Location = new System.Drawing.Point(106, 8);
            this.rdb1KodePos.Name = "rdb1KodePos";
            this.rdb1KodePos.Size = new System.Drawing.Size(74, 18);
            this.rdb1KodePos.TabIndex = 1;
            this.rdb1KodePos.TabStop = true;
            this.rdb1KodePos.Text = "KodePos";
            this.rdb1KodePos.UseVisualStyleBackColor = true;
            this.rdb1KodePos.CheckedChanged += new System.EventHandler(this.rdb1KodePos_CheckedChanged);
            // 
            // rdb1Wilayah
            // 
            this.rdb1Wilayah.AutoSize = true;
            this.rdb1Wilayah.Location = new System.Drawing.Point(18, 8);
            this.rdb1Wilayah.Name = "rdb1Wilayah";
            this.rdb1Wilayah.Size = new System.Drawing.Size(82, 18);
            this.rdb1Wilayah.TabIndex = 0;
            this.rdb1Wilayah.TabStop = true;
            this.rdb1Wilayah.Text = "ID. Wilayah";
            this.rdb1Wilayah.UseVisualStyleBackColor = true;
            this.rdb1Wilayah.CheckedChanged += new System.EventHandler(this.rdb1Wilayah_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 18);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "KodeWilayah";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // wilIDComboBox1
            // 
            this.wilIDComboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wilIDComboBox1.DisplayMember = "WilID";
            this.wilIDComboBox1.FormattingEnabled = true;
            this.wilIDComboBox1.Location = new System.Drawing.Point(174, 62);
            this.wilIDComboBox1.Name = "wilIDComboBox1";
            this.wilIDComboBox1.Size = new System.Drawing.Size(100, 22);
            this.wilIDComboBox1.TabIndex = 1;
            this.wilIDComboBox1.ValueMember = "WilID";
            this.wilIDComboBox1.WilID = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "Kode Pos";
            // 
            // cboKodePos
            // 
            this.cboKodePos.FormattingEnabled = true;
            this.cboKodePos.Location = new System.Drawing.Point(367, 62);
            this.cboKodePos.Name = "cboKodePos";
            this.cboKodePos.Size = new System.Drawing.Size(121, 22);
            this.cboKodePos.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb2TunaiKredit);
            this.groupBox2.Controls.Add(this.rdb2Kredit);
            this.groupBox2.Controls.Add(this.rdb2Tunai);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(174, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 83);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // rdb2TunaiKredit
            // 
            this.rdb2TunaiKredit.AutoSize = true;
            this.rdb2TunaiKredit.Location = new System.Drawing.Point(18, 56);
            this.rdb2TunaiKredit.Name = "rdb2TunaiKredit";
            this.rdb2TunaiKredit.Size = new System.Drawing.Size(158, 18);
            this.rdb2TunaiKredit.TabIndex = 2;
            this.rdb2TunaiKredit.TabStop = true;
            this.rdb2TunaiKredit.Text = "Penjualan Tunai && Kredit";
            this.rdb2TunaiKredit.UseVisualStyleBackColor = true;
            // 
            // rdb2Kredit
            // 
            this.rdb2Kredit.AutoSize = true;
            this.rdb2Kredit.Location = new System.Drawing.Point(18, 32);
            this.rdb2Kredit.Name = "rdb2Kredit";
            this.rdb2Kredit.Size = new System.Drawing.Size(114, 18);
            this.rdb2Kredit.TabIndex = 1;
            this.rdb2Kredit.TabStop = true;
            this.rdb2Kredit.Text = "Penjualan Kredit";
            this.rdb2Kredit.UseVisualStyleBackColor = true;
            // 
            // rdb2Tunai
            // 
            this.rdb2Tunai.AutoSize = true;
            this.rdb2Tunai.Location = new System.Drawing.Point(18, 8);
            this.rdb2Tunai.Name = "rdb2Tunai";
            this.rdb2Tunai.Size = new System.Drawing.Size(111, 18);
            this.rdb2Tunai.TabIndex = 0;
            this.rdb2Tunai.TabStop = true;
            this.rdb2Tunai.Text = "Penjualan Tunai";
            this.rdb2Tunai.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Hitung Atas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "Urut Toko";
            // 
            // cboSort
            // 
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Location = new System.Drawing.Point(174, 268);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(196, 22);
            this.cboSort.TabIndex = 7;
            // 
            // cboTrans
            // 
            this.cboTrans.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTrans.FormattingEnabled = true;
            this.cboTrans.Location = new System.Drawing.Point(174, 143);
            this.cboTrans.Name = "cboTrans";
            this.cboTrans.Size = new System.Drawing.Size(121, 22);
            this.cboTrans.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "KodeTransaksi";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(174, 108);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(284, 21);
            this.monthYearBox1.TabIndex = 31;
            this.monthYearBox1.Year = 2011;
            // 
            // frmRpt6PosisiPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(499, 381);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTrans);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboKodePos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wilIDComboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.MaximizeBox = false;
            this.Name = "frmRpt6PosisiPiutang";
            this.Text = "Rekapitulasi Piutang";
            this.Load += new System.EventHandler(this.frmRpt6PosisiPiutang_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.wilIDComboBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboKodePos, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cboSort, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboTrans, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb1KodePos;
        private System.Windows.Forms.RadioButton rdb1Wilayah;
        private System.Windows.Forms.CheckBox checkBox1;
        private ISA.Controls.WilIDComboBox wilIDComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKodePos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb2TunaiKredit;
        private System.Windows.Forms.RadioButton rdb2Kredit;
        private System.Windows.Forms.RadioButton rdb2Tunai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.ComboBox cboTrans;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Controls.MonthYearBox monthYearBox1;
    }
}
