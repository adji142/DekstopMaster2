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
    public partial class frmCollectorUpdate : ISA.Finance.BaseForm
    {
        string _RowID;
        string _NamaCollector;
        double _BtsOD;
        public frmCollectorUpdate(Form caller_,string RowID_, string NamaCollector, double BtsOD_)
        {
            this.Caller = caller_;
            _RowID = RowID_;
            _NamaCollector = NamaCollector;
            _BtsOD = BtsOD_;
            InitializeComponent();
        }

        private void RefreshData()
        {
            if (this.Caller is frmCollectorBrowser)
            {
                frmCollectorBrowser frmCaller = (frmCollectorBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataHeader(_RowID);
                frmCaller.FindGridHeader("CollectorID", _RowID);
            }
        }

        public frmCollectorUpdate()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Collector_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@BatasOD", SqlDbType.Money,numericTextBox1.GetDoubleValue ));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshData();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        private void frmCollectorUpdate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            textBox1.Text = _NamaCollector;
            textBox1.ReadOnly = true;
            numericTextBox1.Focus();
            numericTextBox1.SelectAll();
        }
    }
}
