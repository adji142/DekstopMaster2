namespace ISA.Trading.Administrasi
{
    partial class frmSecurityApplicationsUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityApplicationsUpdate));
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApplicationName = new ISA.Trading.Controls.CommonTextBox();
            this.txtApplicationID = new ISA.Trading.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(290, 141);
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
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(153, 141);
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
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "App Name";
            // 
            // txtApplicationName
            // 
            this.txtApplicationName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApplicationName.Location = new System.Drawing.Point(153, 92);
            this.txtApplicationName.MaxLength = 50;
            this.txtApplicationName.Name = "txtApplicationName";
            this.txtApplicationName.Size = new System.Drawing.Size(275, 20);
            this.txtApplicationName.TabIndex = 1;
            // 
            // txtApplicationID
            // 
            this.txtApplicationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApplicationID.Location = new System.Drawing.Point(153, 66);
            this.txtApplicationID.MaxLength = 50;
            this.txtApplicationID.Name = "txtApplicationID";
            this.txtApplicationID.Size = new System.Drawing.Size(275, 20);
            this.txtApplicationID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "App ID";
            // 
            // frmSecurityApplicationsUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApplicationName);
            this.Controls.Add(this.txtApplicationID);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSecurityApplicationsUpdate";
            this.Text = "Security - Applications";
            this.Title = "Security - Applications";
            this.Load += new System.EventHandler(this.frmSecurityApplicationsUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSecurityApplicationsUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtApplicationID, 0);
            this.Controls.SetChildIndex(this.txtApplicationName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtApplicationName;
        private ISA.Trading.Controls.CommonTextBox txtApplicationID;
        private System.Windows.Forms.Label label4;
    }
}
