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

namespace ISA.Finance.Register
{
    public partial class frmRegisterHistory : ISA.Finance.BaseForm
    {
        DateTime _Tgl = new DateTime();
        Guid _KPID = Guid.Empty;

        public frmRegisterHistory(Form caller_, Guid KPID_,DateTime Tgl_)
        {
            _Tgl = Tgl_;
            _KPID = KPID_;
            this.Caller = caller_;
            InitializeComponent();
        }

        public frmRegisterHistory()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_HistoryNota]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, _KPID));
                    db.Commands[0].Parameters.Add(new Parameter("@Noregister", SqlDbType.VarChar, textBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, _Tgl));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dt;
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

        private void frmRegisterHistory_Load(object sender, EventArgs e)
        {
           
        }
    }
}
