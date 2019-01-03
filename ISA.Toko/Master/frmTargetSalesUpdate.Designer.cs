namespace ISA.Toko.Master
{
    partial class frmTargetSalesUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetSalesUpdate));
            this.cmdSave = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTMT = new ISA.Toko.Controls.DateTextBox();
            this.txtSkuR2 = new ISA.Controls.NumericTextBox();
            this.txtOmsetNetto = new ISA.Controls.NumericTextBox();
            this.txtOrdAktif = new ISA.Controls.NumericTextBox();
            this.lookupSales1 = new ISA.Toko.Controls.LookupSales();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(183, 298);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(306, 298);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "T.M.T";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "SKU (Items)";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "OMSET NETTO";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(109, 251);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 14);
            this.label16.TabIndex = 27;
            this.label16.Text = "Outlet Aktif";
            // 
            // dateTMT
            // 
            this.dateTMT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTMT.DateValue = null;
            this.dateTMT.Location = new System.Drawing.Point(210, 158);
            this.dateTMT.MaxLength = 10;
            this.dateTMT.Name = "dateTMT";
            this.dateTMT.Size = new System.Drawing.Size(178, 20);
            this.dateTMT.TabIndex = 1;
            // 
            // txtSkuR2
            // 
            this.txtSkuR2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSkuR2.Location = new System.Drawing.Point(210, 187);
            this.txtSkuR2.Name = "txtSkuR2";
            this.txtSkuR2.Size = new System.Drawing.Size(178, 20);
            this.txtSkuR2.TabIndex = 2;
            this.txtSkuR2.Text = "0";
            // 
            // txtOmsetNetto
            // 
            this.txtOmsetNetto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOmsetNetto.Location = new System.Drawing.Point(210, 218);
            this.txtOmsetNetto.Name = "txtOmsetNetto";
            this.txtOmsetNetto.Size = new System.Drawing.Size(178, 20);
            this.txtOmsetNetto.TabIndex = 3;
            this.txtOmsetNetto.Text = "0";
            // 
            // txtOrdAktif
            // 
            this.txtOrdAktif.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOrdAktif.Location = new System.Drawing.Point(210, 248);
            this.txtOrdAktif.Name = "txtOrdAktif";
            this.txtOrdAktif.Size = new System.Drawing.Size(178, 20);
            this.txtOrdAktif.TabIndex = 4;
            this.txtOrdAktif.Text = "0";
            // 
            // lookupSales1
            // 
            this.lookupSales1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(112, 78);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "[CODE]";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 0;
            // 
            // frmTargetSalesUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 414);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.txtOrdAktif);
            this.Controls.Add(this.txtOmsetNetto);
            this.Controls.Add(this.txtSkuR2);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dateTMT);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetSalesUpdate";
            this.Text = "Target Sales";
            this.Title = "Target Sales";
            this.Load += new System.EventHandler(this.frmTargetSalesUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTargetSalesUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.dateTMT, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.txtSkuR2, 0);
            this.Controls.SetChildIndex(this.txtOmsetNetto, 0);
            this.Controls.SetChildIndex(this.txtOrdAktif, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private ISA.Toko.Controls.DateTextBox dateTMT;
        private ISA.Controls.NumericTextBox txtSkuR2;
        private ISA.Controls.NumericTextBox txtOmsetNetto;
        private ISA.Controls.NumericTextBox txtOrdAktif;
        private ISA.Toko.Controls.LookupSales lookupSales1;
    }
}