namespace ISA.Bengkel.Master
{
    partial class frmStandarServiceBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStandarServiceBrowse));
            this.dgMain = new ISA.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KD_SPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEPEDAMOTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDELETE = new ISA.Controls.CommandButton();
            this.cmdEDIT = new ISA.Controls.CommandButton();
            this.cmdADD = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMain
            // 
            this.dgMain.AllowUserToAddRows = false;
            this.dgMain.AllowUserToDeleteRows = false;
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.kode,
            this.kategori,
            this.KD_SPM,
            this.SEPEDAMOTOR,
            this.biaya});
            this.dgMain.Location = new System.Drawing.Point(9, 86);
            this.dgMain.MultiSelect = false;
            this.dgMain.Name = "dgMain";
            this.dgMain.ReadOnly = true;
            this.dgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgMain.Size = new System.Drawing.Size(1009, 362);
            this.dgMain.StandardTab = true;
            this.dgMain.TabIndex = 0;
            this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // kode
            // 
            this.kode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.kode.DataPropertyName = "kode";
            this.kode.FillWeight = 182.7411F;
            this.kode.HeaderText = "KODE";
            this.kode.Name = "kode";
            this.kode.ReadOnly = true;
            this.kode.Width = 120;
            // 
            // kategori
            // 
            this.kategori.DataPropertyName = "kategori";
            this.kategori.FillWeight = 83.45177F;
            this.kategori.HeaderText = "KATEGORI";
            this.kategori.Name = "kategori";
            this.kategori.ReadOnly = true;
            // 
            // KD_SPM
            // 
            this.KD_SPM.DataPropertyName = "kd_spm";
            this.KD_SPM.HeaderText = "KD. SPM";
            this.KD_SPM.Name = "KD_SPM";
            this.KD_SPM.ReadOnly = true;
            // 
            // SEPEDAMOTOR
            // 
            this.SEPEDAMOTOR.DataPropertyName = "jns_spm";
            this.SEPEDAMOTOR.HeaderText = "SEPEDA MOTOR";
            this.SEPEDAMOTOR.Name = "SEPEDAMOTOR";
            this.SEPEDAMOTOR.ReadOnly = true;
            // 
            // biaya
            // 
            this.biaya.DataPropertyName = "biaya";
            this.biaya.HeaderText = "BIAYA";
            this.biaya.Name = "biaya";
            this.biaya.ReadOnly = true;
            // 
            // cmdDELETE
            // 
            this.cmdDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDELETE.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDELETE.Image = ((System.Drawing.Image)(resources.GetObject("cmdDELETE.Image")));
            this.cmdDELETE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDELETE.Location = new System.Drawing.Point(256, 454);
            this.cmdDELETE.Name = "cmdDELETE";
            this.cmdDELETE.Size = new System.Drawing.Size(100, 40);
            this.cmdDELETE.TabIndex = 3;
            this.cmdDELETE.Text = "DELETE";
            this.cmdDELETE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDELETE.UseVisualStyleBackColor = true;
            this.cmdDELETE.Click += new System.EventHandler(this.cmdDELETE_Click);
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEDIT.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdEDIT.Image")));
            this.cmdEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEDIT.Location = new System.Drawing.Point(132, 454);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdEDIT.TabIndex = 2;
            this.cmdEDIT.Text = "EDIT";
            this.cmdEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdADD
            // 
            this.cmdADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdADD.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdADD.Image")));
            this.cmdADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdADD.Location = new System.Drawing.Point(9, 454);
            this.cmdADD.Name = "cmdADD";
            this.cmdADD.Size = new System.Drawing.Size(100, 40);
            this.cmdADD.TabIndex = 1;
            this.cmdADD.Text = "ADD";
            this.cmdADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdADD.UseVisualStyleBackColor = true;
            this.cmdADD.Click += new System.EventHandler(this.cmdADD_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(918, 454);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmStandarServiceBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1028, 510);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDELETE);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.cmdADD);
            this.Controls.Add(this.dgMain);
            this.FormID = "BKL0040";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStandarServiceBrowse";
            this.Text = "BKL0040 - Standar Service";
            this.Title = "Standar Service";
            this.Load += new System.EventHandler(this.frmStandarServiceBrowse_Load);
            this.Controls.SetChildIndex(this.dgMain, 0);
            this.Controls.SetChildIndex(this.cmdADD, 0);
            this.Controls.SetChildIndex(this.cmdEDIT, 0);
            this.Controls.SetChildIndex(this.cmdDELETE, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView dgMain;
        private ISA.Controls.CommandButton cmdDELETE;
        private ISA.Controls.CommandButton cmdEDIT;
        private ISA.Controls.CommandButton cmdADD;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategori;
        private System.Windows.Forms.DataGridViewTextBoxColumn KD_SPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEPEDAMOTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn biaya;
    }
}
