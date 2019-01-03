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
    public partial class MonthYearBox : UserControl
    {

        public int Month
        {
            get
            {
                return cboMonth.SelectedIndex + 1;
            }

            set
            {
                cboMonth.SelectedIndex = value -1;
            }
        }

        public int Year
        {
            get
            {
                return int.Parse (txtYear.Text); 
            }

            set
            {
                txtYear.Text = value.ToString();
            }
        }

        public string MonthName
        {
            get
            {
                return cboMonth.Text;
            }
        }

        public DateTime FirstDateOfMonth
        {
            get
            {
                return new DateTime(Year, Month, 1);
            }
        }

        public DateTime LastDateOfMonth
        {
            get
            {
                int m = Month;
                int y = Year;
                if (m == 12)
                {
                    m = 1;
                    y++;
                }
                else
                {
                    m++;
                }
                return (new DateTime(y,m, 1).AddDays(-1));
            }
        }

        public MonthYearBox()
        {
            InitializeComponent();
            SetControl();
        }

        private void SetControl()
        {
            txtYear.Text = DateTime.Now.Year.ToString();

            cboMonth.Items.Add("Januari");
            cboMonth.Items.Add("Februari");
            cboMonth.Items.Add("Maret");
            cboMonth.Items.Add("April");
            cboMonth.Items.Add("Mei");
            cboMonth.Items.Add("Juni");
            cboMonth.Items.Add("Juli");
            cboMonth.Items.Add("Agustus");
            cboMonth.Items.Add("September");
            cboMonth.Items.Add("Oktober");
            cboMonth.Items.Add("November");
            cboMonth.Items.Add("Desember");

            cboMonth.SelectedIndex = 0;
        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            if (txtYear.Text.Length < 4)
            {                
                txtYear.ForeColor = Color.Red;
            }
            else
            {
                txtYear.ForeColor = Color.Black;
            }
        }
    }
}
