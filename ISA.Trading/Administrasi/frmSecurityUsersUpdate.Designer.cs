namespace ISA.Trading.Administrasi
{
    partial class frmSecurityUsersUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityUsersUpdate));
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new ISA.Trading.Controls.CommonTextBox();
            this.txtUserID = new ISA.Trading.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtInitial = new ISA.Trading.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(290, 220);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 5;
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
            this.cmdSAVE.Location = new System.Drawing.Point(153, 220);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 4;
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
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserName.Location = new System.Drawing.Point(153, 92);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(275, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Location = new System.Drawing.Point(153, 66);
            this.txtUserID.MaxLength = 50;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(275, 20);
            this.txtUserID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "User ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 46;
            this.label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(153, 144);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(275, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtInitial
            // 
            this.txtInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInitial.Location = new System.Drawing.Point(153, 118);
            this.txtInitial.MaxLength = 3;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(275, 20);
            this.txtInitial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 47;
            this.label3.Text = "Initial";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(153, 170);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(68, 18);
            this.chkActive.TabIndex = 49;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // frmSecurityUsersUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSecurityUsersUpdate";
            this.Text = "Security Users";
            this.Title = "Security Users";
            this.Load += new System.EventHandler(this.frmSecurityUsersUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSecurityUsersUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUserID, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtInitial, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtUserName;
        private ISA.Trading.Controls.CommonTextBox txtUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private ISA.Trading.Controls.CommonTextBox txtInitial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkActive;
    }
}
