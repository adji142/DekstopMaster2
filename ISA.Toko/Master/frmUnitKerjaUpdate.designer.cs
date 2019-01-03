namespace ISA.Toko.Master
{
    partial class frmUnitKerjaUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnitKerjaUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Toko.Controls.CommonTextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.txtketerangan = new ISA.Toko.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKode = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBPasif = new System.Windows.Forms.RadioButton();
            this.RBAktif = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(97, 58);
            this.txtNama.MaxLength = 30;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(237, 20);
            this.txtNama.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(97, 172);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 2;
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
            this.cmdClose.Location = new System.Drawing.Point(218, 172);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtketerangan
            // 
            this.txtketerangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtketerangan.Location = new System.Drawing.Point(97, 94);
            this.txtketerangan.MaxLength = 250;
            this.txtketerangan.Name = "txtketerangan";
            this.txtketerangan.Size = new System.Drawing.Size(237, 20);
            this.txtketerangan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Keterangan";
            // 
            // txtKode
            // 
            this.txtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKode.Enabled = false;
            this.txtKode.Location = new System.Drawing.Point(97, 16);
            this.txtKode.MaxLength = 10;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(116, 20);
            this.txtKode.TabIndex = 8;
            this.txtKode.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kode";
            this.label3.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBPasif);
            this.groupBox3.Controls.Add(this.RBAktif);
            this.groupBox3.Location = new System.Drawing.Point(97, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 26);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            // 
            // RBPasif
            // 
            this.RBPasif.AutoSize = true;
            this.RBPasif.Location = new System.Drawing.Point(119, 7);
            this.RBPasif.Name = "RBPasif";
            this.RBPasif.Size = new System.Drawing.Size(55, 18);
            this.RBPasif.TabIndex = 13;
            this.RBPasif.Text = "PASIF";
            this.RBPasif.UseVisualStyleBackColor = true;
            // 
            // RBAktif
            // 
            this.RBAktif.AutoSize = true;
            this.RBAktif.Checked = true;
            this.RBAktif.Location = new System.Drawing.Point(6, 7);
            this.RBAktif.Name = "RBAktif";
            this.RBAktif.Size = new System.Drawing.Size(56, 18);
            this.RBAktif.TabIndex = 12;
            this.RBAktif.TabStop = true;
            this.RBAktif.Text = "AKTIF";
            this.RBAktif.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 14);
            this.label13.TabIndex = 45;
            this.label13.Text = "Status Aktif";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Controls.Add(this.txtKode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtketerangan);
            this.groupBox1.Location = new System.Drawing.Point(157, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 233);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // frmUnitKerjaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 354);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0223";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUnitKerjaUpdate";
            this.Text = "SC0223 - Unit Kerja";
            this.Title = "Unit Kerja";
            this.Load += new System.EventHandler(this.frmUnitKerjaUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUnitKerjaUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtNama;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommonTextBox txtketerangan;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtKode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RBPasif;
        private System.Windows.Forms.RadioButton RBAktif;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
