using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;

namespace ISA.Finance.Class
{
    class BKK
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
                //PIK Keluar
                recordID = recordID.TrimEnd() + "5";
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
            string kepada,
            string pembukuan,
            string noAcc,
            string kasir,
            string penerima,
            string attachment
            )
        
        {

            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_INSERT"));
            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            db.Commands[0].Parameters.Add(new Parameter("@SrcID", SqlDbType.UniqueIdentifier, SrcID));
            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordID));
            db.Commands[0].Parameters.Add(new Parameter("@JenisBukti", SqlDbType.VarChar, jnsBukti));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "K"));
            db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Src));
            db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, noBukti));
            db.Commands[0].Parameters.Add(new Parameter("@TglBukti", SqlDbType.DateTime, tanggal));
            db.Commands[0].Parameters.Add(new Parameter("@Kepada", SqlDbType.VarChar, kepada));
            db.Commands[0].Parameters.Add(new Parameter("@Pembukuan", SqlDbType.VarChar, pembukuan));
            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, noAcc));
            db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, kasir));
            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, penerima));
            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
            db.Commands[0].Parameters.Add(new Parameter("@AttachmentBKK", SqlDbType.VarChar, attachment));
            //db.Commands[0].Parameters.Add(new Parameter("@AttachmentAttachmentSource", SqlDbType.VarChar, attachmentBKK));
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

            /*coba ditutup*/
            //if (_recordID.Length > 0 && !string.IsNullOrEmpty(NIP))
            //{
            //    _recordID = _recordID.Replace(_recordID.Substring(22, 1), jp);
            //}
            //else
            //{
            //    _recordID = string.Empty;
            //    NIP = string.Empty;
            //}
            
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

        public static DataTable ListHeader(Database db, DateTime fromDate, DateTime toDate)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_List"));
            db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
            db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "K"));
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
            db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "K"));
            db.Commands[0].Parameters.Add(new Parameter("@KodeRec", SqlDbType.VarChar, cabang));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable ListHeaderperRow(Guid RowID)
        {
            DataTable dtResult;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_Bukti_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                db.Commands[0].Parameters.Add(new Parameter("@MK", SqlDbType.VarChar, "K"));
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
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dtResult;
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowID));
                dtResult = db.Commands[0].ExecuteDataTable();
                return dtResult;
            }
        }

        public static DataTable GetHeaderByRecordID(Database db, string recordID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_Bukti_LIST_RecordID"));
            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, recordID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }


        public static DataTable GetDetail(Database db, Guid rowID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_List"));
            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
        }

        public static DataTable GetDetailByHRecordID(Database db, string hRecordID)
        {
            DataTable dtResult;
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_LIST_HRecordID"));
            db.Commands[0].Parameters.Add(new Parameter("@hRecordID", SqlDbType.VarChar, hRecordID));
            dtResult = db.Commands[0].ExecuteDataTable();
            return dtResult;
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

    }
}
