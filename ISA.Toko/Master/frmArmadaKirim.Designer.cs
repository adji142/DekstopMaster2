namespace ISA.Toko.Master
{
    partial class frmArmadaKirim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArmadaKirim));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvArmadaKirim = new ISA.Toko.Controls.CustomGridView();
            this.btnAdd = new ISA.Toko.Controls.CommandButton();
            this.btnDelete = new ISA.Toko.Controls.CommandButton();
            this.btnClose = new ISA.Toko.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeArmada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kendaraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomorPolisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TripMeterKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KMPerLiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvArmadaKirim)).BeginInit();
            this.SuspendLayout();
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
            this.KodeArmada,
            this.Kendaraan,
            this.NomorPolisi,
            this.TripMeterKM,
            this.KMPerLiter,
            this.LastUpdatedBy,
            this.LastUpdatedTime});
            this.gvArmadaKirim.Location = new System.Drawing.Point(26, 69);
            this.gvArmadaKirim.MultiSelect = false;
            this.gvArmadaKirim.Name = "gvArmadaKirim";
            this.gvArmadaKirim.ReadOnly = true;
            this.gvArmadaKirim.RowHeadersVisible = false;
            this.gvArmadaKirim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvArmadaKirim.Size = new System.Drawing.Size(656, 150);
            this.gvArmadaKirim.StandardTab = true;
            this.gvArmadaKirim.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(26, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Delete;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(157, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(582, 240);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // KodeArmada
            // 
            this.KodeArmada.DataPropertyName = "KodeArmada";
            this.KodeArmada.HeaderText = "Kode Armada";
            this.KodeArmada.Name = "KodeArmada";
            this.KodeArmada.ReadOnly = true;
            this.KodeArmada.Width = 150;
            // 
            // Kendaraan
            // 
            this.Kendaraan.DataPropertyName = "Kendaraan";
            this.Kendaraan.HeaderText = "Kendaraan";
            this.Kendaraan.Name = "Kendaraan";
            this.Kendaraan.ReadOnly = true;
            // 
            // NomorPolisi
            // 
            this.NomorPolisi.DataPropertyName = "NomorPolisi";
            this.NomorPolisi.HeaderText = "NomorPolisi";
            this.NomorPolisi.Name = "NomorPolisi";
            this.NomorPolisi.ReadOnly = true;
            // 
            // TripMeterKM
            // 
            this.TripMeterKM.DataPropertyName = "TripMeterKM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TripMeterKM.DefaultCellStyle = dataGridViewCellStyle3;
            this.TripMeterKM.HeaderText = "TripMeterKM";
            this.TripMeterKM.Name = "TripMeterKM";
            this.TripMeterKM.ReadOnly = true;
            // 
            // KMPerLiter
            // 
            this.KMPerLiter.DataPropertyName = "KMPerLiter";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KMPerLiter.DefaultCellStyle = dataGridViewCellStyle4;
            this.KMPerLiter.HeaderText = "KMPerLiter";
            this.KMPerLiter.Name = "KMPerLiter";
            this.KMPerLiter.ReadOnly = true;
            // 
            // LastUpdatedBy
            // 
            this.LastUpdatedBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdatedBy.HeaderText = "Last Updated By";
            this.LastUpdatedBy.Name = "LastUpdatedBy";
            this.LastUpdatedBy.ReadOnly = true;
            this.LastUpdatedBy.Visible = false;
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "Last Updated Time";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            this.LastUpdatedTime.ReadOnly = true;
            this.LastUpdatedTime.Visible = false;
            // 
            // frmArmadaKirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 290);
            this.Controls.Add(this.gvArmadaKirim);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmArmadaKirim";
            this.Text = "Armada Kirim";
            this.Title = "Armada Kirim";
            this.Load += new System.EventHandler(this.frmArmadaKirim_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.gvArmadaKirim, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gvArmadaKirim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CustomGridView gvArmadaKirim;
        private ISA.Toko.Controls.CommandButton btnAdd;
        private ISA.Toko.Controls.CommandButton btnDelete;
        private ISA.Toko.Controls.CommandButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeArmada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kendaraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomorPolisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TripMeterKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn KMPerLiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;
    }
}