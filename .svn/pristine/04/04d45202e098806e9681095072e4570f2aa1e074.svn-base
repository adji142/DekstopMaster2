using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmMPRDetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;

        Guid _rowID, _headerID;
        string _kodeToko, _namaBarang = "", _cabang1;
        DateTime _tglMemo;
        DataTable dt;
        DataRow _historyJualRow;
        int QtyNota_,QtyMemo_,QtySisa_;
        // Variable untuk hitungan
        double _disc1, _disc2, _disc3, _pot;
        string _discFormula;

        private void InitVar()
        {
            QtyMemo_ = 0;
            QtyNota_ = 0;
            QtySisa_ = 0;
        }

        public frmMPRDetailUpdate(Form caller, Guid id, enumFormMode FormMode)
        {
            InitializeComponent();
            formMode = FormMode;
            if (formMode == enumFormMode.New)
            {
                _headerID = id;
            }
            else
            {
                _rowID = id;
            }
            this.Caller = caller;
        }

        private void frmMPRDetailUpdate_Load(object sender, EventArgs e)
        {
            /* Isi combo box kode retur */
            DataTable dtKodeRetur = new DataTable();
            DataColumn cKode = new DataColumn("Kode", Type.GetType("System.String"));
            DataColumn cKet = new DataColumn("Ket", Type.GetType("System.String"));
            dtKodeRetur.Columns.Add(cKode);
            dtKodeRetur.Columns.Add(cKet);
            dtKodeRetur.Rows.Add("1", "Murni");
            dtKodeRetur.Rows.Add("2", "Dari Cabang");
            dtKodeRetur.Rows.Add("3", "Tarikan");
            cboKodeRetur.DataSource = dtKodeRetur;
            cboKodeRetur.DisplayMember = "Ket";
            cboKodeRetur.ValueMember = "Kode";
            /* ------------------------ */            
            /*Init*/
            InitVar();
            /**/            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtKategori = new DataTable();

                if (formMode == enumFormMode.New)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        // IF formMode adalah New, dt di isi dari Retur Penjualan Header
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                        db.Commands.Add(db.CreateCommand("usp_Kategori_LIST"));
                        //db.Commands[1].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, "RJ"));
                        dt = db.Commands[0].ExecuteDataTable();
                        dtKategori = db.Commands[1].ExecuteDataTable();
                    }
                    /* Bind data combo box kategori */ 
                    DataColumn cKatConcatenatedCol = new DataColumn("Concatenated", Type.GetType("System.String"));
                    cKatConcatenatedCol.Expression = "Kategori + ' | ' + Keterangan";
                    dtKategori.Columns.Add(cKatConcatenatedCol);
                    cboKategori.DataSource = dtKategori;
                    cboKategori.DisplayMember = "Concatenated";
                    cboKategori.ValueMember = "Kategori";

                    _kodeToko = Tools.isNull(dt.Rows[0]["KodeToko"], "").ToString();
                    _cabang1 = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                    _tglMemo = (DateTime)dt.Rows[0]["TglMPR"];
                    cboKodeRetur.SelectedValue = "1";
                    txtNoNota.Enabled = false;
                    lookupSales.Enabled = false;
                    txtHrgJualRetur.Enabled = false;
                    txtPotRetur.Enabled = false;
                    txtNoACC.Enabled = false;
                }

                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        // IF formMode adalah Update, dt di isi dari Retur Penjualan Detail
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands.Add(db.CreateCommand("usp_Kategori_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, "RJ"));
                        dt = db.Commands[0].ExecuteDataTable();
                        dtKategori = db.Commands[1].ExecuteDataTable();
                    }
                    /* Bind data combo box kategori */ 
                    DataColumn cKatConcatenatedCol = new DataColumn("Concatenated", Type.GetType("System.String"));
                    cKatConcatenatedCol.Expression = "Kategori + ' | ' + Keterangan";
                    dtKategori.Columns.Add(cKatConcatenatedCol);
                    cboKategori.DataSource = dtKategori;
                    cboKategori.DisplayMember = "Concatenated";
                    cboKategori.ValueMember = "Kategori";

                    /* Display data untuk edit */
                    cboKodeRetur.SelectedValue = Tools.isNull(dt.Rows[0]["KodeRetur"], "").ToString();
                    lookupStock.NamaStock = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                    lookupStock.BarangID = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                    txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                    txtNoNota.Text = Tools.isNull(dt.Rows[0]["NotaAsal"], "").ToString();
                    txtTglNota.Text = Tools.isNull(dt.Rows[0]["TglNota"], "").ToString();
                    txtCabang1.Text = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                    txtNoACC.Text = Tools.isNull(dt.Rows[0]["NoACC"], "").ToString();
                    lookupSales.SalesID = Tools.isNull(dt.Rows[0]["KodeSales"], "").ToString();
                    lookupSales.NamaSales = Tools.isNull(dt.Rows[0]["NamaSales"], "").ToString();
                    txtExpedisi.Text = Tools.isNull(dt.Rows[0]["Expedisi"], "").ToString();
                    txtQtyNota.Text = Tools.isNull(dt.Rows[0]["QtySuratJalan"], "").ToString();
                    txtQtyReturSebelumnya.Text = Tools.isNull(dt.Rows[0]["QtyRetur"], "").ToString();
                    txtQtyMemo.Text = Tools.isNull(dt.Rows[0]["QtyMemo"], "").ToString();
                    txtQtyTarik.Text = Tools.isNull(dt.Rows[0]["QtyTarik"], "").ToString();
                    txtQtyGudang.Text = Tools.isNull(dt.Rows[0]["QtyGudang"], "").ToString();
                    txtQtyTerima.Text = Tools.isNull(dt.Rows[0]["QtyTerima"], "").ToString();

                    txtPotNota.Text = Tools.isNull(dt.Rows[0]["Pot"], 0).ToString();
                    txtPotRetur.Text = Tools.isNull(dt.Rows[0]["Pot"], 0).ToString();
                    txtDisc1.Text = Tools.isNull(dt.Rows[0]["Disc1"], 0).ToString();
                    txtDisc2.Text = Tools.isNull(dt.Rows[0]["Disc2"], 0).ToString();
                    txtDisc3.Text = Tools.isNull(dt.Rows[0]["Disc3"], 0).ToString();
                    cboKategori.SelectedValue = Tools.isNull(dt.Rows[0]["Kategori"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan1"], "").ToString();

                    /* Display ver Retur */
                    txtHrgJualRetur.Text = Tools.isNull(dt.Rows[0]["HrgJual"], "").ToString();
                    txtJmlHrgRetur.Text = (txtQtyTarik.GetIntValue * double.Parse(txtHrgJualRetur.Text)).ToString();
                    txtJmlNetRetur.Text = Tools.isNull(dt.Rows[0]["HrgNetto"], "").ToString();

                    /* Display ver Nota */
                    _disc1 = double.Parse(txtDisc1.Text);
                    _disc2 = double.Parse(txtDisc2.Text); // (double)(Tools.isNull(dt.Rows[0]["Disc2"], 0));
                    _disc3 = double.Parse(txtDisc3.Text); //double.Parse(Tools.isNull(dt.Rows[0]["Disc3"], 0).ToString());
                    _discFormula = Tools.isNull(dt.Rows[0]["DiscFormula"], "").ToString();
                    _pot = double.Parse(txtPotRetur.Text);
                    if (cboKodeRetur.SelectedValue.ToString() == "1")
                    {
                        txtHrgJualNota.Text = txtHrgJualRetur.Text;
                        txtJmlHrgNota.Text = txtJmlHrgRetur.Text;
                        txtJmNetlNota.Text =  (HitungNet3Disc(double.Parse(txtJmlHrgNota.Text))
                            - (txtQtyTarik.GetIntValue * _pot)).ToString();
                    }                    

                    /* Untuk update hanya ACC yang bisa di edit */
                    cboKodeRetur.Enabled = false;
                    lookupStock.Enabled = false;
                    txtNoNota.Enabled = false;
                    txtTglNota.Enabled = false;
                    lookupSales.Enabled = false;
                    txtQtyMemo.Enabled = false;
                    txtQtyTarik.Enabled = false;
                    txtHrgJualRetur.Enabled = false;
                    txtHrgJualRetur.Enabled = false;
                    txtPotRetur.Enabled = false;
                    cboKategori.Enabled = false;
                    txtCatatan.Enabled = false;
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

        private double HitungNet3Disc(double hrgBruto)
        {
            double hrgNet3Disc = 0;
            if (_discFormula == null)
                _discFormula = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, hrgBruto));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));                    
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default; 
            }

            return hrgNet3Disc;
        }

        /*------------------------------------------------------------------------*/
        // Pengecekan Barang untuk Kode Retur "Murni" //

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            InitVar();
            CheckBarang();
        }

        private void lookupStock_Validating(object sender, CancelEventArgs e)
        {
            if (lookupStock.BarangID == "[CODE]" || lookupStock.BarangID == "")
            {
                lookupStock.Focus(); 
            }
        }

        private void CheckBarang()
        {
            _namaBarang = lookupStock.NamaStock;
            if (cboKodeRetur.SelectedValue.ToString() == "1" && lookupStock.BarangID != "[CODE]" && lookupStock.BarangID != string.Empty)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtStok = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_HistoryPenjualanForRetur_SEARCH_2]"));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                        db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, _cabang1));
                        db.Commands[0].Parameters.Add(new Parameter("@tglMemo", SqlDbType.VarChar, _tglMemo));
                        dtStok = db.Commands[0].ExecuteDataTable();
                    }

                    if (dtStok.Rows.Count == 0)
                    {
                        ClearLookUpStok();
                        MessageBox.Show("Tidak ada barang tersebut");
                        lookupStock.Focus();
                        return;
                    }
                    else if (dtStok.Rows.Count == 1)
                    {
                        _historyJualRow = dtStok.Rows[0];
                        //ChekSisaRetur();
                    }
                    else
                    {
                        ShowHistoryPenjualanDialogForm(dtStok);
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

                if (_historyJualRow != null)
                {
                    /*Validasi*/
                    if (Tools.isNull(_historyJualRow["Keterangan"], "").ToString() == "PENDING")
                    {
                       MessageBox.Show("Nota Untuk Barang ini Sedang Dalam Proses Pengajuan Potongan !!!");
                       _historyJualRow = null;
                       lookupStock.BarangID = "";
                       lookupStock.NamaStock = "";
                       lookupStock.Focus();
                       return;
                    }

                    string tglnota = _historyJualRow["TglNota"].ToString();

                    txtSatuan.Text = lookupStock.Satuan;
                    txtNoNota.Text = Tools.isNull(_historyJualRow["NoNota"], "").ToString();
                    if (tglnota != "")
                    {
                        txtTglNota.DateValue = (DateTime)_historyJualRow["TglNota"];
                    }
                    txtCabang1.Text = Tools.isNull(_historyJualRow["Cabang1"], "").ToString();
                    lookupSales.SalesID = Tools.isNull(_historyJualRow["KodeSales"], "").ToString();
                    lookupSales.NamaSales = Tools.isNull(_historyJualRow["NamaSales"], "").ToString();
                    txtExpedisi.Text = Tools.isNull(_historyJualRow["Expedisi"], "").ToString();
                    txtQtyNota.Text = Tools.isNull(_historyJualRow["QtyNota"], "0").ToString();
                    txtQtyReturSebelumnya.Text = Tools.isNull(_historyJualRow["QtyRetur"], 0).ToString();
                    double _qtyMemo = double.Parse(txtQtyNota.Text) - double.Parse(txtQtyReturSebelumnya.Text);
                    
                    txtQtyMemo.Text = _qtyMemo.ToString();
                    txtQtyTarik.Text = _qtyMemo.ToString();

                    txtPotRetur.Text = Tools.isNull(_historyJualRow["Pot"], 0).ToString();
                    txtPotNota.Text = Tools.isNull(_historyJualRow["Pot"], 0).ToString();
                    txtDisc1.Text = Tools.isNull(_historyJualRow["Disc1"], 0).ToString();
                    txtDisc2.Text = Tools.isNull(_historyJualRow["Disc2"], 0).ToString();
                    txtDisc3.Text = Tools.isNull(_historyJualRow["Disc3"], 0).ToString();

                    _disc1 = double.Parse(txtDisc1.Text);
                    _disc2 = double.Parse(txtDisc1.Text);
                    _disc3 = double.Parse(txtDisc1.Text);
                    _discFormula = Tools.isNull(_historyJualRow["DiscFormula"], "").ToString();
                    _pot = double.Parse(txtPotRetur.Text);

                    /* Versi Retur */
                    txtHrgJualRetur.Text = Tools.isNull(_historyJualRow["HrgJualRetur"], "").ToString();
                    txtJmlHrgRetur.Text = (txtHrgJualRetur.GetDoubleValue * double.Parse(txtQtyTarik.Text)).ToString();
                    txtJmlNetRetur.Text = (HitungNet3Disc(double.Parse(txtJmlHrgRetur.Text))
                        - (txtQtyNota.GetIntValue * _pot)).ToString();

                    /* Versi Nota */
                    txtHrgJualNota.Text = _historyJualRow["HrgJual"].ToString();
                    txtJmlHrgNota.Text = (txtHrgJualNota.GetDoubleValue * double.Parse(txtQtyNota.Text)).ToString();
                    txtJmNetlNota.Text = (HitungNet3Disc(double.Parse(txtJmlHrgNota.Text))
                        - (txtQtyNota.GetIntValue * _pot)).ToString();

                    /*Tambahan*/
                    QtyNota_ = Convert.ToInt32(_historyJualRow["QtyNota"].ToString());
                    QtyMemo_ = Convert.ToInt32(_historyJualRow["QtyMemo"].ToString());
                    QtySisa_ = Convert.ToInt32(_historyJualRow["QtySisa"].ToString());
                    txtQtyMemo.Text = QtySisa_.ToString();
                    txtQtyMemo.Focus();
                    txtQtyMemo.SelectAll();

                }
            }
        }

        private void ShowHistoryPenjualanDialogForm(DataTable dt)
        {
            frmHistoryPenjualanForReturBrowse ifrmDialog = new frmHistoryPenjualanForReturBrowse(dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetHistoryPenjualanDialogResult(ifrmDialog);
                //ChekSisaRetur();
            }
        }

        private void GetHistoryPenjualanDialogResult(frmHistoryPenjualanForReturBrowse dialogForm)
        {
            _historyJualRow = dialogForm.SelecetedRow;
        }

        private void ClearLookUpStok()
        {
            lookupStock.RowID = new Guid();
            lookupStock.BarangID = "";
            lookupStock.NamaStock = "";
            lookupStock.Satuan = "";
            _namaBarang = "";
        }
       
        private void ChekSisaRetur()
        {

        }

        private bool SisaRetur()
        {
            bool sisa=true;
            if (cboKodeRetur.SelectedValue.ToString() == "1")
            {
                if (QtySisa_ >= txtQtyMemo.GetIntValue && QtySisa_!=0)
                {
                    sisa = false;
                }
            }
            return sisa;
        }
        /*------------------------------------------------------------------------*/

        private bool CekACCRetur()
        {
            DateTime tglTerima, tglRQRetur, tgl;
            double selisihHari;

            tglTerima = (DateTime)_historyJualRow["TglTerima"];
            tglRQRetur = (DateTime)dt.Rows[0]["TglRQRetur"];
            tgl = DateTime.Parse("01/08/2004");

            TimeSpan ts = tglRQRetur.Subtract(tglTerima);
            selisihHari = ts.TotalDays;

            if (tglTerima >= tgl && selisihHari > 30.0)
                return true;
            else
                return false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            { return; }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        string _recID = Tools.CreateFingerPrint();
                        string _noACC = "";                        
                        
                        if (cboKodeRetur.SelectedValue.ToString() == "1")
                        {
                            //tutup 23/01/2016 
                            //if (CekACCRetur())
                            //    _noACC = "XXXXXX";

                            // Insert new detail untuk Retur Murni
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, _historyJualRow["NotaJualDetailID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recID));
                                db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, _historyJualRow["NotaJualDetailRecID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, cboKodeRetur.SelectedValue.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, txtQtyMemo.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, txtQtyTarik.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyTerima.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, cboKategori.SelectedValue.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, txtHrgJualRetur.GetDoubleValue));
                                //db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, txtJmlNetRetur.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, lookupStock.BarangID));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, _noACC));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }
                        }
                        else
                        {
                            // Insert new detail untuk retur Tarikan
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanTarikanDetail_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["RowID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recID));
                                db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaAsal", SqlDbType.VarChar, txtNoNota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, cboKodeRetur.SelectedValue.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, lookupSales.SalesID));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, txtQtyMemo.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, txtQtyTarik.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyTerima.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, double.Parse(txtPotRetur.Text)));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, cboKategori.SelectedValue.ToString()));
                                db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, txtHrgJualRetur.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, _noACC));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }
                        }
                        break;
                    case enumFormMode.Update:
                        if (cboKodeRetur.SelectedValue.ToString() == "1")
                        {
                            // Update detail untuk retur Murni
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["HeaderID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, dt.Rows[0]["NotaJualDetailID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dt.Rows[0]["RecordID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, dt.Rows[0]["NotaJualDetailRecID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dt.Rows[0]["KodeRetur"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dt.Rows[0]["QtyMemo"]));
                                
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dt.Rows[0]["QtyTarik"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, dt.Rows[0]["QtyTerima"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dt.Rows[0]["QtyGudang"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dt.Rows[0]["QtyTolak"]));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dt.Rows[0]["Catatan1"]));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dt.Rows[0]["Catatan2"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dt.Rows[0]["Kategori"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dt.Rows[0]["KodeGudang"]));
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                /**/
                                db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dt.Rows[0]["HrgJual"]));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"]));
                                /**/
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Update detail untuk retur Tarikan
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_ReturPenjualanTarikanDetail_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["HeaderID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dt.Rows[0]["RecordID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@notaAsal", SqlDbType.VarChar, dt.Rows[0]["NotaAsal"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dt.Rows[0]["KodeRetur"]));
                                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dt.Rows[0]["KodeSales"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dt.Rows[0]["QtyMemo"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dt.Rows[0]["QtyTarik"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, dt.Rows[0]["QtyTerima"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, dt.Rows[0]["QtyGudang"]));
                                db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dt.Rows[0]["QtyTolak"]));
                                db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dt.Rows[0]["HrgJual"]));
                                db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dt.Rows[0]["Pot"]));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dt.Rows[0]["Catatan1"]));
                                db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dt.Rows[0]["Catatan2"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dt.Rows[0]["Kategori"]));
                                db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dt.Rows[0]["KodeGudang"]));
                                db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
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

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (formMode == enumFormMode.New)
            {
                // Nama barang tidak boleh kosong
                // Nama barang tidah boleh beda dari text nama barang 
                //  (harus ada di daftar stok)
                if (lookupStock.NamaStock == "")
                {
                    errorProvider1.SetError(lookupStock, "Barang tidak boleh kosong.");
                    valid = false;
                }
                if (_namaBarang != lookupStock.NamaStock)
                {
                    errorProvider1.SetError(lookupStock, "Nama barang tidak valid");
                    valid = false;
                }

                // Qty Memo Tidak boleh kosong
                int _qtyMemo = txtQtyMemo.GetIntValue;
                if (_qtyMemo == 0)
                {
                    errorProvider1.SetError(txtQtyMemo, "Qty Memo tidak boleh kosong");
                    valid = false;
                }

                // Qty Tarik tidak boleh kosong
                int _qtyTarik = txtQtyTarik.GetIntValue;
                if (_qtyTarik == 0)
                {
                    errorProvider1.SetError(txtQtyTarik, "Qty Tarik tidak boleh kosong");
                    valid = false;
                }

                // Check untuk quantity retur
                double sisaQty = double.Parse(txtQtyNota.Text) - double.Parse(txtQtyReturSebelumnya.Text); ;
                if (double.Parse(txtQtyTarik.Text) > sisaQty && sisaQty > 0)
                {
                    errorProvider1.SetError(txtQtyTarik, "Jumlah max harus " + sisaQty);
                    valid = false;
                }

                //Check QtyNota VS QtyMemo
                if (cboKodeRetur.SelectedValue.ToString() == "1")
                {
                    if (SisaRetur() == true)
                    {
                        errorProvider1.SetError(txtQtyMemo, "Jumlah Retur Tidak Boleh Dari Jumlah Nota :" + QtyNota_.ToString() + ", Sisa Max : " + QtySisa_.ToString());
                        valid = false;
                    }
                }

                if (txtNoNota.Text.Trim() == "")
                {

                    errorProvider1.SetError(txtNoNota, "NoNota Harus di ISI !!");
                        valid = false;
                    
                }

                if (lookupSales.SalesID == "" || lookupSales.SalesID=="[CODE]")
                {

                    errorProvider1.SetError(lookupSales, "Sales Harus di ISI !!");
                    valid = false;

                }

                //if (txtHrgJualRetur.GetDoubleValue<=0)
                //{
                //    errorProvider1.SetError(txtHrgJualRetur, " Harus di ISI Lebih Besar dari 0!!");
                //    valid = false;
                //}

                if (Tools.isNull(txtCatatan.Text, "").ToString() == "")
                {
                    errorProvider1.SetError(txtCatatan, "Catatan masih kosong");
                    valid = false;
                }
            }

            return valid;
        }

        private void lookupNotaJualDetail_SelectData(object sender, EventArgs e)
        {

        }

        private void txtQtyMemo_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyMemo.Text == "")
            {
                txtQtyMemo.Text = "0";
            }

            if (cboKodeRetur.SelectedValue.ToString() == "1" && lookupStock.BarangID!="[CODE]" && lookupStock.BarangID!="")
            {
                if (SisaRetur() == true)
                {
                    errorProvider1.SetError(txtQtyMemo, "Jumlah Retur Tidak Boleh Dari Jumlah Nota :" + QtyNota_.ToString() + ", Sisa Max : " + QtySisa_.ToString());
                    txtQtyMemo.Focus();
                }
            }

        }

        private void txtQtyTarik_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyTarik.Text == "")
            {
                txtQtyTarik.Text = "0";
            }
            UpdateFieldHitungan();            
        }

        private void txtHrgJualRetur_Validating(object sender, CancelEventArgs e)
        {
            if (txtHrgJualRetur.Text == "")
            {
                txtHrgJualRetur.Text = "0";
            }
            UpdateFieldHitungan();
        }

        private void txtPotRetur_Validating(object sender, CancelEventArgs e)
        {
            if (txtPotRetur.Text == "")
            {
                txtPotRetur.Text = "0";
            }
            _pot = double.Parse(txtPotRetur.Text);
            UpdateFieldHitungan();
        }

        private void UpdateFieldHitungan()
        {
            // Update field jml harga dan harga net
            if (cboKodeRetur.SelectedValue.ToString() == "1")
            {
                txtJmlHrgRetur.Text = (double.Parse(txtHrgJualRetur.Text) * txtQtyTarik.GetIntValue).ToString();
                txtJmlNetRetur.Text = (HitungNet3Disc(double.Parse(txtJmlHrgRetur.Text))
                            - (txtQtyTarik.GetIntValue * _pot)).ToString();
            }
            else
            {
                txtJmlHrgRetur.Text = (double.Parse(txtHrgJualRetur.Text) * txtQtyTarik.GetIntValue).ToString();
                txtJmlNetRetur.Text = ((double.Parse(txtHrgJualRetur.Text) * txtQtyTarik.GetIntValue) -
                         -(txtQtyTarik.GetIntValue * double.Parse(txtPotRetur.Text))).ToString();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMPRDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMPRBrowser)
                {
                    frmMPRBrowser frmCaller = (frmMPRBrowser)this.Caller;
                    frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                    frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }

        private void ClearField()
        {            
            txtHrgJualNota.Text = "0";
            txtJmlHrgNota.Text = "0";
            txtPotNota.Text = "0";
            txtJmNetlNota.Text = "0";
            txtDisc1.Text = "0";
            txtDisc2.Text = "0";
            txtDisc3.Text = "0";
            txtPotRetur.Text = "0";
            txtHrgJualRetur.Text = "0";
            txtJmlHrgRetur.Text = "0";
            txtJmlNetRetur.Text = "0";
        }

        private void cboKodeRetur_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearField();

            if (cboKodeRetur.SelectedValue.ToString() == "1")
            {
                txtNoNota.Enabled = false;
                lookupSales.Enabled = false;
                txtHrgJualRetur.Enabled = false;
                txtPotRetur.Enabled = false;
            }
            else
            {
                txtNoNota.Enabled = true;
                lookupSales.Enabled = true;
                txtHrgJualRetur.Enabled = true;
                txtPotRetur.Enabled = true;
            }
            CheckBarang();
        }

        private void txtBarcode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_STOK_STOKBARCODE_SEARCH2"));
                    db.Commands[0].Parameters.Add(new Parameter("@katakunci", SqlDbType.VarChar, txtBarcode.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (int.Parse(Tools.isNull(dt.Rows.Count, 0).ToString()) > 0)
                    {
                        lookupStock.NamaStock = dt.Rows[0]["NamaStok"].ToString();
                        lookupStock.BarangID = dt.Rows[0]["BarangID"].ToString();
                        lookupStock.Satuan = dt.Rows[0]["SatJual"].ToString();

                        InitVar();
                        CheckBarang();

                    }
                    else
                    {
                        MessageBox.Show("Tidak ketemu di StokBarcode");

                    }

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
    }
}
