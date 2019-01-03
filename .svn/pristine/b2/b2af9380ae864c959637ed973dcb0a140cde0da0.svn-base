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
using Microsoft.Reporting.WinForms;
using System.Data.SqlTypes;


namespace ISA.Finance.Piutang
{
    public partial class frmPlafonBaru : ISA.Controls.BaseForm
    {
        DateTime TglTerakhir;
        DateTime TglAwalBulan = GlobalVar.DateOfServer.AddDays(-(GlobalVar.DateOfServer.Day - 1));
        DataTable dataDetail;

        public frmPlafonBaru()
        {
            InitializeComponent();
        }

        private void frmPlafonBaru_Load(object sender, EventArgs e)
        {
            refreshHeader();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            if (TglTerakhir == TglAwalBulan)
            {
                MessageBox.Show("Sudah Proses Plafon Baru");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Proses_Plafon"));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                refreshHeader();
                //int bulan = GlobalVar.DateOfServer.Month;

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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            //refreshHeader();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Proses_Plafon"));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                refreshHeader();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_List_TglProsesPlafon]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                GVHeader.DataSource = dt;

                if (GVHeader.SelectedCells.Count > 0)
                {
                    TglTerakhir = (DateTime)dt.Rows[0]["TglProses"];
                }
                else
                {
                    GVDetail.DataSource = null;
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

        private void refreshDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime TglProses = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglProses"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_List_PlafonBaru]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.DateTime, TglProses));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                GVDetail.DataSource = dt;
                dataDetail = dt;
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

        private void GVHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (GVHeader.Rows.Count > 0)
            {
                refreshDetail();
                GVDetail.ReadOnly = false;
                GVDetail.Columns["RowID"].ReadOnly = true;
                GVDetail.Columns["TokoID"].ReadOnly = true;
                GVDetail.Columns["KodeToko"].ReadOnly = true;
                GVDetail.Columns["NamaToko"].ReadOnly = true;
                GVDetail.Columns["WilID"].ReadOnly = true;
                GVDetail.Columns["Alamat"].ReadOnly = true;
                GVDetail.Columns["TotalBayar"].ReadOnly = true;
                GVDetail.Columns["RataRataBayar"].ReadOnly = true;
                GVDetail.Columns["PotensiBerkembang"].ReadOnly = true;
                GVDetail.Columns["KemampuanBayar"].ReadOnly = true;
                GVDetail.Columns["Plafon"].ReadOnly = true;
                //GVDetail.Columns["Keterangan"].ReadOnly = true;
                GVDetail.Columns["TotalPlafon"].ReadOnly = true;
                GVDetail.Columns["TargetOmset"].ReadOnly = true;
                GVDetail.Columns["StatusPN"].ReadOnly = true;
                GVDetail.Columns["TW"].ReadOnly = true;
                GVDetail.Columns["JS"].ReadOnly = true;
                if (!SecurityManager.IsPiutang() || (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglProses"].Value < GlobalVar.DateTimeOfServer.AddDays(-(1 + GlobalVar.DateTimeOfServer.Day)))
                {
                    GVDetail.Columns["PlafonTambahan"].ReadOnly = true;
                    GVDetail.Columns["Keterangan"].ReadOnly = true;
                }
                else
                {
                    GVDetail.Columns["PlafonTambahan"].ReadOnly = false;
                    GVDetail.Columns["Keterangan"].ReadOnly = false;
                }
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime TglProses = (DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglProses"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_List_PlafonBaru]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.DateTime, TglProses));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dataDetail = dt;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (dataDetail.Rows.Count == 0)
            {
                MessageBox.Show("Tidak Ada Data");
                return;
            }
            generateReport(dataDetail);

        }

        private void generateReport(DataTable dt)
        {
            try
            {
                string periode, tglproses, cabang, userid;
                periode = ((DateTime)GVHeader.SelectedCells[0].OwningRow.Cells["TglProses"].Value).ToString("MMM yyyy");
                tglproses = GlobalVar.DateOfServer.ToString("dd-MMM-yyyy");
                cabang = GlobalVar.Gudang;
                userid = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("TglLaporan", tglproses));
                rptParams.Add(new ReportParameter("Cabang", cabang));
                rptParams.Add(new ReportParameter("UserID", userid));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rptPlafonBaru.rdlc", rptParams, dt, "dsPlafonBaru_Data");
                ifrmReport.Text = "rptPlafonBaru";
                ifrmReport.Show();
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

        private void generateReportUpdateJS(DataTable dt)
        {
            try
            {
                string periode;
                periode = GlobalVar.DateTimeOfServer.AddMonths(-7).AddDays(-(GlobalVar.DateTimeOfServer.AddMonths(-7).Day - 1)).Date.ToString("dd MMM yyyy")
                            + " S/D " + GlobalVar.DateTimeOfServer.AddDays(-(GlobalVar.DateTimeOfServer.Day - 1)).AddDays(-1).Date.ToString("dd MMM yyyy");

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Cabang", GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("TglProses", GlobalVar.DateTimeOfServer.Date.ToString("dd-MM-yyyy HH:mm:ss")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.Report.rptPlafonBaru_UpdateJS.rdlc", rptParams, dt, "dsPlafonBaru_UpdateJSToko");
                ifrmReport.ExportToExcel("LAPORAN PERHITUNGAN JS TOKO");

                MessageBox.Show("File Excel JS Toko tersimpan di C:\\Temp\\LAPORAN PERHITUNGAN JS TOKO");
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

        private void generateReportUpdateJSTokoInti(DataTable dt)
        {
            try
            {
                string periode;
                periode = "Tanggal : " + GlobalVar.DateTimeOfServer.ToString("dd MMM yyyy");

                string created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("Tanggal", periode));
                rptParams.Add(new ReportParameter("Cabang", "CABANG : " + GlobalVar.Gudang));
                rptParams.Add(new ReportParameter("Created", created));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptPlafonTokoInti.rdlc", rptParams, dt, "dsPlafonBaru_JSTokoInti");
                ifrmReport.Show();

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

        private void GVDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = GVDetail.Rows[e.RowIndex];
                Double _plfTambahan = 0;
                string _keteranganacc = "";

                if (Tools.isNull(dgvr.Cells["PlafonTambahan"].Value, "0").ToString() != "0" || Tools.isNull(dgvr.Cells["PlafonTambahan"].Value, "0").ToString() != "")
                {
                    _plfTambahan = Double.Parse(dgvr.Cells["PlafonTambahan"].Value.ToString());
                }
                _keteranganacc = dgvr.Cells["Keterangan"].Value.ToString();
                Double _nomplf = Double.Parse(dgvr.Cells["Plafon"].Value.ToString());

                Double _totPlafon = _nomplf + _plfTambahan;

                dgvr.Cells["TotalPlafon"].Value = _totPlafon;
                dgvr.Cells["Keterangan"].Value = _keteranganacc;

                Guid _rowIDDetail = (Guid)dgvr.Cells["RowID"].Value;


                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_PlafonBaru_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDDetail));
                    db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, _plfTambahan));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, _keteranganacc));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void DisplayReport(DataTable dt)
        {

            string _periode = "Periode : " + GlobalVar.DateTimeOfServer.ToString("MMM-yyyy"); ;
            string _created = "Created by " + SecurityManager.UserID + " on " + GlobalVar.DateTimeOfServer;
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", _periode));
            rptParams.Add(new ReportParameter("Created", _created));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptLapTokoJW.rdlc", rptParams, dt, "dsToko_TokoJW");
            ifrmReport.Show();
        }

        private void GVDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                GVDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = GVDetail.Rows[e.RowIndex].Cells["mitra"].Value.ToString() == "0" ? Color.White : Color.BlueViolet;
        }

    }
}
