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
    public partial class frmStafPenjualanUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid  _rowID;
        string tampNama;
        DataTable dt;

        public frmStafPenjualanUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmStafPenjualanUpdate(Form caller, Guid  rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmStafPenjualanUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier , _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    //display data
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    tampNama = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama belum diisi");
                txtNama.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Open();
                                _rowID = Guid.NewGuid();
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                    case enumFormMode.Update:
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier , _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                frmStafPenjualanBrowser  frmCaller = (frmStafPenjualanBrowser )this.Caller;
                frmCaller.RefreshData();
                this.Close();
                frmCaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmStafPenjualanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmStafPenjualanBrowser)
                {
                    frmStafPenjualanBrowser frmCaller = (frmStafPenjualanBrowser)this.Caller;
                    frmCaller.RefreshData();
                    //frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

       

       

       
    }
}
