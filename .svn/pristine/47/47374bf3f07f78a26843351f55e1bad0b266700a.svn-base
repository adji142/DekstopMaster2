using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Controls
{
    public partial class LookupPartnerDetail : UserControl
    {
        public LookupPartnerDetail()
        {
            InitializeComponent();
        }
        public event EventHandler SelectData;

        public string NoPerkiraan
        {
            get
            {
                return lblPerkiraan.Text;
            }
            set
            {
                lblPerkiraan.Text = value;
            }
        }

        public string NamaPerkiraan
        {
            get
            {
                return txtPerkiraan.Text;
            }
            set
            {
                txtPerkiraan.Text = value;
            }
        }

        public void SearchPerkiraan()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtPerkiraan.Text));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count == 1)
                {
                    lblPerkiraan.Text = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                    txtPerkiraan.Text = Tools.isNull(dt.Rows[0]["NamaPerkiraan"], "").ToString();
                    if (this.SelectData != null)
                    {
                        this.SelectData(this, new EventArgs());
                    }
                }
                else
                {
                    ShowDialogForm(txtPerkiraan.Text, dt);
                }
            }
        }

        private void txtPerkiraan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtPerkiraan.Text != "")
                {
                    SearchPerkiraan();
                }
                else
                {

                    Clear();
                }
            }
        }

        private void ShowDialogForm()
        {
            frmPerkiraanLookup ifrmDialog = new frmPerkiraanLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmPerkiraanLookup ifrmDialog = new frmPerkiraanLookup(searchArg, dt,0);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmPerkiraanLookup dialogForm)
        {
            txtPerkiraan.Text = dialogForm.NamaPerkiraan;
            lblPerkiraan.Text = dialogForm.NoPerkiraan;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void Clear()
        {
            txtPerkiraan.Text = "";
            lblPerkiraan.Text = "[CODE]";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }

    }
}
