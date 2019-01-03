namespace ISA.Finance.Controls
{
    partial class LookupBankAsal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLookup = new System.Windows.Forms.Label();
            this.txtLookup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLookup
            // 
            this.lblLookup.AutoSize = true;
            this.lblLookup.Location = new System.Drawing.Point(-3, 26);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(51, 13);
            this.lblLookup.TabIndex = 15;
            this.lblLookup.Text = "[LOKASI]";
            // 
            // txtLookup
            // 
            this.txtLookup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookup.Location = new System.Drawing.Point(0, 3);
            this.txtLookup.MaxLength = 12;
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(132, 20);
            this.txtLookup.TabIndex = 14;
            this.txtLookup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookup_KeyPress);
            // 
            // LookupBankAsal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLookup);
            this.Controls.Add(this.txtLookup);
            this.Name = "LookupBankAsal";
            this.Size = new System.Drawing.Size(154, 45);
            this.Load += new System.EventHandler(this.LookupBankAsal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLookup;
        private System.Windows.Forms.TextBox txtLookup;
    }
}
