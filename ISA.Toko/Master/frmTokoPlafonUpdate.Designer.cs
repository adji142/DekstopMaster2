namespace ISA.Toko.Master
{
    partial class frmTokoPlafonUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTokoPlafonUpdate));
            this.txtWilID = new ISA.Toko.Controls.CommonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCatatan = new ISA.Toko.Controls.CommonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlafon = new ISA.Toko.Controls.NumericTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dsLaporanBarang1 = new ISA.Toko.DataTemplates.dsLaporanBarang();
            this.cmdCLOSE = new ISA.Toko.Controls.CommandButton();
            this.cmdSAVE = new ISA.Toko.Controls.CommandButton();
            this.txtdateplafon = new ISA.Toko.Controls.DateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLaporanBarang1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWilID
            // 
            this.txtWilID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWilID.Location = new System.Drawing.Point(143, 13);
            this.txtWilID.MaxLength = 7;
            this.txtWilID.Name = "txtWilID";
            this.txtWilID.Size = new System.Drawing.Size(95, 20);
            this.txtWilID.TabIndex = 2;
            this.txtWilID.Visible = false;
            this.txtWilID.TextChanged += new System.EventHandler(this.txtWilID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "Wilayah ID";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Plafon";
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Location = new System.Drawing.Point(156, 74);
            this.txtCatatan.MaxLength = 73;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(453, 20);
            this.txtCatatan.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "Keterangan";
            // 
            // txtPlafon
            // 
            this.txtPlafon.Location = new System.Drawing.Point(156, 45);
            this.txtPlafon.MaxLength = 13;
            this.txtPlafon.Name = "txtPlafon";
            this.txtPlafon.Size = new System.Drawing.Size(159, 20);
            this.txtPlafon.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dsLaporanBarang1
            // 
            this.dsLaporanBarang1.DataSetName = "dsLaporanBarang";
            this.dsLaporanBarang1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmdCLOSE
            // 
            this.cmdCLOSE.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Close;
            this.cmdCLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdCLOSE.Image = ((System.Drawing.Image)(resources.GetObject("cmdCLOSE.Image")));
            this.cmdCLOSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCLOSE.Location = new System.Drawing.Point(292, 116);
            this.cmdCLOSE.Name = "cmdCLOSE";
            this.cmdCLOSE.Size = new System.Drawing.Size(100, 40);
            this.cmdCLOSE.TabIndex = 5;
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
            this.cmdSAVE.Location = new System.Drawing.Point(156, 116);
            this.cmdSAVE.Name = "cmdSAVE";
            this.cmdSAVE.Size = new System.Drawing.Size(100, 40);
            this.cmdSAVE.TabIndex = 4;
            this.cmdSAVE.Text = "SAVE";
            this.cmdSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSAVE.UseVisualStyleBackColor = true;
            this.cmdSAVE.Click += new System.EventHandler(this.cmdSAVE_Click);
            // 
            // txtdateplafon
            // 
            this.txtdateplafon.DateValue = null;
            this.txtdateplafon.Enabled = false;
            this.txtdateplafon.Location = new System.Drawing.Point(156, 17);
            this.txtdateplafon.MaxLength = 10;
            this.txtdateplafon.Name = "txtdateplafon";
            this.txtdateplafon.Size = new System.Drawing.Size(159, 20);
            this.txtdateplafon.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tanggal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWilID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(444, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 16);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saya tidak kelihatan";
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtdateplafon);
            this.groupBox2.Controls.Add(this.txtCatatan);
            this.groupBox2.Controls.Add(this.cmdCLOSE);
            this.groupBox2.Controls.Add(this.txtPlafon);
            this.groupBox2.Controls.Add(this.cmdSAVE);
            this.groupBox2.Location = new System.Drawing.Point(31, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 171);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // frmTokoPlafonUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(712, 241);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormID = "SC1403";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTokoPlafonUpdate";
            this.Text = "SC1403 - Plafon";
            this.Title = "Plafon";
            this.Load += new System.EventHandler(this.frmTokoPlafonUpdate_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTokoPlafonUpdate_FormClosed);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLaporanBarang1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.CommonTextBox txtWilID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ISA.Toko.Controls.CommonTextBox txtCatatan;
        private System.Windows.Forms.Label label9;
        private ISA.Toko.Controls.NumericTextBox txtPlafon;
        private ISA.Toko.Controls.CommandButton cmdCLOSE;
        private ISA.Toko.Controls.CommandButton cmdSAVE;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ISA.Toko.DataTemplates.dsLaporanBarang dsLaporanBarang1;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.DateTextBox txtdateplafon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
