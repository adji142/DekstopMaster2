namespace ISA.Toko.Persediaan
    {
    partial class frmRptDetailKosong
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptDetailKosong));
                this.cmdYes = new ISA.Toko.Controls.CommandButton();
                this.cmdNo = new ISA.Toko.Controls.CommandButton();
                this.numericTextBox1 = new ISA.Toko.Controls.NumericTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(12, 175);
                this.cmdYes.Name = "cmdYes";
                this.cmdYes.Size = new System.Drawing.Size(100, 40);
                this.cmdYes.TabIndex = 1;
                this.cmdYes.Text = "YES";
                this.cmdYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdYes.UseVisualStyleBackColor = true;
                this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(402, 175);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 2;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // numericTextBox1
                // 
                this.numericTextBox1.Location = new System.Drawing.Point(150, 69);
                this.numericTextBox1.Name = "numericTextBox1";
                this.numericTextBox1.Size = new System.Drawing.Size(116, 20);
                this.numericTextBox1.TabIndex = 0;
                this.numericTextBox1.Text = "0";
                this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.numericTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox1_KeyPress);
                this.numericTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBox1_Validating);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(31, 69);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(105, 14);
                this.label1.TabIndex = 8;
                this.label1.Text = "Banyaknya Form";
                // 
                // frmRptDetailKosong
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(514, 227);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.numericTextBox1);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.cmdYes);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptDetailKosong";
                this.Text = "Cetak Form Detail Kosong";
                this.Title = "Cetak Form Detail Kosong";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptDetailKosong_Load);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.numericTextBox1, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.CommandButton cmdYes;
        private ISA.Toko.Controls.CommandButton cmdNo;
        private ISA.Toko.Controls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label1;
        }
    }
