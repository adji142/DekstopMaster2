using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Data;
using ISA.DAL;
using ISA.Common;

namespace ISA.Bengkel
{
    class SecurityManager
    {
        public enum enAppRole {Manager, Admin, Operator, Auditor };
        public enum enBnsRole {Penjualan, Stock, Checker, Piutang, Accounting}
        public enum enState { LogIn, LogOut }
        

        static string _userID;
        static string _userName;
        static string _userInitial;
        static DateTime _TglPassword;
        static bool _active;

        static List<string> _parts;
        static List<string> _rights;
        static List<string> _appRoles;
        static List<string> _bizRoles;
        
        static string _clientIP = "";
        static enState _state = enState.LogOut;

        static int _timeOutCounter = 0;

        public static string UserID
        {
            get { return _userID ; }
        }

        public static string UserName
        {
            get { return _userName; }
        }

        public static string UserInitial
        {
            get { return _userInitial; }
        }

        public static DateTime TglPassword
        {
            get { return _TglPassword; }
        }

        public static bool Active
        {
            get { return _active; }
        }

        public static List<string> Parts
        {
            get { return _parts; }
        }

        public static List<string> Rights
        {
            get { return _rights; }
        }

        public static List<string> AppRoles
        {
            get { return _appRoles; }
        }

        public static List<string> BizRoles
        {
            get { return _bizRoles; }
        }

        public static string ClientIP
        {
            get
            {
                return _clientIP;
            }
        }

        public static enState State
        {
            get
            {
                return _state;
            }
        }

        public static int TimeOutCounter
        {
            get
            {
                return _timeOutCounter;
            }
        }

        public static string ClientIPAddress
        {
            get
            {
                if (_clientIP == "")
                {
                    //get IP Address
                    IPAddress[] localIPs = Dns.GetHostAddresses(System.Net.Dns.GetHostName());

                    foreach (IPAddress localIP in localIPs)
                    {
                        if (!IPAddress.IsLoopback(localIP) && !localIP.IsIPv6LinkLocal && !localIP.IsIPv6Multicast && !localIP.IsIPv6SiteLocal)
                        {
                            _clientIP = localIP.ToString();
                        }
                    }
                }
                return _clientIP;
            }
        }

        public static string ClientHostName
        {
            get
                {
                    string host = string.Empty;
                    host = Dns.GetHostName();
                    return host;
                }
        }


        public static bool IsAuthenticate(string userID, string password)
        {                     
            bool valid = false;

            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_AUTHENTICATE"));
                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                db.Commands[0].Parameters.Add(new Parameter("@password", SqlDbType.VarChar, password));
                dt = db.Commands[0].ExecuteDataTable();                
            }

