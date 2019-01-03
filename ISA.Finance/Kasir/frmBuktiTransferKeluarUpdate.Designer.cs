namespace ISA.Finance.Kasir
{
    partial class frmBuktiTransferKeluarUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuktiTransferKeluarUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKepada = new ISA.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridTransfer = new ISA.Controls.CustomGridView();
            this.NoTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowIDDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransferKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericTextBox1 = new ISA.Controls.NumericTextBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.cmdAdd = new ISA.Controls.CommandButton();
            this.lblNoBkk = new System.Windows.Forms.Label();
            this.lookupBank1 = new ISA.Finance.Controls.LookupBank();
            this.cmdEdit = new ISA.Controls.CommandButton();
            this.cmdDelete = new ISA.Controls.CommandButton();
            this.lblPetunjuk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "VOUCHER TRANSFER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dibayarkan Kepada   :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bank  :";
            // 
            // txtKepada
            // 
            this.txtKepada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKepada.Location = new System.Drawing.Point(175, 75);
            this.txtKepada.Name = "txtKepada";
            this.txtKepada.Size = new System.Drawing.Size(163, 20);
            this.txtKepada.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "No. : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tanggal : ";
            // 
            // gridTransfer
            // 
            this.gridTransfer.AllowUserToAddRows = false;
            this.gridTransfer.AllowUserToDeleteRows = false;
            this.gridTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoTransfer,
            this.RowIDDetail,
            this.TransferKe,
            this.Nominal});
            this.gridTransfer.Location = new System.Drawing.Point(13, 157);
            this.gridTransfer.MultiSelect = false;
            this.gridTransfer.Name = "gridTransfer";
            this.gridTransfer.ReadOnly = true;
            this.gridTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridTransfer.Size = new System.Drawing.Size(673, 243);
            this.gridTransfer.StandardTab = true;
            this.gridTransfer.TabIndex = 10;
            this.gridTransfer.Enter += new System.EventHandler(this.gridTransfer_Enter);
            // 
            // NoTransfer
            // 
            this.NoTransfer.DataPropertyName = "Nomor";
            this.NoTransfer.HeaderText = "No.Transfer";
            this.NoTransfer.Name = "NoTransfer";
            this.NoTransfer.ReadOnly = true;
            // 
            // RowIDDetail
            // 
            this.RowIDDetail.DataPropertyName = "RowIDDetail";
            this.RowIDDetail.HeaderText = "Column1";
            this.RowIDDetail.Name = "RowIDDetail";
            this.RowIDDetail.ReadOnly = true;
            this.RowIDDetail.Visible = false;
            // 
            // TransferKe
            // 
            this.TransferKe.DataPropertyName = "AsalTransfer";
            this.TransferKe.HeaderText = "Transfer Ke";
            this.TransferKe.Name = "TransferKe";
            this.TransferKe.ReadOnly = true;
            this.TransferKe.Width = 430;
            // 
            // Nominal
            // 
            this.Nominal.DataPropertyName = "Nominal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.Nominal.DefaultCellStyle = dataGridViewCellStyle1;
            this.Nominal.HeaderText = "Nominal";
            this.Nominal.Name = "Nominal";
            this.Nominal.ReadOnly = true;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Enabled = false;
            this.numericTextBox1.Location = new System.Drawing.Point(591, 432);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(95, 20);
            this.numericTextBox1.TabIndex = 11;
            this.numericTextBox1.Text = "0";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(521, 75);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(39, 14);
            this.lblTanggal.TabIndex = 12;
            this.lblTanggal.Text = "label6";
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(232, 425);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 13;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Visible = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblNoBkk
            // 
            this.lblNoBkk.AutoSize = true;
            this.lblNoBkk.Location = new System.Drawing.Point(522, 28);
            this.lblNoBkk.Name = "lblNoBkk";
            this.lblNoBkk.Size = new System.Drawing.Size(39, 14);
            this.lblNoBkk.TabIndex = 14;
            this.lblNoBkk.Text = "label6";
            // 
            // lookupBank1
            // 
            this.lookupBank1.BankID = "[CODE]";
            this.lookupBank1.Location = new System.Drawing.Point(175, 100);
            this.lookupBank1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lookupBank1.NamaBank = "";
            this.lookupBank1.Name = "lookupBank1";
            this.lookupBank1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupBank1.Size = new System.Drawing.Size(163, 51);
            this.lookupBank1.TabIndex = 1;
            this.lookupBank1.SelectData += new System.EventHandler(this.lookupBank1_SelectData);
            // 
            // cmdEdit
            // 
            this.cmdEdit.CommandType = ISA.Controls.CommandButton.enCommandType.Edit;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(338, 425);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(100, 40);
            this.cmdEdit.TabIndex = 16;
            this.cmdEdit.Text = "EDIT";
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(445, 426);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(100, 40);
            this.cmdDelete.TabIndex = 17;
            this.cmdDelete.Text = "DELETE";
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // lblPetunjuk
            // 
            this.lblPetunjuk.AutoSize = true;
            this.lblPetunjuk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetunjuk.Location = new System.Drawing.Point(10, 406);
            this.lblPetunjuk.Name = "lblPetunjuk";
            this.lblPetunjuk.Size = new System.Drawing.Size(283, 14);
            this.lblPetunjuk.TabIndex = 18;
            this.lblPetunjuk.Text = "INS = Tambah SPACE = Edit DEL = Hapus ESC = Keluar";
            this.lblPetunjuk.Visible = false;
            // 
            // frmBuktiTransferKeluarUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 475);
            this.Controls.Add(this.lblPetunjuk);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.lookupBank1);
            this.Controls.Add(this.lblNoBkk);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.gridTransfer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.txtKepada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "frmBuktiTransferKeluarUpdate";
            this.Text = "Voucher Transfer";
            this.Load += new System.EventHandler(this.frmBuktiTransferKeluarUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuktiTransferKeluarUpdate_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuktiTransferKeluarUpdate_KeyDown);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtKepada, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.gridTransfer, 0);
            this.Controls.SetChildIndex(this.lblTanggal, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.lblNoBkk, 0);
            this.Controls.SetChildIndex(this.lookupBank1, 0);
            this.Controls.SetChildIndex(this.cmdEdit, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.Controls.SetChildIndex(this.lblPetunjuk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommonTextBox txtKepada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CustomGridView gridTransfer;
        private ISA.Controls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label lblTanggal;
        private ISA.Controls.CommandButton cmdAdd;
        private System.Windows.Forms.Label lblNoBkk;
        private ISA.Finance.Controls.LookupBank lookupBank1;
        private ISA.Controls.CommandButton cmdEdit;
        private ISA.Controls.CommandButton cmdDelete;
        private System.Windows.Forms.Label lblPetunjuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransferKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nominal;
    }
}
