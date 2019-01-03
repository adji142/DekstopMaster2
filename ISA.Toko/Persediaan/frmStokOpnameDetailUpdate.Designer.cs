namespace ISA.Toko.Persediaan
    {
    partial class frmStokOpnameDetailUpdate
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokOpnameDetailUpdate));
                this.TglOpname = new ISA.Toko.Controls.DateTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.txtNoForm = new ISA.Toko.Controls.CommonTextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.txtBaik = new ISA.Toko.Controls.NumericTextBox();
                this.txtCacat = new ISA.Toko.Controls.NumericTextBox();
                this.txtRusak = new ISA.Toko.Controls.NumericTextBox();
                this.txtTotal = new ISA.Toko.Controls.NumericTextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.txtPenghitung = new ISA.Toko.Controls.CommonTextBox();
                this.cmdSave = new ISA.Toko.Controls.CommandButton();
                this.cmdCancel = new ISA.Toko.Controls.CommandButton();
                this.label8 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // TglOpname
                // 
                this.TglOpname.DateValue = null;
                this.TglOpname.Location = new System.Drawing.Point(118, 87);
                this.TglOpname.MaxLength = 10;
                this.TglOpname.Name = "TglOpname";
                this.TglOpname.Size = new System.Drawing.Size(121, 20);
                this.TglOpname.TabIndex = 0;
                this.TglOpname.TabStop = false;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(27, 90);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(76, 14);
                this.label1.TabIndex = 6;
                this.label1.Text = "Tgl. Opname";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(27, 134);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(56, 14);
                this.label2.TabIndex = 7;
                this.label2.Text = "No. Form";
                // 
                // txtNoForm
                // 
                this.txtNoForm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtNoForm.Location = new System.Drawing.Point(118, 127);
                this.txtNoForm.Name = "txtNoForm";
                this.txtNoForm.ReadOnly = true;
                this.txtNoForm.Size = new System.Drawing.Size(116, 20);
                this.txtNoForm.TabIndex = 1;
                this.txtNoForm.TabStop = false;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(27, 178);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(30, 14);
                this.label3.TabIndex = 9;
                this.label3.Text = "Baik";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(27, 222);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(37, 14);
                this.label4.TabIndex = 10;
                this.label4.Text = "Cacat";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(27, 267);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(41, 14);
                this.label5.TabIndex = 11;
                this.label5.Text = "Rusak";
                // 
                // txtBaik
                // 
                this.txtBaik.Location = new System.Drawing.Point(118, 171);
                this.txtBaik.Name = "txtBaik";
                this.txtBaik.Size = new System.Drawing.Size(74, 20);
                this.txtBaik.TabIndex = 0;
                this.txtBaik.Text = "0";
                this.txtBaik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtBaik.Leave += new System.EventHandler(this.txtBaik_Leave);
                // 
                // txtCacat
                // 
                this.txtCacat.Location = new System.Drawing.Point(118, 215);
                this.txtCacat.Name = "txtCacat";
                this.txtCacat.Size = new System.Drawing.Size(74, 20);
                this.txtCacat.TabIndex = 1;
                this.txtCacat.Text = "0";
                this.txtCacat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtCacat.Leave += new System.EventHandler(this.txtCacat_Leave);
                // 
                // txtRusak
                // 
                this.txtRusak.Location = new System.Drawing.Point(118, 259);
                this.txtRusak.Name = "txtRusak";
                this.txtRusak.Size = new System.Drawing.Size(74, 20);
                this.txtRusak.TabIndex = 2;
                this.txtRusak.Text = "0";
                this.txtRusak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtRusak.Leave += new System.EventHandler(this.txtRusak_Leave);
                // 
                // txtTotal
                // 
                this.txtTotal.Location = new System.Drawing.Point(118, 303);
                this.txtTotal.Name = "txtTotal";
                this.txtTotal.ReadOnly = true;
                this.txtTotal.Size = new System.Drawing.Size(74, 20);
                this.txtTotal.TabIndex = 3;
                this.txtTotal.TabStop = false;
                this.txtTotal.Text = "0";
                this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(27, 311);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(34, 14);
                this.label6.TabIndex = 16;
                this.label6.Text = "Total";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(27, 355);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(70, 14);
                this.label7.TabIndex = 17;
                this.label7.Text = "Penghitung";
                // 
                // txtPenghitung
                // 
                this.txtPenghitung.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPenghitung.Location = new System.Drawing.Point(118, 347);
                this.txtPenghitung.Name = "txtPenghitung";
                this.txtPenghitung.Size = new System.Drawing.Size(206, 20);
                this.txtPenghitung.TabIndex = 3;
                this.txtPenghitung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPenghitung_KeyPress);
                // 
                // cmdSave
                // 
                this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
                this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
                this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdSave.Location = new System.Drawing.Point(31, 418);
                this.cmdSave.Name = "cmdSave";
                this.cmdSave.Size = new System.Drawing.Size(100, 40);
                this.cmdSave.TabIndex = 4;
                this.cmdSave.Text = "SAVE";
                this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdSave.UseVisualStyleBackColor = true;
                this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
                // 
                // cmdCancel
                // 
                this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdCancel.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
                this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdCancel.Location = new System.Drawing.Point(209, 418);
                this.cmdCancel.Name = "cmdCancel";
                this.cmdCancel.Size = new System.Drawing.Size(100, 40);
                this.cmdCancel.TabIndex = 5;
                this.cmdCancel.Text = "CANCEL";
                this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdCancel.UseVisualStyleBackColor = true;
                this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Location = new System.Drawing.Point(29, 64);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(39, 14);
                this.label8.TabIndex = 18;
                this.label8.Text = "label8";
                // 
                // frmStokOpnameDetailUpdate
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(341, 474);
                this.Controls.Add(this.label8);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.cmdSave);
                this.Controls.Add(this.cmdCancel);
                this.Controls.Add(this.txtPenghitung);
                this.Controls.Add(this.label6);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.txtBaik);
                this.Controls.Add(this.txtTotal);
                this.Controls.Add(this.txtRusak);
                this.Controls.Add(this.TglOpname);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.txtCacat);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.txtNoForm);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmStokOpnameDetailUpdate";
                this.Text = "Hitung";
                this.Title = "Hitung";
                this.Load += new System.EventHandler(this.StokOpnameDetailUpdate_Load);
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StokOpnameDetailUpdate_FormClosed);
                this.Controls.SetChildIndex(this.txtNoForm, 0);
                this.Controls.SetChildIndex(this.label3, 0);
                this.Controls.SetChildIndex(this.txtCacat, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.TglOpname, 0);
                this.Controls.SetChildIndex(this.txtRusak, 0);
                this.Controls.SetChildIndex(this.txtTotal, 0);
                this.Controls.SetChildIndex(this.txtBaik, 0);
                this.Controls.SetChildIndex(this.label4, 0);
                this.Controls.SetChildIndex(this.label5, 0);
                this.Controls.SetChildIndex(this.label6, 0);
                this.Controls.SetChildIndex(this.txtPenghitung, 0);
                this.Controls.SetChildIndex(this.cmdCancel, 0);
                this.Controls.SetChildIndex(this.cmdSave, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label7, 0);
                this.Controls.SetChildIndex(this.label8, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.DateTextBox TglOpname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtNoForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.NumericTextBox txtBaik;
        private ISA.Toko.Controls.NumericTextBox txtCacat;
        private ISA.Toko.Controls.NumericTextBox txtRusak;
        private ISA.Toko.Controls.NumericTextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Toko.Controls.CommonTextBox txtPenghitung;
        private ISA.Toko.Controls.CommandButton cmdSave;
        private ISA.Toko.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.Label label8;
        }
    }
