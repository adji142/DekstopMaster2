namespace ISA.Trading.PSReport
{
    partial class frmDashboardPICArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboardPICArea));
            this.label1 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.rangePeriode = new ISA.Controls.RangeDateBox();
            this.bwKADepo = new System.ComponentModel.BackgroundWorker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periode";
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(139, 215);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 2;
            this.commandButton1.Text = "PRINT";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(313, 215);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 3;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // rangePeriode
            // 
            this.rangePeriode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rangePeriode.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangePeriode.FromDate = null;
            this.rangePeriode.Location = new System.Drawing.Point(191, 154);
            this.rangePeriode.Name = "rangePeriode";
            this.rangePeriode.Size = new System.Drawing.Size(247, 36);
            this.rangePeriode.TabIndex = 5;
            this.rangePeriode.ToDate = null;
            // 
            // bwKADepo
            // 
            this.bwKADepo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwKADepo_DoWork);
            this.bwKADepo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwKADepo_RunWorkerCompleted);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(42, 332);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(468, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // frmDashboardPICArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 374);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.rangePeriode);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDashboardPICArea";
            this.Text = "Dashboard PIC Area";
            this.Title = "Dashboard PIC Area";
            this.Load += new System.EventHandler(this.frmDashboardKaDepo_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.rangePeriode, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private ISA.Controls.RangeDateBox rangePeriode;
        private System.ComponentModel.BackgroundWorker bwKADepo;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}