using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Penjualan
{
    public partial class frmFoxproInjector : ISA.Toko.BaseForm
    {
        public frmFoxproInjector()
        {
            InitializeComponent();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFoxproInjector_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 0));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";

            try
            {
                
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    // Get incompleted Job
                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 0));
                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_UPDATE"));

                    // Loop for each incompleted job
                    if (dt.Rows.Count > 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string connDatabaseStr = string.Format(_connStrTemplate, LookupInfo.GetValue("FOXINJECTOR", "DATABASE_PATH"));
                        string connKasirStr = string.Format(_connStrTemplate, LookupInfo.GetValue("FOXINJECTOR", "KASIR_PATH"));

                        using (OleDbConnection connDatabase = new OleDbConnection(connDatabaseStr), connKasir = new OleDbConnection(connKasirStr))
                        {
                            connDatabase.Open();
                            connKasir.Open();
                            //Create Commands
                            OleDbCommand cmdDatabase = new OleDbCommand();
                            cmdDatabase.Connection = connDatabase;

                            OleDbCommand cmdKasir = new OleDbCommand();
                            cmdKasir.Connection = connKasir;

                            foreach (DataRow dr in dt.Rows)
                            {
                                db.BeginTransaction();
                                //Update table FoxproInjection, set complete to true
                                db.Commands[1].Parameters.Clear();
                                db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[1].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 1));
                                db.Commands[1].Parameters.Add(new Parameter("@runDate", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "ISA.WinServices"));
                                db.Commands[1].ExecuteNonQuery();

                                string script = dr["Script"].ToString();
                                //inject to foxpro                                                                    
                                if (dr["Target"].ToString().ToUpper() == "KASIR")
                                {
                                    cmdKasir.CommandText = script;
                                    cmdKasir.CommandType = CommandType.Text;
                                    cmdKasir.ExecuteNonQuery();
                                }
                                else
                                {
                                    cmdDatabase.CommandText = script;
                                    cmdDatabase.CommandType = CommandType.Text;
                                    cmdDatabase.ExecuteNonQuery();
                                }

                                db.CommitTransaction();
                            }
                            connDatabase.Close();
                            connKasir.Close();
                        }
                    }
                }
                MessageBox.Show("Data sudah dikirim ke Foxpro");
                RefreshData();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
