using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmBPPBrowse : ISA.Finance.BaseForm
    {
        DataTable dt,dtDetail = new DataTable();
        string KodeColl = string.Empty;
        Guid _RowID;
        public event EventHandler SelectData;
        public frmBPPBrowse()
        {
            InitializeComponent();
        }


        public frmBPPBrowse(Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void lookupCollectorDialog()
        {
            frmLookupCollector ifrmDialog = new frmLookupCollector(tbCollector.Text);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmLookupCollector dialogForm)
        {
            //this.CollectorID = dialogForm.KodeCollector;
            //this.NamaCollector = dialogForm.NamaCollector;
            tbCollector.Text = dialogForm.NamaCollector;
            KodeColl = dialogForm.KodeCollector;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }

        }

        private void tbCollector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lookupCollectorDialog();
            }
        }

        private void cmbsearch_Click(object sender, EventArgs e)
        {
            if (KodeColl != null || tbCollector.Text != "")
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BPP_Search"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, tbCollector.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    DataGridViewBpp.DataSource = dt;

                }
                if (dt.Rows.Count > 0)
                {
                    LoadDetail();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void LoadDetail()
        {
            try
            {
                _RowID = (Guid)DataGridViewBpp.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BPPDetail_Search"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dtDetail;

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmbDownload_Click(object sender, EventArgs e)
        {
            Kasir.frmBPPDownload ifrmChild = new Kasir.frmBPPDownload();
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();

        }

        private void cmbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
