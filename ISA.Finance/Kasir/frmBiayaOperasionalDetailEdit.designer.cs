namespace ISA.Finance.Kasir
{
    partial class frmBiayaOperasionalDetailEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiayaOperasionalDetailEdit));
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.txtRpBiayaAcc = new ISA.Controls.NumericTextBox();
            this.txtRpBiaya = new ISA.Controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(367, 218);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 17;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(474, 218);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 18;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtRpBiayaAcc
            // 
            this.txtRpBiayaAcc.Location = new System.Drawing.Point(128, 121);
            this.txtRpBiayaAcc.Name = "txtRpBiayaAcc";
            this.txtRpBiayaAcc.Size = new System.Drawing.Size(100, 20);
            this.txtRpBiayaAcc.TabIndex = 14;
            this.txtRpBiayaAcc.Text = "0";
            // 
            // txtRpBiaya
            // 
            this.txtRpBiaya.Location = new System.Drawing.Point(128, 95);
            this.txtRpBiaya.Name = "txtRpBiaya";
            this.txtRpBiaya.ReadOnly = true;
            this.txtRpBiaya.Size = new System.Drawing.Size(100, 20);
            this.txtRpBiaya.TabIndex = 15;
            this.txtRpBiaya.TabStop = false;
            this.txtRpBiaya.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Keterangan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rp Biaya ACC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rp Biaya";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(128, 69);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.ReadOnly = true;
            this.txtUraian.Size = new System.Drawing.Size(436, 20);
            this.txtUraian.TabIndex = 13;
            this.txtUraian.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Uraian";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(128, 147);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(248, 20);
            this.txtKeterangan.TabIndex = 16;
            // 
            // frmBiayaOperasionalDetailEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(586, 271);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtRpBiayaAcc);
            this.Controls.Add(this.txtRpBiaya);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKeterangan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBiayaOperasionalDetailEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Biaya Operasional Detail";
            this.Title = "Edit Biaya Operasional Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmBiayaOperasionalDetailEdit_Load);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRpBiaya, 0);
            this.Controls.SetChildIndex(this.txtRpBiayaAcc, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.NumericTextBox txtRpBiayaAcc;
        private ISA.Controls.NumericTextBox txtRpBiaya;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtKeterangan;
    }
}
