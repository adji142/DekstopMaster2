using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.GL
{
    public partial class frmJournalUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _recID;
        string _src;

        DataTable dtRowHeader;
        DataTable dtRowDetail;
        DataTable dtRowDetailAwal;
        DataTable dtDeleteee;

        public frmJournalUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _rowID = Guid.NewGuid();
            _recID = ISA.Common.Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);            
            this.Caller = caller;
        }

        public frmJournalUpdate(Form caller, Guid rowID, string recID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _recID = recID;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void frmJournalUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    dtRowHeader = Class.Journal.GetHeader(db, _rowID);
                    dtRowDetail = Class.Journal.ListDetail(db, _rowID);
                    dtRowDetailAwal = dtRowDetail.Copy();
                    dtDeleteee = new DataTable();
                    dtDeleteee = dtRowDetail.Clone();
                    //dtDeleteee.Clear();
                }
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    if (dtRowHeader.Rows.Count > 0)
                    {

                        //display data
                        txtTanggal.Text = ((DateTime)dtRowHeader.Rows[0]["Tanggal"]).ToString("dd/MM/yyyy");
                        txtNoReff.Text = dtRowHeader.Rows[0]["NoReff"].ToString();
                        txtUraian.Text = dtRowHeader.Rows[0]["Uraian"].ToString();
                        _src = dtRowHeader.Rows[0]["Src"].ToString(); ;
                        lookupGudang1.GudangID = dtRowHeader.Rows[0]["KodeGudang"].ToString();
                        dtRowDetail.DefaultView.Sort = "DK, RecordID, NoPerkiraan";
                        customGridView1.DataSource = dtRowDetail.DefaultView;
                    }
                }
                else
                {
                    txtTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtNoReff.Text = Numerator.GetNextNumerator("ADJ");
                    lookupGudang1.GudangID = GlobalVar.Gudang;
                    _src = "GNR";
                    dtRowDetail.DefaultView.Sort = "RecordID";
                    customGridView1.DataSource = dtRowDetail.DefaultView;
                }
                HitungTotal();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dtRowDetail.Rows.Count > 0 && txtSelisih.GetDoubleValue == 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.BeginTransaction();
                                Class.Journal.AddHeader(db, _rowID, _recID, (DateTime)txtTanggal.DateValue, Numerator.BookNumerator("ADJ"), txtUraian.Text, _src, lookupGudang1.GudangID, false);
                                foreach (DataRow drDetail in dtRowDetail.Rows)
                                {
                                    //Guid dJournalID = Guid.NewGuid();
                                    //string journalRecID = ISA.Common.Tools.CreateFingerPrint (GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                                    Class.Journal.AddDetail(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString());
                                }
                                db.CommitTransaction();
                                dtRowDetail.AcceptChanges();
                                formMode = enumFormMode.Update;
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.BeginTransaction();
                                Class.Journal.UpdateHeader(db, _rowID, _recID, (DateTime)txtTanggal.DateValue, txtNoReff.Text, txtUraian.Text, _src, lookupGudang1.GudangID, false);

                                DataTable dtInsert, dtUpdate, dtDelete;
                                dtInsert = dtRowDetail.GetChanges(DataRowState.Added);
                                dtUpdate = dtRowDetail.GetChanges(DataRowState.Modified);
                                //dtDelete =  dtRowDetail.GetChanges(DataRowState.Deleted);

                                if (dtDeleteee.Rows.Count > 0)
                                {
                                    foreach (DataRow drDetail in dtDeleteee.Rows)
                                    {
                                        Class.Journal.DeleteDetail(db, (Guid)drDetail["RowID"]);
                                    }
                                }

                                if (dtInsert != null)
                                {
                                    foreach (DataRow drDetail in dtInsert.Rows)
                                    {
                                        Class.Journal.AddDetail(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString());
                                    }
                                }

                                if (dtUpdate != null)
                                {
                                    foreach (DataRow drDetail in dtUpdate.Rows)
                                    {
                                        Class.Journal.UpdateDetail(db, (Guid)drDetail["RowID"], (Guid)drDetail["HeaderID"], drDetail["RecordID"].ToString(), drDetail["HRecordID"].ToString(), drDetail["NoPerkiraan"].ToString(), drDetail["Uraian"].ToString(), double.Parse(drDetail["Debet"].ToString()), double.Parse(drDetail["Kredit"].ToString()), drDetail["DK"].ToString());
                                    }
                                }


                                db.CommitTransaction();
                                dtRowDetail.AcceptChanges();
                            }
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show(ISA.Common.Messages.Confirm.UpdateSuccess);
                    this.Close();
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
                MessageBox.Show("Debet-Kredit masih belum balance");
            }
        }

        

        
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            double debet = 0;
            double kredit = 0;
            double.TryParse( dtRowDetail.Compute ("SUM(Debet)","").ToString(), out debet);
            double.TryParse( dtRowDetail.Compute("SUM(Kredit)","").ToString() ,out kredit);
            double selisih = debet - kredit;
            if (selisih >= 0)
            {
                debet = 0;
                kredit = selisih;
            }
            else
            {
                debet = Math.Abs(selisih);
                kredit =0;
            }

            GL.frmJournalDetailUpdate ifrmChild = new GL.frmJournalDetailUpdate();
            ifrmChild.Uraian = txtUraian.Text;
            ifrmChild.Debet = debet;
            ifrmChild.Kredit = kredit;
            ifrmChild.ShowDialog();

            if (ifrmChild.DialogResult == DialogResult.Yes)
            {
                DataRow dr = dtRowDetail.NewRow();
                dr["RowID"] = Guid.NewGuid();
                dr["HeaderID"] = (Guid)_rowID;
                dr["RecordID"] = ISA.Common.Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                dr["HRecordID"] = _recID;
                dr["NoPerkiraan"] = ifrmChild.NoPerkiraan;
                dr["NamaPerkiraan"] = ifrmChild.NamaPerkiraan;
                dr["Uraian"] = ifrmChild.Uraian;
                dr["DK"] = ifrmChild.DK;
                dr["Debet"] = ifrmChild.Debet;
                dr["Kredit"] = ifrmChild.Kredit;
                dtRowDetail.Rows.Add(dr);

                HitungTotal();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                
                DataRow drDel = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                int index = customGridView1.SelectedCells[0].OwningRow.Index;
                dtDeleteee.Rows.Add((Guid)dtRowDetail.DefaultView[index][0]);
                drDel.Delete();
                
                
                dtDeleteee.AcceptChanges();
                HitungTotal();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                DataRow dr = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                GL.frmJournalDetailUpdate ifrmChild = new GL.frmJournalDetailUpdate();
                ifrmChild.NoPerkiraan = dr["NoPerkiraan"].ToString();
                ifrmChild.NamaPerkiraan = dr["NamaPerkiraan"].ToString();
                ifrmChild.Uraian = dr["Uraian"].ToString();
                ifrmChild.Debet = double.Parse(dr["Debet"].ToString());
                ifrmChild.Kredit = double.Parse(dr["Kredit"].ToString());
                ifrmChild.ShowDialog();
                if (ifrmChild.DialogResult == DialogResult.Yes)
                {
                    dr["NoPerkiraan"] = ifrmChild.NoPerkiraan;
                    dr["NamaPerkiraan"] = ifrmChild.NamaPerkiraan;
                    dr["Uraian"] = ifrmChild.Uraian;
                    dr["DK"] = ifrmChild.DK;
                    dr["Debet"] = ifrmChild.Debet;
                    dr["Kredit"] = ifrmChild.Kredit;
                    
                    HitungTotal();
                }
            }
        }

        private void HitungTotal()
        {
            double debet = 0;
            double kredit = 0;
            
            if (dtRowDetail.Rows.Count > 0)
            {
                double.TryParse(dtRowDetail.Compute("SUM(Debet)", "").ToString(), out debet);
                double.TryParse(dtRowDetail.Compute("SUM(Kredit)", "").ToString(), out kredit);
            }
            txtTDebet.Text = debet.ToString("#,##0");
            txtTKredit.Text = kredit.ToString("#,##0");
            txtSelisih.Text = (debet - kredit).ToString("#,##0");
            if (txtSelisih.Text == "0" || txtSelisih.Text == "")
            {
                txtSelisih.BackColor = Color.White;
            }
            else
            {
                txtSelisih.BackColor = Color.Red;
            }

        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdAdd_Click(sender, new EventArgs());
                        break;
                    case Keys.E:
                        cmdEdit_Click(sender, new EventArgs());
                        break;
                    case Keys.D:
                        cmdDelete_Click(sender, new EventArgs());
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        cmdAdd_Click(sender, new EventArgs());
                        break;
                    case Keys.Space:
                        cmdEdit_Click(sender, new EventArgs());
                        break;
                    case Keys.Delete:
                        cmdDelete_Click(sender, new EventArgs());
                        break;
                }
            }
        }

        private void frmJournalUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJournalBrowse)
                {
                    frmJournalBrowse frmCaller = (frmJournalBrowse)this.Caller;
                    frmCaller.RefreshRowHeader(_rowID.ToString());
                    frmCaller.FindRow("hRowID", _rowID.ToString());
                }
            }
            else
            {
                DataTable dtInsert, dtUpdate, dtDelete;
                dtInsert = dtRowDetail.GetChanges(DataRowState.Added);
                dtUpdate = dtRowDetail.GetChanges(DataRowState.Modified);
                dtDelete = dtRowDetail.GetChanges(DataRowState.Deleted);

                if (dtInsert != null || dtUpdate != null || dtDeleteee.Rows.Count>0)
                {
                    if (MessageBox.Show("Perubahan Data Belum Di Save. Tutup Form?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        double debet = 0;
                        double kredit = 0;

                        if (dtRowDetail.Rows.Count > 0)
                        {
                            double.TryParse(dtRowDetailAwal.Compute("SUM(Debet)", "").ToString(), out debet);
                            double.TryParse(dtRowDetailAwal.Compute("SUM(Kredit)", "").ToString(), out kredit);
                        }
                        double selisihAwal = (debet - kredit);
                        if (selisihAwal != 0)
                        {
                            MessageBox.Show("Debet-Kredit data awal masih belum balance");
                            e.Cancel = true;
                        }
                    }
                    else
                        e.Cancel = true;
                }
                else
                {
                    if (txtSelisih.GetDoubleValue != 0)
                    {
                        MessageBox.Show("Debet-Kredit masih belum balance");
                        e.Cancel = true;
                    }
                }
            }
        }

    }
}
