namespace ISA.Toko.PO
{
    partial class frmPODetailUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPODetailUpdate));
            this.txtAlasan = new System.Windows.Forms.TextBox();
            this.btProses = new System.Windows.Forms.Button();
            this.tbPO = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSpike = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbFisik = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbQSamp = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.tbBuffer = new System.Windows.Forms.TextBox();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.tbBO = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRefil = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookupStock = new ISA.Toko.Controls.LookupStock();
            this.tbNOPO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cbSave = new ISA.Toko.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // txtAlasan
            // 
            this.txtAlasan.Location = new System.Drawing.Point(177, 290);
            this.txtAlasan.Multiline = true;
            this.txtAlasan.Name = "txtAlasan";
            this.txtAlasan.Size = new System.Drawing.Size(286, 84);
            this.txtAlasan.TabIndex = 64;
            // 
            // btProses
            // 
            this.btProses.Location = new System.Drawing.Point(41, 185);
            this.btProses.Name = "btProses";
            this.btProses.Size = new System.Drawing.Size(87, 25);
            this.btProses.TabIndex = 63;
            this.btProses.Text = "Proses >>";
            this.btProses.UseVisualStyleBackColor = true;
            // 
            // tbPO
            // 
            this.tbPO.Location = new System.Drawing.Point(324, 260);
            this.tbPO.Name = "tbPO";
            this.tbPO.ReadOnly = true;
            this.tbPO.Size = new System.Drawing.Size(66, 20);
            this.tbPO.TabIndex = 60;
            this.tbPO.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(331, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 14);
            this.label15.TabIndex = 59;
            this.label15.Text = "PO";
            // 
            // tbSpike
            // 
            this.tbSpike.Location = new System.Drawing.Point(250, 260);
            this.tbSpike.Name = "tbSpike";
            this.tbSpike.Size = new System.Drawing.Size(66, 20);
            this.tbSpike.TabIndex = 58;
            this.tbSpike.Text = "0";
            this.tbSpike.TextChanged += new System.EventHandler(this.tbSpike_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 14);
            this.label13.TabIndex = 57;
            this.label13.Text = "Spike";
            // 
            // tbFisik
            // 
            this.tbFisik.Location = new System.Drawing.Point(177, 260);
            this.tbFisik.Name = "tbFisik";
            this.tbFisik.Size = new System.Drawing.Size(66, 20);
            this.tbFisik.TabIndex = 56;
            this.tbFisik.Text = "0";
            this.tbFisik.TextChanged += new System.EventHandler(this.tbFisik_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(191, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 14);
            this.label14.TabIndex = 55;
            this.label14.Text = "Fisik";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Alasan Spike";
            // 
            // tbQSamp
            // 
            this.tbQSamp.Location = new System.Drawing.Point(324, 213);
            this.tbQSamp.Name = "tbQSamp";
            this.tbQSamp.ReadOnly = true;
            this.tbQSamp.Size = new System.Drawing.Size(66, 20);
            this.tbQSamp.TabIndex = 53;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(177, 213);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(139, 20);
            this.textBox6.TabIndex = 52;
            // 
            // tbBuffer
            // 
            this.tbBuffer.Location = new System.Drawing.Point(397, 163);
            this.tbBuffer.Name = "tbBuffer";
            this.tbBuffer.ReadOnly = true;
            this.tbBuffer.Size = new System.Drawing.Size(66, 20);
            this.tbBuffer.TabIndex = 51;
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(324, 163);
            this.tbStock.Name = "tbStock";
            this.tbStock.ReadOnly = true;
            this.tbStock.Size = new System.Drawing.Size(66, 20);
            this.tbStock.TabIndex = 50;
            // 
            // tbBO
            // 
            this.tbBO.Location = new System.Drawing.Point(250, 163);
            this.tbBO.Name = "tbBO";
            this.tbBO.ReadOnly = true;
            this.tbBO.Size = new System.Drawing.Size(66, 20);
            this.tbBO.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(269, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 14);
            this.label11.TabIndex = 48;
            this.label11.Text = "B/O";
            // 
            // tbRefil
            // 
            this.tbRefil.Location = new System.Drawing.Point(177, 163);
            this.tbRefil.Name = "tbRefil";
            this.tbRefil.ReadOnly = true;
            this.tbRefil.Size = new System.Drawing.Size(66, 20);
            this.tbRefil.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 14);
            this.label10.TabIndex = 46;
            this.label10.Text = "Refil";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 45;
            this.label9.Text = "Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "Buffer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 43;
            this.label7.Text = "Q.samp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "Tgl.Sampling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Pilih Stock";
            // 
            // lookupStock
            // 
            this.lookupStock.BackColor = System.Drawing.SystemColors.Control;
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(173, 85);
            this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(331, 58);
            this.lookupStock.TabIndex = 40;
            // 
            // tbNOPO
            // 
            this.tbNOPO.Location = new System.Drawing.Point(177, 57);
            this.tbNOPO.Name = "tbNOPO";
            this.tbNOPO.ReadOnly = true;
            this.tbNOPO.Size = new System.Drawing.Size(286, 20);
            this.tbNOPO.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Header Row ID";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(274, 394);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 62;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbSave
            // 
            this.cbSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(150, 394);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 61;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // frmPODetailUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 454);
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNOPO);
            this.Controls.Add(this.txtAlasan);
            this.Controls.Add(this.btProses);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.tbPO);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbSpike);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbFisik);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbQSamp);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.tbBuffer);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.tbBO);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbRefil);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPODetailUpdate";
            this.Text = "frmPODetailUpdate";
            this.Load += new System.EventHandler(this.frmPODetailUpdate_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.tbRefil, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.tbBO, 0);
            this.Controls.SetChildIndex(this.tbStock, 0);
            this.Controls.SetChildIndex(this.tbBuffer, 0);
            this.Controls.SetChildIndex(this.textBox6, 0);
            this.Controls.SetChildIndex(this.tbQSamp, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.tbFisik, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.tbSpike, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.tbPO, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.btProses, 0);
            this.Controls.SetChildIndex(this.txtAlasan, 0);
            this.Controls.SetChildIndex(this.tbNOPO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlasan;
        private System.Windows.Forms.Button btProses;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cbSave;
        private System.Windows.Forms.TextBox tbPO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSpike;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbFisik;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbQSamp;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox tbBuffer;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.TextBox tbBO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRefil;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private System.Windows.Forms.TextBox tbNOPO;
        private System.Windows.Forms.Label label1;
    }
}