namespace ISA.Trading.Master
{
    partial class frmUserAccessUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAccessUpdate));
            this.cboKey = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbCed = new System.Windows.Forms.RadioButton();
            this.rdbVew = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookupSecurityUsers1 = new ISA.Controls.LookupSecurityUsers();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboKey
            // 
            this.cboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKey.FormattingEnabled = true;
            this.cboKey.Items.AddRange(new object[] {
            "ARUS STOK INTERNAL",
            "CLOSING STOK",
            "GENERATE PIN",
            "KOREKSI PEMBELIAN",
            "KOREKSI PENJUALAN",
            "KOREKSI RETUR BELI",
            "KOREKSI RETUR JUAL",
            "LOCK/UNLOCK STOK MINUS",
            "MASTER STOK",
            "MUTASI",
            "PEMBELIAN",
            "PENJUALAN",
            "RETUR BELI",
            "RETUR JUAL",
            "SAMPLING OPNAME",
            "STOK BARCODE"});
            this.cboKey.Location = new System.Drawing.Point(107, 75);
            this.cboKey.Name = "cboKey";
            this.cboKey.Size = new System.Drawing.Size(176, 22);
            this.cboKey.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCed);
            this.groupBox1.Controls.Add(this.rdbVew);
            this.groupBox1.Location = new System.Drawing.Point(107, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 39);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // rdbCed
            // 
            this.rdbCed.AutoSize = true;
            this.rdbCed.Location = new System.Drawing.Point(7, 14);
            this.rdbCed.Name = "rdbCed";
            this.rdbCed.Size = new System.Drawing.Size(129, 18);
            this.rdbCed.TabIndex = 0;
            this.rdbCed.TabStop = true;
            this.rdbCed.Text = "Cretae, Edit, Delete";
            this.rdbCed.UseVisualStyleBackColor = true;
            // 
            // rdbVew
            // 
            this.rdbVew.AutoSize = true;
            this.rdbVew.Location = new System.Drawing.Point(175, 15);
            this.rdbVew.Name = "rdbVew";
            this.rdbVew.Size = new System.Drawing.Size(53, 18);
            this.rdbVew.TabIndex = 1;
            this.rdbVew.TabStop = true;
            this.rdbVew.Text = "View";
            this.rdbVew.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "UserID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "User Name";
            // 
            // lookupSecurityUsers1
            // 
            this.lookupSecurityUsers1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSecurityUsers1.Location = new System.Drawing.Point(104, 101);
            this.lookupSecurityUsers1.Name = "lookupSecurityUsers1";
            this.lookupSecurityUsers1.Size = new System.Drawing.Size(282, 50);
            this.lookupSecurityUsers1.TabIndex = 19;
            this.lookupSecurityUsers1.UserID = "[CODE]";
            this.lookupSecurityUsers1.UserName = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Access";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(224, 241);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 21;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(118, 241);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 20;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmUserAccessUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(442, 311);
            this.Controls.Add(this.cboKey);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookupSecurityUsers1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmUserAccessUpdate";
            this.Text = "User Access Update";
            this.Title = "User Access Update";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmUserAccessUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserAccessUpdate_FormClosed);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookupSecurityUsers1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cboKey, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbCed;
        private System.Windows.Forms.RadioButton rdbVew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.LookupSecurityUsers lookupSecurityUsers1;
        private System.Windows.Forms.Label label4;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CommandButton cmdSave;
    }
}
