namespace ISA.Trading.Master
{
    partial class frmPromo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewPromo = new ISA.Controls.CustomGridView();
            this.commandButtonEdit = new ISA.Trading.Controls.CommandButton();
            this.commandButtonAdd = new ISA.Trading.Controls.CommandButton();
            this.TglMulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSelesai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPromo)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewPromo
            // 
            this.DataGridViewPromo.AllowUserToAddRows = false;
            this.DataGridViewPromo.AllowUserToDeleteRows = false;
            this.DataGridViewPromo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewPromo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewPromo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglMulai,
            this.TglSelesai,
            this.Keterangan,
            this.Status,
            this.StatusAktif,
            this.RowID});
            this.DataGridViewPromo.Location = new System.Drawing.Point(12, 43);
            this.DataGridViewPromo.MultiSelect = false;
            this.DataGridViewPromo.Name = "DataGridViewPromo";
            this.DataGridViewPromo.ReadOnly = true;
            this.DataGridViewPromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridViewPromo.Size = new System.Drawing.Size(809, 400);
            this.DataGridViewPromo.StandardTab = true;
            this.DataGridViewPromo.TabIndex = 6;
            // 
            // commandButtonEdit
            // 
            this.commandButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButtonEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.commandButtonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("commandButtonEdit.Image")));
            this.commandButtonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButtonEdit.Location = new System.Drawing.Point(114, 449);
            this.commandButtonEdit.Name = "commandButtonEdit";
            this.commandButtonEdit.Size = new System.Drawing.Size(100, 40);
            this.commandButtonEdit.TabIndex = 11;
            this.commandButtonEdit.Text = "EDIT";
            this.commandButtonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButtonEdit.UseVisualStyleBackColor = true;
            this.commandButtonEdit.Click += new System.EventHandler(this.commandButtonEdit_Click);
            // 
            // commandButtonAdd
            // 
            this.commandButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButtonAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.commandButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("commandButtonAdd.Image")));
            this.commandButtonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButtonAdd.Location = new System.Drawing.Point(12, 449);
            this.commandButtonAdd.Name = "commandButtonAdd";
            this.commandButtonAdd.Size = new System.Drawing.Size(100, 40);
            this.commandButtonAdd.TabIndex = 10;
            this.commandButtonAdd.Text = "ADD";
            this.commandButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButtonAdd.UseVisualStyleBackColor = true;
            this.commandButtonAdd.Click += new System.EventHandler(this.commandButtonAdd_Click);
            // 
            // TglMulai
            // 
            this.TglMulai.DataPropertyName = "TglMulai";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglMulai.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglMulai.HeaderText = "Tgl. Mulai";
            this.TglMulai.Name = "TglMulai";
            this.TglMulai.ReadOnly = true;
            // 
            // TglSelesai
            // 
            this.TglSelesai.DataPropertyName = "TglSelesai";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.TglSelesai.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglSelesai.HeaderText = "Tgl.Selesai";
            this.TglSelesai.Name = "TglSelesai";
            this.TglSelesai.ReadOnly = true;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // StatusAktif
            // 
            this.StatusAktif.DataPropertyName = "StatusAktif";
            this.StatusAktif.HeaderText = "StatusAktif";
            this.StatusAktif.Name = "StatusAktif";
            this.StatusAktif.ReadOnly = true;
            this.StatusAktif.Visible = false;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 501);
            this.Controls.Add(this.commandButtonEdit);
            this.Controls.Add(this.commandButtonAdd);
            this.Controls.Add(this.DataGridViewPromo);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPromo";
            this.Text = "Promo";
            this.Title = "Promo";
            this.Load += new System.EventHandler(this.frmPromo_Load);
            this.Controls.SetChildIndex(this.DataGridViewPromo, 0);
            this.Controls.SetChildIndex(this.commandButtonAdd, 0);
            this.Controls.SetChildIndex(this.commandButtonEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPromo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView DataGridViewPromo;
        private ISA.Trading.Controls.CommandButton commandButtonEdit;
        private ISA.Trading.Controls.CommandButton commandButtonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMulai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSelesai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}