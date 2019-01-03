namespace ISA.Finance.GL
{
    partial class frmJournalDetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalDetailUpdate));
            this.lookupPerkiraan1 = new ISA.Finance.Controls.LookupPerkiraan();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDebet = new ISA.Controls.NumericTextBox();
            this.txtKredit = new ISA.Controls.NumericTextBox();
            this.cmdOk = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // lookupPerkiraan1
            // 
            this.lookupPerkiraan1.Location = new System.Drawing.Point(135, 24);
            this.lookupPerkiraan1.Margin = new System.Windows.Forms.Padding(0);
            this.lookupPerkiraan1.NamaPerkiraan = "";
            this.lookupPerkiraan1.Name = "lookupPerkiraan1";
            this.lookupPerkiraan1.NoPerkiraan = "[CODE]";
            this.lookupPerkiraan1.Size = new System.Drawing.Size(269, 47);
            this.lookupPerkiraan1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Perkiraan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Uraian";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(135, 80);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(440, 20);
            this.txtUraian.TabIndex = 1;
            this.txtUraian.Enter += new System.EventHandler(this.txtUraian_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Debet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kredit";
            // 
            // txtDebet
            // 
            this.txtDebet.Location = new System.Drawing.Point(177, 118);
            this.txtDebet.Name = "txtDebet";
            this.txtDebet.Size = new System.Drawing.Size(125, 20);
            this.txtDebet.TabIndex = 2;
            this.txtDebet.Text = "0";
            this.txtDebet.TextChanged += new System.EventHandler(this.txtDebet_TextChanged);
            // 
            // txtKredit
            // 
            this.txtKredit.Location = new System.Drawing.Point(371, 118);
            this.txtKredit.Name = "txtKredit";
            this.txtKredit.Size = new System.Drawing.Size(125, 20);
            this.txtKredit.TabIndex = 3;
            this.txtKredit.Text = "0";
            this.txtKredit.TextChanged += new System.EventHandler(this.txtKredit_TextChanged);
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(351, 227);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "YES";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(474, 227);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmJournalDetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(586, 279);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupPerkiraan1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtKredit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDebet);
            this.Name = "frmJournalDetailUpdate";
            this.Text = "Journal Detail";
            this.Load += new System.EventHandler(this.frmJournalDetailUpdate_Load);
            this.Controls.SetChildIndex(this.txtDebet, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtKredit, 0);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lookupPerkiraan1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Finance.Controls.LookupPerkiraan lookupPerkiraan1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.NumericTextBox txtDebet;
        private ISA.Controls.NumericTextBox txtKredit;
        private ISA.Controls.CommandButton cmdOk;
        private ISA.Controls.CommandButton cmdClose;
    }
}
