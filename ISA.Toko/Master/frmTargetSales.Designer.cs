namespace ISA.Toko.Master
{
    partial class frmTargetSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBtnEDIT = new ISA.Toko.Controls.CommandButton();
            this.cmdBtnADD = new ISA.Toko.Controls.CommandButton();
            this.cgvTargetSls = new ISA.Toko.Controls.CustomGridView();
            this.lookupSales1 = new ISA.Toko.Controls.LookupSales();
            this.rangeDateBox1 = new ISA.Toko.Controls.RangeDateBox();
            this.cmdBtnSearch = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.skur2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skur4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skulain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfb2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfb4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomflain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokoKunj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colrowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OmsetNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokoOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cgvTargetSls)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periode";
            // 
            // cmdBtnEDIT
            // 
            this.cmdBtnEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBtnEDIT.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Edit;
            this.cmdBtnEDIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnEDIT.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnEDIT.Image")));
            this.cmdBtnEDIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnEDIT.Location = new System.Drawing.Point(148, 340);
            this.cmdBtnEDIT.Name = "cmdBtnEDIT";
            this.cmdBtnEDIT.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnEDIT.TabIndex = 7;
            this.cmdBtnEDIT.Text = "EDIT";
            this.cmdBtnEDIT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnEDIT.UseVisualStyleBackColor = true;
            this.cmdBtnEDIT.Click += new System.EventHandler(this.cmdBtnEDIT_Click);
            // 
            // cmdBtnADD
            // 
            this.cmdBtnADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBtnADD.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Add;
            this.cmdBtnADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnADD.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnADD.Image")));
            this.cmdBtnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnADD.Location = new System.Drawing.Point(36, 340);
            this.cmdBtnADD.Name = "cmdBtnADD";
            this.cmdBtnADD.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnADD.TabIndex = 6;
            this.cmdBtnADD.Text = "ADD";
            this.cmdBtnADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnADD.UseVisualStyleBackColor = true;
            this.cmdBtnADD.Click += new System.EventHandler(this.cmdBtnADD_Click_1);
            // 
            // cgvTargetSls
            // 
            this.cgvTargetSls.AllowUserToAddRows = false;
            this.cgvTargetSls.AllowUserToDeleteRows = false;
            this.cgvTargetSls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cgvTargetSls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cgvTargetSls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cgvTargetSls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.skur2,
            this.skur4,
            this.skulain,
            this.nomfe2,
            this.nomfe4,
            this.nomfb2,
            this.nomfb4,
            this.nomfa,
            this.nomflain,
            this.tokoKunj,
            this.colrowID,
            this.tmt,
            this.NamaSales,
            this.SKU,
            this.OmsetNetto,
            this.tokoOA,
            this.CreatedBy,
            this.CreatedOn,
            this.LastUpdateBy,
            this.LastUpdatedTime});
            this.cgvTargetSls.Location = new System.Drawing.Point(2, 151);
            this.cgvTargetSls.MultiSelect = false;
            this.cgvTargetSls.Name = "cgvTargetSls";
            this.cgvTargetSls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cgvTargetSls.Size = new System.Drawing.Size(1039, 183);
            this.cgvTargetSls.StandardTab = true;
            this.cgvTargetSls.TabIndex = 5;
            this.cgvTargetSls.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.cgvTargetSls_CellFormatting);
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(425, 16);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(320, 58);
            this.lookupSales1.TabIndex = 3;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(93, 16);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(300, 24);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // cmdBtnSearch
            // 
            this.cmdBtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBtnSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchL;
            this.cmdBtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdBtnSearch.Image")));
            this.cmdBtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBtnSearch.Location = new System.Drawing.Point(768, 21);
            this.cmdBtnSearch.Name = "cmdBtnSearch";
            this.cmdBtnSearch.Size = new System.Drawing.Size(100, 40);
            this.cmdBtnSearch.TabIndex = 4;
            this.cmdBtnSearch.Text = "SEARCH";
            this.cmdBtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdBtnSearch.UseVisualStyleBackColor = true;
            this.cmdBtnSearch.Click += new System.EventHandler(this.cmdBtnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rangeDateBox1);
            this.groupBox1.Controls.Add(this.lookupSales1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdBtnSearch);
            this.groupBox1.Location = new System.Drawing.Point(26, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 76);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Salesman";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(922, 340);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 12;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // skur2
            // 
            this.skur2.DataPropertyName = "SKUR2";
            this.skur2.HeaderText = "SKU R2";
            this.skur2.Name = "skur2";
            this.skur2.Visible = false;
            this.skur2.Width = 60;
            // 
            // skur4
            // 
            this.skur4.DataPropertyName = "SKUR4";
            this.skur4.HeaderText = "SKU R4";
            this.skur4.Name = "skur4";
            this.skur4.Visible = false;
            this.skur4.Width = 60;
            // 
            // skulain
            // 
            this.skulain.DataPropertyName = "SKULain";
            this.skulain.HeaderText = "SKU Lain";
            this.skulain.Name = "skulain";
            this.skulain.Visible = false;
            this.skulain.Width = 60;
            // 
            // nomfe2
            // 
            this.nomfe2.DataPropertyName = "NomFE2";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.nomfe2.DefaultCellStyle = dataGridViewCellStyle1;
            this.nomfe2.HeaderText = "NOM. FE2";
            this.nomfe2.Name = "nomfe2";
            this.nomfe2.Visible = false;
            // 
            // nomfe4
            // 
            this.nomfe4.DataPropertyName = "NomFE4";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.nomfe4.DefaultCellStyle = dataGridViewCellStyle2;
            this.nomfe4.HeaderText = "NOM. FE4";
            this.nomfe4.Name = "nomfe4";
            this.nomfe4.Visible = false;
            // 
            // nomfb2
            // 
            this.nomfb2.DataPropertyName = "NomFB2";
            dataGridViewCellStyle3.Format = "N0";
            this.nomfb2.DefaultCellStyle = dataGridViewCellStyle3;
            this.nomfb2.HeaderText = "NOM. FB2";
            this.nomfb2.Name = "nomfb2";
            this.nomfb2.Visible = false;
            // 
            // nomfb4
            // 
            this.nomfb4.DataPropertyName = "NomFB4";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.nomfb4.DefaultCellStyle = dataGridViewCellStyle4;
            this.nomfb4.HeaderText = "NOM. FB4";
            this.nomfb4.Name = "nomfb4";
            this.nomfb4.Visible = false;
            // 
            // nomfa
            // 
            this.nomfa.DataPropertyName = "NomFA";
            dataGridViewCellStyle5.Format = "N0";
            this.nomfa.DefaultCellStyle = dataGridViewCellStyle5;
            this.nomfa.HeaderText = "NOM. FA";
            this.nomfa.Name = "nomfa";
            this.nomfa.Visible = false;
            // 
            // nomflain
            // 
            this.nomflain.DataPropertyName = "NomFLain";
            dataGridViewCellStyle6.Format = "N0";
            this.nomflain.DefaultCellStyle = dataGridViewCellStyle6;
            this.nomflain.HeaderText = "NOM. F LAIN";
            this.nomflain.Name = "nomflain";
            this.nomflain.Visible = false;
            // 
            // tokoKunj
            // 
            this.tokoKunj.DataPropertyName = "Kunjungan";
            this.tokoKunj.HeaderText = "TOKO KUNJ";
            this.tokoKunj.Name = "tokoKunj";
            this.tokoKunj.Visible = false;
            this.tokoKunj.Width = 70;
            // 
            // colrowID
            // 
            this.colrowID.DataPropertyName = "RowID";
            this.colrowID.HeaderText = "RowID";
            this.colrowID.Name = "colrowID";
            this.colrowID.Visible = false;
            // 
            // tmt
            // 
            this.tmt.DataPropertyName = "TglAktif";
            dataGridViewCellStyle7.Format = "dd/MM/yyyy";
            this.tmt.DefaultCellStyle = dataGridViewCellStyle7;
            this.tmt.HeaderText = "TMT";
            this.tmt.Name = "tmt";
            this.tmt.Width = 75;
            // 
            // NamaSales
            // 
            this.NamaSales.DataPropertyName = "NamaSales";
            this.NamaSales.HeaderText = "NamaSales";
            this.NamaSales.Name = "NamaSales";
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "SKU";
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            // 
            // OmsetNetto
            // 
            this.OmsetNetto.DataPropertyName = "OmsetNetto";
            this.OmsetNetto.HeaderText = "OmsetNetto";
            this.OmsetNetto.Name = "OmsetNetto";
            // 
            // tokoOA
            // 
            this.tokoOA.DataPropertyName = "OrderAktif";
            this.tokoOA.HeaderText = "OA";
            this.tokoOA.Name = "tokoOA";
            this.tokoOA.Width = 70;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.DataPropertyName = "LastUpdateBy";
            this.LastUpdateBy.HeaderText = "LastUpdateBy";
            this.LastUpdateBy.Name = "LastUpdateBy";
            // 
            // LastUpdatedTime
            // 
            this.LastUpdatedTime.DataPropertyName = "LastUpdatedTime";
            this.LastUpdatedTime.HeaderText = "LastUpdatedTime";
            this.LastUpdatedTime.Name = "LastUpdatedTime";
            // 
            // frmTargetSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 389);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdBtnEDIT);
            this.Controls.Add(this.cmdBtnADD);
            this.Controls.Add(this.cgvTargetSls);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTargetSales";
            this.RightToLeftLayout = true;
            this.Text = "History Target Sales";
            this.Title = "History Target Sales";
            this.Load += new System.EventHandler(this.frmTargetSales_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cgvTargetSls, 0);
            this.Controls.SetChildIndex(this.cmdBtnADD, 0);
            this.Controls.SetChildIndex(this.cmdBtnEDIT, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cgvTargetSls)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.RangeDateBox rangeDateBox1;
        private ISA.Toko.Controls.LookupSales lookupSales1;
        private ISA.Toko.Controls.CustomGridView cgvTargetSls;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton cmdBtnADD;
        private ISA.Toko.Controls.CommandButton cmdBtnEDIT;
        private ISA.Controls.CommandButton cmdBtnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn skur2;
        private System.Windows.Forms.DataGridViewTextBoxColumn skur4;
        private System.Windows.Forms.DataGridViewTextBoxColumn skulain;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfb2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfb4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomflain;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokoKunj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn OmsetNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokoOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedTime;

    }
}