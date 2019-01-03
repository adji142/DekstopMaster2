namespace ISA.Bengkel.Master
{
    partial class FrmInstansi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstansi));
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.customGridView2 = new ISA.Controls.CustomGridView();
            this.RowIDCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.commandButton2 = new ISA.Controls.CommandButton();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaInstansi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeToko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.NamaInstansi,
            this.KodeToko});
            this.customGridView1.Location = new System.Drawing.Point(31, 69);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.ReadOnly = true;
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(664, 170);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 5;
            this.customGridView1.SelectionRowChanged += new System.EventHandler(this.customGridView1_SelectionRowChanged);
            this.customGridView1.Click += new System.EventHandler(this.customGridView1_Click);
            // 
            // customGridView2
            // 
            this.customGridView2.AllowUserToAddRows = false;
            this.customGridView2.AllowUserToDeleteRows = false;
            this.customGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.customGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIDCust,
            this.PlatNo,
            this.NamaCust,
            this.Alamat,
            this.JW,
            this.JS,
            this.JX});
            this.customGridView2.Location = new System.Drawing.Point(31, 245);
            this.customGridView2.MultiSelect = false;
            this.customGridView2.Name = "customGridView2";
            this.customGridView2.ReadOnly = true;
            this.customGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView2.Size = new System.Drawing.Size(664, 150);
            this.customGridView2.StandardTab = true;
            this.customGridView2.TabIndex = 6;
            this.customGridView2.Click += new System.EventHandler(this.customGridView2_Click);
            // 
            // RowIDCust
            // 
            this.RowIDCust.DataPropertyName = "RowIDCust";
            this.RowIDCust.HeaderText = "RowIDCust";
            this.RowIDCust.Name = "RowIDCust";
            this.RowIDCust.ReadOnly = true;
            this.RowIDCust.Visible = false;
            // 
            // PlatNo
            // 
            this.PlatNo.DataPropertyName = "PlatNo";
            this.PlatNo.HeaderText = "PlatNo";
            this.PlatNo.Name = "PlatNo";
            this.PlatNo.ReadOnly = true;
            // 
            // NamaCust
            // 
            this.NamaCust.DataPropertyName = "NamaCust";
            this.NamaCust.HeaderText = "NamaCust";
            this.NamaCust.Name = "NamaCust";
            this.NamaCust.ReadOnly = true;
            // 
            // Alamat
            // 
            this.Alamat.DataPropertyName = "Alamat";
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            // 
            // JW
            // 
            this.JW.DataPropertyName = "JW";
            this.JW.HeaderText = "JW";
            this.JW.Name = "JW";
            this.JW.ReadOnly = true;
            // 
            // JS
            // 
            this.JS.DataPropertyName = "JS";
            this.JS.HeaderText = "JS";
            this.JS.Name = "JS";
            this.JS.ReadOnly = true;
            // 
            // JX
            // 
            this.JX.DataPropertyName = "JX";
            this.JX.HeaderText = "JX";
            this.JX.Name = "JX";
            this.JX.ReadOnly = true;
            // 
            // commandButton1
            // 
            this.commandButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Close;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(595, 416);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.ReportName2 = "";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 7;
            this.commandButton1.Text = "CLOSE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            this.commandButton1.Click += new System.EventHandler(this.commandButton1_Click);
            // 
            // commandButton2
            // 
            this.commandButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commandButton2.CommandType = ISA.Controls.CommandButton.enCommandType.Add;
            this.commandButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandButton2.Image")));
            this.commandButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton2.Location = new System.Drawing.Point(489, 416);
            this.commandButton2.Name = "commandButton2";
            this.commandButton2.ReportName2 = "";
            this.commandButton2.Size = new System.Drawing.Size(100, 40);
            this.commandButton2.TabIndex = 8;
            this.commandButton2.Text = "ADD";
            this.commandButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton2.UseVisualStyleBackColor = true;
            this.commandButton2.Click += new System.EventHandler(this.commandButton2_Click);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Visible = false;
            // 
            // NamaInstansi
            // 
            this.NamaInstansi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaInstansi.DataPropertyName = "NamaInstansi";
            this.NamaInstansi.HeaderText = "Nama Instansi";
            this.NamaInstansi.Name = "NamaInstansi";
            this.NamaInstansi.ReadOnly = true;
            // 
            // KodeToko
            // 
            this.KodeToko.DataPropertyName = "KodeToko";
            this.KodeToko.HeaderText = "KodeToko";
            this.KodeToko.Name = "KodeToko";
            this.KodeToko.ReadOnly = true;
            this.KodeToko.Visible = false;
            // 
            // FrmInstansi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 468);
            this.Controls.Add(this.commandButton2);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.customGridView2);
            this.Controls.Add(this.customGridView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmInstansi";
            this.Text = "Form Master Instansi";
            this.Title = "Form Master Instansi";
            this.Load += new System.EventHandler(this.FrmInstansi_Load);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.customGridView2, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.commandButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.CustomGridView customGridView2;
        private ISA.Controls.CommandButton commandButton1;
        private ISA.Controls.CommandButton commandButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIDCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn JW;
        private System.Windows.Forms.DataGridViewTextBoxColumn JS;
        private System.Windows.Forms.DataGridViewTextBoxColumn JX;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaInstansi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeToko;
    }
}