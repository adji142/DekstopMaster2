namespace ISA.Toko.Controls
{
    partial class LookupBank
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
            this.cmdLookup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLookup
            // 
            this.lblLookup.AutoSize = true;
            this.lblLookup.Location = new System.Drawing.Point(3, 30);
            this.lblLookup.Name = "lblLookup";
            this.lblLookup.Size = new System.Drawing.Size(43, 13);
            this.lblLookup.TabIndex = 12;
            this.lblLookup.Text = "[CODE]";
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(0, 3);
            this.txtLookup.MaxLength = 12;
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.Size = new System.Drawing.Size(140, 20);
            this.txtLookup.TabIndex = 11;
            this.txtLookup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookup_KeyPress);
            // 
            // cmdLookup
            // 
            this.cmdLookup.BackgroundImage = global::ISA.Toko.Properties.Resources.Search16;
            this.cmdLookup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdLookup.Location = new System.Drawing.Point(146, 0);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(26, 25);
            this.cmdLookup.TabIndex = 13;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // LookupBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.lblLookup);
            this.Controls.Add(this.txtLookup);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Name = "LookupBank";
            this.Size = new System.Drawing.Size(175, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.Label lblLookup;
        private System.Windows.Forms.TextBox txtLookup;
    }
}
