namespace ISA.Toko.Master
{
    partial class frmHPPUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPPUpdate));
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdiskon = new ISA.Toko.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtnetto = new ISA.Toko.Controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Toko.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSatuan = new ISA.Toko.Controls.CommonTextBox();
            this.txttglBerlaku = new ISA.Toko.Controls.DateTextBox();
            this.txtHargaHpp = new ISA.Toko.Controls.NumericTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Harga Beli";
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
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal Berlaku";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtdiskon);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtnetto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtKeterangan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSatuan);
            this.groupBox1.Controls.Add(this.txttglBerlaku);
            this.groupBox1.Controls.Add(this.txtHargaHpp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Location = new System.Drawing.Point(100, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(470, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "%";
            // 
            // txtdiskon
            // 
            this.txtdiskon.Location = new System.Drawing.Point(430, 79);
            this.txtdiskon.Name = "txtdiskon";
            this.txtdiskon.Size = new System.Drawing.Size(36, 20);
            this.txtdiskon.TabIndex = 2;
            this.txtdiskon.Text = "0";
            this.txtdiskon.TextChanged += new System.EventHandler(this.txtdiskon_TextChanged);
            this.txtdiskon.Validated += new System.EventHandler(this.txtdiskon_Validated);
            this.txtdiskon.Leave += new System.EventHandler(this.txtdiskon_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "Diskon";
            // 
            // txtnetto
            // 
            this.txtnetto.Location = new System.Drawing.Point(152, 118);
            this.txtnetto.Name = "txtnetto";
            this.txtnetto.ReadOnly = true;
            this.txtnetto.Size = new System.Drawing.Size(200, 20);
            this.txtnetto.TabIndex = 3;
            this.txtnetto.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Harga Bersih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(153, 158);
            this.txtKeterangan.MaxLength = 150;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(329, 20);
            this.txtKeterangan.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "Satuan";
            this.label2.Visible = false;
            // 
            // txtSatuan
            // 
            this.txtSatuan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan.Location = new System.Drawing.Point(299, 230);
            this.txtSatuan.MaxLength = 3;
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.Size = new System.Drawing.Size(54, 20);
            this.txtSatuan.TabIndex = 2;
            this.txtSatuan.Visible = false;
            // 
            // txttglBerlaku
            // 
            this.txttglBerlaku.DateValue = null;
            this.txttglBerlaku.Enabled = false;
            this.txttglBerlaku.Location = new System.Drawing.Point(153, 38);
            this.txttglBerlaku.MaxLength = 10;
            this.txttglBerlaku.Name = "txttglBerlaku";
            this.txttglBerlaku.Size = new System.Drawing.Size(200, 20);
            this.txttglBerlaku.TabIndex = 0;
            // 
            // txtHargaHpp
            // 
            this.txtHargaHpp.Location = new System.Drawing.Point(153, 79);
            this.txtHargaHpp.Name = "txtHargaHpp";
            this.txtHargaHpp.Size = new System.Drawing.Size(200, 20);
            this.txtHargaHpp.TabIndex = 1;
            this.txtHargaHpp.Text = "0";
            // 
            // frmHPPUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(759, 392);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC0220";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHPPUpdate";
            this.Text = "SC0220 - HPP";
            this.Title = "HPP";
            this.Load += new System.EventHandler(this.frmHPPUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHPPUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Toko.Controls.NumericTextBox txtHargaHpp;
        private ISA.Toko.Controls.DateTextBox txttglBerlaku;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtSatuan;
        private System.Windows.Forms.Label label4;
        private ISA.Toko.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.NumericTextBox txtdiskon;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.NumericTextBox txtnetto;
        private System.Windows.Forms.Label label5;


    }
}
