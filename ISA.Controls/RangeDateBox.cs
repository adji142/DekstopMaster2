using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class RangeDateBox : UserControl
    {
        public DateTime? FromDate
        {
            get
            {
                return txtDateFrom.DateValue;
            }

            set
            {
                txtDateFrom.DateValue = value;
            }
        }

        public DateTime? ToDate
        {
            get
            {
                return txtDateTo.DateValue;
            }

            set
            {
                txtDateTo.DateValue = value;
            }
        }

        public new event KeyPressEventHandler KeyPress;

        public RangeDateBox()
        {
            InitializeComponent();          
        }

        private void txtDateFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.KeyPress != null)
                this.KeyPress(sender, e);
        }

        private void txtDateTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.KeyPress != null)
                this.KeyPress(sender, e);
        }

        private void txtDateFrom_Leave(object sender, EventArgs e)
        {
            if (txtDateFrom.Text.Length == 8)
            {
                string result;
                string data = txtDateFrom.Text;
                result = data[0].ToString() + data[1].ToString() + "/" + data[2].ToString() + data[3].ToString() + "/" + data[4].ToString() + data[5].ToString() + data[6].ToString() + data[7].ToString();
                txtDateFrom.Text = result;
            }
        }

        private void txtDateTo_Leave(object sender, EventArgs e)
        {
            if (txtDateTo.Text.Length == 8)
            {
                string result;
                string data = txtDateTo.Text;
                result = data[0].ToString() + data[1].ToString() + "/" + data[2].ToString() + data[3].ToString() + "/" + data[4].ToString() + data[5].ToString() + data[6].ToString() + data[7].ToString();
                txtDateTo.Text = result;
            }
        }




    }
}
