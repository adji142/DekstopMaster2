namespace ISA.Toko.Communicator
{
    partial class frmCockpitRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCockpitRestore));
            this.pbSyncDownload = new System.Windows.Forms.ProgressBar();
            this.cmdCancel = new ISA.Toko.Controls.CommandButton();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblJumlahTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbSyncDownload
            // 
            this.pbSyncDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSyncDownload.Location = new System.Drawing.Point(9, 69);
            this.pbSyncDownload.Name = "pbSyncDownload";
            this.pbSyncDownload.Size = new System.Drawing.Size(400, 23);
            this.pbSyncDownload.TabIndex = 10;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(309, 234);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(9, 234);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 8;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 136);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(28, 14);
            this.lblCount.TabIndex = 17;
            this.lblCount.Text = "0/0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Jumlah Table:";
            // 
            // lblJumlahTable
            // 
            this.lblJumlahTable.AutoSize = true;
            this.lblJumlahTable.Location = new System.Drawing.Point(110, 99);
            this.lblJumlahTable.Name = "lblJumlahTable";
            this.lblJumlahTable.Size = new System.Drawing.Size(35, 14);
            this.lblJumlahTable.TabIndex = 20;
            this.lblJumlahTable.Text = "0/34";
            // 
            // frmCockpitRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(426, 286);
            this.Controls.Add(this.lblJumlahTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pbSyncDownload);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCockpitRestore";
            this.Text = "COCKPIT RESTORE";
            this.Title = "COCKPIT RESTORE";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.pbSyncDownload, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblJumlahTable, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbSyncDownload;
        private ISA.Toko.Controls.CommandButton cmdCancel;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJumlahTable;
    }
}
