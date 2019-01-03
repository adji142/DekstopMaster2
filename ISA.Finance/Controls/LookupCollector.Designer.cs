namespace ISA.Finance.Controls
{
    partial class LookupCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupCollector));
            this.txtLookupCode = new ISA.Controls.CommonTextBox();
            this.txtLookupName = new ISA.Controls.CommonTextBox();
            this.cmdLookup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLookupCode
            // 
            this.txtLookupCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLookupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupCode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookupCode.Location = new System.Drawing.Point(4, 31);
            this.txtLookupCode.Name = "txtLookupCode";
            this.txtLookupCode.ReadOnly = true;
            this.txtLookupCode.Size = new System.Drawing.Size(117, 14);
            this.txtLookupCode.TabIndex = 2;
            this.txtLookupCode.Text = "[CODE]";
            // 
            // txtLookupName
            // 
            this.txtLookupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupName.Location = new System.Drawing.Point(4, 4);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(241, 20);
            this.txtLookupName.TabIndex = 0;
            this.txtLookupName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLookupName_Validating);
            // 
            // cmdLookup
            // 
            this.cmdLookup.Image = ((System.Drawing.Image)(resources.GetObject("cmdLookup.Image")));
            this.cmdLookup.Location = new System.Drawing.Point(252, 0);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(29, 25);
            this.cmdLookup.TabIndex = 3;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click_1);
            // 
            // LookupCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtLookupCode);
            this.Controls.Add(this.txtLookupName);
            this.Name = "LookupCollector";
            this.Size = new System.Drawing.Size(286, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommonTextBox txtLookupName;
        private ISA.Controls.CommonTextBox txtLookupCode;
        private System.Windows.Forms.Button cmdLookup;
    }
}
