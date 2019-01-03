namespace ISA.Toko.Pembelian
{
    partial class frmRptAnalisaBOFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaBOFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTglDO = new ISA.Toko.Controls.RangeDateBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tanggal DO:";
            // 
            // rdbTglDO
            // 
            this.rdbTglDO.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTglDO.FromDate = null;
            this.rdbTglDO.Location = new System.Drawing.Point(136, 66);
            this.rdbTglDO.Name = "rdbTglDO";
            this.rdbTglDO.Size = new System.Drawing.Size(257, 22);
            this.rdbTglDO.TabIndex = 0;
            this.rdbTglDO.ToDate = null;
            this.rdbTglDO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdbTglDO_KeyPress);
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(207, 124);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 2;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(98, 124);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 1;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptAnalisaBOFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(407, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbTglDO);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 210);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 210);
            this.Name = "frmRptAnalisaBOFilter";
            this.Text = "Laporan Analisa BO";
            this.Title = "Laporan Analisa BO";
            this.Load += new System.EventHandler(this.frmRptAnalisaBOFilter_Load);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.rdbTglDO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rdbTglDO;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private System.Windows.Forms.ErrorProvider errorProvider1;



    }
}
