namespace ISA.Finance.pin
{
    partial class frmPinVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPinVerification));
            this.label4 = new System.Windows.Forms.Label();
            this.lblKet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.cmdYes = new ISA.Controls.CommandButton();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(326, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "v 2.0.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKet
            // 
            this.lblKet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKet.AutoSize = true;
            this.lblKet.ForeColor = System.Drawing.Color.Red;
            this.lblKet.Location = new System.Drawing.Point(6, 230);
            this.lblKet.Name = "lblKet";
            this.lblKet.Size = new System.Drawing.Size(67, 13);
            this.lblKet.TabIndex = 31;
            this.lblKet.Text = "[keterangan]";
            this.lblKet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 26);
            this.label3.TabIndex = 30;
            this.label3.Text = "PIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Masukan PIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 28;
            this.label1.Text = "PUBLIC KEY";
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(165, 122);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(156, 32);
            this.txtPin.TabIndex = 25;
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPin.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            this.txtPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPin_KeyDown);
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
            this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdYes.Location = new System.Drawing.Point(221, 160);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(100, 40);
            this.cmdYes.TabIndex = 26;
            this.cmdYes.Text = "YES";
            this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(165, 84);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(156, 32);
            this.txtKey.TabIndex = 27;
            this.txtKey.TabStop = false;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPinVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 268);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.txtKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPinVerification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verifikasi PIN";
            this.Load += new System.EventHandler(this.frmPinVerification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPin;
        private ISA.Controls.CommandButton cmdYes;
        private System.Windows.Forms.TextBox txtKey;
    }
}