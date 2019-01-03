namespace ISA.Toko.Persediaan
    {
    partial class frmStokOpnameUpgrade
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokOpnameUpgrade));
                this.dateTextBox1 = new ISA.Toko.Controls.DateTextBox();
                this.cmdOK = new ISA.Toko.Controls.CommandButton();
                this.cmdCancel = new ISA.Toko.Controls.CommandButton();
                this.label1 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // dateTextBox1
                // 
                this.dateTextBox1.DateValue = null;
                this.dateTextBox1.Location = new System.Drawing.Point(150, 61);
                this.dateTextBox1.MaxLength = 10;
                this.dateTextBox1.Name = "dateTextBox1";
                this.dateTextBox1.Size = new System.Drawing.Size(142, 20);
                this.dateTextBox1.TabIndex = 0;
                // 
                // cmdOK
                // 
                this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdOK.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdOK.Image = ((System.Drawing.Image)(resources.GetObject("cmdOK.Image")));
                this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdOK.Location = new System.Drawing.Point(31, 126);
                this.cmdOK.Name = "cmdOK";
                this.cmdOK.Size = new System.Drawing.Size(117, 43);
                this.cmdOK.TabIndex = 1;
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
                this.cmdCancel.Location = new System.Drawing.Point(176, 126);
                this.cmdCancel.Name = "cmdCancel";
                this.cmdCancel.Size = new System.Drawing.Size(117, 43);
                this.cmdCancel.TabIndex = 2;
                this.cmdCancel.Text = "CANCEL";
                this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdCancel.UseVisualStyleBackColor = true;
                this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(105, 14);
                this.label1.TabIndex = 8;
                this.label1.Text = "Tanggal Proses";
                // 
                // frmStokOpnameUpgrade
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(329, 182);
                this.Controls.Add(this.cmdCancel);
                this.Controls.Add(this.cmdOK);
                this.Controls.Add(this.dateTextBox1);
                this.Controls.Add(this.label1);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmStokOpnameUpgrade";
                this.Text = "Upgrade Stok";
                this.Title = "Upgrade Stok";
                this.Load += new System.EventHandler(this.frmStokOpnameUpgrade_Load);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.dateTextBox1, 0);
                this.Controls.SetChildIndex(this.cmdOK, 0);
                this.Controls.SetChildIndex(this.cmdCancel, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.DateTextBox dateTextBox1;
        private ISA.Toko.Controls.CommandButton cmdOK;
        private ISA.Toko.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.Label label1;
        }
    }
