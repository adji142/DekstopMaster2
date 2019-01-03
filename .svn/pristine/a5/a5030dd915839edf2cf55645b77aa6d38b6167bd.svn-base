using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Controls
{
    public partial class frmSOLookup : ISA.Finance.BaseForm
    {
        DataTable dt;
        Guid rowid;
        string norequest, tgldo, nodo, namatoko, alamat, kota, kodetoko, rpnet;

        public frmSOLookup(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt.Copy();
        }

        public Guid _RowID
        {
            get
            {
                return rowid;
            }
            set
            {
                rowid = value;
            }
        }

        public string _NoRequest
        {
            get
            {
                return norequest;
            }
            set
            {
                norequest = value;
            }
        }

        public string _TglDO
        {
            get
            {
                return tgldo;
            }
            set
            {
                tgldo = value;
            }
        }

        public string _NoDO
        {
            get
            {
                return nodo;
            }
            set
            {
                nodo = value;
            }
        }

        public string _KodeToko
        {
            get
            {
                return kodetoko;
            }
            set
            {
                kodetoko = value;
            }
        }

        public string _NamaToko
        {
            get
            {
                return namatoko;
            }
            set
            {
                namatoko = value;
            }
        }

        public string _Alamat
        {
            get
            {
                return alamat;
            }
            set
            {
                alamat = value;
            }
        }

        public string _Kota
        {
            get
            {
                return kota;
            }
            set
            {
                kota = value;
            }
        }

        public string _RpNet
        {
            get
            {
                return rpnet;
            }
            set
            {
                rpnet = value;
            }
        }

        private void ConfirmSelect()
        {
            if (gridSO.SelectedCells.Count == 1)
            {
                rowid = (Guid)gridSO.SelectedCells[0].OwningRow.Cells["RowID_"].Value;
                kodetoko = gridSO.SelectedCells[0].OwningRow.Cells["KodeToko_"].Value.ToString();
                norequest = gridSO.SelectedCells[0].OwningRow.Cells["NoRequest_"].Value.ToString();
                tgldo = gridSO.SelectedCells[0].OwningRow.Cells["TglDO_"].Value.ToString();
                nodo = gridSO.SelectedCells[0].OwningRow.Cells["NoDO_"].Value.ToString();
                namatoko = gridSO.SelectedCells[0].OwningRow.Cells["NamaToko_"].Value.ToString();
                alamat = gridSO.SelectedCells[0].OwningRow.Cells["Alamat_"].Value.ToString();
                kota = gridSO.SelectedCells[0].OwningRow.Cells["Kota_"].Value.ToString();
                rpnet = gridSO.SelectedCells[0].OwningRow.Cells["RpNet_"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }    

        private void frmSOLookup_Load(object sender, EventArgs e)
        {
            gridSO.DataSource = dt.DefaultView.ToTable();
            gridSO.Focus();
        }

        private void frmSOLookup_Shown(object sender, EventArgs e)
        {
            if (gridSO.Rows.Count > 0)
            {
                gridSO.Focus();
            }
        }

        private void gridSO_DoubleClick(object sender, EventArgs e)
        {
            if (gridSO.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void gridSO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelect();
            }
        }

        private void cmdYes_Click_1(object sender, EventArgs e)
        {
            if (gridSO.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }
    }
}
