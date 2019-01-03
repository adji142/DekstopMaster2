namespace ISA.Controls
{
    partial class RangeDateBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateTo = new ISA.Controls.DateTextBox();
            this.txtDateFrom = new ISA.Controls.DateTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "dari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "s/d";
            // 
            // txtDateTo
            // 
            this.txtDateTo.DateValue = null;
            this.txtDateTo.Location = new System.Drawing.Point(154, 0);
            this.txtDateTo.MaxLength = 10;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(81, 20);
            this.txtDateTo.TabIndex = 3;
            this.txtDateTo.Leave += new System.EventHandler(this.txtDateTo_Leave);
            this.txtDateTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDateTo_KeyPress);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.DateValue = null;
            this.txtDateFrom.Location = new System.Drawing.Point(37, 0);
            this.txtDateFrom.MaxLength = 10;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(81, 20);
            this.txtDateFrom.TabIndex = 1;
            this.txtDateFrom.Leave += new System.EventHandler(this.txtDateFrom_Leave);
            this.txtDateFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDateFrom_KeyPress);
            // 
            // RangeDateBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name = "RangeDateBox";
            this.Size = new System.Drawing.Size(257, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DateTextBox txtDateFrom;
        private System.Windows.Forms.Label label2;
        private DateTextBox txtDateTo;
    }
}
