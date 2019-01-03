namespace ISA.Trading.Master
{
    partial class frmTargetCollectorUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetCollectorUpdate));
            this.txtNama = new System.Windows.Forms.TextBox();
            this.dTxtTMT = new ISA.Trading.Controls.DateTextBox();
            this.txtKdColl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nTxtTagih = new ISA.Trading.Controls.NumericTextBox();
            this.nTxtKunj = new ISA.Trading.Controls.NumericTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nTxtNominal = new ISA.Trading.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(126, 82);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(116, 20);
            this.txtNama.TabIndex = 1;
            // 
            // dTxtTMT
            // 
            this.dTxtTMT.DateValue = null;
            this.dTxtTMT.Location = new System.Drawing.Point(126, 111);
            this.dTxtTMT.MaxLength = 10;
            this.dTxtTMT.Name = "dTxtTMT";
            this.dTxtTMT.Size = new System.Drawing.Size(116, 20);
            this.dTxtTMT.TabIndex = 5;
            // 
            // txtKdColl
            // 
            this.txtKdColl.Location = new System.Drawing.Point(367, 82);
            this.txtKdColl.Name = "txtKdColl";
            this.txtKdColl.Size = new System.Drawing.Size(116, 20);
            this.txtKdColl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "T.M.T";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kode Collector";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kunjungan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "% Tagih";
            // 
            // nTxtTagih
            // 
            this.nTxtTagih.Location = new System.Drawing.Point(351, 30);
            this.nTxtTagih.Name = "nTxtTagih";
            this.nTxtTagih.Size = new System.Drawing.Size(43, 20);
            this.nTxtTagih.TabIndex = 3;
            this.nTxtTagih.Text = "0";
            // 
            // nTxtKunj
            // 
            this.nTxtKunj.Location = new System.Drawing.Point(109, 27);
            this.nTxtKunj.Name = "nTxtKunj";
            this.nTxtKunj.Size = new System.Drawing.Size(100, 20);
            this.nTxtKunj.TabIndex = 1;
            this.nTxtKunj.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nTxtNominal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nTxtKunj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nTxtTagih);
            this.groupBox1.Location = new System.Drawing.Point(28, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 114);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TARGET HARIAN";
            // 
            // nTxtNominal
            // 
            this.nTxtNominal.Location = new System.Drawing.Point(109, 67);
            this.nTxtNominal.Name = "nTxtNominal";
            this.nTxtNominal.Size = new System.Drawing.Size(100, 20);
            this.nTxtNominal.TabIndex = 5;
            this.nTxtNominal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "N o m i n a l ";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(28, 298);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(151, 298);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmTargetCollectorUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 369);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.dTxtTMT);
            this.Controls.Add(this.txtKdColl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetCollectorUpdate";
            this.Text = "Target Collector";
            this.Title = "Target Collector";
            this.Load += new System.EventHandler(this.frmTargetCollectorUpdate_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTargetCollectorUpdate_FormClosing);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKdColl, 0);
            this.Controls.SetChildIndex(this.dTxtTMT, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private ISA.Trading.Controls.DateTextBox dTxtTMT;
        private System.Windows.Forms.TextBox txtKdColl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.NumericTextBox nTxtTagih;
        private ISA.Trading.Controls.NumericTextBox nTxtKunj;
        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Trading.Controls.NumericTextBox nTxtNominal;
        private System.Windows.Forms.Label label6;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}