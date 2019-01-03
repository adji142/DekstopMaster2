using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance
{
    class cTools
    {

        public static int getBit(object value)
        {
            int hui = 0;
            if (isNull(value, "0").ToString().Equals("0") || isNull(value, "0").ToString().Length == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

            return hui;
        }

        public static object isNull(object value, object nullValue)
        {
            if (value == null)
            {
                return nullValue;
            }
            else
            {
                if (value.ToString().Trim() == "")
                    return nullValue;
                else
                    return value;
            }
        }
        public static string CreateFingerPrint()
        {
            string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmssff}", GlobalVar.DateTimeOfServer) + SecurityManager.UserInitial + " ";
            //string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmssFF}", DateTime.Now) + SecurityManager.UserInitial + " ";
            //GlobalVar.PerusahaanID + Left((String.Format("{0:yyMMddHHmmssFFF}", DateTime.Now) + SecurityManager.UserInitial + Guid.NewGuid().ToString()), 20);

            return HtrId;
        }

        public static string CreateFingerPrint2803()
        {
            string HtrId = "02P" + String.Format("{0:yyyyMMddHHmmssff}", GlobalVar.DateTimeOfServer) + SecurityManager.UserInitial + " ";
            //string HtrId = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmssFF}", DateTime.Now) + SecurityManager.UserInitial + " ";
            //GlobalVar.PerusahaanID + Left((String.Format("{0:yyMMddHHmmssFFF}", DateTime.Now) + SecurityManager.UserInitial + Guid.NewGuid().ToString()), 20);

            return HtrId;
        }

        //tambah buat kode toko
        public static string CreateFingerPrint(string PerusahaanID, string userInitial)
        {
            string HtrId = PerusahaanID + String.Format("{0:yyyyMMddHH:mms}", DateTime.Now) + userInitial + " ";
            return HtrId;
        }
        //

        public static string CreateFingerPrint(int noUrut)
        {
            string nomor = noUrut.ToString().PadLeft(3, '0');
            string HtrId = CreateFingerPrint().Substring(0, 20) + nomor;
            return HtrId;
        }

        public static string CreateShortFingerPrint2803(int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateFingerPrint2803().Substring(0, 20) + nomor;
            return HtrId;
        }

        public static string CreateShortFingerPrint(int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateFingerPrint().Substring(0, 20) + nomor;
            return HtrId;
        }
        public static DataTable GetGeneralNumerator(string doc)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static DataTable GetGeneralNumerator(string doc, string depan)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
                db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                dt = db.Commands[0].ExecuteDataTable();
            }
            return dt;
        }

        public static string FormatNumerator(int nomor, int lebar, string prefix, string sufix)
        {
            string result;
            result = nomor.ToString();
            for (int i = 0; i < lebar; i++)
            {
                result = "0" + result;
            }
            result = Right(result, lebar);
            result = prefix + result + sufix;
            return result;
        }

        public static string GeneralInitial()
        {
            string Cab = ToCode("A");
            string Thn = ToCode("F");
            string Bln = ToCode("D");
            return Cab + Thn + Bln;
        }


        public static string ToCode(string initial)
        {
            string aFilm = "FILMKARTUN";
            string aDouble = "DOUBLEIMPACT";
            string aAbjad = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string bln = "ABCDEFGHIJKL";
            string thn = "ABCDEFGHIJKL";

            switch (initial)
            {
                case ("A"):
                    initial = aAbjad.Substring((int.Parse(GlobalVar.PerusahaanID.Substring(1, 2)) % 26) - 1, 1);
                    //MessageBox.Show(initial);
                    break;
                case ("F"):
                    initial = aFilm.Substring((Convert.ToInt32(DateTime.Today.Year.ToString().Substring(3, 1))) - 1, 1);
                    break;
                case ("D"):
                    initial = aDouble.Substring((Convert.ToInt32(DateTime.Today.Month.ToString())) - 1, 1);
                    break;
                case ("NOTA_PT_M"):
                    initial = bln.Substring((Convert.ToInt32(DateTime.Today.Month.ToString())) - 1, 1);
                    break;
                case ("NOTA_PT_Y"):
                    int year = DateTime.Today.Year % 10;
                    if (year == 0) year = 10;
                    initial = thn.Substring(year - 1, 1);
                    break;
            }
            return initial;

        }

        public static string Right(string param, int length)
        {
            int pjg = param.Length - length;
            string result = param.Substring(pjg, length);
            //return the result of the operation
            return result;
        }

        public static string Left(string param, int length)
        {
            int pjg = param.Length - length;
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string GetAntiNumeric(string numericValue)
        {
            string result = "";
            string antiNumeric = "DTHAMESVOR";
            string chr;
            int counter = 0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != "," && chr != "-")
                {
                    result += antiNumeric.Substring(int.Parse(chr), 1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }

            if (numericValue.Contains('-'))
            {
                result = "(" + result + ")";
            }

            return result;
        }

        public static string GetAntiNumeric(string numericValue, bool SIP)
        {
            string result = "";
            string antiNumeric = "DTHAMESVOR";
            string chr;
            int counter = 0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != ",")
                {
                    result += antiNumeric.Substring(int.Parse(chr), 1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }

            return result;
        }

        //public static bool SetNumerator(string doc)
        //{
        //    DataTable dt = new DataTable();
        //    using (Database db = new Database())
        //    {
        //        db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
        //        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
        //        dt = db.Commands[0].ExecuteDataTable();

        //        int lebar = Convert.ToInt32(dt.Rows[0]["Lebar"]);
        //        int nomor = Convert.ToInt32(dt.Rows[0]["Nomor"]) + 1;
        //        string belakang = dt.Rows[0]["Belakang"].ToString();
        //        db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
        //        db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
        //        db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, Depan()));
        //        db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
        //        db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, nomor));
        //        db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
        //        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
        //        db.Commands[1].ExecuteNonQuery();
        //        return true;
        //    }
        //}

        public static string Terbilang(int n)
        {
            string[] numbers = {"nol", "satu", "dua", "tiga", "empat", 
                                   "lima", "enam", "tujuh", "delapan", "sembilan"};
            string[] tail = { "", "", " puluh", " ratus", " ribu" };
            string result = "";
            int curNumber, nDigit;


            string sN = n.ToString();

            if (sN.Length > 4)
            {
                result = "";
            }
            else
            {
                for (int i = sN.Length - 1; i >= 0; i--)
                {
                    curNumber = int.Parse(sN.Substring(i, 1));
                    nDigit = sN.Length - i;

                    if ((curNumber == 1 || curNumber == 0) && sN.Length != 1)
                    {
                        if (curNumber == 1)
                        {
                            if (nDigit == 2)
                            {
                                if (result == numbers[0])
                                    result = "sepuluh";
                                else
                                {
                                    if (result == numbers[1])
                                        result = "sebelas";
                                    else
                                        result = result + "belas";
                                }
                            }
                            else
                                result = "se" + tail[nDigit].Trim();
                        }
                    }
                    else
                    {
                        result = numbers[curNumber] + tail[nDigit] + " " + result;

                    }
                }
            }

            result = result.Trim();

            result = result.Substring(0, 1).ToUpper() + result.Substring(1, result.Length - 1);

            return result;
        }

        public static int GetHariSales(string transactionType, int hariSalesToko)
        {
            int hariSales = 0;

            if (transactionType.Trim() == "" || transactionType.Substring(0, 1) == "T")
            {
                hariSales = 0;
            }
            else
            {
                if (transactionType == "KH" || transactionType == "KB" ||
                    transactionType == "KV" ||
                    transactionType == "KT" || transactionType == "KA")
                {
                    hariSales = 30;
                }
                else if (transactionType == "KL")
                {
                    hariSales = 40;
                }
                else if (transactionType == "KJ")
                {
                    hariSales = 14;
                }
                else if (transactionType == "KG")
                {
                    hariSales = 21;
                }
                else if (transactionType == "KZ")
                {
                    hariSales = 60;
                }
                else
                {
                    if (hariSalesToko == 0)
                    {
                        hariSales = 60;
                    }
                    else
                    {
                        hariSales = hariSalesToko;
                    }
                }
            }
            return hariSales;
        }

        public static bool IsNumeric(object input)
        {
            if (input == null || input is DateTime)
                return false;

            if (input is Int16 || input is Int32 || input is Int64 || input is Decimal || input is Single || input is Double || input is Boolean)
                return true;

            try
            {
                if (input is string)
                {
                    Double.Parse(input as string);
                    return true;
                }
                else
                {
                    Double.Parse(input.ToString());
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }

        public static string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            return Right(kodeGudang, 2) +
                noAjuan.ToString().Trim().PadLeft(2, '0') +
                rowID.Replace("-", string.Empty).ToUpper();
        }

        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int a = 0;
            a = Math.Abs((d1.Month - d2.Month) + 12 * (d1.Year - d2.Year));
            return a;
        }
        //Tambahan
        public static void DeleteDataTable(DataTable dt, string filterExpression)
        {
            DataRow[] toBeDeleted;
            toBeDeleted = dt.Select(filterExpression);

            if (toBeDeleted.Length > 0)
            {
                foreach (DataRow dr in toBeDeleted)
                {
                    dt.Rows.Remove(dr);

                }
            }
            dt.AcceptChanges();
        }

        public static string GetNomorDokumen(string Doc, string Depan, string Belakang, int Lebar,
                                      bool IsShowPrefix, bool IsShowSufix)
        {
            string result = "";
            DataTable dt = new DataTable();
            //using (Database db = new Database("ISAPalurTradingDb"))
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_BikinNomorDokumen"));
                db.Commands[0].Parameters.Add(new Parameter("@Doc", SqlDbType.VarChar, Doc));
                db.Commands[0].Parameters.Add(new Parameter("@Depan", SqlDbType.VarChar, Depan));
                db.Commands[0].Parameters.Add(new Parameter("@Belakang", SqlDbType.VarChar, Belakang));
                db.Commands[0].Parameters.Add(new Parameter("@Lebar", SqlDbType.Int, Lebar));
                db.Commands[0].Parameters.Add(new Parameter("@IsShowPrefix", SqlDbType.Bit, IsShowPrefix));
                db.Commands[0].Parameters.Add(new Parameter("@IsShowSufix", SqlDbType.Bit, IsShowSufix));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            result = dt.Rows[0]["NomorDokumen"].ToString();
            return result;
        }

    }
}
