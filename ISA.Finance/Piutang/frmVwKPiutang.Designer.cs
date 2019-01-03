namespace ISA.Finance.Piutang
{
    partial class frmVwKPiutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVwKPiutang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.TglJatuhTempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpSisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglJatuhTempo,
            this.NoTransaksi,
            this.NamaSales,
            this.KodeSales,
            this.RpSisa,
            this.RowID,
            this.KPID,
            this.Keterangan});
            this.customGridView1.Location = new System.Drawing.Point(28, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(464, 177);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            this.customGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customGridView1_KeyDown);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(392, 225);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 4;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // TglJatuhTempo
            // 
            this.TglJatuhTempo.DataPropertyName = "TglJatuhTempo";
            dataGridViewCellStyle1.Format = "dd MMM yyyy";
            this.TglJatuhTempo.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglJatuhTempo.HeaderText = "TglJatuhTempo";
            this.TglJatuhTempo.Name = "TglJatuhTempo";
            this.TglJatuhTempo.ReadOnly = true;
            // 
            // NoTransaksi
            // 
            this.NoTransaksi.DataPropertyName = "NoTransaksi";
            this.NoTransaksi.HeaderText = "No Nota";
            this.NoTransaksi.Name = "NoTransaksi";
            this.NoTransaksi.ReadOnly = true;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "NamaSales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            // 
            // KodeSales
            // 
            this.KodeSales.DataPropertyName = "KodeSales";
            this.KodeSales.HeaderText = "KodeSales";
            this.KodeSales.Name = "KodeSales";
            this.KodeSales.ReadOnly = true;
            this.KodeSales.Visible = false;
            // 
            // RpSisa
            // 
            this.RpSisa.DataPropertyName = "RpSisa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.RpSisa.DefaultCellStyle = dataGridViewCellStyle2;
            this.RpSisa.HeaderText = "Saldo Nota";
            this.RpSisa.Name = "RpSisa";
            this.RpSisa.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // KPID
            // 
            this.KPID.DataPropertyName = "KPID";
            this.KPID.HeaderText = "KPID";
            this.KPID.Name = "KPID";
            this.KPID.ReadOnly = true;
            this.KPID.Visible = false;
            // 
            // Keterangan
            // 
            this.Keterangan.DataPropertyName = "Keterangan";
            this.Keterangan.HeaderText = "Keterangan";
            this.Keterangan.Name = "Keterangan";
            this.Keterangan.ReadOnly = true;
            this.Keterangan.Visible = false;
            // 
            // frmVwKPiutang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(504, 277);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVwKPiutang";
            this.Text = "Nota Tujuan";
            this.Load += new System.EventHandler(this.frmVwKPiutang_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJatuhTempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpSisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keterangan;
    }
}
