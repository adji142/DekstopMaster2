namespace ISA.Finance.Tac
{
    partial class frmKotaTmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKotaTmp));
            this.customGridView1tmp = new ISA.Controls.CustomGridView();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1tmp)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1tmp
            // 
            this.customGridView1tmp.AllowUserToAddRows = false;
            this.customGridView1tmp.AllowUserToDeleteRows = false;
            this.customGridView1tmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1tmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1tmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kota,
            this.Flag});
            this.customGridView1tmp.Location = new System.Drawing.Point(11, 59);
            this.customGridView1tmp.MultiSelect = false;
            this.customGridView1tmp.Name = "customGridView1tmp";
            this.customGridView1tmp.ReadOnly = true;
            this.customGridView1tmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1tmp.Size = new System.Drawing.Size(465, 205);
            this.customGridView1tmp.StandardTab = true;
            this.customGridView1tmp.TabIndex = 5;
            this.customGridView1tmp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1tmp_KeyDown);
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "KOTA";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            this.Kota.Width = 365;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Width = 40;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(272, 278);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(378, 278);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "SPACEBAR  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(76, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "SELECT ITEM";
            // 
            // frmKotaTmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(484, 339);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.customGridView1tmp);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKotaTmp";
            this.Text = "Data Kota";
            this.Title = "Data Kota";
            this.Load += new System.EventHandler(this.frmKotaTmp_Load);
            this.Controls.SetChildIndex(this.customGridView1tmp, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1tmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1tmp;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
    }
}
