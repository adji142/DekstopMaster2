using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.Class;
using ISA.Common;

namespace ISA.Finance.PJ3
{
    public partial class frmPJ3Update : ISA.Controls.BaseForm
    {
        Guid _rowID;
        DataTable dtNota;
        int hariKredit = 0;
        string uraian = "";
        string cab1 = "", cab2 = "";
        int _hariSalesToko = 0, _hariKirimToko = 0;
        string NamaToko_ = "";
        string Sales_ = "";
        
        public frmPJ3Update(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmPJ3Update_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtNota = db.Commands[0].ExecuteDataTable();
                }

                // Display data
                cab1 = Tools.isNull(dtNota.Rows[0]["Cabang1"], "").ToString();
                cab2 = Tools.isNull(dtNota.Rows[0]["Cabang2"], "").ToString();
                txtKodeSales.Text = Tools.isNull(dtNota.Rows[0]["KodeSales"], "").ToString();
                txtNoRQ.Text = Tools.isNull(dtNota.Rows[0]["NoRequest"], "").ToString();
                txtNoDO.Text = Tools.isNull(dtNota.Rows[0]["NoDO"], "").ToString();
                txtNoNota.Text = Tools.isNull(dtNota.Rows[0]["NoNota"], "").ToString();
                txtNoSJ.Text = Tools.isNull(dtNota.Rows[0]["NoSuratJalan"], "").ToString();
                txtTglRQ.DateValue = (DateTime)dtNota.Rows[0]["TglRequest"];
                txtTglDO.DateValue = (DateTime)dtNota.Rows[0]["TglDO"];
                if (dtNota.Rows[0]["TglNota"].ToString() == string.Empty)
                {
                    txtTglNota.DateValue = DateTime.Now;
                }
                else
                {
                    txtTglNota.DateValue = (DateTime)dtNota.Rows[0]["TglNota"];
                }
                txtTglSJ.DateValue = (DateTime)dtNota.Rows[0]["TglSuratJalan"];

                txtNamaToko.Text = Tools.isNull(dtNota.Rows[0]["NamaToko"], "").ToString();
                txtAlamat.Text = Tools.isNull(dtNota.Rows[0]["AlamatKirim"], "").ToString();
                txtKota.Text = Tools.isNull(dtNota.Rows[0]["Kota"], "").ToString();
                txtExpedisi.Text = Tools.isNull(dtNota.Rows[0]["Expedisi"], "").ToString();
                DateTime tglTerima = new DateTime();
                if (!DateTime.TryParse(dtNota.Rows[0]["TglTerima"].ToString(), out tglTerima))
                {
                    txtTglTerima.DateValue = DateTime.Now;
                }
                else
                {
                    txtTglTerima.DateValue = (DateTime)dtNota.Rows[0]["TglTerima"];
                }
                txtRpJual2.Text = Tools.isNull(dtNota.Rows[0]["RpJual2"], "0").ToString();
                txtRpNet2.Text = Tools.isNull(dtNota.Rows[0]["RpNet2"], "0").ToString();

                txtRpJual3.Text = Tools.isNull(dtNota.Rows[0]["RpJual3"], "0").ToString();
                txtRpNet3.Text = Tools.isNull(dtNota.Rows[0]["RpNet3"], "0").ToString();
                txtDisc1.Text = Tools.isNull(dtNota.Rows[0]["Disc1"], "0").ToString();
                txtDisc2.Text = Tools.isNull(dtNota.Rows[0]["Disc2"], "0").ToString();
                txtDisc3.Text = Tools.isNull(dtNota.Rows[0]["Disc3"], "0").ToString();
                txtJnsTrans.Text = Tools.isNull(dtNota.Rows[0]["TransactionType"], "").ToString();
                txtHrKredit.Text = Tools.isNull(dtNota.Rows[0]["HariKredit"], "0").ToString();
                txtHrKirim.Text = Tools.isNull(dtNota.Rows[0]["HariKirim"], "0").ToString();
                txtHrSales.Text = Tools.isNull(dtNota.Rows[0]["HariSales"], "0").ToString();
                txtCat1.Text = Tools.isNull(dtNota.Rows[0]["Cat1"], "").ToString();
                txtCat2.Text = Tools.isNull(dtNota.Rows[0]["Cat2"], "").ToString();
                txtCat3.Text = Tools.isNull(dtNota.Rows[0]["Cat3"], "").ToString();
                txtCat4.Text = Tools.isNull(dtNota.Rows[0]["Cat4"], "").ToString();

                hariKredit = txtHrKredit.GetIntValue;

