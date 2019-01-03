namespace ISA.Bengkel.Master
{
    partial class frmCustMemberUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustMemberUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomor = new ISA.Controls.CommonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeterangan = new ISA.Controls.CommonTextBox();
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDBM = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "NOMOR";
            // 
            // txtNomor
            // 
            this.txtNomor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomor.Location = new System.Drawing.Point(148, 69);
            this.txtNomor.MaxLength = 3;
            this.txtNomor.Name = "txtNomor";
            this.txtNomor.Size = new System.Drawing.Size(92, 20);
            this.txtNomor.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "KETERANGAN";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(148, 97);
            this.txtKeterangan.MaxLength = 25;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(275, 20);
            this.txtKeterangan.TabIndex = 1;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(285, 149);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 4;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(148, 149);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 3;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "IDBM";
            // 
            // txtIDBM
            // 
            this.txtIDBM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDBM.Location = new System.Drawing.Point(148, 123);
            this.txtIDBM.MaxLength = 3;
            this.txtIDBM.Name = "txtIDBM";
            this.txtIDBM.Size = new System.Drawing.Size(52, 20);
            this.txtIDBM.TabIndex = 2;
            // 
            // frmCustMemberUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(437, 211);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIDBM);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomor);
            this.Controls.Add(this.txtKeterangan);
            this.FormID = "BKL0033";
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustMemberUpdate";
            this.Text = "BKL0033 - Member";
            this.Title = "Member";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmCustMemberUpdate_Load);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.txtNomor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.txtIDBM, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtNomor;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtKeterangan;
        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtIDBM;
    }
}
