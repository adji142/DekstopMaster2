using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using ISA.DAL;
using ISA.Trading;

namespace ISA.Trading
{
    class Tools
    {

        public static int getBit(object value)
        {
            int hui = 0;
            if (isNull(value, "0").ToString().Equals("0") || isNull(value, "0").ToString().Length==0)
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

        public static string CreateShortFingerPrint(int noUrut)
        {
            string nomor = ("000" + noUrut.ToString());
            nomor = nomor.Substring(nomor.Length - 4, 4);
            string HtrId = CreateFingerPrint().Substring(0, 18) + nomor;
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
                    string cG = GlobalVar.Gudang.Substring(0, 1);
                    if (cG == "9")
                    {
                        if ((int.Parse(GlobalVar.PerusahaanID.Substring(1, 2)) % 26)==0)
                            initial = aAbjad.Substring(25, 1);
                        else
                            initial = aAbjad.Substring((int.Parse(GlobalVar.PerusahaanID.Substring(1, 2)) % 26) - 1, 1);
                    }
                    else
                    {
                        if ((int.Parse(GlobalVar.PerusahaanID.Substring(0, 2)) % 26) == 0)
                            initial = aAbjad.Substring(25, 1);
                        else
                            initial = aAbjad.Substring((int.Parse(GlobalVar.PerusahaanID.Substring(0, 2)) % 26) - 1, 1);
                   }
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
                    int year = DateTime.Today.Year%10;
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
            string result="";
            string antiNumeric = "DTHAMESFOR";
            string chr;
            int counter=0;
            while (counter < numericValue.Length)
            {
                chr = numericValue.Substring(counter, 1);
                if (chr != "." && chr != "," && chr != "-")
                {
                    result += antiNumeric.Substring (int.Parse( chr),1);
                }
                else
                {
                    result += chr;
                }
                counter++;
            }
            
            if(numericValue.Contains('-'))
            {
                result = "(" + result + ")";
            }

            return result;
        }

        public static string GetAntiNumeric(string numericValue,bool SIP)
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

        public static void pin(int periodePin, int mingguKe, DateTime tanggal, int Bagian, int modulId, string keterangan)
        {
            GlobalVar.pinResult = true;
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("usp_PINUnlockLog"));
                db.Commands[0].Parameters.Add(new Parameter("@select", SqlDbType.Int, 1));
                db.Commands[0].Parameters.Add(new Parameter("@ModulID", SqlDbType.Int, modulId));
                db.Commands[0].Parameters.Add(new Parameter("@MingguKe", SqlDbType.Int, mingguKe));
                db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime2, tanggal));
                db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.Int, periodePin));
                dt = db.Commands[0].ExecuteDataTable();

            }
            if (dt.Rows.Count == 0)
            {
                GlobalVar.pinReport = false;
                GlobalVar.pinResult = false;
                DialogResult dialogResult = MessageBox.Show("Proses ini memerlukan pin. \n Apakah anda ingin melanjutkan ? ", "Peringatan", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GlobalVar.pinReport = true;
                    //Pin.frmPin ifrmChild = new Pin.frmPin(this,periodePin, Bagian, modulId, mingguKe, tanggal, keterangan);
                    //ifrmChild.WindowState = FormWindowState.Normal;
                    //ifrmChild.ShowDialog();



                }
                else if (dialogResult == DialogResult.No)
                {
                    GlobalVar.pinResult = false;
                }
            }
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

    }

    class Email {

        public static void Send(string subject, string file)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "EmailLapKoordDepo"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential
                        ("edp.palur.sas@gmail.com", "password10");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            String[] addr = dt.Rows[0]["Value"].ToString().Split(',');
            try
            {
                mail.From = new MailAddress("edp.palur.sas@gmail.com",
                "SAS", System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = subject;
                mail.Attachments.Add(new Attachment(file));
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(dt.Rows[0]["Value"].ToString());
                try
                {
                    SmtpServer.Send(mail);
                    MessageBox.Show("LAPORAN TERKIRIM KE EMAIL TUJUAN");
                    //System.Diagnostics.Process.Start(file);
                    //Create Log
                    Log(subject, file, 1, "Terkirim ke " + dt.Rows[0]["Value"].ToString());
                }
                catch (SmtpFailedRecipientException ex)
                {
                    MessageBox.Show("LAPORAN GAGAL TERKIRIM KE EMAIL TUJUAN");
                    Error.LogError(ex);
                    Log(subject, file, 0, "Gagal mengirim ke " + dt.Rows[0]["Value"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Send(string subject, string[] file)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "EmailLapKoordDepo"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            string files = "";

            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential
                        ("edp.palur.sas@gmail.com", "password10");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            String[] addr = dt.Rows[0]["Value"].ToString().Split(',');
            try
            {
                mail.From = new MailAddress("edp.palur.sas@gmail.com",
                "SAS", System.Text.Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = subject;
                for (i = 0; i < file.Length; i++)
                {
                    mail.Attachments.Add(new Attachment(file[i]));
                    if (i == 0)
                    {
                        files = file[0];
                    }
                    else
                    {
                        files = files + ", " +file[i];
                    }
                }
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(dt.Rows[0]["Value"].ToString());
                try
                {
                    SmtpServer.Send(mail);
                    MessageBox.Show("LAPORAN TERKIRIM KE EMAIL TUJUAN");
                    //System.Diagnostics.Process.Start(file);
                    Log(subject, files, 1, "Terkirim ke " + dt.Rows[0]["Value"].ToString());
                }
                catch (SmtpFailedRecipientException ex)
                {
                    MessageBox.Show("LAPORAN GAGAL TERKIRIM KE EMAIL TUJUAN");
                    Error.LogError(ex);
                    Log(subject, files, 0, "Gagal mengirim ke " + dt.Rows[0]["Value"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Log(string name, string file, int state, string note)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Log_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@LogName", SqlDbType.VarChar, name));
                    db.Commands[0].Parameters.Add(new Parameter("@LogFile", SqlDbType.VarChar, file));
                    db.Commands[0].Parameters.Add(new Parameter("@LogState", SqlDbType.Bit, state));
                    db.Commands[0].Parameters.Add(new Parameter("@LogNote", SqlDbType.VarChar, note));
                    db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
