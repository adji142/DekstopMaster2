using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;
using System.Data.SqlClient;

namespace ISA.Finance.Piutang
{
    public partial class frmTokoHistoryDetailUpdate : ISA.Finance.BaseForm
    {
        Guid _RowID = Guid.Empty;
        string _KodeToko = string.Empty;
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dt = new DataTable("KasusToko");
        public frmTokoHistoryDetailUpdate()
        {
            InitializeComponent();
        }

        public frmTokoHistoryDetailUpdate(Form caller_,string KodeToko_)
        {
            this.Caller = caller_;
            _KodeToko = KodeToko_;
           formMode  = enumFormMode.New;
            InitializeComponent();
        }

        public frmTokoHistoryDetailUpdate(Form caller_, Guid RowID_, string Update_)
        {
            this.Caller = caller_;
            _RowID = RowID_;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        private void AddKodeKasus()
        {
            
            DataTable dk = new DataTable();
            dk = LookupInfo.GetList("KodeKasus").Copy();
            DataColumn cConcatenated = new DataColumn("Concatenated", Type.GetType("System.String"), "LookupCode + ' | ' + Value");
            dk.Columns.Add(cConcatenated);
            dk.Rows.Add("");
            dk.DefaultView.Sort = "Value ASC";

            cboKodeKasus.DataSource = dk;
            cboKodeKasus.DisplayMember = "Concatenated";
            cboKodeKasus.ValueMember = "LookupCode";

        }

        private void RefreshData()
        {
            if (this.Caller is frmTokoHistory)
            {
                frmTokoHistory frmCaller = (frmTokoHistory)this.Caller;
                //frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                //frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                frmCaller.RefreshRowDetail(_RowID);
                frmCaller.FindGridDetail("RowID", _RowID.ToString());

            }
        }
        private void frmTokoHistoryDetailUpdate_Load(object sender, EventArgs e)
        {
            AddKodeKasus();
           
            switch (formMode)
            {
            case enumFormMode.New:
                    dateTextBox1.DateValue = DateTime.Now;
                    cboKodeKasus.Focus();
            	break;
            case enumFormMode.Update:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using(Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_TokoKasus_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count>0)
                        {
                            dateTextBox1.DateValue = (DateTime)dt.Rows[0]["TglMT"];
                            cboKodeKasus.SelectedValue = Tools.isNull(dt.Rows[0]["KodeKasus"], "").ToString();
                            textBox1.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
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
                break;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DateTime tmt = new DateTime();
            if (cboKodeKasus.SelectedValue.ToString().Equals(string.Empty))
            {
                cboKodeKasus.Focus();
                errorProvider1.SetError(cboKodeKasus, "Tidak Boleh Kosong");
                return;
            }

            if (textBox1.Text.Trim()=="")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Tidak Boleh Kosong");
                return;
            }


            if (dateTextBox1.DateValue.HasValue==false)
            {
                dateTextBox1.Focus();
                errorProvider1.SetError(dateTextBox1, "Tidak Boleh Kosong");
                return;
            }

            if (PeriodeClosing.IsPJTClosed((DateTime)dateTextBox1.DateValue) == true)
                tmt = PeriodeClosing.LastClosingPJT.AddDays(1);
            else
                tmt = (DateTime)dateTextBox1.DateValue;
            
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_TokoKasus_INSERT]"));
                            _RowID = Guid.NewGuid();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMT", SqlDbType.Date, tmt));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeKasus", SqlDbType.VarChar, cboKodeKasus.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, textBox1.Text.Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserID)));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Error.LogError(ex);
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        RefreshData();
                    }
                    break;
                case enumFormMode.Update:
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_TokoKasus_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMT", SqlDbType.Date, dateTextBox1.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeKasus", SqlDbType.VarChar, cboKodeKasus.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, textBox1.Text.Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        RefreshData();
                    }
                    break;
            }
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
