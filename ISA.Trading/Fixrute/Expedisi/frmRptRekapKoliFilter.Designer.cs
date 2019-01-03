namespace ISA.Trading.Expedisi
{
    partial class frmRptRekapKoliFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapKoliFilter));
            this.rangeDateBox1 = new ISA.Trading.Controls.RangeDateBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdShow = new ISA.Trading.Controls.CommandButton();
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbShift2 = new System.Windows.Forms.RadioButton();
            this.rdbShift1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSales = new System.Windows.Forms.RadioButton();
            this.rdbToko = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(130, 66);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 0;
            this.rangeDateBox1.ToDate = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal Nota";
            // 
            // cmdShow
            // 
            this.cmdShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdShow.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.cmdShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdShow.Image = ((System.Drawing.Image)(resources.GetObject("cmdShow.Image")));
            this.cmdShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdShow.Location = new System.Drawing.Point(12, 289);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(100, 40);
            this.cmdShow.TabIndex = 1;
            this.cmdShow.Text = "YES";
            this.cmdShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(591, 289);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 2;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Shift";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Menurut";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbShift2);
            this.groupBox1.Controls.Add(this.rdbShift1);
            this.groupBox1.Location = new System.Drawing.Point(130, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // rdbShift2
            // 
            this.rdbShift2.AutoSize = true;
            this.rdbShift2.Location = new System.Drawing.Point(94, 19);
            this.rdbShift2.Name = "rdbShift2";
            this.rdbShift2.Size = new System.Drawing.Size(67, 18);
            this.rdbShift2.TabIndex = 1;
            this.rdbShift2.TabStop = true;
            this.rdbShift2.Text = "Shift2";
            this.rdbShift2.UseVisualStyleBackColor = true;
            // 
            // rdbShift1
            // 
            this.rdbShift1.AutoSize = true;
            this.rdbShift1.Location = new System.Drawing.Point(6, 19);
            this.rdbShift1.Name = "rdbShift1";
            this.rdbShift1.Size = new System.Drawing.Size(67, 18);
            this.rdbShift1.TabIndex = 0;
            this.rdbShift1.TabStop = true;
            this.rdbShift1.Text = "Shift1";
            this.rdbShift1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbSales);
            this.groupBox2.Controls.Add(this.rdbToko);
            this.groupBox2.Location = new System.Drawing.Point(130, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 52);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // rdbSales
            // 
            this.rdbSales.AutoSize = true;
            this.rdbSales.Location = new System.Drawing.Point(94, 19);
            this.rdbSales.Name = "rdbSales";
            this.rdbSales.Size = new System.Drawing.Size(60, 18);
            this.rdbSales.TabIndex = 1;
            this.rdbSales.TabStop = true;
            this.rdbSales.Text = "Sales";
            this.rdbSales.UseVisualStyleBackColor = true;
            // 
            // rdbToko
            // 
            this.rdbToko.AutoSize = true;
            this.rdbToko.Location = new System.Drawing.Point(6, 19);
            this.rdbToko.Name = "rdbToko";
            this.rdbToko.Size = new System.Drawing.Size(53, 18);
            this.rdbToko.TabIndex = 0;
            this.rdbToko.TabStop = true;
            this.rdbToko.Text = "Toko";
            this.rdbToko.UseVisualStyleBackColor = true;
            // 
            // frmRptRekapKoliFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(703, 341);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.commandButton2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRekapKoliFilter";
            this.Text = "Laporan Rekap Koli";
            this.Title = "Laporan Rekap Koli";
            this.Load += new System.EventHandler(this.frmRptRekapKoliFilter_Load);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.cmdShow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommandButton cmdShow;
        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbShift2;
        private System.Windows.Forms.RadioButton rdbShift1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbSales;
        private System.Windows.Forms.RadioButton rdbToko;

    }
}
