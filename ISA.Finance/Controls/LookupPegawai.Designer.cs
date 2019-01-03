namespace ISA.Finance.Controls
{
    partial class LookupPegawai
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
            this.commonTextBox1 = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // commonTextBox1
            // 
            this.commonTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commonTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.commonTextBox1.Location = new System.Drawing.Point(0, 0);
            this.commonTextBox1.Name = "commonTextBox1";
            this.commonTextBox1.Size = new System.Drawing.Size(101, 20);
            this.commonTextBox1.TabIndex = 0;
            this.commonTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commonTextBox1_KeyDown);
            // 
            // LookupPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commonTextBox1);
            this.Name = "LookupPegawai";
            this.Size = new System.Drawing.Size(103, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox commonTextBox1;
    }
}
