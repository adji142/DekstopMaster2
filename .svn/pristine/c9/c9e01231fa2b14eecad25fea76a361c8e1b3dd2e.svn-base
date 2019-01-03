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
    public partial class frmGetRealisasi : ISA.Finance.BaseForm
    {
#region "Procedure"
        
        protected DataTable dtApi = new DataTable();
        protected DataTable dtBGC = new DataTable();
        protected DataTable dtApiLink = new DataTable();

        private void initDataPiutang()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_GetRealisasi_init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran  ));
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
                this.Cursor = Cursors.WaitCursor;
                foreach (DataRow dr in dtApi.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_GetRealisasi_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDetail", SqlDbType.UniqueIdentifier,(Guid) dr["RowIDDetail"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDHeader"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
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
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void InitBGC()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_RealisasiBGC_Init]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
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
                this.Cursor = Cursors.WaitCursor;
                foreach (DataRow dr in dtBGC.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Setoran_RealisasiBGC_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RowIDDDInden", SqlDbType.UniqueIdentifier, (Guid)dr["RowIDDDInden"]));
                        db.Commands[0].Parameters.Add(new Parameter("@IndenSubDetailID", SqlDbType.UniqueIdentifier, (Guid)dr["IndenSubDetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglCair", SqlDbType.DateTime, Tools.isNull(dr["TglCair"], "").ToString() == "" ? SqlDateTime.Null : (DateTime)dr["TglTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
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
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void InitInden()
        {
             try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SetoranRealisasi_Inden_Init"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
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
                this.Cursor = Cursors.WaitCursor;
                foreach (DataRow dr in dtApiLink.Rows)
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_SetoranRealisasi_Inden_Proses"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBukti", SqlDbType.VarChar, dr["NoBukti"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, dr["CollectorID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKasir", SqlDbType.DateTime, (DateTime)dr["Tglkasir"]));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInden", SqlDbType.Money, Convert.ToDouble(dr["RpInden"])));
                        db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, Setorans.TglSetoran));
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Reset()
        {
            dtApi = new DataTable();
            dtBGC = new DataTable();
            dtApiLink = new DataTable();


            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;


        }
#endregion

        public frmGetRealisasi()
        {
            InitializeComponent();
        }

        private void frmGetRealisasi_Load(object sender, EventArgs e)
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
                Reset();
                cmdAdd.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                lblProses.Visible = true;

                initDataPiutang();//cek
                ProsesDataApi();//cek
                
                InitBGC();//cek
                ProsesDataBGC();//cek

                InitInden();
                ProsesDataInden();
                
                cmdAdd.Enabled = true;
                lblProses.Visible = false;
                MessageBox.Show("Selesai");
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
