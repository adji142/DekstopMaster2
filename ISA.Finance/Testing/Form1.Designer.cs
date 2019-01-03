namespace ISA.Finance.Testing
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.customGridView1 = new ISA.Controls.CustomGridView();
            this.colNoPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaPerkiraan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTextBox1 = new ISA.Controls.DateTextBox();
            this.rangeDateBox1 = new ISA.Controls.RangeDateBox();
            this.lookupGudang1 = new ISA.Controls.LookupGudang();
            this.commandButton1 = new ISA.Controls.CommandButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // customGridView1
            // 
            this.customGridView1.AllowUserToAddRows = false;
            this.customGridView1.AllowUserToDeleteRows = false;
            this.customGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoPerkiraan,
            this.colNamaPerkiraan});
            this.customGridView1.Location = new System.Drawing.Point(28, 109);
            this.customGridView1.MultiSelect = false;
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.customGridView1.Size = new System.Drawing.Size(369, 150);
            this.customGridView1.StandardTab = true;
            this.customGridView1.TabIndex = 4;
            // 
            // colNoPerkiraan
            // 
            this.colNoPerkiraan.DataPropertyName = "NoPerkiraan";
            this.colNoPerkiraan.HeaderText = "No Perkiraan";
            this.colNoPerkiraan.Name = "colNoPerkiraan";
            // 
            // colNamaPerkiraan
            // 
            this.colNamaPerkiraan.DataPropertyName = "Nama Perkiraan";
            this.colNamaPerkiraan.HeaderText = "Perkiraan";
            this.colNamaPerkiraan.Name = "colNamaPerkiraan";
            // 
            // dateTextBox1
            // 
            this.dateTextBox1.DateValue = null;
            this.dateTextBox1.Location = new System.Drawing.Point(83, 22);
            this.dateTextBox1.MaxLength = 10;
            this.dateTextBox1.Name = "dateTextBox1";
            this.dateTextBox1.Size = new System.Drawing.Size(80, 20);
            this.dateTextBox1.TabIndex = 5;
            this.dateTextBox1.TextChanged += new System.EventHandler(this.dateTextBox1_TextChanged);
            // 
            // rangeDateBox1
            // 
            this.rangeDateBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.rangeDateBox1.FromDate = null;
            this.rangeDateBox1.Location = new System.Drawing.Point(169, 20);
            this.rangeDateBox1.Name = "rangeDateBox1";
            this.rangeDateBox1.Size = new System.Drawing.Size(257, 22);
            this.rangeDateBox1.TabIndex = 6;
            this.rangeDateBox1.ToDate = null;
            // 
            // lookupGudang1
            // 
            this.lookupGudang1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupGudang1.GudangID = "[CODE]";
            this.lookupGudang1.KodeCabang = null;
            this.lookupGudang1.Location = new System.Drawing.Point(12, 285);
            this.lookupGudang1.NamaGudang = "";
            this.lookupGudang1.Name = "lookupGudang1";
            this.lookupGudang1.Size = new System.Drawing.Size(276, 54);
            this.lookupGudang1.TabIndex = 7;
            // 
            // commandButton1
            // 
            this.commandButton1.CommandType = ISA.Controls.CommandButton.enCommandType.Delete;
            this.commandButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.commandButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandButton1.Image")));
            this.commandButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandButton1.Location = new System.Drawing.Point(418, 268);
            this.commandButton1.Name = "commandButton1";
            this.commandButton1.Size = new System.Drawing.Size(100, 40);
            this.commandButton1.TabIndex = 8;
            this.commandButton1.Text = "DELETE";
            this.commandButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(418, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "nm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(710, 342);
            this.Controls.Add(this.lookupGudang1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customGridView1);
            this.Controls.Add(this.commandButton1);
            this.Controls.Add(this.dateTextBox1);
            this.Controls.Add(this.rangeDateBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.rangeDateBox1, 0);
            this.Controls.SetChildIndex(this.dateTextBox1, 0);
            this.Controls.SetChildIndex(this.commandButton1, 0);
            this.Controls.SetChildIndex(this.customGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lookupGudang1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Controls.CustomGridView customGridView1;
        private ISA.Controls.DateTextBox dateTextBox1;
        private ISA.Controls.RangeDateBox rangeDateBox1;
        private ISA.Controls.LookupGudang lookupGudang1;
        private ISA.Controls.CommandButton commandButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoPerkiraan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaPerkiraan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
