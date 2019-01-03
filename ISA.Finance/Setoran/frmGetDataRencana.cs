using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Data.SqlTypes;
using System.Threading;

namespace ISA.Finance.Setoran
{
    public partial class frmGetDataRencana : ISA.Finance.BaseForm
    {
#region "Procedure"
        protected DataTable dtCustomer = new DataTable();
        protected DataTable dtApi = new DataTable();
        protected DataTable dtBGC = new DataTable();
        protected DataTable dtApiLink = new DataTable();

        private void initDataCustomer()
        {
            try
            {
                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_Init]"));
                    db.Commands[0].ExecuteNonQuery();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_List]"));
                    dtCustomer = db.Commands[0].ExecuteDataTable();
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dtCustomer.Rows.Count;
               
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
           
        }

        private void ProsesDataCustomer()
        {
            try
            {
               
                foreach (DataRow dr in dtCustomer.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_DataCustomer_Proses]"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar1.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            

        }

        private void initDataPiutang()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_KPiutang_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApi = db.Commands[0].ExecuteDataTable();
                }

                progressBar2.Minimum = 0;
                progressBar2.Maximum = dtApi.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ProsesDataApi()
        {
            try
            {
              
                foreach (DataRow dr in dtApi.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_KPiutang_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,(Guid) dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@ntagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["ntagih"],"0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpJual", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["RpJual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["KPID"],"").ToString() ));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString()));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar2.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar2.Value.ToString("#,##0") + " / " + progressBar2.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            

        }

        private void InitBGC()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtBGC = db.Commands[0].ExecuteDataTable();
                }

                progressBar3.Minimum = 0;
                progressBar3.Maximum = dtBGC.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ProsesDataBGC()
        {
            try
            {
                
                foreach (DataRow dr in dtBGC.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_Proses]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDGiro", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDGiro"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTolak", SqlDbType.DateTime, Tools.isNull(dr["TglTolak"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar3.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar3.Value.ToString("#,##0") + " / " + progressBar3.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void InitInden()
        {
             try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_Inden_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApiLink = db.Commands[0].ExecuteDataTable();
                }

                progressBar4.Minimum = 0;
                progressBar4.Maximum = dtApiLink.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
        
        private void ProsesDataInden()
        {
            try
            {
                
                foreach (DataRow dr in dtApiLink.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_Inden_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, dr["CollectorID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, (DateTime)dr["Tglkasir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Convert.ToDouble(dr["RpInden"])));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar4.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar4.Value.ToString("#,##0") + " / " + progressBar4.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void InitData()
        {
            Thread Th = new Thread(initDataCustomer);
            Thread Th2 = new Thread(initDataPiutang);
            Th.Start();
            Th2.Start();
            
            //Th.Join();
            //Th2.Join();

        }

        private void InitHoliday()
        {
            DataTable dtH = new DataTable();

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_Libur_List]"));
                db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Setorans.Year));
                dtH = db.Commands[0].ExecuteDataTable();
               
            }

            if (dtH.Rows.Count==0)
            {
                DateTime date1 = new DateTime(Setorans.Year, 1, 1);
                DateTime date2 = new DateTime(Setorans.Year + 1, 1, 1);
                TimeSpan ts;
                ts = date2.Subtract(date1);

                DateTime date3 = new DateTime(Setorans.Year, 1, 1);
                for (double i = 0; i < ts.Days; i++)
                {
                    date3 = date1.AddDays(+i);

                    if (date3.DayOfWeek == DayOfWeek.Sunday || date3.DayOfWeek==DayOfWeek.Saturday)
                    {
                        dtH.Rows.Add(Guid.NewGuid(), date3.Day, date3.Month, date3.Year);
                    }
                }



                try
                {
                    foreach (DataRow dr in dtH.Rows)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_Libur_Insert]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Convert.ToInt32(dr["Tahun"])));
                            db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Convert.ToInt32(dr["Bulan"])));
                            db.Commands[0].Parameters.Add(new Parameter("@day", SqlDbType.Int, Convert.ToInt32(dr["Tanggal"])));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
            }

            
        }

        private void AddDataCustomer()
        {
            try
            {

              
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_DataCustomer_Add"));
                        db.Commands[0].ExecuteNonQuery();
                    }
                   
                    Application.DoEvents();
                    this.Invalidate();
                    
                    this.Refresh();
                
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void Reset()
        {
            dtCustomer = new DataTable();
            dtApi = new DataTable();
            dtBGC = new DataTable();
            dtApiLink = new DataTable();


            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;

        }
#endregion
        
        public frmGetDataRencana()
        {
            InitializeComponent();
        }

        private void frmGetDataRencana_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (new DateTime(Setorans.Year, Setorans.Month, 1) > GlobalVar.DateOfServer)
                {
                    Reset();

                    InitHoliday();
                    cmdAdd.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    lblProses.Visible = true;
                    //if (GlobalVar.Gudang != "2808")
                    //{
                    initDataCustomerV2();
                    ProsesDataCustomerV2();//cek
                    //}

                    initDataPiutangV2();//cek
                    ProsesDataApiV2();//cek

                    InitBGCV2();//cek
                    ProsesDataBGCV2();

                    //InitIndenV2();
                    //ProsesDataIndenV2();

                    AddDataCustomerV2();//cek
                    UpdateDataCustomerV2();//cek
                    cmdAdd.Enabled = true;
                    lblProses.Visible = false;
                }
                else
                {
                    if (cekSetoran())
                    {
                        MessageBox.Show("Sudah pernah Get Rencana !!!");
                        return;
                    }
                    Reset();
                    InitHoliday();
                    cmdAdd.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    lblProses.Visible = true;
                    //if (GlobalVar.Gudang != "2808")
                    //{
                    initDataCustomer();
                    ProsesDataCustomer();//cek
                    //}
                    initDataPiutang();//cek
                    ProsesDataApi();//cek

                    InitBGC();//cek
                    ProsesDataBGC();//cek

                    InitInden();//cek
                    ProsesDataInden();//cek
                    AddDataCustomer();
                    cmdAdd.Enabled = true;
                    lblProses.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Proses Selesai");
            }
            

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }

        private bool cekSetoran()
        {
            bool _hasil = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtst;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Setoran_cekSetoran"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtst = db.Commands[0].ExecuteDataTable();
                    if (dtst.Rows.Count > 0)
                    {
                        _hasil = true;
                    }

                }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return _hasil;
        }

        private void initDataCustomerV2()
        {
            try
            {

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_InitV2]"));
                    db.Commands[0].ExecuteNonQuery();
                }

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_ListV2]"));
                    dtCustomer = db.Commands[0].ExecuteDataTable();
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = dtCustomer.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void ProsesDataCustomerV2()
        {
            try
            {

                foreach (DataRow dr in dtCustomer.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_DataCustomer_ProsesV2]"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dr["KodeToko"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar1.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar1.Value.ToString("#,##0") + " / " + progressBar1.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void initDataPiutangV2()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_KPiutang_InitV2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApi = db.Commands[0].ExecuteDataTable();
                }

                progressBar2.Minimum = 0;
                progressBar2.Maximum = dtApi.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ProsesDataApiV2()
        {
            try
            {

                foreach (DataRow dr in dtApi.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_KPiutang_ProsesV2"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].Parameters.Add(new Parameter("@ntagih", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["ntagih"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpJual", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["RpJual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["KPID"], "").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString()));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar2.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar2.Value.ToString("#,##0") + " / " + progressBar2.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }


        }

        private void InitBGCV2()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_InitV2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtBGC = db.Commands[0].ExecuteDataTable();
                }

                progressBar3.Minimum = 0;
                progressBar3.Maximum = dtBGC.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ProsesDataBGCV2()
        {
            try
            {

                foreach (DataRow dr in dtBGC.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Setoran_BGC_ProsesV2]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDGiro", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDGiro"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTolak", SqlDbType.DateTime, Tools.isNull(dr["TglTolak"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar3.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar3.Value.ToString("#,##0") + " / " + progressBar3.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void InitIndenV2()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_Inden_InitV2]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    dtApiLink = db.Commands[0].ExecuteDataTable();
                }

                progressBar4.Minimum = 0;
                progressBar4.Maximum = dtApiLink.Rows.Count;

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void ProsesDataIndenV2()
        {
            try
            {

                foreach (DataRow dr in dtApiLink.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_Inden_ProsesV2"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, dr["CollectorID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, (DateTime)dr["Tglkasir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Convert.ToDouble(dr["RpInden"])));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    progressBar4.Value++;
                    Application.DoEvents();
                    this.Invalidate();
                    lblProses.Text = "Proses " + progressBar4.Value.ToString("#,##0") + " / " + progressBar4.Maximum.ToString("#,##0");
                    this.Refresh();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void AddDataCustomerV2()
        {
            try
            {


                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DataCustomer_AddV2"));
                    db.Commands[0].ExecuteNonQuery();
                }

                Application.DoEvents();
                this.Invalidate();

                this.Refresh();

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void UpdateDataCustomerV2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_RefreshV2]"));
                    //  db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    db.Commands[0].ExecuteNonQuery();

                }

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
    }
}
