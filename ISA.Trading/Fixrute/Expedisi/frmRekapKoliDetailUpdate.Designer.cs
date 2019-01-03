namespace ISA.Trading.Expedisi
{
    partial class frmRekapKoliDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRekapKoliDetailUpdate));
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoDO = new ISA.Trading.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSales = new ISA.Trading.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTunaiKredit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNominal = new ISA.Trading.Controls.NumericTextBox();
            this.txtKeterangan = new ISA.Trading.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoResi = new ISA.Trading.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNoNota = new ISA.Trading.Controls.CommonTextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nomor DO";
            // 
            // txtNoDO
            // 
            this.txtNoDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoDO.Location = new System.Drawing.Point(134, 66);
            this.txtNoDO.MaxLength = 7;
            this.txtNoDO.Name = "txtNoDO";
            this.txtNoDO.Size = new System.Drawing.Size(93, 20);
            this.txtNoDO.TabIndex = 0;
            this.txtNoDO.TabStop = false;
            this.txtNoDO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDO_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nomor Nota";
            // 
            // txtSales
            // 
            this.txtSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSales.Enabled = false;
            this.txtSales.Location = new System.Drawing.Point(134, 122);
            this.txtSales.MaxLength = 7;
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(128, 20);
            this.txtSales.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sales";
            // 
            // cboTunaiKredit
            // 
            this.cboTunaiKredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTunaiKredit.FormattingEnabled = true;
            this.cboTunaiKredit.Items.AddRange(new object[] {
            "T",
            "K"});
            this.cboTunaiKredit.Location = new System.Drawing.Point(134, 150);
            this.cboTunaiKredit.Name = "cboTunaiKredit";
            this.cboTunaiKredit.Size = new System.Drawing.Size(61, 22);
            this.cboTunaiKredit.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Tunai / Kredit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nominal";
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(134, 179);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(93, 20);
            this.txtNominal.TabIndex = 5;
            this.txtNominal.Text = "0";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(134, 207);
            this.txtKeterangan.MaxLength = 30;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(252, 20);
            this.txtKeterangan.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Keterangan";
            // 
            // txtNoResi
            // 
            this.txtNoResi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoResi.Location = new System.Drawing.Point(134, 235);
            this.txtNoResi.MaxLength = 15;
            this.txtNoResi.Name = "txtNoResi";
            this.txtNoResi.Size = new System.Drawing.Size(93, 20);
            this.txtNoResi.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Nomor Resi";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(271, 272);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 9;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(134, 272);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 8;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtNoNota
            // 
            this.txtNoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoNota.Enabled = false;
            this.txtNoNota.Location = new System.Drawing.Point(134, 94);
            this.txtNoNota.MaxLength = 7;
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.Size = new System.Drawing.Size(93, 20);
            this.txtNoNota.TabIndex = 2;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = global::ISA.Trading.Properties.Resources.Search16;
            this.cmdSearch.Location = new System.Drawing.Point(234, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(29, 25);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmRekapKoliDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(423, 350);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNoNota);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtNoResi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNominal);
            this.Controls.Add(this.cboTunaiKredit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoDO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRekapKoliDetailUpdate";
            this.Text = "Rekap Koli Detail";
            this.Title = "Rekap Koli Detail";
            this.Load += new System.EventHandler(this.frmRekapKoliDetailUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRekapKoliDetailUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNoDO, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSales, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboTunaiKredit, 0);
            this.Controls.SetChildIndex(this.txtNominal, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNoResi, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtNoNota, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtNoDO;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtSales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTunaiKredit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.NumericTextBox txtNominal;
        private ISA.Trading.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.CommonTextBox txtNoResi;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Trading.Controls.CommonTextBox txtNoNota;
        private System.Windows.Forms.Button cmdSearch;
    }
}
