using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Expedisi
{
    public partial class frmRekapKoliHeaderUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID;
        string _kodeToko = "";
        DataTable dtRekapKoli;

        public frmRekapKoliHeaderUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmRekapKoliHeaderUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmRekapKoliHeaderUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtExpedisi1 = new DataTable();
                DataTable dtExpedisi2 = new DataTable();
                DataTable dtExpedisi3 = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Expedisi_LIST"));
                    dtExpedisi1 = db.Commands[0].ExecuteDataTable();
                }

                dtExpedisi2 = dtExpedisi1.Copy();
                dtExpedisi3 = dtExpedisi1.Copy();

                cboKodeExp1.DataSource = dtExpedisi1;
                cboKodeExp1.DisplayMember = "KodeExpedisi";
                cboKodeExp1.ValueMember = "KodeExpedisi";
                cboKodeExp2.DataSource = dtExpedisi2;
                cboKodeExp2.DisplayMember = "KodeExpedisi";
                cboKodeExp2.ValueMember = "KodeExpedisi";
                cboKodeExp3.DataSource = dtExpedisi3;
                cboKodeExp3.DisplayMember = "KodeExpedisi";
                cboKodeExp3.ValueMember = "KodeExpedisi";

                
                cboKodeExp1.SelectedValue = "";
                cboKodeExp2.SelectedValue = "";
                cboKodeExp3.SelectedValue = "";
                
                if (cboKodeExp1.FindString("SAS",0)>0)
                    cboKodeExp1.SelectedValue = "SAS";


                if (formMode == enumFormMode.Update)
                {
                    dtRekapKoli = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_RekapKoli_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtRekapKoli = db.Commands[0].ExecuteDataTable();
                    }
                    txtNoSJ.Text = Tools.isNull(dtRekapKoli.Rows[0]["NoSuratJalan"], "").ToString();
                    txtTglSJ.DateValue = DateTime.Parse(Tools.isNull(dtRekapKoli.Rows[0]["TglSuratJalan"], DateTime.Today.Date).ToString());                    
                    _kodeToko = Tools.isNull(dtRekapKoli.Rows[0]["KodeToko"], "").ToString();
                    lookupToko.KodeToko = _kodeToko;
                    lookupToko.NamaToko = Tools.isNull(dtRekapKoli.Rows[0]["NamaToko"], "").ToString();
                    txtAlamatKirim.Text = Tools.isNull(dtRekapKoli.Rows[0]["Alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dtRekapKoli.Rows[0]["Kota"], "").ToString();
                    txtTglKeluar.DateValue = DateTime.Parse(Tools.isNull(dtRekapKoli.Rows[0]["TglKeluar"], "").ToString());
                    cboKodeExp1.SelectedValue = Tools.isNull(dtRekapKoli.Rows[0]["KodeExp1"], "").ToString();
                    cboKodeExp2.SelectedValue = Tools.isNull(dtRekapKoli.Rows[0]["KodeExp2"], "").ToString();
                    cboKodeExp3.SelectedValue = Tools.isNull(dtRekapKoli.Rows[0]["KodeExp3"], "").ToString();
                    txtBiayaExp1.Text = Tools.isNull(dtRekapKoli.Rows[0]["BiayaExp1"], "").ToString();
                    txtBiayaExp2.Text = Tools.isNull(dtRekapKoli.Rows[0]["BiayaExp2"], "").ToString();
                    txtBiayaExp3.Text = Tools.isNull(dtRekapKoli.Rows[0]["BiayaExp3"], "").ToString();
                    cboShift.SelectedItem = Tools.isNull(dtRekapKoli.Rows[0]["Shift"], "").ToString();

                }
                else
                {
                    txtTglSJ.DateValue = DateTime.Now;
                    txtTglKeluar.DateValue = DateTime.Now;
                    cboShift.SelectedIndex = 0;
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
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                string kodeExp1 = "";
                string kodeExp2 = "";
                string kodeExp3 = "";
                if (cboKodeExp1.SelectedIndex >= 0)
                    kodeExp1 = cboKodeExp1.SelectedValue.ToString();
                if (cboKodeExp2.SelectedIndex >= 0)
                    kodeExp2 = cboKodeExp2.SelectedValue.ToString();
                if (cboKodeExp3.SelectedIndex >= 0)
                    kodeExp3 = cboKodeExp3.SelectedValue.ToString();


                switch (formMode)
                {                        
                    case enumFormMode.New:
                        GlobalVar.LastClosingDate = DateTime.Today;
                        if (DateTime.Today <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        string _recordID = Tools.CreateFingerPrint();
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoli_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordID));
                            db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, GenerateNewNoSJ()));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));                            
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp1", SqlDbType.VarChar, kodeExp1));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp2", SqlDbType.VarChar, kodeExp2));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp3", SqlDbType.VarChar, kodeExp3));
                            db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, cboShift.SelectedItem));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp1", SqlDbType.Money, double.Parse(txtBiayaExp1.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp2", SqlDbType.Money, double.Parse(txtBiayaExp2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp3", SqlDbType.Money, double.Parse(txtBiayaExp3.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@kp", SqlDbType.VarChar, "KP!"));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        GlobalVar.LastClosingDate = (DateTime)txtTglSJ.DateValue;
                        if ((DateTime)txtTglSJ.DateValue <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoli_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtRekapKoli.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, txtTglSJ.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, dtRekapKoli.Rows[0]["NoSuratJalan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp1", SqlDbType.VarChar, kodeExp1));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp2", SqlDbType.VarChar, kodeExp2));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeExp3", SqlDbType.VarChar, kodeExp3));
                            db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.Int, cboShift.SelectedItem));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp1", SqlDbType.Money, double.Parse(txtBiayaExp1.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp2", SqlDbType.Money, double.Parse(txtBiayaExp2.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@biayaExp3", SqlDbType.Money, double.Parse(txtBiayaExp3.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtRekapKoli.Rows[0]["NPrint"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kp", SqlDbType.VarChar, dtRekapKoli.Rows[0]["KP"]));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, dtRekapKoli.Rows[0]["SyncFlag"]));
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

        private void Clear()
        {
            txtNoSJ.Text = "";
            txtTglSJ.DateValue = DateTime.Now;
            txtTglKeluar.DateValue = DateTime.Now;            
            _kodeToko = "";
            lookupToko.NamaToko = "";
            lookupToko.KodeToko = "";
            lookupToko.Alamat = "";
            lookupToko.Kota = "";
            txtAlamatKirim.Text = "";
            txtKota.Text = "";
            cboKodeExp1.SelectedItem = null;
            cboKodeExp2.SelectedItem = null;
            cboKodeExp3.SelectedItem = null;
            txtBiayaExp1.Text = "0";
            txtBiayaExp2.Text = "0";
            txtBiayaExp3.Text = "0";
            cboShift.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            
            if (txtTglSJ.Text ==  "")
            {
                errorProvider1.SetError(txtTglSJ, "Tgl Surat Jalan tidak boleh kosong");
                valid = false;
            }
            if (_kodeToko == "")
            {
                errorProvider1.SetError(lookupToko, "Toko tidak boleh kosong");
                valid = false;
            }
            if (txtTglKeluar.Text ==  "")
            {
                errorProvider1.SetError(txtTglSJ, "Tgl Keluar tidak boleh kosong");
                valid = false;
            }
            if (cboKodeExp1.SelectedValue.ToString() == "")
            {
                errorProvider1.SetError(cboKodeExp1, "Expedisi tidak boleh kosong");
                valid = false;
            }
            if (cboShift.SelectedItem == null)
            {
                errorProvider1.SetError(cboShift, "Shift tidak boleh kosong");
                valid = false;
            }

            return valid;
        }

        private string GenerateNewNoSJ()
        {
            string _fill = "0000000";
            string _noSJ;
            string _nomor;
            DataTable dtNumerator = new DataTable();
            try
            {                
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "NOMOR_SJ_EKPEDISI_LUAR_KOTA"));
                    dtNumerator = db.Commands[0].ExecuteDataTable();
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
            _nomor = dtNumerator.Rows[0]["Nomor"].ToString();
            _noSJ = _fill + _nomor;

            UpdateNumerator(dtNumerator);

            return (_noSJ.Substring(_noSJ.Length - 7));
        }

        private void UpdateNumerator(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int _currentNomor = int.Parse(Tools.isNull(dt.Rows[0]["Nomor"], "0").ToString());
                int _nextNomor = _currentNomor + 1;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "NOMOR_SJ_EKPEDISI_LUAR_KOTA"));
                    db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, dt.Rows[0]["Depan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, dt.Rows[0]["Belakang"]));
                    db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, _nextNomor));
                    db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.Int, dt.Rows[0]["Lebar"]));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRekapKoliHeaderUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmRekapKoliBrowse frmCaller = (frmRekapKoliBrowse)this.Caller;
                frmCaller.RefreshDataRekapKoli();
                frmCaller.FindHeader("HeaderRowID", _rowID.ToString());
            }
        }

        private void lookupToko_SelectData(object sender, EventArgs e)
        {
            txtAlamatKirim.Text = lookupToko.Alamat;
            txtKota.Text = lookupToko.Kota;
            _kodeToko = lookupToko.KodeToko;
        }

    }
}
