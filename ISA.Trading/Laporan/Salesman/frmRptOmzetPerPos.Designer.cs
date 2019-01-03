namespace ISA.Trading.Laporan.Salesman
{
    partial class frmRptOmzetPerPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOmzetPerPos));
            this.label2 = new System.Windows.Forms.Label();
            this.cboCab = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNo = new ISA.Trading.Controls.CommandButton();
            this.cmdYes = new ISA.Trading.Controls.CommandButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdbA = new System.Windows.Forms.RadioButton();
            this.fromDate = new ISA.Trading.Controls.DateTextBox();
            this.toDate = new ISA.Trading.Controls.DateTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cabang";
            // 
            // cboCab
            // 
            this.cboCab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCab.FormattingEnabled = true;
            this.cboCab.Location = new System.Drawing.Point(126, 115);
            this.cboCab.MaxDropDownItems = 12;
            this.cboCab.Name = "cboCab";
            this.cboCab.Size = new System.Drawing.Size(215, 22);
            this.cboCab.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tanggal";
            // 
            // cmdNo
            // 
            this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
            this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNo.Location = new System.Drawing.Point(404, 289);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.ReportName = "";
            this.cmdNo.Size = new System.Drawing.Size(100, 40);
            this.cmdNo.TabIndex = 4;
            this.cmdNo.Text = "CANCEL";
            this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(12, 289);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.ReportName = "";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 3;
            this.cmdYes.Text = "PRINT";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "Pilihan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.rdbA);
            this.groupBox1.Location = new System.Drawing.Point(126, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(104, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Brutto";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rdbA
            // 
            this.rdbA.AutoSize = true;
            this.rdbA.Checked = true;
            this.rdbA.Location = new System.Drawing.Point(29, 19);
            this.rdbA.Name = "rdbA";
            this.rdbA.Size = new System.Drawing.Size(54, 18);
            this.rdbA.TabIndex = 0;
            this.rdbA.TabStop = true;
            this.rdbA.Text = "Netto";
            this.rdbA.UseVisualStyleBackColor = true;
            // 
            // fromDate
            // 
            this.fromDate.DateValue = null;
            this.fromDate.Location = new System.Drawing.Point(126, 69);
            this.fromDate.MaxLength = 10;
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(80, 20);
            this.fromDate.TabIndex = 0;
            this.fromDate.Leave += new System.EventHandler(this.fromDate_Leave);
            // 
            // toDate
            // 
            this.toDate.DateValue = null;
            this.toDate.Location = new System.Drawing.Point(230, 69);
            this.toDate.MaxLength = 10;
            this.toDate.Name = "toDate";
            this.toDate.ReadOnly = true;
            this.toDate.Size = new System.Drawing.Size(80, 20);
            this.toDate.TabIndex = 1;
            this.toDate.TabStop = false;
            // 
            // frmRptOmzetPerPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(516, 341);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptOmzetPerPos";
            this.Text = "Rekap Omzet Per Pos";
            this.Title = "Rekap Omzet Per Pos";
            this.Load += new System.EventHandler(this.frmRptOmzetPerPos_Load);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboCab, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.fromDate, 0);
            this.Controls.SetChildIndex(this.toDate, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCab;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rdbA;
        private ISA.Trading.Controls.DateTextBox fromDate;
        private ISA.Trading.Controls.DateTextBox toDate;
    }
}
