namespace ISA.Trading.Expedisi
{
    partial class frmRptRekapChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapChecker));
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChecker = new System.Windows.Forms.ComboBox();
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.rdoChecker1 = new System.Windows.Forms.RadioButton();
            this.rdoChecker2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(303, 148);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdShow
            // 
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(180, 148);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(100, 40);
            this.cmdShow.TabIndex = 4;
            this.cmdShow.Text = "YES";
            this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "Checker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tanggal Surat Jalan";
            // 
            // cboChecker
            // 
            this.cboChecker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboChecker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChecker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChecker.FormattingEnabled = true;
            this.cboChecker.Location = new System.Drawing.Point(181, 93);
            this.cboChecker.Name = "cboChecker";
            this.cboChecker.Size = new System.Drawing.Size(140, 22);
            this.cboChecker.TabIndex = 1;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(175, 66);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // rdoChecker1
            // 
            this.rdoChecker1.AutoSize = true;
            this.rdoChecker1.Location = new System.Drawing.Point(181, 123);
            this.rdoChecker1.Name = "rdoChecker1";
            this.rdoChecker1.Size = new System.Drawing.Size(88, 18);
            this.rdoChecker1.TabIndex = 2;
            this.rdoChecker1.TabStop = true;
            this.rdoChecker1.Text = "Checker 1";
            this.rdoChecker1.UseVisualStyleBackColor = true;
            // 
            // rdoChecker2
            // 
            this.rdoChecker2.AutoSize = true;
            this.rdoChecker2.Location = new System.Drawing.Point(303, 123);
            this.rdoChecker2.Name = "rdoChecker2";
            this.rdoChecker2.Size = new System.Drawing.Size(88, 18);
            this.rdoChecker2.TabIndex = 3;
            this.rdoChecker2.TabStop = true;
            this.rdoChecker2.Text = "Checker 2";
            this.rdoChecker2.UseVisualStyleBackColor = true;
            // 
            // frmRptRekapChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.rdoChecker2);
            this.Controls.Add(this.rdoChecker1);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.cboChecker);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRekapChecker";
            this.Text = "Laporan Rekap Checker";
            this.Title = "Laporan Rekap Checker";
            this.Load += new System.EventHandler(this.frmRptRekapChecker_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.cboChecker, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.rdoChecker1, 0);
            this.Controls.SetChildIndex(this.rdoChecker2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboChecker;
        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.RadioButton rdoChecker1;
        private System.Windows.Forms.RadioButton rdoChecker2;
    }
}
