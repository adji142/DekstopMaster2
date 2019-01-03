namespace ISA.Trading.Persediaan
    {
    partial class frmRptStandarStokBanyak
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStandarStokBanyak));
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.cboKel = new System.Windows.Forms.ComboBox();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Print;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(9, 190);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.ReportName = "";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 2;
                this.cmdYes.Text = "PRINT";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(457, 190);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.ReportName = "";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 3;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // dateTextBox1
                // 
                this.dateTextBox1.DateValue = null;
                this.dateTextBox1.Location = new System.Drawing.Point(121, 63);
                this.dateTextBox1.MaxLength = 10;
                this.dateTextBox1.Name = "dateTextBox1";
                this.dateTextBox1.Size = new System.Drawing.Size(121, 20);
                this.dateTextBox1.TabIndex = 0;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(26, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(49, 14);
                this.label1.TabIndex = 8;
                this.label1.Text = "Tanggal";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(26, 101);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(63, 14);
                this.label2.TabIndex = 9;
                this.label2.Text = "Kelompok";
                // 
                // cboKel
                // 
                this.cboKel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.cboKel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                this.cboKel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboKel.FormattingEnabled = true;
                this.cboKel.Location = new System.Drawing.Point(121, 93);
                this.cboKel.Name = "cboKel";
                this.cboKel.Size = new System.Drawing.Size(121, 22);
                this.cboKel.TabIndex = 1;
                // 
                // frmRptStandarStokBanyak
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(569, 241);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.dateTextBox1);
                this.Controls.Add(this.cboKel);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdYes);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptStandarStokBanyak";
                this.Text = "Laporan Stok Banyak";
                this.Title = "Laporan Stok Banyak";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptStandarStokBanyak_Load);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.cboKel, 0);
                this.Controls.SetChildIndex(this.dateTextBox1, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKel;
        }
    }
