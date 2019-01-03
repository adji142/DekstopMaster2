namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptTokoOrderBaruFilter 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptTokoOrderBaruFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeOrder = new ISA.Toko.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToko = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupSales = new ISA.Toko.Controls.LookupSales();
            this.a = new System.Windows.Forms.Label();
            this.cbWilID = new ISA.Toko.Controls.WilIDComboBox();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdCancel = new ISA.Toko.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal";
            // 
            // rangeOrder
            // 
            this.rangeOrder.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeOrder.FromDate = null;
            this.rangeOrder.Location = new System.Drawing.Point(86, 65);
            this.rangeOrder.Name = "rangeOrder";
            this.rangeOrder.Size = new System.Drawing.Size(257, 22);
            this.rangeOrder.TabIndex = 0;
            this.rangeOrder.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Toko";
            // 
            // txtToko
            // 
            this.txtToko.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToko.Location = new System.Drawing.Point(122, 105);
            this.txtToko.Name = "txtToko";
            this.txtToko.Size = new System.Drawing.Size(309, 20);
            this.txtToko.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Salesman";
            // 
            // lookupSales
            // 
            this.lookupSales.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales.Location = new System.Drawing.Point(120, 142);
            this.lookupSales.NamaSales = "";
            this.lookupSales.Name = "lookupSales";
            this.lookupSales.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales.SalesID = "";
            this.lookupSales.Size = new System.Drawing.Size(276, 54);
            this.lookupSales.TabIndex = 2;
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(28, 196);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(56, 14);
            this.a.TabIndex = 11;
            this.a.Text = "Id. Wil";
            // 
            // cbWilID
            // 
            this.cbWilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbWilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWilID.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbWilID.DisplayMember = "WilID";
            this.cbWilID.FormattingEnabled = true;
            this.cbWilID.Location = new System.Drawing.Point(124, 188);
            this.cbWilID.Name = "cbWilID";
            this.cbWilID.Size = new System.Drawing.Size(100, 22);
            this.cbWilID.TabIndex = 3;
            this.cbWilID.ValueMember = "WilID";
            this.cbWilID.WilID = "";
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(9, 266);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 4;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(352, 266);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "CANCEL";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click_1);
            // 
            // frmRptTokoOrderBaruFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(464, 318);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.cbWilID);
            this.Controls.Add(this.txtToko);
            this.Controls.Add(this.lookupSales);
            this.Controls.Add(this.a);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeOrder);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptTokoOrderBaruFilter";
            this.Text = "Toko Order Baru";
            this.Title = "Toko Order Baru";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptTokoOrderBaruFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeOrder, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.a, 0);
            this.Controls.SetChildIndex(this.lookupSales, 0);
            this.Controls.SetChildIndex(this.txtToko, 0);
            this.Controls.SetChildIndex(this.cbWilID, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rangeOrder;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtToko;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.LookupSales lookupSales;
        private System.Windows.Forms.Label a;
        private ISA.Toko.Controls.WilIDComboBox cbWilID;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdCancel;
    }
}
