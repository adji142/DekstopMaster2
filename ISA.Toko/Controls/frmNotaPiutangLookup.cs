using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Controls
{    
    public partial class frmNotaPiutangLookup : ISA.Toko.BaseForm
    {
        Guid rowID;
        string noNota, tglJTempo, rpNota, rpTagih, noReg, recordID, jenis;
        DataTable dtNota;
        public Guid RowID
        {
            get
            {
                return rowID;
            }
            set
            {
                rowID = value;
            }
        }

        public string RecordID
        {
            get
            {
                return recordID;
            }
            set
            {
                recordID = value;
            }
        }

        public string Jenis
        {
            get
            {
                return jenis;
            }
            set
            {
                jenis = value;
            }
        }

        public string NoNota
        {
            get
            {
                return noNota;
            }
            set
            {
                noNota = value;
            }
        }

        public string TglJatuhTempo
        {
            get
            {
                return tglJTempo;
            }
            set
            {
                tglJTempo = value;
            }
        }

        public string RpNota
        {
            get
            {
                return rpNota;
            }
            set
            {
                rpNota = value;
            }
        }

        public string RpTagih
        {
            get
            {
                return rpTagih;
            }
            set
            {
                rpTagih = value;
            }
        }
        public frmNotaPiutangLookup(DataTable dt)
        {
            InitializeComponent();
            this.dtNota = dt.Copy();
        }

        private void frmNotaPiutangLookup_Load(object sender, EventArgs e)
        {
            dtNota.DefaultView.Sort = "TglJatuhTempo, NoTransaksi";
            gridNotaPiutang.DataSource = dtNota.DefaultView.ToTable();

        }

        private void ConfirmSelect()
        {
            if (gridNotaPiutang.SelectedCells.Count == 1)
            {
                rowID = (Guid)gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cRowID"].Value;
                tglJTempo = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cTglJatuhTempo"].Value.ToString();
                noNota = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cNoTransaksi"].Value.ToString();
                rpNota = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cRpNota"].Value.ToString();
                rpTagih = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cRpTagih"].Value.ToString();
                recordID = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cRecordID"].Value.ToString();
                jenis = gridNotaPiutang.SelectedCells[0].OwningRow.Cells["cJenis"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gridNotaPiutang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gridNotaPiutang.SelectedCells.Count>0)
                ConfirmSelect();
        }

        private void gridNotaPiutang_KeyDown(object sender, KeyEventArgs e)
        {
             if(e.KeyCode==Keys.Enter && gridNotaPiutang.SelectedCells.Count>0)
                 ConfirmSelect();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (gridNotaPiutang.SelectedCells.Count > 0)
                ConfirmSelect();
        }

        private void frmNotaPiutangLookup_Shown(object sender, EventArgs e)
        {
            if (gridNotaPiutang.Rows.Count > 0)
            {
                gridNotaPiutang.Focus();
            }
        }
    }
}
