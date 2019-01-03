namespace ISA.Toko.Administrasi
{
    partial class frmUserUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserUpdate));
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.txtPassword = new ISA.Toko.Controls.CommonTextBox();
            this.txtUserName = new ISA.Toko.Controls.CommonTextBox();
            this.txtUserID = new ISA.Toko.Controls.CommonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRoleApplication = new System.Windows.Forms.ComboBox();
            this.cboRoleBusiness = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(260, 207);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 76;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(143, 207);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 75;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(143, 113);
            this.txtPassword.MaxLength = 250;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 68;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(143, 87);
            this.txtUserName.MaxLength = 250;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(137, 20);
            this.txtUserName.TabIndex = 67;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(143, 61);
            this.txtUserID.MaxLength = 250;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(137, 20);
            this.txtUserID.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Role Business";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Role Application";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "User ID";
            // 
            // cboRoleApplication
            // 
            this.cboRoleApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleApplication.FormattingEnabled = true;
            this.cboRoleApplication.Location = new System.Drawing.Point(144, 139);
            this.cboRoleApplication.Name = "cboRoleApplication";
            this.cboRoleApplication.Size = new System.Drawing.Size(136, 21);
            this.cboRoleApplication.TabIndex = 77;
            // 
            // cboRoleBusiness
            // 
            this.cboRoleBusiness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleBusiness.FormattingEnabled = true;
            this.cboRoleBusiness.Location = new System.Drawing.Point(144, 166);
            this.cboRoleBusiness.Name = "cboRoleBusiness";
            this.cboRoleBusiness.Size = new System.Drawing.Size(136, 21);
            this.cboRoleBusiness.TabIndex = 78;
            // 
            // frmUserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(609, 338);
            this.Controls.Add(this.cboRoleBusiness);
            this.Controls.Add(this.cboRoleApplication);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUserUpdate";
            this.Text = "User";
            this.Title = "User";
            this.Load += new System.EventHandler(this.frmUserUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtUserID, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.cboRoleApplication, 0);
            this.Controls.SetChildIndex(this.cboRoleBusiness, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private ISA.Toko.Controls.CommonTextBox txtPassword;
        private ISA.Toko.Controls.CommonTextBox txtUserName;
        private ISA.Toko.Controls.CommonTextBox txtUserID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRoleApplication;
        private System.Windows.Forms.ComboBox cboRoleBusiness;
    }
}
