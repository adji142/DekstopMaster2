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
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.Piutang
{
    public partial class frmKartuPiutangBrowse : ISA.Finance.BaseForm
    {
#region "Variable"
        enum enumSelectedGrid { dgKpiutangSelected, dgKPiutangDetailSelected };
        DataTable dtKPiutang = new DataTable();
        DataTable dtKpiutangDetail = new DataTable();
        Guid _kpRowID;
        string _KodeToko = string.Empty;
        string _KPID = string.Empty;
        double _RpSisa = 0;
        double _RpKredit = 0;
        double _RpDebet = 0;
        int _prefGrid1Row = -1;
        int _prefGrid2Row = -1;
        bool _random;

     

#endregion

#region "LoadData"

        public void RefreshKPiutang(string KodeToko_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt1 = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KartuPiutang_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    if (comboBox1.SelectedIndex!=0)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, comboBox1.SelectedItem.ToString()));
                    }
                    dt1 = db.Commands[0].ExecuteDataTable();
                }
                dt1.DefaultView.Sort = "TglTransaksi DESC";
                dtKPiutang.Dispose();
                dtKPiutang = dt1.DefaultView.ToTable().Copy();
                dataGridHeader.DataSource = dtKPiutang;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    _kpRowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    RefreshKPiutangDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KPID"].Value.ToString(), (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value);
                }
                else
                {
                    dtKpiutangDetail.Clear();
                    dataGridDetail.DataSource = dtKpiutangDetail;
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

        public void RefreshKPiutangDetail(string KPID_,Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt2 = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_List"));

                    //db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, KPID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                    dt2 = db.Commands[0].ExecuteDataTable();
                }
                if (dt2.Rows.Count > 0)
                {
                    dt2.DefaultView.Sort = "TglTransaksi,RecordID ASC";
                    dtKpiutangDetail = dt2.DefaultView.ToTable().Copy();
                    dataGridDetail.DataSource = dtKpiutangDetail;
                }
                else
                {
                    dataGridDetail.DataSource = null;
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

        private void EditUraianKpiutang(string txt_)
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    //dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value
                    string Date1_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglJatuhTempo"].Value.ToString().Trim();

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutang_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTransaksi"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, Date1_.Equals("")? SqlDateTime.Null : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglJatuhTempo"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@KeteranganTagih", SqlDbType.VarChar, txt_));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                   
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
#endregion

#region "PrintOut"
        private void PrintRekapPerBulan(DataTable dt)
        {
            try
            {
                BuildString data = new BuildString();
              

                data.AddCR();
                data.PROW(true, 1, "Kartu Piutang " + lookupToko1.NamaToko.Trim() + " " + lookupToko1.Alamat.Trim() + " " + lookupToko1.Kota.Trim());
                data.PROW(true, 1, "              " + "Id.Wil: " + lookupToko1.WilID + " Plafon : Rp." + lookupToko1.Plafon.ToString("#,##0"));
                data.PROW(true, 1, "");
                data.PROW(true, 1, "  Bulan            Penjualan      Pembayaran     Retur/Tarikan     Lain-lain  ");
                data.PROW(true, 1, "============================================================================= ");
                string bulan = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                   

                    data.PROW(true, 1,
                                Tools.Left(dr["TglTransaksi"].ToString(), 10) + " " +
                                Tools.Left(dr["Combine"].ToString(), 4) + " " +
                                double.Parse(dr["RpJual"].ToString()).ToString("#,##0") + " " +
                                double.Parse(dr["Rpbayar"].ToString()).ToString("#,##0") + " " +
                                double.Parse(dr["RpRetur"].ToString()).ToString("#,##0") + " " +
                                double.Parse(dr["RpLain"].ToString()).ToString("#,##0") + " "
                               );
                }
                data.PROW(true, 1, "============================================================================= ");
                data.PROW(true, 1, "                " +
                               double.Parse(dt.Compute("SUM(RpJual)", string.Empty).ToString()).ToString("#,##0") + " " +
                               double.Parse(dt.Compute("SUM(Rpbayar)", string.Empty).ToString()).ToString("#,##0") + " " +
                               double.Parse(dt.Compute("SUM(RpRetur)", string.Empty).ToString()).ToString("#,##0") + " " +
                               double.Parse(dt.Compute("SUM(RpLain)", string.Empty).ToString()).ToString("#,##0") + " "
                              );
                data.Eject();
                data.SendToPrinter("show.txt", data.GenerateString());
                Process.Start(Properties.Settings.Default.OutputFile + "\\" + "show.txt");
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            
          


        }

        private void RptRekapPerBulan(DataTable dt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko + " " + lookupToko1.Alamat + " " + lookupToko1.Kota));
                rptParams.Add(new ReportParameter("WilID", " " + lookupToko1.WilID + " Plafon : " + lookupToko1.Plafon.ToString("#,##0")));

                frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptRekapPerBulan.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = "Rekap PerBulan";
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

        private void RptRekapPerSales(DataTable dt)
        {
            //construct parameter
            //string periode;
            //periode = String.Format("{0} s/d {1}", ((DateTime)rdbTglDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rdbTglDO.ToDate).ToString("dd/MM/yyyy"));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko + " " + lookupToko1.Alamat + " " + lookupToko1.Kota));
                rptParams.Add(new ReportParameter("WilID", " " + lookupToko1.WilID + " Plafon : " + lookupToko1.Plafon.ToString("#,##0")));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptRekapPerSales.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = "Rekap PerSales";
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

        private void RptKonfirmasiToko(DataSet dt)
        {
           
            try
            {
                string periode;
                periode = String.Format("{0}", ((DateTime)DateTime.Now).ToString("dd-MMM-yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko));
                rptParams.Add(new ReportParameter("Alamat",lookupToko1.Alamat));
                rptParams.Add(new ReportParameter("Kota", lookupToko1.Kota));
                rptParams.Add(new ReportParameter("Periode", periode));


                //call report viewer
                if (dt.Tables[0].Rows.Count > 0)
                {
                     frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptKonfirmasiToko.rdlc", rptParams, dt.Tables[0], "dsKpiutang_Data");
                ifrmReport.Text = "Konfirmasi Toko(Piutang)";
                ifrmReport.Show();
                }
               

                if (dt.Tables[1].Rows.Count>0)
                {
                    frmReportViewer ifrmReport2 = new frmReportViewer("Piutang.rptKonfirmasiToko-giro.rdlc", rptParams, dt.Tables[1], "dsKpiutang_Data");
                    ifrmReport2.Text = "Konfirmasi Toko(Giro Tolak)";
                    ifrmReport2.Show();
                }

                if (dt.Tables[2].Rows.Count > 0)
                {
                    frmReportViewer ifrmReport3 = new frmReportViewer("Piutang.rptKonfirmasiToko-girojalan.rdlc", rptParams, dt.Tables[2], "dsKpiutang_Data");
                    ifrmReport3.Text = "Konfirmasi Toko(Giro Berjalan)";
                    ifrmReport3.Show();
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

        private void RptRekapPembayaran(DataSet ds, double plafon)
        {
           
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko));
            rptParams.Add(new ReportParameter("WilID", ds.Tables[6].Rows[0]["WilID"].ToString()));
            rptParams.Add(new ReportParameter("Alamat", ds.Tables[6].Rows[0]["Alamat"].ToString()));
            rptParams.Add(new ReportParameter("Catatan", ds.Tables[6].Rows[0]["Catatan"].ToString()));
            rptParams.Add(new ReportParameter("Grade", ds.Tables[6].Rows[0]["Grade"].ToString()));
            rptParams.Add(new ReportParameter("Kota", ds.Tables[6].Rows[0]["Kota"].ToString()+", " + ds.Tables[6].Rows[0]["Daerah"].ToString()));
            rptParams.Add(new ReportParameter("Plafon",lookupToko1.Plafon.ToString("#,##0")));
            rptParams.Add(new ReportParameter("UserName", SecurityManager.UserName));
            rptParams.Add(new ReportParameter("JKW", ds.Tables[5].Rows[0][0].ToString()));
            rptParams.Add(new ReportParameter("NoTelp", ds.Tables[6].Rows[0]["Telp"].ToString()));
            rptParams.Add(new ReportParameter("Pemilik", ds.Tables[6].Rows[0]["PenanggungJawab"].ToString()));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);
            pTable.Add(ds.Tables[3]);
            pTable.Add(ds.Tables[4]);
          

            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsKpiutang_Data");
            pDatasetName.Add("dsKpiutang_Data1");
            pDatasetName.Add("dsKpiutang_Data2");
            pDatasetName.Add("dsKpiutang_Data3");
            pDatasetName.Add("dsKpiutang_Data4");

            frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptRekapPembayaran.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Text = "SaldoKu";
            ifrmReport.Show();
            //ifrmReport.ExportToExcel("RekapPembayaranToko " + lookupToko1.NamaToko);
        }
#endregion

#region "Procedure"

        private void RefreshLabel()
        {
            if (dtKpiutangDetail != null && dtKpiutangDetail.Rows.Count > 0)
            {
                if (dtKpiutangDetail.Compute("SUM(RpJual)", string.Empty).ToString().Equals(string.Empty))
                {
                    _RpDebet = 0;
                }
                else
                {
                    _RpDebet = Convert.ToDouble(dtKpiutangDetail.Compute("SUM(RpJual)", string.Empty).ToString());

                }

                if (dtKpiutangDetail.Compute("SUM(RpKredit)", string.Empty).ToString().Equals(string.Empty))
                {
                    _RpKredit = 0;
                }
                else
                {
                    _RpKredit = Convert.ToDouble(dtKpiutangDetail.Compute("SUM(RpKredit)", string.Empty).ToString());
                }

                _RpSisa = _RpDebet - _RpKredit;

                if (_random)
                {
                    label4.Text = (_RpDebet < 0) ? "-" + Tools.GetAntiNumeric((_RpDebet * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpDebet.ToString("#,##0"));
                    label5.Text = (_RpKredit < 0) ? "-" + Tools.GetAntiNumeric((_RpKredit * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpKredit.ToString("#,##0"));
                    label6.Text = (_RpSisa < 0) ? "-" + Tools.GetAntiNumeric((_RpSisa * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpSisa.ToString("#,##0"));

                }
                else
                {
                    label4.Text = _RpDebet.ToString("#,##0");
                    label5.Text = _RpKredit.ToString("#,##0");
                    label6.Text = _RpSisa.ToString("#,##0");
                }
            }
        }

        private void RandValue()
        {
            RefreshLabel();

            dataGridHeader.Columns["RpJual"].Visible = !_random;
            dataGridHeader.Columns["RpKredit"].Visible = !_random;
            dataGridHeader.Columns["RpSisa"].Visible = !_random;
            dataGridHeader.Columns["RpJualAck"].Visible = _random;
            dataGridHeader.Columns["RpKreditAck"].Visible = _random;
            dataGridHeader.Columns["RpSisaAck"].Visible = _random;

            dataGridDetail.Columns["Kredit"].Visible = !_random;
            dataGridDetail.Columns["Debet"].Visible = !_random;
            dataGridDetail.Columns["KreditAck"].Visible = _random;
            dataGridDetail.Columns["DebetAck"].Visible = _random;
        }

        private void RefreshDataGridDetail()
        {

        }

        public void RefreshGridHeader()
        {
            int index = dataGridHeader.SelectedCells[0].OwningRow.Index;
            RefreshLabel();
            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpJual"].Value = _RpDebet;
            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpKredit"].Value = _RpKredit;
            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpSisa"].Value = _RpSisa;

            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpJualAck"].Value = (_RpDebet < 0) ? "-" + Tools.GetAntiNumeric((_RpDebet * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpDebet.ToString("#,##0"));
            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpKreditAck"].Value = (_RpKredit < 0) ? "-" + Tools.GetAntiNumeric((_RpKredit * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpKredit.ToString("#,##0"));
            dataGridHeader.SelectedCells[0].OwningRow.Cells["RpSisaAck"].Value = (_RpSisa < 0) ? "-" + Tools.GetAntiNumeric((_RpSisa * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpSisa.ToString("#,##0"));

            this.dataGridDetail.RefreshEdit();

        }

        public void FindGridHeader(string ColoumName_, string Value_)
        {
            dataGridHeader.FindRow(ColoumName_, Value_);
        }

        public void FindGridDetail(string ColoumName_, string Value_)
        {
            dataGridDetail.FindRow(ColoumName_, Value_);
        }

        public void RefreshRowData(Guid rowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KartuPiutang_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
            }
        }
        
        public void RefreshRowDataDetail(Guid rowID_)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
            }
        }
#endregion
      
        public frmKartuPiutangBrowse()
        {
            InitializeComponent();
        }

        private void frmKartuPiutangBrowse_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lookupToko1.Focus();
            _random = true;
            comboBox1.SelectedIndex = 1;
            label4.Text = "D";
            label5.Text = "D";
            label6.Text = "D";
            lblWilID.Text = string.Empty;
            lblPasif.Text = string.Empty;
            RandValue();
            if (SecurityManager.UserID == "PSHO") {
                commandButton2.Visible = true;
            }
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {
            if (lookupToko1.KodeToko.ToString() != string.Empty && lookupToko1.KodeToko.ToString() != "[CODE]")
            {
                linkAlamat.Text = lookupToko1.Alamat;
                lblWilID.Text = lookupToko1.WilID;
                txtTelp.Text = lookupToko1.Telp;
                RefreshKPiutang(lookupToko1.KodeToko);
                RandValue();
                RefreshPiutangSales(lookupToko1.KodeToko);
                lblmitra.Text = refreshMitra();
            }
            else
            {
                dtKPiutang.Clear();
                dtKpiutangDetail.Clear();

                dataGridHeader.DataSource = dtKPiutang;
                dataGridDetail.DataSource = dtKpiutangDetail;
            }

            if (lookupToko1.KodeToko!="")
            {
                if (lookupToko1.Pasif)
                {
                    lblPasif.Text = "Toko Pasif";
                }
                else
                {
                    lblPasif.Text = "Toko Aktif";
                }
            }else
            {
                lblPasif.Text = "";
            }
           
        }
        private string refreshMitra() {
            string ret = "";
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_GetTokoMitraDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    ret = "BENGKEL MITRA";
                }
                else
                {
                    ret = "";
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            return ret;
        }
        private void linkAlamat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lookupToko1.KodeToko != "")
            {
                Piutang.frmKartuPiutangNoteTokoUpdate ifrmChild = new Piutang.frmKartuPiutangNoteTokoUpdate(this,lookupToko1.KodeToko);
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();

            }
        }

        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridHeader.SelectedCells.Count > 0)
            {
              
                if (dataGridHeader.SelectedCells[0].RowIndex != _prefGrid1Row)
                {
                    if ((int)dataGridHeader.SelectedCells[0].OwningRow.Cells["Cicil"].Value == 0)
                    {
                        btnInfoCicil.Visible = false;
                    }
                    else
                    {
                        btnInfoCicil.Visible = true;
                    }

                    RefreshKPiutangDetail(dataGridHeader.SelectedCells[0].OwningRow.Cells["KPID"].Value.ToString(), (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value);
                    RefreshLabel();
                }
                _prefGrid1Row = dataGridHeader.SelectedCells[0].RowIndex;
            }
            else
            {
                _prefGrid1Row = -1;
            }

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            string val = string.Empty;
                            string Temp_ = "";

                            Temp_ = Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value,"").ToString();
                            val = Interaction.InputBox("Keterangan Tagihan : ", "Edit Ket. Tagihan", Temp_, 20,20);

                            if (val.Trim()!=Temp_.Trim())
                            {
                                EditUraianKpiutang(val);
                                dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value = val;
                                dataGridHeader.RefreshEdit();
                            }
                        }
                        break;
                    //case Keys.F9:
                    //    _random = !_random;
                    //    RandValue();
                    //    break;
                    case Keys.F8:
                        cmdRptSemuaSales.PerformClick();
                        break;
                    case Keys.F11:
                        cmdRptRekapPerBulan.PerformClick();
                        break;
                    case Keys.F12:
                        cmdRptInfoToko.PerformClick();
                        break;
                }
            }

        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridDetail.RowCount > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        {
                            _KPID = dataGridHeader.SelectedCells[0].OwningRow.Cells["KPID"].Value.ToString();
                            _RpSisa = Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["RpSisa"].Value);
                            Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string NoTransaksi_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoTransaksi"].Value.ToString();
                            Piutang.frmKartuPiutangDetailUpdate ifrmChild = new Piutang.frmKartuPiutangDetailUpdate(this,_KPID ,lookupToko1.KodeToko,_RpSisa,RowID_,NoTransaksi_);
                            ifrmChild.WindowState = FormWindowState.Normal;
                            ifrmChild.ShowDialog();
                        }
                        break;
                    case Keys.F9:
                        _random = !_random;
                        RandValue();
                        break;
                }
            }
        }

        private void cmdRptRekapPerBulan_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.RowCount>0)
            {
                try
                {
                    panelLapF11NewLap.BringToFront();
                    panelLapF11NewLap.Visible = true;

                    txtMYBPeriodeAwalLapF11Awal.Month = GlobalVar.DateOfServer.Month;
                    txtMYBPeriodeAwalLapF11Awal.Year = GlobalVar.DateOfServer.Year;

                    txtMYBLapF11Akhir.Month = GlobalVar.DateOfServer.Month;
                    txtMYBLapF11Akhir.Year = GlobalVar.DateOfServer.Year;

                    txtMYBLapF11Akhir.Enabled = false;


                    //DataTable dt = new DataTable();
                    //using (Database db = new Database(GlobalVar.DBName))
                    //{
                    //    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_RekapPerBulan"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    //    dt = db.Commands[0].ExecuteDataTable();
                    //}
                    ////PrintRekapPerBulan(dt);
                    //RptRekapPerBulan(dt);
                   
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dataGridHeader.RowCount>0)
                {
               
                double RpDebet_ = 0;
                double RpKredit_ = 0;
                double RpSisa_ = 0;

                if (dataGridHeader.Rows[e.RowIndex].Cells["RpJual"].Value.ToString() != "")
                    RpDebet_ = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpJual"].Value.ToString());

                if (dataGridHeader.Rows[e.RowIndex].Cells["RpKredit"].Value.ToString() != "")
                    RpKredit_ = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpKredit"].Value.ToString());

                RpSisa_ = RpDebet_ - RpKredit_;

                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridHeader.Rows[e.RowIndex].Cells["tglprr"].Value.ToString() == "" ? Color.White : Color.Silver;
                dataGridHeader.Rows[e.RowIndex].Cells["RpJualAck"].Value = (RpDebet_ < 0) ? "-" + Tools.GetAntiNumeric((RpDebet_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpDebet_.ToString("#,##0"));
                dataGridHeader.Rows[e.RowIndex].Cells["RpKreditAck"].Value = (RpKredit_ < 0) ? "-" + Tools.GetAntiNumeric((RpKredit_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpKredit_.ToString("#,##0"));
                dataGridHeader.Rows[e.RowIndex].Cells["RpSisaAck"].Value = (RpSisa_ < 0) ? "-" + Tools.GetAntiNumeric((RpSisa_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpSisa_.ToString("#,##0"));
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dataGridDetail.RowCount>0)
                {
                    double RpDebet_ = 0;
                    double RpKredit_ = 0;

                    if (dataGridDetail.Rows[e.RowIndex].Cells["Debet"].Value.ToString() != "")
                        RpDebet_ = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["Debet"].Value.ToString());

                    if (dataGridDetail.Rows[e.RowIndex].Cells["Kredit"].Value.ToString() != "")
                        RpKredit_ = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["Kredit"].Value.ToString());

                    dataGridDetail.Rows[e.RowIndex].Cells["DebetAck"].Value = (RpDebet_ < 0) ? "-" + Tools.GetAntiNumeric((RpDebet_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpDebet_.ToString("#,##0"));
                    dataGridDetail.Rows[e.RowIndex].Cells["KreditAck"].Value = (RpKredit_ < 0) ? "-" + Tools.GetAntiNumeric((RpKredit_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpKredit_.ToString("#,##0"));
                }
               
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
           
        }

        private void cmdRptSemuaSales_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_RekapPerSales"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count==0)
                    {
                        return;
                    }
                    RptRekapPerSales(dt);

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet dt = new DataSet();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_KartuPiutang_KonfirmasiToko]"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        dt = db.Commands[0].ExecuteDataSet();
                    }
                    if (dt.Tables[0].Rows.Count == 0 && dt.Tables[1].Rows.Count==0 && dt.Tables[2].Rows.Count==0)
                    {
                        MessageBox.Show("Toko ini sudah tidak ada saldo piutang");
                        return;
                    }
                    RptKonfirmasiToko(dt);

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdRptInfoToko_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_RekapPembayaran"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        ds = db.Commands[0].ExecuteDataSet();
                    }
                    using (Database db = new Database())
                    {                        
                        db.Commands.Add(db.CreateCommand("fsp_GetLastPlafon"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    double plafon = 0;
                    if (dt.Rows.Count > 0)
                    {
                        double.TryParse(dt.Rows[0]["PlafonAkhir"].ToString(), out plafon);
                    }

                    if (ds.Tables.Count==0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }
                    RptRekapPembayaran(ds,plafon);

                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void frmKartuPiutangBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.F9:
                        _random = !_random;
                        RandValue();
                        break;
                    case Keys.F8:
                        cmdRptSemuaSales.PerformClick();
                        break;
                    case Keys.F11:
                        cmdRptRekapPerBulan.PerformClick();
                        break;
                    case Keys.F12:
                        cmdRptInfoToko.PerformClick();
                        break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lookupToko1.KodeToko!="")
            {
                if (lookupToko1.KodeToko.ToString() != string.Empty && lookupToko1.KodeToko.ToString() != "[CODE]")
                {
                    linkAlamat.Text = lookupToko1.Alamat;
                    lblWilID.Text = lookupToko1.WilID;
                    RefreshKPiutang(lookupToko1.KodeToko);
                    RandValue();
                }
                else
                {
                    dtKPiutang.Clear();
                    dtKpiutangDetail.Clear();

                    dataGridHeader.DataSource = dtKPiutang;
                    dataGridDetail.DataSource = dtKpiutangDetail;
                }
            }
        }

        private void btnInfoCicil_Click(object sender, EventArgs e)
        {
            
            NotaCicilView ifrmChild = new NotaCicilView(this, _kpRowID);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
            ifrmChild.ShowDialog();
        }

        private void lookupToko1_Load(object sender, EventArgs e)
        {

        }

        public void RefreshPiutangSales(string KodeToko_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtSales = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetPiutangSales]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));

                    dtSales = db.Commands[0].ExecuteDataTable();
                }
                dtSales.DefaultView.Sort = "KodeSales";

                datagridSales.DataSource = dtSales;
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

        private void cmdProsesLapF11New_Click(object sender, EventArgs e)
        {
            panelLapF11NewLap.SendToBack();
            panelLapF11NewLap.Visible = false;
            ProsesLaporanF11New();
        }

        private void cmdClosePanelF11_Click(object sender, EventArgs e)
        {
            panelLapF11NewLap.SendToBack();
            panelLapF11NewLap.Visible = false;
        }
        private void ProsesLaporanF11New()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_LaporanPiutangF11"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, txtMYBPeriodeAwalLapF11Awal.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, txtMYBLapF11Akhir.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                RptReportF11New(ds);

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void RptReportF11New(DataSet ds)
        {
            this.Cursor = Cursors.WaitCursor;

            string _periodeF11 = "Periode : " + txtMYBPeriodeAwalLapF11Awal.MonthName + " " + txtMYBPeriodeAwalLapF11Awal.Year + " s/d " + txtMYBLapF11Akhir.MonthName + " " + txtMYBLapF11Akhir.Year;
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaToko", "Nama Toko : " + lookupToko1.NamaToko + " " + lookupToko1.Alamat + " " + lookupToko1.Kota));
            rptParams.Add(new ReportParameter("WilID", "WilID :  " + lookupToko1.WilID));
            rptParams.Add(new ReportParameter("Periode", _periodeF11));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);

            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsLapKartuPiutang_Detail");
            pDatasetName.Add("dsLapKartuPiutang_Rekap");

            frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptLaporanKPF11New.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Text = "Rekap PerBulan";
            ifrmReport.Show();
            //ifrmReport.ExportToExcel("RekapPembayaranToko " + lookupToko1.NamaToko);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridHeader.SelectedCells.Count > 0) {
                    Guid RowID = new Guid(dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                    bool TglKosong = dataGridHeader.SelectedCells[0].OwningRow.Cells["tglprr"].Value.ToString() == "";
                    if (Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["RpSisa"].Value) < 1 && TglKosong)
                    {
                        MessageBox.Show("sisa piutang lebih kecil dari Rp 1, Tidak bisa di jadikan PRR");
                        return;
                    }
                    if (!TglKosong)
                    {
                        if (MessageBox.Show("Apakah Prr Ingin di hapus ? ", "Question", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                        if (SecurityManager.UserID != "PSHO") return;
                    }
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_KartuPiutang_UpdatePrr"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.Bit, TglKosong));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    if (TglKosong)
                    {
                        MessageBox.Show(String.Format(" Nota No. {0} \n Tanggal transaksi: {1:dd-MM-yyyy} \n Rp sisa {2:N0} \n Telah berhasil dicatat sebagai Piutang Ragu-ragu",
                        dataGridHeader.SelectedCells[0].OwningRow.Cells["NoTransaksi"].Value.ToString(),
                        Convert.ToDateTime(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglJatuhTempo"].Value),
                        Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["RpSisa"].Value)
                        ), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    RefreshKPiutang(lookupToko1.KodeToko);
                    dataGridHeader.FindRow("RowID", RowID.ToString());
                }
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }
    }
}
