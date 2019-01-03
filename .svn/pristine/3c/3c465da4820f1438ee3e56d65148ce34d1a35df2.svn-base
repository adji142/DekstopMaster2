using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Master
{
    public partial class frmRightsUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rightID;

        DataTable dt;

        public frmRightsUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmRightsUpdate(Form caller, string rightID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update ;
            _rightID = rightID;
            this.Caller = caller;
        }

        private void frmRightsUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                try
                {

                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Rights_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, _rightID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtRightID.Text = Tools.isNull(dt.Rows[0]["RightID"], "").ToString();
                    txtRightID.Enabled = false;
                    txtRightName.Text = Tools.isNull(dt.Rows[0]["RightName"], "").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Error.LogError(ex);
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Rights_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, txtRightID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RightName", SqlDbType.VarChar, txtRightName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Rights_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RightID", SqlDbType.VarChar, txtRightID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RightName", SqlDbType.VarChar, txtRightName.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                frmRightsBrowse  frmCaller = (frmRightsBrowse )this.Caller;
                frmCaller.RefreshData();
                this.Close();
                frmCaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

    }
}
