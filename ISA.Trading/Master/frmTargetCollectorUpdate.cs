using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Class;

namespace ISA.Trading.Master
{
    public partial class frmTargetCollectorUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _KodeCollector, _NamaCollector;
        DataTable dt;

        public frmTargetCollectorUpdate()
        {
            InitializeComponent();
        }

        public frmTargetCollectorUpdate(Form caller, string KodeCollector_, string NamaCollector_)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _KodeCollector = KodeCollector_;
            _NamaCollector = NamaCollector_;
            this.Caller = caller;
        }

        public frmTargetCollectorUpdate(Form caller, Guid rowID, string KodeCollector_, string NamaCollector_)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _KodeCollector = KodeCollector_;
            _NamaCollector = NamaCollector_;
            this.Caller = caller;
        }

        private void frmTargetCollectorUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HistoryTargetCollector_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, null));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, null));
                        db.Commands[0].Parameters.Add(new Parameter("@CollID", SqlDbType.VarChar, null));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));                         
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    dTxtTMT.DateValue = (DateTime)dt.Rows[0]["TglAktif"];
                    txtKdColl.Text = _KodeCollector;
                    txtNama.Text = _NamaCollector;
                    nTxtKunj.Text = Tools.isNull(dt.Rows[0]["Kunjungan"], "").ToString();
                    nTxtTagih.Text = Tools.isNull(dt.Rows[0]["Tagih"], "").ToString();
                    nTxtNominal.Text = Tools.isNull(dt.Rows[0]["Nominal"], "").ToString();

                    txtNama.Enabled = false;
                    txtKdColl.Enabled = false;
                    dTxtTMT.Enabled = false;

                }
                else
                {
                    txtKdColl.Text = _KodeCollector;
                    txtNama.Text = _NamaCollector;
                    dTxtTMT.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                    txtNama.Enabled = false;
                    txtKdColl.Enabled = false;
                    dTxtTMT.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (PeriodeClosing.IsPJTClosed(dTxtTMT.DateValue.Value))
            {
                MessageBox.Show("Periode Tanggal Sudah Closing");
                return;
            }

            try
            {
                string cGudang = GlobalVar.Gudang;
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetCollector_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CollID", SqlDbType.VarChar, txtKdColl.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dTxtTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@Tagih", SqlDbType.Int, nTxtTagih.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kunjungan", SqlDbType.Int, nTxtKunj.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Int, nTxtNominal.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryTargetCollector_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@CollID", SqlDbType.VarChar, txtKdColl.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dTxtTMT.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@Tagih", SqlDbType.Int, nTxtTagih.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Kunjungan", SqlDbType.Int, nTxtKunj.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Int, nTxtNominal.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.VarChar, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                frmTargetCollector frm = new frmTargetCollector();
                frm = (frmTargetCollector)Caller;
                frm.BindData();
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void frmTargetCollectorUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (this.Caller is frmTargetCollector)
                    {
                        frmTargetCollector frmCaller = (frmTargetCollector)this.Caller;
                        frmCaller.RefreshBrowse1(_rowID.ToString());
                        frmCaller.FindBrowse1("colrowID", _rowID.ToString());
                    }
                }
            }
        }

    }


}
