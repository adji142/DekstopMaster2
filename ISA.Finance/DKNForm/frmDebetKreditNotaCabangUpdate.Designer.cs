namespace ISA.Finance.DKNForm
{
    partial class frmDebetKreditNotaCabangUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebetKreditNotaCabangUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKode = new ISA.Controls.CommonTextBox();
            this.txtNama = new ISA.Controls.CommonTextBox();
            this.txtPerk1 = new ISA.Controls.CommonTextBox();
            this.txtPerk2 = new ISA.Controls.CommonTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "No.Perkiraan#1 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "No.Perkiraan#2";
            // 
            // txtKode
            // 
            this.txtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKode.Location = new System.Drawing.Point(202, 43);
            this.txtKode.MaxLength = 4;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(49, 20);
            this.txtKode.TabIndex = 0;
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(202, 93);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(281, 20);
            this.txtNama.TabIndex = 1;
            // 
            // txtPerk1
            // 
            this.txtPerk1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPerk1.Location = new System.Drawing.Point(202, 147);
            this.txtPerk1.Name = "txtPerk1";
            this.txtPerk1.Size = new System.Drawing.Size(120, 20);
            this.txtPerk1.TabIndex = 2;
            // 
            // txtPerk2
            // 
            this.txtPerk2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPerk2.Location = new System.Drawing.Point(202, 191);
            this.txtPerk2.Name = "txtPerk2";
            this.txtPerk2.Size = new System.Drawing.Size(120, 20);
            this.txtPerk2.TabIndex = 3;
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(274, 279);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "SAVE";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(402, 279);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDebetKreditNotaCabangUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(514, 341);
            this.Controls.Add(this.txtPerk2);
            this.Controls.Add(this.txtPerk1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "frmDebetKreditNotaCabangUpdate";
            this.Text = "Input Cabang";
            this.Load += new System.EventHandler(this.frmDebetKreditNotaCabangUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDebetKreditNotaCabangUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.txtKode, 0);
            this.Controls.SetChildIndex(this.txtNama, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.txtPerk1, 0);
            this.Controls.SetChildIndex(this.txtPerk2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox txtKode;
        private ISA.Controls.CommonTextBox txtNama;
        private ISA.Controls.CommonTextBox txtPerk1;
        private ISA.Controls.CommonTextBox txtPerk2;
        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
