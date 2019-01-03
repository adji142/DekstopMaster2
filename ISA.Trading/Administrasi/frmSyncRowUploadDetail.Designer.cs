namespace ISA.Trading.Administrasi
{
    partial class frmSyncRowUploadDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncRowUploadDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRow = new ISA.Trading.Controls.CommonTextBox();
            this.txtBatchID = new ISA.Trading.Controls.CommonTextBox();
            this.txtTable = new ISA.Trading.Controls.CommonTextBox();
            this.txtData = new ISA.Trading.Controls.CommonTextBox();
            this.txtStatus = new ISA.Trading.Controls.CommonTextBox();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Row ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Batch ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status";
            // 
            // txtRow
            // 
            this.txtRow.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRow.Location = new System.Drawing.Point(143, 66);
            this.txtRow.MaxLength = 50;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(398, 20);
            this.txtRow.TabIndex = 0;
            this.txtRow.TabStop = false;
            // 
            // txtBatchID
            // 
            this.txtBatchID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBatchID.Location = new System.Drawing.Point(143, 94);
            this.txtBatchID.MaxLength = 50;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.ReadOnly = true;
            this.txtBatchID.Size = new System.Drawing.Size(398, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.TabStop = false;
            // 
            // txtTable
            // 
            this.txtTable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTable.Location = new System.Drawing.Point(143, 122);
            this.txtTable.MaxLength = 250;
            this.txtTable.Name = "txtTable";
            this.txtTable.ReadOnly = true;
            this.txtTable.Size = new System.Drawing.Size(398, 20);
            this.txtTable.TabIndex = 2;
            this.txtTable.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Location = new System.Drawing.Point(143, 150);
            this.txtData.MaxLength = 8000;
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(398, 104);
            this.txtData.TabIndex = 3;
            this.txtData.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.Location = new System.Drawing.Point(143, 261);
            this.txtStatus.MaxLength = 50;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(398, 20);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(426, 289);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmSyncRowUploadDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.txtBatchID);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormID = "SC0115";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSyncRowUploadDetail";
            this.Text = "SC0115 - Synchronization Row Detail (Data yang dikirim)";
            this.Title = "Synchronization Row Detail (Data yang dikirim)";
            this.Load += new System.EventHandler(this.frmSyncRowUploadDetail_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtRow, 0);
            this.Controls.SetChildIndex(this.txtBatchID, 0);
            this.Controls.SetChildIndex(this.txtTable, 0);
            this.Controls.SetChildIndex(this.txtData, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.CommonTextBox txtRow;
        private ISA.Trading.Controls.CommonTextBox txtBatchID;
        private ISA.Trading.Controls.CommonTextBox txtTable;
        private ISA.Trading.Controls.CommonTextBox txtData;
        private ISA.Trading.Controls.CommonTextBox txtStatus;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
