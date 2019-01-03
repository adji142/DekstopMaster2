
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using ISA.Controls;

namespace ISA.Controls
{
    public partial class BaseForm : Form
    {
        string _formID;
        bool _isUpdated = false;
        DialogResult _dialogResult = DialogResult.No;
        Form _caller;

        CommandButton cmdAdd;
        CommandButton cmdEdit;
        CommandButton cmdSave;
        CommandButton cmdDelete;
        CommandButton cmdPrint;

        [Browsable(true), DefaultValue("")]
        public string FormID
        {
            get
            {
                return _formID;
            }
            set
            {
                _formID = value;
                this.Text = (_formID != null && _formID != "" ? _formID + " - " : "") + lblTitle.Text;
            }
        }

        public bool IsUpdated
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                _isUpdated = value;

            }
        }

        public new DialogResult DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                _dialogResult = value;
            }
        }

        public Form Caller
        {
            get
            {
                return _caller;
            }

            set
            {
                _caller = value;
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
                this.Text = (_formID != null && _formID != "" ? _formID + " - " : "") + lblTitle.Text;
            }
        }

        public BaseForm()
        {
            InitializeComponent();
        }


        private void BaseForm_Load(object sender, EventArgs e)
        {            

            foreach (Control obj in this.Controls)
            {               
                if (obj is CommandButton)
                {
                    CommandButton cmd = (CommandButton)obj;
                    switch (cmd.CommandType)
                    {
                        case CommandButton.enCommandType.Add:
                            cmdAdd = cmd;
                            break;
                        case CommandButton.enCommandType.Edit:
                            cmdEdit = cmd;
                            break;
                        case CommandButton.enCommandType.Delete:
                            cmdDelete = cmd;
                            break;
                        case CommandButton.enCommandType.Save:
                            cmdSave = cmd;
                            break;
                        case CommandButton.enCommandType.Print:
                            cmdPrint = cmd;
                            break;
                    }

                    CheckAuthorization(obj);
                }
                
            }


        }


        protected void CheckAuthorization(Control ctrl)
        {
            CommandButton item = (CommandButton)ctrl;

            //else if (SecurityManager.IsAOperator())
            //{
            //    /// operator (add, edit, print)
            //    if (item.CommandType == CommandButton.enCommandType.Save || item.CommandType == CommandButton.enCommandType.Add || item.CommandType == CommandButton.enCommandType.Edit || item.CommandType == CommandButton.enCommandType.Print)
            //        item.Enabled = true;
            //    else
            //        item.Enabled = false;
            //}
            //else if (SecurityManager.IsAdministrator())
            //{
            //    if (item.CommandType == CommandButton.enCommandType.Add)
            //        item.Enabled = false;
            //    else
            //        item.Enabled = true;
            //}
            //else if (SecurityManager.IsManager())
            //{
            //    item.Enabled = true;
            //}

            if (item.CommandType == CommandButton.enCommandType.SearchL || item.CommandType == CommandButton.enCommandType.SearchS || item.CommandType == CommandButton.enCommandType.Close || item.CommandType == CommandButton.enCommandType.No || item.CommandType == CommandButton.enCommandType.Yes)
                item.Enabled = true;
        }

        private void lblTitle_Paint(object sender, PaintEventArgs e)
        {
            lblTitle.Left = (this.Width - lblTitle.Width) / 2;
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {                
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        //e.Handled = true;
                        break;
                    case Keys.Escape:
                        this.Close();
                        if (this.Caller != null)
                        {
                            this.Caller.Focus();
                        }
                        break;
                    case Keys.Insert:
                        if (cmdAdd != null)
                        {
                            if (cmdAdd.Enabled && cmdAdd.Visible)
                            {
                                cmdAdd.PerformClick();
                            }
                        }
                        break;
                    case Keys.Space:
                        if (cmdEdit != null)
                        {
                            if (cmdEdit.Enabled && cmdEdit.Visible)
                            {
                                cmdEdit.PerformClick();
                            }
                        }
                        break;
                    case Keys.F3:
                        if (cmdPrint != null)
                        {
                            if (cmdPrint.Enabled && cmdPrint.Visible)
                            {
                                cmdPrint.PerformClick();
                            }
                        }
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        if (e.Control)
                        {
                            if (cmdEdit != null)
                            {
                                if (cmdEdit.Enabled && cmdEdit.Visible)
                                {
                                    cmdEdit.PerformClick();
                                }
                            }
                        }
                        break;
                    case Keys.N:
                        if (e.Control)
                        {
                            if (cmdAdd != null)
                            {
                                if (cmdAdd.Enabled && cmdAdd.Visible)
                                {
                                    cmdAdd.PerformClick();
                                }
                            }
                        }
                        break;
                    case Keys.S:
                        if (e.Control)
                        {
                            if (cmdSave != null)
                            {
                                if (cmdSave.Enabled && cmdSave.Visible)
                                {
                                    cmdSave.PerformClick();
                                }
                            }
                        }
                        break;
                    case Keys.P:
                        if (e.Control)
                        {
                            if (cmdPrint != null)
                            {
                                if (cmdPrint.Enabled && cmdPrint.Visible)
                                {
                                    cmdPrint.PerformClick();
                                }
                            }
                        }
                        break;
                }
            }
        }


        public void RegisterChildNavigation(Control ctrl)
        {
            foreach (Control obj in ctrl.Controls)
            {


                if (obj is TextBox ||
                    obj is ComboBox ||
                    obj is RadioButton ||
                    obj is CheckBox ||
                    obj is NumericTextBox ||
                    obj is DateTextBox ||
                    obj is PostAreaComboBox ||
                    obj is WilIDComboBox
                    //obj is LookupGudang ||
                    //obj is LookupPostArea ||
                    //obj is LookupSales ||
                    //obj is LookupSecurityRights ||
                    //obj is LookupSecurityRoles ||
                    //obj is LookupStock ||
                    //obj is LookupToko
                    )
                {
                    obj.KeyDown += new KeyEventHandler(Control_OnPressEnter);
                    if (obj is TextBox)
                    {
                        //obj.Validated += new EventHandler(Text_ToUpper);
                    }
                }
            }
        }

        public void Control_OnPressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;     
                this.SelectNextControl((Control)sender, true, true, true, true);
                
            }            
        }

        public void Text_ToUpper(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            obj.Text = obj.Text.ToUpper();
        }

    }
}
