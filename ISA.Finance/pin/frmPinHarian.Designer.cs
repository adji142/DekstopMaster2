namespace ISA.Finance.pin
{
    partial class frmPinHarian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPinHarian));
            this.txtKet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // txtKet
            // 
            this.txtKet.AutoSize = true;
            this.txtKet.ForeColor = System.Drawing.Color.Red;
            this.txtKet.Location = new System.Drawing.Point(3, 240);
            this.txtKet.Name = "txtKet";
            this.txtKet.Size = new System.Drawing.Size(67, 13);
            this.txtKet.TabIndex = 18;
            this.txtKet.Text = "[keterangan]";
            this.txtKet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "PIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "Masukan PIN";
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(111, 95);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(134, 32);
            this.txtPin.TabIndex = 15;
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(210, 171);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(86, 37);
            this.cmdYes.TabIndex = 14;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // frmPinHarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 262);
            this.Controls.Add(this.txtKet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.cmdYes);
            this.Name = "frmPinHarian";
            this.Text = "frmPinHarian";
            this.Load += new System.EventHandler(this.frmPinHarian_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtKet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPin;
        private ISA.Controls.CommandButton cmdYes;
    }
}