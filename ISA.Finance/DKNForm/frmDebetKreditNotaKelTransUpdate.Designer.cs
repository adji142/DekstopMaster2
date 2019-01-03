namespace ISA.Finance.DKNForm
{
    partial class frmDebetKreditNotaKelTransUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebetKreditNotaKelTransUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbKode = new ISA.Controls.CommonTextBox();
            this.tbKeterangan = new ISA.Controls.CommonTextBox();
            this.tbGroup = new ISA.Controls.CommonTextBox();
            this.tbDN = new ISA.Controls.CommonTextBox();
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Keterangan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "D/N";
            // 
            // tbKode
            // 
            this.tbKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKode.Location = new System.Drawing.Point(131, 25);
            this.tbKode.MaxLength = 1;
            this.tbKode.Name = "tbKode";
            this.tbKode.Size = new System.Drawing.Size(45, 20);
            this.tbKode.TabIndex = 7;
            this.tbKode.Click += new System.EventHandler(this.tbKode_Click);
            this.tbKode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKode_KeyPress);
            // 
            // tbKeterangan
            // 
            this.tbKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbKeterangan.Location = new System.Drawing.Point(131, 58);
            this.tbKeterangan.MaxLength = 40;
            this.tbKeterangan.Name = "tbKeterangan";
            this.tbKeterangan.Size = new System.Drawing.Size(269, 20);
            this.tbKeterangan.TabIndex = 8;
            // 
            // tbGroup
            // 
            this.tbGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbGroup.Location = new System.Drawing.Point(131, 88);
            this.tbGroup.MaxLength = 1;
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(31, 20);
            this.tbGroup.TabIndex = 9;
            this.tbGroup.Click += new System.EventHandler(this.tbGroup_Click);
            this.tbGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGroup_KeyPress);
            // 
            // tbDN
            // 
            this.tbDN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDN.Location = new System.Drawing.Point(131, 116);
            this.tbDN.MaxLength = 1;
            this.tbDN.Name = "tbDN";
            this.tbDN.Size = new System.Drawing.Size(31, 20);
            this.tbDN.TabIndex = 10;
            this.tbDN.Click += new System.EventHandler(this.tbDN_Click);
            this.tbDN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDN_KeyPress);
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(86, 173);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 11;
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
            this.cmdClose.Location = new System.Drawing.Point(192, 173);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 12;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "1=Penambahan        2=Pengurangan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "D=Dagang     N=Non-Dagang";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDebetKreditNotaKelTransUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(403, 226);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tbDN);
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.tbKeterangan);
            this.Controls.Add(this.tbKode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDebetKreditNotaKelTransUpdate";
            this.Text = "DKN Kode Transaksi Update";
            this.Load += new System.EventHandler(this.frmDebetKreditNotaKelTransUpdate_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbKode, 0);
            this.Controls.SetChildIndex(this.tbKeterangan, 0);
            this.Controls.SetChildIndex(this.tbGroup, 0);
            this.Controls.SetChildIndex(this.tbDN, 0);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.CommonTextBox tbKode;
        private ISA.Controls.CommonTextBox tbKeterangan;
        private ISA.Controls.CommonTextBox tbGroup;
        private ISA.Controls.CommonTextBox tbDN;
        private ISA.Controls.CommandButton cmdClose;
        private ISA.Controls.CommandButton cmdSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
