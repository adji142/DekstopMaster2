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
    public partial class frmLinkRjExecute : ISA.Finance.BaseForm
    {
        DateTime _tglProses;
        string _kodeGudang;
        DataTable dtH = new DataTable ();
        DataTable dtD = new DataTable();
        public frmLinkRjExecute(DateTime tglProses, string kodeGudang, DataTable dtRJH, DataTable dtRJD)
        {
            InitializeComponent();
            gridPJH.AutoGenerateColumns = false;
            gridPJD.AutoGenerateColumns = false;

            _tglProses = tglProses;
            _kodeGudang = kodeGudang;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtH = dtRJH;
                dtD = dtRJD;
                gridPJH.DataSource = dtRJH;
                gridPJD.DataSource = dtRJD.DefaultView;
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

        private void frmLinkRjExecute_Load(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskSave, "Link RJ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.BeginTransaction();

                    db.Commands.Add(db.CreateCommand("psp_PJTools_LinkReturPenjualan_CLEAR"));
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
