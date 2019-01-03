namespace ISA.Trading.Persediaan
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
                this.TglOpname = new ISA.Trading.Controls.DateTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.txtNoForm = new ISA.Trading.Controls.CommonTextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.txtBaik = new ISA.Trading.Controls.NumericTextBox();
                this.txtCacat = new ISA.Trading.Controls.NumericTextBox();
                this.txtRusak = new ISA.Trading.Controls.NumericTextBox();
                this.txtTotal = new ISA.Trading.Controls.NumericTextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.txtPenghitung = new ISA.Trading.Controls.CommonTextBox();
                this.cmdSave = new ISA.Trading.Controls.CommandButton();
                this.cmdCancel = new ISA.Trading.Controls.CommandButton();
                this.label8 = new System.Windows.Forms.Label();
                this.lookupStock1 = new ISA.Controls.LookupStock();
                this.label9 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // TglOpname
                // 
                this.TglOpname.DateValue = null;
                this.TglOpname.Location = new System.Drawing.Point(119, 163);
                this.TglOpname.MaxLength = 10;
                this.TglOpname.Name = "TglOpname";
                this.TglOpname.Size = new System.Drawing.Size(116, 20);
                this.TglOpname.TabIndex = 1;
                this.TglOpname.TabStop = false;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 165);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(76, 14);
                this.label1.TabIndex = 6;
                this.label1.Text = "Tgl. Opname";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(28, 191);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(56, 14);
                this.label2.TabIndex = 7;
                this.label2.Text = "No. Form";
                // 
                // txtNoForm
                // 
                this.txtNoForm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtNoForm.Location = new System.Drawing.Point(119, 188);
                this.txtNoForm.Name = "txtNoForm";
                this.txtNoForm.Size = new System.Drawing.Size(116, 20);
                this.txtNoForm.TabIndex = 2;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(28, 216);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(30, 14);
                this.label3.TabIndex = 9;
                this.label3.Text = "Baik";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(28, 242);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(37, 14);
                this.label4.TabIndex = 10;
                this.label4.Text = "Cacat";
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(28, 265);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(41, 14);
                this.label5.TabIndex = 11;
                this.label5.Text = "Rusak";
                // 
                // txtBaik
                // 
                this.txtBaik.Location = new System.Drawing.Point(119, 213);
                this.txtBaik.Name = "txtBaik";
                this.txtBaik.Size = new System.Drawing.Size(74, 20);
                this.txtBaik.TabIndex = 3;
                this.txtBaik.Text = "0";
                this.txtBaik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtBaik.Leave += new System.EventHandler(this.txtBaik_Leave);
                // 
                // txtCacat
                // 
                this.txtCacat.Location = new System.Drawing.Point(119, 238);
                this.txtCacat.Name = "txtCacat";
                this.txtCacat.Size = new System.Drawing.Size(74, 20);
                this.txtCacat.TabIndex = 4;
                this.txtCacat.Text = "0";
                this.txtCacat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtCacat.Leave += new System.EventHandler(this.txtCacat_Leave);
                // 
                // txtRusak
                // 
                this.txtRusak.Location = new System.Drawing.Point(119, 263);
                this.txtRusak.Name = "txtRusak";
                this.txtRusak.Size = new System.Drawing.Size(74, 20);
                this.txtRusak.TabIndex = 5;
                this.txtRusak.Text = "0";
                this.txtRusak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.txtRusak.Leave += new System.EventHandler(this.txtRusak_Leave);
                // 
                // txtTotal
                // 
                this.txtTotal.Location = new System.Drawing.Point(119, 288);
                this.txtTotal.Name = "txtTotal";
                this.txtTotal.ReadOnly = true;
                this.txtTotal.Size = new System.Drawing.Size(74, 20);
                this.txtTotal.TabIndex = 6;
                this.txtTotal.TabStop = false;
                this.txtTotal.Text = "0";
                this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(28, 292);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(33, 14);
                this.label6.TabIndex = 16;
                this.label6.Text = "Total";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(28, 315);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(70, 14);
                this.label7.TabIndex = 17;
                this.label7.Text = "Penghitung";
                // 
                // txtPenghitung
                // 
                this.txtPenghitung.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtPenghitung.Location = new System.Drawing.Point(119, 313);
                this.txtPenghitung.Name = "txtPenghitung";
                this.txtPenghitung.Size = new System.Drawing.Size(206, 20);
                this.txtPenghitung.TabIndex = 7;
                this.txtPenghitung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPenghitung_KeyPress);
                // 
                // cmdSave
                // 
                this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
                this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
                this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdSave.Location = new System.Drawing.Point(31, 418);
                this.cmdSave.Name = "cmdSave";
                this.cmdSave.Size = new System.Drawing.Size(100, 40);
                this.cmdSave.TabIndex = 8;
                this.cmdSave.Text = "SAVE";
                this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdSave.UseVisualStyleBackColor = true;
                this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
                // 
                // cmdCancel
                // 
                this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdCancel.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
                this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdCancel.Location = new System.Drawing.Point(344, 418);
                this.cmdCancel.Name = "cmdCancel";
                this.cmdCancel.Size = new System.Drawing.Size(100, 40);
                this.cmdCancel.TabIndex = 9;
                this.cmdCancel.Text = "CANCEL";
                this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdCancel.UseVisualStyleBackColor = true;
                this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Location = new System.Drawing.Point(26, 63);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(39, 14);
                this.label8.TabIndex = 18;
                this.label8.Text = "label8";
                // 
                // lookupStock1
                // 
                this.lookupStock1.BarangID = "[CODE]";
                this.lookupStock1.Font = new System.Drawing.Font("Courier New", 8.25F);
                this.lookupStock1.IsiKoli = 0;
                this.lookupStock1.Location = new System.Drawing.Point(117, 95);
                this.lookupStock1.LookUpType = ISA.Controls.LookupStock.EnumLookUpType.Normal;
                this.lookupStock1.NamaStock = "";
                this.lookupStock1.Name = "lookupStock1";
                this.lookupStock1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
                this.lookupStock1.Satuan = null;
                this.lookupStock1.Size = new System.Drawing.Size(329, 54);
                this.lookupStock1.TabIndex = 0;
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Location = new System.Drawing.Point(28, 100);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(65, 14);
                this.label9.TabIndex = 20;
                this.label9.Text = "Nama Stok";
                // 
                // frmStokOpnameDetailUpdate
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(502, 474);
                this.Controls.Add(this.label9);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.lookupStock1);
                this.Controls.Add(this.label8);
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
                this.Controls.SetChildIndex(this.label8, 0);
                this.Controls.SetChildIndex(this.lookupStock1, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label7, 0);
                this.Controls.SetChildIndex(this.label9, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Trading.Controls.DateTextBox TglOpname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommonTextBox txtNoForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.NumericTextBox txtBaik;
        private ISA.Trading.Controls.NumericTextBox txtCacat;
        private ISA.Trading.Controls.NumericTextBox txtRusak;
        private ISA.Trading.Controls.NumericTextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ISA.Trading.Controls.CommonTextBox txtPenghitung;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.Label label8;
        private ISA.Controls.LookupStock lookupStock1;
        private System.Windows.Forms.Label label9;
        }
    }
