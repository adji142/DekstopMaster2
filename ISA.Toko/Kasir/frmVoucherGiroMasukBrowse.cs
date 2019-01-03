using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;
using Microsoft.Reporting.WinForms;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherGiroMasukBrowse : ISA.Toko.BaseForm
    {
        DataTable dtHeader, dtDetail;
        public frmVoucherGiroMasukBrowse()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
            {
            int jmlprint = 1;
            if ((int)gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
                return;
               
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt2 = new DataTable();


                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@key", SqlDbType.VarChar, "DOKUMENVPG"));
                        dt2 = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        jmlprint = int.Parse(dt2.Rows[0]["Value"].ToString());
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

                DisplayReport(dtDetail, "Kasir.Report.rptCetakLapGiro.rdlc", "Voucher Penerimaan Giro");
                //cetakGiro(dtDetail);
                if (jmlprint == 2)
                {
                    DisplayReport(dtDetail, "Kasir.Report.rptCetakLapGirocopy.rdlc", "Voucher Penerimaan Giro");
                }

                Guid _RowID = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_VoucherJournal_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, (int)gridHeader.SelectedCells[0].OwningRow.Cells["hdrNPrint"].Value + 1));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }

                HeaderRowRefresh(_RowID);

            }

        }

        private void HeaderRefresh()
        {
            try
            {
                dtHeader = new DataTable();
                DataTable dtPG = new DataTable();
                DataTable dtCC = new DataTable();
                DataTable dtDB = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtPG = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "PG");
                    dtCC = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "CC");
                    dtDB = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "DB");
                }
                dtHeader = dtPG;
                dtHeader.Merge(dtCC);
                dtHeader.Merge(dtDB);
                if (dtHeader.Rows.Count > 0)
                {
                    dtHeader.DefaultView.Sort = "TglVoucher";
                    gridHeader.DataSource = dtHeader.DefaultView.ToTable();
                    DetailRefresh();
                    gridHeader.Focus();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void DetailRefresh()
        {
            Guid RowIDHeader=(Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            try
            {
                dtDetail = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtDetail = Giro.ListByVoucherID(db, RowIDHeader);
                }

                if (dtHeader.Rows.Count > 0)
                {
                    dtDetail.DefaultView.Sort = "GiroRecID";
                    gridDetail.DataSource = dtDetail.DefaultView.ToTable();
                    //gridDetail.Focus();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void HeaderRowRefresh(Guid RowID)
        {
            try
            {
                dtHeader = new DataTable();
                DataTable dtPG = new DataTable();
                DataTable dtCC = new DataTable();
                DataTable dtDB = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtPG = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "PG");
                    dtCC = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "CC");
                    dtDB = VoucherJournal.ListHeader(db, (DateTime)tbTanggal.FromDate, (DateTime)tbTanggal.ToDate, "DB");
                }
                dtHeader = dtPG;
                dtHeader.Merge(dtCC);
                dtHeader.Merge(dtDB);
                if (dtHeader.Rows.Count > 0)
                {
                    dtHeader.DefaultView.Sort = "TglVoucher";
                    gridHeader.DataSource = dtHeader.DefaultView.ToTable();
                    DetailRefresh();
                    gridHeader.Focus();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            gridHeader.RefreshDataRow(dtHeader.Rows[0], "RowID", RowID.ToString());
        }

        private void frmVoucherGiroMasukBrowse_Load(object sender, EventArgs e)
        {
            //tbTanggal.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //tbTanggal.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            tbTanggal.FromDate = DateTime.Today;
            tbTanggal.ToDate = DateTime.Today;
            HeaderRefresh();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            HeaderRefresh();
        }

        private void gridHeader_Click(object sender, EventArgs e)
        {
            if (gridHeader.SelectedCells.Count > 0)
                DetailRefresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridHeader_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = true;
        }

        private void gridHeader_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridDetail_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = false;
        }

        private void DisplayReport(DataTable dtLaporan, string namerdlc, string judul)
        {
            int i = 0;
            double total = 0, jumlah;
            string _Terima, _NoBukti, _Tanggal, _Lampiran, _Kasir, _Terbilang;

            //Guid RowIDHeader = (Guid)gridHeader.SelectedCells[0].OwningRow.Cells["hdrRowID"].Value;
            //Guid _RowID = (Guid)dtLaporan.Rows[0]["RowID"];
            //string typePrinter = lap.GetPrinterName();
            string NamaBank = "";
            string NoBBM = gridHeader.SelectedCells[0].OwningRow.Cells["hdrNoVoucher"].Value.ToString();
            string TglBBM = ((DateTime)gridHeader.SelectedCells[0].OwningRow.Cells["hdrTglVoucher"].Value).ToString("dd-MMM-yyyy").Trim();
            //string Pembukuan = Tools.isNull(dtLaporan.Rows[0]["Dibukukan"], "").ToString().Trim();
            //string Mengetahui = Tools.isNull(dtLaporan.Rows[0]["Diketahui"], "").ToString().Trim();
            //string Kasir = Tools.isNull(dtLaporan.Rows[0]["Kasir"], "").ToString().Trim();
            //string Penyetor = Tools.isNull(dtLaporan.Rows[0]["Penyetor"], "").ToString().Trim();
            string Nomor = string.Empty;
            string AsalTransfer = string.Empty;
            string Bank = string.Empty;
            string TglBank = string.Empty;
            string TglTransfer = string.Empty;
            double Jumlah = 0;
            double sumJumlah = 0;
            string tempJumlah = string.Empty;
            string UserID = SecurityManager.UserName.ToString();

            foreach (DataRow dr in dtLaporan.Rows)
            {
                total += Convert.ToDouble(dr["Nominal"].ToString());
            }
            _Terbilang = Tools.Terbilang(total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", string.Format("{0}, {1:dd/MM/yyyy hh:mm:ss}", SecurityManager.UserName, DateTime.Now)));
            rptParams.Add(new ReportParameter("NamaBank", NamaBank));
            rptParams.Add(new ReportParameter("NoBBM", NoBBM));
            rptParams.Add(new ReportParameter("TglBBM", String.Format("{0:dd-MMM-yyyy}", TglBBM)));
            rptParams.Add(new ReportParameter("Total", total.ToString()));
            rptParams.Add(new ReportParameter("Terbilang", _Terbilang));
            rptParams.Add(new ReportParameter("Judul", judul));

            frmReportViewer ifrmReport = new frmReportViewer(namerdlc, rptParams, dtLaporan, "dsLapGiro_Data");
            ifrmReport.Print();
            ////ifrmReport.Print(8.5, 6.4);
            ////ifrmReport.Show();
        }

    }
}
