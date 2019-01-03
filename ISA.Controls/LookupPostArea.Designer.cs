namespace ISA.Controls
{
    partial class LookupPostArea
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtLookupName = new ISA.Controls.CommonTextBox();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(45, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(119, 14);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "ALL => Semua Pos";
            // 
            // txtLookupName
            // 
            this.txtLookupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLookupName.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtLookupName.Location = new System.Drawing.Point(3, 3);
            this.txtLookupName.MaxLength = 3;
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(34, 20);
            this.txtLookupName.TabIndex = 16;
            this.txtLookupName.TextChanged += new System.EventHandler(this.txtLookupName_TextChanged);
            this.txtLookupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLookupName_KeyPress);
            this.txtLookupName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLookupName_Validating);
            // 
            // LookupPostArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtLookupName);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name = "LookupPostArea";
            this.Size = new System.Drawing.Size(215, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private ISA.Controls.CommonTextBox txtLookupName;




    }
}
