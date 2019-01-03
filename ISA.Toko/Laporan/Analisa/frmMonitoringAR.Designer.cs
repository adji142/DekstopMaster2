namespace ISA.Toko.Laporan.Analisa
{
    partial class frmMonitoringAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitoringAR));
            this.txtInitPerusahaan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTextBox1 = new ISA.Controls.DateTextBox();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInitPerusahaan
            // 
            this.txtInitPerusahaan.Enabled = false;
            this.txtInitPerusahaan.Location = new System.Drawing.Point(226, 105);
            this.txtInitPerusahaan.Name = "txtInitPerusahaan";
            this.txtInitPerusahaan.Size = new System.Drawing.Size(80, 20);
            this.txtInitPerusahaan.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Init Perusahaan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Periode";
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(226, 72);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox1.TabIndex = 15;
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(294, 154);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 18;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(39, 154);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 17;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 25);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Monitoring AR";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMonitoringAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 224);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtInitPerusahaan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTextBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "frmMonitoringAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring AR";
            this.Load += new System.EventHandler(this.frmMonitoringAR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInitPerusahaan;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.DateTextBox dateTextBox1;
        private System.Windows.Forms.Label lblTitle;
    }
}