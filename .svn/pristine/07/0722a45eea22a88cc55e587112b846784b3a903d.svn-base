using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using ISA.Common;

namespace ISA.Common
{
    public class Tools
    {
        public static object isNull(object value, object nullValue)
        {
            if (value == null)
            {
                return nullValue;
            }
            else
            {
                return value;
            }
        }

        public static string isNullOrEmpty(string value, string nullValue )
        {
            if (string.IsNullOrEmpty(value))
            {
                return nullValue;
            }
            else
            {
                return value;
            }
        }

        public static string CreateFingerPrint(string PerusahaanID, string userInitial)
        {
            //string HtrId = PerusahaanID + String.Format("{0:yyyyMMddHHmmssff}", DateTime.Now) + userInitial + " ";
            string HtrId = PerusahaanID + String.Format("{0:yyyyMMddHHmmssff}", DateTimeOfServer) + userInitial + " ";
            return HtrId;
        }

        
        public static string CreateShortRecordID(string userInitial)
        {
            //string HtrId =  String.Format("{0:yyyyMMddHHmmssff}", DateTime.Now) + userInitial + " ";
            string HtrId = String.Format("{0:yyyyMMddHHmmssff}", DateTimeOfServer) + userInitial + " ";
            return HtrId;
        }

        public static string CreateShortFingerPrint(string PerusahaanID,string userInitial, int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = Tools.Right(nomor, 2);
            string HtrId = CreateFingerPrint(PerusahaanID, userInitial).Substring(0, 20) + nomor;
            return HtrId;
        }

        public static string CreateSortRecordID(string userInitial, int noUrut)
        {
            string nomor = ("00" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 3, 3);
            string HtrId = CreateShortRecordID(userInitial).Substring(0, 20) + nomor;
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

        public static DataTable GetGeneralNumerator(string doc, String DbName)
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(DbName))
            {
                db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, doc));
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


