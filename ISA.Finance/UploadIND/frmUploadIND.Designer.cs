namespace ISA.Finance.UploadIND
{
    partial class frmUploadIND
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploadIND));
            this.label1 = new System.Windows.Forms.Label();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lookupBank1 = new ISA.Finance.Controls.LookupBank();
            this.cmdUpload = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.chkInclude = new System.Windows.Forms.CheckBox();
            this.txtInitCabang = new ISA.Controls.CommonTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblCountRow = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblCountTable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWilID = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Range Tanggal";
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(126, 26);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 4;
            this.rangeDateBox1.ToDate = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Rekening PT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Upload Ke";
            // 
            // lookupBank1
            // 
            this.lookupBank1.BankID = "[CODE]";
            this.lookupBank1.Location = new System.Drawing.Point(135, 54);
            this.lookupBank1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.lookupBank1.NamaBank = "";
            this.lookupBank1.Name = "lookupBank1";
            this.lookupBank1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupBank1.Size = new System.Drawing.Size(166, 44);
            this.lookupBank1.TabIndex = 8;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpload.CommandType = ISA.Controls.CommandButton.enCommandType.Upload;
            this.cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(193, 273);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(128, 40);
            this.cmdUpload.TabIndex = 10;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(348, 273);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // chkInclude
            // 
            this.chkInclude.AutoSize = true;
            this.chkInclude.Location = new System.Drawing.Point(135, 186);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Size = new System.Drawing.Size(148, 18);
            this.chkInclude.TabIndex = 12;
            this.chkInclude.Text = "Include Transaksi POS";
            this.chkInclude.UseVisualStyleBackColor = true;
            this.chkInclude.CheckedChanged += new System.EventHandler(this.chkInclude_CheckedChanged);
            // 
            // txtInitCabang
            // 
            this.txtInitCabang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInitCabang.Location = new System.Drawing.Point(135, 160);
            this.txtInitCabang.Name = "txtInitCabang";
            this.txtInitCabang.ReadOnly = true;
            this.txtInitCabang.Size = new System.Drawing.Size(54, 20);
            this.txtInitCabang.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 216);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // lblCountRow
            // 
            this.lblCountRow.AutoSize = true;
            this.lblCountRow.Location = new System.Drawing.Point(414, 242);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(13, 14);
            this.lblCountRow.TabIndex = 19;
            this.lblCountRow.Text = "0";
            this.lblCountRow.Visible = false;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(235, 242);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(80, 14);
            this.lblTableName.TabIndex = 18;
            this.lblTableName.Text = "lblTableName";
            this.lblTableName.Visible = false;
            // 
            // lblCountTable
            // 
            this.lblCountTable.AutoSize = true;
            this.lblCountTable.Location = new System.Drawing.Point(59, 242);
            this.lblCountTable.Name = "lblCountTable";
            this.lblCountTable.Size = new System.Drawing.Size(41, 14);
            this.lblCountTable.TabIndex = 17;
            this.lblCountTable.Text = "0 of 11";
            this.lblCountTable.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "TABLE:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "ID Wil";
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(135, 106);
            this.txtWilID.MaxLength = 50;
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(166, 20);
            this.txtWilID.TabIndex = 21;
            // 
            // frmUploadIND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(460, 325);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCountRow);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lblCountTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtInitCabang);
            this.Controls.Add(this.chkInclude);
            this.Controls.Add(this.lookupBank1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdUpload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUploadIND";
            this.Text = "Upload IND";
            this.Shown += new System.EventHandler(this.frmUploadIND_Shown);
            this.Controls.SetChildIndex(this.cmdUpload, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.lookupBank1, 0);
            this.Controls.SetChildIndex(this.chkInclude, 0);
            this.Controls.SetChildIndex(this.txtInitCabang, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblCountTable, 0);
            this.Controls.SetChildIndex(this.lblTableName, 0);
            this.Controls.SetChildIndex(this.lblCountRow, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ISA.Finance.Controls.LookupBank lookupBank1;
        private ISA.Controls.CommandButton cmdUpload;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.CheckBox chkInclude;
        private ISA.Controls.CommonTextBox txtInitCabang;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCountRow;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblCountTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox txtWilID;
    }
}
