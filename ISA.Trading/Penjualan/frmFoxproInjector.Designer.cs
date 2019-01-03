namespace ISA.Trading.Penjualan
{
    partial class frmFoxproInjector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFoxproInjector));
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Script = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdUpload = new ISA.Trading.Controls.CommandButton();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.Target,
            this.Script,
            this.Complete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(691, 173);
            this.dataGridView1.TabIndex = 5;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // Target
            // 
            this.Target.DataPropertyName = "Target";
            this.Target.HeaderText = "Target";
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            this.Target.Width = 150;
            // 
            // Script
            // 
            this.Script.DataPropertyName = "Script";
            this.Script.HeaderText = "Script";
            this.Script.Name = "Script";
            this.Script.ReadOnly = true;
            this.Script.Width = 500;
            // 
            // Complete
            // 
            this.Complete.DataPropertyName = "Complete";
            this.Complete.HeaderText = "Complete";
            this.Complete.Name = "Complete";
            this.Complete.ReadOnly = true;
            this.Complete.Width = 80;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(436, 289);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 6;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(603, 289);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 7;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmFoxproInjector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cmdUpload);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmFoxproInjector";
            this.Text = "Data Kasir/Piutang Pending";
            this.Title = "Data Kasir/Piutang Pending";
            this.Load += new System.EventHandler(this.frmFoxproInjector_Load);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private ISA.Trading.Controls.CommandButton cmdUpload;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn Script;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Complete;
    }
}
