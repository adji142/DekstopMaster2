namespace ISA.Trading.Master
{
    partial class FrmTokoMitraBengkel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTokoMitraBengkel));
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.namatoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodetoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wilid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglregistrasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglacc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namasurveyor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
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
            this.namatoko,
            this.kodetoko,
            this.alamat,
            this.wilid,
            this.tglregistrasi,
            this.tglacc,
            this.namasurveyor});
            this.customGridView1.Location = new System.Drawing.Point(26, 67);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(662, 189);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            // 
            // namatoko
            // 
            this.namatoko.DataPropertyName = "namatoko";
            this.namatoko.HeaderText = "namatoko";
            this.namatoko.Name = "namatoko";
            // 
            // kodetoko
            // 
            this.kodetoko.DataPropertyName = "kodetoko";
            this.kodetoko.HeaderText = "kodetoko";
            this.kodetoko.Name = "kodetoko";
            // 
            // alamat
            // 
            this.alamat.DataPropertyName = "alamat";
            this.alamat.HeaderText = "alamat";
            this.alamat.Name = "alamat";
            // 
            // wilid
            // 
            this.wilid.DataPropertyName = "wilid";
            this.wilid.HeaderText = "wilid";
            this.wilid.Name = "wilid";
            // 
            // tglregistrasi
            // 
            this.tglregistrasi.DataPropertyName = "tglregistrasi";
            this.tglregistrasi.HeaderText = "tglregistrasi";
            this.tglregistrasi.Name = "tglregistrasi";
            // 
            // tglacc
            // 
            this.tglacc.DataPropertyName = "tglacc";
            this.tglacc.HeaderText = "tglacc";
            this.tglacc.Name = "tglacc";
            // 
            // namasurveyor
            // 
            this.namasurveyor.DataPropertyName = "namasurveyor";
            this.namasurveyor.HeaderText = "namasurveyor";
            this.namasurveyor.Name = "namasurveyor";
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Download;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(26, 289);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName = "";
            this.commandButton1.Size = new System.Drawing.Size(128, 40);
            this.commandButton1.TabIndex = 6;
            this.commandButton1.Text = "DOWNLOAD";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(588, 289);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 7;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // FrmTokoMitraBengkel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.commandButton2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmTokoMitraBengkel";
            this.Text = "Data Toko Promo";
            this.Title = "Data Toko Promo";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmTokoMitraBengkel_Load);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView customGridView1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn namatoko;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodetoko;
        private System.Windows.Forms.DataGridViewTextBoxColumn alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn wilid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglregistrasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglacc;
        private System.Windows.Forms.DataGridViewTextBoxColumn namasurveyor;
    }
}