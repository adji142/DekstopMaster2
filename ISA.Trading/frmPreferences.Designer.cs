namespace ISA.Trading
{
    partial class frmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSASFoxpro = new ISA.Trading.Controls.FolderBrowserTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbfDownload = new ISA.Trading.Controls.FolderBrowserTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbfUpload = new ISA.Trading.Controls.FolderBrowserTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(461, 288);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(584, 288);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSASFoxpro);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDbfDownload);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDbfUpload);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 167);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Location";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSASFoxpro
            // 
            this.txtSASFoxpro.Location = new System.Drawing.Point(274, 78);
            this.txtSASFoxpro.Name = "txtSASFoxpro";
            this.txtSASFoxpro.Size = new System.Drawing.Size(414, 22);
            this.txtSASFoxpro.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "SAS Foxpro Database Location";
            // 
            // txtDbfDownload
            // 
            this.txtDbfDownload.Location = new System.Drawing.Point(274, 48);
            this.txtDbfDownload.Name = "txtDbfDownload";
            this.txtDbfDownload.Size = new System.Drawing.Size(414, 22);
            this.txtDbfDownload.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "DBF Download File Location";
            // 
            // txtDbfUpload
            // 
            this.txtDbfUpload.Location = new System.Drawing.Point(274, 18);
            this.txtDbfUpload.Name = "txtDbfUpload";
            this.txtDbfUpload.Size = new System.Drawing.Size(414, 22);
            this.txtDbfUpload.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "DBF Upload File Location";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(9, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 194);
            this.tabControl1.TabIndex = 7;
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(715, 342);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPreferences";
            this.Text = "Preferences";
            this.Title = "Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.FolderBrowserTextBox txtDbfUpload;
        private ISA.Trading.Controls.FolderBrowserTextBox txtDbfDownload;
        private ISA.Trading.Controls.FolderBrowserTextBox txtSASFoxpro;
        private System.Windows.Forms.Label label3;
    }
}
