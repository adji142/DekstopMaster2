namespace ISA.Finance.Controls
{
    partial class frmDKNLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDKNLookup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.Tgl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_DKN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefNoBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tgl,
            this.No_DKN,
            this.RefNoBukti,
            this.NoPerkiraan,
            this.jml});
            this.customGridView1.Location = new System.Drawing.Point(6, 57);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(698, 232);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellDoubleClick);
            this.customGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customGridView1_CellContentDoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(604, 295);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName2 = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 4;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search";
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(343, 20);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.ReportName2 = "";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(81, 22);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // Tgl
            // 
            this.Tgl.DataPropertyName = "tgl";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.Tgl.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tgl.HeaderText = "Tanggal";
            this.Tgl.Name = "Tgl";
            this.Tgl.ReadOnly = true;
            // 
            // No_DKN
            // 
            this.No_DKN.DataPropertyName = "NoDKN";
            this.No_DKN.HeaderText = "NoDKN";
            this.No_DKN.Name = "No_DKN";
            this.No_DKN.ReadOnly = true;
            this.No_DKN.Width = 150;
            // 
            // RefNoBukti
            // 
            this.RefNoBukti.DataPropertyName = "RefNoBukti";
            this.RefNoBukti.HeaderText = "RefNoBukti";
            this.RefNoBukti.Name = "RefNoBukti";
            this.RefNoBukti.ReadOnly = true;
            this.RefNoBukti.Width = 150;
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NoPerkiraan";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Width = 150;
            // 
            // jml
            // 
            this.jml.DataPropertyName = "jml";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.jml.DefaultCellStyle = dataGridViewCellStyle2;
            this.jml.HeaderText = "Jumlah";
            this.jml.Name = "jml";
            this.jml.ReadOnly = true;
            this.jml.Width = 105;
            // 
            // frmDKNLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 341);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.customGridView1);
            this.Name = "frmDKNLookup";
            this.Text = "DKN";
            this.Load += new System.EventHandler(this.frmDKNLookup_Load);
            this.Shown += new System.EventHandler(this.frmDKNLookup_Shown);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tgl;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_DKN;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNoBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn jml;
    }
}