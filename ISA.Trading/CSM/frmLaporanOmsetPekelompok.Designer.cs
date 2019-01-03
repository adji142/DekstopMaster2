namespace ISA.Trading.CSM
{
    partial class frmLaporanOmsetPekelompok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaporanOmsetPekelompok));
            this.txtDate1 = new ISA.Trading.Controls.DateTextBox();
            this.txtDate2 = new ISA.Trading.Controls.DateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbCustomerInti = new System.Windows.Forms.RadioButton();
            this.rbMitraSAS = new System.Windows.Forms.RadioButton();
            this.rbMitraPS = new System.Windows.Forms.RadioButton();
            this.rbCalnCI = new System.Windows.Forms.RadioButton();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.rbRegular = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtDate1
            // 
            this.txtDate1.DateValue = null;
            this.txtDate1.Location = new System.Drawing.Point(170, 69);
            this.txtDate1.MaxLength = 10;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Size = new System.Drawing.Size(80, 20);
            this.txtDate1.TabIndex = 5;
            this.txtDate1.TextChanged += new System.EventHandler(this.txtDate1_TextChanged);
            // 
            // txtDate2
            // 
            this.txtDate2.DateValue = null;
            this.txtDate2.Location = new System.Drawing.Point(321, 69);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(80, 20);
            this.txtDate2.TabIndex = 6;
            this.txtDate2.TextChanged += new System.EventHandler(this.txtDate2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tanggal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "s/d";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rbCustomerInti
            // 
            this.rbCustomerInti.AutoSize = true;
            this.rbCustomerInti.Location = new System.Drawing.Point(183, 122);
            this.rbCustomerInti.Name = "rbCustomerInti";
            this.rbCustomerInti.Size = new System.Drawing.Size(101, 18);
            this.rbCustomerInti.TabIndex = 9;
            this.rbCustomerInti.TabStop = true;
            this.rbCustomerInti.Text = "Customer Inti";
            this.rbCustomerInti.UseVisualStyleBackColor = true;
            this.rbCustomerInti.CheckedChanged += new System.EventHandler(this.rbCustomerInti_CheckedChanged);
            // 
            // rbMitraSAS
            // 
            this.rbMitraSAS.AutoSize = true;
            this.rbMitraSAS.Location = new System.Drawing.Point(183, 170);
            this.rbMitraSAS.Name = "rbMitraSAS";
            this.rbMitraSAS.Size = new System.Drawing.Size(78, 18);
            this.rbMitraSAS.TabIndex = 10;
            this.rbMitraSAS.TabStop = true;
            this.rbMitraSAS.Text = "Mitra SAS";
            this.rbMitraSAS.UseVisualStyleBackColor = true;
            this.rbMitraSAS.CheckedChanged += new System.EventHandler(this.rbMitraSAS_CheckedChanged);
            // 
            // rbMitraPS
            // 
            this.rbMitraPS.AutoSize = true;
            this.rbMitraPS.Location = new System.Drawing.Point(183, 147);
            this.rbMitraPS.Name = "rbMitraPS";
            this.rbMitraPS.Size = new System.Drawing.Size(70, 18);
            this.rbMitraPS.TabIndex = 11;
            this.rbMitraPS.TabStop = true;
            this.rbMitraPS.Text = "Mitra PS";
            this.rbMitraPS.UseVisualStyleBackColor = true;
            this.rbMitraPS.CheckedChanged += new System.EventHandler(this.rbMitraPS_CheckedChanged);
            // 
            // rbCalnCI
            // 
            this.rbCalnCI.AutoSize = true;
            this.rbCalnCI.Location = new System.Drawing.Point(183, 195);
            this.rbCalnCI.Name = "rbCalnCI";
            this.rbCalnCI.Size = new System.Drawing.Size(160, 18);
            this.rbCalnCI.TabIndex = 12;
            this.rbCalnCI.TabStop = true;
            this.rbCalnCI.Text = "Calon Customer Inti SAS";
            this.rbCalnCI.UseVisualStyleBackColor = true;
            this.rbCalnCI.CheckedChanged += new System.EventHandler(this.rbCalnCI_CheckedChanged);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(100, 250);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 13;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(299, 250);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 14;
            this.commandButton2.Text = "CANCEL";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // rbRegular
            // 
            this.rbRegular.AutoSize = true;
            this.rbRegular.Location = new System.Drawing.Point(183, 217);
            this.rbRegular.Name = "rbRegular";
            this.rbRegular.Size = new System.Drawing.Size(67, 18);
            this.rbRegular.TabIndex = 15;
            this.rbRegular.TabStop = true;
            this.rbRegular.Text = "Regular";
            this.rbRegular.UseVisualStyleBackColor = true;
            // 
            // frmLaporanOmsetPekelompok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.rbRegular);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.rbCalnCI);
            this.Controls.Add(this.rbMitraPS);
            this.Controls.Add(this.rbMitraSAS);
            this.Controls.Add(this.rbCustomerInti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLaporanOmsetPekelompok";
            this.Load += new System.EventHandler(this.frmLaporanOmsetPekelompok_Load);
            this.Controls.SetChildIndex(this.txtDate2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.txtDate1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rbCustomerInti, 0);
            this.Controls.SetChildIndex(this.rbMitraSAS, 0);
            this.Controls.SetChildIndex(this.rbMitraPS, 0);
            this.Controls.SetChildIndex(this.rbCalnCI, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.rbRegular, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.DateTextBox txtDate1;
        private ISA.Trading.Controls.DateTextBox txtDate2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbCustomerInti;
        private System.Windows.Forms.RadioButton rbMitraSAS;
        private System.Windows.Forms.RadioButton rbMitraPS;
        private System.Windows.Forms.RadioButton rbCalnCI;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.RadioButton rbRegular;
    }
}
