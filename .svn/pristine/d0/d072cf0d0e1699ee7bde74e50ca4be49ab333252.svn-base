using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class frmJadwalExpedisiLookup : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DateTime _DateRq, _DateFrom, _DateTo;
        string _Periode , _gudangID, _NoPeriode;

        public frmJadwalExpedisiLookup(DateTime tglRQ, string KdGdg)
        {
            InitializeComponent();
            _DateRq = tglRQ;
            _gudangID = KdGdg;
        }

        public DateTime tglAwal
        {
            get
            {
                return _DateFrom;
            }
        }

        public DateTime tglAkhir
        {
            get
            {
                return _DateTo;
            }
        }

        public string txtPeriode
        {
            get
            {
                return _Periode + " No:" + _NoPeriode ;
            }
        }

        public Guid guidRowID
        {
            get
            {
                return _rowID;
            }
        }

        public string stringDate
        {
            get
            {
                return _DateFrom.ToString().Substring(0, 10) + " s/d " + _DateTo.ToString().Substring(0, 10);
            }
        }

        private void frmJadwalExpedisiLookup_Load(object sender, EventArgs e)
        {
            if (GridJdwlExp.Rows.Count > 0)
            {
                BindData();
                GridJdwlExp.Focus();
            }
        }

        public void BindData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand("usp_JadwalExpedisi_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@RqDate", SqlDbType.DateTime, _DateRq));
                db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, _gudangID));
                dt = db.Commands[0].ExecuteDataTable();
                GridJdwlExp.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    GridJdwlExp.Focus();
                }
            }
        }

        private void ConfirmSelect()
        {
            if (GridJdwlExp.SelectedCells.Count == 1)
            {
                _rowID = (Guid)GridJdwlExp.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _Periode = (string)GridJdwlExp.SelectedCells[0].OwningRow.Cells["Periode"].Value;
                _NoPeriode = (string)GridJdwlExp.SelectedCells[0].OwningRow.Cells["NoPeriode"].Value.ToString();
                _DateFrom = (DateTime)GridJdwlExp.SelectedCells[0].OwningRow.Cells["TglAwal"].Value;
                _DateTo = (DateTime)GridJdwlExp.SelectedCells[0].OwningRow.Cells["TglAkhir"].Value;

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void GridJdwlExp_DoubleClick(object sender, EventArgs e)
        {
            if (GridJdwlExp.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }

}
