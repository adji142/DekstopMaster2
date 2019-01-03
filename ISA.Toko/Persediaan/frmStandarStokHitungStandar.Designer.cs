namespace ISA.Toko.Persediaan
    {
    partial class frmStandarStokHitungStandar
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStandarStokHitungStandar));
                this.cmdYes = new ISA.Toko.Controls.CommandButton();
                this.cmdNo = new ISA.Toko.Controls.CommandButton();
                this.txtTgl = new ISA.Toko.Controls.DateTextBox();
                this.txtMin = new ISA.Toko.Controls.NumericTextBox();
                this.txtMax = new ISA.Toko.Controls.NumericTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.txtLamaKirim = new ISA.Toko.Controls.NumericTextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.txtHariRata2 = new ISA.Toko.Controls.NumericTextBox();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(12, 269);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 3;
                this.cmdYes.Text = "SAVE";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(193, 269);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 4;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // txtTgl
                // 
                this.txtTgl.DateValue = null;
                this.txtTgl.Location = new System.Drawing.Point(136, 69);
                this.txtTgl.MaxLength = 10;
                this.txtTgl.Name = "txtTgl";
                this.txtTgl.Size = new System.Drawing.Size(81, 20);
                this.txtTgl.TabIndex = 0;
                // 
                // txtMin
                // 
                this.txtMin.Format = "#,##0.0";
                this.txtMin.Location = new System.Drawing.Point(136, 109);
                this.txtMin.Name = "txtMin";
                this.txtMin.Size = new System.Drawing.Size(35, 20);
                this.txtMin.TabIndex = 1;
                this.txtMin.Text = "0.0";
                this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtMax
                // 
                this.txtMax.Format = "#,##0.0";
                this.txtMax.Location = new System.Drawing.Point(223, 112);
                this.txtMax.Name = "txtMax";
                this.txtMax.Size = new System.Drawing.Size(35, 20);
                this.txtMax.TabIndex = 2;
                this.txtMax.Text = "0.0";
                this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMax_KeyPress);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(56, 14);
                this.label1.TabIndex = 10;
                this.label1.Text = "Tanggal";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(177, 115);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(28, 14);
                this.label2.TabIndex = 11;
                this.label2.Text = "Min";
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 112);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(63, 14);
                this.label3.TabIndex = 12;
                this.label3.Text = "Variable";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(264, 115);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(28, 14);
                this.label4.TabIndex = 13;
                this.label4.Text = "Max";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(28, 157);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(77, 14);
                this.label5.TabIndex = 15;
                this.label5.Text = "Lama Kirim";
                // 
                // txtLamaKirim
                // 
                this.txtLamaKirim.Format = "#,##0.0";
                this.txtLamaKirim.Location = new System.Drawing.Point(136, 154);
                this.txtLamaKirim.Name = "txtLamaKirim";
                this.txtLamaKirim.Size = new System.Drawing.Size(35, 20);
                this.txtLamaKirim.TabIndex = 14;
                this.txtLamaKirim.Text = "0.0";
                this.txtLamaKirim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(28, 201);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(105, 14);
                this.label6.TabIndex = 17;
                this.label6.Text = "Hari Rata-Rata";
                // 
                // txtHariRata2
                // 
                this.txtHariRata2.Format = "#,##0.0";
                this.txtHariRata2.Location = new System.Drawing.Point(136, 201);
                this.txtHariRata2.Name = "txtHariRata2";
                this.txtHariRata2.Size = new System.Drawing.Size(35, 20);
                this.txtHariRata2.TabIndex = 16;
                this.txtHariRata2.Text = "0.0";
                this.txtHariRata2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // frmStandarStokHitungStandar
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(305, 321);
                this.Controls.Add(this.label6);
                this.Controls.Add(this.txtHariRata2);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.txtLamaKirim);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.txtMin);
                this.Controls.Add(this.txtTgl);
                this.Controls.Add(this.txtMax);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.cmdNo);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmStandarStokHitungStandar";
                this.Text = "";
                this.Title = "";
                this.Load += new System.EventHandler(this.frmStandarStokHitungStandar_Load);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.txtMax, 0);
                this.Controls.SetChildIndex(this.txtTgl, 0);
                this.Controls.SetChildIndex(this.txtMin, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.txtLamaKirim, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.Controls.SetChildIndex(this.txtHariRata2, 0);
                this.Controls.SetChildIndex(this.label6, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.DateTextBox txtTgl;
        private ISA.Toko.Controls.NumericTextBox txtMin;
        private ISA.Toko.Controls.NumericTextBox txtMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.NumericTextBox txtLamaKirim;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.NumericTextBox txtHariRata2;
        }
    }
