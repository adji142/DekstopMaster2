namespace ISA.Toko.Persediaan
    {
    partial class frmRptTidakAdaRecordID
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing&&(components!=null))
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptTidakAdaRecordID));
                this.cmdOK = new ISA.Toko.Controls.CommandButton();
                this.cmdCancel = new ISA.Toko.Controls.CommandButton();
                this.SuspendLayout();
                // 
                // cmdOK
                // 
                this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdOK.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
                this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdOK.Location = new System.Drawing.Point(14, 173);
                this.cmdOK.Name = "cmdOK";
                this.cmdOK.Size = new System.Drawing.Size(100, 40);
                this.cmdOK.TabIndex = 0;
                this.cmdOK.Text = "YES";
                this.cmdOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdOK.UseVisualStyleBackColor = true;
                this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
                // 
                // cmdCancel
                // 
                this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
                this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdCancel.Location = new System.Drawing.Point(285, 173);
                this.cmdCancel.Name = "cmdCancel";
                this.cmdCancel.Size = new System.Drawing.Size(100, 40);
                this.cmdCancel.TabIndex = 1;
                this.cmdCancel.Text = "CANCEL";
                this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdCancel.UseVisualStyleBackColor = true;
                this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
                // 
                // frmRptTidakAdaRecordID
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(415, 235);
                this.Controls.Add(this.cmdCancel);
                this.Controls.Add(this.cmdOK);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptTidakAdaRecordID";
                this.Text = "Barang Tidak Ada Record_ID";
                this.Title = "Barang Tidak Ada Record_ID";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptTidakAdaRecordID_Load);
                this.Controls.SetChildIndex(this.cmdOK, 0);
                this.Controls.SetChildIndex(this.cmdCancel, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdOK;
        private ISA.Toko.Controls.CommandButton cmdCancel;
        }
    }
