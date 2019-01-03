namespace ISA.Toko.Persediaan
    {
    partial class frmRptStokOpnameBelumTerOpname
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStokOpnameBelumTerOpname));
                this.cmdYes = new ISA.Toko.Controls.CommandButton();
                this.cmdNO = new ISA.Toko.Controls.CommandButton();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(31, 186);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 1;
                this.cmdYes.Text = "YES";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNO
                // 
                this.cmdNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNO.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNO.Image = ((System.Drawing.Image)(resources.GetObject("cmdNO.Image")));
                this.cmdNO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNO.Location = new System.Drawing.Point(260, 186);
                this.cmdNO.Name = "cmdNO";
                this.cmdNO.Size = new System.Drawing.Size(100, 40);
                this.cmdNO.TabIndex = 2;
                this.cmdNO.Text = "CANCEL";
                this.cmdNO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNO.UseVisualStyleBackColor = true;
                this.cmdNO.Click += new System.EventHandler(this.cmdNO_Click);
                // 
                // frmRptStokOpnameBelumTerOpname
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(391, 252);
                this.Controls.Add(this.cmdNO);
                this.Controls.Add(this.cmdYes);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptStokOpnameBelumTerOpname";
                this.Text = "Barang Belum Teropname";
                this.Title = "Barang Belum Teropname";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptStokOpnameBelumTerOpname_Load);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNO, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNO;
        }
    }
