namespace ISA.Trading.Master
{
    partial class frmTabelJwJsFxUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTabelJwJsFxUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmsClose = new ISA.Trading.Controls.CommandButton();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.numericTextBox2 = new ISA.Trading.Controls.NumericTextBox();
            this.numericTextBox1 = new ISA.Trading.Controls.NumericTextBox();
            this.dateTextBox2 = new ISA.Trading.Controls.DateTextBox();
            this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tanggal Aktif";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hari Kredit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hari Sales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tanggal Passif";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // cmsClose
            // 
            this.cmsClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmsClose.Image = ((System.Drawing.Image)(resources.GetObject("cmsClose.Image")));
            this.cmsClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmsClose.Location = new System.Drawing.Point(287, 223);
            this.cmsClose.Name = "cmsClose";
            this.cmsClose.Size = new System.Drawing.Size(100, 40);
            this.cmsClose.TabIndex = 17;
            this.cmsClose.Text = "CLOSE";
            this.cmsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmsClose.UseVisualStyleBackColor = true;
            this.cmsClose.Click += new System.EventHandler(this.cmsClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(184, 223);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 16;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(112, 161);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox2.TabIndex = 15;
            this.numericTextBox2.Text = "0";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(112, 135);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 14;
            this.numericTextBox1.Text = "0";
            // 
            // dateTextBox2
            // 
            this.dateTextBox2.DateValue = null;
            this.dateTextBox2.Location = new System.Drawing.Point(441, 81);
            this.dateTextBox2.MaxLength = 10;
            this.dateTextBox2.Name = "dateTextBox2";
            this.dateTextBox2.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox2.TabIndex = 12;
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(112, 81);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(100, 20);
            this.dateTextBox1.TabIndex = 11;
            // 
            // frmTabelJwJsFxUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(558, 300);
            this.Controls.Add(this.cmsClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTextBox2);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTabelJwJsFxUpdate";
            this.Text = "Update tabel Jw dan Js (Fx)";
            this.Title = "Update tabel Jw dan Js (Fx)";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.dateTextBox2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.Controls.SetChildIndex(this.numericTextBox2, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmsClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private ISA.Trading.Controls.DateTextBox dateTextBox2;
        private System.Windows.Forms.TextBox textBox1;
        private ISA.Trading.Controls.NumericTextBox numericTextBox1;
        private ISA.Trading.Controls.NumericTextBox numericTextBox2;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmsClose;
    }
}
