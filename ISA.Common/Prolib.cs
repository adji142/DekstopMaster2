using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using ISA.Common;

namespace ISA.Common
{
    public class Prolib
    {
        //gethargacte
        public static double GetHargaCTE(string barangID, string KodeToko, string JenisTransaksi)
        {
            double HargaCTE = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetHargaCTE"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, barangID));
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@JenisTransaksi", SqlDbType.VarChar, JenisTransaksi));
                HargaCTE = db.Commands[0].ExecuteNonQuery();
            }

            return HargaCTE;
        }

        //gethargaakhir
        public static DataTable GetHargaAkhir(string barangID, string KodeToko, string JenisTransaksi)
        {

            DataTable dtAkhir = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetHargaAkhir"));
                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@JenisTransaksi", SqlDbType.VarChar, JenisTransaksi));
                dtAkhir = db.Commands[0].ExecuteDataTable();
            }

            return dtAkhir;
        }

        //barang apa aja yang lagi promo
        public static DataTable DataPromoBarang(string idBarang)
        {
            DataTable dtPromoBarang = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoBarang"));
                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, idBarang));
                dtPromoBarang = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoBarang;

        }

        //barang bonus 
        public static DataTable DataPromoBarangBonus(int sumqtybarang, double sumhargabarang)
        {
            DataTable dtPromoBarangBonus = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoBarangBonus"));
                db.Commands[0].Parameters.Add(new Parameter("@sumqty", SqlDbType.Int, sumqtybarang));
                db.Commands[0].Parameters.Add(new Parameter("@sumharga", SqlDbType.Money, sumhargabarang));
                dtPromoBarangBonus = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoBarangBonus;

        }

        //batesan promo kelompok
        public static Boolean cekpromokelompok(string idbarang)
        {
            
           Boolean cekpromokelompok;
           if (idbarang.Substring(0, 3) == "FB2" || idbarang.Substring(0, 3) == "FB4" || idbarang.Substring(0, 3) == "FE2" || idbarang.Substring(0, 3) == "FE4")
           {
               cekpromokelompok = true;
           }
           else
           {
               return false;
           }

            return cekpromokelompok;

        }


        //promo kelompokbonus
        public static DataTable DataPromoKelompok(int sumqtyKelompok, double sumhargaKelompok)
        {
            DataTable dtPromoKelompok = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoKelompok"));
                db.Commands[0].Parameters.Add(new Parameter("@sumqty", SqlDbType.Int, sumqtyKelompok));
                db.Commands[0].Parameters.Add(new Parameter("@sumharga", SqlDbType.Money, sumhargaKelompok));
                dtPromoKelompok = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoKelompok;
        }

        //promo kelompokBengkel
        public static DataTable DataPromoBengkel(int sumqtyKelompok, double sumhargaKelompok, string pktService)
        {
            DataTable dtPromoBengkel = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoBengkel"));
                db.Commands[0].Parameters.Add(new Parameter("@sumqty", SqlDbType.Int, sumqtyKelompok));
                db.Commands[0].Parameters.Add(new Parameter("@sumharga", SqlDbType.Money, sumhargaKelompok));
                db.Commands[0].Parameters.Add(new Parameter("@PktService", SqlDbType.VarChar, pktService));
                dtPromoBengkel = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoBengkel;
            
        }

        /*promo kelompokBengkel service beli oli gratis busi*/
        public static DataTable DataPromoBengkelService()
        {
            DataTable dtPromoBengkelService = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoBengkelServiceOli"));
                dtPromoBengkelService = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoBengkelService;

        }

        public static DataTable DataPromoServiceBengkel(int sumqtyKelompok, double sumhargaKelompok)
        {
            DataTable dtPromoServiceBengkel = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoServiceBengkel"));
                db.Commands[0].Parameters.Add(new Parameter("@sumqty", SqlDbType.Int, sumqtyKelompok));
                db.Commands[0].Parameters.Add(new Parameter("@sumharga", SqlDbType.Money, sumhargaKelompok));
                dtPromoServiceBengkel = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoServiceBengkel;

        }

        //berlaku kelipatan
        public static Boolean Kelipatan(Guid RowIdPromoDetail)
        {
            Boolean CekKelipatan;
            DataTable dtKelipatan = new DataTable();
            using (Database db = new Database())
            {
                
                db.Commands.Add(db.CreateCommand("usp_cekPromoBerlakuKelipatan"));
                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, RowIdPromoDetail));
                dtKelipatan = db.Commands[0].ExecuteDataTable();

            }
            if (dtKelipatan.Rows.Count > 0)
            {
                CekKelipatan = true;
            }
            else
            {
                return false;
            }
            return CekKelipatan;

        }


        //HistoryPenjualan
        public static Boolean HistoryPenjualan(string KodeToko)
        {
            Boolean HistoryPenjualan;
            DataTable dtHistoryPenjualan = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_cekHistoryPenjualan"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
                dtHistoryPenjualan = db.Commands[0].ExecuteDataTable();

            }
            if (dtHistoryPenjualan.Rows.Count > 0)
            {
                HistoryPenjualan = true;
            }
            else
            {
                return false;
            }
            return HistoryPenjualan;

        }


        //Cek berlaku Akumulasi
        public static Boolean Akumulasi(Guid RowIdPromoDetail)
        {
            Boolean Akumulasi;
            DataTable dtAkumulasi = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_cekAkumulasiPromo"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIdPromoDetail));
                dtAkumulasi = db.Commands[0].ExecuteDataTable();

            }
            if (dtAkumulasi.Rows.Count > 0)
            {
                Akumulasi = true;
            }
            else
            {
                return false;
            }
            return Akumulasi;

        }

        //Ambil hari Akumulasi
        public static DataTable AmbilHari(Guid RowIdPromoDetail)
        {
            DataTable dthariAkumulasi = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cekAkumulasiPromo"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIdPromoDetail));
                dthariAkumulasi = db.Commands[0].ExecuteDataTable();
            }
            return dthariAkumulasi;
        }


        //Akumulasi Penjualan
        public static DataTable AkumulasiPenjualan(int hari, string kodetoko)
        {
            DataTable dtAkumulasiPenjualan = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_JumlahPenjualanAkumulasi"));
                db.Commands[0].Parameters.Add(new Parameter("@hari", SqlDbType.Int, hari));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodetoko));
                dtAkumulasiPenjualan = db.Commands[0].ExecuteDataTable();
            }

            return dtAkumulasiPenjualan;
        }


        //Cek berlaku blm ada history
        public static Boolean BelumAdaHistory(Guid RowIdPromoDetail)
        {
            Boolean BelumAdaHistory;
            DataTable dtBelumAdaHistory = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_cekBlmAdaHistory"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIdPromoDetail));
                dtBelumAdaHistory = db.Commands[0].ExecuteDataTable();

            }
            if (dtBelumAdaHistory.Rows.Count > 0)
            {
                BelumAdaHistory = true;
            }
            else
            {
                return false;
            }
            return BelumAdaHistory;

        }

        //cek history Penjualan toko
        public static DataTable HistJualToko(string kodetoko)
        {
            DataTable dtHistJualToko = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_cekAkumulasiPromo"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.UniqueIdentifier, kodetoko));
                dtHistJualToko = db.Commands[0].ExecuteDataTable();
            }

            return dtHistJualToko;
        }


        //Cek berlaku enduser
        public static Boolean Enduser(Guid RowIdPromoDetail)
        {
            Boolean Enduser;
            DataTable dtEnduser = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_cekBlmAdaHistory"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowIdPromoDetail));
                dtEnduser = db.Commands[0].ExecuteDataTable();

            }
            if (dtEnduser.Rows.Count > 0)
            {
                Enduser = true;
            }
            else
            {
                return false;
            }
            return Enduser;

        }



        #region promo tagihan
        // belum pernah dapet promo 
        public static Boolean CekHistPromo(string kodeToko)
        {
            Boolean HistPromo;
            DataTable dtHistPromo = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_PromoTagihanAda"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, DateTime.Today));
                dtHistPromo = db.Commands[0].ExecuteDataTable();

            }
            if (dtHistPromo.Rows.Count == 0)
            {

                HistPromo = true;
            }
            else
            {
                return false;
            }
            return HistPromo;
        }

        public static DataTable CekTagihan(string KodeToko)
        {
            DataTable dtCekTagihan = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_cekPromoTagihan"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, KodeToko));
                dtCekTagihan = db.Commands[0].ExecuteDataTable();

            }
            return dtCekTagihan;
        }
        #endregion



        #region Cek promo tahunan
        public static Boolean PromoTahunan(string barangID)
        {
            Boolean Tahunan;
            DataTable dtTahunan = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_CekPromoTahunan"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, barangID));
                dtTahunan = db.Commands[0].ExecuteDataTable();

            }
            if (dtTahunan.Rows.Count > 0)
            {
                Tahunan = true;
            }
            else
            {
                return false;
            }
            return Tahunan;

        }
        #endregion



        public static DataTable DataPromoTahunan(int sumqtyTahunan, double sumhargaTahunan)
        {
            DataTable dtPromoTahunan= new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_getPromoTahunan"));
                db.Commands[0].Parameters.Add(new Parameter("@sumqty", SqlDbType.Int, sumqtyTahunan));
                db.Commands[0].Parameters.Add(new Parameter("@sumharga", SqlDbType.Money, sumhargaTahunan));
                dtPromoTahunan = db.Commands[0].ExecuteDataTable();
            }
            return dtPromoTahunan;
        }

        public static Boolean CekHistoryTokoTahunan(string KodeToko, string BarangID)
        {
            Boolean CekHistoryTokoTahunan;
            DataTable dtCekHistoryTokoTahunan = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("Usp_TokoPromoTahunan"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, BarangID));
                dtCekHistoryTokoTahunan = db.Commands[0].ExecuteDataTable();

            }
            if (dtCekHistoryTokoTahunan.Rows.Count == 0)
            {
                CekHistoryTokoTahunan = true;
            }
            else
            {
                return false;
            }
            return CekHistoryTokoTahunan;
        }
    }
}