        private static string CabangID
        {
            get
            {
                string Cab = string.Empty;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        Cab = Tools.isNull(dt.Rows[0]["InitCabang"].ToString(), "").ToString();
                    }

                }
                return Cab;
            }
        }

        public static string ToCode(string initial)
        {
            string aFilm = "FILMKARTUN";
            string aDouble = "DOUBLEIMPACT";
            string aAbjad = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string bln = "ABCDEFGHIJKL";
            string thn = "ABCDEFGHIJ";

            switch (initial)
            {
                case ("A"):
                    initial = aAbjad.Substring(int.Parse(CabangID) - 1, 1);
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
                    initial = thn.Substring((Convert.ToInt32(DateTime.Today.Month.ToString())) - 1, 1);
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
            string antiNumeric = "DTHAMESFOR";
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
        //    using (Database db = new Database(Properties.Settings.Default.Host))
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


        public static string DecodePassword(string password)
        {
            string result = "";

            password = password.Trim();

            for (int i = 0; i < password.Length; i++)
            {
                int x = (int)password[i];

                result += char.ConvertFromUtf32((x / 2) - 5);
            }
            return result;
        }

        public static string EncodePassword(string password)
        {
            string result = "";

            password = password.Trim();

            for (int i = 0; i < password.Length; i++)
            {
                int x = (int)password[i];

                result += char.ConvertFromUtf32((x + 5) * 2);
            }
            return result;
        }

        public static string Terbilang(double amount)
        {

            string word = "";
            double divisor = 1000000000000.00; double large_amount = 0;
            double tiny_amount = 0;
            double dividen = 0; double dummy = 0;
            string weight1 = ""; string unit = ""; string follower = "";
            string[] prefix = { "SE", "DUA ", "TIGA ", "EMPAT ", "LIMA ", "ENAM ", "TUJUH ", "DELAPAN ", "SEMBILAN " };
            string[] sufix = { "SATU ", "DUA ", "TIGA ", "EMPAT ", "LIMA ", "ENAM ", "TUJUH ", "DELAPAN ", "SEMBILAN " };
            large_amount = Math.Abs(Math.Truncate(amount));
            tiny_amount = Math.Round((Math.Abs(amount) - large_amount) * 100);
            if (large_amount > divisor)
                return "OUT OF RANGE";
            while (divisor >= 1)
            {
                dividen = Math.Truncate(large_amount / divisor);
                large_amount = large_amount % divisor;
                unit = "";
                if (dividen > 0)
                {
                    if (divisor == 1000000000000.00)
                        unit = "TRILYUN ";
                    else
                        if (divisor == 1000000000.00)
                            unit = "MILYAR ";
                        else
                            if (divisor == 1000000.00)
                                unit = "JUTA ";
                            else
                                if (divisor == 1000.00)
                                    unit = "RIBU ";
                }
                weight1 = "";
                dummy = dividen;
                if (dummy >= 100)
                    weight1 = prefix[(int)Math.Truncate(dummy / 100) - 1] + "RATUS ";
                dummy = dividen % 100;
                if (dummy < 10)
                {
                    if (dummy == 1 && unit == "RIBU ")
                        weight1 += "SE";
                    else
                        if (dummy > 0)
                            weight1 += sufix[(int)dummy - 1];
                }
                else
                    if (dummy >= 11 && dummy <= 19)
                    {
                        weight1 += prefix[(int)(dummy % 10) - 1] + "BELAS ";
                    }
                    else
                    {
                        weight1 += prefix[(int)Math.Truncate(dummy / 10) - 1] + "PULUH ";
                        if (dummy % 10 > 0)
                            weight1 += sufix[(int)(dummy % 10) - 1];
                    }
                word += weight1 + unit;
                divisor /= 1000.00;
            }
            if (Math.Truncate(amount) == 0)
                word = "NOL ";
            follower = "";
            if (tiny_amount < 10)
            {
                if (tiny_amount > 0)
                    follower = "KOMA NOL " + sufix[(int)tiny_amount - 1];
            }
            else
            {
                follower = "KOMA " + sufix[(int)Math.Truncate(tiny_amount / 10) - 1];
                if (tiny_amount % 10 > 0)
                    follower += sufix[(int)(tiny_amount % 10) - 1];
            }
            word += follower;
            if (amount < 0)
            {
                word = "MINUS " + word + "RUPIAH";
            }
            else
            {
                word = word + "RUPIAH";
            }
            word = word.ToLower();
            word = word.Substring(0, 1).ToUpper() + word.Substring(1);
            return word.Trim();
        }

        public static DateTime DateTimeOfServer
        {
            get
            {


                DateTime result;
                DataTable dt2 = new DataTable();
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("[fsp_GetDateServer]"));
                    // db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "PJT"));
                    dt2 = db.Commands[0].ExecuteDataTable();

                }
                result = (DateTime)dt2.Rows[0]["DateTime"];

                return result;
            }

        }

        public static string pin(int periodePin, int mingguKe, DateTime tanggal, int Bagian, int modulId, string Gudang)
        {
            string KodeCabang;
            string AngkaAcak;
            string IDnya;

            if (Gudang == "2811") { KodeCabang = "11"; }
            else if (Gudang == "2801") { KodeCabang = "01"; }
            else if (Gudang == "2802") { KodeCabang = "02"; }
            else if (Gudang == "2803") { KodeCabang = "03"; }
            else if (Gudang == "2804") { KodeCabang = "04"; }
            else if (Gudang == "2805") { KodeCabang = "05"; }
            else if (Gudang == "2806") { KodeCabang = "06"; }
            else if (Gudang == "2807") { KodeCabang = "07"; }
            else if (Gudang == "2808") { KodeCabang = "08"; }
            else if (Gudang == "2809") { KodeCabang = "09"; }
            else if (Gudang == "2810") { KodeCabang = "10"; }
            else if (Gudang == "2812") { KodeCabang = "12"; }
            else if (Gudang == "2813") { KodeCabang = "13"; }
            else if (Gudang == "2814") { KodeCabang = "14"; }
            else if (Gudang == "2815") { KodeCabang = "15"; }
            else if (Gudang == "2816") { KodeCabang = "16"; }
            else if (Gudang == "2817") { KodeCabang = "17"; }
            else if (Gudang == "2818") { KodeCabang = "18"; }
            else if (Gudang == "2819") { KodeCabang = "19"; }
            else if (Gudang == "2820") { KodeCabang = "20"; }
            else { KodeCabang = "99"; }

            AngkaAcak = getOne(Convert.ToInt32(tanggal.ToString("dd") + tanggal.ToString("hh"))).ToString() + getOne(Convert.ToInt32(tanggal.ToString("MM") + tanggal.ToString("mm"))).ToString() + getOne(Convert.ToInt32(tanggal.ToString("yyyy") + tanggal.ToString("ss"))).ToString();
            if (modulId < 10)
            {
                IDnya = "0" + modulId.ToString();
            }
            else
            {
                IDnya = modulId.ToString();

            }
            return KodeCabang + IDnya + AngkaAcak.ToString();
        }

        public static int getOne(int keyOri)
        {
            int xx;
            int keyNew = 0;
            //MessageBox.Show(keyOri.ToString().Length.ToString());
            if (keyOri.ToString().Length == 1)
            {
                return keyOri;
            }
            else
            {
                for (xx = 0; xx < keyOri.ToString().Length; xx++)
                {
                    keyNew = keyNew + Convert.ToInt32(keyOri.ToString().Substring(xx, 1));


                }
                //MessageBox.Show(keyNew.ToString());
                return getOne(keyNew);

            }
        }

        public static string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            return Right(kodeGudang, 2) +
                noAjuan.ToString().Trim().PadLeft(2, '0') +
                rowID.Replace("-", string.Empty).ToUpper();
        }

    }
}
