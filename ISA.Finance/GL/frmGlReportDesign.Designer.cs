namespace ISA.Finance.GL
{
    partial class frmGlReportDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGlReportDesign));
            this.label1 = new System.Windows.Forms.Label();
            this.cbLookup = new System.Windows.Forms.ComboBox();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGL = new ISA.Controls.CustomGridView();
            this.cRowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNoUrut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLMinus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTUnderLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDUnderline = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cBold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdSave = new ISA.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgGL)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "REPORT";
            // 
            // cbLookup
            // 
            this.cbLookup.FormattingEnabled = true;
            this.cbLookup.Location = new System.Drawing.Point(97, 25);
            this.cbLookup.Name = "cbLookup";
            this.cbLookup.Size = new System.Drawing.Size(121, 22);
            this.cbLookup.TabIndex = 4;
            this.cbLookup.SelectedIndexChanged += new System.EventHandler(this.cbLookup_SelectedIndexChanged);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(706, 306);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.Visible = false;
            // 
            // dgGL
            // 
            this.dgGL.AllowUserToAddRows = false;
            this.dgGL.AllowUserToDeleteRows = false;
            this.dgGL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgGL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cRowID,
            this.cReport,
            this.cRef,
            this.cNoUrut,
            this.cTipe,
            this.cKeterangan,
            this.cCatatan,
            this.cFormula,
            this.cLMinus,
            this.cTUnderLine,
            this.cDUnderline,
            this.cBold});
            this.dgGL.Location = new System.Drawing.Point(6, 63);
            this.dgGL.MultiSelect = false;
            this.dgGL.Name = "dgGL";
            this.dgGL.ReadOnly = true;
            this.dgGL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgGL.Size = new System.Drawing.Size(822, 237);
            this.dgGL.StandardTab = true;
            this.dgGL.TabIndex = 7;
            this.dgGL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgGL_KeyDown);
            // 
            // cRowID
            // 
            this.cRowID.DataPropertyName = "RowID";
            this.cRowID.HeaderText = "RowID";
            this.cRowID.Name = "cRowID";
            this.cRowID.ReadOnly = true;
            this.cRowID.Visible = false;
            // 
            // cReport
            // 
            this.cReport.DataPropertyName = "Report";
            this.cReport.HeaderText = "Report";
            this.cReport.Name = "cReport";
            this.cReport.ReadOnly = true;
            this.cReport.Visible = false;
            // 
            // cRef
            // 
            this.cRef.DataPropertyName = "Ref";
            this.cRef.HeaderText = "Ref";
            this.cRef.Name = "cRef";
            this.cRef.ReadOnly = true;
            this.cRef.Visible = false;
            // 
            // cNoUrut
            // 
            this.cNoUrut.DataPropertyName = "NoUrut";
            this.cNoUrut.HeaderText = "NoUrut";
            this.cNoUrut.Name = "cNoUrut";
            this.cNoUrut.ReadOnly = true;
            // 
            // cTipe
            // 
            this.cTipe.DataPropertyName = "Tipe";
            this.cTipe.HeaderText = "Tipe";
            this.cTipe.Name = "cTipe";
            this.cTipe.ReadOnly = true;
            // 
            // cKeterangan
            // 
            this.cKeterangan.DataPropertyName = "Keterangan";
            this.cKeterangan.HeaderText = "Keterangan";
            this.cKeterangan.Name = "cKeterangan";
            this.cKeterangan.ReadOnly = true;
            this.cKeterangan.Width = 250;
            // 
            // cCatatan
            // 
            this.cCatatan.DataPropertyName = "Catatan";
            this.cCatatan.HeaderText = "Catatan";
            this.cCatatan.Name = "cCatatan";
            this.cCatatan.ReadOnly = true;
            // 
            // cFormula
            // 
            this.cFormula.DataPropertyName = "Formula";
            this.cFormula.HeaderText = "Formula";
            this.cFormula.Name = "cFormula";
            this.cFormula.ReadOnly = true;
            // 
            // cLMinus
            // 
            this.cLMinus.DataPropertyName = "LMinus";
            this.cLMinus.HeaderText = "LMinus";
            this.cLMinus.Name = "cLMinus";
            this.cLMinus.ReadOnly = true;
            this.cLMinus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cTUnderLine
            // 
            this.cTUnderLine.DataPropertyName = "TUnderLine";
            this.cTUnderLine.HeaderText = "TUnderLine";
            this.cTUnderLine.Name = "cTUnderLine";
            this.cTUnderLine.ReadOnly = true;
            this.cTUnderLine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cTUnderLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cDUnderline
            // 
            this.cDUnderline.DataPropertyName = "DUnderline";
            this.cDUnderline.HeaderText = "DUnderline";
            this.cDUnderline.Name = "cDUnderline";
            this.cDUnderline.ReadOnly = true;
            this.cDUnderline.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cDUnderline.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cBold
            // 
            this.cBold.DataPropertyName = "Bold";
            this.cBold.HeaderText = "Bold";
            this.cBold.Name = "cBold";
            this.cBold.ReadOnly = true;
            this.cBold.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cBold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(600, 307);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmGlReportDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(833, 358);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgGL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLookup);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmGlReportDesign";
            this.Text = "GL Report Design";
            this.Load += new System.EventHandler(this.frmGlReportDesign_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cbLookup, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgGL, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgGL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLookup;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private ISA.Controls.CustomGridView dgGL;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNoUrut;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCatatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLMinus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cTUnderLine;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cDUnderline;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cBold;
    }
}
