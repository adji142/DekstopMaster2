using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmKasBonLink : ISA.Controls.BaseForm
    {
        private DataTable _dtHeader;

        private Guid _rowId;
        public Guid RowId
        {
            get { return _rowId; }
        }

        private string _pin;
        public string Pin
        {
            get { return _pin; }
        }

        public frmKasBonLink(DataTable dt)
        {
            _dtHeader = dt;
            _rowId = Guid.Empty;
            InitializeComponent();
        }

        private void frmKasBonLink_Load(object sender, EventArgs e)
        {
            dgvHeader.DataSource = _dtHeader;
            RefreshDetail();
        }

        private void dgvHeader_SelectionChanged(object sender, EventArgs e)
        {
            dgvHeader_SelectionRowChanged(sender, e);
        }

        private void dgvHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            RefreshDetail();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                _rowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                _pin = Tools.isNull(dgvHeader.SelectedCells[0].OwningRow.Cells["PIN"].Value, string.Empty).ToString();

                this.Close();
            }
            else
                MessageBox.Show(Messages.Error.RowNotSelected);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDetail()
        {
            if (dgvHeader.SelectedCells.Count > 0)
            {
                Guid headerRowId = (Guid)dgvHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

                DataTable dt = new DataTable();

                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BiayaOperasionalDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@BiayaOperasionalRowID", SqlDbType.UniqueIdentifier, headerRowId));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dgvDetail.DataSource = dt;
            }
        }
    }
}
