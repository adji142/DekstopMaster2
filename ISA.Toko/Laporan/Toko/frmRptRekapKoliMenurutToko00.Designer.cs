namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptRekapKoliMenurutToko00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRekapKoliMenurutToko00));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeTanggalNota = new ISA.Toko.Controls.RangeDateBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdbShift1 = new System.Windows.Forms.RadioButton();
            this.rdbShift2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tanggal Nota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shift ";
            // 
            // rangeTanggalNota
            // 
            this.rangeTanggalNota.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeTanggalNota.FromDate = null;
            this.rangeTanggalNota.Location = new System.Drawing.Point(120, 66);
            this.rangeTanggalNota.Name = "rangeTanggalNota";
            this.rangeTanggalNota.Size = new System.Drawing.Size(257, 22);
            this.rangeTanggalNota.TabIndex = 0;
            this.rangeTanggalNota.ToDate = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rdbShift1
            // 
            this.rdbShift1.AutoSize = true;
            this.rdbShift1.Location = new System.Drawing.Point(6, 19);
            this.rdbShift1.Name = "rdbShift1";
            this.rdbShift1.Size = new System.Drawing.Size(74, 18);
            this.rdbShift1.TabIndex = 0;
            this.rdbShift1.TabStop = true;
            this.rdbShift1.Text = "Shift 1";
            this.rdbShift1.UseVisualStyleBackColor = true;
            // 
            // rdbShift2
            // 
            this.rdbShift2.AutoSize = true;
            this.rdbShift2.Location = new System.Drawing.Point(89, 19);
            this.rdbShift2.Name = "rdbShift2";
            this.rdbShift2.Size = new System.Drawing.Size(74, 18);
            this.rdbShift2.TabIndex = 1;
            this.rdbShift2.TabStop = true;
            this.rdbShift2.Text = "Shift 2";
            this.rdbShift2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbShift1);
            this.groupBox1.Controls.Add(this.rdbShift2);
            this.groupBox1.Location = new System.Drawing.Point(157, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 48);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cmdYes
            // 
            this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(9, 176);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 1;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(334, 176);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRptRekapKoliMenurutToko00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(445, 228);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rangeTanggalNota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRptRekapKoliMenurutToko00";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptRekapKoliMenurutToko00_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rangeTanggalNota, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.RangeDateBox rangeTanggalNota;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbShift1;
        private System.Windows.Forms.RadioButton rdbShift2;
    }
}
