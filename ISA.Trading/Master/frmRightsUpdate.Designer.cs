namespace ISA.Trading.Master
{
    partial class frmRightsUpdate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRightsUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRightID = new ISA.Trading.Controls.KodeTextBox();
            this.txtRightName = new ISA.Trading.Controls.CommonTextBox();
            this.cmdSave = new ISA.Trading.Controls.CommandButton();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Right ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Right Name";
            // 
            // txtRightID
            // 
            this.txtRightID.CodeType = ISA.Trading.Controls.KodeTextBox.enCodeType.KodeBarang;
            this.txtRightID.Location = new System.Drawing.Point(131, 66);
            this.txtRightID.MaxLength = 12;
            this.txtRightID.Name = "txtRightID";
            this.txtRightID.Size = new System.Drawing.Size(233, 20);
            this.txtRightID.TabIndex = 0;
            // 
            // txtRightName
            // 
            this.txtRightName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRightName.Location = new System.Drawing.Point(131, 102);
            this.txtRightName.MaxLength = 50;
            this.txtRightName.Name = "txtRightName";
            this.txtRightName.Size = new System.Drawing.Size(270, 20);
            this.txtRightName.TabIndex = 1;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(131, 141);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 43);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(254, 141);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(117, 43);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmRightsUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtRightName);
            this.Controls.Add(this.txtRightID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRightsUpdate";
            this.Text = "Rights";
            this.Title = "Rights";
            this.Load += new System.EventHandler(this.frmRightsUpdate_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRightID, 0);
            this.Controls.SetChildIndex(this.txtRightName, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.KodeTextBox txtRightID;
        private ISA.Trading.Controls.CommonTextBox txtRightName;
        private ISA.Trading.Controls.CommandButton cmdSave;
        private ISA.Trading.Controls.CommandButton cmdClose;
    }
}
