namespace ISA.Toko.Kasir
{
    partial class frmLookupBPP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLookupBPP));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.NoBPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeCollector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeGudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPerkiraan = new System.Windows.Forms.TextBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.customGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 299);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.customGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.customGridView1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoBPP,
            this.KodeCollector,
            this.KodeGudang});
            this.customGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.customGridView1.Location = new System.Drawing.Point(3, 3);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(689, 293);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            this.customGridView1.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.customGridView1_ColumnAdded);
            // 
            // NoBPP
            // 
            this.NoBPP.DataPropertyName = "NoBPP";
            this.NoBPP.HeaderText = "NoBPP";
            this.NoBPP.Name = "NoBPP";
            this.NoBPP.ReadOnly = true;
            // 
            // KodeCollector
            // 
            this.KodeCollector.DataPropertyName = "KodeCollector";
            this.KodeCollector.HeaderText = "Kode Collector";
            this.KodeCollector.Name = "KodeCollector";
            this.KodeCollector.ReadOnly = true;
            // 
            // KodeGudang
            // 
            this.KodeGudang.DataPropertyName = "KodeGudang";
            this.KodeGudang.HeaderText = "Kode Gudang";
            this.KodeGudang.Name = "KodeGudang";
            this.KodeGudang.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search";
            // 
            // txtPerkiraan
            // 
            this.txtPerkiraan.Location = new System.Drawing.Point(81, 37);
            this.txtPerkiraan.MaxLength = 12;
            this.txtPerkiraan.Name = "txtPerkiraan";
            this.txtPerkiraan.Size = new System.Drawing.Size(237, 20);
            this.txtPerkiraan.TabIndex = 1;
            this.txtPerkiraan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerkiraan_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(324, 35);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 2;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(624, 389);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 4;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmLookupBPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPerkiraan);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.commandButton2);
            this.Name = "frmLookupBPP";
            this.Text = "frmLookupBPP";
            this.Load += new System.EventHandler(this.frmLookupBPP_Load);
            this.Shown += new System.EventHandler(this.frmLookupBPP_Shown);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.txtPerkiraan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ISA.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPerkiraan;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoBPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeGudang;

    }
}