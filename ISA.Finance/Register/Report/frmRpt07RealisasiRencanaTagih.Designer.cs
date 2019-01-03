namespace ISA.Finance.Register.Report
{
    partial class frmRpt07RealisasiRencanaTagih
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt07RealisasiRencanaTagih));
            this.dateTextBox1 = new ISA.Controls.DateTextBox();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbRekap = new System.Windows.Forms.RadioButton();
            this.rdbDetil = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbDetail2 = new System.Windows.Forms.RadioButton();
            this.rdbDetail1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(93, 25);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(112, 20);
            this.dateTextBox1.TabIndex = 3;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 232);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 4;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(391, 232);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 5;
            this.commandButton2.TabStop = false;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Overdue";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb3);
            this.groupBox1.Controls.Add(this.rdb2);
            this.groupBox1.Controls.Add(this.rdb1);
            this.groupBox1.Location = new System.Drawing.Point(93, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 47);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(281, 20);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(39, 18);
            this.rdb3.TabIndex = 2;
            this.rdb3.Text = "All";
            this.rdb3.UseVisualStyleBackColor = true;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Checked = true;
            this.rdb2.Location = new System.Drawing.Point(119, 20);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(37, 18);
            this.rdb2.TabIndex = 1;
            this.rdb2.TabStop = true;
            this.rdb2.Text = ">7";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Location = new System.Drawing.Point(7, 20);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(43, 18);
            this.rdb1.TabIndex = 0;
            this.rdb1.Text = "<=7";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbRekap);
            this.groupBox2.Controls.Add(this.rdbDetil);
            this.groupBox2.Location = new System.Drawing.Point(127, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 47);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // rdbRekap
            // 
            this.rdbRekap.AutoSize = true;
            this.rdbRekap.Location = new System.Drawing.Point(119, 20);
            this.rdbRekap.Name = "rdbRekap";
            this.rdbRekap.Size = new System.Drawing.Size(59, 18);
            this.rdbRekap.TabIndex = 1;
            this.rdbRekap.Text = "Rekap";
            this.rdbRekap.UseVisualStyleBackColor = true;
            this.rdbRekap.CheckedChanged += new System.EventHandler(this.rdbRekap_CheckedChanged);
            // 
            // rdbDetil
            // 
            this.rdbDetil.AutoSize = true;
            this.rdbDetil.Checked = true;
            this.rdbDetil.Location = new System.Drawing.Point(7, 20);
            this.rdbDetil.Name = "rdbDetil";
            this.rdbDetil.Size = new System.Drawing.Size(49, 18);
            this.rdbDetil.TabIndex = 0;
            this.rdbDetil.TabStop = true;
            this.rdbDetil.Text = "Detil";
            this.rdbDetil.UseVisualStyleBackColor = true;
            this.rdbDetil.CheckedChanged += new System.EventHandler(this.rdbDetil_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Format Laporan";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbDetail2);
            this.groupBox3.Controls.Add(this.rdbDetail1);
            this.groupBox3.Location = new System.Drawing.Point(127, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 47);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // rdbDetail2
            // 
            this.rdbDetail2.AutoSize = true;
            this.rdbDetail2.Location = new System.Drawing.Point(119, 20);
            this.rdbDetail2.Name = "rdbDetail2";
            this.rdbDetail2.Size = new System.Drawing.Size(70, 18);
            this.rdbDetail2.TabIndex = 1;
            this.rdbDetail2.Text = "Format2";
            this.rdbDetail2.UseVisualStyleBackColor = true;
            // 
            // rdbDetail1
            // 
            this.rdbDetail1.AutoSize = true;
            this.rdbDetail1.Checked = true;
            this.rdbDetail1.Location = new System.Drawing.Point(7, 20);
            this.rdbDetail1.Name = "rdbDetail1";
            this.rdbDetail1.Size = new System.Drawing.Size(70, 18);
            this.rdbDetail1.TabIndex = 0;
            this.rdbDetail1.TabStop = true;
            this.rdbDetail1.Text = "Format1";
            this.rdbDetail1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Format Detail";
            // 
            // frmRpt07RealisasiRencanaTagih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(503, 284);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.dateTextBox1);
            this.MaximizeBox = false;
            this.Name = "frmRpt07RealisasiRencanaTagih";
            this.Text = "Laporan Realisasi Tagihan Nota & BGC";
            this.Load += new System.EventHandler(this.frmRpt07RealisasiRencanaTagih_Load);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.DateTextBox dateTextBox1;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbRekap;
        private System.Windows.Forms.RadioButton rdbDetil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbDetail2;
        private System.Windows.Forms.RadioButton rdbDetail1;
        private System.Windows.Forms.Label label4;
    }
}
