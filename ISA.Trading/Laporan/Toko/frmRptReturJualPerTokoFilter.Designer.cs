namespace ISA.Trading.Laporan.Toko
{
    partial class frmRptReturJualPerTokoFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReturJualPerTokoFilter));
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.lkptoko = new ISA.Trading.Controls.LookupToko();
            this.rngDateTextBox = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOk = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // cmdNo
            // 
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(215, 135);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 3;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // lkptoko
            // 
            this.lkptoko.Alamat = null;
            this.lkptoko.Daerah = null;
            this.lkptoko.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lkptoko.HariKirim = 0;
            this.lkptoko.HariSales = 0;
            this.lkptoko.KodeToko = "";
            this.lkptoko.Kota = null;
            this.lkptoko.Location = new System.Drawing.Point(92, 78);
            this.lkptoko.NamaToko = "";
            this.lkptoko.Name = "lkptoko";
            this.lkptoko.Propinsi = null;
            this.lkptoko.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lkptoko.Size = new System.Drawing.Size(300, 54);
            this.lkptoko.TabIndex = 1;
            this.lkptoko.TokoID = null;
            this.lkptoko.WilID = "";
            // 
            // rngDateTextBox
            // 
            this.rngDateTextBox.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rngDateTextBox.FromDate = null;
            this.rngDateTextBox.Location = new System.Drawing.Point(58, 50);
            this.rngDateTextBox.Name = "rngDateTextBox";
            this.rngDateTextBox.Size = new System.Drawing.Size(257, 22);
            this.rngDateTextBox.TabIndex = 0;
            this.rngDateTextBox.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Toko";
            // 
            // cmdOk
            // 
            this.cmdOk.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdOk.Image = ((System.Drawing.Image)(resources.GetObject("cmdOk.Image")));
            this.cmdOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOk.Location = new System.Drawing.Point(92, 135);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.ReportName = "";
            this.cmdOk.Size = new System.Drawing.Size(100, 40);
            this.cmdOk.TabIndex = 2;
            this.cmdOk.Text = "PRINT";
            this.cmdOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmRptReturJualPerTokoFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(426, 230);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.lkptoko);
            this.Controls.Add(this.rngDateTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOk);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptReturJualPerTokoFilter";
            this.Text = "Retur Jual Per Toko";
            this.Title = "Retur Jual Per Toko";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptReturJualPerTokoFilter_Load);
            this.Controls.SetChildIndex(this.cmdOk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rngDateTextBox, 0);
            this.Controls.SetChildIndex(this.lkptoko, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.LookupToko lkptoko;
        private ISA.Trading.Controls.RangeDateBox rngDateTextBox;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdOk;
    }
}
