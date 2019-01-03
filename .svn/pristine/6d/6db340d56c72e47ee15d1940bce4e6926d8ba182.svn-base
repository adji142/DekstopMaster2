using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmIndenSuperDetailUpdate : ISA.Finance.BaseForm
    {
        Guid RowIDI, RowIDID, RowIDISD, RowIDISSD, RowIDOrderPenjualan;
        DateTime tglJTGiro, tglBPP;
        DateTime TglDO;
        DataTable dtNota, dtIDWil;
        string RecordID;
        string kodeToko, noReg, chbg, noBukti, noBPP, noGiro, noACC, namaBank, RpInden, HRecordID, totalNominal;
        string _HrecordID = "";
        string NoDO;
        public frmIndenSuperDetailUpdate(Form caller, DataTable dtNota, string kodeToko, string noReg, Guid RowIDI, Guid RowIDID, Guid RowIDISD, DateTime tglJTGiro, string chbg, string noBukti, string noBPP, string noGiro, string noACC, string namaBank, string RpInden, string hRecordID, string totalNominal, DateTime tglBPP, Guid RowIDOrderPenjualan, string noDO, DateTime tglDO)
        {
            InitializeComponent();
            this.kodeToko = kodeToko;
            this.noReg = noReg;
            this.RowIDI = RowIDI;
            this.RowIDID = RowIDID;
            this.RowIDISD = RowIDISD;
            this.tglJTGiro = tglJTGiro;
            this.chbg = chbg;
            this.noBukti = noBukti;
            this.noBPP = noBPP;
            this.noGiro = noGiro;
            this.noACC = noACC;
            this.namaBank = namaBank;
            this.RpInden = RpInden;
            this.HRecordID = hRecordID;
            this.totalNominal = totalNominal;
            this.tglBPP = tglBPP;
            this.Caller = caller;
            this.dtNota = dtNota.Copy();
            this.RowIDOrderPenjualan = RowIDOrderPenjualan;
            this.NoDO = noDO;
            this.TglDO = tglDO;
            
        }

        private void frmIndenSuperDetailUpdate_Load(object sender, EventArgs e)
        {
            lookupNotaPiutang1.KodeToko = kodeToko;
            lookupNotaPiutang1.NoReg = noReg;
            tbTglInden.DateValue = DateTime.Today;
            tbRpInden.Text = RpInden;
        }

        private void lookupNotaPiutang1_Leave(object sender, EventArgs e)
        {
            if (lookupNotaPiutang1.KPID != Guid.Empty)
            {
                tbRpNota.Text = lookupNotaPiutang1.RpNota;
                tbRpTagih.Text = lookupNotaPiutang1.RpTagih;
                tbTglJTempo.DateValue = Convert.ToDateTime(lookupNotaPiutang1.TglJTempo);
                tbRpInden.Focus();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (RowIDOrderPenjualan != Guid.Empty && RowIDOrderPenjualan != lookupNotaPiutang1.RowIDOrderPenjualan)
            {
                MessageBox.Show("Tidak bisa identifikasi Nota. Penerimaan uang harus diidentifikasi ke nota dengan relasi sesuai sesuai SO inden no. " + NoDO + " tgl " + TglDO.ToString("dd/MM/yyyy") + ". Hubungi manager anda.");
                lookupNotaPiutang1.Focus();
                return;
            }

            if (lookupNotaPiutang1.KPID == Guid.Empty)
            {
                MessageBox.Show("No Nota Belum Diisi");
                lookupNotaPiutang1.Focus();
                return;
            }
            if (tbRpTagih.GetDoubleValue < tbRpInden.GetDoubleValue)
            {
                MessageBox.Show("Jumlah Rp Inden Tidak Boleh Melebihi Tagihan(" + tbRpTagih.Text + ")");
                tbRpInden.Focus();
                return;
            }
            if (tbRpInden.GetDoubleValue > Convert.ToDouble(RpInden))
            {
                MessageBox.Show("Jumlah Rp Inden Tidak Boleh Melebihi Nilai Identifikasi (" + Convert.ToDouble(RpInden).ToString("#,###")+")");
                tbRpInden.Focus();
                return;
            }

            if (tbRpInden.GetDoubleValue ==0)
            {
                MessageBox.Show("Jumlah Rp Inden Tidak Boleh 0");
                tbRpInden.Focus();
                return;
            }

            DateTime _Tanggal = (DateTime)tbTglInden.DateValue;
            if (GlobalVar.Gudang != "2808")
            {
                //if (PeriodeClosing.IsPJTClosed(_Tanggal))
                //{
                //    MessageBox.Show("Sudah Closing!");
                //    return;
                //}
            }
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoIDWil"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dtIDWil = db.Commands[0].ExecuteDataTable();
            }

            string kodeTrn = "COL" + dtIDWil.Rows[0]["WilID"].ToString().Substring(0, 1);
            string dNoPerkiraan = Perkiraan.GetPerkiraanKoneksiDetail(kodeTrn).Rows[0]["NoPerkiraan"].ToString();

            RowIDISSD=Guid.NewGuid();
            RecordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);

            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();
                    //insert indensuperdetail

                    addIndenSuperDetail(db, RowIDISSD, RowIDISD, RowIDI, RowIDID, RecordID
                        , Tools.isNull(HRecordID,"").ToString(), lookupNotaPiutang1.TagihDetailID
                        , Tools.isNull(lookupNotaPiutang1.TagihDetailRecID,"").ToString(), lookupNotaPiutang1.KPID
                        , lookupNotaPiutang1.KPrecID,lookupNotaPiutang1.Jenis, tglBPP, noReg
                        , chbg, noBukti, (DateTime)tbTglInden.DateValue
                        , (DateTime)tbTglJTempo.DateValue, "", "", dNoPerkiraan
                        , tbRpInden.Text, tbRpNota.Text, tbRpTagih.Text);

                    if (lookupNotaPiutang1.Jenis == "KP")
                    {
                        insertKPiutangDetail(db);
                    }
                    else
                    {
                        insertGtolakDetail(db);
                    }

                    updateTagihanDetail(db);
                    if (GlobalVar.Gudang != "2803")
                    {
                        insertTagihanSubDetail(db);
                    }
                    db.CommitTransaction();
                }

                //tutup sementara
                frmPenerimaanBelumTeridentifikasiBrowse frm = new frmPenerimaanBelumTeridentifikasiBrowse();
                frm = (frmPenerimaanBelumTeridentifikasiBrowse)Caller;
                frm.IndenRowRefresh(RowIDI);
                frm.IndenDetailRowRefresh(RowIDID);
                frm.IndenSubDetailRowRefresh(RowIDISD);
                frm.IndenSuperDetailRowRefresh(RowIDISSD);
                frm.IndenSuperDetailFindRow("RowIDISSD", RowIDISSD.ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void addIndenSuperDetail(
                Database db,
                Guid RowID,
                Guid HeaderID,
                Guid IndenID,
                Guid IndenDetailID,
                string RecordID,
                string HRecordID,
                Guid TagihDetailID,
                string TagihDetailRecID,
                Guid KPID,
                string KPrecID,
                string Src,
                DateTime TglBPP,
                string NoReg,
                string Ref,
                string NoBukti,
                DateTime TglInden,
                DateTime TglJatuhTempo,
                string Kode,
                string Sub,
                string NoPerk,
                string RpInden,
                string RpNota,
                string RpTagih
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_IndenSuperDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@IndenID", SqlDbType.UniqueIdentifier, IndenID));
            db.Commands[0].Parameters.Add(new Parameter("@IndenDetailID", SqlDbType.UniqueIdentifier, IndenDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@TagihDetailID", SqlDbType.UniqueIdentifier, TagihDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@TagihDetailRecID", SqlDbType.VarChar, TagihDetailRecID));
            db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, KPID));
            db.Commands[0].Parameters.Add(new Parameter("@KPrecID", SqlDbType.VarChar, KPrecID));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Src));
            db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.VarChar, TglBPP));
            db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, NoReg));
            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Ref));
            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, NoBukti));
            db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.VarChar, TglInden));
            db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.VarChar, TglJatuhTempo));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, Sub));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerk", SqlDbType.VarChar, NoPerk));
            db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.VarChar, RpInden));
            db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.VarChar, RpNota));
            db.Commands[0].Parameters.Add(new Parameter("@RpTagih", SqlDbType.VarChar, RpTagih));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        private void insertKPiutangDetail(Database db)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
            string uraian = noBukti + "." + noBPP + "/" + chbg + ":" + totalNominal;

            if (GlobalVar.Gudang == "2803")
            {
                noACC = "-";
                noReg = "xxxxxxx";
            }

            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDISSD));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, lookupNotaPiutang1.KPID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, lookupNotaPiutang1.KPrecID));
            db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, (DateTime)tbTglInden.DateValue));
            db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, chbg));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, 0));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, tbRpInden.Text));
            db.Commands[0].Parameters.Add(new Parameter("@TglJTGiro", SqlDbType.DateTime, tglJTGiro));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, Tools.Right(noReg.Trim(),5)));
            db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, noGiro));
            db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, namaBank));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noACC));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();
        }

        private void insertGtolakDetail(Database db)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
            string uraian = noBukti + "." + noBPP + "/" + chbg + ":" + totalNominal;

            if (GlobalVar.Gudang == "2803")
            {
                noReg = "xxxxx";
                noACC = "-";
            }
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDISSD));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, lookupNotaPiutang1.KPID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.Right(RecordID.TrimEnd(),19)));
            db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.DateTime, (DateTime)tbTglInden.DateValue));
            db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, chbg));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, tbRpInden.Text));
            db.Commands[0].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.DateTime, tglJTGiro));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, Tools.Right(noReg.Trim(), 5)));
            db.Commands[0].Parameters.Add(new Parameter("@noBG", SqlDbType.VarChar, noGiro));
            db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, namaBank));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noACC));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, lookupNotaPiutang1.KPrecID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery(); 
 
        }

        private void updateTagihanDetail(Database db)
        {
            string keterangan = "IDENTIFIKASI PEMBAYARAN : ";
            if (tbRpTagih.Text == tbRpInden.Text)
                keterangan += noBukti;
            else
                keterangan += lookupNotaPiutang1.NoNota;

            keterangan += "  (" + tbRpInden.Text + ")";

            db.Commands.Clear();
            
            db.Commands.Add(db.CreateCommand("usp_TagihanDetail_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, lookupNotaPiutang1.TagihDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, (DateTime)tbTglInden.DateValue));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar,keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();
        }

        private void insertTagihanSubDetail(Database db)
        {
            string keterangan = "IDENTIFIKASI PEMBAYARAN : ";
            if (tbRpTagih.Text == tbRpInden.Text)
                keterangan += noBukti;
            else
                keterangan += lookupNotaPiutang1.NoNota;

            keterangan += "  (" + tbRpInden.Text + ")";

            db.Commands.Clear();

            db.Commands.Add(db.CreateCommand("usp_TagihanSubDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIDISSD));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, lookupNotaPiutang1.TagihDetailID));
            db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, (DateTime)tbTglInden.DateValue));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            //db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, lookupNotaPiutang1.TagihDetailRecID));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, tbRpInden.Text));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
            db.Commands[0].ExecuteNonQuery();
        }

        private void lookupNotaPiutang1_SelectData(object sender, EventArgs e)
        {
            if (lookupNotaPiutang1.KPID != Guid.Empty )
            {
                if(!cekNota())
                {
                    MessageBox.Show("Nota sudah pernah diidentifikasi pada sub ini.");
                    lookupNotaPiutang1.Focus();
                    return;
                }
                tbRpNota.Text = lookupNotaPiutang1.RpNota;
                tbRpTagih.Text = lookupNotaPiutang1.RpTagih;
                tbTglJTempo.DateValue = Convert.ToDateTime(lookupNotaPiutang1.TglJTempo);
                if ((Convert.ToDouble(RpInden) > tbRpTagih.GetDoubleValue))
                    tbRpInden.Text = lookupNotaPiutang1.RpTagih;

                tbRpInden.Focus();
            }
        }

        private bool cekNota()
        {
            bool nota = true;
            int jml=dtNota.Rows.Count;
            int i=0;
            while (i < jml && nota==true)
            {
                if (dtNota.Rows[i]["NoNota"].ToString() == lookupNotaPiutang1.NoNota)
                    nota = false;
                i++;
            }

            return nota;
        }
      
    }
}
