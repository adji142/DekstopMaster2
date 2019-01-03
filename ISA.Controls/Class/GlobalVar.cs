using System;
using System.Collections.Generic;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;
using ISA.Controls;

namespace ISA.Controls
{
    class GlobalVar
    {
        //static string _applicationID = "APP001";
        static string _cabangID;
        static string _perusahaanID;
        static string _gudang;
        static string _dbfUpload;
        static string _dbfDownload;
        static string _SASFoxpro;
        static string _PerusahaanName;
        static DateTime _LastPJTClosing;

        //public static string ApplicationID
        //{
        //    get
        //    {
        //        return _applicationID;
        //    }
        //}

        public static string CabangID
        {
            get
            {
                return _cabangID;
            }
            set
            {
                _cabangID = value;
            }
        }

        public static string PerusahaanID
        {
            get
            {
                return _perusahaanID;
            }
            set
            {
                _perusahaanID = value;
            }
        }

        public static string PerusahaanName
        {
            get
            {
                return _PerusahaanName;
            }
            set
            {
                _PerusahaanName = value;
            }
        }

        public static string Gudang
        {
            get
            {
                return _gudang;
            }
            set
            {
                _gudang = value;
            }
        }

        public static string DbfUpload
        {
            get
            {
                return _dbfUpload;
            }
            set
            {
                _dbfUpload = value;
            }
        }

        public static string DbfDownload
        {
            get
            {
                return _dbfDownload;
            }
            set
            {
                _dbfDownload = value;
            }
        }

        public static string SASFoxpro
        {
            get
            {
                // return _SASFoxpro;
                return "C:\\Temp\\Program Asli\\Database";
            }
            set
            {
                _SASFoxpro = value;
            }
        }

        public static void initialize()
        {
            //load data perusahaan
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                if (dt.Rows.Count > 0)
                {
                    _cabangID = Tools.isNull(dt.Rows[0]["InitCabang"].ToString(), "").ToString();
                    _perusahaanID = Tools.isNull(dt.Rows[0]["InitPerusahaan"].ToString(), "").ToString();
                    _PerusahaanName = Tools.isNull(dt.Rows[0]["Nama"].ToString(), "").ToString();
                    _gudang = Tools.isNull(dt.Rows[0]["InitGudang"].ToString(), "").ToString();
                }

                _LastPJTClosing = new DateTime(1900, 1, 1);
            }
        }
    }
}
