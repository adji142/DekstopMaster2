namespace ISA.Controls
{
    partial class LookupDO
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
            this.txtLookupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdLookup
            // 
            this.cmdLookup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdLookup.Image = global::ISA.Controls.Properties.Resources.Search16;
            this.cmdLookup.Location = new System.Drawing.Point(89, 2);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(25, 23);
            this.cmdLookup.TabIndex = 6;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // txtLookupName
            // 
            this.txtLookupName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLookupName.Location = new System.Drawing.Point(3, 3);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(80, 20);
            this.txtLookupName.TabIndex = 5;
            this.txtLookupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookupName_KeyPress);
            // 
            // LookupDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtLookupName);
            this.Name = "LookupDO";
            this.Size = new System.Drawing.Size(117, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private System.Windows.Forms.TextBox txtLookupName;



    }
}
