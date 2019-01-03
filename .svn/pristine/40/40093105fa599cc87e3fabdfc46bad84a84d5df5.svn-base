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
    public partial class LookupDKN : UserControl
    {
        public event EventHandler SelectData;

        public string NoDKN
        {
            get
            {
                return txtLookup.Text;
            }
            set
            {
                txtLookup.Text = value;
            }
        }

        public string Tanggal
        {
            get
            {
                return lblLookup.Text;
            }
            set
            {
                lblLookup.Text = value;
            }
        }

        public string Jumlah
        {
            get
            {
                return labeljumlah.Text;
            }
            set
            {
                labeljumlah.Text = value;
            }
        }

        public LookupDKN()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmDKNLookup ifrmDialog = new frmDKNLookup();
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmDKNLookup dialogForm)
        {
            txtLookup.Text = dialogForm.NoDKN;
            lblLookup.Text = dialogForm.Tanggal;
            labeljumlah.Text = dialogForm.Jumlah;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            txtLookup.Text = "";
            lblLookup.Text = "[CODE]";
            labeljumlah.Text = "[CODE]";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public bool Set()
        {
            return this.Set("");
        }
        public bool Set(string NoDKN)
        {
            try
            {
                this.Clear();
                using (var db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DKN_LIST_ByNoDKN]"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, NoDKN));
                    DataTable dtbl = db.Commands[0].ExecuteDataTable();
                    if (dtbl.Rows.Count > 0)
                    {
                       txtLookup.Text = Tools.isNull(dtbl.Rows[0]["NoDKN"], "").ToString();
                       lblLookup.Text = Tools.isNull(dtbl.Rows[0]["Tanggal"], "").ToString();
                       labeljumlah.Text = Tools.isNull(dtbl.Rows[0]["Jumlah"], "").ToString();
                       return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }

        private void txtLookup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowDialogForm();
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }
    }
}
