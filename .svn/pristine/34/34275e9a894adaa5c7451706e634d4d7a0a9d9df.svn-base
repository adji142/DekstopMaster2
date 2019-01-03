using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Administrasi
{
    public partial class frmSecurityUsersRightsBrowse : ISA.Toko.BaseForm
    {
        string _userID;
        DataTable dt = new DataTable();

        public frmSecurityUsersRightsBrowse(string userID)
        {
            InitializeComponent();
            _userID = userID;
            this.txtUser.Text = userID;
        }

        private void frmSecurityUsersRights_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            lookupSecurityRights1.Clear();
            RefreshData();
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
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SecurityUsersRights_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, _userID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "cmdDelete")
            {
                DataGridViewRow curRow = dataGridView1.Rows[e.RowIndex];
                int rowID = int.Parse(curRow.Cells["RowID"].Value.ToString());

                if (MessageBox.Show(Messages.Question.AskDelete, "Delete Role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_SecurityUsersRights_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.Int, rowID));
                            db.Commands[0].ExecuteNonQuery();
                            dataGridView1.Rows.Remove(curRow);
                            MessageBox.Show(Messages.Confirm.DeleteSuccess, "Delete Role");
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
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_SecurityUsersRights_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@userID", SqlDbType.VarChar, _userID));
                        db.Commands[0].Parameters.Add(new Parameter("@rightID", SqlDbType.VarChar, lookupSecurityRights1.RightID));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        MessageBox.Show(Messages.Confirm.UpdateSuccess, "Add Role");
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
                RefreshData();
            }
        }


        private bool isValid()
        {
            bool valid = true;
            if (lookupSecurityRights1.RightID == "")
            {
                valid = false;
            }
            return valid;
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
