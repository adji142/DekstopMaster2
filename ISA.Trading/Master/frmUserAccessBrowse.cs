using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ISA.DAL;


namespace ISA.Trading.Master
{
    public partial class frmUserAccessBrowse : ISA.Controls.BaseForm
    {
        public frmUserAccessBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserAccessBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtUser = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_UserAccess_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@initial", SqlDbType.VarChar, ""));
                    dtUser = db.Commands[0].ExecuteDataTable();
                }
                //if (dtUser.Rows.Count > 0)
                //{
                dataGridUser.DataSource = dtUser;
                //}
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            try
            {
                Master.frmUserAccessUpdate ifrmChild = new Master.frmUserAccessUpdate(this);
                ifrmChild.ShowDialog();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool lUserAccess()
        {
            Boolean x = true;
            if (!SecurityManager.IsManager())
            {
                x = false;
                //try
                //{
                //    this.Cursor = Cursors.WaitCursor;
                //    DataTable dtUser = new DataTable();
                //    using (Database db = new Database())
                //    {
                //        db.Commands.Add(db.CreateCommand("usp_UserAccess_LIST"));
                //        db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, "SAMPLING OPNAME"));
                //        db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, SecurityManager.UserID));
                //        dtUser = db.Commands[0].ExecuteDataTable();
                //    }
                //    if (dtUser.Rows.Count > 0)
                //    {
                //        if (Tools.isNull(dtUser.Rows[0]["Value"], "0").ToString() == "0")
                //        {
                //            x = false;
                //        }
                //    }
                //    else
                //    {
                //        x = false;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Error.LogError(ex);
                //}
                //finally
                //{
                //    this.Cursor = Cursors.Default;
                //}
            }
            return x;
        }


        public void FindRow(string columnName, string value)
        {
            dataGridUser.FindRow(columnName, value);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            if (dataGridUser.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid _RowID = new Guid(dataGridUser.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_UserAccess_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        MessageBox.Show("Record telah dihapus");
                        RefreshData();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (!lUserAccess())
            {
                MessageBox.Show("Belum ada wewenang.");
                return;
            }

            if (dataGridUser.SelectedCells.Count > 0)
            {
                Guid _RowID = new Guid(dataGridUser.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString());
                try
                {
                    Master.frmUserAccessUpdate ifrmChild = new Master.frmUserAccessUpdate(this, _RowID);
                    ifrmChild.ShowDialog();
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        private void frmUserAccessBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdAdd.PerformClick();
            }
            if (e.KeyCode == Keys.Space)
            {
                cmdEdit.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }
    }
}