            if (dt.Rows.Count > 0)
            {
                _userID = userID;
                _userName = dt.Rows[0]["UserName"].ToString();
                _userInitial = dt.Rows[0]["Initial"].ToString();
                _TglPassword = DateTime.Parse(dt.Rows[0]["TglPassword"].ToString());
                _active = bool.Parse(dt.Rows[0]["Active"].ToString());

                if (_active)
                {                    
                    using (Database db = new Database())
                    {
                        //Get Parts
                        db.Commands.Add(db.CreateCommand("usp_vwSecurityPartsUsers_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        dt = db.Commands[0].ExecuteDataTable();
                        _parts = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                           _parts.Add (dr["PartID"].ToString());
                        }
                    
                        //Get Rights
                        db.Commands.Add(db.CreateCommand("usp_SecurityUsersRights_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));                        
                        dt = db.Commands[1].ExecuteDataTable();
                        _rights = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                           _rights.Add (dr["RightID"].ToString());
                        }                    
                                        
                        //Get App Roles
                        db.Commands.Add(db.CreateCommand("usp_SecurityRolesUsers_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        db.Commands[2].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, "Application"));
                        dt = db.Commands[2].ExecuteDataTable();
                        _appRoles = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                           _appRoles.Add (dr["RoleID"].ToString());
                        }

                        //Get Biz Roles
                        db.Commands.Add(db.CreateCommand("usp_SecurityRolesUsers_LIST"));
                        db.Commands[3].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                        db.Commands[3].Parameters.Add(new Parameter("@roleType", SqlDbType.VarChar, "Business"));
                        dt = db.Commands[3].ExecuteDataTable();
                        _bizRoles = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                           _bizRoles.Add (dr["RoleID"].ToString());
                        }
                    }
                    valid = true;
                }
                else
                {
                    MessageBox.Show(Messages.Error.AccountInactive, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            //get IP Address
            IPAddress[] localIPs = Dns.GetHostAddresses(System.Net.Dns.GetHostName());


            if (valid)
            {
                SecurityManager.ResetCounter();
                _state = enState.LogIn;                
            }
            return valid;
        }

        public static bool IsLogin
        {
            get{
                bool Valid = false;
                try
                {
                   
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_LoginUser_AUTHENTICATE]"));

                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@HostName", SqlDbType.VarChar, SecurityManager.ClientHostName));
                        db.Commands[0].Parameters.Add(new Parameter("@IpAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                        Valid = Convert.ToBoolean(db.Commands[0].ExecuteScalar());
                        if (SecurityManager.UserID == "KAMORO")
                        {
                            Valid = false;
                        }
                    }

                 
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                return Valid;
            }
        }

        public static string GetUserLogin(string UserID_)
        {
            string Msgg = string.Empty;
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_LoginUser_List]"));

                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
               
            }
            Msgg = "User : " + _userID + "\tSudah login pada \nPC : " + dt.Rows[0]["HostName"].ToString() + "\t IP : " + dt.Rows[0]["IPAddress"].ToString(); 
            return Msgg;

        }

        public static void SetUserLogin(string UserID_, bool Status_)
        {
            try
            {
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_LoginUser_UPDATE]"));

                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@HostName", SqlDbType.VarChar, SecurityManager.ClientHostName));
                    db.Commands[0].Parameters.Add(new Parameter("@IpAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusLogin", SqlDbType.Bit, Status_));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public static void AlwaysAuthenticate()
        {
            //_userID = "RAY";
            //_userInitial = "RAY";

            //SecurityManager.IsAuthenticate("RAY", EncodePassword("12345"));
            SecurityManager.IsAuthenticate("WRT", EncodePassword( "wirwir"));
            IsAuthenticate("WRT", EncodePassword("wirwir"));
            //SecurityManager.RecordLoginHistory();

            //if (SecurityManager.IsPasswordExpired())
            //{
            //    frmChangePassword ifrmChild = new frmChangePassword(true);
            //    ifrmChild.Show();
            //}


            _state = enState.LogIn;
        }

        public static bool IsAppRole(string role)
        {
            bool valid = false;
            if (_appRoles != null)
            {
                if (_appRoles.Contains (role))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsBizRole(string role)
        {
            bool valid = false;
            if (_bizRoles != null)
            {
                if (_bizRoles.Contains(role))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsPenjualan()
        {
            return IsBizRole("FIN.PENJUALAN");
        }

        public static bool IsAccounting()
        {
            return IsBizRole("FIN.ACC");
        }

        public static bool IsChecker()
        {
            return IsBizRole("FIN.CHECKER");
        }

        public static bool IsExpedisi()
        {
            return IsBizRole("FIN.EXPEDISI");
        }

        public static bool IsGudang()
        {
            return IsBizRole("FIN.GUDANG");
        }

        public static bool IsPiutang()
        {
            return IsBizRole("FIN.PIUTANG");
        }

        public static bool HasRight(string right)
        {
            bool valid = false;
            if (_rights != null)
            {
                if (_rights.Contains(right))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool HasPart(string part)
        {
            bool valid = false;
            if (_parts != null)
            {
                if (_parts.Contains(part))
                {
                    valid = true;
                }
            }
            return valid;
        }

        public static bool IsManager()
        {
            return IsAppRole("FIN.MANAGER");
        }

        public static bool IsAdministrator()
        {
            return IsAppRole("FIN.ADMIN");
        }

        public static bool IsAOperator()
        {
            return IsAppRole("FIN.OPERATOR");
        }

        public static bool IsAuditor()
        {
            return IsAppRole("FIN.AUDITOR");
        }

        public static void ChangePassword(string newPassword)
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_UPDATE"));
                
                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].Parameters.Add(new Parameter("@userName", SqlDbType.VarChar, SecurityManager.UserName));
                db.Commands[0].Parameters.Add(new Parameter("@initial", SqlDbType.VarChar, SecurityManager.UserInitial));
                db.Commands[0].Parameters.Add(new Parameter("@Password", SqlDbType.VarChar, newPassword));
                db.Commands[0].Parameters.Add(new Parameter("@TglPassword", SqlDbType.DateTime, DateTime.Now));
                db.Commands[0].Parameters.Add(new Parameter("@Active", SqlDbType.VarChar, SecurityManager.Active));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));                
                db.Commands[0].ExecuteNonQuery();                
            }
        }


        public static void LogOut()
        {
            _userID = "";
            _userInitial = "";
            ClearCredential();
            _state = enState.LogOut;            
        }

        public static void ResetCounter()
        {
            _timeOutCounter = 0;
        }

        public static void AddCounter()
        {            
            _timeOutCounter++;         
        }

        //public static bool AskPasswordManager()
        //{
        //    bool valid = false;

        //    try
        //    {
        //        Administrasi.frmAskPasswordManager ifrmChild = new Administrasi.frmAskPasswordManager();
        //        DialogResult dResult = ifrmChild.ShowDialog();
        //        if (dResult == DialogResult.Yes)
        //        {
        //            valid = true;
        //        }
        //        return valid;
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    return valid;
        //}

 
        public static void ClearCredential()
        {
            _parts = null;
            _rights = null;
            _bizRoles = null;
            _appRoles = null;
        }

        public static void DisableUser(string userID)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityUsers_ENABLED"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                    db.Commands[0].Parameters.Add(new Parameter("@active", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "SYSTEM"));
                    db.Commands[0].ExecuteNonQuery();                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }        
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

        public static void RecordLoginHistory()
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginHistory_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglLogin", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@ipAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public static void RecordLoginAttempt(string userID)
        {
            try
            {
                int maxAttempt = int.Parse ( LookupInfo.GetValue("SECURITY", "MAX_LOGIN_ATTEMPT"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginAttempt_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglLogin", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@ipAddress", SqlDbType.VarChar, SecurityManager.ClientIPAddress));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }



        public static void ClearLoginAttempt(string userID)
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityLoginAttempt_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));                                        
                    db.Commands[0].ExecuteNonQuery();                  
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public static bool IsPasswordExpired()
        {
            bool expired = false;


            int maxAge = int.Parse( LookupInfo.GetValue("SECURITY", "PASSWORD_AGE"));
            if (maxAge > 0)
            {
                int datediff = DateTime.Now.Subtract(SecurityManager.TglPassword).Days;

                if (datediff > maxAge)
                {
                    expired = true;
                }
            }

            return expired;
        }

        public static bool IsExist(string userID)
        {
            bool valid = false;

            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_SecurityUsers_EXIST"));
                db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, userID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count > 0)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }

            return valid;
        }
    }
}
