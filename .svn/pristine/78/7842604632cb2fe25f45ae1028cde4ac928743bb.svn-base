using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using ISA.Common;

namespace ISA.Toko.Class
{
    class TransferBank
    {
        public static void addHeader(
                Database db,
            	Guid RowID,
                Guid SrcID,
	            string RecordID, 
	            DateTime TglBBM, 
	            string NoBBM, 
	            string MK, 
                string BankID,
	            string Keterangan, 
	            string Dibukukan, 
	            string Diketahui, 
	            string Kasir, 
	            string Penyetor
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBank_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,RowID ));
            db.Commands[0].Parameters.Add(new Parameter("@SrcID", SqlDbType.UniqueIdentifier, SrcID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@TglBBM", SqlDbType.DateTime, TglBBM));
            db.Commands[0].Parameters.Add(new Parameter("@NoBBM", SqlDbType.VarChar, NoBBM));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, MK));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Keterangan));
            db.Commands[0].Parameters.Add(new Parameter("@Dibukukan", SqlDbType.VarChar, Dibukukan));
            db.Commands[0].Parameters.Add(new Parameter("@Diketahui", SqlDbType.VarChar, Diketahui));
            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, Kasir));
            db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, Penyetor));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void addDetail(
                Database db,
                Guid RowID, 
	            Guid HeaderID, 
	            string RecordID, 
	            string HRecordID, 
	            string KodeToko, 
	            string AsalTransfer, 
	            string NamaBank, 
	            string Lokasi, 
	            string Nomor, 
	            DateTime TglTransfer, 
	            string Nominal,	
	            string MainTitip, 
	            string SubTitip, 
	            string MainPiut, 
	            string SubPiut, 
	            string BankID, 
	            string NoPerkiraan, 
	            string TitiPerkiraan,
                string IdBankTujuan
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
            db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, AsalTransfer));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, NamaBank));
            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Lokasi));
            db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, Nomor));
            db.Commands[0].Parameters.Add(new Parameter("@TglTransfer", SqlDbType.DateTime, TglTransfer));
            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, MainTitip));
            db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, SubTitip));
            db.Commands[0].Parameters.Add(new Parameter("@MainPiut", SqlDbType.VarChar, MainPiut));
            db.Commands[0].Parameters.Add(new Parameter("@SubPiut", SqlDbType.VarChar, SubPiut));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@TitiPerkiraan", SqlDbType.VarChar, TitiPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].Parameters.Add(new Parameter("@KodeBankTujuan", SqlDbType.VarChar, IdBankTujuan));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void addDetail(
                Database db,
                Guid RowID,
                Guid HeaderID,
                string RecordID,
                string HRecordID,
                string KodeToko,
                string AsalTransfer,
                string NamaBank,
                string Lokasi,
                string Nomor,
                DateTime TglTransfer,
                string Nominal,
                string MainTitip,
                string SubTitip,
                string MainPiut,
                string SubPiut,
                string BankID,
                string NoPerkiraan,
                string TitiPerkiraan
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, HRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
            db.Commands[0].Parameters.Add(new Parameter("@AsalTransfer", SqlDbType.VarChar, AsalTransfer));
            db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, NamaBank));
            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, Lokasi));
            db.Commands[0].Parameters.Add(new Parameter("@Nomor", SqlDbType.VarChar, Nomor));
            db.Commands[0].Parameters.Add(new Parameter("@TglTransfer", SqlDbType.DateTime, TglTransfer));
            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, Nominal));
            db.Commands[0].Parameters.Add(new Parameter("@MainTitip", SqlDbType.VarChar, MainTitip));
            db.Commands[0].Parameters.Add(new Parameter("@SubTitip", SqlDbType.VarChar, SubTitip));
            db.Commands[0].Parameters.Add(new Parameter("@MainPiut", SqlDbType.VarChar, MainPiut));
            db.Commands[0].Parameters.Add(new Parameter("@SubPiut", SqlDbType.VarChar, SubPiut));
            db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, BankID));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, NoPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@TitiPerkiraan", SqlDbType.VarChar, TitiPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            
            db.Commands[0].ExecuteNonQuery();
        }

        public static void DeleteDetail(
            Database db,
            Guid RowID)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static DataTable ListHeader(
            Database db,
            DateTime fromDate,
            DateTime toDate,
            string MK
            )
         
        {
            DataTable dt = new DataTable();

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBank_LIST_ByDate"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, MK));
            dt = db.Commands[0].ExecuteDataTable();            
            return dt;

        }

        public static DataTable ListHeaderRow(
            Guid RowID,
            string MK
            )
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_TransferBank_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;

        }

        public static DataTable ListDetail(
            Database db,
            Guid HeaderID
            )
        {
            DataTable dt = new DataTable();

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_LIST_ByHeaderID"));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID));            
            dt = db.Commands[0].ExecuteDataTable();
            dt.DefaultView.Sort = "TglBank Desc";
            return dt.DefaultView.ToTable();

        }

        public static DataTable ListDetailRow(
            Guid RowID
            )
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;

        }

        public static void AddPinjamanPegawai(
            Database db,
            Guid rowID,
            string _recordID,
            string NIP,
            DateTime tglPinjam,
            string Ref,
            string NoRef,
            string Uraian,
            string KeteranganLain,
            double Debet,
            double Kredit,
            string jp
            )
        {


            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
            db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, NIP));
            db.Commands[0].Parameters.Add(new Parameter("@TglPinjam", SqlDbType.VarChar, tglPinjam));
            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Ref));
            db.Commands[0].Parameters.Add(new Parameter("@NoRef", SqlDbType.VarChar, NoRef));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Uraian));
            db.Commands[0].Parameters.Add(new Parameter("@KeteranganLain", SqlDbType.VarChar, KeteranganLain));
            db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Debet));
            db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Kredit));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }


        public static void UpdatePinjamanPegawai(
           Database db,
           Guid rowID,
            string recordID,
           string uraian
           )
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_Transfer_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void UpdateUraianPinjaman(
           Database db,
           Guid rowID
           )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Pinjaman_List_Uraian"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void cetakTransfer(DataTable dtTrn, string MK)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan, _judul, _h2="";

            Guid _RowID = (Guid)dtTrn.Rows[0]["RowID"];
            _Terima = dtTrn.Rows[0]["Penyetor"].ToString();
            _NoBukti = dtTrn.Rows[0]["NoBBM"].ToString();
            _Tanggal = String.Format("{0:dd-MMM-yyyy}", dtTrn.Rows[0]["TglBBM"]);
            _Kasir = dtTrn.Rows[0]["Kasir"].ToString();
            _mengetahui = dtTrn.Rows[0]["Diketahui"].ToString();
            _pembukuan = dtTrn.Rows[0]["Dibukukan"].ToString();
            if (MK == "M")
            {
                _judul = "[BUKTI BANK MASUK]";
                _h2 = "Di Terima Dari : ";
            }
            else
            {
                _judul = "[BUKTI BANK KELUAR]";
                _h2 = "Kepada : ";
            }
            
            BuildString lap = new BuildString();
            lap.Initialize();

            lap.PageLLine(33);
            lap.LeftMargin(1);
            lap.FontCPI(12);
            lap.LineSpacing("1/6");
            lap.DoubleWidth(true);
            lap.PROW(true, 1, _judul);
            lap.DoubleWidth(false);


            lap.PROW(true, 1, lap.PrintTopLeftCorner() + lap.PrintHorizontalLine(41) + lap.PrintTTOp()
                        + lap.PrintHorizontalLine(41) + lap.PrintTopRightCorner());
            lap.PROW(true, 1, lap.PrintVerticalLine() + _h2.PadRight(41) +
                lap.PrintVerticalLine() + ("Nomor   : " + _NoBukti).PadRight(41) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + _Terima.PadRight(41) + lap.PrintVerticalLine() + ("Tanggal : " +
                _Tanggal).PadRight(30) + ("Hal : 1/1").PadRight(11) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(41) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(10, "Nomor") + lap.PadCenter(20, "Asal Transfer") + lap.SPACE(1)
        + lap.PadCenter(11, "Bank") + lap.PadCenter(13, "Tgl. Bank") + lap.PadCenter(13, "Tgl. Trf")
        + lap.PadCenter(15, "Nilai Transfer") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

            foreach (DataRow dr in dtTrn.Rows)
            {
                jumlah = Convert.ToDouble(dr["Nominal"].ToString());
                lap.PROW(true, 1, lap.PrintVerticalLine() + dr["NoPerkiraan"].ToString().PadRight(10)  + dr["AsalTransfer"].ToString().ToUpper().PadRight(20).Substring(0,20)
                    + dr["NamaBank"].ToString().PadRight(12).Substring(0,12) + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["TglBBM"])) 
                    + lap.PadCenter(13, String.Format("{0:dd-MMM-yyyy}", dr["TglTransfer"]))  + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                total += Convert.ToDouble(dr["Nominal"].ToString());
                i++;
            }
            if (i < 10)
            {
                for (int j = 0; j < 10 - i; j++)
                {
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                }
            }
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp." +
                total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, "Penyetor") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _pembukuan.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _mengetahui.Trim())
                + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" +
                lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
            lap.PROW(true, 1,String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)+" "+ SecurityManager.UserName);
            lap.Eject();

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_TransferBank_Update"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)dtTrn.Rows[0]["nprint"] + 1));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("laporan.txt");
        }
        
    }
}
