namespace ISA.Toko.Ekspedisi
{
    partial class frmCetakPackingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCetakPackingList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbShift2 = new System.Windows.Forms.RadioButton();
            this.rdbShift1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbTunai = new System.Windows.Forms.RadioButton();
            this.rdbKredit = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new ISA.Toko.Controls.CommandButton();
            this.cmdYes = new ISA.Toko.Controls.CommandButton();
            this.txtKeterangan = new ISA.Toko.Controls.CommonTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbShift2);
            this.groupBox1.Controls.Add(this.rdbShift1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdbShift2
            // 
            resources.ApplyResources(this.rdbShift2, "rdbShift2");
            this.rdbShift2.Name = "rdbShift2";
            this.rdbShift2.TabStop = true;
            this.rdbShift2.UseVisualStyleBackColor = true;
            // 
            // rdbShift1
            // 
            resources.ApplyResources(this.rdbShift1, "rdbShift1");
            this.rdbShift1.Name = "rdbShift1";
            this.rdbShift1.TabStop = true;
            this.rdbShift1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbManual);
            this.groupBox2.Controls.Add(this.rdbAuto);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdbManual
            // 
            resources.ApplyResources(this.rdbManual, "rdbManual");
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.TabStop = true;
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // rdbAuto
            // 
            resources.ApplyResources(this.rdbAuto, "rdbAuto");
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.TabStop = true;
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbTunai);
            this.groupBox3.Controls.Add(this.rdbKredit);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rdbTunai
            // 
            resources.ApplyResources(this.rdbTunai, "rdbTunai");
            this.rdbTunai.Name = "rdbTunai";
            this.rdbTunai.TabStop = true;
            this.rdbTunai.UseVisualStyleBackColor = true;
            // 
            // rdbKredit
            // 
            resources.ApplyResources(this.rdbKredit, "rdbKredit");
            this.rdbKredit.Name = "rdbKredit";
            this.rdbKredit.TabStop = true;
            this.rdbKredit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdYes
            // 
            this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
            resources.ApplyResources(this.cmdYes, "cmdYes");
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtKeterangan, "txtKeterangan");
            this.txtKeterangan.Name = "txtKeterangan";
            // 
            // frmCetakPackingList
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtKeterangan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCetakPackingList";
            this.Title = "Cetak Packing List";
            this.Load += new System.EventHandler(this.frmCetakPackingList_Load);
            this.Controls.SetChildIndex(this.txtKeterangan, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cmdYes, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbShift2;
        private System.Windows.Forms.RadioButton rdbShift1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbTunai;
        private System.Windows.Forms.RadioButton rdbKredit;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton cmdClose;
        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommonTextBox txtKeterangan;
    }
}
