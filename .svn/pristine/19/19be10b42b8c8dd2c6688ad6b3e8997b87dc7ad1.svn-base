using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko
{
    public partial class frmChangePassword : ISA.Toko.BaseForm
    {
        string oldPassword="";
        bool _mustChange= false;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        public frmChangePassword(bool mustChange)
        {
            InitializeComponent();
            _mustChange = mustChange;
            cmdClose.Enabled = !mustChange;
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (isValidInput())
            {
                SecurityManager.ChangePassword(SecurityManager.EncodePassword(txtNewPassword.Text));
                MessageBox.Show(Messages.Confirm.ProcessFinished);
                this.Close();
            }            
        }

        private bool isValidInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (txtNewPassword.Text == "")
            {
                errorProvider1.SetError(txtNewPassword, Messages.Error.InputRequired);
                valid = false;
                return valid;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, Messages.Error.ConfirmPasswordNotMatch);
                valid = false;
                return valid;
            }
            string decodedOlPassword = SecurityManager.DecodePassword(oldPassword);
            if (decodedOlPassword != txtOldPassword.Text)
            {
                errorProvider1.SetError(txtOldPassword, Messages.Error.WrongPassword);
                valid = false;
                return valid;
            }
            return valid;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt;
                    db.Commands.Add(db.CreateCommand("usp_SecurityUsers_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                    oldPassword = dt.Rows[0]["Password"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mustChange)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
            }
        }        
    }
}
