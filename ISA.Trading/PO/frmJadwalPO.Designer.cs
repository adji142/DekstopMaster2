namespace ISA.Trading.PO
{
    partial class frmJadwalPO
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbKodeGdg = new System.Windows.Forms.ComboBox();
            this.txtJadwalPo = new System.Windows.Forms.TextBox();
            this.txtJadwalXpdc = new System.Windows.Forms.TextBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.customGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.kd_gudang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jdwl_po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jdwl_kirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdDownload = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "kd.Gudang";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jadwal PO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jadwal XPDC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Catatan";
            // 
            // cbKodeGdg
            // 
            this.cbKodeGdg.Enabled = false;
            this.cbKodeGdg.FormattingEnabled = true;
            this.cbKodeGdg.Location = new System.Drawing.Point(154, 66);
            this.cbKodeGdg.Name = "cbKodeGdg";
            this.cbKodeGdg.Size = new System.Drawing.Size(121, 22);
            this.cbKodeGdg.TabIndex = 9;
            // 
            // txtJadwalPo
            // 
            this.txtJadwalPo.Location = new System.Drawing.Point(154, 105);
            this.txtJadwalPo.Name = "txtJadwalPo";
            this.txtJadwalPo.Size = new System.Drawing.Size(285, 20);
            this.txtJadwalPo.TabIndex = 10;
            // 
            // txtJadwalXpdc
            // 
            this.txtJadwalXpdc.Location = new System.Drawing.Point(154, 142);
            this.txtJadwalXpdc.Name = "txtJadwalXpdc";
            this.txtJadwalXpdc.Size = new System.Drawing.Size(285, 20);
            this.txtJadwalXpdc.TabIndex = 11;
            // 
            // txtCatatan
            // 
            this.txtCatatan.Location = new System.Drawing.Point(154, 179);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(285, 20);
            this.txtCatatan.TabIndex = 12;
            this.txtCatatan.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kd_gudang,
            this.jdwl_po,
            this.jdwl_kirim,
            this.catatan,
            this.lm});
            this.customGridView1.Location = new System.Drawing.Point(31, 221);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(994, 262);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 13;
            // 
            // kd_gudang
            // 
            this.kd_gudang.DataPropertyName = "kd_gdg";
            this.kd_gudang.HeaderText = "Kode Gudang";
            this.kd_gudang.Name = "kd_gudang";
            this.kd_gudang.Width = 150;
            // 
            // jdwl_po
            // 
            this.jdwl_po.DataPropertyName = "hari_po";
            this.jdwl_po.HeaderText = "Jadwal PO";
            this.jdwl_po.Name = "jdwl_po";
            this.jdwl_po.Width = 250;
            // 
            // jdwl_kirim
            // 
            this.jdwl_kirim.DataPropertyName = "hari_xpdc";
            this.jdwl_kirim.HeaderText = "Jadwal Pengiriman";
            this.jdwl_kirim.Name = "jdwl_kirim";
            this.jdwl_kirim.Width = 250;
            // 
            // catatan
            // 
            this.catatan.DataPropertyName = "catatan";
            this.catatan.HeaderText = "Catatan";
            this.catatan.Name = "catatan";
            this.catatan.Width = 250;
            // 
            // lm
            // 
            this.lm.DataPropertyName = "SyncFlag";
            this.lm.HeaderText = "lm";
            this.lm.Name = "lm";
            this.lm.Width = 50;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdUpload.Image = global::ISA.Trading.Properties.Resources.Upload32;
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(624, 520);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(94, 37);
            this.cmdUpload.TabIndex = 14;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDownload.Image = global::ISA.Trading.Properties.Resources.Download32;
            this.cmdDownload.Location = new System.Drawing.Point(753, 520);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(109, 37);
            this.cmdDownload.TabIndex = 15;
            this.cmdDownload.Text = "Download";
            this.cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdExit.Image = global::ISA.Trading.Properties.Resources.Delete32;
            this.cmdExit.Location = new System.Drawing.Point(892, 520);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(94, 37);
            this.cmdExit.TabIndex = 16;
            this.cmdExit.Text = "Exit";
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmJadwalPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 566);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJadwalXpdc);
            this.Controls.Add(this.txtJadwalPo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.cbKodeGdg);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJadwalPO";
            this.Text = "frmJadwalPO";
            this.Load += new System.EventHandler(this.frmJadwalPO_Load);
            this.Controls.SetChildIndex(this.cbKodeGdg, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtJadwalPo, 0);
            this.Controls.SetChildIndex(this.txtJadwalXpdc, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmdExit, 0);
            this.Controls.SetChildIndex(this.txtCatatan, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.cmdDownload, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKodeGdg;
        private System.Windows.Forms.TextBox txtJadwalPo;
        private System.Windows.Forms.TextBox txtJadwalXpdc;
        private System.Windows.Forms.TextBox txtCatatan;
        private ISA.Trading.Controls.CustomGridView customGridView1;
        private System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.Button cmdDownload;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_gudang;
        private System.Windows.Forms.DataGridViewTextBoxColumn jdwl_po;
        private System.Windows.Forms.DataGridViewTextBoxColumn jdwl_kirim;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn lm;
    }
}