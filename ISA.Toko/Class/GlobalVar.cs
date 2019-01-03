using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISA.DAL;
using System.Data;
using System.IO;

using System.Windows.Forms;
namespace ISA.Toko
{
    class GlobalVar
    {
        static string _applicationID = "APP001";
        static string _cabangID;
        static string _perusahaanID;
        static string _gudang;
        static string _dbfUpload;
        static string _dbfDownload;
        static string _SASFoxpro;
        static string _PerusahaanName;
        static string _PerusahaanAddress;
        static string _PerusahaanTelp;
        static string _PerusahaanKota;
        static DateTime _LastPJTClosing;
        static string _DBFinance = ISA.Toko.Properties.Settings.Default.DBFinance;
        static bool _PS;
        static bool _KS;
        static DateTime _ServerDate;
        static Boolean _pinResult;
        static Boolean _pinReport;
        static Boolean _pinResultRekon;
        static Boolean _pinOverdue;

        public static bool HasKasir 
        {
             get { return _KS; }
            set { _KS = value; }
        }
        public static bool IsPS
        {
            get { return _PS; }
            set { _PS = value; }
        }

        public static string DBFinance
        {
            get
            {
                // return _SASFoxpro;
                return _DBFinance;
            }
            set
            {
                _DBFinance = value;
            }
        }

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

        public static string PerusahaanAddress
        {
            get
            {
                return _PerusahaanAddress;
            }
            set
            {
                _PerusahaanAddress = value;
            }
        }

        public static string PerusahaanTelp
        {
            get
            {
                return _PerusahaanTelp;
            }
            set
            {
                _PerusahaanTelp = value;
            }
        }

        public static string PerusahaanKota
        {
            get
            {
                return _PerusahaanKota;
            }
            set
            {
                _PerusahaanKota = value;
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
                //MessageBox.Show(dt.Rows.Count.ToString());
                if (dt.Rows.Count > 0)
                {
                    _cabangID = Tools.isNull( dt.Rows[0]["InitCabang"].ToString(),"").ToString();
                    _perusahaanID = Tools.isNull(dt.Rows[0]["InitPerusahaan"].ToString(), "").ToString();
                    _PerusahaanName = Tools.isNull(dt.Rows[0]["Nama"].ToString(), "").ToString();
                    _PerusahaanAddress = Tools.isNull(dt.Rows[0]["Alamat"].ToString(), "").ToString();
                    _PerusahaanTelp = Tools.isNull(dt.Rows[0]["Telp"].ToString(), "").ToString();
                    _PerusahaanKota = Tools.isNull(dt.Rows[0]["Kota"].ToString(), "").ToString();
                    _gudang = Tools.isNull(dt.Rows[0]["InitGudang"].ToString(), "").ToString();
                    _PS = Convert.ToBoolean(dt.Rows[0]["PartStation"]);
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
            _KS = Convert.ToBoolean(Class.AppSetting.GetValue("KASIR"));
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

        public static Boolean pinResult
        {
            get
            {
                return _pinResult;
            }
            set
            {
                _pinResult = value;
            }
        }

        public static Boolean pinOverdue
        {
            get
            {
                return _pinOverdue;
            }
            set
            {
                _pinOverdue = value;
            }
        }

        public static Boolean pinReport
        {
            get
            {
                return _pinReport;
            }
            set
            {
                _pinReport = value;
            }
        }
        public static Boolean pinResultRekon
        {
            get
            {
                return _pinResultRekon;
            }
            set
            {
                _pinResultRekon = value;
            }
        }
    }
}
