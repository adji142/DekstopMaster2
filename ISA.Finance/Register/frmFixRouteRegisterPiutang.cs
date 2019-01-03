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

namespace ISA.Finance.Piutang
{
    public partial class frmFixRouteRegisterPiutang : ISA.Finance.BaseForm
    {
        DataTable TagihDetail;
        public frmFixRouteRegisterPiutang()
        {
            InitializeComponent();
        }

        public frmFixRouteRegisterPiutang(Form caller_)
        {
            InitializeComponent();
            this.Caller = caller_;
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            //searchDetail();
        }

        private void frmFixRouteRegisterPiutang_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.AddDays(-7);
            rangeDateBox1.ToDate = DateTime.Now;

            searchHeader();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            searchDetail();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (TagihDetail.Rows.Count == 0)
            {
                MessageBox.Show("Tidah Ada yg bisa dibuat Register Tagihan");
                return;
            }
            InsertData();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InsertData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dtNum = Tools.GetGeneralNumerator("REG", GlobalVar.DBName);

                //   string Nomor_ = Numerator.GetNumerator("REG");
                int lebar = 4;
                int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                string depan = Tools.Right(DateTime.Now.Year.ToString(), 1) + Tools.Right("0" + DateTime.Now.Month.ToString(), 2);
                string belakang = dtNum.Rows[0]["Belakang"].ToString();
                iNomor++;

                string txtRegister = Tools.FormatNumerator(iNomor, lebar, depan, "");
                Guid RowID_ = Guid.NewGuid();
                string _KodeSales = dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                string RecordID_ = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tagihan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, RecordID_));
                    db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, txtRegister));
                    db.Commands[0].Parameters.Add(new Parameter("@TglReg", SqlDbType.DateTime, GlobalVar.DateTimeOfServer.Date));
                    db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, _KodeSales));
                    db.Commands[0].Parameters.Add(new Parameter("@Wilayah", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode1", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Periode2", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    double Tlama_ = 0;
                    
                    Tlama_ = Convert.ToDouble(TagihDetail.Compute("SUM(RpSisa)", string.Empty));

                    db.Commands[0].Parameters.Add(new Parameter("@TLama", SqlDbType.Money, Tlama_));
                    db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, string.Empty));
                    db.Commands[0].Parameters.Add(new Parameter("@Nprint", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                    // db.Commands[0].ExecuteNonQuery();

                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "REG"));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    //db.Commands.Clear();
                    //MessageBox.Show(TagihDetail.Rows.Count.ToString());

                    //if (_Lcabang && TagihDetail.Rows.Count > 0)
                    if (TagihDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < TagihDetail.Rows.Count; i++)
                        {
                            db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_INSERT]"));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, RowID_));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ISA.Common.Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, i)));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, RecordID_));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@KPID", SqlDbType.UniqueIdentifier, (Guid)TagihDetail.Rows[i]["RowID"]));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, TagihDetail.Rows[i]["KPID"].ToString()));
                            if (Convert.ToInt32(TagihDetail.Rows[i]["Cicil"]) == 0)
                                db.Commands[i + 2].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, string.Empty));
                            else
                                db.Commands[i + 2].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, "KONTRAK"));

                            db.Commands[i + 2].Parameters.Add(new Parameter("@KodeTagih", SqlDbType.VarChar, TagihDetail.Rows[i]["KodeTransaksi"].ToString()));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpJual"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpKredit"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(TagihDetail.Rows[i]["RpSisa"], "0"))));
                            db.Commands[i + 2].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));
                        }

                    }



                    db.BeginTransaction();
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        db.Commands[j].ExecuteNonQuery();
                    }

                    db.CommitTransaction();
                    //  string a = Numerator.BookNumerator("REG");
                    RefreshDataRegister(RowID_);
                }
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
        }

        private void searchHeader()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_FixSales_List"));
                dataGridHeader.DataSource = db.Commands[0].ExecuteDataTable();
            }     
        }

        private void searchDetail()
        {
            DataTable dt = new DataTable();
            if (dataGridHeader.Rows.Count > 0)
            {

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string _KodeSales = dataGridHeader.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString();
                    
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetailFixRoute_Vw"));
                        db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    //dataGridDetail.DataSource = dt;
                    
                    DataTable dtTemp = new DataTable();
                    dtTemp = dt.Copy();
                    dtTemp.DefaultView.RowFilter = "StatusAktif = 1";
                    TagihDetail = dtTemp.DefaultView.ToTable();
                    dataGridDetail.DataSource = TagihDetail;
                    //TagihDetail = dt;

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
            else
            {
                dataGridDetail.DataSource = dt;
                TagihDetail = dt;
            }
        }

        private void RefreshDataRegister(Guid RowID_)
        {
            if (this.Caller is Register.frmRegisterBrowser)
            {
                Register.frmRegisterBrowser frmCaller = (Register.frmRegisterBrowser)this.Caller;
                //frmCaller.RefreshRowDetail(_RowID);
                frmCaller.RefreshRowDataHeader(RowID_);
                frmCaller.FindGridHeader("RowIDHeader", RowID_.ToString());
            }
        }
    }
}
