namespace ISA.Finance.V_Otong.Report
{
    partial class frmRpt01RekapTongolan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt01RekapTongolan));
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUserWilID = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb1All = new System.Windows.Forms.RadioButton();
            this.rdb1FB2FE2 = new System.Windows.Forms.RadioButton();
            this.rdb1FB4FE4 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 247);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 3;
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
            this.commandButton2.Location = new System.Drawing.Point(351, 247);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 4;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(118, 20);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Jenis Rekap";
            // 
            // cboUserWilID
            // 
            this.cboUserWilID.FormattingEnabled = true;
            this.cboUserWilID.Location = new System.Drawing.Point(153, 58);
            this.cboUserWilID.Name = "cboUserWilID";
            this.cboUserWilID.Size = new System.Drawing.Size(121, 22);
            this.cboUserWilID.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(60, 18);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Actual";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb1All);
            this.groupBox2.Controls.Add(this.rdb1FB2FE2);
            this.groupBox2.Controls.Add(this.rdb1FB4FE4);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(184, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 105);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // rdb1All
            // 
            this.rdb1All.AutoSize = true;
            this.rdb1All.Checked = true;
            this.rdb1All.Location = new System.Drawing.Point(25, 72);
            this.rdb1All.Name = "rdb1All";
            this.rdb1All.Size = new System.Drawing.Size(47, 18);
            this.rdb1All.TabIndex = 2;
            this.rdb1All.TabStop = true;
            this.rdb1All.Text = "ALL";
            this.rdb1All.UseVisualStyleBackColor = true;
            // 
            // rdb1FB2FE2
            // 
            this.rdb1FB2FE2.AutoSize = true;
            this.rdb1FB2FE2.Location = new System.Drawing.Point(25, 19);
            this.rdb1FB2FE2.Name = "rdb1FB2FE2";
            this.rdb1FB2FE2.Size = new System.Drawing.Size(76, 18);
            this.rdb1FB2FE2.TabIndex = 1;
            this.rdb1FB2FE2.Text = "FB2 && FE2";
            this.rdb1FB2FE2.UseVisualStyleBackColor = true;
            // 
            // rdb1FB4FE4
            // 
            this.rdb1FB4FE4.AutoSize = true;
            this.rdb1FB4FE4.Location = new System.Drawing.Point(25, 48);
            this.rdb1FB4FE4.Name = "rdb1FB4FE4";
            this.rdb1FB4FE4.Size = new System.Drawing.Size(76, 18);
            this.rdb1FB4FE4.TabIndex = 0;
            this.rdb1FB4FE4.Text = "FB4 && FE4";
            this.rdb1FB4FE4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kelompok";
            // 
            // frmRpt01RekapTongolan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(463, 299);
            this.Controls.Add(this.cboUserWilID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.commandButton2);
            this.MaximizeBox = false;
            this.Name = "frmRpt01RekapTongolan";
            this.Load += new System.EventHandler(this.frmRpt1RekapTongolan_Load);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboUserWilID, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUserWilID;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb1All;
        private System.Windows.Forms.RadioButton rdb1FB2FE2;
        private System.Windows.Forms.RadioButton rdb1FB4FE4;
        private System.Windows.Forms.Label label3;
    }
}
