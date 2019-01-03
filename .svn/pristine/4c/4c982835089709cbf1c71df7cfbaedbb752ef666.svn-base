using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class frmAccountTokoUpdate : ISA.Toko.BaseForm
    {

        public string NoAccount
        {
            get
            {
                return tbNoAcc.Text.Trim();
            }
            set
            {
                tbNoAcc.Text = value;
            }
        }

        public string KodeToko
        {
            get
            {
                return lookupToko1.KodeToko;
            }
        }

        public frmAccountTokoUpdate()
        {
            InitializeComponent();
        }

        public frmAccountTokoUpdate(string noAccount)
        {
            InitializeComponent();
            tbNoAcc.Text = noAccount;
        }

        private void frmAccountTokoUpdate_Load(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (lookupToko1.KodeToko == "" || lookupToko1.KodeToko == "[CODE]")
            {
                MessageBox.Show("Toko Harus Dipilih.");
                return;
            }

            if (tbNoAcc.Text=="")
            {
                MessageBox.Show("No Account Harus Diisi.");
                return;
            }


            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_AccountToko_INSERT"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier,Guid.NewGuid()));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@NoAccount", SqlDbType.VarChar, tbNoAcc.Text.Trim()));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
