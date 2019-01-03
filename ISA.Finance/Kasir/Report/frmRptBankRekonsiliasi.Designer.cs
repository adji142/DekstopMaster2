﻿namespace ISA.Finance.Kasir.Report
{
    partial class frmRptBankRekonsiliasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptBankRekonsiliasi));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTgl = new ISA.Controls.DateTextBox();
            this.tbNamaBank = new ISA.Controls.CommonTextBox();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSaldoRKBank = new ISA.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nama Bank";
            // 
            // tbTgl
            // 
            this.tbTgl.DateValue = null;
            this.tbTgl.Location = new System.Drawing.Point(134, 25);
            this.tbTgl.MaxLength = 10;
            this.tbTgl.Name = "tbTgl";
            this.tbTgl.Size = new System.Drawing.Size(80, 20);
            this.tbTgl.TabIndex = 0;
            // 
            // tbNamaBank
            // 
            this.tbNamaBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNamaBank.Enabled = false;
            this.tbNamaBank.Location = new System.Drawing.Point(134, 51);
            this.tbNamaBank.Name = "tbNamaBank";
            this.tbNamaBank.Size = new System.Drawing.Size(100, 20);
            this.tbNamaBank.TabIndex = 1;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(28, 117);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 2;
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
            this.cmdClose.Location = new System.Drawing.Point(134, 117);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saldo RK Bank";
            // 
            // tbSaldoRKBank
            // 
            this.tbSaldoRKBank.Location = new System.Drawing.Point(134, 77);
            this.tbSaldoRKBank.Name = "tbSaldoRKBank";
            this.tbSaldoRKBank.Size = new System.Drawing.Size(100, 20);
            this.tbSaldoRKBank.TabIndex = 6;
            this.tbSaldoRKBank.Text = "0";
            // 
            // frmRptBankRekonsiliasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(266, 169);
            this.Controls.Add(this.tbSaldoRKBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.tbNamaBank);
            this.Controls.Add(this.tbTgl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRptBankRekonsiliasi";
            this.Text = "LAPORAN REKONSILIASI BANK";
            this.Load += new System.EventHandler(this.frmRptBankRekonsiliasi_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbTgl, 0);
            this.Controls.SetChildIndex(this.tbNamaBank, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbSaldoRKBank, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.DateTextBox tbTgl;
        private ISA.Controls.CommonTextBox tbNamaBank;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.NumericTextBox tbSaldoRKBank;
    }
}