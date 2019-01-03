namespace ISA.Toko.Master
{
    partial class frmKelompokBarangUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKelompokBarangUpdate));
            this.txtSubACC = new ISA.Toko.Controls.CommonTextBox();
            this.txtMainACC = new ISA.Toko.Controls.CommonTextBox();
            this.txtKelompok = new ISA.Toko.Controls.CommonTextBox();
            this.txtKeterangan = new ISA.Toko.Controls.CommonTextBox();
            this.txtKelompokBrgID = new ISA.Toko.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // txtSubACC
            // 
            this.txtSubACC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubACC.Location = new System.Drawing.Point(163, 178);
            this.txtSubACC.MaxLength = 10;
            this.txtSubACC.Name = "txtSubACC";
            this.txtSubACC.Size = new System.Drawing.Size(159, 20);
            this.txtSubACC.TabIndex = 4;
            // 
            // txtMainACC
            // 
            this.txtMainACC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMainACC.Location = new System.Drawing.Point(163, 150);
            this.txtMainACC.MaxLength = 7;
            this.txtMainACC.Name = "txtMainACC";
            this.txtMainACC.Size = new System.Drawing.Size(159, 20);
            this.txtMainACC.TabIndex = 3;
            // 
            // txtKelompok
            // 
            this.txtKelompok.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKelompok.Location = new System.Drawing.Point(163, 122);
            this.txtKelompok.MaxLength = 1;
            this.txtKelompok.Name = "txtKelompok";
            this.txtKelompok.Size = new System.Drawing.Size(46, 20);
            this.txtKelompok.TabIndex = 2;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Location = new System.Drawing.Point(163, 94);
            this.txtKeterangan.MaxLength = 17;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(159, 20);
            this.txtKeterangan.TabIndex = 1;
            // 
            // txtKelompokBrgID
            // 
            this.txtKelompokBrgID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKelompokBrgID.Location = new System.Drawing.Point(163, 66);
            this.txtKelompokBrgID.MaxLength = 3;
            this.txtKelompokBrgID.Name = "txtKelompokBrgID";
            this.txtKelompokBrgID.Size = new System.Drawing.Size(46, 20);
            this.txtKelompokBrgID.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "Main ACC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Kelompok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Keterangan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kelompok Barang ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 43;
            this.label5.Text = "Sub ACC";
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(300, 215);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(117, 43);
            this.cmdCLOSE.TabIndex = 6;
            this.cmdCLOSE.Text = "CLOSE";
            this.cmdCLOSE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCLOSE.UseVisualStyleBackColor = true;
            this.cmdCLOSE.Click += new System.EventHandler(this.cmdCLOSE_Click);
            // 
            // cmdSAVE
            // 
            this.cmdSAVE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cmdSAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSAVE.Image = ((System.Drawing.Image)(resources.GetObject("cmdSAVE.Image")));
            this.cmdSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSAVE.Location = new System.Drawing.Point(163, 215);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(117, 43);
            this.cmdSAVE.TabIndex = 5;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // frmKelompokBarangUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 431);
            this.Controls.Add(this.cmdCLOSE);
            this.Controls.Add(this.cmdSAVE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSubACC);
            this.Controls.Add(this.txtMainACC);
            this.Controls.Add(this.txtKelompok);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtKelompokBrgID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormID = "SC0227";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmKelompokBarangUpdate";
            this.Text = "SC0227 - Kelompok Barang";
            this.Title = "Kelompok Barang";
            this.Load += new System.EventHandler(this.frmKelompokBarangUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKelompokBarangUpdate_FormClosed);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtKelompokBrgID, 0);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.txtKelompok, 0);
            this.Controls.SetChildIndex(this.txtMainACC, 0);
            this.Controls.SetChildIndex(this.txtSubACC, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmdSAVE, 0);
            this.Controls.SetChildIndex(this.cmdCLOSE, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommonTextBox txtSubACC;
        private ISA.Toko.Controls.CommonTextBox txtMainACC;
        private ISA.Toko.Controls.CommonTextBox txtKelompok;
        private ISA.Toko.Controls.CommonTextBox txtKeterangan;
        private ISA.Toko.Controls.CommonTextBox txtKelompokBrgID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
    }
}
