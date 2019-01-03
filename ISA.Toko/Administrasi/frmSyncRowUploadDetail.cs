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
    public partial class frmSyncRowUploadDetail : ISA.Toko.BaseForm
    {
        enum enumFormMode { list };
        enumFormMode formMode;
        Guid _rowID;

        public frmSyncRowUploadDetail(Form caller, Guid rowID)
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
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_SyncUploadDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BatchID", SqlDbType.UniqueIdentifier , _rowID ));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtRow.Text = Tools.isNull(dt.Rows[0]["RowID"], "").ToString();
                txtBatchID.Text = Tools.isNull(dt.Rows[0]["BatchID"], "").ToString();
                txtTable.Text = Tools.isNull(dt.Rows[0]["TableID"], "").ToString();
                txtData.Text = Tools.isNull(dt.Rows[0]["Data"], "").ToString().Replace(Environment.NewLine, string.Empty).TrimEnd();
                txtStatus.Text = Tools.isNull(dt.Rows[0]["Status"], "").ToString();

            }
           catch (Exception ex)
           {
               Error.LogError(ex);
           }
        }
        
        private void frmSyncRowUploadDetail_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.list)
            {
                RefreshData();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
