namespace ISA.Toko.Master
{
    partial class frmArmadaKirimUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArmadaKirimUpdate));
            this.txtKodeArmada = new ISA.Toko.Controls.CommonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKendaraan = new ISA.Toko.Controls.CommonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomorPolisi = new ISA.Toko.Controls.CommonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTripMeterKM = new ISA.Controls.NumericTextBox();
            this.btnSave = new ISA.Toko.Controls.CommandButton();
            this.btnClose = new ISA.Toko.Controls.CommandButton();
            this.txtKMPerLiter = new ISA.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // txtKodeArmada
            // 
            this.txtKodeArmada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeArmada.Location = new System.Drawing.Point(123, 78);
            this.txtKodeArmada.Name = "txtKodeArmada";
            this.txtKodeArmada.ReadOnly = true;
            this.txtKodeArmada.Size = new System.Drawing.Size(154, 20);
            this.txtKodeArmada.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "KodeArmada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kendaraan";
            // 
            // txtKendaraan
            // 
            this.txtKendaraan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKendaraan.Location = new System.Drawing.Point(123, 113);
            this.txtKendaraan.Name = "txtKendaraan";
            this.txtKendaraan.Size = new System.Drawing.Size(154, 20);
            this.txtKendaraan.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "NomorPolisi";
            // 
            // txtNomorPolisi
            // 
            this.txtNomorPolisi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomorPolisi.Location = new System.Drawing.Point(123, 150);
            this.txtNomorPolisi.Name = "txtNomorPolisi";
            this.txtNomorPolisi.Size = new System.Drawing.Size(154, 20);
            this.txtNomorPolisi.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "TripMeterKM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "KMPerLiter";
            // 
            // txtTripMeterKM
            // 
            this.txtTripMeterKM.Location = new System.Drawing.Point(123, 187);
            this.txtTripMeterKM.Name = "txtTripMeterKM";
            this.txtTripMeterKM.Size = new System.Drawing.Size(154, 20);
            this.txtTripMeterKM.TabIndex = 17;
            this.txtTripMeterKM.Text = "0";
            this.txtTripMeterKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(31, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(576, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtKMPerLiter
            // 
            this.txtKMPerLiter.Location = new System.Drawing.Point(123, 227);
            this.txtKMPerLiter.Name = "txtKMPerLiter";
            this.txtKMPerLiter.Size = new System.Drawing.Size(154, 20);
            this.txtKMPerLiter.TabIndex = 18;
            this.txtKMPerLiter.Text = "0";
            this.txtKMPerLiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmArmadaKirimUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.txtKMPerLiter);
            this.Controls.Add(this.txtTripMeterKM);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomorPolisi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKendaraan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKodeArmada);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmArmadaKirimUpdate";
            this.Text = "Armada Kirim Insert";
            this.Title = "Armada Kirim Insert";
            this.Load += new System.EventHandler(this.frmArmadaKirimUpdate_Load);
            this.Controls.SetChildIndex(this.txtKodeArmada, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtKendaraan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNomorPolisi, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.txtTripMeterKM, 0);
            this.Controls.SetChildIndex(this.txtKMPerLiter, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommonTextBox txtKodeArmada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.CommonTextBox txtKendaraan;
        private System.Windows.Forms.Label label3;
        private ISA.Toko.Controls.CommonTextBox txtNomorPolisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ISA.Toko.Controls.CommandButton btnSave;
        private ISA.Toko.Controls.CommandButton btnClose;
        private ISA.Controls.NumericTextBox txtTripMeterKM;
        private ISA.Controls.NumericTextBox txtKMPerLiter;
    }
}