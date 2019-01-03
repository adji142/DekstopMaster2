using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.KoreksiReturJual
{
    public partial class frmKoreksiReturJualTKBrowser : ISA.Toko.BaseForm
    {
        DataTable dt;

        public frmKoreksiReturJualTKBrowser()
        {
            InitializeComponent();
        }

        private void frmKoreksiReturJualTKBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Koreksi Retur Jual";
            this.Text = "Koreksi Retur Jual";
            customGridView1.AutoGenerateColumns = false;

        }

        private void rgbTglNotaRetur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rgbTglNotaRetur.FromDate.ToString().Trim() == "" ||
                rgbTglNotaRetur.ToDate.ToString().Trim() == "")
            {
                MessageBox.Show("Range Tgl. Retur masih kosong");
                return;
            }
            RefreshDataRetur();
        }

        private void RefreshDataRetur()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiReturPenjualan_LIST_TunaiKredit"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglNotaRetur.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglNotaRetur.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dt;
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

        private void RefreshRowDataRetur(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiReturPenjualan_LIST_TunaiKredit"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    customGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
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

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.T:
                        ProsesKoreksiTK("T");
                        break;
                    case Keys.K:
                        ProsesKoreksiTK("K");
                        break;
                }
            }
        }

        private void ProsesKoreksiTK(string _tk)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int i = customGridView1.SelectedCells[0].OwningRow.Index;
                using (Database db = new Database(Properties.Settings.Default.Host))
                {
                    db.Commands.Add(db.CreateCommand("usp_Koret_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@returPenjualanID", SqlDbType.UniqueIdentifier, dt.Rows[i]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[i]["ReturID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, dt.Rows[i]["NoNotaRetur"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tk", SqlDbType.VarChar, _tk));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                RefreshRowDataRetur(dt.Rows[i]["RowID"].ToString());
                customGridView1.FindRow("RowID", dt.Rows[i]["RowID"].ToString());
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

        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
