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

namespace ISA.Trading.Ekspedisi
{
    public partial class frmEkspedisiPengirimanBrowse : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { PengirimanEkspedisiHeader, PengirimanEkspedisiDetail, RekapKoli};
        enumSelectedGrid selectedGrid = enumSelectedGrid.PengirimanEkspedisiHeader;

        public frmEkspedisiPengirimanBrowse()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (!rdbTgl.FromDate.HasValue || !rdbTgl.ToDate.HasValue)
            {
                rdbTgl.Focus();
                return;

            }
            RefreshDataHeader();
        }

        public void RefreshDataHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    this.Cursor = Cursors.WaitCursor;


                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST_FILTER_TglKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        //_jKoliB = dt.Compute("SUM(JKoliB)", string.Empty).ToString();
                        //_jKoliK = dt.Compute("SUM(JKoliK)", string.Empty).ToString();
                        //dataGridView1.DataSource = dt;
                        txtSumKoliB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliB"].Value.ToString();
                        txtSumKoliK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliK"].Value.ToString();

                        txtSumSJB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoB"].Value.ToString();
                        txtSumSJK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoK"].Value.ToString();

                    }
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                    txtSumKoliB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliB"].Value.ToString();
                    txtSumKoliK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliK"].Value.ToString();

                    txtSumSJB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoB"].Value.ToString();
                    txtSumSJK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoK"].Value.ToString();

                }
                else
                {
                    dataGridView1.DataSource = null;
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

        public void FindHeader(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }

        public void RefreshDataDetail()
        {
            try
            {
                Guid _rowID = (Guid) dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dataGridView2.DataSource = null;                 
                }

                if (dataGridView2.SelectedCells.Count > 0)
                {
                    label2.Text = dataGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                    RefreshDataRekapKoli();
                }
                else
                {
                    label2.Text = "";
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

        public void FindDetail(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }

        public void RefreshDataRekapKoli()
        {
            try
            {
                Guid _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RekapKoliID"].Value;
               
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }


                if (dt.Rows.Count > 0)
                {
                    dataGridView3.DataSource = dt;
                }
                else
                {
                    dataGridView3.DataSource = null;
                }
                if (dataGridView3.SelectedCells.Count > 0)
                {
                    txtToko.Text = dt.Rows.Count.ToString();
                }
                else
                {
                    txtToko.Text = "";

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

        public void FindRekapKoli(string columnName, string value)
        {
            dataGridView3.FindRow(columnName, value);
        }

        private void frmEkspedisiPengirimanBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            rdbTgl.FromDate = DateTime.Now;
            rdbTgl.ToDate = DateTime.Now;
            label2.Text = "";
        }
               
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.PengirimanEkspedisiHeader)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                        if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Ekspedisi.frmEkspedisiPengirimanUpdate ifrmChild = new Ekspedisi.frmEkspedisiPengirimanUpdate(this, rowID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        //}
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

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.PengirimanEkspedisiDetail:
                        if (int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0)
                        {
                            // Validasi di angkat, krn hapus boleh dr segala kondisi
                            //if (!string.IsNullOrEmpty(dataGridView2.SelectedCells[0].OwningRow.Cells["TglKembaliDetail"].Value.ToString()))
                            //{
                            //    MessageBox.Show("Data tidak bisa di hapus.");
                            //    dataGridView2.Focus();
                            //    return;
                            //}
                            if (!SecurityManager.AskPasswordManager())
                            { 
                                dataGridView2.Focus();
                                return;
                            }
                        }

                        if (MessageBox.Show("Data akan dihapus...?", "Hapus Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;

                                Guid _rowIDDetail = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                                Guid _rowIDRekapKoli = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RekapKoliRowID"].Value;

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisiDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDDetail));
                                    db.Commands[0].Parameters.Add(new Parameter("@rekapKoliID", SqlDbType.UniqueIdentifier, _rowIDRekapKoli));

                                    db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
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
                        break;
                case enumSelectedGrid.PengirimanEkspedisiHeader:
                        if (int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["NPrintHeader"].Value.ToString()) > 0)
                        {
                            if (!string.IsNullOrEmpty(dataGridView1.SelectedCells[0].OwningRow.Cells["TglKembali"].Value.ToString()))
                            {
                                MessageBox.Show("Data tidak bisa di hapus.");
                                dataGridView1.Focus();
                                return;
                            }
                            if (!SecurityManager.AskPasswordManager())
                            {
                                dataGridView1.Focus();
                                return;
                            }
                        }
                        if (MessageBox.Show("Data akan dihapus...?", "Hapus Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                                if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;

                                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));

                                    db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataHeader();
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
                        break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.PengirimanEkspedisiHeader :
                    Ekspedisi.frmEkspedisiPengirimanUpdate ifrmChild = new Ekspedisi.frmEkspedisiPengirimanUpdate(this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    RefreshDataHeader();
                    break;
                case enumSelectedGrid.PengirimanEkspedisiDetail:
                    if (dataGridView1 .SelectedCells.Count > 0)
                    {
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value;
                            if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKirim"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            Guid _headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string _trID = dataGridView1.SelectedCells[0].OwningRow.Cells["TrID"].Value.ToString();
                            DateTime _fromDate = (DateTime)rdbTgl.FromDate;
                            DateTime _toDate = (DateTime)rdbTgl.ToDate;
                            Ekspedisi.frmEkspedisiPengirimanDetailUpdate ifrmChild2 = new Ekspedisi.frmEkspedisiPengirimanDetailUpdate(this, _headerID, _trID, _fromDate, _toDate);
                            ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
                            RefreshDataHeader();
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                    break;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.PengirimanEkspedisiDetail;
            if (!SecurityManager.IsAuditor())
            {
                cmdEdit.Enabled = false;
                cmdDelete.Enabled = true;
                cmdAdd.Enabled = true;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.PengirimanEkspedisiHeader;
            if (!SecurityManager.IsAuditor())
            {
                cmdEdit.Enabled = true;
                cmdDelete.Enabled = true;
                cmdAdd.Enabled = true;
            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            cmdAdd.Enabled = false;
            cmdEdit.Enabled = false;
            cmdDelete.Enabled = false;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                label2.Text = dataGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                RefreshDataRekapKoli();
            }
            else
            {
                label2.Text = "";
            }
        }

        private void frmEkspedisiPengirimanBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!SecurityManager.IsAuditor())
                {
                    if (dataGridView1.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }

                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
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
                }
            }
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
            printESC.PROW(true, 1, "|NO|           NAMA TOKO           |KOLI|NO.NOTA| NO.SJ |T/K|  SALES    |  KETERANGAN  |       TANDA TERIMA      |");
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

                if (lastToko.Equals(kodeToko_) )//(lastToko.Equals(kodeToko_) && lastAlamat1.Equals(alamat1))
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
                else if (printAlamat1 == false && printAlamat2 == false && firstRecord==false)
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
                    if (row < 5 && first==false)
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
            printESC.PROW(true, 1,"------------------------------------------------------------------------------------------------------------------");
            printESC.PROW(true, 1,"|            TOTAL KOLI            |" + nKoli.ToString().PadLeft(4) + "|                                                                        |");
            printESC.PROW(true, 1,"==================================================================================================================");
            printESC.Eject();

            printESC.SendToFile("PengantarSuratJalan.txt");

        }
        private void DisplayReport(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            //rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptSuratPengantarEkspedisi.rdlc", rptParams, dt, "dsEkspedisi_Data");
            ifrmReport.Show();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataDetail();
                txtSumKoliB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliB"].Value.ToString();
                txtSumKoliK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JKoliK"].Value.ToString();

                txtSumSJB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoB"].Value.ToString();
                txtSumSJK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoK"].Value.ToString();

            }
        }
       
    }
}
