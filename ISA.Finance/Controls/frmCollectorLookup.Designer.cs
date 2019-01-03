namespace ISA.Finance.Controls
{
    partial class frmCollectorLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCollectorLookup));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new ISA.Controls.CommonTextBox();
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.dataGridView1 = new ISA.Controls.CustomGridView();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglLahir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatasOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMasuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglKeluar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton2 = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nama Collector";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(132, 43);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(255, 20);
            this.txtNama.TabIndex = 12;
            this.txtNama.TextChanged += new System.EventHandler(this.txtNama_TextChanged);
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(393, 41);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.ReportName2 = "";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 13;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kode,
            this.Nama,
            this.TglLahir,
            this.Alamat,
            this.Target,
            this.BatasOD,
            this.TglMasuk,
            this.TglKeluar,
            this.LastUpdateBy,
            this.LastUpdateTime});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 94);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(733, 219);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Kode
            // 
            this.Kode.DataPropertyName = "Kode";
            this.Kode.HeaderText = "Collector ID";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.DataPropertyName = "Nama";
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            this.Nama.Width = 300;
            // 
            // TglLahir
            // 
            this.TglLahir.HeaderText = "Tgl Lahir";
            this.TglLahir.Name = "TglLahir";
            this.TglLahir.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // Target
            // 
            this.Target.DataPropertyName = "Target";
            this.Target.HeaderText = "Target";
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            // 
            // BatasOD
            // 
            this.BatasOD.DataPropertyName = "BatasOD";
            this.BatasOD.HeaderText = "BatasOD";
            this.BatasOD.Name = "BatasOD";
            this.BatasOD.ReadOnly = true;
            // 
            // TglMasuk
            // 
            this.TglMasuk.DataPropertyName = "TglMasuk";
            this.TglMasuk.HeaderText = "TglMasuk";
            this.TglMasuk.Name = "TglMasuk";
            this.TglMasuk.ReadOnly = true;
            // 
            // TglKeluar
            // 
            this.TglKeluar.DataPropertyName = "TglKeluar";
            this.TglKeluar.HeaderText = "TglKeluar";
            this.TglKeluar.Name = "TglKeluar";
            this.TglKeluar.ReadOnly = true;
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.DataPropertyName = "LastUpdateBy";
            this.LastUpdateBy.HeaderText = "LastUpdateBy";
            this.LastUpdateBy.Name = "LastUpdateBy";
            this.LastUpdateBy.ReadOnly = true;
            // 
            // LastUpdateTime
            // 
            this.LastUpdateTime.DataPropertyName = "LastUpdateTime";
            this.LastUpdateTime.HeaderText = "LastUpdateTime";
            this.LastUpdateTime.Name = "LastUpdateTime";
            this.LastUpdateTime.ReadOnly = true;
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(618, 318);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName2 = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 15;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // frmCollectorLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 370);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "frmCollectorLookup";
            this.Text = "Collector";
            this.Load += new System.EventHandler(this.frmCollectorLookup_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommonTextBox txtNama;
        private ISA.Controls.CommandButton cmdSearch;
        private ISA.Controls.CustomGridView dataGridView1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglLahir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatasOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMasuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglKeluar;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateTime;
    }
}