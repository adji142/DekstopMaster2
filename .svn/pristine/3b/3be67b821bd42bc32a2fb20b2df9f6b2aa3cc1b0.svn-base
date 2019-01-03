
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
using ISA.DAL;

namespace ISA.DAL
{
    public class Database:IDisposable 
    {
        string connStrTemplate = "Data Source={0}; Initial Catalog={1};Min Pool Size=5;Max Pool Size=60;user id={2};password={3};Connect Timeout=300";
        static string defaultPath="C:\\ISAApp\\";
        SqlConnection _connection;
        List  <Command > _command;
        SqlTransaction _transaction;

        public static string FilePath
        {
            get
            {
                string path;
                
                path = typeof(Database).Assembly.Location.Replace("SAS.DAL", "");
                path = path.Replace(".dll", "");
                path = path.Replace(".exe", "");
                return path;
            }
        }

        public static string Host
        {
            get
            {
                string path;
                string host = "";
                path = typeof(Database).Assembly.Location.Replace("SAS.DAL", "");
                path = path.Replace(".dll", "");
                path = path.Replace(".exe", "");

                string fileName = "host.config.xml";
                fileName = path + fileName;

                if (!File.Exists (fileName ))
                {
                    fileName = defaultPath + "host.config.xml";
                }

                XmlDocument xdoc = new XmlDocument();

                if (File.Exists(fileName))
                {
                    xdoc.Load(fileName);
                }
                XmlNodeList xlist = xdoc.SelectNodes("root/row");
                if (xlist.Count > 0)
                {
                    if (xlist[0].Attributes["default"].Value=="1")
                        host = xlist[0].Attributes["host"].Value;
                }
                return host;


            }

        }

        public Database()
        {
            string path;
            path = typeof(Database).Assembly.Location.Replace("SAS.DAL", "");
            path = path.Replace(".dll", "");
            path = path.Replace(".exe", "");
           
            string fileName = "host.config.xml";
            string host = "";
            string user = "";
            string password = "";
            string database = "";

            fileName = path + fileName;
            if (!File.Exists(fileName))
            {
                fileName = defaultPath + "host.config.xml";
            }

            XmlDocument xdoc = new XmlDocument();

            if (File.Exists(fileName))
            {
                xdoc.Load(fileName);
            }
            XmlNodeList xlist = xdoc.SelectNodes("root/row[@default='1']");
            if (xlist.Count > 0)
            {
                if (xlist[0].Attributes["default"].Value == "1")
                {
                    user = DecodePassword(xlist[0].Attributes["user"].Value);
                    password = DecodePassword(xlist[0].Attributes["pwd"].Value);
                    host = xlist[0].Attributes["host"].Value;
                    database = DecodePassword(xlist[0].Attributes["datasource"].Value);
                }
            }
            string connStr = string.Format(connStrTemplate, host, database, user, password);
            //connStr = "Data Source=skyline\\sqlexpress; Initial Catalog=ISAdb;Min Pool Size=5;Max Pool Size=60;user id=sa;password=passwordsql;Connect Timeout=300";
            _connection = new SqlConnection(connStr);
            _command = new List<Command>();
            _connection.Open();
        }

        public Database(string id)
        {

            string path;
            string fileName = "host.config.xml";
            string host = string.Empty;
            string user = "";
            string password = "";
            string database = "";

            path = typeof(Database).Assembly.Location.Replace("SAS.DAL", "");
            path = path.Replace(".dll", "");
            path = path.Replace(".exe", "");

            fileName = path + fileName;
            if (!File.Exists(fileName))
            {
                fileName = defaultPath + "host.config.xml";
            }

            XmlDocument xdoc = new XmlDocument();

            if (File.Exists(fileName))
            {
                xdoc.Load(fileName);
            }
            XmlNodeList xlist = xdoc.SelectNodes("root/row[@id='" + id + "']");
            if (xlist.Count > 0)
            {
                if (xlist[0].Attributes["id"].Value == id)
                {
                    host = xlist[0].Attributes["host"].Value;
                    user = DecodePassword(xlist[0].Attributes["user"].Value);
                    password = DecodePassword(xlist[0].Attributes["pwd"].Value);
                    database = DecodePassword(xlist[0].Attributes["datasource"].Value);
                }
            }
            
            string connStr = string.Format(connStrTemplate, host, database, user, password);
            //connStr = "Data Source=skyline\\sqlexpress; Initial Catalog=ISAdb;Min Pool Size=5;Max Pool Size=60;user id=sa;password=passwordsql;Connect Timeout=300";
            _connection = new SqlConnection(connStr);
            _command = new List<Command>();
            _connection.Open();
        }


        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public List <Command> Commands
        {
            get
            {
                return _command;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public Command CreateCommand(string procName)
        {
            Command cmd = new Command(procName);
            cmd.Database = this;
            return cmd;                
        }
       




        public void Open ()
        {
            if (_connection.State == ConnectionState.Closed )
            {
                _connection.Open ();
            }
        }
    
        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();            
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }            
        }
        

        public void Dispose()
        {
            this.Close();
            _connection.Dispose ();
            
        }

        public string DecodePassword(string password)
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

        public string EncodePassword(string password)
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
    }

    public class Command
    {
        string _procedureName;
        List<Parameter> _paramaters;
        Database _db;


        SqlCommand cmd;
        public Command(string procedureName)
        {
            cmd = new SqlCommand();
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 18000;
            _paramaters = new List<Parameter>();
        }

