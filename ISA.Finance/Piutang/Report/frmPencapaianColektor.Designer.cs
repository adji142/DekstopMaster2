namespace ISA.Finance.Piutang.Report
{
    partial class frmPencapaianColektor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPencapaianColektor));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintColektor = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnREfresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masukkan Tanggal";
            // 
            // btnPrintColektor
            // 
            this.btnPrintColektor.Location = new System.Drawing.Point(244, 81);
            this.btnPrintColektor.Name = "btnPrintColektor";
            this.btnPrintColektor.Size = new System.Drawing.Size(88, 31);
            this.btnPrintColektor.TabIndex = 2;
            this.btnPrintColektor.Text = "Save Excel";
            this.btnPrintColektor.UseVisualStyleBackColor = true;
            this.btnPrintColektor.Click += new System.EventHandler(this.btnPrintColektor_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // btnREfresh
            // 
            this.btnREfresh.Location = new System.Drawing.Point(54, 81);
            this.btnREfresh.Name = "btnREfresh";
            this.btnREfresh.Size = new System.Drawing.Size(90, 31);
            this.btnREfresh.TabIndex = 4;
            this.btnREfresh.Text = "Refresh Data";
            this.btnREfresh.UseVisualStyleBackColor = true;
            this.btnREfresh.Click += new System.EventHandler(this.btnREfresh_Click);
            // 
            // frmPencapaianColektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(368, 134);
            this.Controls.Add(this.btnREfresh);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnPrintColektor);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPencapaianColektor";
            this.Text = "Pencapaian Colektor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintColektor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnREfresh;
    }
}