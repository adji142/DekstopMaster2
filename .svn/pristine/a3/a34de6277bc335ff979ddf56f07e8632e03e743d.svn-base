using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Testing
{
    public partial class PerkiraanUpdateTest : ISA.Finance.BaseForm
    {
        enum enumFormMode {New, update};
        enumFormMode formMode;
        string _rowID;

        DataTable dt;


        public PerkiraanUpdateTest(Form Caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = Caller;

        }

        public PerkiraanUpdateTest(Form Caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.update;
            txtNoPerkiraan.ReadOnly = true;
            _rowID = rowID;
            this.Caller = Caller;

        }

        public PerkiraanUpdateTest()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PerkiraanUpdateTest_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (formMode == enumFormMode.update)
                {
                    //retrieving data

                    dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtNoPerkiraan.Text = Tools.isNull(dt.Rows[0]["NoPerkiraan"], "").ToString();
                    txtUraian.Text = Tools.isNull(dt.Rows[0]["NamaPerkiraan"], "").ToString();
                    txtRef.Text = Tools.isNull(dt.Rows[0]["Ref"], "").ToString();
                    cboLevel.Text = Tools.isNull(dt.Rows[0]["Level"], "").ToString();
                    chkPassive.Checked = (bool)dt.Rows[0]["Pasif"];
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            { if (InputIsValid())
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch(formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database(GlobalVar.DBName))
                            {

                                db.Commands.Add(db.CreateCommand("usp_Perkiraan_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, txtRef.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Level", SqlDbType.VarChar, cboLevel.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                                db.Commands[0].Parameters.Add(new Parameter("@Pasif", SqlDbType.VarChar, chkPassive.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                this._rowID = txtNoPerkiraan.Text;
                            }
                            break;

                        case enumFormMode.update:
                            using (Database db = new Database(GlobalVar.DBName))
                            {

                                db.Commands.Add(db.CreateCommand("usp_Perkiraan_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, txtRef.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Level", SqlDbType.VarChar, cboLevel.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, txtUraian.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                                db.Commands[0].Parameters.Add(new Parameter("@Pasif", SqlDbType.VarChar, chkPassive.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            break;
                    }

                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }


        private bool InputIsValid()
        {
            bool valid = true;

            if (txtNoPerkiraan.Text == string.Empty)
            {
                txtNoPerkiraan.Focus();
                errorProvider1.SetError(txtNoPerkiraan, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtUraian.Text == string.Empty)
            {
                txtUraian.Focus();
                errorProvider1.SetError(txtUraian, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtRef.Text == string.Empty)
            {
                txtRef.Focus();
                errorProvider1.SetError(txtRef, Messages.Error.InputRequired);
                valid = false;
            }

            return valid;
        }

        private void PerkiraanUpdateTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is Testing.PerkiraanBrowseTest)
                {
                    Testing.PerkiraanBrowseTest frmCaller = (Testing.PerkiraanBrowseTest)this.Caller;
                    frmCaller.RefreshRowData(_rowID.ToString());
                    
                    if (this.formMode == enumFormMode.New)
                    {
                        frmCaller.FindRow("NoPerkiraan", _rowID);
                    }
                }
            }
        }

        



    }
}