        public Database Database
        {
            set
            {
                _db = value;
                cmd.Connection = _db.Connection;
            }
        }

        public List<Parameter> Parameters
        {
            get
            {
                return _paramaters;
            }
            set
            {
                _paramaters = value;
            }
        }

        public string ProcedureName
        {
            get
            {
                return _procedureName;
            }
            set
            {
                _procedureName = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return cmd.CommandType;
            }

            set
            {
                cmd.CommandType = value;
            }
        }
        public DataSet ExecuteDataSet()
        {
            SqlDataAdapter objDa;
            SqlParameter sqlParam;
            DataSet ds = new DataSet();

            try
            {
                //Setup Parameters
                cmd.Parameters.Clear();
                foreach (Parameter param in this.Parameters)
                {

                    sqlParam = new SqlParameter(param.ParameterName, param.DataType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                objDa = new SqlDataAdapter(cmd);

                objDa.Fill(ds);

                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExecuteDataTable()
        {
            SqlDataAdapter objDa;
            SqlParameter sqlParam;
            DataTable dt = new DataTable();

            try
            {
                //Setup Parameters
                cmd.Parameters.Clear();
                foreach (Parameter param in this.Parameters)
                {

                    sqlParam = new SqlParameter(param.ParameterName, param.DataType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                objDa = new SqlDataAdapter(cmd);

                objDa.Fill(dt);

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery()
        {
            SqlParameter sqlParam;
            int affectedRows;

            try
            {
                //Setup Parameters

                cmd.Parameters.Clear();

                foreach (Parameter param in this.Parameters)
                {

                    sqlParam = new SqlParameter(param.ParameterName, param.DataType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                if (this._db.Transaction != null)
                {
                    cmd.Transaction = this._db.Transaction;
                }

                affectedRows = cmd.ExecuteNonQuery();

                return affectedRows;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
            
        }


        public object ExecuteScalar()
        {
            SqlParameter sqlParam;
            object returnValue;

            try
            {
                //Setup Parameters

                cmd.Parameters.Clear();

                foreach (Parameter param in this.Parameters)
                {

                    sqlParam = new SqlParameter(param.ParameterName, param.DataType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                if (this._db.Transaction != null)
                {
                    cmd.Transaction = this._db.Transaction;
                }

                returnValue = cmd.ExecuteScalar();

                return returnValue;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader ExecuteReader()
        {
            SqlParameter sqlParam;
            SqlDataReader returnValue;

            try
            {
                //Setup Parameters

                cmd.Parameters.Clear();

                foreach (Parameter param in this.Parameters)
                {

                    sqlParam = new SqlParameter(param.ParameterName, param.DataType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                if (this._db.Transaction != null)
                {
                    cmd.Transaction = this._db.Transaction;
                }

                returnValue = cmd.ExecuteReader();

                return returnValue;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameter(string parameterName, SqlDbType dataType, object value)
        {
            Parameters.Add(new Parameter(parameterName, dataType, value));
        }

    }

    public class Parameter
    {
        string _parameterName;
        SqlDbType _dataType;
        object _value;

        public Parameter( string parameterName, SqlDbType dataType, object value)
        {
            _parameterName = parameterName;
            _dataType = dataType;
            _value = value;
        }

        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                _parameterName = value;
            }
        }

        public SqlDbType DataType
        {
            get
            {
                return _dataType ;
            }
            set
            {
                _dataType  = value;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

    }

    public class Parameters : List<Parameter>
    {
        public void AddParameter(string parameterName, SqlDbType dataType, object value)
        {
            Add(new Parameter(parameterName, dataType, value));
        }
    }

    public class DBTools
    {
        public static DataTable DBGetDataTable(string sql, List<Parameter> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static object DBGetScalar(string sql, List<Parameter> parameters)
        {
            object result = null;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    result = db.Commands[0].ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static DataTable DBGetDataTableByRowID(string sql, Guid rowID)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = prm;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable DBGetDataTableByDate(string sql, DateTime? tglAwal, DateTime? tglAkhir)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, tglAwal));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, tglAkhir));
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = prm;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable DBGetDataTable(string _dbID, string sql, List<Parameter> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(_dbID))
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static object DBGetScalar(string _dbID, string sql, List<Parameter> parameters)
        {
            object result = null;
            try
            {
                using (Database db = new Database(_dbID))
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = parameters;
                    result = db.Commands[0].ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static DataTable DBGetDataTableByRowID(string _dbID, string sql, Guid rowID)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
            try
            {
                using (Database db = new Database(_dbID))
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = prm;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable DBGetDataTableByDate(string _dbID, string sql, DateTime? tglAwal, DateTime? tglAkhir)
        {
            DataTable dt = new DataTable();
            List<Parameter> prm = new List<Parameter>();
            prm.Add(new Parameter("@fromDate", SqlDbType.Date, tglAwal));
            prm.Add(new Parameter("@toDate", SqlDbType.Date, tglAkhir));
            try
            {
                using (Database db = new Database(_dbID))
                {
                    db.Commands.Add(db.CreateCommand(sql));
                    db.Commands[0].Parameters = prm;
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DateTime? DBGetServerDate()
        {
            //DateTime? tgl = null;
            object otgl = DBGetScalar("usp_GetServerDate", new List<Parameter>());
            return Convert.IsDBNull(otgl) ? null : (DateTime?)Convert.ToDateTime(otgl);
        }
    }
}
