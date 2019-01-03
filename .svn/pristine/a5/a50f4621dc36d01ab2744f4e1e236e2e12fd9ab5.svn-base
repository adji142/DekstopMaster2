using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ISA.DAL;

namespace ISA.Toko.Class
{
    #region Plafon Toko
    public class TokoPlafon
    {
        public static double Plafon(string kodeToko)
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
                //if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
                //{
                retVal = Convert.ToDouble(dt.Rows[0]["plf_fb"]);
                //}
                //else
                //{
                //    retVal = Convert.ToDouble(dt.Rows[0]["plf_fx"]);
                //}
            }

            return retVal;
        }

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
                //if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
                //{
                    retVal = Convert.ToDouble(dt.Rows[0]["plf_fb"]);
                //}
                //else
                //{
                //    retVal = Convert.ToDouble(dt.Rows[0]["plf_fx"]);
                //}
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
                retVal = Convert.ToDouble(dt.Rows[0]["sisa"]);
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
                retVal = Convert.ToDouble(dt.Rows[0]["GIT"]);
            }

            return retVal;
        }

        public static double DODLMPROSES(String kodeToko)
        {
            double retVal = 0;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("uSp_DoDalamProses"));
                db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                //db.Commands[0].Parameters.Add(new Parameter("@jenistrans", SqlDbType.VarChar, jenisTransaksi));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                retVal = Convert.ToDouble(dt.Rows[0]["DO"]);
            }
             
            return retVal;
        }

        public static double Giro(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
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
                    retVal = Convert.ToDouble(dt.Rows[0]["Giro"]);
                }
            }

            return retVal;
        }

        public static double GiroTolak(string kodeToko, string jenisTransaksi)
        {
            double retVal = 0;

            if (jenisTransaksi == "K2" || jenisTransaksi == "K4")
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetTokoGiroTolak"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, kodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    retVal = Convert.ToDouble(dt.Rows[0]["GiroTolak"]);
                }
            }

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

        public static double SisaPlafon(double plafon, double piutang, double git, double giro, double giroTolak, double dodalamproses)
        {
            double retVal = 0;
            
            retVal = plafon - piutang - git - giro - giroTolak - dodalamproses;

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
                retVal = Convert.ToDouble(dt.Rows[0]["Overdue"]);
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
                retVal = Convert.ToDouble(dt.Rows[0]["Overdue"]);
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
                retVal = Convert.ToDouble(dt.Rows[0]["Overdue"]);
            }

            return retVal;
        }
    }
    #endregion
}
