using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.PJTools
{
    public partial class frmKelompokBarangBrowse : ISA.Finance.BaseForm
    {
        public frmKelompokBarangBrowse()
        {
            InitializeComponent();
        }

        private void frmKelompokBarangBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KelompokBarang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dt;
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

        public void FindRow(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            PJTools.frmKelompokBarangUpdate ifrmChild = new PJTools.frmKelompokBarangUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["cKelompokBrgID"].Value.ToString();
                PJTools.frmKelompokBarangUpdate ifrmChild = new PJTools.frmKelompokBarangUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["cKelompokBrgID"].Value.ToString();
                if (MessageBox.Show(Messages.Question.AskDelete, "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_KelompokBarang_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@KelompokBrgID", SqlDbType.VarChar, rowID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        DataRowView drHapus = (DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem;
                        drHapus.Row.Delete();

                        MessageBox.Show(Messages.Confirm.DeleteSuccess);                        
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
    }
}
