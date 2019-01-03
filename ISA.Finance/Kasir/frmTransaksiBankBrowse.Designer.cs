namespace ISA.Finance.Kasir
{
    partial class frmTransaksiBankBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaksiBankBrowse));
            this.dgTransaksiBank = new ISA.Controls.CustomGridView();
            this.kd_trs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nm_trs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbcr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_perk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ke_ket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKd_Trs = new ISA.Controls.CommonTextBox();
            this.tbNoPerk = new ISA.Controls.CommonTextBox();
            this.tbNama = new ISA.Controls.CommonTextBox();
            this.tbKet = new ISA.Controls.CommonTextBox();
            this.rbDebet = new System.Windows.Forms.CheckBox();
            this.rbKredit = new System.Windows.Forms.CheckBox();
            this.rbChbg = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksiBank)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTransaksiBank
            // 
            this.dgTransaksiBank.AllowUserToAddRows = false;
            this.dgTransaksiBank.AllowUserToDeleteRows = false;
            this.dgTransaksiBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransaksiBank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kd_trs,
            this.nm_trs,
            this.dbcr,
            this.bgch,
            this.no_perk,
            this.ke_ket,
            this.kode,
            this.sub});
            this.dgTransaksiBank.Location = new System.Drawing.Point(6, 19);
            this.dgTransaksiBank.MultiSelect = false;
            this.dgTransaksiBank.Name = "dgTransaksiBank";
            this.dgTransaksiBank.ReadOnly = true;
            this.dgTransaksiBank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgTransaksiBank.Size = new System.Drawing.Size(668, 246);
            this.dgTransaksiBank.StandardTab = true;
            this.dgTransaksiBank.TabIndex = 4;
            this.dgTransaksiBank.SelectionChanged += new System.EventHandler(this.dgTransaksiBank_SelectionChanged);
            // 
            // kd_trs
            // 
            this.kd_trs.DataPropertyName = "kd_trs";
            this.kd_trs.HeaderText = "Trs";
            this.kd_trs.Name = "kd_trs";
            this.kd_trs.ReadOnly = true;
            this.kd_trs.Width = 70;
            // 
            // nm_trs
            // 
            this.nm_trs.DataPropertyName = "nm_trs";
            this.nm_trs.HeaderText = "Nama Transaksi";
            this.nm_trs.Name = "nm_trs";
            this.nm_trs.ReadOnly = true;
            this.nm_trs.Width = 150;
            // 
            // dbcr
            // 
            this.dbcr.DataPropertyName = "dbcr";
            this.dbcr.HeaderText = "D/K";
            this.dbcr.Name = "dbcr";
            this.dbcr.ReadOnly = true;
            this.dbcr.Width = 50;
            // 
            // bgch
            // 
            this.bgch.DataPropertyName = "bgch";
            this.bgch.HeaderText = "BgCh";
            this.bgch.Name = "bgch";
            this.bgch.ReadOnly = true;
            this.bgch.Width = 50;
            // 
            // no_perk
            // 
            this.no_perk.DataPropertyName = "no_perk";
            this.no_perk.HeaderText = "No_perk";
            this.no_perk.Name = "no_perk";
            this.no_perk.ReadOnly = true;
            // 
            // ke_ket
            // 
            this.ke_ket.DataPropertyName = "ke_ket";
            this.ke_ket.HeaderText = "Keterangan";
            this.ke_ket.Name = "ke_ket";
            this.ke_ket.ReadOnly = true;
            this.ke_ket.Width = 200;
            // 
            // kode
            // 
            this.kode.DataPropertyName = "kd";
            this.kode.HeaderText = "kode";
            this.kode.Name = "kode";
            this.kode.ReadOnly = true;
            this.kode.Visible = false;
            // 
            // sub
            // 
            this.sub.DataPropertyName = "sub";
            this.sub.HeaderText = "sub";
            this.sub.Name = "sub";
            this.sub.ReadOnly = true;
            this.sub.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgTransaksiBank);
            this.groupBox1.Location = new System.Drawing.Point(28, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 279);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdCancel);
            this.groupBox2.Controls.Add(this.cmdSave);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.rbChbg);
            this.groupBox2.Controls.Add(this.rbKredit);
            this.groupBox2.Controls.Add(this.rbDebet);
            this.groupBox2.Controls.Add(this.tbKet);
            this.groupBox2.Controls.Add(this.tbNama);
            this.groupBox2.Controls.Add(this.tbNoPerk);
            this.groupBox2.Controls.Add(this.tbKd_Trs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(28, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 227);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Debet & Kredit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nomor Perkiraan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keterangan";
            // 
            // tbKd_Trs
            // 
            this.tbKd_Trs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKd_Trs.Enabled = false;
            this.tbKd_Trs.Location = new System.Drawing.Point(128, 17);
            this.tbKd_Trs.Name = "tbKd_Trs";
            this.tbKd_Trs.Size = new System.Drawing.Size(100, 20);
            this.tbKd_Trs.TabIndex = 5;
            // 
            // tbNoPerk
            // 
            this.tbNoPerk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoPerk.Location = new System.Drawing.Point(128, 96);
            this.tbNoPerk.Name = "tbNoPerk";
            this.tbNoPerk.Size = new System.Drawing.Size(175, 20);
            this.tbNoPerk.TabIndex = 6;
            // 
            // tbNama
            // 
            this.tbNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNama.Enabled = false;
            this.tbNama.Location = new System.Drawing.Point(364, 17);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(232, 20);
            this.tbNama.TabIndex = 7;
            // 
            // tbKet
            // 
            this.tbKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKet.Location = new System.Drawing.Point(128, 135);
            this.tbKet.Name = "tbKet";
            this.tbKet.Size = new System.Drawing.Size(468, 20);
            this.tbKet.TabIndex = 8;
            // 
            // rbDebet
            // 
            this.rbDebet.AutoSize = true;
            this.rbDebet.Enabled = false;
            this.rbDebet.Location = new System.Drawing.Point(128, 59);
            this.rbDebet.Name = "rbDebet";
            this.rbDebet.Size = new System.Drawing.Size(58, 18);
            this.rbDebet.TabIndex = 9;
            this.rbDebet.Text = "Debet";
            this.rbDebet.UseVisualStyleBackColor = true;
            // 
            // rbKredit
            // 
            this.rbKredit.AutoSize = true;
            this.rbKredit.Enabled = false;
            this.rbKredit.Location = new System.Drawing.Point(244, 59);
            this.rbKredit.Name = "rbKredit";
            this.rbKredit.Size = new System.Drawing.Size(59, 18);
            this.rbKredit.TabIndex = 10;
            this.rbKredit.Text = "Kredit";
            this.rbKredit.UseVisualStyleBackColor = true;
            // 
            // rbChbg
            // 
            this.rbChbg.AutoSize = true;
            this.rbChbg.Enabled = false;
            this.rbChbg.Location = new System.Drawing.Point(540, 58);
            this.rbChbg.Name = "rbChbg";
            this.rbChbg.Size = new System.Drawing.Size(56, 18);
            this.rbChbg.TabIndex = 11;
            this.rbChbg.Text = "CHBG";
            this.rbChbg.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(309, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Jika Kosong Akan Dianggap Transaksi Ke/Dari Bank";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(203, 171);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(312, 171);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdClose);
            this.groupBox3.Controls.Add(this.cmdEdit);
            this.groupBox3.Location = new System.Drawing.Point(259, 555);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 65);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(115, 19);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 16;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(6, 19);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 15;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // frmTransaksiBankBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(752, 631);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTransaksiBankBrowse";
            this.Text = "Tabel Transaksi Bank";
            this.Load += new System.EventHandler(this.frmTransaksiBankBrowse_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksiBank)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgTransaksiBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_trs;
        private System.Windows.Forms.DataGridViewTextBoxColumn nm_trs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbcr;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgch;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_perk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ke_ket;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox rbChbg;
        private System.Windows.Forms.CheckBox rbKredit;
        private System.Windows.Forms.CheckBox rbDebet;
        private ISA.Controls.CommonTextBox tbKet;
        private ISA.Controls.CommonTextBox tbNama;
        private ISA.Controls.CommonTextBox tbNoPerk;
        private ISA.Controls.CommonTextBox tbKd_Trs;
        private ISA.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdEdit;
    }
}
