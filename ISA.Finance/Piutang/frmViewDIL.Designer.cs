namespace ISA.Finance.Piutang
{
    partial class frmViewDIL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewDIL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.NoPot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPot,
            this.TglPot,
            this.Dil,
            this.PotID,
            this.RowID});
            this.customGridView1.Location = new System.Drawing.Point(18, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(507, 195);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(425, 237);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // NoPot
            // 
            this.NoPot.DataPropertyName = "NoPot";
            this.NoPot.HeaderText = "No Pot (DIL)";
            this.NoPot.Name = "NoPot";
            this.NoPot.ReadOnly = true;
            // 
            // TglPot
            // 
            this.TglPot.DataPropertyName = "TglPot";
            dataGridViewCellStyle7.Format = "dd MMM yyyy";
            this.TglPot.DefaultCellStyle = dataGridViewCellStyle7;
            this.TglPot.HeaderText = "Tgl Pot (DIL)";
            this.TglPot.Name = "TglPot";
            this.TglPot.ReadOnly = true;
            // 
            // Dil
            // 
            this.Dil.DataPropertyName = "Dil";
            dataGridViewCellStyle8.Format = "#,##0";
            this.Dil.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dil.HeaderText = "Pot (DIL)";
            this.Dil.Name = "Dil";
            this.Dil.ReadOnly = true;
            // 
            // PotID
            // 
            this.PotID.DataPropertyName = "PotID";
            this.PotID.HeaderText = "PotID";
            this.PotID.Name = "PotID";
            this.PotID.ReadOnly = true;
            this.PotID.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmViewDIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(543, 301);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmViewDIL";
            this.Text = "";
            this.Title = "";
            this.Load += new System.EventHandler(this.frmViewDIL_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dil;
        private System.Windows.Forms.DataGridViewTextBoxColumn PotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