                if (hariKredit == 0)
                {
                    txtHrKredit.Enabled = false;
                    //txtHrKredit.Enabled = true;
                    txtHrKredit.ReadOnly = false;
                }
                else
                {
                    txtHrKredit.Enabled = false;
                    txtHrKredit.ReadOnly = true;
                }

                using (Database db = new Database())
                {
                    DataTable dtToko = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtNota.Rows[0]["KodeToko"]));
                    dtToko = db.Commands[0].ExecuteDataTable();
                    _hariSalesToko = int.Parse(Tools.isNull(dtToko.Rows[0]["HariSales"], "0").ToString());
                    _hariKirimToko = int.Parse(Tools.isNull(dtToko.Rows[0]["HariKirim"], "0").ToString());
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            
            if (txtJnsTrans.Text.Substring(0, 1) == "K")
            {
                //if (txtJnsTrans.Text.Substring(1, 1) != "K")
                    uraian = "PJK (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
                //else
                //    uraian = "PKK (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
            }

            if (txtJnsTrans.Text.Substring(0, 1) == "T")
            {
                //if (txtJnsTrans.Text.Substring(1, 1) == "K")
                    uraian = "PJT (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
                //else
                //    uraian = "PKT (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
            }

            NamaToko_ = Tools.isNull(dtNota.Rows[0]["NamaToko"], "").ToString().Trim();
            Sales_ = Tools.isNull(dtNota.Rows[0]["KodeSales"], "").ToString().Trim().Substring(7, 3);

            /***************************************************************
             * Code di bawah ini sudah tidak di pakai karena tidak ada lagi
             * karena PJ3 tidak lagi ada jenis transaksi berinitial "T"
             ***************************************************************/
            //else
            //{
            //    if (txtJnsTrans.Text.Substring(0, 1) == "T")
            //    {
            //        uraian = "PJT (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
            //        hariKredit = 3;
            //    }
            //    else
            //        uraian = "PENJUALAN (" + Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString() + ")";
            //}

