using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;
using ISA.Common;
using ISA.Finance;

namespace ISA.Bengkel
{
    class GlobalVar
    {
        static string _applicationID = "APP002";
        static string _cabangID;
        static string _perusahaanID;
        static string _gudang;
        static string _dbfUpload;
        static string _dbfDownload;
        static string _SASFoxpro;
        static string _PerusahaanName;
        static DateTime _LastPJTClosing;
        //static string _DBName = ISA.Bengkel.Properties.Settings.Default.DbName;
        //static string _DBHR = ISA.Bengkel.Properties.Settings.Default.DbHR;
        static DateTime _ServerDate;

        public static string ApplicationID
        {
            get
            {
                return _applicationID;
            }
        }

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

        //public static string DBName
        //{
        //    get
        //    {
        //        // return _SASFoxpro;
        //        return _DBName;
        //    }
        //    set
        //    {
        //        _DBName = value;
        //    }
        //}

      

        //public static string DBHR
        //{
        //    get
        //    {
        //        // return _SASFoxpro;
        //        return _DBHR;
        //    }
        //    set
        //    {
        //        _DBHR = value;
        //    }
        //}

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
                    _cabangID = Tools.isNull( dt.Rows[0]["InitCabang"].ToString(),"").ToString();
                    _perusahaanID = Tools.isNull(dt.Rows[0]["InitPerusahaan"].ToString(), "").ToString();
                    _PerusahaanName = Tools.isNull(dt.Rows[0]["Nama"].ToString(), "").ToString();
                    _gudang = Tools.isNull(dt.Rows[0]["InitGudang"].ToString(), "").ToString();
                }

                _LastPJTClosing = new DateTime(1900, 1, 1);
            }

            DateTime result;
            DataTable dt2 = new DataTable();
            using (Database db = new Database())
            {

                db.Commands.Add(db.CreateCommand("[fsp_GetDateServer]"));
                // db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "PJT"));
                dt2 = db.Commands[0].ExecuteDataTable();

            }
            result = (DateTime)dt2.Rows[0]["Date"];
            _ServerDate = result;
            //load preferences            
            _dbfUpload = Properties.Settings.Default.DBFUpload;
            
            _dbfDownload = Properties.Settings.Default.DBFDownload;

            if (!Directory.Exists(_dbfUpload))
            {
                Directory.CreateDirectory(_dbfUpload);
            }
            if (!Directory.Exists(_dbfDownload))
            {
                Directory.CreateDirectory(_dbfDownload);
            }
        }

         public static DateTime LastClosingDate
        {
            get
            {
                DateTime result;
                using (Database db=new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_fnGetClosingStok"));
                    db.Commands[0].Parameters.Add(new Parameter("@tipe", SqlDbType.VarChar, "PJT"));
                   
                    db.Commands[0].Parameters.Add(new Parameter("@tglAwal", SqlDbType.DateTime,(_LastPJTClosing!=new DateTime(1900,1,1))?_LastPJTClosing : DateTime.Now.Date));
                    result = (DateTime)db.Commands[0].ExecuteScalar();
                }
                return result;
            }

            set { _LastPJTClosing = value; }
        }
        
        public static DateTime DateOfServer
         {
             get
             {
                 return _ServerDate;
             }

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
        
    }
}
