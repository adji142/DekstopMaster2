using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Controls
{
    public partial class LookupBarcode : UserControl
    {
        public event EventHandler SelectData;
        public LookupBarcode()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            frmLookupBarcode ifrmChild = new frmLookupBarcode(this);
            ifrmChild.Show();
        }

        public void DataGet(string[] dataSend) {
            lKodebarcode.Text = dataSend[1].ToString();
           tbBarcode.Text = dataSend[0].ToString();
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void LookupBarcode_Load(object sender, EventArgs e)
        {

        }

        public string getKodeBarcode
        {
            get
            {
                return lKodebarcode.Text;
            }
            set
            {
                lKodebarcode.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLookupBarcode ifrmChild = new frmLookupBarcode(this);
            ifrmChild.Show();
        }


    }
}
