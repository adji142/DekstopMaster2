namespace ISA.Trading.Rekon
{
    partial class frmrekonclosing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrekonclosing));
            this.prosesclosing = new ISA.Trading.Controls.CommandButton();
            this.commandButton1 = new ISA.Trading.Controls.CommandButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPerhatian = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tglclosing = new ISA.Trading.Controls.DateTextBox();
            this.tglclsawal = new ISA.Trading.Controls.DateTextBox();
            this.tglclsakhir = new ISA.Trading.Controls.DateTextBox();
            this.dari = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // prosesclosing
            // 
            this.prosesclosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prosesclosing.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
            this.prosesclosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.prosesclosing.Image = ((System.Drawing.Image)(resources.GetObject("prosesclosing.Image")));
            this.prosesclosing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.prosesclosing.Location = new System.Drawing.Point(483, 452);
            this.prosesclosing.Name = "prosesclosing";
            this.prosesclosing.Size = new System.Drawing.Size(100, 40);
            this.prosesclosing.TabIndex = 5;
            this.prosesclosing.Text = "YES";
            this.prosesclosing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.prosesclosing.UseVisualStyleBackColor = true;
            this.prosesclosing.Click += new System.EventHandler(this.prosesclosing_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(604, 452);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 6;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPerhatian);
            this.panel1.Location = new System.Drawing.Point(31, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 227);
            this.panel1.TabIndex = 8;
            // 
            // lblPerhatian
            // 
            this.lblPerhatian.AutoSize = true;
            this.lblPerhatian.Location = new System.Drawing.Point(3, 5);
            this.lblPerhatian.Name = "lblPerhatian";
            this.lblPerhatian.Size = new System.Drawing.Size(34, 14);
            this.lblPerhatian.TabIndex = 0;
            this.lblPerhatian.Text = "TEXT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tgl. Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tgl. Awal";
            // 
            // tglclosing
            // 
            this.tglclosing.DateValue = null;
            this.tglclosing.Location = new System.Drawing.Point(183, 328);
            this.tglclosing.MaxLength = 10;
            this.tglclosing.Name = "tglclosing";
            this.tglclosing.Size = new System.Drawing.Size(80, 20);
            this.tglclosing.TabIndex = 12;
            this.tglclosing.Validated += new System.EventHandler(this.tglclosing_Validated);
            // 
            // tglclsawal
            // 
            this.tglclsawal.DateValue = null;
            this.tglclsawal.Enabled = false;
            this.tglclsawal.Location = new System.Drawing.Point(183, 296);
            this.tglclsawal.MaxLength = 10;
            this.tglclsawal.Name = "tglclsawal";
            this.tglclsawal.ReadOnly = true;
            this.tglclsawal.Size = new System.Drawing.Size(80, 20);
            this.tglclsawal.TabIndex = 13;
            // 
            // tglclsakhir
            // 
            this.tglclsakhir.DateValue = null;
            this.tglclsakhir.Enabled = false;
            this.tglclsakhir.Location = new System.Drawing.Point(290, 296);
            this.tglclsakhir.MaxLength = 10;
            this.tglclsakhir.Name = "tglclsakhir";
            this.tglclsakhir.ReadOnly = true;
            this.tglclsakhir.Size = new System.Drawing.Size(80, 20);
            this.tglclsakhir.TabIndex = 14;
            // 
            // dari
            // 
            this.dari.AutoSize = true;
            this.dari.Location = new System.Drawing.Point(136, 301);
            this.dari.Name = "dari";
            this.dari.Size = new System.Drawing.Size(28, 14);
            this.dari.TabIndex = 15;
            this.dari.Text = "dari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "s/d";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmrekonclosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 522);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dari);
            this.Controls.Add(this.tglclsakhir);
            this.Controls.Add(this.tglclsawal);
            this.Controls.Add(this.tglclosing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.prosesclosing);
            this.Controls.Add(this.commandButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(752, 560);
            this.MinimumSize = new System.Drawing.Size(752, 560);
            this.Name = "frmrekonclosing";
            this.Text = "Closing Rekon";
            this.Title = "Closing Rekon";
            this.Load += new System.EventHandler(this.frmrekonclosing_Load);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.prosesclosing, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tglclosing, 0);
            this.Controls.SetChildIndex(this.tglclsawal, 0);
            this.Controls.SetChildIndex(this.tglclsakhir, 0);
            this.Controls.SetChildIndex(this.dari, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Trading.Controls.CommandButton prosesclosing;
        private ISA.Trading.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPerhatian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.DateTextBox tglclosing;
        private ISA.Trading.Controls.DateTextBox tglclsawal;
        private ISA.Trading.Controls.DateTextBox tglclsakhir;
        private System.Windows.Forms.Label dari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}