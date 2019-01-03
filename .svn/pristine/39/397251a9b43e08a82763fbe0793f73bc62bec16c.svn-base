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


namespace ISA.Finance.Piutang
{
    public partial class frmKartuPiutangNoteTokoUpdate : ISA.Finance.BaseForm
    {
        string _KodeToko = string.Empty;
        DataTable dt = new DataTable();
       // DataRow dr_;
        public frmKartuPiutangNoteTokoUpdate(Form caller_,string KodeToko_)
        {

            this.Caller = caller_;
            _KodeToko = KodeToko_;
            InitializeComponent();
        }

        private void KodePosLoad()
        {
            try
            {
                DataTable dt = new DataTable();
                using(Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_KodePos_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.Rows.Add("");
                dt.DefaultView.Sort = "KodePos ASC";

                cboKodePos.DataSource = dt;
                cboKodePos.DisplayMember = "KodePos";
                cboKodePos.ValueMember = "KodePos";

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);	
            }
            
        }
        public frmKartuPiutangNoteTokoUpdate()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKartuPiutangNoteTokoUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                KodePosLoad();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 1)
                    {
                        txtWilID.Text = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                        txtGrade.Text = Tools.isNull(dt.Rows[0]["Grade"], "").ToString();
                        txtINfoTagih.Text = Tools.isNull(dt.Rows[0]["RefCollector"], "").ToString();
                        txtCatatanToko.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                        cboKodePos.Text = Tools.isNull(dt.Rows[0]["KodePos"], "").ToString();
                    }
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
             
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE_Catatan"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, cboKodePos.SelectedText));
                    db.Commands[0].Parameters.Add(new Parameter("@Grade", SqlDbType.VarChar, txtGrade.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@RefCollector", SqlDbType.VarChar, txtINfoTagih.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatanToko.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar,SecurityManager.UserID));
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
                this.Close();
            }
        }
    }
}
