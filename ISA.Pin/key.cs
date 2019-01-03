
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using ISA.Pin;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ISA.Pin
{
    public class key
    {


        public struct Bagian
        {
            public const int C0101 = 1;
            public const int C0901 = 2;
            public const int C0902 = 3;
            public const int C0903 = 4;
            public const int C0905 = 5;
            public const int C1801 = 6;
            public const int C1901 = 7;
            public const int C2001 = 8;
            public const int C2101 = 9;
            public const int C2201 = 10;
            public const int C2501 = 11;
        }

        public struct BaseCode
        {
            public const string Rekon      = "YZWX90UVST78QROP56MNKL34IJGH12EFCDAB";
            public const string PSReportCI = "ZYXW09VUTS87RQPO65NMLK43JIHG21FEDCBA";
            public const string PSReportKS = "ZYXWVUTS09876RQPONMLK54321JIHGFEDCBA";
            public const string PO         = "XYWZVUTS01276RQPONMLK12345HIGJBADCEF";
            public const string RekonsPJT  = "XYWZVUTS02576RQPONKLM07039HIGJBADCEF";
            public const string CetakRegister = "SWVXZYTU89756MONPQKLR71358CGBHACFEDI";
            public const string ClosingRegister = "TVWSZUXV59875NQROMPLK51378AEGDCHIFBD";
            public const string FilterBySales = "ADEFCHIGBD59857TVWVZSXU81378NQROMPLK";

        //pin cetak register 3 lapis
            public const string CetakRegisterSPV = "PGTMSEB81640RFKWCQHA75091YXKRVNOLIZ";
            public const string CetakRegisterSupport = "DTNOSEQ48275GWRMFHJP63901VBXZYUIAKL";
            public const string CetakRegisterPKP = "STUVZWYX48275KLMNOPQR63901FECDABJGIH";
        //


            public const string OASPV = "RAFDIOQHBU32065SEWZXYJV74981KNGCLMP";
            public const string OASupport = "OZCKNPJSEW69815LTAUFQXV27430HBDGIRM";

            public const string Kasbon = "YZWX90UVST78QROP56MNKL34IJGH12EFCDAB";
            public const string Adj = "YZWX90UVST78QROP56MNKL34IJGH12EFCDAB";
        }

        public struct BaseCodeMultiplier
        {
            public const int Rekon = 16;
            public const int PSReportCI = 16;
            public const int PSReportKS = 1;
            public const int PO = 17;
            public const int RekonsPJT = 18;
            public const int CetakRegister = 19;
            public const int ClosingRegister = 20;
            public const int FilterBySales = 21;

            public const int CetakRegisterSPV = 22;
            public const int CetakRegisterSupport = 23;
            public const int CetakRegisterPKP = 24;

            public const int OASPV = 25;
            public const int OAYYK = 26;

            public const int Kasbon = 27;
            public const int Adj = 29;
        }

        public static Boolean cek(string _key, string _pin, int _id)
        {
            string kunci, pin;
            int i, key1, key2, key3, key0, key4, key5, key6, keyJml;
            Boolean status = true;
            string keyCek;
            keyJml = 0;
            kunci = _key;

            for (i = 0; i < 7; i++)
            {
                keyJml = keyJml + Convert.ToInt32(_key.Substring(i, 1));
            }
            // MessageBox.Show(keyJml.ToString());
            pin = _pin.Substring(0, 1) + _pin.Substring(2, 1) + _pin.Substring(6, 1) + _pin.Substring(7, 1);

            key0 = Convert.ToInt32(kunci.Substring(0, 1)) + Convert.ToInt32(kunci.Substring(1, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key1 = Convert.ToInt32(kunci.Substring(1, 1)) + Convert.ToInt32(kunci.Substring(2, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key2 = Convert.ToInt32(kunci.Substring(2, 1)) + Convert.ToInt32(kunci.Substring(3, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key3 = Convert.ToInt32(kunci.Substring(3, 1)) + Convert.ToInt32(kunci.Substring(4, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key4 = Convert.ToInt32(kunci.Substring(4, 1)) + Convert.ToInt32(kunci.Substring(5, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key5 = Convert.ToInt32(kunci.Substring(5, 1)) + Convert.ToInt32(kunci.Substring(6, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            key6 = Convert.ToInt32(kunci.Substring(6, 1)) + Convert.ToInt32(kunci.Substring(0, 1)) + keyJml + _id + Convert.ToInt32(kunci.Substring(0, 2));
            //MessageBox.Show(kunci.Substring(0, 1) + "/" + kunci.Substring(1, 1) + "/" + keyJml.ToString() + "/" + _id.ToString());

            key0 = getOne(key0 + Convert.ToInt32(kunci.Substring(0, 2)));
            key1 = getOne(key1 + Convert.ToInt32(kunci.Substring(0, 2)));
            key2 = getOne(key2 + Convert.ToInt32(kunci.Substring(0, 2)));
            key3 = getOne(key3 + Convert.ToInt32(kunci.Substring(0, 2)));
            key4 = getOne(key4 + Convert.ToInt32(kunci.Substring(0, 2)));
            key5 = getOne(key5 + Convert.ToInt32(kunci.Substring(0, 2)));
            key6 = getOne(key6 + Convert.ToInt32(kunci.Substring(0, 2)));

            key0 = getOne(key0 + key6);
            key1 = getOne(key1 + key5);
            key2 = getOne(key2 + key4);
            key3 = getOne(key3);





            keyCek = key0.ToString() + key1.ToString() + key2.ToString() + key3.ToString();
            MessageBox.Show(keyCek.ToString() + "==" + pin.ToString() + "==" + _pin.Length.ToString());

            if (_pin.Length != 8) { status = false; } //MessageBox.Show(status.ToString() + "=1");
            if (keyCek != pin) { status = false; } //MessageBox.Show(status.ToString() + "=2");

            //int jam = Convert.ToInt32(DateTime.Now.AddHours(1).ToString("HH")) + key0 + key1 + key2 + key3;
            // int menit = Convert.ToInt32(DateTime.Now.AddHours(1).ToString("mm")) + key0 + key1 + key2 + key3;


            // int jam = Convert.ToInt32(_pin.Substring(4, 1) + _pin.Substring(1, 1)) - key0 - key1 - key2 - key3 - key4 - key5 - key6 - _id - Convert.ToInt32(kunci.Substring(0, 2));
            // int menit = Convert.ToInt32(_pin.Substring(3, 1) + _pin.Substring(5, 1)) - key0 - key1 - key2 - key3 - key4 - key5 - key6 - _id - Convert.ToInt32(kunci.Substring(0, 2));
            //MessageBox.Show(jam.ToString() + "/" + menit.ToString() + "==" + _pin.Substring(3, 1) +"/"+ _pin.Substring(5, 1));

            int jam = Convert.ToInt32(_pin.Substring(4, 1) + _pin.Substring(1, 1)) - key4 - key5 - key6 - _id;
            int menit = Convert.ToInt32(_pin.Substring(3, 1) + _pin.Substring(5, 1)) - key4 - key5 - key6 - _id;


            //if (jam > 24 && jam < 0) { return false; } //MessageBox.Show(status.ToString() + "=3" + jam.ToString());
            if (jam > 24 || jam < 0) { return false; } //MessageBox.Show(status.ToString() + "=3" + jam.ToString());
            if (menit > 60 || menit < 0) { return false; } //MessageBox.Show(status.ToString() + "=4");

            string dateTimeStr = jam.ToString() + ":" + menit.ToString();
            DateTime waktuPin = DateTime.Parse(dateTimeStr);
            DateTime waktuSekarang = DateTime.Now;
            //MessageBox.Show(jam.ToString() + "/" + menit.ToString());
            //if (waktuSekarang > waktuPin) { status = false; } //MessageBox.Show(status.ToString() + "=5");

            //return waktuSekarang.ToString() + "==" + waktuPin.ToString();

            //MessageBox.Show(status.ToString()+"=5");
            return status;
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

        public static string proses(string _key, int _id, string cabang)
        {


            string key, jamString, menitString;
            int i, key1, key2, key3, key0, key4, key5, key6, keyJml;

            keyJml = 0;
            key = _key;
            for (i = 0; i < 7; i++)
            {
                keyJml = keyJml + Convert.ToInt32(key.Substring(i, 1));

            }
            // MessageBox.Show(keyJml.ToString());
            key0 = Convert.ToInt32(key.Substring(0, 1)) + Convert.ToInt32(key.Substring(1, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key1 = Convert.ToInt32(key.Substring(1, 1)) + Convert.ToInt32(key.Substring(2, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key2 = Convert.ToInt32(key.Substring(2, 1)) + Convert.ToInt32(key.Substring(3, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key3 = Convert.ToInt32(key.Substring(3, 1)) + Convert.ToInt32(key.Substring(4, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key4 = Convert.ToInt32(key.Substring(4, 1)) + Convert.ToInt32(key.Substring(5, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key5 = Convert.ToInt32(key.Substring(5, 1)) + Convert.ToInt32(key.Substring(6, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            key6 = Convert.ToInt32(key.Substring(6, 1)) + Convert.ToInt32(key.Substring(0, 1)) + keyJml + _id + Convert.ToInt32(cabang);
            //MessageBox.Show(key.Substring(0, 1) + "/" + key.Substring(1, 1) + "/" + keyJml.ToString() + "/" + _id.ToString());
            //MessageBox.Show(key0.ToString() + "=" + key1.ToString() + "=" + key2.ToString() + "=" + key3.ToString() + "=" + key4.ToString() + "=" + key5.ToString() + "=" + key6.ToString() + "=");
            key0 = getOne(key0 + Convert.ToInt32(cabang));
            key1 = getOne(key1 + Convert.ToInt32(cabang));
            key2 = getOne(key2 + Convert.ToInt32(cabang));
            key3 = getOne(key3 + Convert.ToInt32(cabang));
            key4 = getOne(key4 + Convert.ToInt32(cabang));
            key5 = getOne(key5 + Convert.ToInt32(cabang));
            key6 = getOne(key6 + Convert.ToInt32(cabang));

            key0 = getOne(key0 + key6);
            key1 = getOne(key1 + key5);
            key2 = getOne(key2 + key4);
            key3 = getOne(key3);

            //MessageBox.Show(key0.ToString() + "-" + key1.ToString() + "-" + key2.ToString() + "-" + key3.ToString() );

            int jam = Convert.ToInt32(DateTime.Now.AddHours(4).ToString("HH")) + key4 + key5 + key6 + _id;
            int menit = Convert.ToInt32(DateTime.Now.AddHours(4).ToString("mm")) + key4 + key5 + key6 + _id;


            //if (menit % 2 == 0) { key0 = getOne(key0 + key2); key2 = getOne(key2 + key1);  }
            //if (menit % 2 == 1) { key1 = getOne(key1 + key3); key3 = getOne(key3 + key2); }

            if (Convert.ToString(jam).Length == 1) { jamString = "0" + jam.ToString(); } else { jamString = jam.ToString(); }
            if (Convert.ToString(menit).Length == 1) { menitString = "0" + menit.ToString(); } else { menitString = menit.ToString(); }
            // MessageBox.Show(jam.ToString() + ",qq," + menit.ToString());
            string pin = key0.ToString()
                        + jamString.Substring(1, 1)
                        + key1.ToString()
                        + menitString.Substring(0, 1)
                        + jamString.Substring(0, 1)
                        + menitString.Substring(1, 1)
                        + key2.ToString()
                        + key3.ToString();

            return pin;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString().ToUpper();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string CreateDailyPin(DateTime tanggal, string kodeGudang, string baseCode, int multiplier)
        {
            const int pinMaxLen = 7;

            string dateString = String.Format("{0:MM/dd/yyyy}", tanggal);


            string yearString = dateString.Substring(6, 4);
            string monthString = dateString.Substring(0, 2);
            string dayString = dateString.Substring(3, 2);

            Double codeNumber = 0;
            codeNumber = Convert.ToDouble(yearString) * Convert.ToDouble(monthString) * Convert.ToDouble(dayString) * Convert.ToDouble(kodeGudang) * multiplier;

            string code = codeNumber.ToString();
            string codePadded = string.Empty;
            if (code.Length >= 7)
            {
                codePadded = code.Substring(code.Length - pinMaxLen, pinMaxLen);
            }
            else
            {
                codePadded = code.PadLeft(pinMaxLen - code.Length, '0');
            }

            int baseStringLen = baseCode.Length;
            string crypticCode = string.Empty;
            int charNo = 0;
            int counter = 0;
            for (int i = 1; i <= pinMaxLen; i++)
            {

                if (codePadded.Substring(i - 1, 1) == "0")
                {
                    charNo = 0;
                }
                else
                {
                    charNo = Convert.ToInt32(codePadded.Substring(i - 1, 1));
                }

                if (charNo == 0)
                {
                    counter = i;
                }
                else if ((i * charNo) % (baseStringLen) == 0)
                {
                    counter = i;
                }
                else
                {
                    counter = (i * charNo) % (baseStringLen);
                }

                crypticCode = crypticCode + baseCode.Substring(counter - 1, 1);

            }


            return crypticCode;
        }
    }
}
