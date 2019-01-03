using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using ISA.Common;

namespace ISA.Toko.Class
{
    class BKM
    {
        public static string GetRecordIDBukti(string recordID, string Src)
        {
            if (Src == "BSA")
            {
                recordID = recordID.TrimEnd() + "1";
            }
            else if (Src == "BSK")
            {
                recordID = recordID.TrimEnd() + "2";
            }
            else if (Src == "BSL")
            {
                recordID = recordID.TrimEnd() + "3";
            }
            else if (Src == "PIK")
            {
                recordID = recordID.TrimEnd() + "4";
            }
            else if (Src == "OUT")
            {
                recordID = recordID.TrimEnd() + "6";
            }
            else if (Src == "IN")
            {
                recordID = recordID.TrimEnd() + "7";
            }
            else if (Src == "PJT")
            {
                recordID = recordID.TrimEnd() + "T";
            }
            else if (Src == "IND")
            {
                recordID = recordID.TrimEnd() + "I";
            }
            return recordID;
        }

        public static void AddHeader(
            Database db,
            Guid rowID,
            Guid SrcID,
            string recordID,
            string noBukti,
            string jnsBukti,
            string Src,
            DateTime tanggal,
            string terima,
            string pembukuan,
            string noAcc,
            string kasir,
            string penerima
            )
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@SrcID", SqlDbType.UniqueIdentifier, SrcID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@JenisBukti", SqlDbType.VarChar, jnsBukti));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Src));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "M"));
            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBukti));
            db.Commands[0].Parameters.Add(new Parameter("@TglBukti", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, terima));
            db.Commands[0].Parameters.Add(new Parameter("@Pembukuan", SqlDbType.VarChar, pembukuan));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noAcc));
            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, kasir));
            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, penerima));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void AddDetail(
            Database db,
            Guid _rowID,
            Guid _headerID,
            string _recordID,
            string _HrecordID,
            string BSRecordID,
            string kode,
            string sub,
            string noAcc,
            string noPerk,
            string uraian,
            string jumlah
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _headerID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
            db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HrecordID));
            db.Commands[0].Parameters.Add(new Parameter("@BSRecordID", SqlDbType.VarChar, BSRecordID));
            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, kode));
            db.Commands[0].Parameters.Add(new Parameter("@Sub", SqlDbType.VarChar, sub));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noAcc));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerk));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, jumlah));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
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

            _recordID = _recordID.Replace(_recordID.Substring(22, 1), jp);
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

        public static void UpdateBuktiDetail(
            Database db,
            Guid rowIDDetail,
            string noPerkiraan,
            string uraian,
            string jumlah
            )
        {
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIDDetail));
            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, noPerkiraan));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, jumlah));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();

        }

        public static void UpdatePinjamanPegawai(
            Database db,
            Guid rowID,
            string recordID,
            string nip,
            DateTime tglPinjam,
            string reff,
            string noreff,
            string uraian,
            string keteranganLain,
            string jp
            )
        {

            if (recordID.Length > 0)
            {
                recordID = recordID.Replace(recordID.Substring(22, 1), jp);

            }
            else
            {
                recordID = string.Empty;
            }

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_UPDATE"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, nip));
            db.Commands[0].Parameters.Add(new Parameter("@TglPinjam", SqlDbType.DateTime, tglPinjam));
            db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, reff));
            db.Commands[0].Parameters.Add(new Parameter("@NoRef", SqlDbType.VarChar, noreff));
            db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, uraian));
            db.Commands[0].Parameters.Add(new Parameter("@KeteranganLain", SqlDbType.VarChar, keteranganLain));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }
        

        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_List"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "M"));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }
        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate, string cabang)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_List_KodeRec"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "M"));
            db.Commands[0].Parameters.Add(new Parameter("@KodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListHeaderperRow(Guid RowID)
        {
            DataTable dtResult;
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_Bukti_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "M"));
                dtResult = db.Commands[0].ExecuteDataTable();
            }
            return dtResult;
        }

        public static DataTable ListDetail(Database db, Guid headerID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List"));
            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListDetailperRow(Guid RowID)
        {
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                DataTable dtResult;
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
                dtResult = db.Commands[0].ExecuteDataTable();
                return dtResult;
            }
        }

        public static void DeleteBuktiDetail(
            Database db,
            Guid rowIdDetail)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_DELETE"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIdDetail));
            db.Commands[0].ExecuteNonQuery();
        }

        public static void UpdateUraianPinjaman(
            Database db,
            Guid rowID
            )
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List_Uraian"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].ExecuteNonQuery();
        }



        public static void cetakBukti(DataTable dtBKM, string MK)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Kasir, _mengetahui, _pembukuan, _judul, _h2="",_penerima;

            Guid _RowID = (Guid)dtBKM.Rows[0]["RowID"];
            _Terima = dtBKM.Rows[0]["Kepada"].ToString().Trim();
            _NoBukti = dtBKM.Rows[0]["NoBukti"].ToString().Trim();
            
            _Tanggal = String.Format("{0:dd-MMM-yyyy}",dtBKM.Rows[0]["TglBukti"]);
            _Kasir = dtBKM.Rows[0]["kasir"].ToString().Trim();
            _mengetahui = "";
            _pembukuan = dtBKM.Rows[0]["pembukuan"].ToString().Trim();

            if (MK == "M")
            {
                _judul = "[BUKTI KAS MASUK]";
                _h2 = "Di Terima Dari : ";
                _penerima = "Penyetor";
            }
            else
            {
                _judul = "[BUKTI KAS KELUAR]";
                _h2 = "Kepada : ";
                _penerima = "Penerima";
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
                _Tanggal).PadRight(30) + ("Hal : 1 / 1").PadRight(11) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(41) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(41) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "No. Prk".PadRight(10) + lap.PadCenter(58, "URAIAN") + lap.SPACE(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());

            if (dtBKM.Rows[0]["Jumlah"].ToString() != "")
            {
                foreach (DataRow dr in dtBKM.Rows)
                {

                    jumlah = Convert.ToDouble(dr["Jumlah"].ToString());
                    lap.PROW(true, 1, lap.PrintVerticalLine() + "".PadRight(10) + dr["Uraian"].ToString().ToUpper().PadRight(58).Substring(0, 58) + jumlah.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
                    total += Convert.ToDouble(dr["Jumlah"].ToString());
                    i++;
                }
            }
            if (i < 10)
            {
                for (int j = 0; j < 10 - i; j++)
                {
                    lap.PROW(true, 1, lap.PrintVerticalLine() + lap.SPACE(83) + lap.PrintVerticalLine());
                }
            }
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "Terbilang".PadRight(58) + "Jumlah Rp.".PadRight(10) +
                total.ToString("#,###").PadLeft(15) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(83) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + Tools.Terbilang(total).PadRight(83) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintTLeft() + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTTOp()
                + lap.PrintHorizontalLine(20) + lap.PrintTTOp() + lap.PrintHorizontalLine(20) + lap.PrintTRight());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "Pembukuan") + lap.PrintVerticalLine() + lap.PadCenter(20, "Mengetahui")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "Kasir") + lap.PrintVerticalLine() + lap.PadCenter(20, _penerima) + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "")
                + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine() + lap.PadCenter(20, "") + lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "") + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, "")
                + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Kasir.Trim()) + ")" + lap.PrintVerticalLine() + "(" + lap.PadCenter(18, _Terima.Trim()) + ")" +
                lap.PrintVerticalLine());
            lap.PROW(true, 1, lap.PrintBottomLeftCorner() + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintTBottom()
                + lap.PrintHorizontalLine(20) + lap.PrintTBottom() + lap.PrintHorizontalLine(20) + lap.PrintBottomRightCorner());
            lap.PROW(true, 1,String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)+" "+ SecurityManager.UserName);
            lap.Eject();

            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("rsp_CetakBukti"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                db.Commands[0].ExecuteNonQuery();
            }
            lap.SendToPrinter("laporan.txt");
        }

    }
}
