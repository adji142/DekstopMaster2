using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Administrasi
{
    public partial class frmSyncDownloadDetailBrowse : ISA.Trading.BaseForm
    {
        enum enumFormMode {list};
        enumFormMode formMode;
        Guid  _rowID;
       

        public frmSyncDownloadDetailBrowse(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.list;
            _rowID = rowID;
            this.Caller = caller;
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_SyncDownloadDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BatchID", SqlDbType.UniqueIdentifier , _rowID ));

                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                   
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSyncDownloadDetailBrowse_Load(object sender, EventArgs e)
        {
            if(formMode == enumFormMode.list)
                RefreshData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Administrasi.frmSyncRowDetail  ifrmChild = new Administrasi.frmSyncRowDetail (this, rowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
