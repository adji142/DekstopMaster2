using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class LookupAccountToko : UserControl
    {
        public event EventHandler SelectData;
        string _kodeToko;
        public string NoAccount
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }

        public string KodeToko
        {
            get
            {
                return _kodeToko;
            }
            set
            {
                _kodeToko = value;
            }
        }
        public LookupAccountToko()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TextBox1.Text != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("usp_AccountToko_LOOKUP"));
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, TextBox1.Text));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (dt.Rows.Count > 0)
                    {
                        ShowDialogForm(TextBox1.Text, dt);
                    }
                    else
                    {
                        ShowDialogFormUpdate(TextBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }

            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmAccountTokoLookup ifrmDialog = new frmAccountTokoLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else if (ifrmDialog.DialogResult == DialogResult.None)
            {
                ShowDialogFormUpdate(TextBox1.Text);
            }
        }

        private void ShowDialogFormUpdate(string searchArg)
        {
            frmAccountTokoUpdate ifrmDialog = new frmAccountTokoUpdate(searchArg);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResultUpdate(ifrmDialog);
            }
            else
            {
                this.TextBox1.Focus();
                this.TextBox1.SelectAll();
            }
        }


        private void GetDialogResult(frmAccountTokoLookup dialogForm)
        {
            TextBox1.Text = dialogForm.NoAccount;
            KodeToko = dialogForm.KodeToko;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void GetDialogResultUpdate(frmAccountTokoUpdate dialogForm)
        {
            TextBox1.Text = dialogForm.NoAccount;
            KodeToko = dialogForm.KodeToko;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        public void Clear()
        {
            TextBox1.Text = "";
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
    }
}
