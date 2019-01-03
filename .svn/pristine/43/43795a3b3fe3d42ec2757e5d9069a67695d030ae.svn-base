using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Bengkel;
using ISA.DAL;
using ISA.Common;
using System.Net;

namespace ISA.Bengkel
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public void AskLogin()
        {
            txtPassword.Text = "";
            this.Visible = true;
            txtPassword.Focus();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (txtUserName.Text.Trim().Length > 0)
            {
                bool isAuthenticate = SecurityManager.IsAuthenticate(txtUserName.Text, SecurityManager.EncodePassword(txtPassword.Text));

                if (isAuthenticate)
                {
                    SecurityManager.RecordLoginHistory();

                    this.DialogResult = DialogResult.OK;


                    //                     if (SecurityManager.IsPasswordExpired())
                    //                     {
                    //                         frmChangePassword ifrmChild = new frmChangePassword(true);
                    //                         ifrmChild.Show();
                    //                     }

                    if (SecurityManager.IsLogin == true)
                    {
                        this.Visible = true;
                        MessageBox.Show(SecurityManager.GetUserLogin(txtUserName.Text.Trim()), "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.Enabled = true;

                        return;
                    }
                    this.Visible = false;
                    frmMain ifrmMain = new frmMain();
                    Program.MainForm = ifrmMain;
                    ifrmMain.Show();
                }
                else
                {
                    if (SecurityManager.IsExist(txtUserName.Text))
                    {
                        SecurityManager.RecordLoginAttempt(txtUserName.Text);
                    }
                    MessageBox.Show(Messages.Confirm.LoginFailed);
                }
            }
            this.Enabled = true;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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

            //if (e.Control == true && e.Shift == true && e.KeyCode == Keys.S)
            //{
            //    this.SendToBack();
            //    frmResetLogin ifrmChild = new frmResetLogin();
            //    ifrmChild.Show();
            //}
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblHost.Text = Database.Host;

            if (txtUserName.Text == "")
            {
                txtUserName.Focus();
            }
            else
            {
                txtPassword.Focus();
            }

            //try
            //{
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("[usp_CLosingPJT_Chek]"));
            //        db.Commands[0].ExecuteNonQuery();
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    Error.LogError(ex);
            //}
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdLogin.PerformClick();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.S)
            {
                this.SendToBack();
                frmResetLogin ifrmChild = new frmResetLogin();
                ifrmChild.Show();
            }
        }
    }
}
