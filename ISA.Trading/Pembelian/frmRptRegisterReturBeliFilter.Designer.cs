namespace ISA.Trading.Pembelian
{
    partial class frmRptRegisterReturBeliFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRegisterReturBeliFilter));
            this.cmdCLOSE = new ISA.Trading.Controls.CommandButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdYES = new ISA.Trading.Controls.CommandButton();
            this.cboGudang = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoTglKeluar = new System.Windows.Forms.RadioButton();
            this.rdoTglRetur = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.monthYearBox1 = new ISA.Controls.MonthYearBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t2 = new ISA.Controls.DateTextBox();
            this.T1 = new ISA.Controls.DateTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p1 = new System.Windows.Forms.RadioButton();
            this.p2 = new System.Windows.Forms.RadioButton();
            this.p0 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(385, 255);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 7;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "Gudang:";
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(9, 255);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 6;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // cboGudang
            // 
            this.cboGudang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGudang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGudang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGudang.FormattingEnabled = true;
            this.cboGudang.Location = new System.Drawing.Point(107, 173);
            this.cboGudang.Name = "cboGudang";
            this.cboGudang.Size = new System.Drawing.Size(230, 22);
            this.cboGudang.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoTglKeluar);
            this.groupBox2.Controls.Add(this.rdoTglRetur);
            this.groupBox2.Location = new System.Drawing.Point(30, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 34);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // rdoTglKeluar
            // 
            this.rdoTglKeluar.AutoSize = true;
            this.rdoTglKeluar.Checked = true;
            this.rdoTglKeluar.Location = new System.Drawing.Point(124, 12);
            this.rdoTglKeluar.Name = "rdoTglKeluar";
            this.rdoTglKeluar.Size = new System.Drawing.Size(95, 18);
            this.rdoTglKeluar.TabIndex = 1;
            this.rdoTglKeluar.TabStop = true;
            this.rdoTglKeluar.Text = "Tanggal MPR";
            this.rdoTglKeluar.UseVisualStyleBackColor = true;
            // 
            // rdoTglRetur
            // 
            this.rdoTglRetur.AutoSize = true;
            this.rdoTglRetur.Location = new System.Drawing.Point(17, 12);
            this.rdoTglRetur.Name = "rdoTglRetur";
            this.rdoTglRetur.Size = new System.Drawing.Size(101, 18);
            this.rdoTglRetur.TabIndex = 0;
            this.rdoTglRetur.Text = "Tanggal Retur";
            this.rdoTglRetur.UseVisualStyleBackColor = true;
            this.rdoTglRetur.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 78;
            this.label3.Text = "Periode:";
            // 
            // monthYearBox1
            // 
            this.monthYearBox1.Location = new System.Drawing.Point(107, 111);
            this.monthYearBox1.Month = 1;
            this.monthYearBox1.Name = "monthYearBox1";
            this.monthYearBox1.Size = new System.Drawing.Size(370, 27);
            this.monthYearBox1.TabIndex = 1;
            this.monthYearBox1.Year = 2012;
            this.monthYearBox1.Validating += new System.ComponentModel.CancelEventHandler(this.monthYearBox1_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 14);
            this.label1.TabIndex = 77;
            this.label1.Text = "s/d";
            // 
            // t2
            // 
            this.t2.DateValue = null;
            this.t2.Location = new System.Drawing.Point(274, 144);
            this.t2.MaxLength = 10;
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(122, 20);
            this.t2.TabIndex = 3;
            // 
            // T1
            // 
            this.T1.DateValue = null;
            this.T1.Location = new System.Drawing.Point(107, 147);
            this.T1.MaxLength = 10;
            this.T1.Name = "T1";
            this.T1.Size = new System.Drawing.Size(121, 20);
            this.T1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Controls.Add(this.p2);
            this.groupBox1.Controls.Add(this.p0);
            this.groupBox1.Location = new System.Drawing.Point(31, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 37);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // p1
            // 
            this.p1.AutoSize = true;
            this.p1.Location = new System.Drawing.Point(130, 12);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(77, 18);
            this.p1.TabIndex = 1;
            this.p1.Text = "Periode 1";
            this.p1.UseVisualStyleBackColor = true;
            this.p1.CheckedChanged += new System.EventHandler(this.p1_CheckedChanged);
            // 
            // p2
            // 
            this.p2.AutoSize = true;
            this.p2.Location = new System.Drawing.Point(233, 12);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(77, 18);
            this.p2.TabIndex = 2;
            this.p2.Text = "Periode 2";
            this.p2.UseVisualStyleBackColor = true;
            this.p2.CheckedChanged += new System.EventHandler(this.p2_CheckedChanged);
            // 
            // p0
            // 
            this.p0.AutoSize = true;
            this.p0.Checked = true;
            this.p0.Location = new System.Drawing.Point(17, 12);
            this.p0.Name = "p0";
            this.p0.Size = new System.Drawing.Size(92, 18);
            this.p0.TabIndex = 0;
            this.p0.TabStop = true;
            this.p0.Text = "Non Periode";
            this.p0.UseVisualStyleBackColor = true;
            this.p0.CheckedChanged += new System.EventHandler(this.p0_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 76;
            this.label2.Text = "Tgl :";
            // 
            // frmRptRegisterReturBeliFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(497, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthYearBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.T1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.cboGudang);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRegisterReturBeliFilter";
            this.Text = "Laporan Register Retur Beli";
            this.Title = "Laporan Register Retur Beli";
            this.Load += new System.EventHandler(this.frmRptRegisterReturBeliFilter_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cboGudang, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.T1, 0);
            this.Controls.SetChildIndex(this.t2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.monthYearBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdCLOSE;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CommandButton cmdYES;
        private System.Windows.Forms.ComboBox cboGudang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoTglKeluar;
        private System.Windows.Forms.RadioButton rdoTglRetur;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.MonthYearBox monthYearBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.DateTextBox t2;
        private ISA.Controls.DateTextBox T1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton p1;
        private System.Windows.Forms.RadioButton p2;
        private System.Windows.Forms.RadioButton p0;
        private System.Windows.Forms.Label label2;
    }
}
