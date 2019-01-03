namespace ISA.Controls
{
    partial class LookupGudang
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
            this.txtLookupName = new ISA.Controls.CommonTextBox();
            this.cmdLookup = new System.Windows.Forms.Button();
            this.txtLookupCode = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // txtLookupName
            // 
            this.txtLookupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookupName.Location = new System.Drawing.Point(3, 3);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(233, 20);
            this.txtLookupName.TabIndex = 8;
            this.txtLookupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookupName_KeyPress);
            // 
            // cmdLookup
            // 
            this.cmdLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLookup.Image = global::ISA.Controls.Properties.Resources.Search16;
            this.cmdLookup.Location = new System.Drawing.Point(244, 0);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(29, 25);
            this.cmdLookup.TabIndex = 9;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // txtLookupCode
            // 
            this.txtLookupCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLookupCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtLookupCode.Location = new System.Drawing.Point(3, 29);
            this.txtLookupCode.Name = "txtLookupCode";
            this.txtLookupCode.ReadOnly = true;
            this.txtLookupCode.Size = new System.Drawing.Size(117, 15);
            this.txtLookupCode.TabIndex = 14;
            this.txtLookupCode.TabStop = false;
            this.txtLookupCode.Text = "[Code]";
            // 
            // LookupGudang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLookupCode);
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtLookupName);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name = "LookupGudang";
            this.Size = new System.Drawing.Size(276, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private ISA.Controls.CommonTextBox txtLookupName;
        private ISA.Controls.CommonTextBox txtLookupCode;
    }
}
