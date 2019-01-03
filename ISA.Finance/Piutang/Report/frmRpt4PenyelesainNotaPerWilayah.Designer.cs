namespace ISA.Finance.Piutang.Report
{
    partial class frmRpt4PenyelesainNotaPerWilayah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt4PenyelesainNotaPerWilayah));
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.wilIDComboBox1 = new ISA.Controls.WilIDComboBox();
            this.LMinus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb1Toko = new System.Windows.Forms.RadioButton();
            this.rdb1WilID = new System.Windows.Forms.RadioButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(130, 28);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(167, 84);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 2;
            // 
            // wilIDComboBox1
            // 
            this.wilIDComboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wilIDComboBox1.DisplayMember = "WilID";
            this.wilIDComboBox1.FormattingEnabled = true;
            this.wilIDComboBox1.Location = new System.Drawing.Point(168, 56);
            this.wilIDComboBox1.Name = "wilIDComboBox1";
            this.wilIDComboBox1.Size = new System.Drawing.Size(100, 22);
            this.wilIDComboBox1.TabIndex = 1;
            this.wilIDComboBox1.ValueMember = "WilID";
            this.wilIDComboBox1.WilID = "";
            // 
            // LMinus
            // 
            this.LMinus.AutoSize = true;
            this.LMinus.Location = new System.Drawing.Point(28, 132);
            this.LMinus.Name = "LMinus";
            this.LMinus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LMinus.Size = new System.Drawing.Size(157, 18);
            this.LMinus.TabIndex = 3;
            this.LMinus.Text = "Cetak Saldo < 0                ";
            this.LMinus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb1Toko);
            this.groupBox1.Controls.Add(this.rdb1WilID);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(168, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 49);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rdb1Toko
            // 
            this.rdb1Toko.AutoSize = true;
            this.rdb1Toko.Checked = true;
            this.rdb1Toko.Location = new System.Drawing.Point(91, 19);
            this.rdb1Toko.Name = "rdb1Toko";
            this.rdb1Toko.Size = new System.Drawing.Size(83, 18);
            this.rdb1Toko.TabIndex = 1;
            this.rdb1Toko.TabStop = true;
            this.rdb1Toko.Text = "NamaToko";
            this.rdb1Toko.UseVisualStyleBackColor = true;
            // 
            // rdb1WilID
            // 
            this.rdb1WilID.AutoSize = true;
            this.rdb1WilID.Location = new System.Drawing.Point(7, 19);
            this.rdb1WilID.Name = "rdb1WilID";
            this.rdb1WilID.Size = new System.Drawing.Size(51, 18);
            this.rdb1WilID.TabIndex = 0;
            this.rdb1WilID.Text = "WilID";
            this.rdb1WilID.UseVisualStyleBackColor = true;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 234);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 5;
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
            this.commandButton2.Location = new System.Drawing.Point(399, 234);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 6;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Wilayah";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nama Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Urut";
            // 
            // frmRpt4PenyelesainNotaPerWilayah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(511, 286);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.wilIDComboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LMinus);
            this.MaximizeBox = false;
            this.Name = "frmRpt4PenyelesainNotaPerWilayah";
            this.Text = "Penyelesain Piutang";
            this.Load += new System.EventHandler(this.frmRpt4PenyelesainNotaPerWilayah_Load);
            this.Controls.SetChildIndex(this.LMinus, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.wilIDComboBox1, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.LookupSales lookupSales1;
        private ISA.Controls.WilIDComboBox wilIDComboBox1;
        private System.Windows.Forms.CheckBox LMinus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb1Toko;
        private System.Windows.Forms.RadioButton rdb1WilID;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
