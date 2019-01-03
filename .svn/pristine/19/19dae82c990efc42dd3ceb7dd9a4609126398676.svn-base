using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Library;
using ISA.Bengkel;
using ISA.Bengkel.Helper;

namespace ISA.Bengkel.Master
{
    public partial class frmStandarBiayaServiceBrowse : ISA.Controls.BaseForm
    {
        public frmStandarBiayaServiceBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStandarBiayaServiceBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StandarService_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dgMain.DataSource = dt;
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
            dgMain.FindRow(columnName, value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmStandarBiayaServiceUpdate ifrmChild = new frmStandarBiayaServiceUpdate(this);
            ifrmChild.ShowDialog();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (!FormTools.IsRowSelected(dgMain))
            {
                return;
            }
            Guid rowID;
            rowID = (Guid)dgMain.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            frmStandarBiayaServiceUpdate ifrmChild = new frmStandarBiayaServiceUpdate(this, rowID);
            ifrmChild.ShowDialog();

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!FormTools.IsRowSelected(dgMain))
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            deleteData();
        }


        private void deleteData()
        {
            Guid rowID = (Guid)dgMain.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            if (MessageBox.Show("Hapus Standar Service id: " + rowID + " ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_StandarService_DELETE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
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
    }
}
