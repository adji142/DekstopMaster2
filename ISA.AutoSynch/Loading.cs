using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;


namespace ISA.AutoSynch
{
    public partial class Loading : Form
    {
        int hitung;
        RegistryKey reg = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


        
        public Loading()
        {
            reg.SetValue("AutoSynchCabang", Application.ExecutablePath.ToString());
            InitializeComponent();
        }

        //untuk mendisable menu exit
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 


        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
           
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hitung++;
            progbar.Value = hitung;
            if (hitung == 50)
            {
                timer1.Enabled = false;
                frmautosynch frm = new frmautosynch();
                frm.Show();

                this.Hide();
            }
  
        }
    }
}
