namespace ISA.Finance.Kasir
{
    partial class frmRptLapIdenSetorPiutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptLapIdenSetorPiutang));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoTglInden = new System.Windows.Forms.RadioButton();
            this.rdoNoBukti = new System.Windows.Forms.RadioButton();
            this.txtPID = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "IDENTIFIKASI PEMBAYARAN KE NOTA";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "PERIODE";
            this.label2.UseWaitCursor = true;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(195, 84);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 5;
            this.rangeDateBox1.ToDate = null;
            this.rangeDateBox1.UseWaitCursor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(107, 250);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 6;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.UseWaitCursor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(286, 250);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.UseWaitCursor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "DIURUTKAN BERDASARKAN";
            this.label3.UseWaitCursor = true;
            // 
            // rdoTglInden
            // 
            this.rdoTglInden.AutoSize = true;
            this.rdoTglInden.Checked = true;
            this.rdoTglInden.Location = new System.Drawing.Point(195, 174);
            this.rdoTglInden.Name = "rdoTglInden";
            this.rdoTglInden.Size = new System.Drawing.Size(79, 18);
            this.rdoTglInden.TabIndex = 9;
            this.rdoTglInden.TabStop = true;
            this.rdoTglInden.Text = "Tgl. Inden";
            this.rdoTglInden.UseVisualStyleBackColor = true;
            this.rdoTglInden.UseWaitCursor = true;
            // 
            // rdoNoBukti
            // 
            this.rdoNoBukti.AutoSize = true;
            this.rdoNoBukti.Location = new System.Drawing.Point(300, 174);
            this.rdoNoBukti.Name = "rdoNoBukti";
            this.rdoNoBukti.Size = new System.Drawing.Size(73, 18);
            this.rdoNoBukti.TabIndex = 10;
            this.rdoNoBukti.TabStop = true;
            this.rdoNoBukti.Text = "No. Bukti";
            this.rdoNoBukti.UseVisualStyleBackColor = true;
            this.rdoNoBukti.UseWaitCursor = true;
            // 
            // txtPID
            // 
            this.txtPID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPID.Location = new System.Drawing.Point(195, 126);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(40, 20);
            this.txtPID.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "PERUSAHAAN ID";
            // 
            // frmRptLapIdenSetorPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(518, 310);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.rdoNoBukti);
            this.Controls.Add(this.rdoTglInden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdYes);
            this.Name = "frmRptLapIdenSetorPiutang";
            this.Text = "Identifikasi Pembayaran Ke Nota";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmRptLapIdenSetorPiutang_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rdoTglInden, 0);
            this.Controls.SetChildIndex(this.rdoNoBukti, 0);
            this.Controls.SetChildIndex(this.txtPID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoTglInden;
        private System.Windows.Forms.RadioButton rdoNoBukti;
        private ISA.Controls.CommonTextBox txtPID;
        private System.Windows.Forms.Label label4;
    }
}
