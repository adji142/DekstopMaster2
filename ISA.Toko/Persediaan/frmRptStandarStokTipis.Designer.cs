namespace ISA.Toko.Persediaan
{
    partial class frmRptStandarStokTipis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStandarStokTipis));
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.tglForm = new ISA.Toko.Controls.DateTextBox();
            this.TglRequest = new ISA.Toko.Controls.DateTextBox();
            this.cboKel = new System.Windows.Forms.ComboBox();
            this.cboLink = new System.Windows.Forms.ComboBox();
            this.cboSup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoRequest = new ISA.Toko.Controls.CommonTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 289);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 6;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(358, 289);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 7;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // tglForm
            // 
            this.tglForm.DateValue = null;
            this.tglForm.Location = new System.Drawing.Point(143, 63);
            this.tglForm.MaxLength = 10;
            this.tglForm.Name = "tglForm";
            this.tglForm.Size = new System.Drawing.Size(88, 20);
            this.tglForm.TabIndex = 0;
            // 
            // TglRequest
            // 
            this.TglRequest.DateValue = null;
            this.TglRequest.Location = new System.Drawing.Point(143, 120);
            this.TglRequest.MaxLength = 10;
            this.TglRequest.Name = "TglRequest";
            this.TglRequest.Size = new System.Drawing.Size(80, 20);
            this.TglRequest.TabIndex = 3;
            // 
            // cboKel
            // 
            this.cboKel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKel.FormattingEnabled = true;
            this.cboKel.Location = new System.Drawing.Point(143, 92);
            this.cboKel.Name = "cboKel";
            this.cboKel.Size = new System.Drawing.Size(66, 22);
            this.cboKel.TabIndex = 1;
            // 
            // cboLink
            // 
            this.cboLink.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLink.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLink.FormattingEnabled = true;
            this.cboLink.Items.AddRange(new object[] {
            "Ya",
            "Tidak"});
            this.cboLink.Location = new System.Drawing.Point(378, 98);
            this.cboLink.Name = "cboLink";
            this.cboLink.Size = new System.Drawing.Size(66, 22);
            this.cboLink.TabIndex = 2;
            this.cboLink.Visible = false;
            this.cboLink.Leave += new System.EventHandler(this.cboLink_Leave);
            this.cboLink.TextChanged += new System.EventHandler(this.cboLink_TextChanged);
            // 
            // cboSup
            // 
            this.cboSup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSup.FormattingEnabled = true;
            this.cboSup.Location = new System.Drawing.Point(143, 178);
            this.cboSup.Name = "cboSup";
            this.cboSup.Size = new System.Drawing.Size(171, 22);
            this.cboSup.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kelompok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Link Ke PBO";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tanggal Request";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Supplier";
            // 
            // txtNoRequest
            // 
            this.txtNoRequest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoRequest.Location = new System.Drawing.Point(143, 146);
            this.txtNoRequest.Name = "txtNoRequest";
            this.txtNoRequest.Size = new System.Drawing.Size(100, 20);
            this.txtNoRequest.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "No. Request";
            // 
            // frmRptStandarStokTipis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(470, 341);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNoRequest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSup);
            this.Controls.Add(this.cboLink);
            this.Controls.Add(this.cboKel);
            this.Controls.Add(this.TglRequest);
            this.Controls.Add(this.tglForm);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptStandarStokTipis";
            this.Text = "Laporan Stok Tipis";
            this.Title = "Laporan Stok Tipis";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptStandarStokTipis_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.tglForm, 0);
            this.Controls.SetChildIndex(this.TglRequest, 0);
            this.Controls.SetChildIndex(this.cboKel, 0);
            this.Controls.SetChildIndex(this.cboLink, 0);
            this.Controls.SetChildIndex(this.cboSup, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNoRequest, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.DateTextBox tglForm;
        private ISA.Toko.Controls.DateTextBox TglRequest;
        private System.Windows.Forms.ComboBox cboKel;
        private System.Windows.Forms.ComboBox cboLink;
        private System.Windows.Forms.ComboBox cboSup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommonTextBox txtNoRequest;
        private System.Windows.Forms.Label label6;
    }
}
