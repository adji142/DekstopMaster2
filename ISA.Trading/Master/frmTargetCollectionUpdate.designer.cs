namespace ISA.Trading.Master
{
    partial class frmTargetCollectionUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetCollectionUpdate));
            this.label3 = new System.Windows.Forms.Label();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetRp = new ISA.Controls.NumericTextBox();
            this.txtKeterangan = new ISA.Trading.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdSAVE = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Periode:";
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(143, 80);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(362, 23);
            this.monthYearBox1.TabIndex = 9;
            this.monthYearBox1.Year = 2012;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Target Rp";
            // 
            // txtTargetRp
            // 
            this.txtTargetRp.Location = new System.Drawing.Point(143, 109);
            this.txtTargetRp.Name = "txtTargetRp";
            this.txtTargetRp.Size = new System.Drawing.Size(136, 20);
            this.txtTargetRp.TabIndex = 11;
            this.txtTargetRp.Text = "0";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(142, 141);
            this.txtKeterangan.MaxLength = 75;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(311, 20);
            this.txtKeterangan.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Keterangan";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(305, 252);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 15;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(160, 252);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 14;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // frmTargetCollectionUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTargetRp);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetCollectionUpdate";
            this.Text = "Target Collection Kasir";
            this.Title = "Target Collection Kasir";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmTargetCollectionUpdate_Layout);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.txtTargetRp, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.NumericTextBox txtTargetRp;
        private ISA.Trading.Controls.CommonTextBox txtKeterangan;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdSAVE;
    }
}