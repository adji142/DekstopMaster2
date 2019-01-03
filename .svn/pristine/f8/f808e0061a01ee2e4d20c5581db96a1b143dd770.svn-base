using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Expedisi
{
    public partial class frmRekapKoliSubDetailUpdate : ISA.Toko.BaseForm
    {

        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID, _headerID;
        DataTable dtSubDetail, dtDetail;

        public frmRekapKoliSubDetailUpdate(Form caller, Guid headerID)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _headerID = headerID;
            this.Caller = caller;
        }

        public frmRekapKoliSubDetailUpdate(Form caller, Guid rowID, Guid headerID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _headerID = headerID;
            this.Caller = caller;
        }

        private void frmRekapKoliSubDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    dtDetail = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                txtNoDO.Text = Tools.isNull(dtDetail.Rows[0]["NoDO"], "").ToString();
                txtNoNota.Text = Tools.isNull(dtDetail.Rows[0]["NoNota"], "").ToString();
                txtSales.Text = Tools.isNull(dtDetail.Rows[0]["NamaSales"], "").ToString();
                txtTunaiKredit.Text = Tools.isNull(dtDetail.Rows[0]["TunaiKredit"], "").ToString();
                txtNoResi.Text = Tools.isNull(dtDetail.Rows[0]["NoResi"], "").ToString();

                if (formMode == enumFormMode.Update)
                {
                    dtSubDetail = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtSubDetail = db.Commands[0].ExecuteDataTable();
                    }
                    txtUraian.Text = Tools.isNull(dtSubDetail.Rows[0]["Uraian"], "").ToString();
                    txtJumlahKoli.Text = Tools.isNull(dtSubDetail.Rows[0]["Jumlah"], "").ToString(); ;
                    txtSatuan.Text = Tools.isNull(dtSubDetail.Rows[0]["Satuan"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dtSubDetail.Rows[0]["Keterangan"], "").ToString();                    

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        string _recordID = Tools.CreateFingerPrint();
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordID));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jumlah", SqlDbType.VarChar, txtJumlahKoli.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtSubDetail.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtSubDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtSubDetail.Rows[0]["HtrID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, txtUraian.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jumlah", SqlDbType.VarChar, txtJumlahKoli.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, dtSubDetail.Rows[0]["SyncFlag"]));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void Clear()
        {
            txtUraian.Text = "";
            txtJumlahKoli.Text = "0";
            txtSatuan.Text = "";
            txtKeterangan.Text = "";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRekapKoliSubDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmRekapKoliBrowse frmCaller = (frmRekapKoliBrowse)this.Caller;
                frmCaller.RefreshDataRekapKoliSubDetail();
            }
        }
    }
}
