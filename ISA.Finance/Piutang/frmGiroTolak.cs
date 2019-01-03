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
    public partial class frmGiroTolak : ISA.Finance.BaseForm
    {
#region "Variable"
        DataTable dtHeader = new DataTable("GiroTolak");
        DataTable dtDetail = new DataTable("GiroTolakDetail");
        Double _RpDebet = 0;
        Double _RpKredit = 0;
        Double _RpSisa = 0;
        bool _random;

        int _PrevGrid1 = -1;
#endregion

#region "Procedure"
        #region "Load Data"
        public void RefreshGiroTolak(string KodeToko_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GiroTolak_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    if (comboBox1.SelectedIndex != 0)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, comboBox1.SelectedItem.ToString()));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "TglGiro DESC";
                dtHeader.Dispose();
                dtHeader = dt.DefaultView.ToTable().Copy();
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshGiroTolakDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value);
                }
                else
                {
                    dtDetail.Clear();
                    dataGridDetail.DataSource = dtDetail;
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

        public void RefreshGiroTolakDetail(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GiroTolakDetail_List]"));

                    //db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, KPID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {

                    dt.DefaultView.Sort = "TglBayar,RecordID ASC";
                    dtDetail.Dispose();
                    dtDetail = dt.DefaultView.ToTable().Copy();
                    dataGridDetail.DataSource = dtDetail;
                }
                else
                {
                    dtDetail.Clear();
                    dataGridDetail.DataSource = dtDetail;
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

        public void RefreshLabel()
        {
            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                _RpDebet = 0;
                _RpKredit = 0;
                if (dtHeader.Columns.Contains("Debet"))
                {
                    double.TryParse(dtHeader.Compute("SUM(Debet)","").ToString(), out _RpDebet);
                }

                if (dtHeader.Columns.Contains("Kredit"))
                {
                    double.TryParse(dtHeader.Compute("SUM(Kredit)", "").ToString(), out _RpKredit);
                }

                _RpSisa = _RpDebet - _RpKredit;
                //dataGridHeader.SelectedCells[0].OwningRow.Cells["Kredit"].Value = _RpKredit;
                //if (_random)
                //{
                //    label4.Text = (_RpDebet < 0) ? "-" + Tools.GetAntiNumeric((_RpDebet * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpDebet.ToString("#,##0"));
                //    label5.Text = (_RpKredit < 0) ? "-" + Tools.GetAntiNumeric((_RpKredit * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpKredit.ToString("#,##0"));
                //    label6.Text = (_RpSisa < 0) ? "-" + Tools.GetAntiNumeric((_RpSisa * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(_RpSisa.ToString("#,##0"));

                //}
                //else
                //{
                //    label4.Text = _RpDebet.ToString("#,##0");
                //    label5.Text = _RpKredit.ToString("#,##0");
                //    label6.Text = _RpSisa.ToString("#,##0");
                //}
            }
        }

        private void RandValue()
        {
            RefreshLabel();

            dataGridHeader.Columns["Debet"].Visible = !_random;
            dataGridHeader.Columns["Kredit"].Visible = !_random;
            dataGridHeader.Columns["DebetAck"].Visible = _random;
            dataGridHeader.Columns["KreditAck"].Visible = _random;

            dataGridDetail.Columns["KreditDetail"].Visible = !_random;
            dataGridDetail.Columns["KreditDetailAck"].Visible = _random;
        }

        private void EditUraian(string txt_)
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    //dataGridHeader.SelectedCells[0].OwningRow.Cells["KeteranganTagihan"].Value
                    string Date1_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGiro"].Value.ToString().Trim();
                    string Date2_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglJthGiro"].Value.ToString().Trim();
                    db.Commands.Add(db.CreateCommand("usp_GiroTolak_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Date1_.Equals("") ? SqlDateTime.Null : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglGiro"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJthGiro", SqlDbType.DateTime, Date2_.Equals("") ? SqlDateTime.Null : (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglJthGiro"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, txt_));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void FindGridDetail(string ColoumName_, string Value_)
        {
            dataGridDetail.FindRow(ColoumName_, Value_);
        }

        public void RefreshRowDataGridHeader(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroTolak_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
            }
        }

        public void RefreshRowDataGridDetail(Guid rowID_)
        {

            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_List"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID_));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                dataGridDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID_.ToString());
            }
        }

        #endregion

        #region "Print Out"
        private void RptGiroTolak(DataTable dt)
        {

            try
            {
                string periode;
                periode = String.Format("{0}", ((DateTime)DateTime.Now).ToString("dd-MMM-yyyy"));
                this.Cursor = Cursors.WaitCursor;
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NamaToko", lookupToko1.NamaToko+" "+lookupToko1.Alamat));
                rptParams.Add(new ReportParameter("WilID", "IdWil :"+lookupToko1.WilID + "  Plafon : Rp."+lookupToko1.Plafon.ToString("#,##0")));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptKPGiroTolak.rdlc", rptParams, dt, "dsKpiutang_Data");
                ifrmReport.Text = "kpBGT";
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
        #endregion
#endregion

        public frmGiroTolak()
        {
            InitializeComponent();
        }

        private void lookupToko1_Validated(object sender, EventArgs e)
        {
            if (lookupToko1.NamaToko.Trim().Equals(string.Empty))
            {
                lookupToko1.KodeToko = string.Empty;
            }
        }

        private void frmGiroTolak_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            _random = true;
            comboBox1.SelectedIndex = 1;
            lblKet.Text = "WilID : " + System.Environment.NewLine +
                         "Alamat : ";
            lookupToko1.Focus();
            RandValue();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookupToko1_SelectData(object sender, EventArgs e)
        {

            if (lookupToko1.KodeToko.ToString() != string.Empty && lookupToko1.KodeToko.ToString() != "[CODE]")
            {
                RefreshGiroTolak(lookupToko1.KodeToko);
                RandValue();
                lblKet.Text = "WilID : " + lookupToko1.WilID + System.Environment.NewLine +
                       "Alamat : " + lookupToko1.Alamat;
            }
            else
            {
                dtHeader.Clear();
                dtDetail.Clear();
                dataGridHeader.DataSource = dtHeader;
                dataGridDetail.DataSource = dtDetail;
            }
            
        }

        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].RowIndex != _PrevGrid1)
                {
                    RefreshGiroTolakDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value);
                    RefreshLabel();
                }
                 _PrevGrid1= dataGridHeader.SelectedCells[0].RowIndex;
            }
            else
            {
                _PrevGrid1 = -1;
            }

           
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {

        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dataGridHeader.RowCount > 0)
                {

                    double RpDebet_ = 0;
                    double RpKredit_ = 0;

                    if (dataGridHeader.Rows[e.RowIndex].Cells["Debet"].Value.ToString() != "")
                        RpDebet_ = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["Debet"].Value.ToString());

                    if (dataGridHeader.Rows[e.RowIndex].Cells["Kredit"].Value.ToString() != "")
                        RpKredit_ = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["Kredit"].Value.ToString());


                    dataGridHeader.Rows[e.RowIndex].Cells["DebetAck"].Value = (RpDebet_ < 0) ? "-" + Tools.GetAntiNumeric((RpDebet_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpDebet_.ToString("#,##0"));
                    dataGridHeader.Rows[e.RowIndex].Cells["KreditAck"].Value = (RpKredit_ < 0) ? "-" + Tools.GetAntiNumeric((RpKredit_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpKredit_.ToString("#,##0"));
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
                if (dataGridDetail.RowCount > 0)
                {
                    double RpKredit_ = 0;


                    if (dataGridDetail.Rows[e.RowIndex].Cells["KreditDetail"].Value.ToString() != "")
                        RpKredit_ = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["KreditDetail"].Value.ToString());

                    dataGridDetail.Rows[e.RowIndex].Cells["KreditDetailAck"].Value = (RpKredit_ < 0) ? "-" + Tools.GetAntiNumeric((RpKredit_ * (-1)).ToString("#,##0")) : Tools.GetAntiNumeric(RpKredit_.ToString("#,##0"));
                }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
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

                            Temp_ = Tools.isNull(dataGridHeader.SelectedCells[0].OwningRow.Cells["KetTagih"].Value, "").ToString();
                            val = Interaction.InputBox("Keterangan Tagihan : ", "Edit Ket. Tagihan", Temp_, 20, 20);

                            if (val.Trim() != Temp_.Trim())
                            {
                                EditUraian(val);
                                dataGridHeader.SelectedCells[0].OwningRow.Cells["KetTagih"].Value = val;
                                dataGridHeader.RefreshEdit();
                            }
                        }
                        break;
                    case Keys.F9:
                        _random = !_random;
                        RandValue();
                        break;
                    case Keys.F8:
                        {
                            try
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable dt = new DataTable();
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("[rsp_GiroTolak_BGT]"));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, lookupToko1.KodeToko));
                                    dt = db.Commands[0].ExecuteDataTable();
                                }
                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show("No Data");
                                    return;
                                }
                                RptGiroTolak(dt);

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
                        break;
                }
            }

        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.RowCount > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        {
                            Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            string RecordID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                            string NoTransaksi_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoBG"].Value.ToString();
                            double a_ = Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["Debet"].Value);
                            double b_ = Convert.ToDouble(dataGridHeader.SelectedCells[0].OwningRow.Cells["Kredit"].Value);
                            Piutang.frmGiroTolakDetailUpdate ifrmChild = new Piutang.frmGiroTolakDetailUpdate(this,RowID_,RecordID_,(a_-b_),lookupToko1.KodeToko,NoTransaksi_);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lookupToko1.KodeToko.ToString() != string.Empty && lookupToko1.KodeToko.ToString() != "[CODE]")
            {
                RefreshGiroTolak(lookupToko1.KodeToko);
                lblKet.Text = "WilID : " + lookupToko1.WilID + System.Environment.NewLine +
                          "Alamat : " + lookupToko1.Alamat;
                RandValue();
            }
            else
            {
                dtHeader.Clear();
                dtDetail.Clear();
                dataGridHeader.DataSource = dtHeader;
                dataGridDetail.DataSource = dtDetail;
            }
            
        }
    }
}
