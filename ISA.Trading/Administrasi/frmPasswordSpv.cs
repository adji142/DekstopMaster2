using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Trading.Administrasi
{
    public partial class frmPasswordSpv : Form
    {
        public frmPasswordSpv()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            return;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length > 0)
            {
                string userID = txtUserName.Text;
                string password = txtPassword.Text;
                DataTable dt;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PasswordSPVTrading"));
                    db.Commands[0].Parameters.Add(new Parameter("@username", SqlDbType.VarChar, userID));
                    db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, password));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Messages.Error.LoginFailed);
                }
            }
        }

        private void frmPasswordSpv_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        break;
                }
            }
        }
    }
}
