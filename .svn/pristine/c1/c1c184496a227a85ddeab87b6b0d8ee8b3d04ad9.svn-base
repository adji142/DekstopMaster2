using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Finance;
using ISA.Finance.DataTemplates;
using ISA.DAL;
using ISA.Finance.Class;
using ISA.Common;

namespace ISA.Finance.GL
{
    public partial class frmTutupBukuExecute : ISA.Finance.BaseForm
    {
        DateTime tglProses;
        string _periode;
        string _kodeGudang;

        DataTable dtClosing = new DataTable();
        dsJurnal.JournalDataTable dtJurnalH = new dsJurnal.JournalDataTable();
        dsJurnal.JournalDetailDataTable dtJurnalD = new dsJurnal.JournalDetailDataTable();

        int prevRow1 = -1;


        public frmTutupBukuExecute(string periode, string kodeGudang, DataTable pClosingGL, dsJurnal.JournalDataTable dtJournal, dsJurnal.JournalDetailDataTable dtJournalDetail)
        {
            InitializeComponent();

            _periode = periode;
            _kodeGudang = kodeGudang;
            dtClosing = pClosingGL;
            dtJurnalH = dtJournal;
            dtJurnalD = dtJournalDetail;            
        }

        private void frmTutupBukuPreview_Shown(object sender, EventArgs e)
        {
            gridClosingGL.DataSource = dtClosing;
            customGridView1.DataSource = dtJurnalH;
            customGridView2.DataSource = dtJurnalD.DefaultView;
            //if (customGridView1.Rows.Count > 0)
            //{
            //    customGridView1.CurrentCell = customGridView1[2,0];
            //}
            RefreshDetail();
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (MessageBox.Show(Messages.Question.AskSave, "Tutup Buku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DateTime lbbDate = new DateTime(Convert.ToInt32(_periode.Substring(0, 4)), Convert.ToInt32(_periode.Substring(4, 2)), 1).AddMonths(1);
                    DateTime closingDate = lbbDate.AddDays(-1);

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.BeginTransaction();

                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_GL_ClearTutupBuku"));
                        db.Commands[0].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, _periode));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, _kodeGudang));
                        db.Commands[0].ExecuteNonQuery();

                        foreach (DataRow dr in dtClosing.Rows)
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_ClosingGL_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@Periode", SqlDbType.VarChar, _periode));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, dr["KodeGudang"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, dr["NoPerkiraan"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglProses", SqlDbType.DateTime, dr["TglProses"]));
                            db.Commands[0].Parameters.Add(new Parameter("@RpAkhir", SqlDbType.Money, dr["RpAkhir"]));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserInitial));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        foreach (DataRow dr in dtJurnalH.Rows)
                        {
                            Journal.AddHeader(db,
                                new Guid(dr["RowID"].ToString()),
                                dr["RecordID"].ToString(),
                                Convert.ToDateTime(dr["Tanggal"]),
                                dr["NoReff"].ToString(),
                                dr["Uraian"].ToString(),
                                dr["Src"].ToString(),
                                dr["KodeGudang"].ToString(),
                                Convert.ToBoolean(dr["SyncFlag"]));

                        }

                        foreach (DataRow dr in dtJurnalD.Rows)
                        {
                            Journal.AddDetail(db,
                                new Guid(dr["RowID"].ToString()),
                                new Guid(dr["HeaderID"].ToString()),
                                dr["RecordID"].ToString(),
                                dr["HRecordID"].ToString(),
                                dr["NoPerkiraan"].ToString(),
                                dr["Uraian"].ToString(),
                                Convert.ToDouble(dr["Debet"]),
                                Convert.ToDouble(dr["Kredit"]),
                                dr["DK"].ToString());
                        }



                        db.CommitTransaction();
                        MessageBox.Show(Messages.Confirm.ProcessFinished);
                    }
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void RefreshDetail()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string journalID = customGridView1.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString();
                dtJurnalD.DefaultView.RowFilter = "HeaderID='" + journalID + "'";
                
                prevRow1 = customGridView1.SelectedCells[0].RowIndex;                
            }
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow1 != customGridView1.SelectedCells[0].RowIndex)
                {
                    RefreshDetail();
                }
            }
            //else
            //{
            //    dtJurnalD.DefaultView.RowFilter = "RowID=''";
            //}
        }

    }
}
