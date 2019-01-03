namespace ISA.Trading.AKC
{
    partial class LaporanHasilKunjunganCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaporanHasilKunjunganCollector));
            this.commandButton2 = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate1 = new ISA.Trading.Controls.DateTextBox();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate2 = new ISA.Trading.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(375, 157);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 20;
            this.commandButton2.Text = "CANCEL";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "s/d";
            // 
            // txtDate1
            // 
            this.txtDate1.DateValue = null;
            this.txtDate1.Location = new System.Drawing.Point(259, 108);
            this.txtDate1.MaxLength = 10;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Size = new System.Drawing.Size(80, 20);
            this.txtDate1.TabIndex = 15;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(203, 157);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 19;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tanggal";
            // 
            // txtDate2
            // 
            this.txtDate2.DateValue = null;
            this.txtDate2.Location = new System.Drawing.Point(410, 108);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Size = new System.Drawing.Size(80, 20);
            this.txtDate2.TabIndex = 16;
            // 
            // LaporanHasilKunjunganCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LaporanHasilKunjunganCollector";
            this.Load += new System.EventHandler(this.LaporanHasilKunjunganCollector_Load);
            this.Controls.SetChildIndex(this.txtDate2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.txtDate1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton commandButton2;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.DateTextBox txtDate1;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.DateTextBox txtDate2;
    }
}
