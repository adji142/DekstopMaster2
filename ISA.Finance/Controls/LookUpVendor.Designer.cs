namespace ISA.Finance.Controls
{
    partial class LookUpVendor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookUpVendor));
            this.cmdSearch = new ISA.Controls.CommandButton();
            this.txtNamaVendor = new System.Windows.Forms.TextBox();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.CommandType = ISA.Controls.CommandButton.enCommandType.SearchS;
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cmdSearch.Location = new System.Drawing.Point(347, 17);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(80, 23);
            this.cmdSearch.TabIndex = 6;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtNamaVendor
            // 
            this.txtNamaVendor.Location = new System.Drawing.Point(114, 19);
            this.txtNamaVendor.Name = "txtNamaVendor";
            this.txtNamaVendor.Size = new System.Drawing.Size(221, 20);
            this.txtNamaVendor.TabIndex = 3;
            // 
            // lblVendorID
            // 
            this.lblVendorID.AutoSize = true;
            this.lblVendorID.Location = new System.Drawing.Point(111, 54);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(62, 13);
            this.lblVendorID.TabIndex = 7;
            this.lblVendorID.Text = "lblVendorID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kode Pemasok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nama Pemasok";
            // 
            // LookUpVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtNamaVendor);
            this.Controls.Add(this.lblVendorID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LookUpVendor";
            this.Size = new System.Drawing.Size(477, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdSearch;
        public System.Windows.Forms.TextBox txtNamaVendor;
        private System.Windows.Forms.Label lblVendorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
