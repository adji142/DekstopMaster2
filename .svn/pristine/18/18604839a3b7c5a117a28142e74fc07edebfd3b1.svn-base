using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;

namespace ISA.Finance.GL
{
    public partial class frmPartnerUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        string _partnerID;

        public frmPartnerUpdate()
        {
            InitializeComponent();
            formMode = enumFormMode.New;
        }

        public frmPartnerUpdate(string partnerID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _partnerID = "";
            txtPartnerID.ReadOnly = true;
        }

        public void LoadData()
        {
            
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                dt = Class.Journal.ListPartner(db);
            }
            if (dt.Rows.Count > 0)
            {
                txtPartnerID.Text = _partnerID;
                txtUraian.Text = dt.Rows[0]["Uraian"].ToString();
            }
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
                this.Close();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                Class.Journal.AddPartner(db, txtPartnerID.Text, txtUraian.Text);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartnerUpdate_Shown(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                LoadData();
            }
        }
    }
}
