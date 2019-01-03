namespace ISA.Toko.Kasir
{
    partial class frmLaporanSaldoperPeriode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanSaldoperPeriode));
            this.label4 = new System.Windows.Forms.Label();
            this.comboJenisTr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.lookupBank1 = new ISA.Toko.Controls.LookupBank();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Jenis Transaksi";
            // 
            // comboJenisTr
            // 
            this.comboJenisTr.DisplayMember = "All";
            this.comboJenisTr.FormattingEnabled = true;
            this.comboJenisTr.Items.AddRange(new object[] {
            "All",
            "Bukti Kas Masuk",
            "Bukti Kas Keluar"});
            this.comboJenisTr.Location = new System.Drawing.Point(133, 110);
            this.comboJenisTr.Name = "comboJenisTr";
            this.comboJenisTr.Size = new System.Drawing.Size(121, 22);
            this.comboJenisTr.TabIndex = 22;
            this.comboJenisTr.Text = "All";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bank";
            this.label3.Visible = false;
            // 
            // comboType
            // 
            this.comboType.DisplayMember = "Kas";
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Kas",
            "Bank",
            "All"});
            this.comboType.Location = new System.Drawing.Point(133, 148);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(121, 22);
            this.comboType.TabIndex = 20;
            this.comboType.Text = "Kas";
            this.comboType.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Type";
            this.label2.Visible = false;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(133, 69);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 18;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Periode";
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(396, 223);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 25;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(31, 223);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 24;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // lookupBank1
            // 
            this.lookupBank1.BankID = "[CODE]";
            this.lookupBank1.Location = new System.Drawing.Point(321, 115);
            this.lookupBank1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lookupBank1.NamaBank = "";
            this.lookupBank1.Name = "lookupBank1";
            this.lookupBank1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupBank1.Size = new System.Drawing.Size(175, 51);
            this.lookupBank1.TabIndex = 28;
            this.lookupBank1.Visible = false;
            // 
            // frmLaporanSaldoperPeriode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 288);
            this.Controls.Add(this.lookupBank1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboJenisTr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanSaldoperPeriode";
            this.Text = "Laporan per Periode";
            this.Title = "Laporan per Periode";
            this.Load += new System.EventHandler(this.frmLaporanSaldoperPeriode_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.comboType, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.comboJenisTr, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.lookupBank1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboJenisTr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.LookupBank lookupBank1;
    }
}