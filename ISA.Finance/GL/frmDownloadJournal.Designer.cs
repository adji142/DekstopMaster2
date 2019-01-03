namespace ISA.Finance.GL
{
    partial class frmDownloadJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadJournal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatus = new ISA.Controls.CommonTextBox();
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.commonTextBox2 = new ISA.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download Jurnal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Folder Download";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.ForeColor = System.Drawing.Color.Lime;
            this.txtStatus.Location = new System.Drawing.Point(318, 149);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(76, 20);
            this.txtStatus.TabIndex = 13;
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Enabled = false;
            this.commonTextBox1.Location = new System.Drawing.Point(212, 102);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.ReadOnly = true;
            this.commonTextBox1.Size = new System.Drawing.Size(182, 20);
            this.commonTextBox1.TabIndex = 11;
            this.commonTextBox1.Text = "C:\\TEMP\\DOWNLOAD";
            // 
            // commonTextBox2
            // 
            this.commonTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox2.Enabled = false;
            this.commonTextBox2.Location = new System.Drawing.Point(212, 149);
            this.commonTextBox2.Name = "commonTextBox2";
            this.commonTextBox2.ReadOnly = true;
            this.commonTextBox2.Size = new System.Drawing.Size(100, 20);
            this.commonTextBox2.TabIndex = 12;
            this.commonTextBox2.Text = "NOPERK.ZIP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nama File";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(266, 298);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(50, 238);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(378, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Download;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(84, 298);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(128, 40);
            this.cmdYes.TabIndex = 14;
            this.cmdYes.Text = "DOWNLOAD";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // frmDownloadJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 367);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.commonTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmDownloadJournal";
            this.Text = "frmDownloadJournal";
            this.Load += new System.EventHandler(this.frmDownloadJournal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommonTextBox txtStatus;
        private ISA.Controls.CommonTextBox commonTextBox1;
        private ISA.Controls.CommonTextBox commonTextBox2;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ISA.Controls.CommandButton cmdYes;
    }
}