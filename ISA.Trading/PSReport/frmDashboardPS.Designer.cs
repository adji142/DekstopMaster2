namespace ISA.Trading.PSReport
{
    partial class frmDashboardPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboardPS));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClose = new ISA.Trading.Controls.CommandButton();
            this.bwDashboardPS = new System.ComponentModel.BackgroundWorker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.myPeriode = new ISA.Controls.RangeDateBox();
            this.commandButton1 = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Periode";
            // 
            // cmbClose
            // 
            this.cmbClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmbClose.Image = ((System.Drawing.Image)(resources.GetObject("cmbClose.Image")));
            this.cmbClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbClose.Location = new System.Drawing.Point(318, 191);
            this.cmbClose.Name = "cmbClose";
            this.cmbClose.Size = new System.Drawing.Size(100, 40);
            this.cmbClose.TabIndex = 8;
            this.cmbClose.Text = "CLOSE";
            this.cmbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmbClose.UseVisualStyleBackColor = true;
            this.cmbClose.Click += new System.EventHandler(this.cmbClose_Click);
            // 
            // bwDashboardPS
            // 
            this.bwDashboardPS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDashboardPS_DoWork);
            this.bwDashboardPS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDashboardPS_RunWorkerCompleted);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(39, 275);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(468, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // myPeriode
            // 
            this.myPeriode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.myPeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.myPeriode.FromDate = null;
            this.myPeriode.Location = new System.Drawing.Point(192, 117);
            this.myPeriode.Name = "myPeriode";
            this.myPeriode.Size = new System.Drawing.Size(253, 38);
            this.myPeriode.TabIndex = 26;
            this.myPeriode.ToDate = null;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(166, 191);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName2 = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 27;
            this.commandButton1.Text = "PRINT";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmDashboardPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 311);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.myPeriode);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.cmbClose);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDashboardPS";
            this.Text = "Dashboard PS";
            this.Title = "Dashboard PS";
            this.Load += new System.EventHandler(this.frmDashboardPS_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbClose, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.myPeriode, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmbClose;
        private System.ComponentModel.BackgroundWorker bwDashboardPS;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ISA.Controls.RangeDateBox myPeriode;
        private ISA.Controls.CommandButton commandButton1;
    }
}