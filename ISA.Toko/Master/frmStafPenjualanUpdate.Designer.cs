namespace ISA.Toko.Master
{
    partial class frmStafPenjualanUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStafPenjualanUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Toko.Controls.CommonTextBox();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtKeterangan = new ISA.Toko.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Kode = new System.Windows.Forms.Label();
            this.TxtKode = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbUnitKerja = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBPasif = new System.Windows.Forms.RadioButton();
            this.RBAktif = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(105, 30);
            this.txtNama.MaxLength = 100;
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
            this.cmdSave.Location = new System.Drawing.Point(105, 186);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 5;
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
            this.cmdClose.Location = new System.Drawing.Point(226, 186);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Keterangan";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TxtKeterangan
            // 
            this.TxtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtKeterangan.Location = new System.Drawing.Point(105, 114);
            this.TxtKeterangan.MaxLength = 250;
            this.TxtKeterangan.Name = "TxtKeterangan";
            this.TxtKeterangan.Size = new System.Drawing.Size(478, 20);
            this.TxtKeterangan.TabIndex = 2;
            this.TxtKeterangan.TextChanged += new System.EventHandler(this.TxtKeterangan_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Unit Kerja";
            // 
            // Kode
            // 
            this.Kode.AutoSize = true;
            this.Kode.Location = new System.Drawing.Point(393, 33);
            this.Kode.Name = "Kode";
            this.Kode.Size = new System.Drawing.Size(35, 14);
            this.Kode.TabIndex = 13;
            this.Kode.Text = "Kode";
            this.Kode.Visible = false;
            this.Kode.Click += new System.EventHandler(this.Kode_Click);
            // 
            // TxtKode
            // 
            this.TxtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtKode.Enabled = false;
            this.TxtKode.Location = new System.Drawing.Point(447, 30);
            this.TxtKode.MaxLength = 10;
            this.TxtKode.Name = "TxtKode";
            this.TxtKode.Size = new System.Drawing.Size(136, 20);
            this.TxtKode.TabIndex = 12;
            this.TxtKode.Visible = false;
            this.TxtKode.TextChanged += new System.EventHandler(this.TxtKode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.CbUnitKerja);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Controls.Add(this.Kode);
            this.groupBox1.Controls.Add(this.TxtKeterangan);
            this.groupBox1.Controls.Add(this.TxtKode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(31, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CbUnitKerja
            // 
            this.CbUnitKerja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbUnitKerja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbUnitKerja.FormattingEnabled = true;
            this.CbUnitKerja.Location = new System.Drawing.Point(105, 70);
            this.CbUnitKerja.Name = "CbUnitKerja";
            this.CbUnitKerja.Size = new System.Drawing.Size(237, 22);
            this.CbUnitKerja.TabIndex = 1;
            this.CbUnitKerja.SelectedIndexChanged += new System.EventHandler(this.CbUnitKerja_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBPasif);
            this.groupBox3.Controls.Add(this.RBAktif);
            this.groupBox3.Location = new System.Drawing.Point(105, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 26);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // RBPasif
            // 
            this.RBPasif.AutoSize = true;
            this.RBPasif.Location = new System.Drawing.Point(119, 7);
            this.RBPasif.Name = "RBPasif";
            this.RBPasif.Size = new System.Drawing.Size(55, 18);
            this.RBPasif.TabIndex = 4;
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
            this.RBAktif.TabIndex = 3;
            this.RBAktif.TabStop = true;
            this.RBAktif.Text = "AKTIF";
            this.RBAktif.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 14);
            this.label8.TabIndex = 32;
            this.label8.Text = "Status Aktif";
            // 
            // frmStafPenjualanUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(667, 347);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0223";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStafPenjualanUpdate";
            this.Text = "SC0223 - Staf ADM dan Operasional";
            this.Title = "Staf ADM dan Operasional";
            this.Load += new System.EventHandler(this.frmStafPenjualanUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStafPenjualanUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommonTextBox txtNama;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox TxtKeterangan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Kode;
        private ISA.Toko.Controls.CommonTextBox TxtKode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RBPasif;
        private System.Windows.Forms.RadioButton RBAktif;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CbUnitKerja;
    }
}
