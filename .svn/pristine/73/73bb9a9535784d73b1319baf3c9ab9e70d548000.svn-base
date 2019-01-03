using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmLookupUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _lookupCode;
        string _lookupType;

        DataTable dt;

        public frmLookupUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmLookupUpdate(Form caller, string lookupCode, string lookupType)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _lookupCode = lookupCode;
            _lookupType = lookupType;
            this.Caller = caller;
        }

        private void frmLookupUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Lookup_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@lookupCode", SqlDbType.VarChar, _lookupCode));
                        db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, _lookupType));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtLookupCode.Text = Tools.isNull(dt.Rows[0]["LookupCode"], "").ToString();
                    txtLookupCode.Enabled = false;
                    txtLookupType.Text = Tools.isNull(dt.Rows[0]["LookupType"], "").ToString();
                    txtLookupType.ReadOnly = true;
                    txtValue.Text = Tools.isNull(dt.Rows[0]["Value"], "").ToString();
                    txtAdditionalInfo.Text = Tools.isNull(dt.Rows[0]["AdditionalInfo"], "").ToString();
                    txtRowOrder.Text = Tools.isNull(dt.Rows[0]["RowOrder"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Lookup_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@lookupCode", SqlDbType.VarChar, txtLookupCode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, txtLookupType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@value", SqlDbType.VarChar, txtValue.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@additionalInfo", SqlDbType.VarChar, txtAdditionalInfo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@rowOrder", SqlDbType.VarChar, txtRowOrder.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Lookup_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@lookupCode", SqlDbType.VarChar, _lookupCode));
                            db.Commands[0].Parameters.Add(new Parameter("@lookupType", SqlDbType.VarChar, _lookupType));
                            db.Commands[0].Parameters.Add(new Parameter("@value", SqlDbType.VarChar, txtValue.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@additionalInfo", SqlDbType.VarChar, txtAdditionalInfo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@rowOrder", SqlDbType.VarChar, txtRowOrder.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void frmLookupUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmLookupBrowse)
                {
                    frmLookupBrowse frmCaller = (frmLookupBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("LookupCode", txtLookupCode.Text);
                }
            }
        }
    }
}
