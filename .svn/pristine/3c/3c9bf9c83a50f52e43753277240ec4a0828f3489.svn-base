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
using System.Data.SqlClient;

namespace ISA.Finance.Kasir
{
    public partial class frmLinkLeGLExecute : ISA.Finance.BaseForm
    {
        string prevHRowID = "";

        DataTable dtJournalH;
        DataTable dtJournalD;
        DateTime _tglProses;
        string _kodeGudang;
        public frmLinkLeGLExecute(DateTime tglProses, string kodeGudang, dsJurnal.JournalDataTable dataHeader,dsJurnal.JournalDetailDataTable dataDetail )
        {
            InitializeComponent();
            _tglProses = tglProses;
            _kodeGudang = kodeGudang;

            dtJournalH = dataHeader.Copy();
            dtJournalD = dataDetail.Copy();

            DataColumn newCol= new DataColumn ("Selected", typeof (System.Boolean));
            newCol.DefaultValue = true;
            dtJournalH.Columns.Add(newCol);
        }

        private void frmLinkLeGLExecute_Load(object sender, EventArgs e)
        {
            customGridView1.ReadOnly = false;
            foreach (DataGridViewColumn col in customGridView1.Columns)
            {
                col.ReadOnly = true;
            }
            customGridView1.Columns["hSelected"].ReadOnly = false;
            dtJournalD.DefaultView.Sort = "DK,RecordID";
            customGridView1.DataSource = dtJournalH.DefaultView;
            customGridView2.DataSource = dtJournalD.DefaultView;
            HitungTotal();
            dtJournalH.RowChanged += new DataRowChangeEventHandler(dtJournalH_RowChanged);
            
        }

        void dtJournalH_RowChanged(object sender, DataRowChangeEventArgs e)
        {            
            HitungTotal();
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
                DataRow[] drSelected = dtJournalH.Select("Selected=true");
                progressBar1.Maximum = drSelected.Length;
                progressBar1.Value = 0;
                this.RefreshForm();

                LinkGL();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == customGridView1.Rows[e.RowIndex].Cells["hSelected"].ColumnIndex)
            //{
            //    DataRow dr = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
            //    dr["Selected"] = !((bool)(dr["Selected"]));      
            //}

            RefreshDetail();
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtJournalH.Rows)
            {
                dr["Selected"] = chkSelectAll.Checked;
            }            
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && customGridView1.CurrentCell.OwningColumn.Name  != "hSelected")
            {
                if (customGridView1.SelectedCells.Count > 0)
                {
                    DataRow dr = ((DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                    dr["Selected"] = !((bool)(dr["Selected"]));                    
                }
                e.Handled = true;
            }
        }

        private void frmLinkLeGLExecute_Shown(object sender, EventArgs e)
        {


            if (dtJournalH.Rows.Count > 0)
            {
                dtJournalD.DefaultView.RowFilter = "HeaderID='" + dtJournalH.Rows[0]["RowID"].ToString() + "'";
            }
        }

        private void LinkGL()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();


                    ////CLEAR PREVIOUS EXISSTING DATA
                    //db.Commands.Clear();
                    //db.Commands.Add(db.CreateCommand("psp_KASIR_LinktoGL_CLEAR"));
                    //db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, _tglProses));
                    //db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, _kodeGudang));
                    //db.Commands[0].ExecuteNonQuery();

                    //INSERT TO JOURNAL
                    db.Commands.Clear();
                    foreach (DataRow drH in dtJournalH.Rows)
                    {
                        if ((bool)drH["Selected"])
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
                            Journal.LinkHeaderDelete(db, hRowID, RowIDH, hRecordID, hTanggal, hNoReff, hUraian, hSrc, hKodeGudang, hSyncFlag);
                            progressBar1.Value++;
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
                    }


                    db.CommitTransaction();
                }

                MessageBox.Show(Messages.Confirm.UpdateSuccess);

            }
            catch (SqlException exs)
            {
                Error.LogError(exs);
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


        private void HitungTotal()
        {
            double tDebet = 0;
            double tKredit = 0;

            
            foreach (DataRowView dr in dtJournalH.DefaultView)
            {
                if ((bool)dr["Selected"])
                {
                    double rDebet = 0;
                    double rKredit = 0;
                    double.TryParse(dr["Debet"].ToString(), out rDebet);
                    double.TryParse(dr["Kredit"].ToString(), out rKredit);
                    tDebet += rDebet;
                    tKredit += rKredit;
                }
            }
            txtTDebet.Text = tDebet.ToString("#,##0");
            txtTKredit.Text = tKredit.ToString("#,##0");
        }

        private void customGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.CommitEdit(DataGridViewDataErrorContexts.LeaveControl))
                HitungTotal();
        }

        private void customGridView1_FilterData(object sender, EventArgs e)
        {
            HitungTotal();
        }

    }
}
