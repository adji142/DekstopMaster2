namespace ISA.Trading.Penjualan
{
    partial class frmLostSalesupdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLostSalesupdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
            this.lookupStock1 = new ISA.Trading.Controls.LookupStock();
            this.lookupSales1 = new ISA.Trading.Controls.LookupSales();
            this.lookupToko1 = new ISA.Trading.Controls.LookupToko();
            this.commonTextBox1 = new ISA.Trading.Controls.CommonTextBox();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "SallesMan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Keterangan";
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(114, 66);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(120, 20);
            this.dateTextBox1.TabIndex = 10;
            // 
            // lookupStock1
            // 
            this.lookupStock1.BarangID = "[CODE]";
            this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock1.IsiKoli = 0;
            this.lookupStock1.Location = new System.Drawing.Point(111, 93);
            this.lookupStock1.LookUpType = ISA.Trading.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock1.LPasif = ISA.Trading.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock1.NamaStock = "";
            this.lookupStock1.Name = "lookupStock1";
            this.lookupStock1.RecordID = null;
            this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock1.Satuan = null;
            this.lookupStock1.Size = new System.Drawing.Size(329, 54);
            this.lookupStock1.TabIndex = 11;
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(111, 153);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "[CODE]";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 12;
            // 
            // lookupToko1
            // 
            this.lookupToko1.Alamat = null;
            this.lookupToko1.Daerah = null;
            this.lookupToko1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupToko1.HariKirim = 0;
            this.lookupToko1.HariSales = 0;
            this.lookupToko1.KodeToko = "[CODE]";
            this.lookupToko1.Kota = null;
            this.lookupToko1.Location = new System.Drawing.Point(111, 210);
            this.lookupToko1.NamaToko = "";
            this.lookupToko1.Name = "lookupToko1";
            this.lookupToko1.Propinsi = null;
            this.lookupToko1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupToko1.Size = new System.Drawing.Size(300, 54);
            this.lookupToko1.TabIndex = 13;
            this.lookupToko1.TokoID = null;
            this.lookupToko1.WilID = "";
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Location = new System.Drawing.Point(114, 277);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.Size = new System.Drawing.Size(297, 20);
            this.commonTextBox1.TabIndex = 14;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(31, 321);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 15;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(356, 321);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 16;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmLostSalesupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.commonTextBox1);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookupToko1);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.lookupStock1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmLostSalesupdate";
            this.Text = "Lost Sales Update";
            this.Title = "Lost Sales Update";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmLostSalesupdate_Load);
            this.Controls.SetChildIndex(this.lookupStock1, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.lookupToko1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.commonTextBox1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private ISA.Trading.Controls.LookupStock lookupStock1;
        private ISA.Trading.Controls.LookupSales lookupSales1;
        private ISA.Trading.Controls.LookupToko lookupToko1;
        private ISA.Trading.Controls.CommonTextBox commonTextBox1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;

    }
}