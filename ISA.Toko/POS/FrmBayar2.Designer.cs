namespace ISA.Toko.POS.Bayar
{
    partial class FrmBayar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBayar));
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.commandButton3 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.CmdPrint = new ISA.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.LblNota = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TxtNeto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LblNoDO_ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Charge";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(413, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "Masa Berlaku";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMOR NOTA";
            this.label1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "Nomor Kartu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(413, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 14);
            this.label12.TabIndex = 17;
            this.label12.Text = "Nama Pemegang";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(413, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 14);
            this.label13.TabIndex = 16;
            this.label13.Text = "Nama Kartu";
            // 
            // commandButton3
            // 
            this.commandButton3.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton3.Image = ((System.Drawing.Image)(resources.GetObject("commandButton3.Image")));
            this.commandButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton3.Location = new System.Drawing.Point(470, 276);
            this.commandButton3.Name = "commandButton3";
            this.commandButton3.Size = new System.Drawing.Size(100, 40);
            this.commandButton3.TabIndex = 2;
            this.commandButton3.Text = "CLOSE";
            this.commandButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton3.UseVisualStyleBackColor = true;
            this.commandButton3.Click += new System.EventHandler(this.commandButton3_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(324, 276);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 1;
            this.commandButton2.Text = "SAVE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // CmdPrint
            // 
            this.CmdPrint.CommandType = ISA.Controls.CommandButton.enCommandType.Print;
            this.CmdPrint.Enabled = false;
            this.CmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("CmdPrint.Image")));
            this.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdPrint.Location = new System.Drawing.Point(188, 276);
            this.CmdPrint.Name = "CmdPrint";
            this.CmdPrint.Size = new System.Drawing.Size(100, 40);
            this.CmdPrint.TabIndex = 0;
            this.CmdPrint.Text = "PRINT";
            this.CmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CmdPrint.UseVisualStyleBackColor = true;
            this.CmdPrint.Click += new System.EventHandler(this.CmdPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "PEMBAYARAN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "Uang Kembali";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nilai Kredit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Credit Card";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cash / Tunai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Jumlah Neto";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(567, 218);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(152, 20);
            this.textBox6.TabIndex = 10;
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(567, 180);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(152, 20);
            this.textBox7.TabIndex = 9;
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(567, 100);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(152, 20);
            this.textBox9.TabIndex = 7;
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(567, 139);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(152, 20);
            this.textBox8.TabIndex = 8;
            // 
            // LblNota
            // 
            this.LblNota.AutoSize = true;
            this.LblNota.Location = new System.Drawing.Point(185, 337);
            this.LblNota.Name = "LblNota";
            this.LblNota.Size = new System.Drawing.Size(48, 14);
            this.LblNota.TabIndex = 5;
            this.LblNota.Text = "LblNota";
            this.LblNota.Visible = false;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(567, 66);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(152, 20);
            this.textBox10.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(185, 218);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(152, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(185, 180);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(152, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(185, 139);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(185, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 20);
            this.textBox2.TabIndex = 2;
            // 
            // TxtNeto
            // 
            this.TxtNeto.Enabled = false;
            this.TxtNeto.Location = new System.Drawing.Point(185, 66);
            this.TxtNeto.Name = "TxtNeto";
            this.TxtNeto.Size = new System.Drawing.Size(152, 20);
            this.TxtNeto.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(467, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "KREDIT CARD";
            // 
            // LblNoDO_
            // 
            this.LblNoDO_.AutoSize = true;
            this.LblNoDO_.Location = new System.Drawing.Point(187, 352);
            this.LblNoDO_.Name = "LblNoDO_";
            this.LblNoDO_.Size = new System.Drawing.Size(45, 14);
            this.LblNoDO_.TabIndex = 12;
            this.LblNoDO_.Text = "label14";
            this.LblNoDO_.Visible = false;
            // 
            // FrmBayar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 366);
            this.Controls.Add(this.commandButton3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.CmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblNoDO_);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblNota);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNeto);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox5);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBayar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.Title = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmBayar2_Load);
            this.Controls.SetChildIndex(this.textBox5, 0);
            this.Controls.SetChildIndex(this.textBox9, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.textBox8, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.textBox7, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox6, 0);
            this.Controls.SetChildIndex(this.TxtNeto, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBox10, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.LblNota, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.LblNoDO_, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.CmdPrint, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.commandButton3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.CommandButton commandButton3;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton CmdPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label LblNota;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox TxtNeto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblNoDO_;
    }
}