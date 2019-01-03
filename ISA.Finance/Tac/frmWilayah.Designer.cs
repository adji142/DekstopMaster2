namespace ISA.Finance.Tac
{
    partial class frmWilayah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWilayah));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.wilayah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.wil = new ISA.Controls.CommonTextBox();
            this.cmdSimpan = new System.Windows.Forms.Button();
            this.cmdTutup = new System.Windows.Forms.Button();
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
            this.wilayah,
            this.LastUpdateBy,
            this.RowID});
            this.customGridView1.Location = new System.Drawing.Point(12, 177);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(418, 141);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            // 
            // wilayah
            // 
            this.wilayah.DataPropertyName = "wilayah";
            this.wilayah.HeaderText = "WILAYAH";
            this.wilayah.Name = "wilayah";
            this.wilayah.ReadOnly = true;
            this.wilayah.Width = 75;
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.DataPropertyName = "LastUpdatedBy";
            this.LastUpdateBy.HeaderText = "USER";
            this.LastUpdateBy.Name = "LastUpdateBy";
            this.LastUpdateBy.ReadOnly = true;
            this.LastUpdateBy.Width = 300;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            this.RowID.Width = 200;
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 328);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(118, 328);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 7;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(224, 328);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(330, 328);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Wilayah Toko yang akan di TAC";
            // 
            // wil
            // 
            this.wil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.wil.Enabled = false;
            this.wil.Location = new System.Drawing.Point(209, 82);
            this.wil.MaxLength = 1;
            this.wil.Name = "wil";
            this.wil.Size = new System.Drawing.Size(34, 20);
            this.wil.TabIndex = 12;
            // 
            // cmdSimpan
            // 
            this.cmdSimpan.Enabled = false;
            this.cmdSimpan.Location = new System.Drawing.Point(274, 126);
            this.cmdSimpan.Name = "cmdSimpan";
            this.cmdSimpan.Size = new System.Drawing.Size(75, 23);
            this.cmdSimpan.TabIndex = 13;
            this.cmdSimpan.Text = "Save";
            this.cmdSimpan.UseVisualStyleBackColor = true;
            this.cmdSimpan.Click += new System.EventHandler(this.cmdSimpan_Click);
            // 
            // cmdTutup
            // 
            this.cmdTutup.Enabled = false;
            this.cmdTutup.Location = new System.Drawing.Point(355, 126);
            this.cmdTutup.Name = "cmdTutup";
            this.cmdTutup.Size = new System.Drawing.Size(75, 23);
            this.cmdTutup.TabIndex = 14;
            this.cmdTutup.Text = "Close";
            this.cmdTutup.UseVisualStyleBackColor = true;
            this.cmdTutup.Click += new System.EventHandler(this.cmdTutup_Click);
            // 
            // frmWilayah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(441, 389);
            this.Controls.Add(this.cmdTutup);
            this.Controls.Add(this.cmdSimpan);
            this.Controls.Add(this.wil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cmdAdd);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmWilayah";
            this.Text = "Wilayah";
            this.Title = "Wilayah";
            this.Load += new System.EventHandler(this.frmWilayah_Load);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.wil, 0);
            this.Controls.SetChildIndex(this.cmdSimpan, 0);
            this.Controls.SetChildIndex(this.cmdTutup, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox wil;
        private System.Windows.Forms.Button cmdSimpan;
        private System.Windows.Forms.Button cmdTutup;
        private System.Windows.Forms.DataGridViewTextBoxColumn wilayah;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;

    }
}
