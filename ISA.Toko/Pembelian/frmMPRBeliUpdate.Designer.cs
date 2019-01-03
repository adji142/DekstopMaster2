namespace ISA.Toko.Pembelian
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
            this.txtNoMPR = new ISA.Toko.Controls.CommonTextBox();
            this.txtTglKeluar = new ISA.Toko.Controls.DateTextBox();
            this.txtTglKirim = new ISA.Toko.Controls.DateTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTglKirim2 = new ISA.Toko.Controls.DateTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPenerima = new ISA.Toko.Controls.CommonTextBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPengirim = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Supplier";
            // 
            // cboPemasok
            // 
            this.cboPemasok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPemasok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPemasok.FormattingEnabled = true;
            this.cboPemasok.Location = new System.Drawing.Point(171, 13);
            this.cboPemasok.Name = "cboPemasok";
            this.cboPemasok.Size = new System.Drawing.Size(205, 22);
            this.cboPemasok.TabIndex = 0;
            this.cboPemasok.SelectedIndexChanged += new System.EventHandler(this.cboPemasok_SelectedIndexChanged_2);
            // 
            // txtNoMPR
            // 
            this.txtNoMPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMPR.Enabled = false;
            this.txtNoMPR.Location = new System.Drawing.Point(171, 41);
            this.txtNoMPR.MaxLength = 7;
            this.txtNoMPR.Name = "txtNoMPR";
            this.txtNoMPR.ReadOnly = true;
            this.txtNoMPR.Size = new System.Drawing.Size(60, 20);
            this.txtNoMPR.TabIndex = 1;
            this.txtNoMPR.TabStop = false;
            this.txtNoMPR.Visible = false;
            // 
            // txtTglKeluar
            // 
            this.txtTglKeluar.DateValue = null;
            this.txtTglKeluar.Enabled = false;
            this.txtTglKeluar.Location = new System.Drawing.Point(171, 67);
            this.txtTglKeluar.MaxLength = 10;
            this.txtTglKeluar.Name = "txtTglKeluar";
            this.txtTglKeluar.Size = new System.Drawing.Size(80, 20);
            this.txtTglKeluar.TabIndex = 2;
            // 
            // txtTglKirim
            // 
            this.txtTglKirim.DateValue = null;
            this.txtTglKirim.Location = new System.Drawing.Point(171, 93);
            this.txtTglKirim.MaxLength = 10;
            this.txtTglKirim.Name = "txtTglKirim";
            this.txtTglKirim.Size = new System.Drawing.Size(80, 20);
            this.txtTglKirim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "No. Nota Ret. Beli";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tgl. MPRB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tgl. Kirim ke Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Pengirim";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "---------------------------------------------------------------------";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Isian untuk cross check......";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "Telah diperiksa Tgl.";
            this.label8.Visible = false;
            // 
            // txtTglKirim2
            // 
            this.txtTglKirim2.DateValue = null;
            this.txtTglKirim2.Enabled = false;
            this.txtTglKirim2.Location = new System.Drawing.Point(171, 189);
            this.txtTglKirim2.MaxLength = 10;
            this.txtTglKirim2.Name = "txtTglKirim2";
            this.txtTglKirim2.ReadOnly = true;
            this.txtTglKirim2.Size = new System.Drawing.Size(80, 20);
            this.txtTglKirim2.TabIndex = 5;
            this.txtTglKirim2.TabStop = false;
            this.txtTglKirim2.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Oleh";
            this.label9.Visible = false;
            // 
            // txtPenerima
            // 
            this.txtPenerima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPenerima.Enabled = false;
            this.txtPenerima.Location = new System.Drawing.Point(334, 189);
            this.txtPenerima.Name = "txtPenerima";
            this.txtPenerima.ReadOnly = true;
            this.txtPenerima.Size = new System.Drawing.Size(150, 20);
            this.txtPenerima.TabIndex = 6;
            this.txtPenerima.TabStop = false;
            this.txtPenerima.Visible = false;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(276, 236);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 6;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(151, 236);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 5;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cboPengirim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdCLOSE);
            this.groupBox1.Controls.Add(this.txtTglKeluar);
            this.groupBox1.Controls.Add(this.cmdSAVE);
            this.groupBox1.Controls.Add(this.txtTglKirim);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNoMPR);
            this.groupBox1.Controls.Add(this.txtPenerima);
            this.groupBox1.Controls.Add(this.cboPemasok);
            this.groupBox1.Controls.Add(this.txtTglKirim2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(31, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 291);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // cboPengirim
            // 
            this.cboPengirim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPengirim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPengirim.FormattingEnabled = true;
            this.cboPengirim.Location = new System.Drawing.Point(171, 122);
            this.cboPengirim.Name = "cboPengirim";
            this.cboPengirim.Size = new System.Drawing.Size(205, 22);
            this.cboPengirim.TabIndex = 4;
            // 
            // frmMPRBeliUpdate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(589, 345);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMPRBeliUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MPRB";
            this.Title = "MPRB";
            this.Load += new System.EventHandler(this.frmMPRBeliUpdate_Load);
            this.Shown += new System.EventHandler(this.frmMPRBeliUpdate_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMPRBeliUpdate_FormClosed);
            this.MouseHover += new System.EventHandler(this.frmMPRBeliUpdate_MouseHover);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPemasok;
        private ISA.Toko.Controls.CommonTextBox txtNoMPR;
        private ISA.Toko.Controls.DateTextBox txtTglKeluar;
        private ISA.Toko.Controls.DateTextBox txtTglKirim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ISA.Toko.Controls.DateTextBox txtTglKirim2;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.CommonTextBox txtPenerima;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPengirim;
    }
}