            /* Isi TglTerima */
            try
            {
                if (GlobalVar.Gudang != "2808")
                {
                    if (txtTglTerima.DateValue <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    if (MessageBox.Show("Tgl Jatuh Tempo Nota ini: " + HitungTglJatuhTempo().ToString("dd-MMM-yyyy") + ", data akan disimpan?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IsiTglTerima();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        return;
                    }
                }
                else
                {
                    IsiTglTerima();
                }

                /* Proses link ke piutang */
                string cCab1 = Tools.isNull(dtNota.Rows[0]["Cabang1"], "").ToString().Trim();
                string cCab2 = Tools.isNull(dtNota.Rows[0]["Cabang2"], "").ToString().Trim();

                if (cCab1 == GlobalVar.Gudang && cCab2 == GlobalVar.Gudang)
                {
                    LinkKePiutang();
                }

                string _TK = txtJnsTrans.Text.ToString();
                /*kebijakan baru, link penjualan tunai di kembalikan ke penjualan tunai kasir*/
                //if (_TK.Substring(0, 1) == "T")
                //{
                //    /*tampil form pembayaran tunai*/
                //    if (dtNota.Rows[0]["Cabang1"].ToString() == GlobalVar.CabangID)
                //    {
                //        Finance.PJ3.frmPembayaranTunaiUpdate ifrmChild = new Finance.PJ3.frmPembayaranTunaiUpdate(this, _rowID);
                //        ifrmChild.ShowDialog();
                //        if (ifrmChild.DialogResult != DialogResult.OK)
                //        {
                //            return;
                //        }
                //    }

                //    //else
                //    //{
                //    //    MessageBox.Show("Penjualan PS / 91. Tidak Link Ke Kasir.");
                //    //}
                //}
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private bool ValidateInput()
        {
            bool valid = true;
            
            errorProvider1.Clear();

            if (txtTglTerima.Text == "")
            {
                errorProvider1.SetError(txtTglTerima, "Tgl terima harus diisi");
                valid = false;
            }
            if (txtTglTerima.Text != "" && txtTglTerima.DateValue.Value > GlobalVar.DateOfServer)
            {
                errorProvider1.SetError(txtTglTerima, "Tgl terima tidak boleh lebih besar dari tanggal hari ini.");
                valid = false;
            }
            if (txtTglTerima.Text != "" && txtTglTerima.DateValue.Value < txtTglSJ.DateValue.Value) {
                errorProvider1.SetError(txtTglTerima, "Tgl terima tidak boleh lebih kecil dari tgl SJ.");
                valid = false;
            }
            //if (txtTglTerima.Text != "" && txtTglTerima.DateValue.Value < dataGridNotaJual.)
            if (txtJnsTrans.Text == "")
            {
                errorProvider1.SetError(txtJnsTrans, "Jenis Transaksi tidak boleh kosong");
                valid = false;
            }
            else
            {
                /***********************************************************
                 * Jenis Transaksi pada PJ3 Hanya kredit ("K") yang valid.
                 * Sekiranya, pada awalnya jenis transaksi adalah tunai
                 * di PJ3 ini harus di rubah manjadi tunai.
                 * Dan tidak diperbolehkan adanya perubahan 
                 * pada character kedua pada jenis transaksi.
                 ***********************************************************/
                //Tutup sementara
                //if (NamaToko_ != "ECERAN CASH" || Sales_ != "VIA")
                //{
                //    string jnsTransKredit = "K" + dtNota.Rows[0]["TransactionType"].ToString().Substring(1, 1);
                //    if (txtJnsTrans.Text != jnsTransKredit)
                //    {
                //        MessageBox.Show("Dep4");
                //        errorProvider1.SetError(txtJnsTrans, "Jenis Transaksi harus " + jnsTransKredit);
                //        valid = false;
                //    }
                //}
            }

            //Tutup sementara
            //if (NamaToko_ != "ECERAN CASH" || Sales_ != "VIA")
            //{
            //    if (txtHrKredit.GetIntValue <= 0)
            //    {
            //        MessageBox.Show("Dep5");
            //        errorProvider1.SetError(txtHrKredit, "Penjualan kredit harus ada jangka waktu kreditnya.");
            //        valid = false;
            //    }
            //}
            return valid;
        }

        private void IsiTglTerima()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtNota.Rows[0]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["DOID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTglTerima.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, dtNota.Rows[0]["TglSerahTerimaChecker"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtNota.Rows[0]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtNota.Rows[0]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtNota.Rows[0]["Cabang3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtNota.Rows[0]["KodeSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtNota.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtNota.Rows[0]["alamatKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, dtNota.Rows[0]["Kota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtNota.Rows[0]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtNota.Rows[0]["Cat1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtNota.Rows[0]["Cat2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, dtNota.Rows[0]["Cat3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, dtNota.Rows[0]["Cat4"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, dtNota.Rows[0]["Cat5"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtNota.Rows[0]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtNota.Rows[0]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, dtNota.Rows[0]["Checker1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, dtNota.Rows[0]["Checker2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, txtJnsTrans.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, txtHrKredit.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, txtHrKirim.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, txtHrSales.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
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

        private void LinkKePiutang()
        {
            if (cab1 != GlobalVar.Gudang)
            {
                return;
            }
            string rpNet2 = dtNota.Rows[0]["RpNet2"].ToString();
            string rpJual2 = dtNota.Rows[0]["RpJual2"].ToString();
            string rpPot2 = dtNota.Rows[0]["RpPot2"].ToString();

            if (double.Parse(rpNet2) == 0 && (double.Parse(rpJual2) - double.Parse(rpPot2)) == 0)
            {
                MessageBox.Show("Nota Barang Bonus, tidak perlu dilink ke API");
                this.Close();
                return;
            }

            string rpNet3 = dtNota.Rows[0]["RpNet3"].ToString();
            if (double.Parse(rpNet3) == 0)
            {
                MessageBox.Show("Nilai Nota masih 0..!, Cek data dan link ulang ke API", "PERINGATAN");
                this.Close();
                return;
            }

            /* proses untuk link ke piutang (panggil psp) */
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_PJ3_LinkToPiutang_ISA"));
                    db.Commands[0].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, HitungTglJatuhTempo()));
                    db.Commands[0].Parameters.Add(new Parameter("@tipeLink", SqlDbType.VarChar, "1")); // TipeLink 1 untuk POS
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
                //MessageBox.Show("PROSES LINK KE PIUTANG BERHASIL...");
            }
        }

        private DateTime HitungTglJatuhTempo()
        {
            object tglJatuhTempo = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTglJatuhTempo"));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, txtJnsTrans.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTglTerima.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, txtHrKredit.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, txtHrKirim.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, txtHrSales.GetIntValue));
                    tglJatuhTempo = db.Commands[0].ExecuteScalar();
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
            return (DateTime)tglJatuhTempo;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void frmPJ3Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is Finance.PJ3.frmPJ3Browse)
                {
                    Finance.PJ3.frmPJ3Browse frmCaller = (Finance.PJ3.frmPJ3Browse)this.Caller;
                    frmCaller.RefreshRowDataNotaJual(_rowID.ToString());
                    //frmCaller.FindHeader("NotaRowID", _rowID.ToString());
                }
            }

        }
    }
}
