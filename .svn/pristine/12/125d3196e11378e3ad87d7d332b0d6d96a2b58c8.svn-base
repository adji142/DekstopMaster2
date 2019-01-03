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

namespace ISA.Finance.Register
{
    public partial class frmRegisterTglKembaliUpdate : ISA.Finance.BaseForm
    {


        Guid _RowID = Guid.Empty;
        string _Tgl = string.Empty;
        DateTime _tgl = new DateTime();


        private void RefreshData()
        {
            if (this.Caller is frmRegisterBrowser)
            {
                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataHeader(_RowID);
                frmCaller.FindGridHeader("RowIDHeader", _RowID.ToString());
            }
        }

        public frmRegisterTglKembaliUpdate(Form caller_, Guid RowID_, string Tgl_, DateTime tgl_)
        {

            this.Caller = caller_;
            _RowID = RowID_;
            _Tgl = Tgl_;
            _tgl = tgl_;
            InitializeComponent();
        }

        public frmRegisterTglKembaliUpdate()
        {
            InitializeComponent();
        }

       
        private void frmRegisterTglKembaliUpdate_Load(object sender, EventArgs e)
        {
            if (_Tgl!="")
            {
                dateTextBox1.SetValue(_tgl);
            }else
            {
                dateTextBox1.SetValue(DateTime.Now);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (dateTextBox1.DateValue.HasValue==false)
            {
                dateTextBox1.Focus();
                dateTextBox1.SelectAll();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Tagihan_Update]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKembali", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshData();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }
    }
}
