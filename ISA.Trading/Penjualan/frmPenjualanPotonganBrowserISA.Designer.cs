namespace ISA.Trading.Penjualan
{
    partial class frmPenjualanPotonganBrowserISA
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualanPotonganBrowserISA));
            this.label1 = new System.Windows.Forms.Label();
            this.rgbTgl = new ISA.Trading.Controls.RangeDateBox();
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPotJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JKW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotRp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlamatKirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DILMinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DILACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatatanPemohon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatatanACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIBMinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIBACC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaJualID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdDelete = new ISA.Trading.Controls.CommandButton();
            this.cmdEdit = new ISA.Trading.Controls.CommandButton();
            this.cmdSearch = new ISA.Trading.Controls.CommandButton();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Range Tanggal Potongan";
            // 
            // rgbTgl
            // 
            this.rgbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rgbTgl.FromDate = null;
            this.rgbTgl.Location = new System.Drawing.Point(182, 66);
            this.rgbTgl.Name = "rgbTgl";
            this.rgbTgl.Size = new System.Drawing.Size(257, 22);
            this.rgbTgl.TabIndex = 0;
            this.rgbTgl.ToDate = null;
            this.rgbTgl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTgl_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.v,
            this.tanda,
            this.NoPotJ,
            this.RowID,
            this.TglPot,
            this.NoNota,
            this.TglNota,
            this.JKW,
            this.Salesman,
            this.Exp,
            this.RpNet,
            this.PotRp,
            this.Disc1,
            this.NamaToko,
            this.AlamatKirim,
            this.Kota,
            this.DILMinta,
            this.DILACC,
            this.TglACC,
            this.CatatanPemohon,
            this.CatatanACC,
            this.DIBMinta,
            this.DIBACC,
            this.IDLink,
            this.NotaJualID});
            this.dataGridView1.Location = new System.Drawing.Point(0, 94);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(717, 256);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // v
            // 
            this.v.DataPropertyName = "StatusACC";
            this.v.Frozen = true;
            this.v.HeaderText = "v";
            this.v.Name = "v";
            this.v.ReadOnly = true;
            this.v.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.v.Width = 25;
            // 
            // tanda
            // 
            this.tanda.DataPropertyName = "tanda";
            this.tanda.Frozen = true;
            this.tanda.HeaderText = "!";
            this.tanda.Name = "tanda";
            this.tanda.ReadOnly = true;
            this.tanda.Width = 25;
            // 
            // NoPotJ
            // 
            this.NoPotJ.DataPropertyName = "NoPot";
            this.NoPotJ.HeaderText = "No.Pot.J";
            this.NoPotJ.Name = "NoPotJ";
            this.NoPotJ.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // TglPot
            // 
            this.TglPot.DataPropertyName = "TglPot";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.TglPot.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglPot.HeaderText = "Tgl.Pot";
            this.TglPot.Name = "TglPot";
            this.TglPot.ReadOnly = true;
            // 
            // NoNota
            // 
            this.NoNota.DataPropertyName = "NoNota";
            this.NoNota.HeaderText = "No.Nota";
            this.NoNota.Name = "NoNota";
            this.NoNota.ReadOnly = true;
            // 
            // TglNota
            // 
            this.TglNota.DataPropertyName = "TglNota";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.TglNota.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglNota.HeaderText = "Tgl.Nota";
            this.TglNota.Name = "TglNota";
            this.TglNota.ReadOnly = true;
            // 
            // JKW
            // 
            this.JKW.DataPropertyName = "HariKredit";
            this.JKW.HeaderText = "JKW";
            this.JKW.Name = "JKW";
            this.JKW.ReadOnly = true;
            // 
            // Salesman
            // 
            this.Salesman.DataPropertyName = "NamaSales";
            this.Salesman.HeaderText = "Salesman";
            this.Salesman.Name = "Salesman";
            this.Salesman.ReadOnly = true;
            // 
            // Exp
            // 
            this.Exp.DataPropertyName = "Expedisi";
            this.Exp.HeaderText = "Exp";
            this.Exp.Name = "Exp";
            this.Exp.ReadOnly = true;
            // 
            // RpNet
            // 
            this.RpNet.DataPropertyName = "RpNet";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.RpNet.DefaultCellStyle = dataGridViewCellStyle3;
            this.RpNet.HeaderText = "Rp.Net";
            this.RpNet.Name = "RpNet";
            this.RpNet.ReadOnly = true;
            // 
            // PotRp
            // 
            this.PotRp.DataPropertyName = "PotRp";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.PotRp.DefaultCellStyle = dataGridViewCellStyle4;
            this.PotRp.HeaderText = "Pot.Rp";
            this.PotRp.Name = "PotRp";
            this.PotRp.ReadOnly = true;
            // 
            // Disc1
            // 
            this.Disc1.DataPropertyName = "Disc1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.Disc1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Disc1.HeaderText = "Disc.1";
            this.Disc1.Name = "Disc1";
            this.Disc1.ReadOnly = true;
            // 
            // NamaToko
            // 
            this.NamaToko.DataPropertyName = "NamaToko";
            this.NamaToko.HeaderText = "Nama Toko";
            this.NamaToko.Name = "NamaToko";
            this.NamaToko.ReadOnly = true;
            // 
            // AlamatKirim
            // 
            this.AlamatKirim.DataPropertyName = "Alamat";
            this.AlamatKirim.HeaderText = "Alamat Kirim";
            this.AlamatKirim.Name = "AlamatKirim";
            this.AlamatKirim.ReadOnly = true;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // DILMinta
            // 
            this.DILMinta.DataPropertyName = "Dil";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0";
            this.DILMinta.DefaultCellStyle = dataGridViewCellStyle6;
            this.DILMinta.HeaderText = "DIL.Minta";
            this.DILMinta.Name = "DILMinta";
            this.DILMinta.ReadOnly = true;
            // 
            // DILACC
            // 
            this.DILACC.DataPropertyName = "DilACC";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,##0";
            this.DILACC.DefaultCellStyle = dataGridViewCellStyle7;
            this.DILACC.HeaderText = "DIL.ACC";
            this.DILACC.Name = "DILACC";
            this.DILACC.ReadOnly = true;
            // 
            // TglACC
            // 
            this.TglACC.DataPropertyName = "TglACC";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            this.TglACC.DefaultCellStyle = dataGridViewCellStyle8;
            this.TglACC.HeaderText = "Tgl.ACC";
            this.TglACC.Name = "TglACC";
            this.TglACC.ReadOnly = true;
            // 
            // CatatanPemohon
            // 
            this.CatatanPemohon.DataPropertyName = "Catatan";
            this.CatatanPemohon.HeaderText = "Catatan Pemohon";
            this.CatatanPemohon.Name = "CatatanPemohon";
            this.CatatanPemohon.ReadOnly = true;
            // 
            // CatatanACC
            // 
            this.CatatanACC.DataPropertyName = "CatACC";
            this.CatatanACC.HeaderText = "CatatanACC";
            this.CatatanACC.Name = "CatatanACC";
            this.CatatanACC.ReadOnly = true;
            // 
            // DIBMinta
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "#,##0";
            this.DIBMinta.DefaultCellStyle = dataGridViewCellStyle9;
            this.DIBMinta.HeaderText = "DIBMinta";
            this.DIBMinta.Name = "DIBMinta";
            this.DIBMinta.ReadOnly = true;
            // 
            // DIBACC
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "#,##0";
            this.DIBACC.DefaultCellStyle = dataGridViewCellStyle10;
            this.DIBACC.HeaderText = "DIB.ACC";
            this.DIBACC.Name = "DIBACC";
            this.DIBACC.ReadOnly = true;
            // 
            // IDLink
            // 
            this.IDLink.DataPropertyName = "IDLink";
            this.IDLink.HeaderText = "ID.Link";
            this.IDLink.Name = "IDLink";
            this.IDLink.ReadOnly = true;
            // 
            // NotaJualID
            // 
            this.NotaJualID.DataPropertyName = "NotaPenjualanID";
            this.NotaJualID.HeaderText = "NotaJualID";
            this.NotaJualID.Name = "NotaJualID";
            this.NotaJualID.ReadOnly = true;
            this.NotaJualID.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::ISA.Trading.Properties.Resources.help;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(682, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 14;
            this.button1.TabStop = false;
            this.toolTip1.SetToolTip(this.button1, "F3 = Filter Toko\r\nF4 = Filter Nota\r\nF5 = Filter Nota Belum Link\r\nF6 = Link ke Piu" +
                    "tang");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(587, 386);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
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
            this.cmdDelete.Location = new System.Drawing.Point(261, 386);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 5;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdEdit.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(138, 386);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(446, 64);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 1;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(14, 386);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmPenjualanPotonganBrowserISA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(717, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.rgbTgl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdAdd);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPenjualanPotonganBrowserISA";
            this.Text = "Potongan";
            this.Title = "Potongan";
            this.Load += new System.EventHandler(this.frmPenjualanPotonganBrowserISA_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPenjualanPotonganBrowserISA_KeyPress);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.cmdSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rgbTgl, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.RangeDateBox rgbTgl;
        private ISA.Trading.Controls.CommandButton cmdSearch;
        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private ISA.Trading.Controls.CommandButton cmdEdit;
        private ISA.Trading.Controls.CommandButton cmdDelete;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn v;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPotJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPot;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn JKW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn PotRp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaToko;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlamatKirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DILMinta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DILACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatatanPemohon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatatanACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIBMinta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIBACC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaJualID;
    }
}
