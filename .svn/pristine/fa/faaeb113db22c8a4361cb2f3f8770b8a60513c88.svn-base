using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Kasir
{
    public partial class frmAttachmentPreview : Form
    {
        public frmAttachmentPreview()
        {
            InitializeComponent();

            
        }


        
        public Image ImageSource { get; set; }

        private void frmAttachmentPreview_Shown(object sender, EventArgs e)
        {
            this.picPreview.Visible = false;
            this.lblMessage.Visible = false;
            try
            {
                if (this.picPreview.Image != null)
                {
                    this.picPreview.Dispose();
                }
                if (ImageSource == null)
                {
                    this.lblMessage.Visible = true;
                }
                else
                {
                    this.picPreview.Image = ImageSource;
                    this.picPreview.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "PREVIEW ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void LoadImage()
        //{
        //    this.picPreview.Visible = false;
        //    this.lblMessage.Visible = false;
        //    try
        //    {
        //        if (this.picPreview.Image != null)
        //        {
        //            this.picPreview.Dispose();
        //        }
        //        if (ImageSource == null)
        //        {
        //            this.lblMessage.Visible = true;
        //        }
        //        else
        //        {
        //            this.picPreview.Image = ImageSource;
        //            this.picPreview.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "PREVIEW ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void frmAttachmentPreview_Load(object sender, EventArgs e)
        {
            //
        }

        private void frmAttachmentPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.picPreview.Image != null)
                {
                    this.picPreview.Image.Dispose();
                }
            }
            catch { }
        }

        private void frmAttachmentPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



    }
}
