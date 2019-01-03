namespace ISA.Finance.Kasir
{
    partial class frmBKMUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBKMUpdate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBKMUpdate = new System.Windows.Forms.GroupBox();
            this.tbTerbilang = new System.Windows.Forms.TextBox();
            this.cmdExit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.cmdPrint = new ISA.Controls.CommandButton();
            this.tbTotal = new ISA.Controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTerima = new ISA.Controls.CommonTextBox();
            this.tbLampiran = new ISA.Controls.NumericTextBox();
            this.tbTanggal = new ISA.Controls.DateTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgDetailBKM = new ISA.Controls.CustomGridView();
            this.NoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uraian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNoBKM = new ISA.Controls.CommonTextBox();
            this.gbUpdateDetailBKM = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.tbUraian = new ISA.Finance.Controls.LookupPerkiraanKoneksi();
            this.cmdCancel = new ISA.Controls.CommandButton();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.tbJumlah = new ISA.Controls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbBKMUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKM)).BeginInit();
            this.gbUpdateDetailBKM.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBKMUpdate
            // 
            this.gbBKMUpdate.Controls.Add(this.tbTerbilang);
            this.gbBKMUpdate.Controls.Add(this.cmdExit);
            this.gbBKMUpdate.Controls.Add(this.cmdDelete);
            this.gbBKMUpdate.Controls.Add(this.cmdEdit);
            this.gbBKMUpdate.Controls.Add(this.cmdAdd);
            this.gbBKMUpdate.Controls.Add(this.cmdPrint);
            this.gbBKMUpdate.Controls.Add(this.tbTotal);
            this.gbBKMUpdate.Controls.Add(this.label7);
            this.gbBKMUpdate.Controls.Add(this.tbTerima);
            this.gbBKMUpdate.Controls.Add(this.tbLampiran);
            this.gbBKMUpdate.Controls.Add(this.tbTanggal);
            this.gbBKMUpdate.Controls.Add(this.label6);
            this.gbBKMUpdate.Controls.Add(this.dgDetailBKM);
            this.gbBKMUpdate.Controls.Add(this.label1);
            this.gbBKMUpdate.Controls.Add(this.label2);
            this.gbBKMUpdate.Controls.Add(this.label5);
            this.gbBKMUpdate.Controls.Add(this.label4);
            this.gbBKMUpdate.Controls.Add(this.label3);
            this.gbBKMUpdate.Controls.Add(this.tbNoBKM);
            this.gbBKMUpdate.Location = new System.Drawing.Point(23, 18);
            this.gbBKMUpdate.Name = "gbBKMUpdate";
            this.gbBKMUpdate.Size = new System.Drawing.Size(705, 463);
            this.gbBKMUpdate.TabIndex = 3;
            this.gbBKMUpdate.TabStop = false;
            // 
            // tbTerbilang
            // 
            this.tbTerbilang.BackColor = System.Drawing.SystemColors.Window;
            this.tbTerbilang.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTerbilang.Location = new System.Drawing.Point(122, 342);
            this.tbTerbilang.Name = "tbTerbilang";
            this.tbTerbilang.ReadOnly = true;
            this.tbTerbilang.Size = new System.Drawing.Size(412, 25);
            this.tbTerbilang.TabIndex = 41;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(581, 402);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(100, 40);
            this.cmdExit.TabIndex = 40;
            this.cmdExit.Text = "CLOSE";
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(404, 402);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 39;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(298, 402);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 38;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(192, 402);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 37;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.Location = new System.Drawing.Point(11, 402);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 40);
            this.cmdPrint.TabIndex = 36;
            this.cmdPrint.Text = "PRINT";
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(540, 342);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(141, 26);
            this.tbTotal.TabIndex = 35;
            this.tbTotal.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 22);
            this.label7.TabIndex = 33;
            this.label7.Text = "TERBILANG";
            // 
            // tbTerima
            // 
            this.tbTerima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTerima.Location = new System.Drawing.Point(105, 69);
            this.tbTerima.Name = "tbTerima";
            this.tbTerima.Size = new System.Drawing.Size(293, 20);
            this.tbTerima.TabIndex = 31;
            this.tbTerima.Leave += new System.EventHandler(this.tbTerima_Leave);
            // 
            // tbLampiran
            // 
            this.tbLampiran.Enabled = false;
            this.tbLampiran.Location = new System.Drawing.Point(540, 84);
            this.tbLampiran.Name = "tbLampiran";
            this.tbLampiran.Size = new System.Drawing.Size(67, 20);
            this.tbLampiran.TabIndex = 29;
            this.tbLampiran.Text = "0";
            // 
            // tbTanggal
            // 
            this.tbTanggal.DateValue = null;
            this.tbTanggal.Enabled = false;
            this.tbTanggal.Location = new System.Drawing.Point(540, 55);
            this.tbTanggal.MaxLength = 10;
            this.tbTanggal.Name = "tbTanggal";
            this.tbTanggal.Size = new System.Drawing.Size(141, 20);
            this.tbTanggal.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "LEMBAR";
            // 
            // dgDetailBKM
            // 
            this.dgDetailBKM.AllowUserToAddRows = false;
            this.dgDetailBKM.AllowUserToDeleteRows = false;
            this.dgDetailBKM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDetailBKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDetailBKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetailBKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPerkiraan,
            this.rowID,
            this.Uraian,
            this.Jumlah});
            this.dgDetailBKM.Location = new System.Drawing.Point(10, 125);
            this.dgDetailBKM.MultiSelect = false;
            this.dgDetailBKM.Name = "dgDetailBKM";
            this.dgDetailBKM.ReadOnly = true;
            this.dgDetailBKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDetailBKM.Size = new System.Drawing.Size(671, 200);
            this.dgDetailBKM.StandardTab = true;
            this.dgDetailBKM.TabIndex = 32;
            this.dgDetailBKM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDetailBKM_KeyDown);
            // 
            // NoPerkiraan
            // 
            this.NoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.NoPerkiraan.HeaderText = "NO. PERK";
            this.NoPerkiraan.Name = "NoPerkiraan";
            this.NoPerkiraan.ReadOnly = true;
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
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Jumlah.DefaultCellStyle = dataGridViewCellStyle1;
            this.Jumlah.HeaderText = "JUMLAH";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "BUKTI KAS MASUK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "NO. ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "LAMPIRAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "TANGGAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "TERIMA DARI";
            // 
            // tbNoBKM
            // 
            this.tbNoBKM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNoBKM.Enabled = false;
            this.tbNoBKM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoBKM.Location = new System.Drawing.Point(540, 13);
            this.tbNoBKM.Name = "tbNoBKM";
            this.tbNoBKM.Size = new System.Drawing.Size(141, 26);
            this.tbNoBKM.TabIndex = 27;
            // 
            // gbUpdateDetailBKM
            // 
            this.gbUpdateDetailBKM.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gbUpdateDetailBKM.Controls.Add(this.label12);
            this.gbUpdateDetailBKM.Controls.Add(this.txtUraian);
            this.gbUpdateDetailBKM.Controls.Add(this.tbUraian);
            this.gbUpdateDetailBKM.Controls.Add(this.cmdCancel);
            this.gbUpdateDetailBKM.Controls.Add(this.cmdSave);
            this.gbUpdateDetailBKM.Controls.Add(this.tbJumlah);
            this.gbUpdateDetailBKM.Controls.Add(this.label10);
            this.gbUpdateDetailBKM.Controls.Add(this.label9);
            this.gbUpdateDetailBKM.Controls.Add(this.label8);
            this.gbUpdateDetailBKM.Location = new System.Drawing.Point(168, 9);
            this.gbUpdateDetailBKM.Name = "gbUpdateDetailBKM";
            this.gbUpdateDetailBKM.Size = new System.Drawing.Size(418, 234);
            this.gbUpdateDetailBKM.TabIndex = 41;
            this.gbUpdateDetailBKM.TabStop = false;
            this.gbUpdateDetailBKM.Text = "Detail BKM";
            this.gbUpdateDetailBKM.Visible = false;
            this.gbUpdateDetailBKM.Enter += new System.EventHandler(this.gbUpdateDetailBKM_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 14);
            this.label12.TabIndex = 15;
            this.label12.Text = "Uraian";
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(91, 88);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(289, 20);
            this.txtUraian.TabIndex = 1;
            // 
            // tbUraian
            // 
            this.tbUraian.Kode = "BKM";
            this.tbUraian.Location = new System.Drawing.Point(92, 33);
            this.tbUraian.Margin = new System.Windows.Forms.Padding(0);
            this.tbUraian.NamaPerkiraan = "";
            this.tbUraian.Name = "tbUraian";
            this.tbUraian.NoPerkiraan = "?";
            this.tbUraian.Size = new System.Drawing.Size(267, 43);
            this.tbUraian.TabIndex = 0;
            this.tbUraian.TipeForm = ISA.Finance.Controls.LookupPerkiraanKoneksi.enTipeForm.form1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(230, 165);
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
            this.cmdSave.Location = new System.Drawing.Point(92, 165);
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
            this.tbJumlah.Location = new System.Drawing.Point(91, 113);
            this.tbJumlah.Name = "tbJumlah";
            this.tbJumlah.Size = new System.Drawing.Size(139, 20);
            this.tbJumlah.TabIndex = 2;
            this.tbJumlah.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Jumlah";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Nama Perk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "No. Perk";
            // 
            // frmBKMUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(745, 533);
            this.Controls.Add(this.gbUpdateDetailBKM);
            this.Controls.Add(this.gbBKMUpdate);
            this.Name = "frmBKMUpdate";
            this.Text = "BUKTI KAS MASUK";
            this.Load += new System.EventHandler(this.frmBKMUpdate_Load);
            this.Controls.SetChildIndex(this.gbBKMUpdate, 0);
            this.Controls.SetChildIndex(this.gbUpdateDetailBKM, 0);
            this.gbBKMUpdate.ResumeLayout(false);
            this.gbBKMUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetailBKM)).EndInit();
            this.gbUpdateDetailBKM.ResumeLayout(false);
            this.gbUpdateDetailBKM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBKMUpdate;
        private ISA.Controls.CommandButton cmdExit;
        private ISA.Controls.CommandButton cmdDelete;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdAdd;
        private ISA.Controls.CommandButton cmdPrint;
        private ISA.Controls.NumericTextBox tbTotal;
        private System.Windows.Forms.Label label7;
        private ISA.Controls.CommonTextBox tbTerima;
        private ISA.Controls.NumericTextBox tbLampiran;
        private ISA.Controls.DateTextBox tbTanggal;
        private System.Windows.Forms.Label label6;
        private ISA.Controls.CustomGridView dgDetailBKM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox tbNoBKM;
        private System.Windows.Forms.GroupBox gbUpdateDetailBKM;
        private ISA.Controls.CommandButton cmdCancel;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.NumericTextBox tbJumlah;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uraian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.TextBox tbTerbilang;
        private ISA.Finance.Controls.LookupPerkiraanKoneksi tbUraian;
        private System.Windows.Forms.Label label12;
        private ISA.Controls.CommonTextBox txtUraian;

    }
}
