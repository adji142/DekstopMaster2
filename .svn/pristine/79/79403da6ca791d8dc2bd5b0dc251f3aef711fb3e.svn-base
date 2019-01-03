using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Trading.Class
{
    #region Plafon Toko
    public class TokoPlafon
    {
        public static double Plafon(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoPlafon"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (jenisTransaksi == "K2" || jenisTransaksi == "K4" || jenisTransaksi == "KK")
                {
                    if (!double.TryParse(dt.Rows[0]["plf_fb"].ToString(), out retVal)) retVal = 0;
                }
                else
                {
                    if (!double.TryParse(dt.Rows[0]["plf_fx"].ToString(), out retVal)) retVal = 0;
                }
            }

            return retVal;
        }

        public static double PlafonFin(string kodeToko)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoPlafonFin"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                retVal = Double.Parse(Tools.isNull(dt.Rows[0]["Plafon"],"0").ToString());
            }
            return retVal;
        }

        public static double Piutang(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoPiutang"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@jenistrans", SqlDbType.VarChar, jenisTransaksi));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["sisa"].ToString(), out retVal)) retVal = 0;
            }


            return retVal;
        }

        public static double GIT(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoGIT"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@jenistrans", SqlDbType.VarChar, jenisTransaksi));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["GIT"].ToString(), out retVal)) retVal = 0;
            }

            return retVal;
        }

        public static double Giro(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            if (jenisTransaksi == "K2" || jenisTransaksi == "K4" || jenisTransaksi == "KK")
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTokoGiro"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    if (!double.TryParse(dt.Rows[0]["Giro"].ToString(), out retVal)) retVal = 0;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTokoGiroFX"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    if (!double.TryParse(dt.Rows[0]["Giro"].ToString(), out retVal)) retVal = 0;
                }
            }


            return retVal;
        }

        public static double GiroTolak(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            //if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
            //{
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTokoGiroTolak"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    if (!double.TryParse(dt.Rows[0]["GiroTolak"].ToString(), out retVal)) retVal = 0;
                }
            //}

            return retVal;
        }

        public static double SisaPlafon(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;
            double plafon = Plafon(kodeToko, jenisTransaksi);
            double piutang = Piutang(kodeToko, jenisTransaksi);
            double git = GIT(kodeToko, jenisTransaksi);
            double giro = Giro(kodeToko,jenisTransaksi);
            double giroTolak = GiroTolak(kodeToko,jenisTransaksi);

            retVal = plafon - piutang - git - giro - giroTolak;

            return retVal;
        }

        public static double SisaPlafon(double plafon, double piutang, double git, double giro, double giroTolak)
        {
            double retVal = 0;
            
            retVal = plafon - piutang - git - giro - giroTolak;

            return retVal;
        }

        public static double SisaPlafonFin(string kodeToko)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetSisaPlafon"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                retVal = Double.Parse(Tools.isNull(dt.Rows[0]["SisaPlafon"].ToString(),"0").ToString());
            }
            return retVal;
        }

        public static double SisaPlafonFinV2(string kodeToko,Guid DOID)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetSisaPlafonV2"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, DOID));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                retVal = Double.Parse(Tools.isNull(dt.Rows[0]["SisaPlafon"].ToString(), "0").ToString());
            }
            return retVal;
        }

        public static double PiutangFin(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PiutangFin"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["SisaPiutang"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double GITFin(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GITFin"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["GitToko"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double GiroFin(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GiroFin"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["SaldoGiroBerjalan"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double GiroTolakFin(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GiroTolakFin"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["SisaGiro"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double Pembayaran(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Pembayaran"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["Bayar"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double LamaOverdue(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetLamaOvd"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["Hrovd"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

        public static double DoBerjalan(string kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_DoBerjalan"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["HrgJual"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }

    }
    #endregion

    #region Overdue Toko
    public class TokoOverdue
    {
        //Overdue Toko
        public static double Overdue(string kodeToko)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoOverdue"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["Overdue"].ToString(), out retVal)) retVal = 0;
            }

            return retVal;
        }

        //Overdue Toko Non-agen
        public static double OverdueFB(string kodeToko)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoOverdueNonAgen"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["Overdue"].ToString(), out retVal)) retVal = 0;
            }

            return retVal;
        }

        //Overdue Toko Agen
        public static double OverdueFX(string kodeToko)
        {
            double retVal = 0;

            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoOverdueAgen"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["Overdue"].ToString(), out retVal)) retVal = 0;
            }

            return retVal;
        }


        //Hari Overdue Toko FX
        public static double HariOverdueFX(string kodeSales)
        {
            double retVal = 0;
            
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetTokoOverdue_HariOvdFX"));
                db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, kodeSales));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                if (!double.TryParse(dt.Rows[0]["UmurPtg"].ToString(), out retVal)) retVal = 0;
            }
            return retVal;
        }


    }
    #endregion
}
