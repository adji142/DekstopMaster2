namespace ISA.Trading.Expedisi
{
    partial class frmNotaLookupForRekapKoli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaLookupForRekapKoli));
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.NotaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaRecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KreditTunai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyKoli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NotaID,
            this.NotaRecID,
            this.NoNota,
            this.NoDO,
            this.TglNota,
            this.NamaSales,
            this.NamaToko,
            this.AlamatKirim,
            this.KreditTunai,
            this.Nominal,
            this.QtyKoli});
            this.dataGridView1.Location = new System.Drawing.Point(-3, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(720, 193);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // NotaID
            // 
            this.NotaID.DataPropertyName = "NotaJualID";
            this.NotaID.HeaderText = "Nota ID";
            this.NotaID.Name = "NotaID";
            this.NotaID.ReadOnly = true;
            this.NotaID.Visible = false;
            // 
            // NotaRecID
            // 
            this.NotaRecID.DataPropertyName = "NotaRecID";
            this.NotaRecID.HeaderText = "Nota Rec ID";
            this.NotaRecID.Name = "NotaRecID";
            this.NotaRecID.ReadOnly = true;
            this.NotaRecID.Visible = false;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // NoDO
            // 
            this.NoDO.DataPropertyName = "NoDO";
            this.NoDO.HeaderText = "No DO";
            this.NoDO.Name = "NoDO";
            this.NoDO.ReadOnly = true;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            this.TglNota.HeaderText = "Tgl Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            this.TglNota.Visible = false;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "Sales";
            this.NamaSales.Name = "NamaSales";
            this.NamaSales.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // AlamatKirim
            // 
            this.AlamatKirim.DataPropertyName = "AlamatKirim";
            this.AlamatKirim.HeaderText = "Alamat Kirim";
            this.AlamatKirim.Name = "AlamatKirim";
            this.AlamatKirim.ReadOnly = true;
            // 
            // KreditTunai
            // 
            this.KreditTunai.DataPropertyName = "KreditTunai";
            this.KreditTunai.HeaderText = "Kredit/Tunai";
            this.KreditTunai.Name = "KreditTunai";
            this.KreditTunai.ReadOnly = true;
            this.KreditTunai.Visible = false;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            this.Nominal.Visible = false;
            // 
            // QtyKoli
            // 
            this.QtyKoli.DataPropertyName = "QtyKoli";
            this.QtyKoli.HeaderText = "Qty Koli";
            this.QtyKoli.Name = "QtyKoli";
            this.QtyKoli.ReadOnly = true;
            this.QtyKoli.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(589, 285);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 27;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmNotaLookupForRekapKoli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(720, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.dataGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNotaLookupForRekapKoli";
            this.Text = "Nota";
            this.Title = "Nota";
            this.Load += new System.EventHandler(this.frmNotaLookupForRekapKoli_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private ISA.Trading.Controls.CommandButton cmdClose;
        //private System.Windows.Forms.DataGridViewTextBoxColumn NotaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaRecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn KreditTunai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyKoli;
    }
}
