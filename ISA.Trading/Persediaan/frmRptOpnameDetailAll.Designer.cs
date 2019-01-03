namespace ISA.Trading.Persediaan
    {
    partial class frmRptOpnameDetailAll
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing&&(components!=null))
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOpnameDetailAll));
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.label1 = new System.Windows.Forms.Label();
                this.rdbNama = new System.Windows.Forms.RadioButton();
                this.rdbRak = new System.Windows.Forms.RadioButton();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(9, 186);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 2;
                this.cmdYes.Text = "YES";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(277, 186);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 3;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(28, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(35, 14);
                this.label1.TabIndex = 7;
                this.label1.Text = "Urut";
                // 
                // rdbNama
                // 
                this.rdbNama.AutoSize = true;
                this.rdbNama.Checked = true;
                this.rdbNama.Location = new System.Drawing.Point(73, 67);
                this.rdbNama.Name = "rdbNama";
                this.rdbNama.Size = new System.Drawing.Size(88, 18);
                this.rdbNama.TabIndex = 0;
                this.rdbNama.TabStop = true;
                this.rdbNama.Text = "Nama Stok";
                this.rdbNama.UseVisualStyleBackColor = true;
                // 
                // rdbRak
                // 
                this.rdbRak.AutoSize = true;
                this.rdbRak.Location = new System.Drawing.Point(73, 91);
                this.rdbRak.Name = "rdbRak";
                this.rdbRak.Size = new System.Drawing.Size(81, 18);
                this.rdbRak.TabIndex = 1;
                this.rdbRak.Text = "Kode Rak";
                this.rdbRak.UseVisualStyleBackColor = true;
                // 
                // frmRptOpnameDetailAll
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(389, 238);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.rdbRak);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.rdbNama);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptOpnameDetailAll";
                this.Text = "Cetak Form Detail Opname All";
                this.Title = "Cetak Form Detail Opname All";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Controls.SetChildIndex(this.rdbNama, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.rdbRak, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbNama;
        private System.Windows.Forms.RadioButton rdbRak;
        }
    }
