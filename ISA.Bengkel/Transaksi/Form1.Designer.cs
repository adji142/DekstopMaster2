namespace ISA.Bengkel.Transaksi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.no_pol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kd_cust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamaat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kd_spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jns_spm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keluhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(22, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 244);
            this.panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no_pol,
            this.NamaCust,
            this.Kd_cust,
            this.MemberId,
            this.nomorid,
            this.telp,
            this.Alamaat,
            this.spm,
            this.kd_spm,
            this.jns_spm,
            this.warna,
            this.tahun,
            this.km,
            this.keluhan});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nomor Polisi";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(970, 384);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // no_pol
            // 
            this.no_pol.DataPropertyName = "no_pol";
            this.no_pol.HeaderText = "NO POLISI";
            this.no_pol.Name = "no_pol";
            this.no_pol.ReadOnly = true;
            this.no_pol.Width = 150;
            // 
            // NamaCust
            // 
            this.NamaCust.DataPropertyName = "nama_cust";
            this.NamaCust.HeaderText = "PEMILIK";
            this.NamaCust.Name = "NamaCust";
            this.NamaCust.ReadOnly = true;
            this.NamaCust.Width = 200;
            // 
            // Kd_cust
            // 
            this.Kd_cust.DataPropertyName = "kd_cust";
            this.Kd_cust.HeaderText = "KODE CUSTOMER";
            this.Kd_cust.Name = "Kd_cust";
            this.Kd_cust.ReadOnly = true;
            this.Kd_cust.Width = 150;
            // 
            // MemberId
            // 
            this.MemberId.DataPropertyName = "id_member";
            this.MemberId.HeaderText = "MEMBER ID";
            this.MemberId.Name = "MemberId";
            this.MemberId.ReadOnly = true;
            // 
            // nomorid
            // 
            this.nomorid.DataPropertyName = "no_id";
            this.nomorid.HeaderText = "NO KTP";
            this.nomorid.Name = "nomorid";
            this.nomorid.ReadOnly = true;
            // 
            // telp
            // 
            this.telp.DataPropertyName = "no_telp";
            this.telp.HeaderText = "NO TELP";
            this.telp.Name = "telp";
            this.telp.ReadOnly = true;
            // 
            // Alamaat
            // 
            this.Alamaat.DataPropertyName = "alamat";
            this.Alamaat.HeaderText = "ALAMAT";
            this.Alamaat.Name = "Alamaat";
            this.Alamaat.ReadOnly = true;
            // 
            // spm
            // 
            this.spm.DataPropertyName = "spm";
            this.spm.HeaderText = "SEPEDA MOTOR";
            this.spm.Name = "spm";
            this.spm.ReadOnly = true;
            this.spm.Width = 200;
            // 
            // kd_spm
            // 
            this.kd_spm.DataPropertyName = "kd_spm";
            this.kd_spm.HeaderText = "KODE SEPEDA MOTOR";
            this.kd_spm.Name = "kd_spm";
            this.kd_spm.ReadOnly = true;
            this.kd_spm.Width = 150;
            // 
            // jns_spm
            // 
            this.jns_spm.DataPropertyName = "jns_spm";
            this.jns_spm.HeaderText = "JENIS SEPEDA MOTOR";
            this.jns_spm.Name = "jns_spm";
            this.jns_spm.ReadOnly = true;
            this.jns_spm.Width = 150;
            // 
            // warna
            // 
            this.warna.DataPropertyName = "warna";
            this.warna.HeaderText = "WARNA";
            this.warna.Name = "warna";
            this.warna.ReadOnly = true;
            // 
            // tahun
            // 
            this.tahun.DataPropertyName = "tahun";
            this.tahun.HeaderText = "TAHUN";
            this.tahun.Name = "tahun";
            this.tahun.ReadOnly = true;
            // 
            // km
            // 
            this.km.DataPropertyName = "km";
            this.km.HeaderText = "KM";
            this.km.Name = "km";
            this.km.ReadOnly = true;
            this.km.Width = 50;
            // 
            // keluhan
            // 
            this.keluhan.DataPropertyName = "keluhan";
            this.keluhan.HeaderText = "KELUHAN";
            this.keluhan.Name = "keluhan";
            this.keluhan.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 462);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Data Service";
            this.Title = "Data Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_pol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kd_cust;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomorid;
        private System.Windows.Forms.DataGridViewTextBoxColumn telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamaat;
        private System.Windows.Forms.DataGridViewTextBoxColumn spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn kd_spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn jns_spm;
        private System.Windows.Forms.DataGridViewTextBoxColumn warna;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn km;
        private System.Windows.Forms.DataGridViewTextBoxColumn keluhan;
    }
}