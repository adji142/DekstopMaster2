using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace ISA.Finance.Register
{
    public partial class frmRegisterDetailUpdate : ISA.Finance.BaseForm
    {
        Guid _HeaderID = Guid.Empty;
        string _RecordID = string.Empty;
        public frmRegisterDetailUpdate()
        {
            InitializeComponent();
        }

          private void RefreshData()
        {
            if (this.Caller is frmRegisterBrowser)
            {
                frmRegisterBrowser frmCaller = (frmRegisterBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataHeader(_HeaderID);
                frmCaller.RefreshDetail(_HeaderID);
                frmCaller.FindGridHeader("RowIDHeader", _HeaderID.ToString());
            }
        }

        private void InsertData(DataTable TagihDetail)
        {
            try
            { 
               
                using(Database db = new Database(GlobalVar.DBName))
                {
                   
                    for (int i = 0; i < TagihDetail.Rows.Count;i++ )
                    {
                        db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_INSERT]"));
                        db.Commands[i].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[i].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                        db.Commands[i].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ISA.Common.Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial,i)));
                        db.Commands[i].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _RecordID));
                        db.Commands[i].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, (Guid)TagihDetail.Rows[i]["RowID"]));
                        db.Commands[i].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, TagihDetail.Rows[i]["KPID"].ToString()));
                        if (Convert.ToInt32(TagihDetail.Rows[i]["Cicil"]) == 0)
                            db.Commands[i  ].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, string.Empty));
                        else
                            db.Commands[i  ].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "KONTRAK"));
                       
                        db.Commands[i].Parameters.Add(new Parameter("@KodeTagih", SqlDbType.VarChar, TagihDetail.Rows[i]["KodeTransaksi"].ToString()));
                        db.Commands[i].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpJual"],"0"))));
                        db.Commands[i].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpKredit"], "0"))));
                        db.Commands[i].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpSisa"], "0"))));
                        db.Commands[i].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                    }


                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }
                    db.CommitTransaction();
                  //  string a = Numerator.BookNumerator("REG");
                }

                RefreshData();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            this.Close();
        }

        public frmRegisterDetailUpdate(Form caller_ , Guid HeaderID_, string RecordID_)
        {
            this.Caller = caller_;
            _HeaderID = HeaderID_;
            _RecordID = RecordID_;
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            ErrorProvider ep = new ErrorProvider();
            if (rangeDateBox1.FromDate.HasValue==false || rangeDateBox1.ToDate.HasValue==false)
            {
                ep.SetError(rangeDateBox1, "Harus Di Isi");
                return;
            }

             try
            {
                
                
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_Vw2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, textBox1.Text.Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

               if (dt.Rows.Count==0)
               {
                   MessageBox.Show("No Data !!!");
                   return;
               }

               InsertData(dt);

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

        private void frmRegisterDetailUpdate_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.AddDays(-7);
            rangeDateBox1.ToDate = DateTime.Now;
        }
        

        
    }
}
