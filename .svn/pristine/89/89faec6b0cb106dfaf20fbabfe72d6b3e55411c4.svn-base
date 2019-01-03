using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;
using ISA.Trading;
using System.IO;
using System.Drawing.Printing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ISA.Trading.xpdc
{
    public partial class frm_kirim : ISA.Controls.BaseForm
    {
        DateTime _fromDate, _toDate;
        DataTable dtHeader, dtDetail, sekarang, dtGet;
        int nDay, nYear, nMonth;
        string _TglKirim = string.Empty;
        string HeaderRecID = string.Empty;
        string HeadRecID = string.Empty;
        string TglKembali = string.Empty;
        string RowID_ = string.Empty;
        string RowIDselect;
        string PrnAktif = "0";
        int _nCetak = 0;

        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;

        public frm_kirim()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nDay = DateTime.Today.Day-1;
            _fromDate = DateTime.Today.AddDays(-nDay);
            _toDate = DateTime.Now;
            rdb_xpdc.FromDate = _fromDate;
            rdb_xpdc.ToDate = _toDate;
            rdb_xpdc.Focus();
            RefreshDataXpdc();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    Insert_Header(); 
                    break;

                case enumSelectedGrid.Detail:
                    Insert_Detail();
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (dgS == enumSelectedGrid.Header)
            {
                Edit_Header();
            }

            if (dgS == enumSelectedGrid.Detail)
            {
                Edit_Detail();
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetdataNotaJual_Click(object sender, EventArgs e)
        {
            //dataGridNotaJualtmp();
        }

        private void rangeDateBox1_Load(object sender, EventArgs e)
        {
        }

        private void commandButton1_Click_3(object sender, EventArgs e)
        {
            RefreshDataXpdc();
        }

        public void RefreshDataXpdc()
        {
            _fromDate = (DateTime)rdb_xpdc.FromDate;
            _toDate = (DateTime)rdb_xpdc.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST_FILTER_TglKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridxpdc.DataSource = dtHeader;

                if (dataGridxpdc.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
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

        public void RefreshDataDetail()
        {
            if (dataGridxpdc.SelectedCells.Count > 0)
            {
                try
                {
                    Guid _rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        dataGridDetailxpdc.DataSource = dt;
                    }
                    else
                    {
                        dataGridDetailxpdc.DataSource = null;
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
        }

        public void RefreshDataRekapToko()
        {
            try
            {
                Guid _rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dtr = new DataTable();
                using (Database dbr = new Database())
                {
                    dbr.Commands.Add(dbr.CreateCommand("usp_PengirimanXpdc_RekapToko_LIST"));
                    dbr.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtr = dbr.Commands[0].ExecuteDataTable();
                }
                if (dtr.Rows.Count > 0)
                {
                    //dataGridDetailxpdc.DataSource = dtr;
                }
                else
                {
                    //dataGridDetailxpdc.DataSource = null;
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


        public void RefreshDataXpdc_GetNotaAg()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtGet = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_GetNotaJualAg"));
                    dtGet = db.Commands[0].ExecuteDataTable();
                }
                dataGridxpdc.DataSource = dtGet;
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


        private void dataGridxpdc_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
            cmdEdit.Enabled = true;
            cmdDelete.Enabled = true;
            cmdAdd.Enabled = true;
        }

        private void dataGridxpdc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshDataDetail();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (dgS)
            {
                case enumSelectedGrid.Header:
                    Hapus_Header();
                    break;

                case enumSelectedGrid.Detail:
                    Hapus_Detail();
                    break;
            }
        }

        private void dataGridDetailxpdc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void dataGridXpdc_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridxpdc.SelectedCells.Count > 0)
                RefreshDataDetail();
        }

        private void dataGridHeaderlxpdc_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Header;
            RefreshDataDetail();
        }

        private void dataGridDetaillxpdc_Click(object sender, EventArgs e)
        {
            dgS = enumSelectedGrid.Detail;
        }

        private void dataGridxpdc_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void dataGridxpdcDetail_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                Insert_Detail();
            }

            if (e.KeyCode == Keys.Space)
            {
                Edit_Detail();
            }

            if (e.KeyCode == Keys.Delete)
            {
                Hapus_Detail();
            }

            //if (e.KeyCode == Keys.F2)
            //{
            //    if (dataGridxpdc.SelectedCells.Count > 0)
            //    {
            //        TglKembali = dataGridxpdc.SelectedCells[0].OwningRow.Cells["TglKemb"].Value.ToString();
            //        if (TglKembali != null && TglKembali != "")
            //        {
            //            MessageBox.Show("Barang Sudah dikirim, data tidak bisa diedit..!");
            //            return;
            //        }

            //        try
            //        {
            //            Guid rowID = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
            //            xpdc.frm_detail_xpdc_Jkoli ifrmChild = new xpdc.frm_detail_xpdc_Jkoli(this, rowID);
            //            ifrmChild.MdiParent = Program.MainForm;
            //            Program.MainForm.RegisterChild(ifrmChild);
            //            ifrmChild.Show();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(Messages.Error.RowNotSelected);
            //    }
            //}

            //if (e.KeyCode == Keys.F3)
            //{
            //    if (dataGridxpdc.SelectedCells.Count > 0)
            //    {
            //        try
            //        {
            //            Guid rowID = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
            //            xpdc.frm_penyelesaian_kiriman ifrmChild = new xpdc.frm_penyelesaian_kiriman(this, rowID);
            //            ifrmChild.MdiParent = Program.MainForm;
            //            Program.MainForm.RegisterChild(ifrmChild);
            //            ifrmChild.Show();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.LogError(ex);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(Messages.Error.RowNotSelected);
            //    }
            //}

            if (e.KeyCode == Keys.F5)
                cmdBatalKirim_Click(sender, new EventArgs());

        }
        
        
        private bool CekDataPrint()
        {
            Guid HeaderRecID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dtc = new DataTable();
            using (Database dbc = new Database())
            {
                dbc.Commands.Add(dbc.CreateCommand("usp_PengirimanXpdcCheckDataPrint"));
                dbc.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, HeaderRecID));
                dtc = dbc.Commands[0].ExecuteDataTable();
                if (dtc.Rows.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void Insert_Header()
        {
            xpdc.frm_header_xpdc ifrmChild = new frm_header_xpdc(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void Edit_Header()
        {
            if (dataGridxpdc.SelectedCells.Count > 0)
            {
                if (Tools.isNull(dataGridxpdc.SelectedCells[0].OwningRow.Cells["TglKemb"].Value, "").ToString() != "")
                {
                    MessageBox.Show("Tanggal Terima sudah terisi, tidak bisa diedit.");
                    return;
                }
                try
                {
                    Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    xpdc.frm_header_xpdc ifrmChild = new xpdc.frm_header_xpdc(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void Insert_Detail()
        {
            if ((bool)dataGridxpdc.SelectedCells[0].OwningRow.Cells[Atk.Name].Value == false)
            {
                Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                DateTime tglKirim = (DateTime)dataGridxpdc.SelectedCells[0].OwningRow.Cells[TglKirim.Name].Value;
                DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;

                frmXpdcDetailAdd frm = new frmXpdcDetailAdd(rowID, tglKirim, detailDt);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    RefreshDataDetail();
            }
            else
            {
                Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                frmXpdcDetailAddNonTrading frm = new frmXpdcDetailAddNonTrading(this, rowID);
                frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //    RefreshDataDetail();
            }

            //Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
            //DateTime tglKirim = (DateTime)dataGridxpdc.SelectedCells[0].OwningRow.Cells[TglKirim.Name].Value;
            //DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;

            //frmXpdcDetailAdd frm = new frmXpdcDetailAdd(rowID, tglKirim, detailDt);
            //frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //    RefreshDataDetail();
        }

        private void Edit_Detail()
        {
            if (dataGridxpdc.SelectedCells.Count > 0)
            {
                TglKembali = dataGridxpdc.SelectedCells[0].OwningRow.Cells["TglKemb"].Value.ToString();
                if (TglKembali != null && TglKembali != "")
                {
                    MessageBox.Show("Barang Sudah dikirim, data tidak bisa diedit..!");
                    return;
                }

                try
                {
                    if ((bool)dataGridxpdc.SelectedCells[0].OwningRow.Cells[Atk.Name].Value == false)
                    {
                        Guid rowId = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
                        DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;
                        frmXpdcDetailUpdate frm = new frmXpdcDetailUpdate(rowId, detailDt);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            RefreshDataDetail();
                    }
                    else
                    {
                        Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                        DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;
                        frmXpdcDetailAddNonTrading frm = new frmXpdcDetailAddNonTrading(this, rowID);
                        frm.ShowDialog();

                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void Hapus_Header()
        {
            TglKembali = dataGridxpdc.SelectedCells[0].OwningRow.Cells["TglKemb"].Value.ToString();
            if (TglKembali != null && TglKembali != "")
            {
                MessageBox.Show("Barang Sudah dikirim, data tidak bisa dihapus..!");
                return;
            }

            if (!CekAddEditHapus("hapus"))
            {
                MessageBox.Show("Masih ada Detail record");
                return;
            }

            if (MessageBox.Show("Data akan dihapus...?", "Hapus Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid _rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengirimanXpdc_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();
                    }
                    MessageBox.Show("Record telah dihapus");
                    this.RefreshDataXpdc();
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
        }

        private void Hapus_Detail()
        {
            TglKembali = dataGridxpdc.SelectedCells[0].OwningRow.Cells["TglKemb"].Value.ToString();
            if (TglKembali != null && TglKembali != "")
            {
                MessageBox.Show("Barang Sudah dikirim, data tidak bisa dihapus..!");
                return;
            }

            if (CekAddEditHapus("hapus"))
            {
                MessageBox.Show("Tidak ada data yang akan dihapus");
                return;
            }

            if (MessageBox.Show("Data Detail akan dihapus...?", "Hapus Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Guid rowId = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
                    Guid notaJualId = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["NotaJualID"].Value;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowId));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaJualID", SqlDbType.UniqueIdentifier, notaJualId));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Record telah dihapus");
                    this.RefreshDataDetail();
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
        }

        //private void dataGridNotaJualtmp()
        //{
        //    if (dataGridxpdc.SelectedCells.Count > 0)
        //    {
        //        DataTable dtH = new DataTable();
        //        //dtH = dtH.Copy();
        //        _TglKirim = dataGridxpdc.CurrentRow.Cells[0].Value.ToString();
        //        Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
        //        xpdc.frm_detail_xpdc ifrmChild = new xpdc.frm_detail_xpdc(this, rowID, _TglKirim);
        //        ifrmChild.MdiParent = Program.MainForm;
        //        Program.MainForm.RegisterChild(ifrmChild);
        //        ifrmChild.Show();
        //    }
        //}


        private bool CekAddEditHapus(string modus)
        {
            Guid HeaderRecID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dtc = new DataTable();
            using (Database dbc = new Database())
            {
                dbc.Commands.Add(dbc.CreateCommand("usp_PengirimanXpdcCheckDetail"));
                dbc.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, HeaderRecID));
                dtc = dbc.Commands[0].ExecuteDataTable();
                if (dtc.Rows.Count <= 0)
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
        }

        private void DisplayReport(DataTable dt)                                                 
        {
           List<ReportParameter> rptParams = new List<ReportParameter>();
           // rptParams.Add(new ReportParameter("fromdate", .Text));
            
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptSerahTerima.rdlc", rptParams, dt, "DsXpdcSerahTerima_SerahTerima");
            //ifrmReport.WindowState = FormWindowState.Normal;
            ifrmReport.Show();
           
        }

        private string PrintHeader(DataTable dt)
        {
            BuildString printESC = new BuildString();

            string namaPerusahaan = dt.Rows[0]["NamaPerusahaan"].ToString();
            string alamat = dt.Rows[0]["AlamatPerusahaan"].ToString();
            string kota = dt.Rows[0]["KotaPerusahaan"].ToString();
            DateTime tglKirim = DateTime.Parse(dt.Rows[0]["TglKirim"].ToString());
            string tujuan = dt.Rows[0]["Tujuan"].ToString();
            string supir = dt.Rows[0]["Sopir"].ToString();
            string kernet = dt.Rows[0]["Kernet"].ToString();
            string noKirim = dt.Rows[0]["NoKirim"].ToString();
            string noPolisi = dt.Rows[0]["NoPolisi"].ToString();

            printESC.PROW(true, 1, "PART STATION");
            printESC.PROW(true, 1, namaPerusahaan);
            printESC.PROW(true, 1, alamat);
            printESC.PROW(true, 1, kota);
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "TANGGAL      : " + tglKirim.ToString("dd-MMM-yyyy"));
            printESC.PROW(true, 1, "TUJUAN       : " + tujuan);
            printESC.PROW(true, 1, "SOPIR/KERNET : " + supir + "/" + kernet);
            printESC.PROW(true, 1, "NO.KIRIM     : " + noKirim);
            printESC.PROW(true, 1, "No.POLISI    : " + noPolisi);
            printESC.PROW(true, 1, "==================================================================================================================");
            printESC.PROW(true, 1, "|NO|           NAMA TOKO           |KOLI|NO.NOTA| NO.SJ |T/K|  SALES    |  TANGAL SJ   |   TTD / STEMPEL TOKO    |");
            printESC.PROW(true, 1, "------------------------------------------------------------------------------------------------------------------");

            return printESC.GenerateString();
        }

        private void PrintRawPengantarSuratJalan(DataTable dt)
        {
            BuildString printESC = new BuildString();

            printESC.Initialize();
            printESC.LeftMargin(0);
            printESC.FontCPI(15);
            printESC.Append(PrintHeader(dt));

            int nKoli = 0;
            int jKoli = 0;
            int ctr = 0;
            int no = 0;
            string namaToko = string.Empty;
            string noNota = string.Empty;
            string noSJ = string.Empty;
            string tunaiKredit = string.Empty;
            string sales = string.Empty;
            string ket = string.Empty;
            string tempAlamat = string.Empty;
            string alamat1 = string.Empty;
            string alamat2 = string.Empty;
            string lastToko = string.Empty;
            string lastAlamat1 = string.Empty;
            bool printAlamat1 = false;
            bool printAlamat2 = false;
            bool firstRecord = true;
            int recordCount = 0;
            string kodeToko_ = string.Empty;
            ctr = 12;
            int row = 0;
            bool first = true;
            foreach (DataRow dr in dt.Rows)
            {
                recordCount++;
                namaToko = dr["Toko"].ToString();
                kodeToko_ = dr["KodeToko"].ToString();
                jKoli = int.Parse(dr["JmlKoli"].ToString());
                noNota = dr["NoNota"].ToString();
                noSJ = dr["NoSuratJalan"].ToString();
                tunaiKredit = dr["TK"].ToString();
                sales = dr["Sales"].ToString();
                ket = dr["Keterangan"].ToString();
                
                tempAlamat = dr["Alamat"].ToString();

                if (tempAlamat.Length > 31)
                {
                    alamat1 = tempAlamat.Substring(0, 31);
                    int pos = alamat1.LastIndexOf(' ');
                    alamat1 = alamat1.Substring(0, pos).PadRight(31);
                    alamat2 = tempAlamat.Substring(pos);
                }
                else
                {
                    alamat1 = tempAlamat.PadRight(31);
                    alamat2 = string.Empty;
                }

                alamat2 = alamat2.TrimStart();

                nKoli += jKoli;

                if (lastToko.Equals(kodeToko_))//(lastToko.Equals(kodeToko_) && lastAlamat1.Equals(alamat1))
                {
                    if (printAlamat1 == false)
                    {
                        printAlamat1 = true;
                        printESC.PROW(true, 1, "|" + "  |" + alamat1 + "|" + jKoli.ToString().PadLeft(4) +
                          "|" + noNota + "|" + noSJ + "| " + tunaiKredit + "|" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
                    }
                    else if (printAlamat2 == false)
                    {
                        printAlamat2 = true;
                        printESC.PROW(true, 1, "|" + "  |" + alamat2.PadRight(31) + "|" + jKoli.ToString().PadLeft(4) +
                         "|" + noNota + "|" + noSJ + "| " + tunaiKredit + "|" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
                    }
                    else
                    {
                        printESC.PROW(true, 1, "|" + "  |" + printESC.SPACE(31) + "|" + jKoli.ToString().PadLeft(4) +
                              "|" + noNota + "|" + noSJ + "| " + tunaiKredit + "|" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
                    }
                    firstRecord = true;
                    row++;
                    ctr++;
                }
                else if (printAlamat1 == false && printAlamat2 == false && firstRecord == false)
                {
                    printESC.PROW(true, 1, "|  |" + alamat1 + "|    |       |       |   |           |              |                         |");
                    row += 1;
                    ctr = ctr + 1;
                    if (!string.IsNullOrEmpty(alamat2.Trim()))
                    {
                        printESC.PROW(true, 1, "|  |" + alamat2.PadRight(31) + "|    |       |       |   |           |              |                         |");
                        row += 1;
                        ctr = ctr + 1;
                    }
                    //row += 2;
                    //ctr = ctr + 2;
                    firstRecord = true;
                    printAlamat1 = true;
                    printAlamat2 = true;
                }
                else
                {
                    no++;
                    if (row < 5 && first == false)
                    {
                        for (int i = 0; i < 5 - row; i++)
                        {
                            printESC.PROW(true, 1, "|  |                               |    |       |       |   |           |              |                         |");
                        }



                        ctr = ctr + (5 - row);
                    }
                    row = 0;
                    if (no != 1)
                    {
                        printESC.PROW(true, 1, "|  |                               |    |       |       |   |           |              | ....................... |");
                        row += 1;
                        ctr = ctr + 1;
                    }
                    else
                        row += 1;

                    if ((ctr >= 47) && (recordCount != dt.Rows.Count))
                    {
                        ctr = 0;
                        printESC.PROW(true, 1, "|  |                               |    |       |       |   |           |              |                         |");
                        printESC.PROW(true, 1, "==================================================================================================================");
                        printESC.Eject();
                        printESC.Append(PrintHeader(dt));
                        ctr = 12;
                        first = true;
                    }
                    printESC.PROW(true, 1, "|" + no.ToString().PadLeft(2) + "|" + namaToko.PadRight(31) + "|" + jKoli.ToString().PadLeft(4) +
                          "|" + noNota + "|" + noSJ + "| " + tunaiKredit + "|" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + "                       " + " |");

                    firstRecord = true;
                    printAlamat1 = false;
                    printAlamat2 = false;
                    first = false;
                    row += 1;
                    ctr = ctr + 1;

                }

                lastToko = kodeToko_;
                lastAlamat1 = alamat1;



            }
            if (row < 5)
            {
                for (int i = 0; i < 5 - row; i++)
                {
                    printESC.PROW(true, 1, "|  |                               |    |       |       |   |           |              |                         |");
                }
                ctr = ctr + (5 - row);
            }
            printESC.PROW(true, 1, "------------------------------------------------------------------------------------------------------------------");
            printESC.PROW(true, 1, "|            TOTAL KOLI            |" + nKoli.ToString().PadLeft(4) + "|                                                                        |");
            printESC.PROW(true, 1, "==================================================================================================================");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "             Gudang,                            Security,                                Sopir,");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "         (             )                    (              )                        (               )");
            printESC.Eject();
            printESC.SendToFile("PengantarSuratJalan.txt");
            //printESC.SendToPrinter("PengantarSuratJalan.txt");

        }

        private void cmdPrintPengantarSj_Click(object sender, EventArgs e)
        {
            PrinterValidated("EXPEDISI");

            if (!SecurityManager.IsAuditor())
            {
                if (dataGridxpdc.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }

                if (dataGridxpdc.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    DialogResult dialogResult = MessageBox.Show("Cetak ke Printer ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Penjualan.frmCetakNota ifrmDialog = new Penjualan.frmCetakNota(this, _nCetak);
                        //ifrmDialog.ShowDialog();
                        //if (ifrmDialog.DialogResult == DialogResult.OK)
                        //{
                        //    _nCetak = ifrmDialog.Result;
                        //}
                        //else
                        //    return;

                        if (PrnAktif == "0")
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("rsp_CetakSuratPengantarEkspedisi"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                if (dt.Rows.Count > 0)
                                {
                                    PrintRawPengantarSuratJalan(dt);
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ada");
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
                        else
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {

                                    db.Commands.Add(db.CreateCommand("rsp_CetakSuratPengantarEkspedisi_v2"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                                    dt = db.Commands[0].ExecuteDataTable();

                                }
                                if (dt.Rows.Count > 0)
                                {
                                    PrintRawPengantarSuratJalan_Inkjet(dt);
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ada");
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
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void cmdPenyelesaian_Click(object sender, EventArgs e)
        {
            if (dataGridxpdc.SelectedCells.Count == 0)
            { MessageBox.Show("Silakan pilih data terlebih dahulu..."); return; }

            Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            xpdc.Penyelesaian_Pengiriman_xpdc ifrmChild = new Penyelesaian_Pengiriman_xpdc(this, rowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdBatalKirim_Click(object sender, EventArgs e)
        {
            if (dataGridxpdc.SelectedCells.Count > 0)
            {
                try
                {
                    Guid rowID = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
                    xpdc.frm_batal_kirim ifrmChild = new xpdc.frm_batal_kirim(this, rowID);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void PrintRawSuratJalan(DataTable dt)
        {
            BuildString suratJalan = new BuildString();
            int jumlahkoli = 0;

            #region Header

            string nosj = dt.Rows[0]["NoSuratJalan"].ToString();
            string namatoko = dt.Rows[0]["NamaToko"].ToString();
            string alamat = dt.Rows[0]["Alamat"].ToString();
            string tmp = string.Empty;
            string ekspedisi = dt.Rows[0]["NamaExpedisi"].ToString();
            //string ekspedisi = dt.Rows[0]["Expedisi"].ToString();
            string alamatExpedisi = dt.Rows[0]["AlamatExpedisi"].ToString();
            string kotaExpedisi = dt.Rows[0]["KotaTujuan"].ToString();
            string telpExpedisi = dt.Rows[0]["TelpExpedisi"].ToString();


            if (alamat.Length > 28)
            {
                tmp = alamat.Substring(0, 28);
            }
            else
            {
                tmp = alamat + " ";
            }

            int pos = tmp.LastIndexOf(' ');
            string alamat1 = tmp.Substring(0, pos);
            string alamat3 = dt.Rows[0]["Alamat3"].ToString();
            string alamat2 = alamat.Substring(pos).Trim() + alamat3;
            string kota = dt.Rows[0]["Kota"].ToString();
            string idwil = dt.Rows[0]["WilID"].ToString();
            string tlp = dt.Rows[0]["Telp"].ToString();
            string NoPol = dt.Rows[0]["NoPolisi"].ToString();
            string Sopir = dt.Rows[0]["Sopir"].ToString().Trim();
            string Kernet = dt.Rows[0]["Kernet"].ToString().Trim();
            DateTime tglsuratjalan = DateTime.Parse(dt.Rows[0]["TglSuratJalan"].ToString());

            suratJalan.Initialize();
            suratJalan.Append((char)27 + "@" + (char)27 + "C" + (char)33 + (char)27 + "M");
            suratJalan.Append(Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1));
            //suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, suratJalan.PadCenter(80, "SURAT JALAN"));
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "NOMOR       : " + nosj.PadRight(14) + suratJalan.SPACE(10) + "KEPADA YTH :");
            suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(10) + namatoko);
            //suratJalan.PROW(true, 1, "NO.POLISI   : " + NoPol.PadRight(24) + alamat.Trim().Substring(0,10));
            suratJalan.PROW(true, 1, "NO.POLISI   : " + NoPol.PadRight(24) + alamat);
            suratJalan.PROW(true, 1, "SOPIR/KERNET: " + Sopir + "/" + Kernet.PadRight(20) + kota);
            suratJalan.PROW(true, 1, "EXPEDISI    : " + ekspedisi.PadRight(24));
            suratJalan.PROW(true, 1, "ALAMAT      : " + alamatExpedisi.PadRight(24));
            suratJalan.PROW(true, 1, "KOTA        : " + kotaExpedisi.Trim());
            suratJalan.PROW(true, 1, "TELEPON     : " + telpExpedisi.Trim());

            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(92));
            suratJalan.PROW(true, 1, " NO.DO   NO.NOTA   SALES                    URAIAN                JUMLAH  SATUAN  KETERANGAN");
            suratJalan.PROW(true, 1, suratJalan.Replicate("-", 92));

            #endregion

            #region Detail

            string nonota = string.Empty;
            string nodo = string.Empty;
            string sales = string.Empty;
            string lastNoNota = string.Empty;
            string uraian = string.Empty;
            string ket = string.Empty;
            string satuan = string.Empty;
            int jumlah = 0;

            foreach (DataRow dr in dt.Rows)
            {
                nonota = dr["NoNota"].ToString();
                nodo = dr["NoDO"].ToString();
                sales = dr["Sales"].ToString();
                uraian = dr["Uraian"].ToString();
                ket = dr["Keterangan"].ToString();
                satuan = dr["Satuan"].ToString();
                jumlah = int.Parse(dr["Jumlah"].ToString());

                jumlahkoli += jumlah;
                suratJalan.PROW(true, 1, " " + nodo +
                    " " + nonota +
                    "   " + sales.PadRight(23) +
                    "  " + uraian.PadRight(20) +
                    "  " + jumlah.ToString("#,###;(#,###);#").PadLeft(7) +
                    "  " + suratJalan.PadCenter(6, satuan) +
                    "  " + ket.PadRight(40));
            }

            #endregion

            #region Footer
            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(92));
            suratJalan.PROW(true, 1, suratJalan.SPACE(67) + jumlahkoli.ToString("#,##0").PadLeft(6) + suratJalan.SPACE(11) + (char)27 + (char)33 + (char)24 + "FRANGKO" + (char)27 + (char)33 + (char)1);
            if (GlobalVar.Gudang != "2803")
            {
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "           Penerima,                      Sopir,                     Pengirim,");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "       (...............)            (...............)            (...............)");
            }
            else
            {
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "         Penerima,               Sopir,              Security,             Pengirim,");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "");
                suratJalan.PROW(true, 1, "     (...............)     (...............)     (...............)     (...............)");
            }
            suratJalan.PROW(true, 1, SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyyy") + " Jam " + DateTime.Now.ToShortTimeString());
            suratJalan.Eject();

            #endregion

            //suratJalan.SendToFile("SuratJalan.txt");
            suratJalan.SendToPrinter("SuratJalan.txt");
        }

        private void cmdPrintSj_Click(object sender, EventArgs e)
        {
            PrinterValidated("EXPEDISI");

            if (dataGridxpdc.SelectedCells.Count == 0)
            {
                MessageBox.Show("Silahkan pilih header pengirimannya terlebih dahulu.");
                return;
            }

            if (dataGridDetailxpdc.SelectedCells.Count == 0)
            {
                MessageBox.Show("Silahkan isi terlebih dahulu detail pengirimannya.");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                DataTable dtToko = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanXpdcDetail_Toko"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                    dtToko = db.Commands[0].ExecuteDataTable();

                }
                if (dtToko.Rows.Count == 0)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Toko tujuan kosong di detail pengiriman.");
                    return;
                }


                foreach (DataRow dr in dtToko.Rows)
                {
                    string kodeToko = dr["KodeToko"].ToString();
                    string namaToko = dr["NamaToko"].ToString();
                    string alamatToko = dr["Alamat"].ToString();
                    string message = "Cetak Surat Jalan untuk toko: " + namaToko + "\n" + alamatToko;

                    DialogResult dlg = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dlg == DialogResult.Yes)
                    {
                        DataTable dtSj = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("rsp_CetakSuratJalan2"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kodeToko));
                            dtSj = db.Commands[0].ExecuteDataTable();
                        }

                        if (dtSj.Rows.Count > 0)
                        {
                            if (PrnAktif == "0")
                            {
                                PrintRawSuratJalan(dtSj);
                            }
                            else
                            {
                                PrintRawSuratJalan_Inkjet(dtSj);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Suran Jalan untuk toko " + namaToko + "\n" + alamatToko + "\n tidak bisa dicetak.");
                        }
                    }
                }
            }
            catch (Exception ex) { Error.LogError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }


        private void PrintRawSuratJalan_Inkjet(DataTable dt)
        {
            string UserID = SecurityManager.UserName.ToString();
            string Gudang = GlobalVar.Gudang;
            string Expedisi = Tools.isNull(dt.Rows[0]["Expedisi"], "").ToString();
            string AlamatExp = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
            int Total = 0, TotalPcs = 0;

            foreach (DataRow dr in dt.Rows)
            {
                Total += int.Parse(Tools.isNull(dr["JmlKoli"],"0").ToString());
                TotalPcs += int.Parse(Tools.isNull(dr["JmlPcs"],"0").ToString());
            }

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", UserID.ToString()));
            rptParams.Add(new ReportParameter("Total", Total.ToString()));
            rptParams.Add(new ReportParameter("Gudang", Gudang.ToString()));
            rptParams.Add(new ReportParameter("TotalPcs", TotalPcs.ToString()));

            int prn = 0, lbr = 1;
            prn = int.Parse(Tools.isNull(PrnAktif, "0").ToString());

            for (int i = 1; i <= prn; i = i + 1)
            {
                if (i == 1)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.rptXpdcSuratJalan.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print();
                }
                if (i == 2)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.rptXpdcSuratJalan_copy1.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print();
                }
                if (i == 3)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.rptXpdcSuratJalan_copy2.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print();
                }
                //if (i == 4)
                //{
                //    frmReportViewer ifrmReport = new frmReportViewer("xpdc.rptXpdcSuratJalan_copy3.rdlc", rptParams, dt, "dsEkspedisi_Data");
                //    ifrmReport.Print();
                //}
            }
        }


        private void PrinterValidated(string cKet)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, cKet));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    PrnAktif = "0";
                }
                else
                {
                    PrnAktif = Tools.isNull(dt.Rows[0]["Value"], "0").ToString();
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


        private void PrintRawPengantarSuratJalan_Inkjet(DataTable dt)
        {
            string namaPerusahaan = dt.Rows[0]["NamaPerusahaan"].ToString();
            string alamat = dt.Rows[0]["AlamatPerusahaan"].ToString();
            string kota = dt.Rows[0]["KotaPerusahaan"].ToString();
            string tujuan = dt.Rows[0]["Tujuan"].ToString();
            string supir = dt.Rows[0]["Sopir"].ToString();
            string kernet = dt.Rows[0]["Kernet"].ToString();
            string noKirim = dt.Rows[0]["NoKirim"].ToString();
            string noPolisi = dt.Rows[0]["NoPolisi"].ToString();
            DateTime tglKirim = DateTime.Parse(dt.Rows[0]["TglKirim"].ToString());
            string UserName = SecurityManager.UserName.ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("TglKirim", tglKirim.ToString()));
            rptParams.Add(new ReportParameter("Tujuan", tujuan));
            rptParams.Add(new ReportParameter("Sopir", supir));
            rptParams.Add(new ReportParameter("Kernet", kernet));
            rptParams.Add(new ReportParameter("NoKirim", noKirim));
            rptParams.Add(new ReportParameter("NoPolisi", noPolisi));
            rptParams.Add(new ReportParameter("UserID", UserName));

            int prn = 0, lbr = 1;
            prn = int.Parse(Tools.isNull(PrnAktif, "0").ToString());

            for (int i = 1; i <= prn; i = i + 1)
            {
                if (i == 1)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptPengantarSuratJalan.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print(8.5, 12.75);
                }
                if (i == 2)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptPengantarSuratJalan_copy1.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print(8.5, 12.75);
                }
                if (i == 3)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptPengantarSuratJalan_copy2.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print(8.5, 12.75);
                }
                if (i == 4)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("xpdc.RptPengantarSuratJalan_copy3.rdlc", rptParams, dt, "dsEkspedisi_Data");
                    ifrmReport.Print(8.5, 12.75);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterValidated("EXPEDISI");

            if (!SecurityManager.IsAuditor())
            {
                if (dataGridxpdc.SelectedCells.Count == 0)
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                    return;
                }

                if (dataGridxpdc.SelectedCells.Count > 0)
                {
                    Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    DialogResult dialogResult = MessageBox.Show("Cetak ke Printer ?", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Penjualan.frmCetakNota ifrmDialog = new Penjualan.frmCetakNota(this, _nCetak);
                        //ifrmDialog.ShowDialog();
                        //if (ifrmDialog.DialogResult == DialogResult.OK)
                        //{
                        //    _nCetak = ifrmDialog.Result;
                        //}
                        //else
                        //    return;

                        if (PrnAktif == "0")
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("rsp_CetakSuratPengantarEkspedisi"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                if (dt.Rows.Count > 0)
                                {
                                    PrintRawPengantarSuratJalan(dt);
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ada");
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
                        else
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database())
                                {

                                    db.Commands.Add(db.CreateCommand("rsp_CetakSuratPengantarEkspedisi_v2"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                                    dt = db.Commands[0].ExecuteDataTable();

                                }
                                if (dt.Rows.Count > 0)
                                {
                                    PrintRawPengantarSuratJalan_Inkjet(dt);
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ada");
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
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }

        }

        private void frm_kirim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (MessageBox.Show("Cetak Daftar Ekspedisi ?", "Cetak", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {

                            db.Commands.Add(db.CreateCommand("rsp_CetakDaftarExpedisi"));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DisplayReportExpedisi(dt);
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ada");
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
            }
        }

        private void DisplayReportExpedisi(DataTable dt)
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(LapExpedisiList(dt));

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "rpt_Expedisi_List";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private ExcelPackage LapExpedisiList(DataTable dt)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Daftar Ekspedisi";
            ex.Workbook.Properties.SetCustomPropertyValue("Ekspedisi", "1147");

            ex.Workbook.Worksheets.Add("Ekspedisi");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];
            ws.View.ShowGridLines = false;
            ws.Cells.Style.Font.Size = 9;

            int nRow = 0, nHeader = 1, Rowx = 0;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 30;      //namaexpedisi
            ws.Cells[1, 4].Worksheet.Column(4).Width = 60;      //alamat
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;      //kota
            ws.Cells[1, 6].Worksheet.Column(6).Width = 40;      //telp
            ws.Cells[1, 7].Worksheet.Column(7).Width = 30;      //tujuan

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Daftar Ekspedisi";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", DateTime.Today);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            //ws.Cells[nHeader + 3, 2].Value = "Depo " + GlobalVar.Gudang;
            //ws.Cells[nHeader + 3, 2].Style.Font.Bold = true;
            //ws.Cells[nHeader + 2, 2].Style.Font.Italic = true;

            nRow = nHeader + 3;
            Rowx = nRow;
            int MaxCol = 7;

            for (int i = 2; i <= 7; i++)
            {
                ws.Cells[Rowx, i, Rowx + 1, i].Merge = true;
            }

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " Nama Ekspedisi ";
            ws.Cells[Rowx, 4].Value = " Alamat ";
            ws.Cells[Rowx, 5].Value = " Kota ";
            ws.Cells[Rowx, 6].Value = " Telp ";
            ws.Cells[Rowx, 7].Value = " Tujuan ";

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx + 1, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);

            Rowx += 2;
            int no = 0;
            double Jumlah = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt.Rows)
                {
                    no += 1;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells[Rowx, 3].Value = Tools.isNull(dr1["NamaExpedisi"], "").ToString();
                    ws.Cells[Rowx, 4].Value = Tools.isNull(dr1["Alamat"], "").ToString();
                    ws.Cells[Rowx, 5].Value = Tools.isNull(dr1["Kota"], "").ToString();
                    ws.Cells[Rowx, 6].Value = Tools.isNull(dr1["Telp"], "").ToString();
                    ws.Cells[Rowx, 7].Value = Tools.isNull(dr1["Tujuan"], "").ToString();
                    Rowx++;
                }
            }
            Rowx++;

            var border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx - 1, 2, Rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style = ExcelBorderStyle.Thin;
            border.Top.Style = ExcelBorderStyle.None;
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[Rowx, 10, Rowx, 10].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            border = ws.Cells[nRow, 2, nRow + 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            Rowx += 2;
            ws.Cells[Rowx - 2, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
            ws.Cells[Rowx - 2, 2].Style.Font.Size = 8;
            ws.Cells[Rowx - 2, 2].Style.Font.Italic = true;

            return ex;

        }

    }
}
