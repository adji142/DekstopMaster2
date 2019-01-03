namespace ISA.Toko.Gudang
{
    partial class frmPODetailAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPODetailAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNOPO = new System.Windows.Forms.TextBox();
            this.lookupStock = new ISA.Toko.Controls.LookupStock();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRefil = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbBO = new System.Windows.Forms.TextBox();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.tbBuffer = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.tbQSamp = new System.Windows.Forms.TextBox();
            this.tbAlasanSpike = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSpike = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbFisik = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbPO = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.cbSave = new ISA.Toko.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "No. PO";
            // 
            // tbNOPO
            // 
            this.tbNOPO.Location = new System.Drawing.Point(98, 66);
            this.tbNOPO.Name = "tbNOPO";
            this.tbNOPO.ReadOnly = true;
            this.tbNOPO.Size = new System.Drawing.Size(246, 20);
            this.tbNOPO.TabIndex = 6;
            // 
            // lookupStock
            // 
            this.lookupStock.BarangID = "[CODE]";
            this.lookupStock.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupStock.IsiKoli = 0;
            this.lookupStock.Location = new System.Drawing.Point(98, 92);
            this.lookupStock.LookUpType = ISA.Toko.Controls.LookupStock.EnumLookUpType.Normal;
            this.lookupStock.LPasif = ISA.Toko.Controls.LookupStock.EnumPasif.Aktiv;
            this.lookupStock.NamaStock = "";
            this.lookupStock.Name = "lookupStock";
            this.lookupStock.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupStock.Satuan = null;
            this.lookupStock.Size = new System.Drawing.Size(284, 54);
            this.lookupStock.TabIndex = 7;
            this.lookupStock.Load += new System.EventHandler(this.lookupStock1_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pilih Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tgl.Sampling";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Q.samp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Buffer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Stock";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Refil";
            // 
            // tbRefil
            // 
            this.tbRefil.Location = new System.Drawing.Point(98, 165);
            this.tbRefil.Name = "tbRefil";
            this.tbRefil.ReadOnly = true;
            this.tbRefil.Size = new System.Drawing.Size(57, 20);
            this.tbRefil.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "B/O";
            // 
            // tbBO
            // 
            this.tbBO.Location = new System.Drawing.Point(161, 165);
            this.tbBO.Name = "tbBO";
            this.tbBO.ReadOnly = true;
            this.tbBO.Size = new System.Drawing.Size(57, 20);
            this.tbBO.TabIndex = 19;
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(224, 165);
            this.tbStock.Name = "tbStock";
            this.tbStock.ReadOnly = true;
            this.tbStock.Size = new System.Drawing.Size(57, 20);
            this.tbStock.TabIndex = 20;
            // 
            // tbBuffer
            // 
            this.tbBuffer.Location = new System.Drawing.Point(287, 165);
            this.tbBuffer.Name = "tbBuffer";
            this.tbBuffer.ReadOnly = true;
            this.tbBuffer.Size = new System.Drawing.Size(57, 20);
            this.tbBuffer.TabIndex = 21;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(98, 211);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(120, 20);
            this.textBox6.TabIndex = 22;
            // 
            // tbQSamp
            // 
            this.tbQSamp.Location = new System.Drawing.Point(224, 211);
            this.tbQSamp.Name = "tbQSamp";
            this.tbQSamp.ReadOnly = true;
            this.tbQSamp.Size = new System.Drawing.Size(57, 20);
            this.tbQSamp.TabIndex = 24;
            // 
            // tbAlasanSpike
            // 
            this.tbAlasanSpike.Location = new System.Drawing.Point(98, 281);
            this.tbAlasanSpike.Multiline = true;
            this.tbAlasanSpike.Name = "tbAlasanSpike";
            this.tbAlasanSpike.ReadOnly = true;
            this.tbAlasanSpike.Size = new System.Drawing.Size(246, 79);
            this.tbAlasanSpike.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 14);
            this.label12.TabIndex = 25;
            this.label12.Text = "Alasan Spike";
            // 
            // tbSpike
            // 
            this.tbSpike.Location = new System.Drawing.Point(161, 255);
            this.tbSpike.Name = "tbSpike";
            this.tbSpike.Size = new System.Drawing.Size(57, 20);
            this.tbSpike.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(171, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "Spike";
            // 
            // tbFisik
            // 
            this.tbFisik.Location = new System.Drawing.Point(98, 255);
            this.tbFisik.Name = "tbFisik";
            this.tbFisik.Size = new System.Drawing.Size(57, 20);
            this.tbFisik.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 239);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "Fisik";
            // 
            // tbPO
            // 
            this.tbPO.Location = new System.Drawing.Point(224, 255);
            this.tbPO.Name = "tbPO";
            this.tbPO.Size = new System.Drawing.Size(57, 20);
            this.tbPO.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(230, 238);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 14);
            this.label15.TabIndex = 31;
            this.label15.Text = "PO";
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(244, 366);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 34;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // cbSave
            // 
            this.cbSave.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Save;
            this.cbSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cbSave.Image = ((System.Drawing.Image)(resources.GetObject("cbSave.Image")));
            this.cbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSave.Location = new System.Drawing.Point(138, 366);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 33;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            // 
            // frmPODetailAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 433);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.tbPO);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbSpike);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbFisik);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbAlasanSpike);
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
            this.Controls.Add(this.lookupStock);
            this.Controls.Add(this.tbNOPO);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPODetailAdd";
            this.Text = "PO Detail Add";
            this.Title = "PO Detail Add";
            this.Load += new System.EventHandler(this.frmPODetailAdd_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbNOPO, 0);
            this.Controls.SetChildIndex(this.lookupStock, 0);
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
            this.Controls.SetChildIndex(this.tbAlasanSpike, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.tbFisik, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.tbSpike, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.tbPO, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNOPO;
        private ISA.Toko.Controls.LookupStock lookupStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbRefil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbBO;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.TextBox tbBuffer;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox tbQSamp;
        private System.Windows.Forms.TextBox tbAlasanSpike;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSpike;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbFisik;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbPO;
        private System.Windows.Forms.Label label15;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton cbSave;
    }
}