namespace ISA.Toko.Master
{
    partial class frmAppSettingUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppSettingUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new ISA.Toko.Controls.CommonTextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Toko.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValue = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(153, 32);
            this.txtKey.MaxLength = 50;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(298, 20);
            this.txtKey.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(36, 189);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(382, 189);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Enabled = false;
            this.txtKeterangan.Location = new System.Drawing.Point(153, 59);
            this.txtKeterangan.MaxLength = 200;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(298, 20);
            this.txtKeterangan.TabIndex = 1;
            this.txtKeterangan.TextChanged += new System.EventHandler(this.commonTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue.Location = new System.Drawing.Point(153, 87);
            this.txtValue.MaxLength = 50;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(298, 20);
            this.txtValue.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.txtKeterangan);
            this.groupBox1.Location = new System.Drawing.Point(76, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // frmAppSettingUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 392);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0220";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmAppSettingUpdate";
            this.Text = "SC0220 - App Setting";
            this.Title = "App Setting";
            this.Load += new System.EventHandler(this.frmAppSettingUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAppSettingUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtKey;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox txtValue;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
