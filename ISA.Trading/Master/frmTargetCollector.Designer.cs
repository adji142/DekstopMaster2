namespace ISA.Trading.Master
{
    partial class frmTargetCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetCollector));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdBtnSearch = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.cmdBtnEDIT = new ISA.Trading.Controls.CommandButton();
            this.cmdBtnADD = new ISA.Trading.Controls.CommandButton();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.cgvGridCollector = new ISA.Trading.Controls.CustomGridView();
            this.colrowid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kunjungan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cgvGridCollector)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBtnSearch
            // 
            this.cmdBtnSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchL;
            this.cmdBtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnSearch.Image")));
            this.cmdBtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnSearch.Location = new System.Drawing.Point(586, 73);
            this.cmdBtnSearch.Name = "cmdBtnSearch";
            this.cmdBtnSearch.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnSearch.TabIndex = 4;
            this.cmdBtnSearch.Text = "SEARCH";
            this.cmdBtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnSearch.UseVisualStyleBackColor = true;
            this.cmdBtnSearch.Click += new System.EventHandler(this.cmdBtnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collector";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periode";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(95, 89);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(242, 24);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdBtnEDIT
            // 
            this.cmdBtnEDIT.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdBtnEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnEDIT.Image")));
            this.cmdBtnEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnEDIT.Location = new System.Drawing.Point(127, 343);
            this.cmdBtnEDIT.Name = "cmdBtnEDIT";
            this.cmdBtnEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnEDIT.TabIndex = 7;
            this.cmdBtnEDIT.Text = "EDIT";
            this.cmdBtnEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnEDIT.UseVisualStyleBackColor = true;
            this.cmdBtnEDIT.Click += new System.EventHandler(this.cmdBtnEDIT_Click);
            // 
            // cmdBtnADD
            // 
            this.cmdBtnADD.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdBtnADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnADD.Image")));
            this.cmdBtnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnADD.Location = new System.Drawing.Point(15, 343);
            this.cmdBtnADD.Name = "cmdBtnADD";
            this.cmdBtnADD.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnADD.TabIndex = 6;
            this.cmdBtnADD.Text = "ADD";
            this.cmdBtnADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnADD.UseVisualStyleBackColor = true;
            this.cmdBtnADD.Click += new System.EventHandler(this.cmdBtnADD_Click);
            // 
            // cmbCollector
            // 
            this.cmbCollector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Location = new System.Drawing.Point(439, 91);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(121, 22);
            this.cmbCollector.TabIndex = 3;
            // 
            // cgvGridCollector
            // 
            this.cgvGridCollector.AllowUserToAddRows = false;
            this.cgvGridCollector.AllowUserToDeleteRows = false;
            this.cgvGridCollector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cgvGridCollector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colrowid,
            this.tmt,
            this.kunjungan,
            this.tagih,
            this.nominal});
            this.cgvGridCollector.Location = new System.Drawing.Point(15, 119);
            this.cgvGridCollector.MultiSelect = false;
            this.cgvGridCollector.Name = "cgvGridCollector";
            this.cgvGridCollector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cgvGridCollector.Size = new System.Drawing.Size(678, 209);
            this.cgvGridCollector.StandardTab = true;
            this.cgvGridCollector.TabIndex = 5;
            // 
            // colrowid
            // 
            this.colrowid.DataPropertyName = "rowID";
            dataGridViewCellStyle1.NullValue = null;
            this.colrowid.DefaultCellStyle = dataGridViewCellStyle1;
            this.colrowid.HeaderText = "rowID";
            this.colrowid.Name = "colrowid";
            this.colrowid.Visible = false;
            // 
            // tmt
            // 
            this.tmt.DataPropertyName = "tglaktif";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.tmt.DefaultCellStyle = dataGridViewCellStyle2;
            this.tmt.HeaderText = "T.M.T.";
            this.tmt.Name = "tmt";
            this.tmt.Width = 150;
            // 
            // kunjungan
            // 
            this.kunjungan.DataPropertyName = "kunjungan";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.kunjungan.DefaultCellStyle = dataGridViewCellStyle3;
            this.kunjungan.HeaderText = "Toko Kunjungan";
            this.kunjungan.Name = "kunjungan";
            this.kunjungan.Width = 150;
            // 
            // tagih
            // 
            this.tagih.DataPropertyName = "tagih";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.tagih.DefaultCellStyle = dataGridViewCellStyle4;
            this.tagih.HeaderText = "Tagih";
            this.tagih.Name = "tagih";
            this.tagih.Width = 150;
            // 
            // nominal
            // 
            this.nominal.DataPropertyName = "nominal";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.nominal.DefaultCellStyle = dataGridViewCellStyle5;
            this.nominal.HeaderText = "Nominal";
            this.nominal.Name = "nominal";
            this.nominal.Width = 185;
            // 
            // frmTargetCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 407);
            this.Controls.Add(this.cgvGridCollector);
            this.Controls.Add(this.cmbCollector);
            this.Controls.Add(this.cmdBtnEDIT);
            this.Controls.Add(this.cmdBtnADD);
            this.Controls.Add(this.cmdBtnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetCollector";
            this.Text = "Target Collector";
            this.Title = "Target Collector";
            this.Load += new System.EventHandler(this.frmTargetCollector_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdBtnSearch, 0);
            this.Controls.SetChildIndex(this.cmdBtnADD, 0);
            this.Controls.SetChildIndex(this.cmdBtnEDIT, 0);
            this.Controls.SetChildIndex(this.cmbCollector, 0);
            this.Controls.SetChildIndex(this.cgvGridCollector, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cgvGridCollector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdBtnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private ISA.Trading.Controls.CommandButton cmdBtnEDIT;
        private ISA.Trading.Controls.CommandButton cmdBtnADD;
        private System.Windows.Forms.ComboBox cmbCollector;
        private ISA.Trading.Controls.CustomGridView cgvGridCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrowid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn kunjungan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagih;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
    }
}