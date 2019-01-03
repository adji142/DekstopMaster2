namespace ISA.Finance.Tac
{
    partial class frmSalesEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesEntry));
            this.cmdSave = new ISA.Controls.CommandButton();
            this.cmdClose = new ISA.Controls.CommandButton();
            this.label13 = new System.Windows.Forms.Label();
            this.lookupSales1 = new ISA.Controls.LookupSales();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(231, 270);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 40);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(337, 270);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(157, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "SALES";
            // 
            // lookupSales1
            // 
            this.lookupSales1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSales1.Location = new System.Drawing.Point(207, 97);
            this.lookupSales1.NamaSales = "";
            this.lookupSales1.Name = "lookupSales1";
            this.lookupSales1.RowID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.lookupSales1.SalesID = "[CODE]";
            this.lookupSales1.Size = new System.Drawing.Size(276, 54);
            this.lookupSales1.TabIndex = 0;
            this.lookupSales1.SelectData += new System.EventHandler(this.lookupSales1_SelectData);
            // 
            // frmSalesEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(666, 354);
            this.Controls.Add(this.lookupSales1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSalesEntry";
            this.Text = "Entry Sales";
            this.Title = "Entry Sales";
            this.Load += new System.EventHandler(this.frmSalesEntry_Load);
            this.Controls.SetChildIndex(this.cmdSave, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lookupSales1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSave;
        private ISA.Controls.CommandButton cmdClose;
        private System.Windows.Forms.Label label13;
        private ISA.Controls.LookupSales lookupSales1;
    }
}
