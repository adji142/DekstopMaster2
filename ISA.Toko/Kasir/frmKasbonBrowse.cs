using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;
using ISA.Common;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace ISA.Toko.Kasir
{
    public partial class frmKasbonBrowse : ISA.Toko.BaseForm
    {
        DataTable dtKasbon;
        DataTable dt;
        string PrnAktif = "0";

        public frmKasbonBrowse()
        {
            InitializeComponent();
        }

        private void frmKasbonBrowse_Load(object sender, EventArgs e)
        {
            //tbRange.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //tbRange.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            
            tbRange.FromDate = DateTime.Today;
            tbRange.ToDate = DateTime.Today;
            tbstatus.SelectedItem = tbstatus.Items[0];
            KasbonRefresh();
        }

        public void KasbonRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtKasbon = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_Kasbon_LIST_OPEN"));

                    if (tbstatus.SelectedItem == tbstatus.Items[0])
                        db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, "O"));
                    else if (tbstatus.SelectedItem == tbstatus.Items[1])
                        db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, "C"));
                    
                    
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)tbRange.FromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)tbRange.ToDate));
                    dtKasbon = db.Commands[0].ExecuteDataTable();
                }

                

                    dtKasbon.DefaultView.Sort = "StatusKasbon, Tgl";
                    
                    dgKasbon.DataSource = dtKasbon.DefaultView;
                    if (dgKasbon.SelectedCells.Count > 0)
                    {
                        TampilDetail();
                    }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                dgKasbon.Focus();
            }
        }

        public void KasbonRefresh(Guid rowID)
        {
            DataTable dtResult = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_KASBON_LIST_ByRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID",SqlDbType.UniqueIdentifier,rowID));
                dtResult = db.Commands[0].ExecuteDataTable();
            }
            dgKasbon.RefreshDataRow(dtResult.Rows[0], "RowID", rowID.ToString());
        }
        public void KasbonFindRow(string column, string value)
        {
            dgKasbon.FindRow(column, value);
            dgKasbon.Focus();
            TampilDetail();
        }

        public void TampilDetail()
        {
            tbDivisi.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["UnitKerja"].Value.ToString();
            tbDue.DateValue = (Convert.ToDateTime(dgKasbon.SelectedCells[0].OwningRow.Cells["Tgl"].Value)).AddDays((int)dgKasbon.SelectedCells[0].OwningRow.Cells["Hari"].Value);
            tbHari.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["Hari"].Value.ToString();
            tbKeperluan.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["Keperluan"].Value.ToString();
            tbNamaPegawai.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
            tbNip.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();
            TBNoKasbon.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["NoBukti"].Value.ToString();
            tbNoPerk.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
            tbTanggal.DateValue = (DateTime)dgKasbon.SelectedCells[0].OwningRow.Cells["Tgl"].Value;

            txtBbk3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BBKNo3"].Value.ToString();
            txtTrm3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BBMNo3"].Value.ToString();
            txtBkk3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BKKNo3"].Value.ToString();
            txtBkm3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BKMNo3"].Value.ToString();
            txtJv.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["JVNo1"].Value.ToString();
            txtNobbk.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BBKNo1"].Value.ToString();
            txtNoBkk.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["BKKNo1"].Value.ToString();
            txtNoTrk.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["TRKNo1"].Value.ToString();
            txtRpBbk.Text = String.Format("{0:#,##0}",dgKasbon.SelectedCells[0].OwningRow.Cells["BBKRp1"].Value);
            txtRpBbk3.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["BBKRp3"].Value);
            txtRpTrm3.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["TRNRp3"].Value);
            txtRpBkk.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["BKKRp1"].Value);
            txtRpBkk3.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["BKKRp3"].Value);
            txtRpBkm3.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["BKMRp3"].Value);
            txtRpJv.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["JVRp1"].Value);
            txtRpTotal.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["BKKRp1"].Value);
            txtRpLbhKrng.Text = String.Format("{0:#,##0}", (Convert.ToDouble(txtRpTotal.Text) - Convert.ToDouble(txtRpJv.Text)));
            txtRpTrk.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["TRKRp1"].Value);
            txtRpTrk3.Text = String.Format("{0:#,##0}", dgKasbon.SelectedCells[0].OwningRow.Cells["TRKRp3"].Value);
            txtTrk3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["TRKNo3"].Value.ToString();
            txtTrm3.Text = dgKasbon.SelectedCells[0].OwningRow.Cells["TRNNo3"].Value.ToString();
        }

        private void dgKasbon_Click(object sender, EventArgs e)
        {
            if (dgKasbon.SelectedCells.Count > 0)
            {
                TampilDetail();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            KasbonRefresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmKasbonUpdate frm = new frmKasbonUpdate(this);
            frm.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgKasbon.SelectedCells[0].OwningRow.Cells["StatusKasbon"].Value.ToString() == "C")
            {
                MessageBox.Show("Sudah Penyelesaian, Tidak Bisa di Edit");
                return;
            }
            string rowID=dgKasbon.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            DataTable dtKasbonRow = dtKasbon.Copy();
            dtKasbonRow.DefaultView.RowFilter="RowID='"+rowID+"'";
            DataView dv = new DataView();
            dv = dtKasbonRow.DefaultView;

            frmKasbonUpdate frm = new frmKasbonUpdate(this,dv.ToTable());
            frm.ShowDialog();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "KASBON"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    PrnAktif = "0";
                else
                    PrnAktif = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (PrnAktif == "0")
                cetakKasbon();
            else
                DisplayReport(dt);
        }


        private void DisplayReport(DataTable dt)
        {
            string Nomor = TBNoKasbon.Text.ToString();
            string Tanggal = String.Format("{0:dd-MMM-yyyy}",tbTanggal.DateValue);
            string Nama = tbNamaPegawai.Text.ToString();
            string Divisi = tbDivisi.Text.ToString();
            string Keperluan = tbKeperluan.Text.ToString();

            string NoBkk = txtNoBkk.Text.ToString();
            string RpBkk = txtRpBkk.Text.ToString().Trim();

            string JmlBkk = txtRpTotal.Text.ToString().Trim();
            string Jv = txtJv.Text.ToString();
            string RpJv = txtRpJv.Text.ToString();
            string LebihKurang = txtRpLbhKrng.Text.ToString();

            string Kurang = txtBkk3.Text.ToString();
            string RpKurang = txtRpBkk3.Text.ToString().Trim();
            string Trk = txtTrk3.Text.ToString();
            string RpTrk = txtRpTrk3.Text.ToString().Trim();
            string JmlKrg = (Convert.ToDouble(txtRpTrk3.Text.ToString()) + Convert.ToDouble(txtRpBkk3.Text.ToString())).ToString();

            string Lebih = txtBkm3.Text.ToString();
            string RpLebih = txtRpBkm3.Text.ToString().Trim();
            string Trm = txtTrm3.Text.ToString();
            string RpTrm = txtRpTrm3.Text.ToString().Trim();
            string JmlLbh = (Convert.ToDouble(txtRpTrm3.Text.ToString()) + Convert.ToDouble(txtRpBkm3.Text.ToString())).ToString();

            string UserID = SecurityManager.UserName.ToString().Trim();

            double Total = Convert.ToDouble(Tools.isNull(txtRpTotal.Text,"0").ToString());
            string Terbilang = Tools.Terbilang(Total);

            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", UserID));
            rptParams.Add(new ReportParameter("Nomor", Nomor));
            rptParams.Add(new ReportParameter("Tanggal", Tanggal));
            rptParams.Add(new ReportParameter("Total", Total.ToString()));
            rptParams.Add(new ReportParameter("Terbilang", Terbilang));
            rptParams.Add(new ReportParameter("Nama", Nama));
            rptParams.Add(new ReportParameter("Divisi", Divisi));
            rptParams.Add(new ReportParameter("Keperluan", Keperluan));

            rptParams.Add(new ReportParameter("NoBkk", NoBkk));
            rptParams.Add(new ReportParameter("RpBkk", RpBkk));
            rptParams.Add(new ReportParameter("JmlBkk", JmlBkk));
            rptParams.Add(new ReportParameter("Jv", Jv));
            rptParams.Add(new ReportParameter("RpJv", RpJv));
            rptParams.Add(new ReportParameter("LebihKurang", LebihKurang));
            rptParams.Add(new ReportParameter("Kurang", Kurang));
            rptParams.Add(new ReportParameter("RpKurang",RpKurang));
            rptParams.Add(new ReportParameter("Trk", Trk));
            rptParams.Add(new ReportParameter("RpTrk", RpTrk));
            rptParams.Add(new ReportParameter("JmlKrg", JmlKrg));

            rptParams.Add(new ReportParameter("Lebih", Lebih));
            rptParams.Add(new ReportParameter("RpLebih", RpLebih));
            rptParams.Add(new ReportParameter("Trm", Trm));
            rptParams.Add(new ReportParameter("RpTrm", RpTrm));
            rptParams.Add(new ReportParameter("JmlLbh", JmlLbh));

            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptCetakKasbonbaru.rdlc", rptParams, dt, "dsKasbon_Data");
            ifrmReport.Print();
            //////ifrmReport.Print(8.5, 6.4);
            //////ifrmReport.Show();

        }


        private void cmdReport_Click(object sender, EventArgs e)
        {

        }

        private void dgKasbon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgKasbon.Rows.Count > 0)
            {
                if (dgKasbon.Rows[e.RowIndex].Cells["StatusKasbon"].Value.ToString() == "C")
                {
                    for(int i=0;i<=41;i++)
                    {
                        dgKasbon.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Gray;
                    }
                }
                   

            }
        }

        private void dgKasbon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgKasbon.SelectedCells.Count > 0)
            {
                TampilDetail();
            }
        }

        private void dgKasbon_Enter(object sender, EventArgs e)
        {
            dgKasbon_SelectionChanged(sender, e);
        }


        private void cetakKasbon()
        {


            BuildString lap = new BuildString();
            lap.Initialize();

            lap.PageLLine(33);
            lap.LeftMargin(1);
            lap.FontCPI(12);
            lap.LineSpacing("1/6");
            lap.DoubleWidth(true);
            lap.PROW(true, 1, "[ PERTANGGUNGAN UANG MUKA PEGAWAI ]");
            lap.DoubleWidth(false);

            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, "NOMOR".PadRight(12) + lap.PadCenter(3, ":") + TBNoKasbon.Text.PadRight(70));
            lap.PROW(true, 1, "TANGGAL".PadRight(12) + lap.PadCenter(3, ":") + String.Format("{0:dd-MMM-yyyy}",tbTanggal.DateValue).PadRight(70));
            lap.PROW(true, 1, "NAMA PEGAWAI".PadRight(12) + lap.PadCenter(3, ":") + tbNamaPegawai.Text.PadRight(70));
            lap.PROW(true, 1, "NIP/DIVISI".PadRight(12) + lap.PadCenter(3, ":") + tbDivisi.Text.PadRight(70));
            lap.PROW(true, 1, "KEPERLUAN".PadRight(12) + lap.PadCenter(3, ":") + tbKeperluan.Text.PadRight(70));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.PrintMinusSymbol(85));
            lap.PROW(true, 1, "I. PENGAMBILAN".PadRight(20) + "1.BKK No : " + txtNoBkk.Text + lap.SPACE(5) + txtRpBkk.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(70) + txtRpTotal.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, "II. PENGELUARAN".PadRight(85));
            lap.PROW(true, 1, lap.SPACE(4) + "- Biaya".PadRight(8) + txtJv.Text.PadRight(33) + lap.SPACE(5) + txtRpBkk.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(70) + txtRpJv.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(70) + lap.PrintMinusSymbol(15));
            lap.PROW(true, 1, lap.SPACE(55)+"KURANG/LEBIH".PadRight(15) + txtRpLbhKrng.Text.PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, "III. PENYELESAIAN".PadRight(85));
            lap.PROW(true, 1, lap.SPACE(5) + "KURANG".PadRight(15) + "1.BKK No : " + txtBkk3.Text + lap.SPACE(5) + txtRpBkk3.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(20) + "2.TRK No : " + txtTrk3.Text + lap.SPACE(5) + txtRpTrk3.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(70) + string.Format("{0:#,##0}",(Convert.ToDouble(txtRpTrk3.Text) + Convert.ToDouble(txtRpBkk3.Text))).PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.SPACE(5) + "LEBIH".PadRight(15) + "1.BKM No : " + txtBkm3.Text + lap.SPACE(5) + txtRpBkm3.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(20) + "2.TRN No : " + txtTrm3.Text + lap.SPACE(5) + txtRpTrm3.Text.Trim().PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(70) + string.Format("{0:#,##0}",(Convert.ToDouble(txtRpTrm3.Text) + Convert.ToDouble(txtRpBkm3.Text))).PadLeft(15));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.PrintMinusSymbol(85));
            lap.PROW(true, 1, "JUMLAH UANG MUKA : Rp."+txtRpTotal.Text.PadLeft(15));
            lap.PROW(true, 1, "("+Tools.Terbilang(Convert.ToDouble(txtRpTotal.Text))+")");
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.PadCenter(15, "Dibuat") + lap.SPACE(8) + lap.PadCenter(15, "Disetujui") + lap.SPACE(8) + lap.PadCenter(15, "Diketahui") + lap.SPACE(8) + lap.PadCenter(15, "Penerima"));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, lap.SPACE(85));
            lap.PROW(true, 1, "(" + lap.SPACE(13) + ")" + lap.SPACE(8) + "(" + lap.SPACE(13) + ")" + lap.SPACE(8) + "(" + lap.SPACE(13) + ")" + lap.SPACE(8) + "(" + lap.SPACE(13) + ")");

            lap.Eject();
            //lap.SendToPrinter("laporanPS.txt");
            lap.SendToFile("laporanPS.txt");
        }
        
      

   
  

   

    }
}
