namespace ISA.Finance
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.lblHorizontalMargin = new System.Windows.Forms.Label();
            this.lblVerticalMargin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHorizontalMargin
            // 
            this.lblHorizontalMargin.AutoSize = true;
            this.lblHorizontalMargin.Location = new System.Drawing.Point(25, 9);
            this.lblHorizontalMargin.Name = "lblHorizontalMargin";
            this.lblHorizontalMargin.Size = new System.Drawing.Size(15, 14);
            this.lblHorizontalMargin.TabIndex = 1;
            this.lblHorizontalMargin.Text = "V";
            this.lblHorizontalMargin.Visible = false;
            // 
            // lblVerticalMargin
            // 
            this.lblVerticalMargin.AutoSize = true;
            this.lblVerticalMargin.Location = new System.Drawing.Point(3, 28);
            this.lblVerticalMargin.Name = "lblVerticalMargin";
            this.lblVerticalMargin.Size = new System.Drawing.Size(14, 14);
            this.lblVerticalMargin.TabIndex = 2;
            this.lblVerticalMargin.Text = "H";
            this.lblVerticalMargin.Visible = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.lblVerticalMargin);
            this.Controls.Add(this.lblHorizontalMargin);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHorizontalMargin;
        private System.Windows.Forms.Label lblVerticalMargin;




    }
}