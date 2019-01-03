namespace ISA.Finance.Testing
{
    partial class PerkiraanUpdateTest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerkiraanUpdateTest));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoPerkiraan = new ISA.Controls.CommonTextBox();
            this.txtUraian = new ISA.Controls.CommonTextBox();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.txtRef = new ISA.Controls.CommonTextBox();
            this.chkPassive = new System.Windows.Forms.CheckBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "No Perkiraan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uraian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ref";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pasif";
            // 
            // txtNoPerkiraan
            // 
            this.txtNoPerkiraan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoPerkiraan.Location = new System.Drawing.Point(114, 39);
            this.txtNoPerkiraan.Name = "txtNoPerkiraan";
            this.txtNoPerkiraan.Size = new System.Drawing.Size(100, 20);
            this.txtNoPerkiraan.TabIndex = 8;
            // 
            // txtUraian
            // 
            this.txtUraian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUraian.Location = new System.Drawing.Point(114, 76);
            this.txtUraian.Name = "txtUraian";
            this.txtUraian.Size = new System.Drawing.Size(484, 20);
            this.txtUraian.TabIndex = 9;
            // 
            // cboLevel
            // 
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboLevel.Location = new System.Drawing.Point(114, 116);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(38, 22);
            this.cboLevel.TabIndex = 10;
            // 
            // txtRef
            // 
            this.txtRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRef.Location = new System.Drawing.Point(114, 154);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(52, 20);
            this.txtRef.TabIndex = 11;
            // 
            // chkPassive
            // 
            this.chkPassive.AutoSize = true;
            this.chkPassive.Location = new System.Drawing.Point(114, 191);
            this.chkPassive.Name = "chkPassive";
            this.chkPassive.Size = new System.Drawing.Size(15, 14);
            this.chkPassive.TabIndex = 12;
            this.chkPassive.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(464, 274);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(581, 274);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 14;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PerkiraanUpdateTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.chkPassive);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cboLevel);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.txtUraian);
            this.Controls.Add(this.txtNoPerkiraan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PerkiraanUpdateTest";
            this.Load += new System.EventHandler(this.PerkiraanUpdateTest_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerkiraanUpdateTest_FormClosed);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNoPerkiraan, 0);
            this.Controls.SetChildIndex(this.txtUraian, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.cboLevel, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.txtRef, 0);
            this.Controls.SetChildIndex(this.chkPassive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Controls.CommonTextBox txtNoPerkiraan;
        private ISA.Controls.CommonTextBox txtUraian;
        private System.Windows.Forms.ComboBox cboLevel;
        private ISA.Controls.CommonTextBox txtRef;
        private System.Windows.Forms.CheckBox chkPassive;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
