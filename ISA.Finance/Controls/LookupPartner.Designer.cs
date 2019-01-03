namespace ISA.Finance.Controls
{
    partial class LookupPartner
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
            this.lblPerkiraan = new System.Windows.Forms.Label();
            this.txtPerkiraan = new System.Windows.Forms.TextBox();
            this.cmdLookup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPerkiraan
            // 
            this.lblPerkiraan.AutoSize = true;
            this.lblPerkiraan.Location = new System.Drawing.Point(0, 31);
            this.lblPerkiraan.Name = "lblPerkiraan";
            this.lblPerkiraan.Size = new System.Drawing.Size(43, 13);
            this.lblPerkiraan.TabIndex = 12;
            this.lblPerkiraan.Text = "[CODE]";
            // 
            // txtPerkiraan
            // 
            this.txtPerkiraan.Location = new System.Drawing.Point(0, 5);
            this.txtPerkiraan.MaxLength = 12;
            this.txtPerkiraan.Name = "txtPerkiraan";
            this.txtPerkiraan.Size = new System.Drawing.Size(200, 20);
            this.txtPerkiraan.TabIndex = 11;
            // 
            // cmdLookup
            // 
            this.cmdLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLookup.BackgroundImage = global::ISA.Finance.Properties.Resources.Search16;
            this.cmdLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdLookup.Location = new System.Drawing.Point(206, 2);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(29, 25);
            this.cmdLookup.TabIndex = 13;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // LookupPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.lblPerkiraan);
            this.Controls.Add(this.txtPerkiraan);
            this.Name = "LookupPartner";
            this.Size = new System.Drawing.Size(234, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.Label lblPerkiraan;
        private System.Windows.Forms.TextBox txtPerkiraan;
    }
}
