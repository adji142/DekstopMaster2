namespace ISA.Bengkel.Lookup
{
    partial class LookupCustomerALL
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
            this.cmdLookup = new System.Windows.Forms.Button();
            this.txtNoMember = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdLookup
            // 
            this.cmdLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLookup.Location = new System.Drawing.Point(206, 9);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(29, 25);
            this.cmdLookup.TabIndex = 12;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // txtNoMember
            // 
            this.txtNoMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoMember.Location = new System.Drawing.Point(3, 10);
            this.txtNoMember.Name = "txtNoMember";
            this.txtNoMember.Size = new System.Drawing.Size(197, 20);
            this.txtNoMember.TabIndex = 11;
            this.txtNoMember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoMember_KeyPress);
            // 
            // LookupCustomerALL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtNoMember);
            this.Name = "LookupCustomerALL";
            this.Size = new System.Drawing.Size(309, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private ISA.Controls.CommonTextBox txtNoMember;

    }
}
