namespace ISA.Toko.Master
{
    partial class frmPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPriceList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbStok = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKlp = new System.Windows.Forms.ComboBox();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdPrint = new ISA.Toko.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbStok);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbKlp);
            this.groupBox1.Location = new System.Drawing.Point(9, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "FILTER DATA";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(347, 144);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(39, 18);
            this.rbAll.TabIndex = 3;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbStok
            // 
            this.rbStok.AutoSize = true;
            this.rbStok.Location = new System.Drawing.Point(347, 120);
            this.rbStok.Name = "rbStok";
            this.rbStok.Size = new System.Drawing.Size(92, 18);
            this.rbStok.TabIndex = 2;
            this.rbStok.TabStop = true;
            this.rbStok.Text = "Stock Ready";
            this.rbStok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "KELOMPOK BARANG";
            // 
            // cmbKlp
            // 
            this.cmbKlp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbKlp.FormattingEnabled = true;
            this.cmbKlp.Location = new System.Drawing.Point(346, 80);
            this.cmbKlp.Name = "cmbKlp";
            this.cmbKlp.Size = new System.Drawing.Size(121, 22);
            this.cmbKlp.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(356, 281);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdPrint.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(254, 281);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // frmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPriceList";
            this.Text = "PRICE LIST";
            this.Title = "PRICE LIST";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmPriceList_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ISA.Toko.Controls.CommandButton cmdPrint;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ComboBox cmbKlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbStok;
    }
}
