namespace ISA.Toko.Controls
{
    partial class frmJadwalExpedisiLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJadwalExpedisiLookup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.GridJdwlExp = new ISA.Controls.CustomGridView();
            this.rowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPeriode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSearch = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridJdwlExp)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(428, 296);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 20;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // GridJdwlExp
            // 
            this.GridJdwlExp.AllowUserToAddRows = false;
            this.GridJdwlExp.AllowUserToDeleteRows = false;
            this.GridJdwlExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridJdwlExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridJdwlExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowID,
            this.Periode,
            this.NoPeriode,
            this.TglAwal,
            this.TglAkhir});
            this.GridJdwlExp.Location = new System.Drawing.Point(8, 86);
            this.GridJdwlExp.MultiSelect = false;
            this.GridJdwlExp.Name = "GridJdwlExp";
            this.GridJdwlExp.ReadOnly = true;
            this.GridJdwlExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridJdwlExp.Size = new System.Drawing.Size(520, 204);
            this.GridJdwlExp.StandardTab = true;
            this.GridJdwlExp.TabIndex = 21;
            this.GridJdwlExp.DoubleClick += new System.EventHandler(this.GridJdwlExp_DoubleClick);
            // 
            // rowID
            // 
            this.rowID.DataPropertyName = "rowID";
            this.rowID.HeaderText = "Row ID";
            this.rowID.Name = "rowID";
            this.rowID.ReadOnly = true;
            this.rowID.Visible = false;
            // 
            // Periode
            // 
            this.Periode.DataPropertyName = "Periode";
            this.Periode.HeaderText = "Periode";
            this.Periode.Name = "Periode";
            this.Periode.ReadOnly = true;
            // 
            // NoPeriode
            // 
            this.NoPeriode.DataPropertyName = "NoPeriode";
            this.NoPeriode.HeaderText = "No Periode";
            this.NoPeriode.Name = "NoPeriode";
            this.NoPeriode.ReadOnly = true;
            this.NoPeriode.Width = 90;
            // 
            // TglAwal
            // 
            this.TglAwal.DataPropertyName = "DateFromExpedisi";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TglAwal.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglAwal.HeaderText = "Batas Tgl Awal";
            this.TglAwal.Name = "TglAwal";
            this.TglAwal.ReadOnly = true;
            this.TglAwal.Width = 150;
            // 
            // TglAkhir
            // 
            this.TglAkhir.DataPropertyName = "DateToExpedisi";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.TglAkhir.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglAkhir.HeaderText = "Batas Tgl Akhir";
            this.TglAkhir.Name = "TglAkhir";
            this.TglAkhir.ReadOnly = true;
            this.TglAkhir.Width = 150;
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(448, 50);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 22;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmJadwalExpedisiLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 339);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.GridJdwlExp);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJadwalExpedisiLookup";
            this.Text = "Jadwal Expedisi";
            this.Title = "Jadwal Expedisi";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmJadwalExpedisiLookup_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.GridJdwlExp, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridJdwlExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommandButton cmdClose;
        private ISA.Controls.CustomGridView GridJdwlExp;
        private CommandButton cmdSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPeriode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglAkhir;
    }
}