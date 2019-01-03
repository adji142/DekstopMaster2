namespace ISA.Finance.Administrasi
{
    partial class frmSecurityRightsUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityRightsUpdate));
            this.cmdCLOSE = new ISA.Controls.CommandButton();
            this.cmdSAVE = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRightName = new ISA.Controls.CommonTextBox();
            this.txtRightID = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(294, 136);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 3;
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
            this.cmdSAVE.Location = new System.Drawing.Point(157, 136);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 2;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "Right Name";
            // 
            // txtRightName
            // 
            this.txtRightName.Location = new System.Drawing.Point(153, 92);
            this.txtRightName.MaxLength = 50;
            this.txtRightName.Name = "txtRightName";
            this.txtRightName.Size = new System.Drawing.Size(275, 20);
            this.txtRightName.TabIndex = 1;
            // 
            // txtRightID
            // 
            this.txtRightID.Location = new System.Drawing.Point(153, 66);
            this.txtRightID.MaxLength = 50;
            this.txtRightID.Name = "txtRightID";
            this.txtRightID.Size = new System.Drawing.Size(275, 20);
            this.txtRightID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "Right ID";
            // 
            // frmSecurityRightsUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(771, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRightName);
            this.Controls.Add(this.txtRightID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSecurityRightsUpdate";
            this.Text = "Security - Rights";           
            this.Load += new System.EventHandler(this.frmSecurityRightsUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSecurityRightsUpdate_FormClosed);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRightID, 0);
            this.Controls.SetChildIndex(this.txtRightName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdCLOSE;
        private ISA.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtRightName;
        private ISA.Controls.CommonTextBox txtRightID;
        private System.Windows.Forms.Label label4;


    }
}
