using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Controls;

namespace ISA.Controls
{
    class Tools
    {
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
                    initial = aAbjad.Substring(int.Parse(GlobalVar.CabangID) - 1, 1);
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
                    initial = thn.Substring((Convert.ToInt32(DateTime.Today.Month)) - 1, 1);
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

            if (numericValue.Contains("-"))
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

    }
}
