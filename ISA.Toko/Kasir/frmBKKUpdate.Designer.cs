namespace ISA.Toko.Kasir
{
    partial class frmBKKUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBKKUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBKKUpdate = new System.Windows.Forms.GroupBox();
            this.lookupStafAdm1 = new ISA.Toko.Controls.LookupStafAdm();
            this.gbUpdateDetailBKK = new System.Windows.Forms.GroupBox();
            this.tbUraian = new ISA.Controls.CommonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAcc = new ISA.Controls.CommonTextBox();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.tbJumlah = new ISA.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTotal = new ISA.Controls.NumericTextBox();
            this.tbTerbilang = new System.Windows.Forms.TextBox();
            this.dgDetailBKK = new ISA.Controls.CustomGridView();
            this.tbTanggal = new ISA.Controls.DateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNoBKK = new ISA.Controls.CommonTextBox();
            this.tbLampiran = new ISA.Controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdExit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBKKUpdate.SuspendLayout();
            this.gbUpdateDetailBKK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKK)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBKKUpdate
            // 
            this.gbBKKUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbBKKUpdate.Controls.Add(this.lookupStafAdm1);
            this.gbBKKUpdate.Controls.Add(this.gbUpdateDetailBKK);
            this.gbBKKUpdate.Controls.Add(this.label7);
            this.gbBKKUpdate.Controls.Add(this.tbTotal);
            this.gbBKKUpdate.Controls.Add(this.tbTerbilang);
            this.gbBKKUpdate.Controls.Add(this.dgDetailBKK);
            this.gbBKKUpdate.Controls.Add(this.tbTanggal);
            this.gbBKKUpdate.Controls.Add(this.label1);
            this.gbBKKUpdate.Controls.Add(this.label2);
            this.gbBKKUpdate.Controls.Add(this.label4);
            this.gbBKKUpdate.Controls.Add(this.label3);
            this.gbBKKUpdate.Controls.Add(this.tbNoBKK);
            this.gbBKKUpdate.Location = new System.Drawing.Point(26, 69);
            this.gbBKKUpdate.Name = "gbBKKUpdate";
            this.gbBKKUpdate.Size = new System.Drawing.Size(705, 417);
            this.gbBKKUpdate.TabIndex = 0;
            this.gbBKKUpdate.TabStop = false;
            // 
            // lookupStafAdm1
            // 
            this.lookupStafAdm1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lookupStafAdm1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStafAdm1.Kode = "[CODE]";
            this.lookupStafAdm1.Location = new System.Drawing.Point(82, 41);
            this.lookupStafAdm1.Nama = "";
            this.lookupStafAdm1.Name = "lookupStafAdm1";
            this.lookupStafAdm1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStafAdm1.Size = new System.Drawing.Size(281, 54);
            this.lookupStafAdm1.TabIndex = 0;
            this.lookupStafAdm1.SelectData += new System.EventHandler(this.tbKepada_Leave);
            // 
            // gbUpdateDetailBKK
            // 
            this.gbUpdateDetailBKK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbUpdateDetailBKK.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbUpdateDetailBKK.Controls.Add(this.tbUraian);
            this.gbUpdateDetailBKK.Controls.Add(this.label11);
            this.gbUpdateDetailBKK.Controls.Add(this.tbAcc);
            this.gbUpdateDetailBKK.Controls.Add(this.cmdCancel);
            this.gbUpdateDetailBKK.Controls.Add(this.cmdSave);
            this.gbUpdateDetailBKK.Controls.Add(this.tbJumlah);
            this.gbUpdateDetailBKK.Controls.Add(this.label10);
            this.gbUpdateDetailBKK.Controls.Add(this.label9);
            this.gbUpdateDetailBKK.Location = new System.Drawing.Point(135, 133);
            this.gbUpdateDetailBKK.Name = "gbUpdateDetailBKK";
            this.gbUpdateDetailBKK.Size = new System.Drawing.Size(406, 207);
            this.gbUpdateDetailBKK.TabIndex = 3;
            this.gbUpdateDetailBKK.TabStop = false;
            this.gbUpdateDetailBKK.Text = "Detail BKK";
            this.gbUpdateDetailBKK.Visible = false;
            // 
            // tbUraian
            // 
            this.tbUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUraian.Location = new System.Drawing.Point(89, 33);
            this.tbUraian.Name = "tbUraian";
            this.tbUraian.Size = new System.Drawing.Size(276, 20);
            this.tbUraian.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "ACC";
            // 
            // tbAcc
            // 
            this.tbAcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAcc.Location = new System.Drawing.Point(89, 69);
            this.tbAcc.Name = "tbAcc";
            this.tbAcc.Size = new System.Drawing.Size(100, 20);
            this.tbAcc.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(229, 146);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 40);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "CLOSE";
            this.cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(67, 146);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // tbJumlah
            // 
            this.tbJumlah.Location = new System.Drawing.Point(89, 105);
            this.tbJumlah.Name = "tbJumlah";
            this.tbJumlah.Size = new System.Drawing.Size(139, 20);
            this.tbJumlah.TabIndex = 2;
            this.tbJumlah.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Jumlah";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Uraian";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 22);
            this.label7.TabIndex = 44;
            this.label7.Text = "TERBILANG";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(547, 385);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(141, 26);
            this.tbTotal.TabIndex = 6;
            this.tbTotal.Text = "0";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTerbilang
            // 
            this.tbTerbilang.BackColor = System.Drawing.SystemColors.Window;
            this.tbTerbilang.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTerbilang.Location = new System.Drawing.Point(129, 386);
            this.tbTerbilang.Name = "tbTerbilang";
            this.tbTerbilang.ReadOnly = true;
            this.tbTerbilang.Size = new System.Drawing.Size(412, 25);
            this.tbTerbilang.TabIndex = 5;
            // 
            // dgDetailBKK
            // 
            this.dgDetailBKK.AllowUserToAddRows = false;
            this.dgDetailBKK.AllowUserToDeleteRows = false;
            this.dgDetailBKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetailBKK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetailBKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetailBKK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPerkiraan,
            this.rowID,
            this.Uraian,
            this.Jumlah});
            this.dgDetailBKK.Location = new System.Drawing.Point(17, 102);
            this.dgDetailBKK.MultiSelect = false;
            this.dgDetailBKK.Name = "dgDetailBKK";
            this.dgDetailBKK.ReadOnly = true;
            this.dgDetailBKK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDetailBKK.Size = new System.Drawing.Size(671, 278);
            this.dgDetailBKK.StandardTab = true;
            this.dgDetailBKK.TabIndex = 4;
            this.dgDetailBKK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDetailBKK_KeyDown);
            // 
            // tbTanggal
            // 
            this.tbTanggal.DateValue = null;
            this.tbTanggal.Enabled = false;
            this.tbTanggal.Location = new System.Drawing.Point(547, 48);
            this.tbTanggal.MaxLength = 10;
            this.tbTanggal.Name = "tbTanggal";
            this.tbTanggal.Size = new System.Drawing.Size(141, 20);
            this.tbTanggal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "BUKTI KAS KELUAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "NO. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "TANGGAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Kepada";
            // 
            // tbNoBKK
            // 
            this.tbNoBKK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoBKK.Enabled = false;
            this.tbNoBKK.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoBKK.Location = new System.Drawing.Point(416, 13);
            this.tbNoBKK.Name = "tbNoBKK";
            this.tbNoBKK.Size = new System.Drawing.Size(272, 29);
            this.tbNoBKK.TabIndex = 1;
            // 
            // tbLampiran
            // 
            this.tbLampiran.Enabled = false;
            this.tbLampiran.Location = new System.Drawing.Point(576, 28);
            this.tbLampiran.Name = "tbLampiran";
            this.tbLampiran.Size = new System.Drawing.Size(67, 20);
            this.tbLampiran.TabIndex = 3;
            this.tbLampiran.Text = "0";
            this.tbLampiran.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "LEMBAR";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "LAMPIRAN";
            this.label5.Visible = false;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdExit.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(607, 493);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(100, 40);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "CLOSE";
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(430, 493);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(143, 493);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(324, 492);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(37, 493);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 1;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Visible = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NO. PERK";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
            this.NoPerkiraan.Visible = false;
            this.NoPerkiraan.Width = 150;
            // 
            // rowID
            // 
            this.rowID.DataPropertyName = "rowID";
            this.rowID.HeaderText = "rowID";
            this.rowID.Name = "rowID";
            this.rowID.ReadOnly = true;
            this.rowID.Visible = false;
            // 
            // Uraian
            // 
            this.Uraian.DataPropertyName = "Uraian";
            this.Uraian.HeaderText = "URAIAN";
            this.Uraian.Name = "Uraian";
            this.Uraian.ReadOnly = true;
            this.Uraian.Width = 350;
            // 
            // Jumlah
            // 
            this.Jumlah.DataPropertyName = "Jumlah";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle1;
            this.Jumlah.HeaderText = "JUMLAH";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Width = 120;
            // 
            // frmBKKUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(745, 545);
            this.Controls.Add(this.gbBKKUpdate);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.tbLampiran);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBKKUpdate";
            this.Text = "Bukti Kas Keluar";
            this.Title = "Bukti Kas Keluar";
            this.Load += new System.EventHandler(this.frmBKKUpdate_Load);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbLampiran, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.cmdPrint, 0);
            this.Controls.SetChildIndex(this.cmdExit, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.gbBKKUpdate, 0);
            this.gbBKKUpdate.ResumeLayout(false);
            this.gbBKKUpdate.PerformLayout();
            this.gbUpdateDetailBKK.ResumeLayout(false);
            this.gbUpdateDetailBKK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBKKUpdate;
        private ISA.Controls.CommandButton cmdExit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.NumericTextBox tbLampiran;
        private ISA.Controls.DateTextBox tbTanggal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox tbNoBKK;
        private ISA.Controls.NumericTextBox tbJumlah;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ISA.Controls.CommandButton cmdCancel;
        private System.Windows.Forms.GroupBox gbUpdateDetailBKK;
        private ISA.Controls.CustomGridView dgDetailBKK;
        private System.Windows.Forms.TextBox tbTerbilang;
        private ISA.Controls.NumericTextBox tbTotal;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox tbAcc;
        private System.Windows.Forms.Label label11;
        private ISA.Controls.CommonTextBox tbUraian;
        private ISA.Toko.Controls.LookupStafAdm lookupStafAdm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
    }
}
