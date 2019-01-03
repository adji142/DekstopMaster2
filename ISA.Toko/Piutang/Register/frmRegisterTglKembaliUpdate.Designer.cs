namespace ISA.Toko.Register
{
    partial class frmRegisterTglKembaliUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterTglKembaliUpdate));
            this.label3 = new System.Windows.Forms.Label();
            this.dateTextBox1 = new ISA.Controls.DateTextBox();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tgl Kembali";
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(128, 22);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(113, 20);
            this.dateTextBox1.TabIndex = 28;
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(192, 87);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 26;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 87);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 25;
            this.commandButton1.Text = "SAVE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // frmRegisterTglKembaliUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(304, 139);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.MaximizeBox = false;
            this.Name = "frmRegisterTglKembaliUpdate";
            this.Text = "Tgl Kembali";
            this.Load += new System.EventHandler(this.frmRegisterTglKembaliUpdate_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.DateTextBox dateTextBox1;
    }
}
