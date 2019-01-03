using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;
using ISA.Finance.Class;
using ISA.Common;

namespace ISA.Finance.PJTools
{
    public partial class frmLinkPjExecute : ISA.Finance.BaseForm
    {
        //public frmLinkPjExecute(DataTable dtPJH, DataTable dtPJD, DataTable dtAGH, DataTable dtAGD, DataTable dtPJACH,  DataTable dtPJACD)
        DateTime _tglProses;
        string _kodeGudang;
        DataTable dtH = new DataTable ();
        DataTable dtD = new DataTable();
        public frmLinkPjExecute(DateTime tglProses, string kodeGudang, DataTable dtPJH, DataTable dtPJD)
        {            
            InitializeComponent();
            _tglProses = tglProses;
            _kodeGudang = kodeGudang;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtH = dtPJH;
                dtD = dtPJD;
                gridPJH.DataSource = dtPJH;
                gridPJD.DataSource = dtPJD.DefaultView;
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

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskSave, "Link PJ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();

                    db.Commands.Add(db.CreateCommand("psp_PJTools_LinkPenjualan_CLEAR"));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, _tglProses));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, _kodeGudang));
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands.Clear();

                    foreach (DataRow drH in dtH.Rows)
                    {
                        Journal.AddHeader(
                              db,
                              new Guid(drH["RowID"].ToString()),
                              drH["RecordID"].ToString(),
                              DateTime.Parse(drH["Tanggal"].ToString()),
                              drH["NoReff"].ToString(),
                              drH["Uraian"].ToString(),
                              drH["Src"].ToString(),
                              drH["KodeGudang"].ToString(),
                              bool.Parse(drH["SyncFlag"].ToString()));
                    }
                    foreach (DataRow drD in dtD.Rows)
                    {
                        Journal.AddDetail(
                            db,
                            new Guid(drD["RowID"].ToString()),
                            new Guid(drD["HeaderID"].ToString()),
                            drD["RecordID"].ToString(),
                            drD["HRecordID"].ToString(),
                            drD["NoPerkiraan"].ToString(),
                            drD["Uraian"].ToString(),
                            double.Parse(drD["Debet"].ToString()),
                            double.Parse(drD["Kredit"].ToString()),
                            drD["DK"].ToString());

                    }

                    db.CommitTransaction();
                }
                MessageBox.Show(Messages.Confirm.UpdateSuccess);
            }
        }

        private void gridPJH_SelectionRowChanged(object sender, EventArgs e)
        {
            if (gridPJH.SelectedCells.Count > 0)
            {
                Guid rowid = new Guid(gridPJH.SelectedCells[0].OwningRow.Cells["hRowID"].Value.ToString());
                dtD.DefaultView.RowFilter = "HeaderID = '" + rowid.ToString() + "'";
                
            }
        }
    }
}
