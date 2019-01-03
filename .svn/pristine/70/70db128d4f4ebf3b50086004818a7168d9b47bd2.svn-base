using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmHargaJualUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        double _hrgHPP;
        DateTime _DateHpp;

        public void GetHargaHpp(string barangID)
        {
            try
            {
                DataTable dtGetHargaHPP = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekHargaHPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    dtGetHargaHPP = db.Commands[0].ExecuteDataTable();
                }
                if (dtGetHargaHPP.Rows.Count > 0)
                {
                    _hrgHPP = Convert.ToDouble(dtGetHargaHPP.Rows[0]["HPP"]);
                    _DateHpp = (DateTime)dtGetHargaHPP.Rows[0]["TglAktif"];
                }
                else
                {
                    _hrgHPP = 0;
                }
                DataTable dtBarang = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_HistoryHPP"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                    dtBarang = db.Commands[0].ExecuteDataTable();
                }
                lblnama.Text = dtBarang.Rows[0]["NamaStok"].ToString();
                txthpp.Text = dtBarang.Rows[0]["HPP"].ToString();
                txthpp2.Text = dtBarang.Rows[0]["HPP2"].ToString();
                lbldisc.Text = "Disc "+ dtBarang.Rows[0]["Discount"].ToString()+ " %";

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        String _RecordBarangID= "", _KodeBarang = string.Empty;
        double _dcash, _dtop10, _denduser ,_disc4= 0;
        double _hcash, _htop10, _henduser, _hnet ,_harga4 = 0;

        DataTable dt, dthargsSebelum, dtHarga;

        public frmHargaJualUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmHargaJualUpdate(Form caller, string KodeBarang, String beda)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _KodeBarang = KodeBarang;
            this.Caller = caller;
        }

        public frmHargaJualUpdate(Form caller, string KodeBarang, Guid rowID)
        {
             InitializeComponent();
             formMode = enumFormMode.Update;
             _KodeBarang = KodeBarang;
            _rowID = rowID;
            this.Caller = caller;

        }

        private void LoadHargaSebelumnya()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_HistoryBMKDepo_HargaJual_LIST_TOP1]"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _KodeBarang));
                    dthargsSebelum = db.Commands[0].ExecuteDataTable();
                }
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetDataHarga()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_HistoryBMKDepo_HargaJual_LIST_UPDATE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtHarga = db.Commands[0].ExecuteDataTable();
                }
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmHargaJualUpdate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GetHargaHpp(_KodeBarang);
            try
            {
                if (formMode == enumFormMode.New)
                {
                    dtTmt2.Enabled = false;
                    dttmt1.Focus();

                    LoadHargaSebelumnya();

                    dttmt1.DateValue = DateTime.Now;
                    if (dthargsSebelum.Rows.Count > 0)
                    {
                        _hnet = Convert.ToDouble(Tools.isNull(dthargsSebelum.Rows[0]["hnet"],0));
                        _dcash = Convert.ToDouble(Tools.isNull(dthargsSebelum.Rows[0]["cash"],0));
                        _dtop10 = Convert.ToDouble(Tools.isNull(dthargsSebelum.Rows[0]["top10"],0));
                        _denduser = Convert.ToDouble(Tools.isNull(dthargsSebelum.Rows[0]["enduser"],0));
                        _disc4 = Convert.ToDouble(Tools.isNull(Tools.isNull(dthargsSebelum.Rows[0]["disc4"],0),0));

                        _hcash = _hnet - ((_dcash / 100) * _hnet);
                        _htop10 = _hnet - ((_dtop10 / 100) * _hnet);
                        _henduser = _hnet - ((_denduser / 100) * _hnet);
                        _harga4 = _hnet - ((_disc4 / 100) * _hnet);

                        txtHNet.Text = _hnet.ToString();

                        txtDiscCash.Text = _dcash.ToString();
                        if (txtDiscCash.GetIntValue == 0)
                        { txtHCash.Text = "0"; }
                        else
                        {
                            txtHCash.Text = _hcash.ToString();
                        }
                        //  txtHCash.Enabled = false;
                        txtDiscTop10.Text = _dtop10.ToString();
                        if (txtDiscTop10.GetIntValue == 0)
                        { txtHTop10.Text = "0"; }
                        else
                        {
                            txtHTop10.Text = _htop10.ToString();
                        }
                        // txtHTop10.Enabled = false;
                        txtDiscEndUser.Text = _denduser.ToString();
                        if (txtDiscEndUser.GetIntValue == 0)
                        { txtHenduser.Text = "0"; }
                        else
                        {
                            txtHenduser.Text = _henduser.ToString();
                        }
                        //  txtHenduser.Enabled = false;

                        txtDisc4.Text = _disc4.ToString();
                        if (txtDisc4.GetIntValue == 0)
                        {  txtHarga4.Text = "0"; }
                        else
                        {
                           txtHarga4.Text = _harga4.ToString();
                        }

                    }
                    else
                    {
                        txtHNet.Text = "0";
                        txtDiscCash.Text = "0";
                        txtHCash.Text = "0";
                        txtDiscTop10.Text = "0";
                        txtHTop10.Text = "0";
                        txtDiscEndUser.Text = "0";
                        txtHenduser.Text = "0";
                        txtDisc4.Text = "0";
                        txtHarga4.Text = "0";
                    }
                    txtDiscCash.Enabled = true;
                    txtDiscTop10.Enabled = true;
                    txtDiscEndUser.Enabled = true;
                    txtDisc4.Enabled = true;
                    txtHCash.Enabled = false;
                    txtHTop10.Enabled = false;
                    txtHenduser.Enabled = false;
                    txtHarga4.Enabled = false;


                }

                if (formMode == enumFormMode.Update)
                {
                    dttmt1.Focus();
                    dtTmt2.Enabled = true;
                    GetDataHarga();

                    dttmt1.DateValue = Convert.ToDateTime(dtHarga.Rows[0]["TglAktif"]);
                    //DateTime tglpasif= Convert.ToDateTime(dtHarga.Rows[0]["TglPasif"]);
                    if (dtHarga.Rows[0]["TglPasif"].ToString() == "")
                    {
                        dtTmt2.Text = string.Empty;
                    }
                    else
                    {
                        dtTmt2.DateValue = Convert.ToDateTime(dtHarga.Rows[0]["TglPasif"]);
                    }
                    _hnet = Convert.ToDouble(dtHarga.Rows[0]["hnet"]);
                    _dcash = Convert.ToDouble(dtHarga.Rows[0]["cash"]);
                    _dtop10 = Convert.ToDouble(dtHarga.Rows[0]["top10"]);
                    _denduser = Convert.ToDouble(dtHarga.Rows[0]["enduser"]);
                    _disc4 = Convert.ToDouble(dtHarga.Rows[0]["disc4"]);


                    _hcash = Convert.ToDouble(dtHarga.Rows[0]["hjual_c"]);
                    _htop10 = Convert.ToDouble(dtHarga.Rows[0]["hjual_t"]);
                    _henduser = Convert.ToDouble(dtHarga.Rows[0]["hjual_e"]);
                    _harga4 = Convert.ToDouble(dtHarga.Rows[0]["harga4"]);

                    txtHNet.Text = _hnet.ToString();
                    txtDiscCash.Text = _dcash.ToString();
                    txtHCash.Text = _hcash.ToString();
                    txtHCash.Enabled = false;
                    txtDiscTop10.Text = _dtop10.ToString();
                    txtHTop10.Text = _htop10.ToString();
                    txtHTop10.Enabled = false;
                    txtDiscEndUser.Text = _denduser.ToString();
                    txtHenduser.Text = _henduser.ToString();
                    txtHenduser.Enabled = false;
                    txtDisc4.Text = _disc4.ToString();
                    txtHarga4.Text = _harga4.ToString();
                    txtHarga4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool ValidatedSave() 
        {
            bool canSave = true;
            String Pesan ="Harga Beli Terakhir rp :" + _hrgHPP.ToString("#,##0") + " tanggal "+_DateHpp.ToString("dd-MM-yyyy")+" \n ";
            if (txtHarga4.GetDoubleValue < _hrgHPP)
            {
                Pesan = Pesan + "- Harga jual 4 rp :" + txtHarga4.GetDoubleValue.ToString("#,##0") + " Harus Lebih Besar dari Harga Beli Terakhir \n ";
                canSave = false;
            }
            if (txtHenduser.GetDoubleValue < _hrgHPP)
            {
                Pesan = Pesan + "- Harga jual 3 rp :" + txtHenduser.GetDoubleValue.ToString("#,##0") + " Harus Lebih Besar dari Harga Beli Terakhir \n ";
                canSave = false;
            }
            if (txtHTop10.GetDoubleValue < _hrgHPP)
            {
                Pesan = Pesan + "- Harga jual 2 rp :" + txtHTop10.GetDoubleValue.ToString("#,##0") + " Harus Lebih Besar dari Harga Beli Terakhir \n ";
                canSave = false;
            }
            if (txtHCash.GetDoubleValue < _hrgHPP) 
            {
                Pesan = Pesan + "- Harga jual 1 rp :" + txtHCash.GetDoubleValue.ToString("#,##0") + " Harus Lebih Besar dari Harga Beli Terakhir \n ";
                canSave = false;
            }
            if (txtHarga4.GetDoubleValue <= txtHenduser.GetDoubleValue)
            {
                Pesan = Pesan + "- Harga jual 4 rp " + txtHarga4.GetDoubleValue.ToString("#,##0") + " Harus Lebih Besar dari dari Harga jual 3  rp " + txtHenduser.GetDoubleValue.ToString("#,##0") + "\n ";
                canSave = false;
            }
            if (txtHenduser.GetDoubleValue <= txtHTop10.GetDoubleValue)
            {
                Pesan = Pesan + "- Harga jual 3 rp " + txtHenduser.GetDoubleValue.ToString("#,##0") + "Harus Lebih Besar dari dari Harga jual 2 rp " + txtHTop10.GetDoubleValue.ToString("#,##0") + "\n ";
                canSave = false;
            }
            if (txtHTop10.GetDoubleValue <= txtHCash.GetDoubleValue)
            {
                Pesan = Pesan + "- Harga jual 2 rp " + txtHTop10.GetDoubleValue.ToString("#,##0") + "Harus Lebih Besar dari dari Harga jual 1 rp " + txtHCash.GetDoubleValue.ToString("#,##0") + "\n";
                canSave = false;
            }
            
            
            if (!canSave) { Pesan = Pesan + "Anda harus memiliki kewenangan Manager, Untuk melanjutkan Proses."; MessageBox.Show(Pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            return canSave;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidatedSave()) { 
                    if(!SecurityManager.AskPasswordManager())
                        return; }
                switch (formMode)
                {
                    case enumFormMode.New:
                        if (dttmt1.DateValue < GlobalVar.DateOfServer)
                        {
                            MessageBox.Show("Tanggal Berlaku kurang dari " +GlobalVar.DateOfServer.ToString());
                            dttmt1.Focus();
                            return;
                        }
                        DataTable dt = new DataTable();
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("rsp_HistoryBMK_Cek"));
                                db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, _KodeBarang));
                                db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, dttmt1.DateValue));
                                dt = db.Commands[0].ExecuteDataTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        if ((bool)dt.Rows[0]["Ada"])
                        {
                            MessageBox.Show("di Tanggal yang sama sudah ada Record");
                            dttmt1.Focus();
                            return;
                        }
                        SaveBMK();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case enumFormMode.Update:
                        UpdateBMK();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;

                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHargaJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmHargaJual)
                {
                    frmHargaJual frmCaller = (frmHargaJual)this.Caller;
                    frmCaller.RefreshDataStok();
                    frmCaller.FindRow("KodeBarang", _KodeBarang);
                    frmCaller.RefreshDataBMK();
                    frmCaller.FindRow1("RowID1", _rowID.ToString());
                    
                }
            }
        }

        private void txtDiscCash_Leave(object sender, EventArgs e)
        {
            _hnet = txtHNet.GetDoubleValue;
            _dcash = txtDiscCash.GetDoubleValue;

            _hcash = _hnet - ((_dcash / 100) * _hnet);

            txtHCash.Text = _hcash.ToString();
        }

        private void txtDiscTop10_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _dtop10 = txtDiscTop10.GetDoubleValue;

            _htop10 = _hnet - ((_dtop10 / 100) * _hnet);

            txtHTop10.Text = _htop10.ToString();
        }

        private void txtDiscEndUser_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _denduser = txtDiscEndUser.GetDoubleValue;

            _henduser = _hnet - ((_denduser / 100) * _hnet);

            txtHenduser.Text = _henduser.ToString();
        }



        private void SaveBMK()
        {

            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_HargaJualBMK_INSERT"));
                    _rowID = Guid.NewGuid();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HistoryID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@StokID", SqlDbType.VarChar, _RecordBarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, _KodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dttmt1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualB", SqlDbType.Money, txtHCash.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualM", SqlDbType.Money, txtHTop10.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualK", SqlDbType.Money, txtHenduser.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hnet", SqlDbType.Int, txtHNet.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, txtDiscCash.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, txtDiscTop10.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, txtDiscEndUser.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_c", SqlDbType.Int, txtHCash.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_t", SqlDbType.Int, txtHTop10.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_e", SqlDbType.Int, txtHenduser.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].Parameters.Add(new Parameter("@disc4", SqlDbType.NChar, txtDisc4.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@harga4", SqlDbType.Int, txtHarga4.GetIntValue));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data Berhasil Disimpan");
                this.DialogResult = DialogResult.OK;
                CloseForm();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void UpdateBMK()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_HargaJualBMK_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.Date, dttmt1.DateValue));
                    if (dtTmt2.Text == "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.Date, null));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.Date, dtTmt2.DateValue));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualB", SqlDbType.Money, txtHCash.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualM", SqlDbType.Money, txtHTop10.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgJualK", SqlDbType.Money, txtHenduser.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hnet", SqlDbType.Int, txtHNet.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, txtDiscCash.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, txtDiscTop10.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, txtDiscEndUser.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_c", SqlDbType.Int, txtHCash.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_t", SqlDbType.Int, txtHTop10.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_e", SqlDbType.Int, txtHenduser.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@disc4", SqlDbType.NChar, txtDisc4.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@harga4", SqlDbType.Int, txtHarga4.GetIntValue));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Data Berhasil TerUpdate");
                this.DialogResult = DialogResult.OK;
                CloseForm();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtDiscCash.Enabled = true;
            txtDiscTop10.Enabled = true;
            txtDiscEndUser.Enabled = true;
            txtDisc4.Enabled = true;
            txtHCash.Enabled = false;
            txtHTop10.Enabled = false;
            txtHenduser.Enabled = false;
            txtHarga4.Enabled = false;
        }

        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            txtDiscCash.Enabled = false;
            txtDiscTop10.Enabled = false;
            txtDiscEndUser.Enabled = false;
            txtDisc4.Enabled = false;
            txtHCash.Enabled = true;
            txtHTop10.Enabled = true;
            txtHenduser.Enabled = true;
            txtHarga4.Enabled = true;

        }

        private void txtHNet_Leave(object sender, EventArgs e)
        {
            hitung();
        }
        private void hitung()
        {
            _hnet = Convert.ToDouble(txtHNet.Text);
            _dcash = Convert.ToDouble(txtDiscCash.Text);
            _dtop10 = Convert.ToDouble(txtDiscTop10.Text);
            _denduser = Convert.ToDouble(txtDiscEndUser.Text);
            _disc4 = txtDisc4.GetDoubleValue;


            _hcash = _hnet - ((_dcash / 100) * _hnet);
            _htop10 = _hnet - ((_dtop10 / 100) * _hnet);
            _henduser = _hnet - ((_denduser / 100) * _hnet);
            _harga4 = _hnet - ((_disc4 / 100) * _hnet);


            txtHNet.Text = _hnet.ToString();
            txtHCash.Text = _hcash.ToString();
            txtHTop10.Text = _htop10.ToString();
            txtHenduser.Text = _henduser.ToString();
            txtHarga4.Text = _harga4.ToString();
        }

        private void txtHTop10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHCash_Leave(object sender, EventArgs e)
        {
            _hnet = txtHNet.GetDoubleValue;
            _hcash = txtHCash.GetDoubleValue;

            _dcash = ((_hnet - _hcash) / _hnet) * 100;
            if (_dcash < 0) _dcash = 0;
            txtDiscCash.Text = _dcash.ToString();
        }

        private void txtHTop10_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _htop10 = txtHTop10.GetDoubleValue;

            _dtop10 = ((_hnet - _htop10) / _hnet) * 100;
            if (_dtop10 < 0) _dtop10 = 0;
            txtDiscTop10.Text = _dtop10.ToString();
            
        }

        private void txtHenduser_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _henduser = txtHenduser.GetDoubleValue;
            _denduser = ((_hnet - _henduser) / _hnet) * 100;
            if (_denduser < 0) _denduser = 0;
            txtDiscEndUser.Text = _denduser.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDiscEndUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisc4_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _disc4 = txtDisc4.GetDoubleValue;

            _harga4 = _hnet - ((_disc4 / 100) * _hnet);

            txtHarga4.Text = _harga4.ToString();
        }

        private void txtHarga4_Leave(object sender, EventArgs e)
        {
            //hitung();
            _hnet = txtHNet.GetDoubleValue;
            _harga4 = txtHarga4.GetDoubleValue;

            _disc4 = ((_hnet - _harga4) / _hnet) * 100;
            if (_disc4 < 0) _disc4 = 0;
            txtDisc4.Text = _disc4.ToString();
        }
    }
}
