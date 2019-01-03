namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptJWJSFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptJWJSFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTgl = new ISA.Toko.Controls.RangeDateBox();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCabang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKodeTrans = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tanggal";
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(125, 65);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 0;
            this.rdbTgl.ToDate = null;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(238, 162);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 4;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdYES
            // 
            this.cmdYES.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            this.cmdYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYES.Image = ((System.Drawing.Image)(resources.GetObject("cmdYES.Image")));
            this.cmdYES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYES.Location = new System.Drawing.Point(129, 162);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 3;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 50;
            this.label6.Text = "Cabang";
            // 
            // cboCabang
            // 
            this.cboCabang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCabang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCabang.FormattingEnabled = true;
            this.cboCabang.Location = new System.Drawing.Point(132, 134);
            this.cboCabang.Name = "cboCabang";
            this.cboCabang.Size = new System.Drawing.Size(180, 22);
            this.cboCabang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 54;
            this.label2.Text = "Kd Transaksi";
            // 
            // cboKodeTrans
            // 
            this.cboKodeTrans.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboKodeTrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKodeTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodeTrans.FormattingEnabled = true;
            this.cboKodeTrans.Location = new System.Drawing.Point(132, 101);
            this.cboKodeTrans.Name = "cboKodeTrans";
            this.cboKodeTrans.Size = new System.Drawing.Size(45, 22);
            this.cboKodeTrans.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptJWJSFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(397, 233);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboKodeTrans);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCabang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbTgl);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 260);
            this.MinimumSize = new System.Drawing.Size(405, 260);
            this.Name = "frmRptJWJSFilter";
            this.Text = "JW / JS";
            this.Title = "JW / JS";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmRptJWJSFilter_Load);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboCabang, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboKodeTrans, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rdbTgl;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCabang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKodeTrans;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
