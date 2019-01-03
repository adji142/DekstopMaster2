using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.GL
{
    public partial class frmJournalDetailUpdate : ISA.Finance.BaseForm
    {
        
        public string NoPerkiraan
        {
            get { return lookupPerkiraan1.NoPerkiraan; }
            set { lookupPerkiraan1.NoPerkiraan = value; }
        }

        public string NamaPerkiraan
        {
            get { return lookupPerkiraan1.NamaPerkiraan; }
            set { lookupPerkiraan1.NamaPerkiraan = value; }
        }
        public string Uraian
        {
            get { return txtUraian.Text ; }
            set { txtUraian.Text = value; }
        }
        public string DK
        {
            get 
            {
                string _DK = "D";
                if (Kredit > 0)
                    _DK = "K";
                return _DK;
            }            
        }
        public double Debet
        {
            get 
            {
                return txtDebet.GetDoubleValue;
            }
            set 
            {
                txtDebet.Text = value.ToString("#,##0"); 
            }
        }
        public double Kredit
        {
            get
            {
                return txtKredit.GetDoubleValue;
            }
            set
            {
                txtKredit.Text = value.ToString("#,##0");
            }
        }


        public frmJournalDetailUpdate()
        {
            InitializeComponent();
        }

        private void frmJournalDetailUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtUraian_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtDebet_TextChanged(object sender, EventArgs e)
        {
            txtKredit.Text = "0";
        }

        private void txtKredit_TextChanged(object sender, EventArgs e)
        {
            txtDebet.Text = "0";
        }
    }
}
