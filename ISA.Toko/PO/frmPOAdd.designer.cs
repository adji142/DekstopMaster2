namespace ISA.Toko.PO
{
    partial class frmPOAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOAdd));
            this.commandButton1 = new ISA.Toko.Controls.CommandButton();
            this.cbSave = new ISA.Toko.Controls.CommandButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCatatan = new System.Windows.Forms.TextBox();
            this.tbGudang = new System.Windows.Forms.TextBox();
            this.tbAdmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.gRevil = new System.Windows.Forms.GroupBox();
            this.dtpAkhir = new System.Windows.Forms.DateTimePicker();
            this.dtpAwal = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbOrder = new System.Windows.Forms.CheckBox();
            this.gRevil.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(261, 410);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 28;
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
            this.cbSave.Location = new System.Drawing.Point(117, 410);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(100, 40);
            this.cbSave.TabIndex = 27;
            this.cbSave.Text = "SAVE";
            this.cbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbSave.UseVisualStyleBackColor = true;
            this.cbSave.Click += new System.EventHandler(this.cbSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "Catatan";
            // 
            // tbCatatan
            // 
            this.tbCatatan.Location = new System.Drawing.Point(117, 274);
            this.tbCatatan.Multiline = true;
            this.tbCatatan.Name = "tbCatatan";
            this.tbCatatan.Size = new System.Drawing.Size(416, 100);
            this.tbCatatan.TabIndex = 25;
            // 
            // tbGudang
            // 
            this.tbGudang.Location = new System.Drawing.Point(117, 248);
            this.tbGudang.Name = "tbGudang";
            this.tbGudang.Size = new System.Drawing.Size(273, 20);
            this.tbGudang.TabIndex = 24;
            this.tbGudang.TextChanged += new System.EventHandler(this.tbGudang_TextChanged);
            // 
            // tbAdmin
            // 
            this.tbAdmin.Location = new System.Drawing.Point(117, 222);
            this.tbAdmin.Name = "tbAdmin";
            this.tbAdmin.Size = new System.Drawing.Size(273, 20);
            this.tbAdmin.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Bagian Gudang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bagian Admin";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(167, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nomor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tanggal";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.CustomFormat = "";
            this.dtpTanggal.Location = new System.Drawing.Point(117, 86);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(167, 20);
            this.dtpTanggal.TabIndex = 42;
            this.dtpTanggal.ValueChanged += new System.EventHandler(this.dtpTanggal_ValueChanged);
            // 
            // gRevil
            // 
            this.gRevil.Controls.Add(this.dtpAkhir);
            this.gRevil.Controls.Add(this.dtpAwal);
            this.gRevil.Controls.Add(this.label7);
            this.gRevil.Controls.Add(this.label6);
            this.gRevil.Location = new System.Drawing.Point(18, 145);
            this.gRevil.Name = "gRevil";
            this.gRevil.Size = new System.Drawing.Size(515, 59);
            this.gRevil.TabIndex = 43;
            this.gRevil.TabStop = false;
            this.gRevil.Text = "Refill";
            // 
            // dtpAkhir
            // 
            this.dtpAkhir.Location = new System.Drawing.Point(317, 23);
            this.dtpAkhir.Name = "dtpAkhir";
            this.dtpAkhir.Size = new System.Drawing.Size(192, 20);
            this.dtpAkhir.TabIndex = 5;
            // 
            // dtpAwal
            // 
            this.dtpAwal.Location = new System.Drawing.Point(99, 23);
            this.dtpAwal.Name = "dtpAwal";
            this.dtpAwal.Size = new System.Drawing.Size(175, 20);
            this.dtpAwal.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 14);
            this.label7.TabIndex = 2;
            this.label7.Text = "s/d";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tanggal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(391, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 14);
            this.label8.TabIndex = 46;
            this.label8.Text = "Order";
            // 
            // cbOrder
            // 
            this.cbOrder.AutoSize = true;
            this.cbOrder.Location = new System.Drawing.Point(437, 88);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(90, 18);
            this.cbOrder.TabIndex = 47;
            this.cbOrder.TabStop = false;
            this.cbOrder.Text = "Order ke 00";
            this.cbOrder.UseVisualStyleBackColor = true;
            this.cbOrder.CheckedChanged += new System.EventHandler(this.cbOrder_CheckedChanged);
            // 
            // frmPOAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 499);
            this.Controls.Add(this.cbOrder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.tbCatatan);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.gRevil);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGudang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPOAdd";
            this.Text = "Tambah PO";
            this.Title = "Tambah PO";
            this.Load += new System.EventHandler(this.frmPOAdd_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbAdmin, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbGudang, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbSave, 0);
            this.Controls.SetChildIndex(this.gRevil, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.tbCatatan, 0);
            this.Controls.SetChildIndex(this.dtpTanggal, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cbOrder, 0);
            this.gRevil.ResumeLayout(false);
            this.gRevil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton cbSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCatatan;
        private System.Windows.Forms.TextBox tbGudang;
        private System.Windows.Forms.TextBox tbAdmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.GroupBox gRevil;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAwal;
        private System.Windows.Forms.DateTimePicker dtpAkhir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbOrder;
    }
}