namespace ISA.Toko.Laporan.Salesman
{
    partial class frmRptAnalisaSalesman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaSalesman));
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdNo = new ISA.Toko.Controls.CommandButton();
            this.rangeAnalisa = new ISA.Toko.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCabang = new ISA.Toko.Controls.CabangComboBox();
            this.SuspendLayout();
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 289);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 2;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(404, 289);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 3;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // rangeAnalisa
            // 
            this.rangeAnalisa.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeAnalisa.FromDate = null;
            this.rangeAnalisa.Location = new System.Drawing.Point(100, 66);
            this.rangeAnalisa.Name = "rangeAnalisa";
            this.rangeAnalisa.Size = new System.Drawing.Size(257, 22);
            this.rangeAnalisa.TabIndex = 0;
            this.rangeAnalisa.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tanggal ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cabang ";
            // 
            // cbCabang
            // 
            this.cbCabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCabang.CabangID = "";
            this.cbCabang.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbCabang.DisplayMember = "Concatenated";
            this.cbCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCabang.Font = new System.Drawing.Font("Courier New", 8F);
            this.cbCabang.FormattingEnabled = true;
            this.cbCabang.Location = new System.Drawing.Point(136, 103);
            this.cbCabang.Name = "cbCabang";
            this.cbCabang.Size = new System.Drawing.Size(180, 22);
            this.cbCabang.TabIndex = 1;
            this.cbCabang.ValueMember = "CabangID";
            // 
            // frmRptAnalisaSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(522, 341);
            this.Controls.Add(this.cbCabang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeAnalisa);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptAnalisaSalesman";
            this.Text = "Analisa Salesman";
            this.Title = "Analisa Salesman";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptAnalisaSalesman_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.rangeAnalisa, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbCabang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.RangeDateBox rangeAnalisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CabangComboBox cbCabang;
    }
}
