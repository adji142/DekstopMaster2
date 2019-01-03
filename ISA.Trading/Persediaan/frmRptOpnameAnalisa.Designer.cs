namespace ISA.Trading.Persediaan
    {
    partial class frmRptOpnameAnalisa
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing&&(components!=null))
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOpnameAnalisa));
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.rdbA2 = new System.Windows.Forms.RadioButton();
                this.rdbA1 = new System.Windows.Forms.RadioButton();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.rdbC3 = new System.Windows.Forms.RadioButton();
                this.rdbC2 = new System.Windows.Forms.RadioButton();
                this.rdbC1 = new System.Windows.Forms.RadioButton();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.rdbB4 = new System.Windows.Forms.RadioButton();
                this.rdbB3 = new System.Windows.Forms.RadioButton();
                this.rdbB2 = new System.Windows.Forms.RadioButton();
                this.rdbB1 = new System.Windows.Forms.RadioButton();
                this.cb = new System.Windows.Forms.ComboBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.txtNamaStok = new ISA.Trading.Controls.CommonTextBox();
                this.rdbA3 = new System.Windows.Forms.RadioButton();
                this.groupBox1.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(12, 279);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 2;
                this.cmdYes.Text = "YES";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(470, 279);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 3;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(30, 14);
                this.label1.TabIndex = 7;
                this.label1.Text = "Urut";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(28, 98);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(55, 14);
                this.label2.TabIndex = 8;
                this.label2.Text = "Hitungan";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 128);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(124, 14);
                this.label3.TabIndex = 9;
                this.label3.Text = "Filter Selisih Opname";
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.rdbA3);
                this.groupBox1.Controls.Add(this.rdbA2);
                this.groupBox1.Controls.Add(this.rdbA1);
                this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox1.Location = new System.Drawing.Point(219, 50);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(355, 33);
                this.groupBox1.TabIndex = 10;
                this.groupBox1.TabStop = false;
                // 
                // rdbA2
                // 
                this.rdbA2.AutoSize = true;
                this.rdbA2.Location = new System.Drawing.Point(115, 11);
                this.rdbA2.Name = "rdbA2";
                this.rdbA2.Size = new System.Drawing.Size(111, 18);
                this.rdbA2.TabIndex = 1;
                this.rdbA2.TabStop = true;
                this.rdbA2.Text = "Selisih Opname";
                this.rdbA2.UseVisualStyleBackColor = true;
                // 
                // rdbA1
                // 
                this.rdbA1.AutoSize = true;
                this.rdbA1.Location = new System.Drawing.Point(7, 11);
                this.rdbA1.Name = "rdbA1";
                this.rdbA1.Size = new System.Drawing.Size(96, 18);
                this.rdbA1.TabIndex = 0;
                this.rdbA1.TabStop = true;
                this.rdbA1.Text = "Nama Barang";
                this.rdbA1.UseVisualStyleBackColor = true;
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.rdbC3);
                this.groupBox2.Controls.Add(this.rdbC2);
                this.groupBox2.Controls.Add(this.rdbC1);
                this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox2.Location = new System.Drawing.Point(219, 128);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(355, 33);
                this.groupBox2.TabIndex = 11;
                this.groupBox2.TabStop = false;
                // 
                // rdbC3
                // 
                this.rdbC3.AutoSize = true;
                this.rdbC3.Location = new System.Drawing.Point(202, 9);
                this.rdbC3.Name = "rdbC3";
                this.rdbC3.Size = new System.Drawing.Size(95, 18);
                this.rdbC3.TabIndex = 2;
                this.rdbC3.TabStop = true;
                this.rdbC3.Text = "Tidak Selisih";
                this.rdbC3.UseVisualStyleBackColor = true;
                // 
                // rdbC2
                // 
                this.rdbC2.AutoSize = true;
                this.rdbC2.Location = new System.Drawing.Point(115, 9);
                this.rdbC2.Name = "rdbC2";
                this.rdbC2.Size = new System.Drawing.Size(62, 18);
                this.rdbC2.TabIndex = 1;
                this.rdbC2.TabStop = true;
                this.rdbC2.Text = "Selisih";
                this.rdbC2.UseVisualStyleBackColor = true;
                // 
                // rdbC1
                // 
                this.rdbC1.AutoSize = true;
                this.rdbC1.Location = new System.Drawing.Point(7, 9);
                this.rdbC1.Name = "rdbC1";
                this.rdbC1.Size = new System.Drawing.Size(63, 18);
                this.rdbC1.TabIndex = 0;
                this.rdbC1.TabStop = true;
                this.rdbC1.Text = "Semua";
                this.rdbC1.UseVisualStyleBackColor = true;
                // 
                // groupBox3
                // 
                this.groupBox3.Controls.Add(this.rdbB4);
                this.groupBox3.Controls.Add(this.rdbB3);
                this.groupBox3.Controls.Add(this.rdbB2);
                this.groupBox3.Controls.Add(this.rdbB1);
                this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.groupBox3.Location = new System.Drawing.Point(219, 89);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(355, 33);
                this.groupBox3.TabIndex = 13;
                this.groupBox3.TabStop = false;
                // 
                // rdbB4
                // 
                this.rdbB4.AutoSize = true;
                this.rdbB4.Location = new System.Drawing.Point(284, 9);
                this.rdbB4.Name = "rdbB4";
                this.rdbB4.Size = new System.Drawing.Size(50, 18);
                this.rdbB4.TabIndex = 3;
                this.rdbB4.TabStop = true;
                this.rdbB4.Text = "Final";
                this.rdbB4.UseVisualStyleBackColor = true;
                // 
                // rdbB3
                // 
                this.rdbB3.AutoSize = true;
                this.rdbB3.Location = new System.Drawing.Point(202, 9);
                this.rdbB3.Name = "rdbB3";
                this.rdbB3.Size = new System.Drawing.Size(62, 18);
                this.rdbB3.TabIndex = 2;
                this.rdbB3.TabStop = true;
                this.rdbB3.Text = "KeTiga";
                this.rdbB3.UseVisualStyleBackColor = true;
                // 
                // rdbB2
                // 
                this.rdbB2.AutoSize = true;
                this.rdbB2.Location = new System.Drawing.Point(115, 9);
                this.rdbB2.Name = "rdbB2";
                this.rdbB2.Size = new System.Drawing.Size(59, 18);
                this.rdbB2.TabIndex = 1;
                this.rdbB2.TabStop = true;
                this.rdbB2.Text = "KeDua";
                this.rdbB2.UseVisualStyleBackColor = true;
                // 
                // rdbB1
                // 
                this.rdbB1.AutoSize = true;
                this.rdbB1.Location = new System.Drawing.Point(7, 9);
                this.rdbB1.Name = "rdbB1";
                this.rdbB1.Size = new System.Drawing.Size(71, 18);
                this.rdbB1.TabIndex = 0;
                this.rdbB1.TabStop = true;
                this.rdbB1.Text = "Pertama";
                this.rdbB1.UseVisualStyleBackColor = true;
                // 
                // cb
                // 
                this.cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
                this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cb.FormattingEnabled = true;
                this.cb.Location = new System.Drawing.Point(219, 206);
                this.cb.Name = "cb";
                this.cb.Size = new System.Drawing.Size(121, 22);
                this.cb.TabIndex = 1;
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(28, 186);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(65, 14);
                this.label4.TabIndex = 15;
                this.label4.Text = "Nama Stok";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(28, 214);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(63, 14);
                this.label5.TabIndex = 16;
                this.label5.Text = "Kelompok";
                // 
                // txtNamaStok
                // 
                this.txtNamaStok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtNamaStok.Location = new System.Drawing.Point(219, 180);
                this.txtNamaStok.Name = "txtNamaStok";
                this.txtNamaStok.Size = new System.Drawing.Size(294, 20);
                this.txtNamaStok.TabIndex = 0;
                // 
                // rdbA3
                // 
                this.rdbA3.AutoSize = true;
                this.rdbA3.Location = new System.Drawing.Point(239, 11);
                this.rdbA3.Name = "rdbA3";
                this.rdbA3.Size = new System.Drawing.Size(71, 18);
                this.rdbA3.TabIndex = 2;
                this.rdbA3.TabStop = true;
                this.rdbA3.Text = "Koderak";
                this.rdbA3.UseVisualStyleBackColor = true;
                // 
                // frmRptOpnameAnalisa
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(582, 331);
                this.Controls.Add(this.txtNamaStok);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.cb);
                this.Controls.Add(this.groupBox3);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.groupBox1);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptOpnameAnalisa";
                this.Text = "Laporan Analisa Hasil Stok Opname";
                this.Title = "Laporan Analisa Hasil Stok Opname";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptOpnameAnalisa_Load);
                this.Controls.SetChildIndex(this.groupBox1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.groupBox2, 0);
                this.Controls.SetChildIndex(this.groupBox3, 0);
                this.Controls.SetChildIndex(this.cb, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.Controls.SetChildIndex(this.txtNamaStok, 0);
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

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbA2;
        private System.Windows.Forms.RadioButton rdbA1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbB2;
        private System.Windows.Forms.RadioButton rdbB1;
        private System.Windows.Forms.RadioButton rdbC3;
        private System.Windows.Forms.RadioButton rdbC2;
        private System.Windows.Forms.RadioButton rdbC1;
        private System.Windows.Forms.RadioButton rdbB4;
        private System.Windows.Forms.RadioButton rdbB3;
        private System.Windows.Forms.ComboBox cb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.CommonTextBox txtNamaStok;
        private System.Windows.Forms.RadioButton rdbA3;
        }
    }
