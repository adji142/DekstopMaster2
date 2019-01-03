namespace ISA.Toko.Controls
{
    partial class frmArmadaKirimLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArmadaKirimLookup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.gvArmadaKirim = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeArmada2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraan2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomorPolisi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TripMeterKM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMPerLiter2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvArmadaKirim)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(526, 236);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(420, 236);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 7;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // gvArmadaKirim
            // 
            this.gvArmadaKirim.AllowUserToAddRows = false;
            this.gvArmadaKirim.AllowUserToDeleteRows = false;
            this.gvArmadaKirim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvArmadaKirim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvArmadaKirim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArmadaKirim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.KodeArmada2,
            this.Kendaraan2,
            this.NomorPolisi2,
            this.TripMeterKM2,
            this.KMPerLiter2,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.gvArmadaKirim.Location = new System.Drawing.Point(26, 50);
            this.gvArmadaKirim.MultiSelect = false;
            this.gvArmadaKirim.Name = "gvArmadaKirim";
            this.gvArmadaKirim.ReadOnly = true;
            this.gvArmadaKirim.RowHeadersVisible = false;
            this.gvArmadaKirim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvArmadaKirim.Size = new System.Drawing.Size(600, 170);
            this.gvArmadaKirim.StandardTab = true;
            this.gvArmadaKirim.TabIndex = 9;
            this.gvArmadaKirim.DoubleClick += new System.EventHandler(this.gvArmadaKirim_DoubleClick);
            this.gvArmadaKirim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvArmadaKirim_KeyDown);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // KodeArmada2
            // 
            this.KodeArmada2.DataPropertyName = "KodeArmada";
            this.KodeArmada2.HeaderText = "KodeArmada";
            this.KodeArmada2.Name = "KodeArmada2";
            this.KodeArmada2.ReadOnly = true;
            this.KodeArmada2.Width = 150;
            // 
            // Kendaraan2
            // 
            this.Kendaraan2.DataPropertyName = "Kendaraan";
            this.Kendaraan2.HeaderText = "Kendaraan";
            this.Kendaraan2.Name = "Kendaraan2";
            this.Kendaraan2.ReadOnly = true;
            this.Kendaraan2.Width = 150;
            // 
            // NomorPolisi2
            // 
            this.NomorPolisi2.DataPropertyName = "NomorPolisi";
            this.NomorPolisi2.HeaderText = "NomorPolisi";
            this.NomorPolisi2.Name = "NomorPolisi2";
            this.NomorPolisi2.ReadOnly = true;
            this.NomorPolisi2.Width = 150;
            // 
            // TripMeterKM2
            // 
            this.TripMeterKM2.DataPropertyName = "TripMeterKM";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TripMeterKM2.DefaultCellStyle = dataGridViewCellStyle1;
            this.TripMeterKM2.HeaderText = "TripMeterKM";
            this.TripMeterKM2.Name = "TripMeterKM2";
            this.TripMeterKM2.ReadOnly = true;
            // 
            // KMPerLiter2
            // 
            this.KMPerLiter2.DataPropertyName = "KMPerLiter";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KMPerLiter2.DefaultCellStyle = dataGridViewCellStyle2;
            this.KMPerLiter2.HeaderText = "KMPerLiter";
            this.KMPerLiter2.Name = "KMPerLiter2";
            this.KMPerLiter2.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "LastUpdatedBy";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // frmArmadaKirimLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 281);
            this.Controls.Add(this.gvArmadaKirim);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmArmadaKirimLookup";
            this.Text = "Armada Kirim Lookup";
            this.Title = "Armada Kirim Lookup";
            this.Load += new System.EventHandler(this.frmArmadaKirimLookup_Load);
            this.Shown += new System.EventHandler(this.frmArmadaKirimLookup_Shown);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.gvArmadaKirim, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvArmadaKirim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdYes;
        private ISA.Controls.CustomGridView gvArmadaKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeArmada2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomorPolisi2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TripMeterKM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMPerLiter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}