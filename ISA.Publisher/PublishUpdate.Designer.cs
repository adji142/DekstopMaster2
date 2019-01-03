namespace ISA.Publisher
{
    partial class PublishUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishUpdate));
            this.cmdPublish = new ISA.Controls.CommandButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdPublish
            // 
            this.cmdPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPublish.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdPublish.BackgroundImage")));
            this.cmdPublish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdPublish.CommandType = ISA.Controls.CommandButton.enCommandType.None;
            this.cmdPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdPublish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPublish.Location = new System.Drawing.Point(293, 221);
            this.cmdPublish.Name = "cmdPublish";
            this.cmdPublish.Size = new System.Drawing.Size(100, 40);
            this.cmdPublish.TabIndex = 0;
            this.cmdPublish.Text = "PUBLISH";
            this.cmdPublish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPublish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPublish.UseVisualStyleBackColor = true;
            this.cmdPublish.Click += new System.EventHandler(this.cmdPublish_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 190);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // PublishUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 273);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdPublish);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublishUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PublishUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ISA.Controls.CommandButton cmdPublish;
        private System.Windows.Forms.TextBox textBox1;
    }
}