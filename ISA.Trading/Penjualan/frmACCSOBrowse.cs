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
    public partial class frmACCSOBrowse : ISA.Trading.BaseForm
    {
        public frmACCSOBrowse()
        {
            InitializeComponent();
        }

        private void frmACCSOBrowse_Load(object sender, EventArgs e)
        {
            rdbTglDO.FromDate = GlobalVar.DateOfServer;
            rdbTglDO.ToDate = GlobalVar.DateOfServer;

            //bool isAccSO = LookupInfoValue.CekAccSO(SecurityManager.UserID);

            if (SecurityManager.IsPiutang())
            {
                cmdYes.Visible = true;
            }

            cmdSearch_Click(sender, e);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                DataTable dt = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DOCekSOList"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, (DateTime)rdbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, (DateTime)rdbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    //dataGridDO.DataSource = dt.DefaultView;
                }

                dataGridDO.DataSource = dt;//.DefaultView;

                if (dataGridDO.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                    //lblToko.Text = "\"" + customGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                    //    + customGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                    //customGridView2.Focus();
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

        private void RefreshDataDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDetailDO = new DataTable();
                using (Database db = new Database())
                {
                    Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_FILTER_HEADERID")); // udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();
                }

                dataGridDetailDO.DataSource = dtDetailDO;
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void customGridView2_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                RefreshDataDetail();

                //lblToko.Text = "\"" + customGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                //    + customGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
            }
            else
            {
                lblToko.Text = " ";
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                Flag();
                cmdSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private void Flag()
        {
            try
            {
                
                Guid _doId = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells[RowID.Name].Value;
                
                string message = "Dengan meng-acc ini maka bagian piutang sudah melakukan pengecekan terhadap informasi Sales Order ini adalah benar dan tidak fiktif. Simpanlah bukti Sales Order ini untuk kepentingan pada saat proses auditing.";
                DialogResult dlg = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlg == DialogResult.Yes)
                {
                    // update kolom di table
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPenjualanUpdateCekFisik"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _doId));
                        db.Commands[0].Parameters.Add(new Parameter("@Cek", SqlDbType.Bit, 1));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    dataGridDO.SelectedCells[0].OwningRow.Cells[CekSO.Name].Value = "1";
                    dataGridDO.SelectedCells[0].OwningRow.DefaultCellStyle.BackColor = Color.Plum;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F10:
            //        Flag();
            //        break; 
            //}
        }

        private void dataGridDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                RefreshDataDetail();

                //lblToko.Text = "\"" + customGridView2.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                //    + customGridView2.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
            }
            else
            {
                lblToko.Text = " ";
            }
        }

    }
}
