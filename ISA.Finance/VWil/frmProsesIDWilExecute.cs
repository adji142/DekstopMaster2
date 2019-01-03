using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;

namespace ISA.Finance.VWil
{
    public partial class frmProsesIDWilExecute : ISA.Finance.BaseForm
    {
        string prevHRowID = "";
        
        DataTable dtJournalH;
        DataTable dtJournalD;
        string _kodeToko = "";
        Guid _refRowID;

        public frmProsesIDWilExecute(string kodeToko, Guid refRowID, dsJurnal.JournalDataTable dataHeader, dsJurnal.JournalDetailDataTable dataDetail)
        {
            InitializeComponent();
            _kodeToko = kodeToko;
            _refRowID = refRowID;

            dtJournalH = dataHeader.Copy();
            dtJournalD = dataDetail.Copy();
        }


        private void RefreshDetail()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string curHRowID = customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString();
                if (prevHRowID != curHRowID)
                {
                    if (customGridView1.SelectedCells.Count > 0)
                    {
                        dtJournalD.DefaultView.RowFilter = "HeaderID='" + customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString() + "'";
                    }
                    prevHRowID = curHRowID;
                }
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskSave, "Link GL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                LinkGL();
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkGL()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();


                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_Vwil_UpdateToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@refRowID", SqlDbType.UniqueIdentifier, _refRowID));                    
                    db.Commands[0].ExecuteNonQuery();
                    /*
                    //CLEAR PREVIOUS EXISSTING DATA
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("psp_VWil_LinktoGL_CLEAR"));
                    db.Commands[0].Parameters.Add(new Parameter("@RefRowID", SqlDbType.UniqueIdentifier, _refRowID));                    
                    db.Commands[0].ExecuteNonQuery();

                    //INSERT TO JOURNAL
                    db.Commands.Clear();
                    foreach (DataRow drH in dtJournalH.Rows)
                    {
                        Guid RowIDH = new Guid(drH["RowID"].ToString());
                        Guid hRowID = new Guid(drH["RefRowID"].ToString());
                        string hRecordID = drH["RecordID"].ToString();
                        DateTime hTanggal = (DateTime)drH["Tanggal"];
                        string hNoReff = drH["NoReff"].ToString();
                        string hUraian = drH["Uraian"].ToString();
                        string hSrc = drH["Src"].ToString();
                        string hKodeGudang = drH["KodeGudang"].ToString();
                        bool hSyncFlag = false;
                        Journal.LinkHeader(db, hRowID, RowIDH, hRecordID, hTanggal, hNoReff, hUraian, hSrc, hKodeGudang, hSyncFlag);
                        //progressBar1.Value++;
                        this.RefreshForm();

                        DataRow[] drDArray = dtJournalD.Select("HeaderID='" + RowIDH.ToString() + "'");

                        foreach (DataRow drD in drDArray)
                        {
                            Guid RowIDD = new Guid(drD["RowID"].ToString());
                            Guid dRowID = new Guid(drD["RefRowID"].ToString());
                            Guid dHeaderID = new Guid(drD["HeaderID"].ToString());
                            string dRecordID = drD["RecordID"].ToString();
                            string dHRecordID = drD["HRecordID"].ToString();
                            string dNoPerkiraan = drD["NoPerkiraan"].ToString();
                            string dUraian = drD["Uraian"].ToString();
                            double dDebet = double.Parse(drD["Debet"].ToString());
                            double dKredit = double.Parse(drD["Kredit"].ToString());
                            string dDK = drD["DK"].ToString();
                            Journal.LinkDetail(db, RowIDD, dRowID, dHeaderID, dRecordID, dHRecordID, dNoPerkiraan, dUraian, dDebet, dKredit, dDK);
                        }                        
                    }
                    */
                    db.CommitTransaction();
                }
                this.DialogResult = DialogResult.OK;
                MessageBox.Show(Messages.Confirm.UpdateSuccess);

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




        private void gridPJH_FilterData(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void frmProsesIDWilExecute_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is VWil.frmRiwayatIDWilBrowse)
                {
                    VWil.frmRiwayatIDWilBrowse frmCaller = (VWil.frmRiwayatIDWilBrowse)this.Caller;
                    frmCaller.RefreshRowData(_kodeToko);
                    frmCaller.RefreshRowDetail(_refRowID.ToString());
                    
                }
            }
        }

        private void frmProsesIDWilExecute_Shown(object sender, EventArgs e)
        {
            customGridView1.DataSource = dtJournalH.DefaultView;
            customGridView2.DataSource = dtJournalD.DefaultView;
            RefreshDetail();
        }


    }
}
