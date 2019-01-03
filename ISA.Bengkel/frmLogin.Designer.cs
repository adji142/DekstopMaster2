namespace ISA.Bengkel
{
    partial class frmLogin
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtUserName = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Host";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(147, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login";
            // 
            // cmdExit
            // 
            this.cmdExit.BackgroundImage = global::ISA.Bengkel.Properties.Resources.Close32;
            this.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(193, 130);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(111, 42);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "EXIT";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.BackgroundImage = global::ISA.Bengkel.Properties.Resources.Key32;
            this.cmdLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLogin.Location = new System.Drawing.Point(55, 130);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(119, 42);
            this.cmdLogin.TabIndex = 2;
            this.cmdLogin.Text = "LOGIN";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(144, 101);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(0, 13);
            this.lblHost.TabIndex = 13;
            // 
            // txtUserName
            // 
            this.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserName.Location = new System.Drawing.Point(147, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 213);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdLogin);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISA.Bengkel.Depo";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdLogin;
        private ISA.Controls.CommonTextBox txtUserName;
        private System.Windows.Forms.Label lblHost;

    }
}