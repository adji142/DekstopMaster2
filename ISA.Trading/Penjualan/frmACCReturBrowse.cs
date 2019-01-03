using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmACCReturBrowse : ISA.Trading.BaseForm
    {
        public frmACCReturBrowse()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCReturSPVList"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rdbTglMPR.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rdbTglMPR.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dataGridDO.DataSource = dt;
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

        private void frmACCReturBrowse_Load(object sender, EventArgs e)
        {
            rdbTglMPR.FromDate = GlobalVar.DateOfServer;
            rdbTglMPR.ToDate = GlobalVar.DateOfServer;


            bool isAccRetur = LookupInfoValue.CekAccRetur(SecurityManager.UserID);
            //cmdYes.Visible = isAccRetur;
            //------------ close soon -------------
            cmdYes.Visible = true;
            //------------ close soon -------------
            cmdSearch_Click(sender, e);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbTglMPR_KeyDown(object sender, KeyEventArgs e)
        {
            cmdSearch_Click(sender, new EventArgs());
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                Guid rowId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                string noMPR = dataGridDO.SelectedCells[0].OwningRow.Cells[NoMemo.Name].Value.ToString();

                DialogResult dlg = new DialogResult();

                dlg = MessageBox.Show("Acc Pengajuan Retur " + noMPR + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.Yes)
                {
                    UpdateAccSPV(rowId);

                    cmdSearch_Click(sender, e);
                }
            }
        }

        private void UpdateAccSPV(Guid rowId)
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_updateACCReturSPV"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowId));
                db.Commands[0].Parameters.Add(new Parameter("@pin", SqlDbType.VarChar, "ACC"));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                dt = db.Commands[0].ExecuteDataTable();
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            bool isAccRetur = LookupInfoValue.CekAccRetur(SecurityManager.UserID);
            if (isAccRetur == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        cmdYes_Click(sender, e);
                        break;
                }
            }
        }
    }
}
