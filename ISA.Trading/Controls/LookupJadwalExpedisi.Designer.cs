namespace ISA.Trading.Controls
{
    partial class LookupJadwalExpedisi
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
            this.labelRowID = new System.Windows.Forms.Label();
            this.txtLookupName = new ISA.Trading.Controls.CommonTextBox();
            this.TxtFromTo = new ISA.Trading.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // cmdLookup
            // 
            this.cmdLookup.Image = global::ISA.Trading.Properties.Resources.Search16;
            this.cmdLookup.Location = new System.Drawing.Point(189, 4);
            this.cmdLookup.Name = "cmdLookup";
            this.cmdLookup.Size = new System.Drawing.Size(29, 25);
            this.cmdLookup.TabIndex = 11;
            this.cmdLookup.TabStop = false;
            this.cmdLookup.UseVisualStyleBackColor = true;
            this.cmdLookup.Click += new System.EventHandler(this.cmdLookup_Click);
            // 
            // labelRowID
            // 
            this.labelRowID.AutoSize = true;
            this.labelRowID.Location = new System.Drawing.Point(214, 37);
            this.labelRowID.Name = "labelRowID";
            this.labelRowID.Size = new System.Drawing.Size(0, 13);
            this.labelRowID.TabIndex = 12;
            this.labelRowID.Visible = false;
            // 
            // txtLookupName
            // 
            this.txtLookupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupName.Location = new System.Drawing.Point(5, 6);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(179, 20);
            this.txtLookupName.TabIndex = 10;
            // 
            // TxtFromTo
            // 
            this.TxtFromTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFromTo.Location = new System.Drawing.Point(6, 34);
            this.TxtFromTo.Name = "TxtFromTo";
            this.TxtFromTo.Size = new System.Drawing.Size(178, 20);
            this.TxtFromTo.TabIndex = 13;
            // 
            // LookupJadwalExpedisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFromTo);
            this.Controls.Add(this.labelRowID);
            this.Controls.Add(this.cmdLookup);
            this.Controls.Add(this.txtLookupName);
            this.Name = "LookupJadwalExpedisi";
            this.Size = new System.Drawing.Size(227, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLookup;
        private CommonTextBox txtLookupName;
        private System.Windows.Forms.Label labelRowID;
        private CommonTextBox TxtFromTo;
    }
}
