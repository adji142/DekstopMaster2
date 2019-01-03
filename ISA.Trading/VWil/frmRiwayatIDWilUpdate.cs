using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.VWil
{
    public partial class frmRiwayatIDWilUpdate : ISA.Trading.BaseForm
    {
        
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _idwil; //, _lrefresh;

        public frmRiwayatIDWilUpdate(Form caller, Guid rowID, string idwil)//, string lrefresh)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _rowID = rowID;
            _idwil = idwil;
            //_lrefresh = lrefresh;
        }

        public frmRiwayatIDWilUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _rowID = rowID;
           
        }

        private void frmRiwayatIDWilUpdate_Load(object sender, EventArgs e)
        {
            txtWilIDOld.Text = _idwil;
            txtWilID.Focus();
            if (formMode == enumFormMode.Update)
            {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("usp_ReIDWil_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();

                }
                txtWilIDOld.Text = Tools.isNull(dt.Rows[0]["WilIDOld"],"").ToString();
                txtWilID.Text = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_ReIDWil_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@tokoID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text ));
                            db.Commands[0].Parameters.Add(new Parameter("@wilIDOld", SqlDbType.VarChar, txtWilIDOld.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lRefresh", SqlDbType.VarChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("ID wil: " + txtWilID.Text + " sudah ada");
                                txtWilID.SelectAll();
                                txtWilID.Focus();
                                return;
                            }

                        }
                        //);

                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_ReIDWil_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("ID wil: " + txtWilID.Text + " sudah ada");
                                txtWilID.SelectAll();
                                txtWilID.Focus();
                                return;
                            }

                        }
                        break;
                }
                //MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                frmRiwayatIDWilBrowse  frmCaller = (frmRiwayatIDWilBrowse)this.Caller;
                this.Close();
                frmCaller.RefreshData();
                frmCaller.Show();
            }
        }

        public bool IsValid()
        {
            bool valid = true;
            if (txtWilID.Text == "" )
            {
                errorProvider1.SetError(txtWilID, Messages.Error.InputRequired);
                txtWilID.Focus();
                valid = false;
            }
            return valid;
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRiwayatIDWilUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmRiwayatIDWilBrowse)
                {
                    frmRiwayatIDWilBrowse frmCaller = (frmRiwayatIDWilBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindDetail("Row", _rowID.ToString());
                }
            }
        }
    }
}
