namespace ISA.Trading.Fixrute
{
    partial class frmMasterFixSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterFixSales));
            this.panel1 = new System.Windows.Forms.Panel();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesLapangan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customGridView1);
            this.panel1.Location = new System.Drawing.Point(19, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 232);
            this.panel1.TabIndex = 5;
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.KodeSales,
            this.NamaSales,
            this.SalesLapangan});
            this.customGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customGridView1.Location = new System.Drawing.Point(0, 0);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(565, 232);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 0;
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "Row ID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "kd_sales";
            this.KodeSales.HeaderText = "Kode Sales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            this.KodeSales.Width = 150;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "nm_sales";
            this.NamaSales.HeaderText = "Nama Sales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            this.NamaSales.Width = 300;
            // 
            // SalesLapangan
            // 
            this.SalesLapangan.DataPropertyName = "idrec";
            this.SalesLapangan.FalseValue = "0";
            this.SalesLapangan.HeaderText = "Sales Lapangan";
            this.SalesLapangan.Name = "SalesLapangan";
            this.SalesLapangan.ReadOnly = true;
            this.SalesLapangan.TrueValue = "1";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(481, 326);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 61;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDelete.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(230, 326);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 60;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.None;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = global::ISA.Trading.Properties.Resources.Edit32;
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(124, 326);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 59;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(18, 326);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 58;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmMasterFixSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 403);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMasterFixSales";
            this.Text = "Master Fix Sales";
            this.Title = "Master Fix Sales";
            this.Load += new System.EventHandler(this.frmMasterFixSales_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        //private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SalesLapangan;
        private ISA.Trading.Controls.CommandButton cmdEdit;
    }
}