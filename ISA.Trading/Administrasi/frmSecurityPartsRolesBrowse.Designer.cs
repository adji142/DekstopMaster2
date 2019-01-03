namespace ISA.Trading.Administrasi
{
    partial class frmSecurityPartsRolesBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityPartsRolesBrowse));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPart = new ISA.Trading.Controls.CommonTextBox();
            this.cmdClose = new ISA.Trading.Controls.CommandButton();
            this.dataGridView1 = new ISA.Trading.Controls.CustomGridView();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lookupSecurityRoles1 = new ISA.Trading.Controls.LookupSecurityRoles();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAdd = new ISA.Trading.Controls.CommandButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Part ID";
            // 
            // txtPart
            // 
            this.txtPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPart.Location = new System.Drawing.Point(98, 16);
            this.txtPart.Name = "txtPart";
            this.txtPart.ReadOnly = true;
            this.txtPart.Size = new System.Drawing.Size(130, 20);
            this.txtPart.TabIndex = 0;
            this.txtPart.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Close;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(601, 423);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 40);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "CLOSE";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.RoleID,
            this.PartID,
            this.RoleName,
            this.cmdDelete});
            this.dataGridView1.Location = new System.Drawing.Point(9, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(689, 195);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.HeaderText = "RowID";
            this.RowID.Name = "RowID";
            // 
            // RoleID
            // 
            this.RoleID.DataPropertyName = "RoleID";
            this.RoleID.HeaderText = "Role ID";
            this.RoleID.Name = "RoleID";
            // 
            // PartID
            // 
            this.PartID.DataPropertyName = "PartID";
            this.PartID.HeaderText = "Part ID";
            this.PartID.Name = "PartID";
            // 
            // RoleName
            // 
            this.RoleName.DataPropertyName = "RoleName";
            this.RoleName.HeaderText = "Role Name";
            this.RoleName.Name = "RoleName";
            this.RoleName.Width = 300;
            // 
            // cmdDelete
            // 
            this.cmdDelete.HeaderText = "";
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmdDelete.Width = 23;
            // 
            // lookupSecurityRoles1
            // 
            this.lookupSecurityRoles1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lookupSecurityRoles1.Location = new System.Drawing.Point(95, 39);
            this.lookupSecurityRoles1.Name = "lookupSecurityRoles1";
            this.lookupSecurityRoles1.RoleID = "[CODE]";
            this.lookupSecurityRoles1.RoleName = "";
            this.lookupSecurityRoles1.RoleType = ISA.Trading.Controls.LookupSecurityRoles.enRoleType.Business;
            this.lookupSecurityRoles1.Size = new System.Drawing.Size(336, 50);
            this.lookupSecurityRoles1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lookupSecurityRoles1);
            this.groupBox1.Controls.Add(this.txtPart);
            this.groupBox1.Location = new System.Drawing.Point(9, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 135);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.CommandType = ISA.Trading.Controls.CommandButton.enCommandType.Add;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(243, 89);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(100, 40);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "ADD";
            this.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "Role";
            // 
            // frmSecurityPartsRolesBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(713, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmSecurityPartsRolesBrowse";
            this.Text = "Security Parts - Business Roles";
            this.Title = "Security Parts - Business Roles";
            this.Load += new System.EventHandler(this.frmSecurityPartsUpdateRoles_Load);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ISA.Trading.Controls.CommonTextBox txtPart;
        private ISA.Trading.Controls.CommandButton cmdClose;
        private ISA.Trading.Controls.CustomGridView dataGridView1;
        private ISA.Trading.Controls.LookupSecurityRoles lookupSecurityRoles1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private ISA.Trading.Controls.CommandButton cmdAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewImageColumn cmdDelete;
    }
}
