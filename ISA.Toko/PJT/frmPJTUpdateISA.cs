using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.PJT
{
    public partial class frmPJTUpdateISA : ISA.Toko.BaseForm
    {
        DataTable dtNota, dtNotaDetail;
        Guid _rowID;

        public frmPJTUpdateISA(Form caller ,Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmPJTUpdateISA_Load(object sender, EventArgs e)
        {
            this.Title = "Link Data ke Piutang";
            this.Text = "PJT";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtNota = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[1].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                    dtNotaDetail = db.Commands[1].ExecuteDataTable();

                }

                // Display data
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

                txtRpJual3.Text = Tools.isNull(dtNota.Rows[0]["RpJual3"], "0").ToString();
                txtRpNet3.Text = Tools.isNull(dtNota.Rows[0]["RpNet3"], "0").ToString();
                txtDisc1.Text = Tools.isNull(dtNota.Rows[0]["Disc1"], "0").ToString();
                txtDisc2.Text = Tools.isNull(dtNota.Rows[0]["Disc2"], "0").ToString();
                txtDisc3.Text = Tools.isNull(dtNota.Rows[0]["Disc3"], "0").ToString();
                txtJnsTrans.Text = Tools.isNull(dtNota.Rows[0]["TransactionType"], "").ToString();
                txtHrKredit.Text = Tools.isNull(dtNota.Rows[0]["HariKredit"], "0").ToString();
                txtHrKirim.Text = Tools.isNull(dtNota.Rows[0]["HariKirim"], "0").ToString();
                txtHrSelesai.Text = Tools.isNull(dtNota.Rows[0]["HariSales"], "0").ToString();
                txtCat1.Text = Tools.isNull(dtNota.Rows[0]["Cat1"], "").ToString();
                txtCat2.Text = Tools.isNull(dtNota.Rows[0]["Cat2"], "").ToString();
                txtCat3.Text = Tools.isNull(dtNota.Rows[0]["Cat3"], "").ToString();
                txtCat4.Text = Tools.isNull(dtNota.Rows[0]["Cat4"], "").ToString();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (MessageBox.Show("Data Akan disimpan..??", "WARNING") == DialogResult.OK)
            {
                try
                {
                    DateTime tglJT = HitungTglJatuhTempo();
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        int i = 0;
                        // Update Detail Nota: Proses memindahkan QtySJ ke QtyNota
                        for (i = 0; i < dtNotaDetail.Rows.Count; i++)
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE"));
                            db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[i]["RowID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtNotaDetail.Rows[i]["RecordID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[i]["HeaderID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtNotaDetail.Rows[i]["HtrID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[i]["DOID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[i]["DODetailID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, dtNotaDetail.Rows[i]["QtySuratJalan"]));
                            // Copy QtySJ ke QtyNota
                            db.Commands[i].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtNotaDetail.Rows[i]["BarangID"]));
                            db.Commands[i].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtNotaDetail.Rows[i]["HrgJual"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtNotaDetail.Rows[i]["Disc1"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtNotaDetail.Rows[i]["Disc2"]));
                            db.Commands[i].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtNotaDetail.Rows[i]["Disc3"]));
                            db.Commands[i].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtNotaDetail.Rows[i]["DiscFormula"]));
                            db.Commands[i].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtNotaDetail.Rows[i]["Pot"]));
                            db.Commands[i].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtNotaDetail.Rows[i]["KodeGudang"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, dtNotaDetail.Rows[i]["QtySuratJalan"]));
                            db.Commands[i].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, dtNotaDetail.Rows[i]["QtyKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, dtNotaDetail.Rows[i]["KoliAwal"]));
                            db.Commands[i].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, dtNotaDetail.Rows[i]["KoliAkhir"]));
                            db.Commands[i].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dtNotaDetail.Rows[i]["NoKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtNotaDetail.Rows[i]["Catatan"]));
                            db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[i].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dtNotaDetail.Rows[i]["KetKoli"]));
                            db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }

                        // Update header: update TglTerima dan Jenis Transaksi
                        i = db.Commands.Count;
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE"));
                        db.Commands[i].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["RowID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtNota.Rows[0]["HtrID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["DOID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTglTerima.DateValue));
                        db.Commands[i].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, dtNota.Rows[0]["TglSerahTerimaChecker"]));
                        db.Commands[i].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtNota.Rows[0]["Cabang1"]));
                        db.Commands[i].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtNota.Rows[0]["Cabang2"]));
                        db.Commands[i].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtNota.Rows[0]["Cabang3"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtNota.Rows[0]["KodeSales"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtNota.Rows[0]["KodeToko"]));
                        db.Commands[i].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtNota.Rows[0]["alamatKirim"]));
                        db.Commands[i].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, dtNota.Rows[0]["Kota"]));
                        db.Commands[i].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtNota.Rows[0]["isClosed"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtNota.Rows[0]["Cat1"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtNota.Rows[0]["Cat2"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, txtCat3.Text));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, dtNota.Rows[0]["Cat4"]));
                        db.Commands[i].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, dtNota.Rows[0]["Cat5"]));
                        db.Commands[i].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, "1"));
                            //dtNota.Rows[0]["LinkID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtNota.Rows[0]["NPrint"]));
                        db.Commands[i].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, dtNota.Rows[0]["Checker1"]));
                        db.Commands[i].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, dtNota.Rows[0]["Checker2"]));
                        db.Commands[i].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, txtJnsTrans.Text));
                        db.Commands[i].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, 0));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        if (dtNota.Rows[0]["Cabang1"].ToString() == GlobalVar.CabangID)
                        {
                            // Proses link ke piutang
                            i = db.Commands.Count;
                            db.Commands.Add(db.CreateCommand("[psp_PJT_LinkToPiutang_ISA]"));
                            db.Commands[i].Parameters.Add(new Parameter("@notaID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[i].Parameters.Add(new Parameter("@tglJatuhTempo", SqlDbType.DateTime, tglJT));
                            db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        }

                        db.BeginTransaction();
                        for (i = 0; i < db.Commands.Count; i++)
                        {
                            db.Commands[i].ExecuteNonQuery();
                        }
                        db.CommitTransaction();
                    }

                    PJT.frmPembayaranTunaiUpdateISA ifrmChild = new PJT.frmPembayaranTunaiUpdateISA(this, _rowID);
                    ifrmChild.ShowDialog();

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
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, 0));
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

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (txtJnsTrans.Text == "")
            {
                errorProvider1.SetError(txtJnsTrans, "Jenis Transaksi tidak boleh kosong");
                valid = false;
            }
            else
            {
                /***********************************************************
                 * Jenis Transaksi pada PJT Hanya tunai ("T") yang valid.
                 * Sekiranya, pada awalnya jenis transaksi adalah kredit
                 * di PJT ini harus di rubah manjadi Tunai.
                 * Dan tidak diperbolehkan adanya perubahan 
                 * pada character kedua pada jenis transaksi.
                 ***********************************************************/
                string jnsTransTunai = "T" + dtNota.Rows[0]["TransactionType"].ToString().Substring(1, 1);
                if (txtJnsTrans.Text != jnsTransTunai)
                {
                    errorProvider1.SetError(txtJnsTrans, "Jenis Transaksi harus " + jnsTransTunai);
                    valid = false;
                }
            }

            return valid;
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPJTUpdateISA_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                 if (this.Caller is frmPJTBrowserISA)
                    {
                        frmPJTBrowserISA frmCaller = (frmPJTBrowserISA)this.Caller;
                        frmCaller.RefreshRowDataNotaJual(_rowID.ToString());
                    }
                
            }
        }
    }
}
