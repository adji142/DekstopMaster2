namespace ISA.Trading.Pembelian
{
    partial class frmMPRBeliUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMPRBeliUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.cboPemasok = new System.Windows.Forms.ComboBox();
            this.txtNoMPR = new ISA.Trading.Controls.CommonTextBox();
            this.txtTglKeluar = new ISA.Trading.Controls.DateTextBox();
            this.txtTglKirim = new ISA.Trading.Controls.DateTextBox();
            this.txtPengirim = new ISA.Trading.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTglKirim2 = new ISA.Trading.Controls.DateTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPenerima = new ISA.Trading.Controls.CommonTextBox();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama Pemasok";
            // 
            // cboPemasok
            // 
            this.cboPemasok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPemasok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPemasok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPemasok.FormattingEnabled = true;
            this.cboPemasok.Location = new System.Drawing.Point(181, 66);
            this.cboPemasok.Name = "cboPemasok";
            this.cboPemasok.Size = new System.Drawing.Size(140, 22);
            this.cboPemasok.TabIndex = 0;
            // 
            // txtNoMPR
            // 
            this.txtNoMPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMPR.Enabled = false;
            this.txtNoMPR.Location = new System.Drawing.Point(181, 94);
            this.txtNoMPR.MaxLength = 7;
            this.txtNoMPR.Name = "txtNoMPR";
            this.txtNoMPR.ReadOnly = true;
            this.txtNoMPR.Size = new System.Drawing.Size(60, 20);
            this.txtNoMPR.TabIndex = 1;
            this.txtNoMPR.TabStop = false;
            // 
            // txtTglKeluar
            // 
            this.txtTglKeluar.DateValue = null;
            this.txtTglKeluar.Location = new System.Drawing.Point(181, 120);
            this.txtTglKeluar.MaxLength = 10;
            this.txtTglKeluar.Name = "txtTglKeluar";
            this.txtTglKeluar.Size = new System.Drawing.Size(80, 20);
            this.txtTglKeluar.TabIndex = 2;
            // 
            // txtTglKirim
            // 
            this.txtTglKirim.DateValue = null;
            this.txtTglKirim.Location = new System.Drawing.Point(181, 146);
            this.txtTglKirim.MaxLength = 10;
            this.txtTglKirim.Name = "txtTglKirim";
            this.txtTglKirim.Size = new System.Drawing.Size(80, 20);
            this.txtTglKirim.TabIndex = 3;
            // 
            // txtPengirim
            // 
            this.txtPengirim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPengirim.Location = new System.Drawing.Point(181, 172);
            this.txtPengirim.Name = "txtPengirim";
            this.txtPengirim.Size = new System.Drawing.Size(150, 20);
            this.txtPengirim.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nomor Memo Retur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tgl. Memo Retur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tgl. Kirim ke 11";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nama Pengirim SAS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(490, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "---------------------------------------------------------------------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Isian Untuk Cross Check Div.Penjualan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "Telah diperiksa Tgl.";
            // 
            // txtTglKirim2
            // 
            this.txtTglKirim2.DateValue = null;
            this.txtTglKirim2.Enabled = false;
            this.txtTglKirim2.Location = new System.Drawing.Point(181, 242);
            this.txtTglKirim2.MaxLength = 10;
            this.txtTglKirim2.Name = "txtTglKirim2";
            this.txtTglKirim2.ReadOnly = true;
            this.txtTglKirim2.Size = new System.Drawing.Size(80, 20);
            this.txtTglKirim2.TabIndex = 5;
            this.txtTglKirim2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Oleh";
            // 
            // txtPenerima
            // 
            this.txtPenerima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPenerima.Enabled = false;
            this.txtPenerima.Location = new System.Drawing.Point(344, 242);
            this.txtPenerima.Name = "txtPenerima";
            this.txtPenerima.ReadOnly = true;
            this.txtPenerima.Size = new System.Drawing.Size(150, 20);
            this.txtPenerima.TabIndex = 6;
            this.txtPenerima.TabStop = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(286, 289);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 8;
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
            this.cmdSAVE.Location = new System.Drawing.Point(161, 289);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 7;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMPRBeliUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(549, 348);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPenerima);
            this.Controls.Add(this.txtTglKirim2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPengirim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPemasok);
            this.Controls.Add(this.txtNoMPR);
            this.Controls.Add(this.txtTglKirim);
            this.Controls.Add(this.txtTglKeluar);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 375);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 375);
            this.Name = "frmMPRBeliUpdate";
            this.Text = "MPR";
            this.Title = "MPR";
            this.Load += new System.EventHandler(this.frmMPRBeliUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMPRBeliUpdate_FormClosed);
            this.Controls.SetChildIndex(this.txtTglKeluar, 0);
            this.Controls.SetChildIndex(this.txtTglKirim, 0);
            this.Controls.SetChildIndex(this.txtNoMPR, 0);
            this.Controls.SetChildIndex(this.cboPemasok, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtPengirim, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTglKirim2, 0);
            this.Controls.SetChildIndex(this.txtPenerima, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPemasok;
        private ISA.Trading.Controls.CommonTextBox txtNoMPR;
        private ISA.Trading.Controls.DateTextBox txtTglKeluar;
        private ISA.Trading.Controls.DateTextBox txtTglKirim;
        private ISA.Trading.Controls.CommonTextBox txtPengirim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ISA.Trading.Controls.DateTextBox txtTglKirim2;
        private System.Windows.Forms.Label label9;
        private ISA.Trading.Controls.CommonTextBox txtPenerima;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
