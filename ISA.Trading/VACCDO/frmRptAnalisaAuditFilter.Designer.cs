namespace ISA.Trading.VACCDO
{
    partial class frmRptAnalisaAuditFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAnalisaAuditFilter));
            this.lookupPostArea = new ISA.Trading.Controls.LookupPostArea();
            this.txtC1 = new ISA.Trading.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lookupPostArea
            // 
            this.lookupPostArea.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupPostArea.Location = new System.Drawing.Point(97, 125);
            this.lookupPostArea.Name = "lookupPostArea";
            this.lookupPostArea.PostID = "";
            this.lookupPostArea.PostName = null;
            this.lookupPostArea.Size = new System.Drawing.Size(233, 28);
            this.lookupPostArea.TabIndex = 3;
            // 
            // txtC1
            // 
            this.txtC1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtC1.Location = new System.Drawing.Point(101, 97);
            this.txtC1.MaxLength = 2;
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(34, 20);
            this.txtC1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "POS ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "C1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Per Bulan";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(220, 159);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 5;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(97, 159);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 4;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMonth.Location = new System.Drawing.Point(101, 66);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(45, 22);
            this.cboMonth.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tahun";
            // 
            // cboYear
            // 
            this.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(203, 66);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(61, 22);
            this.cboYear.TabIndex = 1;
            // 
            // frmRptAnalisaAuditFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(372, 222);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.lookupPostArea);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.txtC1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 256);
            this.MinimumSize = new System.Drawing.Size(380, 256);
            this.Name = "frmRptAnalisaAuditFilter";
            this.Text = "Analisa Audit DO ACC";
            this.Title = "Analisa Audit DO ACC";
            this.Load += new System.EventHandler(this.frmRptAnalisaAuditFilter_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtC1, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.lookupPostArea, 0);
            this.Controls.SetChildIndex(this.cboMonth, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboYear, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.LookupPostArea lookupPostArea;
        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private ISA.Trading.Controls.CommandButton cmdYES;
        private ISA.Trading.Controls.CommonTextBox txtC1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboYear;
    }
}
