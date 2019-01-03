namespace ISA.Finance.Kasir
{
    partial class frmRptSaldoGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSaldoGiro));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbPeriode = new ISA.Controls.DateTextBox();
            this.rdoBGD = new System.Windows.Forms.RadioButton();
            this.rdoBGT = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.txtPID = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "SALDO GIRO (BGD DAN BGT)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "PERIODE";
            // 
            // dbPeriode
            // 
            this.dbPeriode.DateValue = null;
            this.dbPeriode.Location = new System.Drawing.Point(138, 100);
            this.dbPeriode.MaxLength = 10;
            this.dbPeriode.Name = "dbPeriode";
            this.dbPeriode.Size = new System.Drawing.Size(101, 20);
            this.dbPeriode.TabIndex = 5;
            // 
            // rdoBGD
            // 
            this.rdoBGD.AutoSize = true;
            this.rdoBGD.Location = new System.Drawing.Point(138, 138);
            this.rdoBGD.Name = "rdoBGD";
            this.rdoBGD.Size = new System.Drawing.Size(47, 18);
            this.rdoBGD.TabIndex = 6;
            this.rdoBGD.TabStop = true;
            this.rdoBGD.Text = "BGD";
            this.rdoBGD.UseVisualStyleBackColor = true;
            // 
            // rdoBGT
            // 
            this.rdoBGT.AutoSize = true;
            this.rdoBGT.Location = new System.Drawing.Point(205, 140);
            this.rdoBGT.Name = "rdoBGT";
            this.rdoBGT.Size = new System.Drawing.Size(47, 18);
            this.rdoBGT.TabIndex = 7;
            this.rdoBGT.TabStop = true;
            this.rdoBGT.Text = "BGT";
            this.rdoBGT.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "BGD/BGT";
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(58, 233);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 9;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(220, 233);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtPID
            // 
            this.txtPID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPID.Location = new System.Drawing.Point(138, 175);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(40, 20);
            this.txtPID.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "PERUSAHAAN ID";
            // 
            // frmRptSaldoGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(387, 289);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.dbPeriode);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoBGD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoBGT);
            this.Name = "frmRptSaldoGiro";
            this.Text = "Saldo Giro";
            this.Load += new System.EventHandler(this.frmRptSaldoGiro_Load);
            this.Controls.SetChildIndex(this.rdoBGT, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rdoBGD, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dbPeriode, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.DateTextBox dbPeriode;
        private System.Windows.Forms.RadioButton rdoBGD;
        private System.Windows.Forms.RadioButton rdoBGT;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommonTextBox txtPID;
        private System.Windows.Forms.Label label4;
    }
}
