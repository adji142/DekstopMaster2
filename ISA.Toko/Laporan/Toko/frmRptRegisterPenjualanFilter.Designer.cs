namespace ISA.Toko.Laporan.Toko
{
    partial class frmRptRegisterPenjualanFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRegisterPenjualanFilter));
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdYES = new ISA.Toko.Controls.CommandButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoHrgNetto = new System.Windows.Forms.RadioButton();
            this.rdoHrgBruto = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTglTerima = new System.Windows.Forms.RadioButton();
            this.rdoTglNota = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbTgl = new ISA.Toko.Controls.RangeDateBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(192, 207);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 2;
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
            this.cmdYES.Location = new System.Drawing.Point(83, 207);
            this.cmdYES.Name = "cmdYES";
            this.cmdYES.Size = new System.Drawing.Size(100, 40);
            this.cmdYES.TabIndex = 1;
            this.cmdYES.Text = "YES";
            this.cmdYES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYES.UseVisualStyleBackColor = true;
            this.cmdYES.Click += new System.EventHandler(this.cmdYES_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoHrgNetto);
            this.groupBox2.Controls.Add(this.rdoHrgBruto);
            this.groupBox2.Location = new System.Drawing.Point(45, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 33);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rdoHrgNetto
            // 
            this.rdoHrgNetto.AutoSize = true;
            this.rdoHrgNetto.Location = new System.Drawing.Point(109, 11);
            this.rdoHrgNetto.Name = "rdoHrgNetto";
            this.rdoHrgNetto.Size = new System.Drawing.Size(54, 18);
            this.rdoHrgNetto.TabIndex = 1;
            this.rdoHrgNetto.TabStop = true;
            this.rdoHrgNetto.Text = "Netto";
            this.rdoHrgNetto.UseVisualStyleBackColor = true;
            // 
            // rdoHrgBruto
            // 
            this.rdoHrgBruto.AutoSize = true;
            this.rdoHrgBruto.Location = new System.Drawing.Point(7, 11);
            this.rdoHrgBruto.Name = "rdoHrgBruto";
            this.rdoHrgBruto.Size = new System.Drawing.Size(55, 18);
            this.rdoHrgBruto.TabIndex = 0;
            this.rdoHrgBruto.TabStop = true;
            this.rdoHrgBruto.Text = "Bruto";
            this.rdoHrgBruto.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoTglTerima);
            this.groupBox1.Controls.Add(this.rdoTglNota);
            this.groupBox1.Location = new System.Drawing.Point(45, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 33);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdoTglTerima
            // 
            this.rdoTglTerima.AutoSize = true;
            this.rdoTglTerima.Location = new System.Drawing.Point(109, 11);
            this.rdoTglTerima.Name = "rdoTglTerima";
            this.rdoTglTerima.Size = new System.Drawing.Size(83, 18);
            this.rdoTglTerima.TabIndex = 1;
            this.rdoTglTerima.TabStop = true;
            this.rdoTglTerima.Text = "Tgl.Terima";
            this.rdoTglTerima.UseVisualStyleBackColor = true;
            // 
            // rdoTglNota
            // 
            this.rdoTglNota.AutoSize = true;
            this.rdoTglNota.Location = new System.Drawing.Point(7, 11);
            this.rdoTglNota.Name = "rdoTglNota";
            this.rdoTglNota.Size = new System.Drawing.Size(69, 18);
            this.rdoTglNota.TabIndex = 0;
            this.rdoTglNota.TabStop = true;
            this.rdoTglNota.Text = "Tgl.Nota";
            this.rdoTglNota.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tanggal:";
            // 
            // rdbTgl
            // 
            this.rdbTgl.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rdbTgl.FromDate = null;
            this.rdbTgl.Location = new System.Drawing.Point(104, 66);
            this.rdbTgl.Name = "rdbTgl";
            this.rdbTgl.Size = new System.Drawing.Size(257, 22);
            this.rdbTgl.TabIndex = 0;
            this.rdbTgl.ToDate = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRptRegisterPenjualanFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(369, 255);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdYES);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbTgl);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 293);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 293);
            this.Name = "frmRptRegisterPenjualanFilter";
            this.Text = "Register Penjualan";
            this.Title = "Register Penjualan";
            this.Load += new System.EventHandler(this.frmRptRegisterPenjualanFilter_Load);
            this.Controls.SetChildIndex(this.rdbTgl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cmdYES, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdYES;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoHrgNetto;
        private System.Windows.Forms.RadioButton rdoHrgBruto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTglTerima;
        private System.Windows.Forms.RadioButton rdoTglNota;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.RangeDateBox rdbTgl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
