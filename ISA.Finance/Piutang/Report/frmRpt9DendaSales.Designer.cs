namespace ISA.Finance.Piutang.Report
{
    partial class frmRpt9DendaSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt9DendaSales));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.txtSpare = new ISA.Controls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPinalty = new ISA.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tgl. Nota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "Sales";
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(347, 289);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 6;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Yes;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(12, 289);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 5;
            this.commandButton1.Text = "YES";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 40;
            this.label6.Text = "Urut ";
            // 
            // cboSort
            // 
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Location = new System.Drawing.Point(124, 175);
            this.cboSort.Name = "cboSort";
            this.cboSort.Size = new System.Drawing.Size(228, 22);
            this.cboSort.TabIndex = 4;
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(89, 83);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 1;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(124, 19);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 0;
            // 
            // txtSpare
            // 
            this.txtSpare.Location = new System.Drawing.Point(124, 115);
            this.txtSpare.MaxLength = 2;
            this.txtSpare.Name = "txtSpare";
            this.txtSpare.Size = new System.Drawing.Size(100, 20);
            this.txtSpare.TabIndex = 2;
            this.txtSpare.Text = "0";
            this.txtSpare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "Spare Waktu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "Denda PerBulan";
            // 
            // txtPinalty
            // 
            this.txtPinalty.Location = new System.Drawing.Point(124, 145);
            this.txtPinalty.MaxLength = 2;
            this.txtPinalty.Name = "txtPinalty";
            this.txtPinalty.Size = new System.Drawing.Size(100, 20);
            this.txtPinalty.TabIndex = 3;
            this.txtPinalty.Text = "0";
            this.txtPinalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmRpt9DendaSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(459, 341);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPinalty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSpare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboSort);
            this.Controls.Add(this.rangeDateBox1);
            this.Controls.Add(this.lookupSales1);
            this.MaximizeBox = false;
            this.Name = "frmRpt9DendaSales";
            this.Text = "Lap. Denda Sales";
            this.Load += new System.EventHandler(this.frmRpt9DendaSales_Load);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.cboSort, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSpare, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPinalty, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ISA.Controls.CommandButton commandButton2;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSort;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.LookupSales lookupSales1;
        private ISA.Controls.NumericTextBox txtSpare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ISA.Controls.NumericTextBox txtPinalty;
    }
}
