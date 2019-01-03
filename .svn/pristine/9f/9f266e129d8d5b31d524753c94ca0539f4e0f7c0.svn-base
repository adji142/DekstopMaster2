using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.DAL;


namespace ISA.Trading.Master
{
    public partial class frmUserAccessUpdate : ISA.Controls.BaseForm
    {
        public event EventHandler SelectData;
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID, _headerID;

        public frmUserAccessUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmUserAccessUpdate(Form caller, Guid _rowID)
        {
            formMode = enumFormMode.Update;
            this.Caller = caller;
            InitializeComponent();
            _headerID = _rowID;
            _RowID = _rowID;
        }

        private void frmUserAccessUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.Update:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dtUser = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_UserAccess_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _headerID));
                            dtUser = db.Commands[0].ExecuteDataTable();
                        }
                        if (dtUser.Rows.Count > 0)
                        {
                            cboKey.Text = Tools.isNull(dtUser.Rows[0]["kode"], "").ToString();
                            lookupSecurityUsers1.UserName = Tools.isNull(dtUser.Rows[0]["UserName"], "").ToString();
                            lookupSecurityUsers1.UserID = Tools.isNull(dtUser.Rows[0]["UserID"], "").ToString();
                            string cAkses = Tools.isNull(dtUser.Rows[0]["Value"], "").ToString();
                            if (cAkses == "1")
                            {
                                rdbCed.Checked = Convert.ToBoolean(1);
                                rdbVew.Checked = Convert.ToBoolean(0);
                            }
                            else
                            {
                                rdbCed.Checked = Convert.ToBoolean(0);
                                rdbVew.Checked = Convert.ToBoolean(1);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(cboKey.Text, "") == "")
            {
                MessageBox.Show("Key masih kosong");
                cboKey.Focus();
                return;
            }

            if (Tools.isNull(lookupSecurityUsers1.UserName, "") == "")
            {
                MessageBox.Show("User Name masih kosong");
                lookupSecurityUsers1.Focus();
                return;
            }

            string cAkses = "0";
            if (rdbCed.Checked)
                cAkses = "1";
            else
                cAkses = "0";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case enumFormMode.New:
                        _RowID = Guid.NewGuid();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_UserAccess_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cboKey.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, lookupSecurityUsers1.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, lookupSecurityUsers1.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@userInit", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@value", SqlDbType.VarChar, cAkses));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_UserAccess_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cboKey.Text.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, lookupSecurityUsers1.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, lookupSecurityUsers1.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@userInit", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@value", SqlDbType.VarChar, cAkses));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void frmUserAccessUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmUserAccessBrowse)
                {
                    frmUserAccessBrowse frmCaller = (frmUserAccessBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _RowID.ToString());
                }
            }

        }
    }
}
