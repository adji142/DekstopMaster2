namespace ISA.Finance.Piutang.Report
{
    partial class frmOmsetUmurPiutangJS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOmsetUmurPiutangJS));
            this.rdTgl = new ISA.Controls.RangeDateBox();
            this.Periode = new System.Windows.Forms.Label();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // rdTgl
            // 
            this.rdTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdTgl.FromDate = null;
            this.rdTgl.Location = new System.Drawing.Point(125, 64);
            this.rdTgl.Name = "rdTgl";
            this.rdTgl.Size = new System.Drawing.Size(268, 24);
            this.rdTgl.TabIndex = 5;
            this.rdTgl.ToDate = null;
            // 
            // Periode
            // 
            this.Periode.AutoSize = true;
            this.Periode.Location = new System.Drawing.Point(72, 67);
            this.Periode.Name = "Periode";
            this.Periode.Size = new System.Drawing.Size(50, 14);
            this.Periode.TabIndex = 6;
            this.Periode.Text = "Periode";
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(110, 176);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 7;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(223, 176);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmOmsetUmurPiutangJS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(440, 243);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.Periode);
            this.Controls.Add(this.rdTgl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOmsetUmurPiutangJS";
            this.Text = "";
            this.Title = "";
            this.Load += new System.EventHandler(this.frmOmsetUmurPiutangJS_Load);
            this.Controls.SetChildIndex(this.rdTgl, 0);
            this.Controls.SetChildIndex(this.Periode, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.RangeDateBox rdTgl;
        private System.Windows.Forms.Label Periode;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CommandButton cmdClose;
    }
}
