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
using ISA.Toko.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace ISA.Toko.Register
{
    public partial class frmRegisterCollectorUpdate : ISA.Toko.BaseForm
    {

      //  DataRow dr = null;
        Guid _RowID = Guid.Empty;
        string KodeCollector = string.Empty;

        private void GetCollector()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_Collector_LIST]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                //dt.Rows.Add("");
                dt.DefaultView.Sort = "Nama ASC";
                textBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox2.DataSource = dt;
                textBox2.DisplayMember = "Nama";
                textBox2.ValueMember = "Kode";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

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

        public frmRegisterCollectorUpdate(Form caller_,Guid RowID_, string KodeCollector_ )
        {
            this.Caller = caller_;
            _RowID = RowID_;
            KodeCollector = KodeCollector_;
            InitializeComponent();
        }

        public frmRegisterCollectorUpdate()
        {
            InitializeComponent();
        }

        private void frmRegisterCollectorUpdate_Load(object sender, EventArgs e)
        {
            GetCollector();
            textBox2.SelectedValue = KodeCollector;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Tagihan_Update]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, textBox2.SelectedValue.ToString()));
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
