namespace ISA.Toko.Persediaan
    {
    partial class frmRptMasterKosong
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptMasterKosong));
                this.numericTextBox1 = new ISA.Toko.Controls.NumericTextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.commandButton1 = new ISA.Toko.Controls.CommandButton();
                this.cmdNo = new ISA.Toko.Controls.CommandButton();
                this.SuspendLayout();
                // 
                // numericTextBox1
                // 
                this.numericTextBox1.Location = new System.Drawing.Point(162, 72);
                this.numericTextBox1.Name = "numericTextBox1";
                this.numericTextBox1.Size = new System.Drawing.Size(116, 20);
                this.numericTextBox1.TabIndex = 0;
                this.numericTextBox1.Text = "1";
                this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.numericTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox1_KeyPress);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(31, 75);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(105, 14);
                this.label1.TabIndex = 6;
                this.label1.Text = "Banyaknya Form";
                // 
                // commandButton1
                // 
                this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.commandButton1.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.Yes;
                this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
                this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.commandButton1.Location = new System.Drawing.Point(14, 136);
                this.commandButton1.Name = "commandButton1";
                this.commandButton1.Size = new System.Drawing.Size(100, 40);
                this.commandButton1.TabIndex = 1;
                this.commandButton1.Text = "YES";
                this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.commandButton1.UseVisualStyleBackColor = true;
                this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
                // 
                // cmdNo
                // 
                this.cmdNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.cmdNo.CommandType = ISA.Toko.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(314, 136);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 2;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // frmRptMasterKosong
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(426, 192);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.cmdNo);
                this.Controls.Add(this.commandButton1);
                this.Controls.Add(this.numericTextBox1);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmRptMasterKosong";
                this.Text = "Cetak Form Master Kosong";
                this.Title = "Cetak Form Master Kosong";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmRptMasterKosong_Load);
                this.Controls.SetChildIndex(this.numericTextBox1, 0);
                this.Controls.SetChildIndex(this.commandButton1, 0);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Toko.Controls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label1;
        private ISA.Toko.Controls.CommandButton commandButton1;
        private ISA.Toko.Controls.CommandButton cmdNo;
        }
    }
