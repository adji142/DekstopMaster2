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
using System.IO;

namespace ISA.Toko.Ekspedisi
{
    public partial class frmPackingListBrowse : ISA.Controls.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { PackingListSelected, DetailPackingListSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.PackingListSelected;
        DataTable dt = new DataTable();
        string PrnAktif = "0";
        string _jmlDO, _jmlSJ, _jmlKoli;

        public frmPackingListBrowse()
        {
            InitializeComponent();
        }

        private void frmPackingListBrowse_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            txtTgl.DateValue = DateTime.Now;
            dateTextBox1.DateValue = DateTime.Now;
        }
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataHeader();
        }

        private void rgbTgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataHeader(){
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    Console.WriteLine(txtNamaToko.Text);
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_TglSuratJalan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, dateTextBox1.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtTgl.DateValue));
                    if (!string.IsNullOrEmpty(txtNamaToko.Text))
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNamaToko.Text));
                    }
                    //db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTgl.FromDate));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTgl.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    
                        dataGridView1.DataSource = dt;
                    
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                    lblToko.Text = "\"" + dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" " + dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    lblToko.Text = " ";
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

                using (Database db = new Database())
                {
                    DataTable dtDetail = new DataTable();
                    Guid _headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_HeaderID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();

                    _jmlDO = dtDetail.Compute("SUM(QtyOrderDetail)", string.Empty).ToString();
                    _jmlSJ = dtDetail.Compute("SUM(QtySuratJalan)", string.Empty).ToString();
                    _jmlKoli = dtDetail.Compute("SUM(QtyKoli)", string.Empty).ToString();

                    dataGridView2.DataSource = dtDetail;
                }

                if (dataGridView2.SelectedCells.Count > 0)
                {
                    txtJDO.Text = _jmlDO;
                    txtSJ.Text = _jmlSJ;
                    txtKoli.Text = _jmlKoli;

                    lblNamaStok.Text = dataGridView2.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                }
                else
                {
                    txtJDO.Text = "";
                    txtSJ.Text = "";
                    txtKoli.Text = "";


                    lblNamaStok.Text = " ";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridView2.FindRow(columnName, value);
        }
        
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.PackingListSelected:
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        //if (dataGridView1.SelectedCells[0].OwningRow.Cells["Tgl"].Value.ToString() != "")
                        //{
                        //    MessageBox.Show("Nota sudah dibuat surat jalan");
                        //}
                        //else
                        //{
                            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            Ekspedisi.frmPackingListHeaderUpdate ifrmChild = new Ekspedisi.frmPackingListHeaderUpdate(this, rowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        //}
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    break;

                case enumSelectedGrid.DetailPackingListSelected:
                    if (dataGridView2.SelectedCells.Count > 0)
                    {
                        if (dataGridView1.SelectedCells[0].OwningRow.Cells["TglStrm"].Value.ToString() == "")
                        {
                            MessageBox.Show("Tanggal serah terima belum diisi,\n silahkan isi tanggal serah terima terlebih dahulu.");
                            return;
                        }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglStrm"].Value;
                            if ((DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglStrm"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            //if (dataGridView2.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString() != "")
                            //{
                            //    //MessageBox.Show("Sudah di ACC pusat");
                            //}
                            //else if (dataGridView2.SelectedCells[0].OwningRow.Cells["LinkID"].Value.ToString() != "")
                            //{
                            //    //MessageBox.Show("Sudah PJ3");
                            //}
                            //else
                            //{
                            Guid _rowID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                            //string NamaBarang = dataGridView2.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                            //Guid HeaderID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["HeaderIDD"].Value;
                            //Guid DODetailID = (Guid)dataGridView2.SelectedCells[0].OwningRow.Cells["DODetailIDD"].Value;
                            //string RecordID = dataGridView2.SelectedCells[0].OwningRow.Cells["RecordIDD"].Value.ToString();
                            //string HtrID = dataGridView2.SelectedCells[0].OwningRow.Cells["HtrIDD"].Value.ToString();
                            //string KodeGudang = dataGridView2.SelectedCells[0].OwningRow.Cells["KodeGudangD"].Value.ToString();
                            //string Catatan = dataGridView2.SelectedCells[0].OwningRow.Cells["CatatanD"].Value.ToString();
                            //int QtyNota = int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["QtyNota"].Value.ToString());
                            //string Satuan = dataGridView2.SelectedCells[0].OwningRow.Cells["Sat"].Value.ToString();
                            //int QtyDO = int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["JDO"].Value.ToString());
                            //int QtySJ = int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["JSJ"].Value.ToString());
                            //double HargaJual = double.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["Hjual"].Value.ToString());
                            //int QtyKoli = int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["JKoli"].Value.ToString());
                            //int KoliAwal = int.Parse(dataGridView2.SelectedCells[0].OwningRow.Cells["KoliAwal"].Value.ToString());
                            //string KetKoli = dataGridView2.SelectedCells[0].OwningRow.Cells["KetKoli"].Value.ToString();
                            //string Kelompok = dataGridView2.SelectedCells[0].OwningRow.Cells["Kel"].Value.ToString();

                            Ekspedisi.frmPackingListDetailUpdate ifrmChild2 = new Ekspedisi.frmPackingListDetailUpdate(this, _rowID);

                            //Ekspedisi.frmPackingListDetailUpdate ifrmChild2 = new Ekspedisi.frmPackingListDetailUpdate(this, _rowID, NamaBarang, 
                            //    HeaderID, DODetailID, RecordID, HtrID, KodeGudang,
                            //    Catatan, QtyNota, Satuan,  QtyDO, QtySJ, HargaJual,
                            //    QtyKoli, KoliAwal, KetKoli, Kelompok);

                            ifrmChild2.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild2);
                            ifrmChild2.Show();
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
                    break;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.PackingListSelected;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailPackingListSelected;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                lblNamaStok.Text = "\"" + dataGridView2.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString() + "\" ";
            }
            else
            {
                lblNamaStok.Text = " ";
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackingListBrowse_KeyDown(object sender, KeyEventArgs e)
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
                        string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        string expedisi = dataGridView1.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();
                       // DateTime tgl = DateTime.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells["TglSJ"].Value.ToString());
                        Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DateTime tgl0 = dateTextBox1.DateValue.Value;
                        DateTime tgl = txtTgl.DateValue.Value;
                        Ekspedisi.frmCetakPackingList ifrmChild = new Ekspedisi.frmCetakPackingList(this, kodeToko, expedisi,tgl0, tgl,rowID);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (!SecurityManager.IsAuditor())
                {
                    if (dataGridView1.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    frmCetakAmplop ifrmDialog = new frmCetakAmplop();
                    ifrmDialog.ShowDialog();
                    if (ifrmDialog.DialogResult == DialogResult.OK)
                    {
                        GetDialogResultCetakAmplop(ifrmDialog);
                    }
                }
            }
        }

        private void GetDialogResultCetakAmplop(frmCetakAmplop dialogForm)
        {
            string shift, bayar;
            shift = dialogForm.Shift;
            bayar = dialogForm.Bayar;

            string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
            string expedisi = dataGridView1.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString();
            DateTime tgl0 = dateTextBox1.DateValue.Value;
            DateTime tgl = txtTgl.DateValue.Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakPackingList"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, expedisi));
                    db.Commands[0].Parameters.Add(new Parameter("@date", SqlDbType.DateTime, tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@date0", SqlDbType.DateTime, tgl0));
                    db.Commands[0].Parameters.Add(new Parameter("@bayar", SqlDbType.VarChar, bayar));
                    db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, shift));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    CetakPackingListAmplop(dt);
                }
                else
                {
                    MessageBox.Show("Tidak ada data packing list");
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

        private void CetakPackingListAmplop(DataTable dt)
        {
            BuildString data = new BuildString();

            string sAlamat = dt.Rows[0]["Alamat"].ToString().Trim();
            string sJmlKoli = dt.Compute("SUM(JmlKoli)", string.Empty).ToString();

            data.Initialize();
            data.LetterQuality(true);
            data.FontCPI(10);
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, data.SPACE(2) + "JUMLAH KOLI : " 
                + sJmlKoli + " (" + Tools.Terbilang(int.Parse(sJmlKoli)).ToUpper() + ")" );
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, "");
            data.PROW(true, 1, dt.Rows[0]["NamaToko"].ToString().PadLeft(83));
            data.PROW(true, 1, data.SPACE(10) + dt.Rows[0]["Catatan3"].ToString().Trim());
            data.PROW(true, 1, sAlamat.PadLeft(83));
            data.PROW(true, 1, "");
            data.PROW(true, 1, dt.Rows[0]["Daerah"].ToString().PadLeft(83));
            data.PROW(true, 1, dt.Rows[0]["Kota"].ToString().PadLeft(83));
            data.Eject();

            data.SendToPrinter("amplop.txt", data.GenerateString());
        }

        private void DisplayReportAmplop(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptAmplopPackingList.rdlc", rptParams, dt, "dsNotaPenjualan_Data");
            ifrmReport.Show();
        }

        private void txtNamaToko_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataDetail();
                lblToko.Text = "\"" + dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" " + dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString() + " " + dataGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
            }
            else
            {
                lblToko.Text = " ";
            }
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
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "DokumenPackingList"));
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

            //if (PrnAktif == "0")
            //    cetakLaporan();
            //else

            DisplayReport(dt, "rptCetakPackingList");

            if(AppSetting.GetValue("DokumenPackingList")=="2"){
                DisplayReport(dt, "rptCetakPackingListCopy");
            }
            //switch (AppSetting.GetValue("DokumenPackingList"))
            //{
            //    case "2":
            //        DisplayReport(dt, "rptCetakPackingList");
            //        DisplayReport(dt, "rptCetakPackingListCopy");
            //        break;
            //}
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = true;
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {
            cmdPrint.Enabled = false;
        }

        private void DisplayReport(DataTable dt, String Nama)
        {
            try
            {

                string UserID = SecurityManager.UserName.ToString();
                double total = 0;
                string _Keterangan, _Mode;
                Guid _rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _Keterangan = dataGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value.ToString();
                _Mode = dataGridView1.SelectedCells[0].OwningRow.Cells["1"].Value.ToString();
                

                
                string _Terbilang = Tools.Terbilang(total);

                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", UserID + ", " + String.Format("{0:dd/MM/yyyy hh:mm:ss}", DateTime.Now)));
                rptParams.Add(new ReportParameter("Keterangan", _Keterangan));
                rptParams.Add(new ReportParameter("Mode", _Mode));
                rptParams.Add(new ReportParameter("Total", total.ToString()));

                frmReportViewer ifrmReport = new frmReportViewer("Fixrute.Expedisi." + Nama + ".rdlc", rptParams, dt, "dsNotaPenjualan_Data");
                ifrmReport.Print();
                ////ifrmReport.Print(8.5, 6.4);
                ////ifrmReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
