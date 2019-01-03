using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace ISA.DAL
{
    public class Foxpro
    {
        static string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";

        public enum enFoxproTypes
        {
            Varchar,
            Char,
            Numeric,
            Logical,
            DateTime,
            Memo
        }

        public class DataStruct
        {
            public string ISAName;
            public string FieldName;
            public enFoxproTypes DataType;
            public int Length;

            public DataStruct(string isaName, string fieldName, enFoxproTypes dataType, int length)
            {
                ISAName = isaName;
                FieldName = fieldName;
                DataType = dataType;
                Length = length;
            }
        }

        public class IndexStruct
        {
            public string Field;
            public string OrderName;

            public IndexStruct(string field, string orderName)
            {
                Field = field;
                OrderName = orderName;
            }
        }

        public static DataTable ReadFile(string fileName)
        {
            DataTable dt = new DataTable();
            if (File.Exists(fileName))
            {
                FileInfo info = new FileInfo(fileName);
                string tableName = info.Name;
                string connStr = String.Format(_connStrTemplate, info.DirectoryName);

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = @"SET DELETED ON";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"SELECT * FROM " + tableName;
                    cmd.CommandType = CommandType.Text;
                    //

                    //OleDbCommand cmd = new OleDbCommand();
                    //cmd.Connection = conn;
                    //cmd.CommandText = tableName;
                    //cmd.CommandType = CommandType.TableDirect;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType == System.Type.GetType("System.DateTime"))
                        {
                            if (((DateTime)row[col.ColumnName]) <= new DateTime(1900, 1, 1))
                            {
                                row[col.ColumnName] = DBNull.Value;
                            }
                        }
                    }
                }
            }

            return dt;
        }

        public void WriteData(DataRow dr)
        {
            //foreach
        }

        public static void WriteFile(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data)
        {
            ProgressBar pb = new ProgressBar();
            List<IndexStruct> idx = new List<IndexStruct>();

            CreateDBF(filePath, tableName, tableStructure, data, pb, idx);
        }

        public static void WriteFile(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar)
        {
            List<IndexStruct> idx = new List<IndexStruct>();

            CreateDBF(filePath, tableName, tableStructure, data, progressBar, idx);
        }

        private static void CreateDBF(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar)
        {

            using (OleDbConnection conn = new OleDbConnection("Provider = VFPOLEDB;Data Source=\\\\jktdev\\sasapp$\\SAS\\database"))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "EXECSCRIPT([USE " + tableName + "]+CHR(13)+CHR(10)+[COPY STRUCTURE TO 'C:\\TEMP\\DumpDownload\\" + tableName + "' WITH CDX])";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }



            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = data.Rows.Count;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }



            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                // cmd.CommandText = "EXECSCRIPT([USE HKRMAGUD]+CHR(13)+CHR(10)+[COPY STRUCTURE TO 'C:\\TEMP\\DumpUpload\\HKRMAGUD' WITH CDX])";

                //// cmd.CommandText = "EXECSCRIPT([USE " + tableName + "]+CHR(13)+CHR(10)+[COPY STRUCTURE TO 'C:\\TEMP\\DumpUpload\\'" + tableName + " WITH CDX])";
                // cmd.ExecuteNonQuery();

                foreach (DataRow dr in data.Rows)
                {
                    progressBar.Increment(1);
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public static void WriteFile(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar, List<IndexStruct> index)
        {
            CreateDBF(filePath, tableName, tableStructure, data, progressBar, index);
        }

        private static void CreateDBF(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar, List<IndexStruct> index)
        {
            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = data.Rows.Count;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }

            cmdText = "CREATE TABLE " + tableName + " (" + cStructure.ToString() + ")";
            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();

                string indexCmd;

                foreach (IndexStruct idx in index)
                {
                    indexCmd = "EXECSCRIPT([SELECT 0]+CHR(13)+CHR(10)+[USE " + tableName + " EXCLUSIVE IN 0]+CHR(13)+CHR(10)+[INDEX ON " + tableName + "." + idx.Field + " TAG " + idx.OrderName + "]+CHR(13)+CHR(10)+[CLOSE TABLE])";
                    cmd.CommandText = indexCmd;
                    cmd.ExecuteNonQuery();
                }

                foreach (DataRow dr in data.Rows)
                {
                    progressBar.Increment(1);
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public static void WriteReaderToFile(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, List<IndexStruct> index, Form form, ProgressBar progressBar, Label lblCount)
        {
            CreateReaderDBF(filePath, tableName, tableStructure, dr, index, form, progressBar, lblCount, true);
        }



        public static void WriteReaderToFile(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, List<IndexStruct> index, Form form, ProgressBar progressBar, Label lblCount, bool closeReader)
        {
            CreateReaderDBF(filePath, tableName, tableStructure, dr, index, form, progressBar, lblCount, closeReader);
        }

        private static void CreateReaderDBF(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, List<IndexStruct> index, Form form, ProgressBar progressBar, Label lblCount, bool closeReader)
        {
            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }

            cmdText = "CREATE TABLE " + tableName + " (" + cStructure.ToString() + ")";
            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();

                string indexCmd;

                foreach (IndexStruct idx in index)
                {
                    indexCmd = "EXECSCRIPT([SELECT 0]+CHR(13)+CHR(10)+[USE " + tableName + " EXCLUSIVE IN 0]+CHR(13)+CHR(10)+[INDEX ON " + tableName + "." + idx.Field + " TAG " + idx.OrderName + "]+CHR(13)+CHR(10)+[CLOSE TABLE])";
                    cmd.CommandText = indexCmd;
                    cmd.ExecuteNonQuery();
                }

                int i = 0;
                while (dr.Read())
                {
                    progressBar.Increment(1);
                    if (progressBar.Value == progressBar.Maximum)
                    {
                        progressBar.Value = 0;
                    }
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();
                    i++;
                    lblCount.Text = i.ToString("#,##0");
                    form.Invalidate();
                    form.Refresh();

                }

                if (closeReader)
                {
                    dr.Close();
                }

                conn.Close();
                progressBar.Value = progressBar.Maximum;
            }


        }

        public static void WriteReaderToFile(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, string dbPath, Form form, ProgressBar progressBar, Label lblCount)
        {
            List<IndexStruct> idx = new List<IndexStruct>();

            CreateReaderDBF(filePath, tableName, tableStructure, dr, dbPath, idx, form, progressBar, lblCount);
        }

        private static void CreateReaderDBF(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, string DBLocation, List<IndexStruct> index, Form form, ProgressBar progressBar, Label lblCount)
        {
            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }

            cmdText = "CREATE TABLE " + tableName + " (" + cStructure.ToString() + ")";
            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();

                //foreach (IndexStruct idx in index)
                //{
                //    indexCmd = "EXECSCRIPT([SELECT 0]+CHR(13)+CHR(10)+[USE " + tableName + " EXCLUSIVE IN 0]+CHR(13)+CHR(10)+[INDEX ON " + tableName + "." + idx.Field + " TAG " + idx.OrderName + "]+CHR(13)+CHR(10)+[CLOSE TABLE])";
                //    cmd.CommandText = indexCmd;
                //    cmd.ExecuteNonQuery();
                //}

                string connStr2 = "Provider = VFPOLEDB;Data Source=" + DBLocation;

                using (OleDbConnection connIdx = new OleDbConnection(connStr2))
                {
                    //Create Table
                    OleDbCommand cmdIdx = new OleDbCommand();
                    cmdIdx.Connection = connIdx;
                    cmdIdx.CommandText = "EXECSCRIPT([USE " + tableName + "]+CHR(13)+CHR(10)+[COPY STRUCTURE TO '" + filePath + tableName + "' WITH CDX])";
                    cmdIdx.CommandType = CommandType.Text;
                    connIdx.Open();
                    cmdIdx.ExecuteNonQuery();
                }

                int i = 0;
                while (dr.Read())
                {
                    progressBar.Increment(1);
                    if (progressBar.Value == progressBar.Maximum)
                    {
                        progressBar.Value = 0;
                    }
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break; 
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();
                    i++;
                    lblCount.Text = i.ToString("#,##0");
                    form.Invalidate();
                    form.Refresh();
                }
                dr.Close();
                progressBar.Value = progressBar.Maximum;
                conn.Close();
            }
        }

        public static void CreateDBFForUPLPT(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar)
        {

            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";

            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = data.Rows.Count;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }

            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();

                foreach (DataRow dr in data.Rows)
                {
                    progressBar.Increment(1);
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        public static void InsertDeletedRecord(string filePath, string tableName,  List<DataStruct> tableStructure, DataTable data, string ColumnName)
        {
            string connStr = String.Format(_connStrTemplate, filePath);

            StringBuilder fieldNames = new StringBuilder();
            string strINSERT = "";

            foreach (DataStruct field in tableStructure)
            {
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
            }

            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();

                foreach (DataRow dr in data.Rows)
                {
                    StringBuilder values = new StringBuilder();
                    string value = string.Empty;
                 
                    foreach (DataStruct field in tableStructure)
                    {
                        values.Append(values.ToString() != "" ? ", " : "");
                        if (field.FieldName.Equals(ColumnName))
                        {
                            values.Append("'" + dr["RecordID"].ToString().Trim() + "'");
                        }
                        else
                        {
                            switch (field.DataType)
                            {
                                case enFoxproTypes.DateTime:
                                    value = "CTOD(\"\")";
                                    break;
                                case enFoxproTypes.Numeric:
                                    value = "0";
                                    break;
                                case enFoxproTypes.Logical: 
                                    value = ".F.";
                                    break;
                                default:
                                    value = "\"\"";
                                    break;
                            }
                            values.Append(value);
                        }
                    }

                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();

                    string deleteCmd = "DELETE FROM " + tableName + " WHERE " + ColumnName + " = '" + dr["RecordID"].ToString().Trim() + "'";
                    cmd.CommandText = deleteCmd;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static DataTable ReadDeletedFile(string fileName)
        {
            DataTable dt = new DataTable();
            if (File.Exists(fileName))
            {
                FileInfo info = new FileInfo(fileName);
                string tableName = info.Name;
                string connStr = String.Format(_connStrTemplate, info.DirectoryName);

                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = @"SET DELETED OFF";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"SELECT * FROM " + tableName + " WHERE DELETED()" ;
                    cmd.CommandType = CommandType.Text;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.DataType == System.Type.GetType("System.DateTime"))
                        {
                            if (((DateTime)row[col.ColumnName]) <= new DateTime(1900, 1, 1))
                            {
                                row[col.ColumnName] = DBNull.Value;
                            }
                        }
                    }
                }
            }

            return dt;
        }

        public static void WriteData(string filePath, string tableName, List<DataStruct> tableStructure, SqlDataReader dr, List<IndexStruct> index, Form form, ProgressBar progressBar, Label lblCount, bool closeReader)
        {
            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }


            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();


                string indexCmd;

                foreach (IndexStruct idx in index)
                {
                    indexCmd = "EXECSCRIPT([SELECT 0]+CHR(13)+CHR(10)+[USE " + tableName + " EXCLUSIVE IN 0]+CHR(13)+CHR(10)+[INDEX ON " + tableName + "." + idx.Field + " TAG " + idx.OrderName + "]+CHR(13)+CHR(10)+[CLOSE TABLE])";
                    cmd.CommandText = indexCmd;
                    cmd.ExecuteNonQuery();
                }

                int i = 0;
                while (dr.Read())
                {
                    progressBar.Increment(1);
                    if (progressBar.Value == progressBar.Maximum)
                    {
                        progressBar.Value = 0;
                    }
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();
                    i++;
                    lblCount.Text = i.ToString("#,##0");
                    form.Invalidate();
                    form.Refresh();

                }

                if (closeReader)
                {
                    dr.Close();
                }

                conn.Close();
                progressBar.Value = progressBar.Maximum;
            }
        }

        public static void WriteData(string filePath, string tableName, List<DataStruct> tableStructure, DataTable data, ProgressBar progressBar)
        {
            string connStr = String.Format(_connStrTemplate, filePath);
            StringBuilder cStructure = new StringBuilder();
            StringBuilder fieldNames = new StringBuilder();

            DataTable dt = new DataTable();
            string fieldText = "";
            //Generate structure
            string cmdText = "";
            string strINSERT = "";

            progressBar.Minimum = 0;
            progressBar.Maximum = data.Rows.Count;
            progressBar.Value = 0;

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }

            cmdText = "CREATE TABLE " + tableName + " (" + cStructure.ToString() + ")";
            strINSERT = "INSERT INTO " + tableName + " (" + fieldNames.ToString() + ") VALUES({0})";

            foreach (DataStruct field in tableStructure)
            {
                switch (field.DataType)
                {
                    case enFoxproTypes.Varchar: fieldText = "VARCHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Char: fieldText = "CHAR (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Numeric: fieldText = "NUMERIC (" + field.Length.ToString() + ")";
                        break;
                    case enFoxproTypes.Logical: fieldText = "LOGICAL";
                        break;
                    case enFoxproTypes.DateTime: fieldText = "DATE";
                        break;
                    case enFoxproTypes.Memo: fieldText = "MEMO (" + field.Length.ToString() + ")";
                        break;
                }
                fieldNames.Append(fieldNames.ToString() != "" ? ", " : "");
                fieldNames.Append(field.FieldName);
                cStructure.Append(cStructure.ToString() != "" ? ", " : "");
                cStructure.Append(field.FieldName + " ");
                cStructure.Append(fieldText);
            }
          
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                //Create Table
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();

                string indexCmd;
             

                foreach (DataRow dr in data.Rows)
                {
                    progressBar.Increment(1);
                    StringBuilder values = new StringBuilder();
                    string value = "";
                    foreach (DataStruct field in tableStructure)
                    {
                        if (field.ISAName != "")
                        {
                            values.Append(values.ToString() != "" ? ", " : "");

                            if (dr[field.ISAName].GetType() == System.Type.GetType("System.DBNull"))
                            {
                                switch (field.DataType)
                                {
                                    case enFoxproTypes.DateTime:
                                        value = "CTOD(\"\")";
                                        break;
                                    case enFoxproTypes.Numeric:
                                        value = "0";
                                        break;
                                    case enFoxproTypes.Logical:
                                        value = ".F.";
                                        break;
                                    default:
                                        value = "\"\"";
                                        break;
                                }

                                values.Append(value);
                            }
                            else
                            {
                                if (dr[field.ISAName].GetType() != System.Type.GetType("System.Boolean"))
                                {
                                    if (dr[field.ISAName].GetType() == System.Type.GetType("System.DateTime"))
                                    {
                                        DateTime dateValue = (DateTime)dr[field.ISAName];
                                        value = "DATE(" + dateValue.Year.ToString() + "," + dateValue.Month.ToString() + "," + dateValue.Day.ToString() + ")";
                                        //((DateTime) dr[field.ISAName]).ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        if (field.DataType == enFoxproTypes.Numeric && string.IsNullOrEmpty(dr[field.ISAName].ToString()))
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = dr[field.ISAName].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((bool)dr[field.ISAName] == true)
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "1";
                                        }
                                        else
                                        {
                                            value = ".T.";
                                        }
                                    }
                                    else
                                    {
                                        if (field.DataType != enFoxproTypes.Logical)
                                        {
                                            value = "0";
                                        }
                                        else
                                        {
                                            value = ".F.";
                                        }
                                    }
                                }
                                value = value.Replace("\"", "'");
                                value = value.Replace("\0", "");

                                if (field.DataType != enFoxproTypes.Numeric && field.DataType != enFoxproTypes.DateTime && field.DataType != enFoxproTypes.Logical)
                                {
                                    values.Append(string.Format("\"{0}\"", value));
                                }
                                else
                                {
                                    values.Append(value);
                                }
                            }
                        }
                    }
                    string insertCmd;
                    insertCmd = string.Format(strINSERT, values.ToString());
                    cmd.CommandText = insertCmd;
                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }


    }
}
