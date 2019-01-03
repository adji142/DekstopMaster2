namespace ISA.Toko.Controls
{
    partial class LookupSecurityUsers
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
            this.txtLookupCode = new ISA.Toko.Controls.CommonTextBox();
            this.txtLookupName = new ISA.Toko.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdLookup
            // 
            this.cmdLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLookup.Image = global::ISA.Toko.Properties.Resources.Search16;
            this.cmdLookup.Location = new System.Drawing.Point(254, 2);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(25, 23);
            this.cmdLookup.TabIndex = 6;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // txtLookupCode
            // 
            this.txtLookupCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLookupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookupCode.Location = new System.Drawing.Point(3, 29);
            this.txtLookupCode.Name = "txtLookupCode";
            this.txtLookupCode.ReadOnly = true;
            this.txtLookupCode.Size = new System.Drawing.Size(100, 15);
            this.txtLookupCode.TabIndex = 7;
            this.txtLookupCode.TabStop = false;
            this.txtLookupCode.Text = "[CODE]";
            // 
            // txtLookupName
            // 
            this.txtLookupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupName.Location = new System.Drawing.Point(3, 3);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(245, 20);
            this.txtLookupName.TabIndex = 5;
            this.txtLookupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLookupName_KeyDown);
            this.txtLookupName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLookupName_KeyUp);
            this.txtLookupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookupName_KeyPress);
            // 
            // LookupSecurityUsers
            // 
            this.Controls.Add(this.txtLookupCode);
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtLookupName);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name = "LookupSecurityUsers";
            this.Size = new System.Drawing.Size(282, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommonTextBox txtLookupCode;
        private System.Windows.Forms.Button cmdLookup;
        private ISA.Toko.Controls.CommonTextBox txtLookupName;
    }
}
