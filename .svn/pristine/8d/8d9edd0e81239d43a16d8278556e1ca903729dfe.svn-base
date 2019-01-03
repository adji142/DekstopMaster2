using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.xpdc
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

        enum enumSelectedGrid { Header, Detail };
        enumSelectedGrid dgS = enumSelectedGrid.Header;

        public frm_kirim()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool isPrintSj = LookupInfoValue.CekPrintSj();

            cmdPrintSj.Visible = isPrintSj;

            if (cmdPrintSj.Visible)
            {
                cmdPrintPengantarSj.Text = "REKAP";
            }

            nDay = DateTime.Today.Day-1;
            
            _fromDate = DateTime.Today.AddDays(-nDay);
            _toDate = DateTime.Now;
            rdb_xpdc.FromDate = _fromDate;
            rdb_xpdc.ToDate = _toDate;
            rdb_xpdc.Focus();

            RefreshDataXpdc();
            //sekarang = _toDate.AddDays(Convert.ToInt16(DateTime.Today));
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
            if (e.KeyCode == Keys.Insert)
                Insert_Header();
            else if (e.KeyCode == Keys.Space)
                Edit_Header();
            else if (e.KeyCode == Keys.Delete)
                Hapus_Header();
            else if (e.KeyCode == Keys.F3)
                if (cmdPrintSj.Visible)
                    cmdPrintSj_Click(sender, e);
                else
                    cmdPrintPengantarSj_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                if (cmdPrintSj.Visible)
                    cmdPrintPengantarSj_Click(sender, e);

            //if (dataGridxpdc.RowCount > 0 && dataGridxpdc.SelectedCells.Count > 0)
            //{
            //    if (e.Control == true && e.KeyCode == Keys.P)
            //    {
            //        //this.Cursor = Cursors.WaitCursor;
            //        Guid _rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            //        if (!CekDataPrint())
            //        {
            //            MessageBox.Show("Tanggal Kembali masih kosong");
            //            return;
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("Cetak..?", "Cetak data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //            }
            //        }

            //    }
            //}
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
            Guid rowID = (Guid)dataGridxpdc.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
            DateTime tglKirim = (DateTime)dataGridxpdc.SelectedCells[0].OwningRow.Cells[TglKirim.Name].Value;
            DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;

            frmXpdcDetailAdd frm = new frmXpdcDetailAdd(rowID, tglKirim, detailDt);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                RefreshDataDetail();
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

                //if (CekAddEditHapus("Edit"))
                //{
                //    MessageBox.Show("Tidak ada data yang diedit");
                //    return;
                //}

                try
                {
                    //Guid rowID = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
                    //xpdc.frm_barcode_detail_kirim ifrmChild = new xpdc.frm_barcode_detail_kirim(this, rowID);
                    //ifrmChild.MdiParent = Program.MainForm;
                    //Program.MainForm.RegisterChild(ifrmChild);
                    //ifrmChild.Show();

                    Guid rowId = (Guid)dataGridDetailxpdc.SelectedCells[0].OwningRow.Cells["DRowID"].Value;
                    DataTable detailDt = (DataTable)dataGridDetailxpdc.DataSource;
                    frmXpdcDetailUpdate frm = new frmXpdcDetailUpdate(rowId, detailDt);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                        RefreshDataDetail();

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
            printESC.PROW(true, 1, "|NO|           NAMA TOKO           |KOLI|NO.NOTA| NO.SJ |T/K|  SALES    |  TANGAL SJ   |       TANDA TERIMA      |");
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
                          "|" + noNota + "|" + noSJ + "| " + tunaiKredit + " |" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
                    }
                    else if (printAlamat2 == false)
                    {
                        printAlamat2 = true;
                        printESC.PROW(true, 1, "|" + "  |" + alamat2.PadRight(31) + "|" + jKoli.ToString().PadLeft(4) +
                         "|" + noNota + "|" + noSJ + "| " + tunaiKredit + " |" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
                    }
                    else
                    {
                        printESC.PROW(true, 1, "|" + "  |" + printESC.SPACE(31) + "|" + jKoli.ToString().PadLeft(4) +
                              "|" + noNota + "|" + noSJ + "| " + tunaiKredit + " |" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + printESC.SPACE(23) + " |");
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
                          "|" + noNota + "|" + noSJ + "| " + tunaiKredit + " |" + sales.PadRight(11) + "|" + ket.PadRight(14) + "| " + "                       " + " |");

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
            printESC.Eject();

            printESC.SendToFile("PengantarSuratJalan.txt");

        }

        private void cmdPrintPengantarSj_Click(object sender, EventArgs e)
        {
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
                                //DisplayReport(dt);
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
            DateTime tglsuratjalan = DateTime.Parse(dt.Rows[0]["TglSuratJalan"].ToString());


            suratJalan.Initialize();
            suratJalan.Append((char)27 + "@" + (char)27 + "C" + (char)33 + (char)27 + "M");
            suratJalan.Append(Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1));
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, suratJalan.PadCenter(80, "SURAT JALAN"));
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "NO.         : " + nosj.PadRight(14) + suratJalan.SPACE(20) + "KEPADA YTH :");
            suratJalan.PROW(true, 1, "KENDARAAN   : .............." + suratJalan.SPACE(20) + namatoko);
            suratJalan.PROW(true, 1, "NO. POLISI  : .............." + suratJalan.SPACE(20) + alamat1);

            suratJalan.PROW(true, 1, "EXPEDISI    : " + " ".PadRight(34) + (string.IsNullOrEmpty(alamat2) == true ? kota : alamat2));
            if (!string.IsNullOrEmpty(alamat2))
            {
                suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20) + kota);
                suratJalan.PROW(true, 1, suratJalan.SPACE(48) + "WIL : " + idwil + (string.IsNullOrEmpty(tlp) == true ? tlp : ",TELP : " + tlp));
            }
            else
            {
                suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20) + "WIL : " + idwil + (string.IsNullOrEmpty(tlp) == true ? tlp : ",TELP : " + tlp));
            }

            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(88));
            suratJalan.PROW(true, 1, "  NO.DO  NO.NOTA    SALES       URAIAN    JUMLAH  SATUAN           KETERANGAN           ");
            suratJalan.PROW(true, 1, suratJalan.Replicate(".", 88));

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

                if (lastNoNota.Equals(nonota))
                {
                    sales = suratJalan.SPACE(11);
                    nodo = suratJalan.SPACE(7);
                    nonota = suratJalan.SPACE(7);
                }
                else
                {
                    lastNoNota = nonota;
                }

                suratJalan.PROW(true, 1, " " + nodo +
                    " " + nonota +
                    " " + sales +
                    " " + uraian.PadRight(12) +
                    " " + jumlah.ToString("#,###;(#,###);#").PadLeft(7) +
                    " " + suratJalan.PadCenter(6, satuan) +
                    " " + ket.PadRight(30));
            }

            #endregion

            #region Footer
            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(88));

            suratJalan.PROW(true, 1, suratJalan.SPACE(41) + jumlahkoli.ToString("#,##0").PadLeft(6) + suratJalan.SPACE(11) + (char)27 + (char)33 + (char)24 + "FRANGKO" + (char)27 + (char)33 + (char)1);

            suratJalan.PROW(true, 1, "");

            suratJalan.PROW(true, 1, "           PENERIMA                     PENGIRIMAN                    SOPIR");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "         (..........)                  (...........)               (............)");
            suratJalan.PROW(true, 1, SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyyy") + " Jam " + DateTime.Now.ToShortTimeString());
            suratJalan.Eject();

            #endregion

            suratJalan.SendToPrinter("RekapKoli.txt");
        }

        private void cmdPrintSj_Click(object sender, EventArgs e)
        {
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
                            PrintRawSuratJalan(dtSj);
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
    }
}
