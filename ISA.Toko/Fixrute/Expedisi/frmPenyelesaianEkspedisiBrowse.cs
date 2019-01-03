using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using Microsoft.VisualBasic;
using ISA.Toko.Class;

namespace ISA.Toko.Expedisi
{
    public partial class frmPenyelesaianEkspedisiBrowse : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        int prevGrid2Row = -1;
        enum enumSelectedGrid { PengirimanEkspedisiHeader, PengirimanEkspedisiDetail, RekapKoli };
        enumSelectedGrid selectedGrid = enumSelectedGrid.PengirimanEkspedisiHeader;

        public frmPenyelesaianEkspedisiBrowse()
        {
            InitializeComponent();
        }

        private void frmPenyelesaianEkspedisiBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            rdbTgl.FromDate = DateTime.Now;
            rdbTgl.ToDate = DateTime.Now;
            label2.Text = "";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataHeader();
        }

        public void RefreshDataHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST_FILTER_TglKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rdbTgl.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rdbTgl.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    txtSumSJB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoB"].Value.ToString();
                    txtSumSJK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoK"].Value.ToString();

                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
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

        public void RefreshDataDetail()
        {
            try
            {
                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
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

                    int _totalKoli = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                       _totalKoli += int.Parse(dr["JKoli"].ToString());
                    }
                    
                    txtSumKoliB.Text = _totalKoli.ToString();
                    txtSumKoliK.Text = _totalKoli.ToString();
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.PengirimanEkspedisiHeader)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    //if (SecurityManager.AskPasswordManager())
                    //{
                    try
                    {
                        if (dataGridView1.SelectedCells[0].OwningRow.Cells["TglKembali"].Value.ToString()!="")
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKembali"].Value;
                            if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglKembali"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                        }
                       
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        Expedisi.frmPenyelesaianEkspedisiUpdate ifrmChild = new Expedisi.frmPenyelesaianEkspedisiUpdate(this, rowID);
                        //ifrmChild.MdiParent = Program.MainForm;
                        //Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.ShowDialog();
                        if (ifrmChild.DialogResult == DialogResult.OK)
                        {
                            dataGridView1.SelectedCells[0].OwningRow.Cells["TglKembali"].Value = ifrmChild.TglKembali;
                            dataGridView1.RefreshEdit();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    //}
                }
                else
                {
                    MessageBox.Show(Messages.Error.RowNotSelected);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.PengirimanEkspedisiHeader;
            if (!SecurityManager.IsAuditor())
            {
                cmdEdit.Enabled = true;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.PengirimanEkspedisiDetail;
            if (!SecurityManager.IsAuditor())
            {
                cmdEdit.Enabled = true;
            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            cmdEdit.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshDataDetail();
                    txtSumSJB.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoB"].Value.ToString();
                    txtSumSJK.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["JTokoK"].Value.ToString();
                }
                prevGrid1Row = dataGridView1.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {

                if (dataGridView2.SelectedCells[0].RowIndex != prevGrid2Row)
                {
                    label2.Text = dataGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " " + dataGridView2.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                    RefreshDataRekapKoli();
                }
                prevGrid2Row = dataGridView2.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid2Row = -1;
                label2.Text = "";
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!SecurityManager.IsAuditor())
            {
                string noSj = dataGridView2.SelectedCells[0].OwningRow.Cells["NoSj"].Value.ToString();
                string message = "Surat jalan No: " + noSj + " akan dipending?";

                if (e.KeyCode == Keys.F5)
                {
                    if (MessageBox.Show(message, "Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PendingProses(noSj);
                    }
                }
            }
        }

        private void PendingProses(string noSuratJalan)
        {
            DataTable dtResult = new DataTable();
            string alasanPending;
            alasanPending = Interaction.InputBox("Alasan Pending:", "Alasan Pending","", 100, 100);

            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenyelesaianExpedisiCekPending"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, noSuratJalan));
                dtResult = db.Commands[0].ExecuteDataTable();
            }

            string updateRowID = string.Empty;
            string tglKembali = string.Empty;
            string ketPending = string.Empty;

            foreach (DataRow dr in dtResult.Rows)
            {
                updateRowID = dr["RowID"].ToString();
                tglKembali = dr["TglKembali"].ToString();
                ketPending = dr["KetPending"].ToString();
            }

            bool update = true;

            if (!string.IsNullOrEmpty(tglKembali))
            {
                try
                {
                    //GlobalVar.LastClosingDate = Convert.ToDateTime(tglKembali);
                    //if (PeriodeClosing.IsPJTClosed(Convert.ToDateTime(tglKembali)))
                    //{
                    //    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    //}
                    if (!string.IsNullOrEmpty(ketPending))
                    {
                        string message = "Surat jalan No: " + noSuratJalan + " pernah dipending. akan dibatalkan?";

                        if (MessageBox.Show(message, "Pending", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (SecurityManager.AskPasswordManager())
                            {
                                alasanPending = string.Empty;
                            }
                            else
                            {
                                update = false;
                            }
                        }
                        else
                        {
                            update = false;
                        }

                    }
                    if (update)
                    {
                        using (Database db2 = new Database())
                        {
                            db2.Commands.Add(db2.CreateCommand("usp_PenyelesaianExpedisiPending_UPDATE"));
                            db2.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.VarChar, updateRowID));
                            db2.Commands[0].Parameters.Add(new Parameter("@ketPending", SqlDbType.VarChar, alasanPending));
                            db2.BeginTransaction();
                            db2.Commands[0].ExecuteNonQuery();
                            db2.CommitTransaction();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void PrintRawRincianBiaya(DataTable dt)
        { 
            BuildString printESC = new BuildString();

            DateTime tglKirim = DateTime.Parse(dt.Rows[0]["TglKirim"].ToString());
            string sopir = dt.Rows[0]["Sopir"].ToString();
            string tujuan = dt.Rows[0]["Tujuan"].ToString();
            string kernet = dt.Rows[0]["Kernet"].ToString();
            string noPolisi = dt.Rows[0]["NoPolisi"].ToString();
            double total = double.Parse(dt.Rows[0]["Total"].ToString());
            double bbmRp = double.Parse(dt.Rows[0]["BBMRp"].ToString()); ;
            double parkir = double.Parse(dt.Rows[0]["Parkir"].ToString()); ;
            double uangMakan = double.Parse(dt.Rows[0]["UangMakan"].ToString()); ;
            double tol = double.Parse(dt.Rows[0]["Tol"].ToString()); ;
            double izinMasuk = double.Parse(dt.Rows[0]["IzinMasuk"].ToString()); ;
            double timbangan = double.Parse(dt.Rows[0]["Timbangan"].ToString()); ;
            double insTepatWaktu = double.Parse(dt.Rows[0]["InTepatWaktu"].ToString()); ;
            double insPengiriman = double.Parse(dt.Rows[0]["InPengiriman"].ToString()); ;
            double lain = double.Parse(dt.Rows[0]["Lain"].ToString()); ;
            double kuli = double.Parse(dt.Rows[0]["Kuli"].ToString()); ;
            double kasbon = double.Parse(dt.Rows[0]["Kasbon"].ToString());

            printESC.Initialize();
            printESC.Append(printESC.SPACE(20) + Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)24));
            printESC.PROW(true, 1, "PERINCIAN BIAYA EKSPEDISI");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1) + "Periode  : " + tglKirim.ToString("dd-MMM-yyyy") + printESC.SPACE(15) + "Nama Sopir  : " + sopir);
            printESC.PROW(true, 1, "Jalur    : "+ tujuan.PadRight(20) + printESC.SPACE(6) + "Nama Helper : " + kernet);
            printESC.PROW(true, 1, printESC.SPACE(37) + "No. Polisi  : "+ noPolisi);
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1,  printESC.Replicate("-", 60));
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "Biaya Bahan Bakar                 : Rp. " + bbmRp.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Retribusi Parkir            : Rp. " + parkir.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Makan                       : Rp. " + uangMakan.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Tol                         : Rp. " + tol.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Izin Masuk kota             : Rp. " + izinMasuk.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Timbangan                   : Rp. " + timbangan.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Insentif tepat waktu              : Rp. " + insTepatWaktu.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Insentif pengiriman               : Rp. " + insPengiriman.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Lain-lain                         : Rp. " + lain.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Biaya Kuli                        : Rp. " + kuli.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, printESC.SPACE(32) + "-----------------");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "Jumlah Biaya                      : Rp. " + total.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "Uang Saku                         : Rp. " + kasbon.ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, printESC.SPACE(32) + "-----------------");
            printESC.PROW(true, 1, "Sisa uang saku                    : Rp. " + (kasbon - total).ToString("#,##0").PadLeft(9));
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "Keterangan     : ");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, "");
            printESC.PROW(true, 1, " Bag. Ekspedisi,                                    Kasir, ");
            printESC.Eject();

            printESC.SendToPrinter("RincianBiaya.txt");
        }

        private void PrintRawRekapPengirimanBarang(DataTable dt)
        {
            BuildString printESC = new BuildString();

            string noKirim = dt.Rows[0]["NoKirim"].ToString();
            string noPolisi = dt.Rows[0]["NoPolisi"].ToString();
            DateTime tglKirim = DateTime.Parse(dt.Rows[0]["TglKirim"].ToString());
            string sopir = dt.Rows[0]["Sopir"].ToString();
            string tujuan = dt.Rows[0]["Tujuan"].ToString();
            int totalKoli = 0;
            double kasbon = double.Parse(dt.Rows[0]["Kasbon"].ToString());
            double bbmRp = double.Parse(dt.Rows[0]["BBMRp"].ToString());
            int bbmLtr = int.Parse(dt.Rows[0]["BBMLtr"].ToString());
            double umSopir = double.Parse(dt.Rows[0]["UMSopir"].ToString());
            double umKernet = double.Parse(dt.Rows[0]["UMKernet"].ToString()); 
            double operational = double.Parse(dt.Rows[0]["Operational"].ToString()); 
            double jumlahBiaya = double.Parse(dt.Rows[0]["JumlahBiaya"].ToString()); 
            double sisa = double.Parse(dt.Rows[0]["Sisa"].ToString());

            printESC.Initialize();
            printESC.FontCondensed(true);
            printESC.PROW(true, 1,  "NOMOR   : " + noKirim + printESC.SPACE(55) + "NO.POL   : " + noPolisi.PadRight(10));
            printESC.PROW(true, 1,  "TANGGAL : " + tglKirim.ToString("dd-MMM-yyyy") + printESC.SPACE(50) + "DRIVER   : " + sopir.PadRight(20));
            printESC.PROW(true, 1,  printESC.SPACE(71) + "KIRIM KE : " + tujuan.PadRight(20));
            printESC.PROW(true, 1,  "======================================================================================================");
            printESC.PROW(true, 1,  "|NO| NO.SJ |           CUSTOMER            |        KOTA        |NO.NOTA|KODE SALES |KOLI |KETERANGAN|");
            printESC.PROW(true, 1,  "------------------------------------------------------------------------------------------------------");
            
            int ctr=0;
            string noSj = string.Empty;
            string namaToko = string.Empty;
            string kota = string.Empty;
            string noNota =string.Empty;
            string sales = string.Empty;
            int jKoli=0;
            string uraian = string.Empty;
            
            foreach(DataRow dr in dt.Rows)
            {
                noSj = dr["NoSuratJalan"].ToString();
                namaToko = dr["NamaToko"].ToString();
                kota = dr["Kota"].ToString();
                noNota = dr["NoNota"].ToString();
                sales = dr["NamaSales"].ToString();
                jKoli = int.Parse(dr["JKoli"].ToString());
                uraian = dr["Uraian"].ToString();

                ctr++;

                printESC.PROW(true, 1,"|" + ctr.ToString().PadLeft(2) + "|" + noSj + "|" + namaToko.PadRight(31) + "|" + kota.PadRight(20) +
                    "|" + noNota + "|" + sales.PadRight(11) + "|" + jKoli.ToString().PadLeft(5) + "|" + uraian.PadRight(10) + "|");

                totalKoli += jKoli;
            }
            
            printESC.PROW(true, 1, "------------------------------------------------------------------------------------------------------");
            printESC.PROW(true, 1, "|                                                                        TOTAL KOLI  " + totalKoli.ToString().PadLeft(5) + "           |");
            printESC.PROW(true, 1, "------------------------------------------------------------------------------------------------------");
            printESC.PROW(true, 1, "|                                                              |                                     |");
            printESC.PROW(true, 1, "|Jumlah BS                                    Rp. " + kasbon.ToString("#,##0.00").PadLeft(12) + " |Driver/  Ka.Expedisi  Opr.POS  Kasir |");
            printESC.PROW(true, 1, "|BBM                Rp. " + bbmRp.ToString("#,##0.00").PadLeft(12) + " (" + bbmLtr.ToString().PadLeft(3) + " Lt)                  |Helper                               |");
            printESC.PROW(true, 1, "|Biaya Operasional  Rp. " + operational.ToString("#,##0.00").PadLeft(12) + "                           |                                     |");
            printESC.PROW(true, 1, "|Biaya Sopir        Rp. " + umSopir.ToString("#,##0.00").PadLeft(12) + "                           |                                     |");
            printESC.PROW(true, 1, "|Biaya Kernet       Rp. " + umKernet.ToString("#,##0.00").PadLeft(12) + "                           |                                     |");
            printESC.PROW(true, 1, "|      Jumlah Biaya                           Rp. " + jumlahBiaya.ToString("#,##0.00").PadLeft(12) + " |                                     |");
            printESC.PROW(true, 1, "|                                                              |                                     |");
            printESC.PROW(true, 1, "|      Sisa Disetor                           Rp. " + sisa.ToString("#,##0.00").PadLeft(12) + " |                                     |");
            printESC.PROW(true, 1, "|                                                              |(......)  (........)  (.....)  (....)|");
            printESC.PROW(true, 1, "======================================================================================================");
            printESC.FontCondensed(false);
            printESC.Eject();

            printESC.SendToPrinter("RekapPenyelesianKirim.txt");
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dt = new DataTable();

                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                        db.Commands.Add(db.CreateCommand("rsp_PengirimanEkspedisi_RincianBiaya"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        PrintRawRincianBiaya(dt);
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
            else if (e.KeyCode == Keys.F4)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DataTable dt = new DataTable();

                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                        db.Commands.Add(db.CreateCommand("rsp_PenyelesianKirim_RekapPengirimanBarang"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        PrintRawRekapPengirimanBarang(dt);
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

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["KetPending"].Value.ToString() != "")
                {
                    for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Gray;
                    }
                }
                

            }
        }
    }
}
