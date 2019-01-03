namespace ISA.Finance.Controls
{
    partial class LookupAccountToko
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
            this.TextBox1 = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBox1.Location = new System.Drawing.Point(0, 3);
            this.TextBox1.MaxLength = 15;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(143, 20);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // LookupAccountToko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBox1);
            this.Name = "LookupAccountToko";
            this.Size = new System.Drawing.Size(171, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox TextBox1;
    }
}
