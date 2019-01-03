namespace ISA.Finance.Setoran
{
    partial class frmStokTitipanGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokTitipanGiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.TglTerima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglJthGiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyGiro2Cair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglPrediksiCair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RpJumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglRealCair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(775, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(62, 14);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Prefrence";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(737, 229);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 5;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Refresh;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(576, 229);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(120, 40);
            this.commandButton1.TabIndex = 4;
            this.commandButton1.Text = "REFRESH";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.AllowUserToResizeRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TglTerima,
            this.NamaBank,
            this.Kota,
            this.NoGiro,
            this.TglJthGiro,
            this.TglSetor,
            this.QtyGiro2Cair,
            this.TglPrediksiCair,
            this.RpJumlah,
            this.TglRealCair,
            this.RowID});
            this.customGridView1.Location = new System.Drawing.Point(19, 28);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.RowHeadersVisible = false;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(818, 190);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 3;
            // 
            // TglTerima
            // 
            this.TglTerima.DataPropertyName = "TglTerima";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            this.TglTerima.DefaultCellStyle = dataGridViewCellStyle1;
            this.TglTerima.HeaderText = "TglTerima";
            this.TglTerima.Name = "TglTerima";
            this.TglTerima.ReadOnly = true;
            // 
            // NamaBank
            // 
            this.NamaBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamaBank.DataPropertyName = "NamaBank";
            this.NamaBank.HeaderText = "NamaBank";
            this.NamaBank.Name = "NamaBank";
            this.NamaBank.ReadOnly = true;
            this.NamaBank.Width = 89;
            // 
            // Kota
            // 
            this.Kota.DataPropertyName = "Kota";
            this.Kota.HeaderText = "Kota";
            this.Kota.Name = "Kota";
            this.Kota.ReadOnly = true;
            // 
            // NoGiro
            // 
            this.NoGiro.DataPropertyName = "NoGiro";
            this.NoGiro.HeaderText = "NoGiro";
            this.NoGiro.Name = "NoGiro";
            this.NoGiro.ReadOnly = true;
            // 
            // TglJthGiro
            // 
            this.TglJthGiro.DataPropertyName = "TglJthGiro";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.TglJthGiro.DefaultCellStyle = dataGridViewCellStyle2;
            this.TglJthGiro.HeaderText = "TglJt.Tempo";
            this.TglJthGiro.Name = "TglJthGiro";
            this.TglJthGiro.ReadOnly = true;
            // 
            // TglSetor
            // 
            this.TglSetor.DataPropertyName = "TglSetor";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.TglSetor.DefaultCellStyle = dataGridViewCellStyle3;
            this.TglSetor.HeaderText = "TglSetor";
            this.TglSetor.Name = "TglSetor";
            this.TglSetor.ReadOnly = true;
            // 
            // QtyGiro2Cair
            // 
            this.QtyGiro2Cair.DataPropertyName = "QtyGiro2Cair";
            this.QtyGiro2Cair.HeaderText = "Giro Est ? Cair";
            this.QtyGiro2Cair.MinimumWidth = 120;
            this.QtyGiro2Cair.Name = "QtyGiro2Cair";
            this.QtyGiro2Cair.ReadOnly = true;
            this.QtyGiro2Cair.Width = 120;
            // 
            // TglPrediksiCair
            // 
            this.TglPrediksiCair.DataPropertyName = "TglPCair";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.TglPrediksiCair.DefaultCellStyle = dataGridViewCellStyle4;
            this.TglPrediksiCair.HeaderText = "TglPrediksiCair";
            this.TglPrediksiCair.Name = "TglPrediksiCair";
            this.TglPrediksiCair.ReadOnly = true;
            // 
            // RpJumlah
            // 
            this.RpJumlah.DataPropertyName = "RpJumlah";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0";
            this.RpJumlah.DefaultCellStyle = dataGridViewCellStyle5;
            this.RpJumlah.HeaderText = "Jumlah";
            this.RpJumlah.Name = "RpJumlah";
            this.RpJumlah.ReadOnly = true;
            // 
            // TglRealCair
            // 
            this.TglRealCair.DataPropertyName = "TglRealCair";
            dataGridViewCellStyle6.Format = "dd-MMM-yyyy";
            this.TglRealCair.DefaultCellStyle = dataGridViewCellStyle6;
            this.TglRealCair.HeaderText = "TglRealCair";
            this.TglRealCair.Name = "TglRealCair";
            this.TglRealCair.ReadOnly = true;
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // frmStokTitipanGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(849, 281);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.customGridView1);
            this.Name = "frmStokTitipanGiro";
            this.Text = "Setoran : Saldo & Titipan Giro";
            this.Load += new System.EventHandler(this.frmStokTitipanGiro_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglTerima;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kota;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglJthGiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyGiro2Cair;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglPrediksiCair;
        private System.Windows.Forms.DataGridViewTextBoxColumn RpJumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglRealCair;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
    }
}
