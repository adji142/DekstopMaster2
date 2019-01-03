namespace ISA.Toko.POS.Laporan
{
    partial class FrmPOSLaporan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lookupSales1 = new ISA.Toko.Controls.LookupSales();
            this.CmdToExcel = new System.Windows.Forms.Button();
            this.DateLaporan = new ISA.Toko.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "LAPORAN PENJUALAN HARIAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "POINT OF SALES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SALESMAN";
            // 
            // button1
            // 
            this.button1.Image = global::ISA.Toko.Properties.Resources.Printer32;
            this.button1.Location = new System.Drawing.Point(16, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "PROSES";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ISA.Toko.Properties.Resources.Close32;
            this.button2.Location = new System.Drawing.Point(283, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "CLOSE";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(132, 121);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "[CODE]";
            this.lookupSales1.Size = new System.Drawing.Size(275, 27);
            this.lookupSales1.TabIndex = 2;
            // 
            // CmdToExcel
            // 
            this.CmdToExcel.Location = new System.Drawing.Point(146, 180);
            this.CmdToExcel.Name = "CmdToExcel";
            this.CmdToExcel.Size = new System.Drawing.Size(108, 51);
            this.CmdToExcel.TabIndex = 8;
            this.CmdToExcel.Text = "TO EXCEL";
            this.CmdToExcel.UseVisualStyleBackColor = true;
            this.CmdToExcel.Visible = false;
            this.CmdToExcel.Click += new System.EventHandler(this.CmdToExcel_Click);
            // 
            // DateLaporan
            // 
            this.DateLaporan.DateValue = null;
            this.DateLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLaporan.Location = new System.Drawing.Point(138, 87);
            this.DateLaporan.MaxLength = 10;
            this.DateLaporan.Name = "DateLaporan";
            this.DateLaporan.Size = new System.Drawing.Size(116, 20);
            this.DateLaporan.TabIndex = 9;
            // 
            // FrmPOSLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 307);
            this.Controls.Add(this.DateLaporan);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmdToExcel);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPOSLaporan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Title = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmPOSLaporan_Load);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.CmdToExcel, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.DateLaporan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.LookupSales lookupSales1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CmdToExcel;
        private ISA.Toko.Controls.DateTextBox DateLaporan;
    }
}