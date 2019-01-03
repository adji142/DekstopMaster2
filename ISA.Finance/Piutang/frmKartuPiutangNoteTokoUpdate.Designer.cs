namespace ISA.Finance.Piutang
{
    partial class frmKartuPiutangNoteTokoUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKartuPiutangNoteTokoUpdate));
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWilID = new System.Windows.Forms.TextBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKodePos = new System.Windows.Forms.ComboBox();
            this.txtINfoTagih = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCatatanToko = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(388, 164);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 3;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(499, 164);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 4;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wil. ID        :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Info Tagih :";
            // 
            // txtWilID
            // 
            this.txtWilID.Location = new System.Drawing.Point(98, 25);
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.ReadOnly = true;
            this.txtWilID.Size = new System.Drawing.Size(100, 20);
            this.txtWilID.TabIndex = 7;
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(277, 25);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(100, 20);
            this.txtGrade.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Grade  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kode Pos  :";
            // 
            // cboKodePos
            // 
            this.cboKodePos.FormattingEnabled = true;
            this.cboKodePos.Location = new System.Drawing.Point(478, 28);
            this.cboKodePos.Name = "cboKodePos";
            this.cboKodePos.Size = new System.Drawing.Size(121, 22);
            this.cboKodePos.TabIndex = 11;
            // 
            // txtINfoTagih
            // 
            this.txtINfoTagih.Location = new System.Drawing.Point(98, 64);
            this.txtINfoTagih.Name = "txtINfoTagih";
            this.txtINfoTagih.Size = new System.Drawing.Size(279, 20);
            this.txtINfoTagih.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Catatan Toko :";
            // 
            // txtCatatanToko
            // 
            this.txtCatatanToko.Location = new System.Drawing.Point(28, 128);
            this.txtCatatanToko.Name = "txtCatatanToko";
            this.txtCatatanToko.Size = new System.Drawing.Size(571, 20);
            this.txtCatatanToko.TabIndex = 14;
            // 
            // frmKartuPiutangNoteTokoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(611, 209);
            this.Controls.Add(this.txtINfoTagih);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCatatanToko);
            this.Controls.Add(this.txtWilID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboKodePos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKartuPiutangNoteTokoUpdate";
            this.Text = "Catatan Toko";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmKartuPiutangNoteTokoUpdate_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtGrade, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboKodePos, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtWilID, 0);
            this.Controls.SetChildIndex(this.txtCatatanToko, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtINfoTagih, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWilID;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKodePos;
        private System.Windows.Forms.TextBox txtINfoTagih;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCatatanToko;
    }
}
