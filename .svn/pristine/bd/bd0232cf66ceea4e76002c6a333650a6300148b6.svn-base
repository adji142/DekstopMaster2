using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Tac
{
    public partial class frmWilayah : ISA.Controls.BaseForm
    {
        string mode = string.Empty;
        DataTable dt;
        Guid RowID_;
        string wilayah_ = string.Empty;

        public frmWilayah()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            this.wil.Enabled = true;
            this.cmdSimpan.Enabled = true;
            this.cmdTutup.Enabled = true;
            this.wil.Focus();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            this.wil.Enabled = true;
            this.cmdSimpan.Enabled = true;
            this.cmdTutup.Enabled = true;
            this.wil.Focus();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Wilayah_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        wil.Text = Tools.isNull(dt.Rows[0]["wilayah"], "").ToString();
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

        private void cmdTutup_Click(object sender, EventArgs e)
        {
            this.wil.Enabled = false;
            this.cmdSimpan.Enabled = false;
            this.cmdTutup.Enabled = false;
        }

        private void cmdSimpan_Click(object sender, EventArgs e)
        {
            if (wil.Text == "")
            {
                MessageBox.Show("Wilayah masih kosong..!");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (mode == "Add")
                {
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Wilayah_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@wilayah", SqlDbType.VarChar, wil.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }

                if (mode == "Edit")
                {
                    RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    wilayah_ = wil.Text;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_Wilayah_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].Parameters.Add(new Parameter("@Wilayah", SqlDbType.VarChar, wil.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                //    break;
                    //case enumFormMode.Update:
                    //    using (Database db = new Database(GlobalVar.DBName))
                    //    {

                    //        db.Commands.Add(db.CreateCommand("usp_Perkiraan_UPDATE"));
                    //        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, txtNoPerkiraan.Text));
                    //        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, txtRef.Text));
                    //        db.Commands[0].Parameters.Add(new Parameter("@Level", SqlDbType.VarChar, cboLevel.Text));
                    //        db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, txtUraian.Text));
                    //        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 1));
                    //        db.Commands[0].Parameters.Add(new Parameter("@Pasif", SqlDbType.VarChar, chkPassive.Checked));
                    //        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    //        db.Commands[0].ExecuteNonQuery();
                    //    }
                    //    break;

                MessageBox.Show(Messages.Confirm.UpdateSuccess);
                this.DialogResult = DialogResult.OK;
                RefreshData();
                this.WilayahFindRow("wilayah", wilayah_);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.wil.Enabled = false;
            this.cmdSimpan.Enabled = false;
            this.cmdTutup.Enabled = false;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWilayah_Load(object sender, EventArgs e)
        {
            InitializeComponents();
            customGridView1.ReadOnly = true;
            RefreshData(); 
        }

        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Wilayah_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt.DefaultView;
        }

        public void WilayahFindRow(string column, string value)
        {
            RefreshData();
            customGridView1.FindRow(column, value);
            customGridView1.Focus();
        }

        public void FindRow(string columnName, string value)
        {
            foreach (DataGridViewRow row in customGridView1.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString().ToUpper() == value.ToUpper())
                    {
                        int i = 0;
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Visible == true)
                            {
                                break;
                            }
                        }
                        customGridView1.CurrentCell = row.Cells[i];
                        this.Focus();
                        row.Selected = true;
                        customGridView1.FirstDisplayedCell = customGridView1.CurrentCell;
                        break;
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string wil = customGridView1.SelectedCells[0].OwningRow.Cells["wilayah"].Value.ToString();
                if (MessageBox.Show("Hapus Wilayah : " + wil + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Wilayah_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        this.RefreshData();
                        MessageBox.Show("Record telah dihapus");
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

        public void InitializeComponents()
        {
            this.Location = new Point(340, 190);
        }

    }
}
