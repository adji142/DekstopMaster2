namespace ISA.Toko.Master
{
    partial class FrmBudgetPembelianAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBudgetPembelianAddEdit));
            this.dateTextBoxTmt = new ISA.Toko.Controls.DateTextBox();
            this.numericTextBoxBudget = new ISA.Toko.Controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.commandButtonSave = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.SuspendLayout();
            // 
            // dateTextBoxTmt
            // 
            this.dateTextBoxTmt.DateValue = null;
            this.dateTextBoxTmt.Enabled = false;
            this.dateTextBoxTmt.Location = new System.Drawing.Point(111, 73);
            this.dateTextBoxTmt.MaxLength = 10;
            this.dateTextBoxTmt.Name = "dateTextBoxTmt";
            this.dateTextBoxTmt.Size = new System.Drawing.Size(80, 20);
            this.dateTextBoxTmt.TabIndex = 5;
            // 
            // numericTextBoxBudget
            // 
            this.numericTextBoxBudget.Location = new System.Drawing.Point(111, 99);
            this.numericTextBoxBudget.Name = "numericTextBoxBudget";
            this.numericTextBoxBudget.Size = new System.Drawing.Size(80, 20);
            this.numericTextBoxBudget.TabIndex = 6;
            this.numericTextBoxBudget.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "TMT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Budget";
            // 
            // commandButtonSave
            // 
            this.commandButtonSave.CommandType = ISA.Controls.CommandButton.enCommandType.Save;
            this.commandButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("commandButtonSave.Image")));
            this.commandButtonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButtonSave.Location = new System.Drawing.Point(53, 159);
            this.commandButtonSave.Name = "commandButtonSave";
            this.commandButtonSave.Size = new System.Drawing.Size(100, 40);
            this.commandButtonSave.TabIndex = 9;
            this.commandButtonSave.Text = "SAVE";
            this.commandButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButtonSave.UseVisualStyleBackColor = true;
            this.commandButtonSave.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(159, 159);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 10;
            this.commandButton2.Text = "CLOSE";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // FrmBudgetPembelianAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 334);
            this.Controls.Add(this.dateTextBoxTmt);
            this.Controls.Add(this.numericTextBoxBudget);
            this.Controls.Add(this.commandButtonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandButton2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBudgetPembelianAddEdit";
            this.Text = "Budget Pembelian";
            this.Title = "Budget Pembelian";
            this.Load += new System.EventHandler(this.FrmBudgetPembelianAddEdit_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBudgetPembelianAddEdit_FormClosed);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.commandButtonSave, 0);
            this.Controls.SetChildIndex(this.numericTextBoxBudget, 0);
            this.Controls.SetChildIndex(this.dateTextBoxTmt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Toko.Controls.DateTextBox dateTextBoxTmt;
        private ISA.Toko.Controls.NumericTextBox numericTextBoxBudget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ISA.Controls.CommandButton commandButtonSave;
        private ISA.Controls.CommandButton commandButton2;
    }
}