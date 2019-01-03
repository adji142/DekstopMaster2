namespace ISA.Trading.Persediaan
    {
    partial class frmStokOpnameTransfer
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokOpnameTransfer));
                this.dateTextBox1 = new ISA.Trading.Controls.DateTextBox();
                this.cmdYes = new ISA.Trading.Controls.CommandButton();
                this.cmdNo = new ISA.Trading.Controls.CommandButton();
                this.label1 = new System.Windows.Forms.Label();
                this.rbTglopname = new System.Windows.Forms.RadioButton();
                this.rbTgltransfer = new System.Windows.Forms.RadioButton();
                this.label2 = new System.Windows.Forms.Label();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.groupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // dateTextBox1
                // 
                this.dateTextBox1.DateValue = null;
                this.dateTextBox1.Location = new System.Drawing.Point(124, 63);
                this.dateTextBox1.MaxLength = 10;
                this.dateTextBox1.Name = "dateTextBox1";
                this.dateTextBox1.Size = new System.Drawing.Size(115, 20);
                this.dateTextBox1.TabIndex = 0;
                // 
                // cmdYes
                // 
                this.cmdYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.cmdYes.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Yes;
                this.cmdYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdYes.Image = ((System.Drawing.Image)(resources.GetObject("cmdYes.Image")));
                this.cmdYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdYes.Location = new System.Drawing.Point(32, 181);
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
                this.cmdNo.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.No;
                this.cmdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                this.cmdNo.Image = ((System.Drawing.Image)(resources.GetObject("cmdNo.Image")));
                this.cmdNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.cmdNo.Location = new System.Drawing.Point(267, 181);
                this.cmdNo.Name = "cmdNo";
                this.cmdNo.Size = new System.Drawing.Size(100, 40);
                this.cmdNo.TabIndex = 2;
                this.cmdNo.Text = "CANCEL";
                this.cmdNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.cmdNo.UseVisualStyleBackColor = true;
                this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(35, 65);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(74, 14);
                this.label1.TabIndex = 8;
                this.label1.Text = "Tgl Transfer";
                // 
                // rbTglopname
                // 
                this.rbTglopname.AutoSize = true;
                this.rbTglopname.Location = new System.Drawing.Point(10, 14);
                this.rbTglopname.Name = "rbTglopname";
                this.rbTglopname.Size = new System.Drawing.Size(138, 18);
                this.rbTglopname.TabIndex = 9;
                this.rbTglopname.TabStop = true;
                this.rbTglopname.Text = "Per Tanggal Opname";
                this.rbTglopname.UseVisualStyleBackColor = true;
                // 
                // rbTgltransfer
                // 
                this.rbTgltransfer.AutoSize = true;
                this.rbTgltransfer.Location = new System.Drawing.Point(9, 38);
                this.rbTgltransfer.Name = "rbTgltransfer";
                this.rbTgltransfer.Size = new System.Drawing.Size(139, 18);
                this.rbTgltransfer.TabIndex = 10;
                this.rbTgltransfer.TabStop = true;
                this.rbTgltransfer.Text = "Per Tanggal Transfer";
                this.rbTgltransfer.UseVisualStyleBackColor = true;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(35, 97);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(54, 14);
                this.label2.TabIndex = 11;
                this.label2.Text = "Transfer";
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.rbTglopname);
                this.groupBox1.Controls.Add(this.rbTgltransfer);
                this.groupBox1.Location = new System.Drawing.Point(123, 83);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(171, 63);
                this.groupBox1.TabIndex = 12;
                this.groupBox1.TabStop = false;
                // 
                // frmStokOpnameTransfer
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
                this.ClientSize = new System.Drawing.Size(401, 234);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.dateTextBox1);
                this.Controls.Add(this.cmdYes);
                this.Controls.Add(this.groupBox1);
                this.Controls.Add(this.cmdNo);
                this.Location = new System.Drawing.Point(0, 0);
                this.Name = "frmStokOpnameTransfer";
                this.Text = "Transfer Opname";
                this.Title = "Transfer Opname";
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Load += new System.EventHandler(this.frmStokOpnameTransfer_Load);
                this.Controls.SetChildIndex(this.cmdNo, 0);
                this.Controls.SetChildIndex(this.groupBox1, 0);
                this.Controls.SetChildIndex(this.cmdYes, 0);
                this.Controls.SetChildIndex(this.dateTextBox1, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

        #endregion

        private ISA.Trading.Controls.DateTextBox dateTextBox1;
        private ISA.Trading.Controls.CommandButton cmdYes;
        private ISA.Trading.Controls.CommandButton cmdNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTglopname;
        private System.Windows.Forms.RadioButton rbTgltransfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        }
    }
