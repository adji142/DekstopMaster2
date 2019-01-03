using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Controls
{
    public partial class frmPegawaiLookup : ISA.Toko.BaseForm
    {
        DataTable dt;
        string nip, nama, unitKerja, jabatan, lp, alamat;


        public frmPegawaiLookup(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt.Copy();
        }


        

        public string _NIP
        {
            get
            {
                return nip;
            }
            set
            {
                nip = value;
            }
        }

        public string _Nama
        {
            get
            {
                return nama;
            }
            set
            {
                nama = value;
            }
        }

        public string _UnitKerja
        {
            get
            {
                return unitKerja;
            }
            set
            {
                unitKerja = value;
            }
        }

        public string _LP
        {
            get
            {
                return lp;
            }
            set
            {
                lp = value;
            }
        }

        public string _Jabatan
        {
            get
            {
                return jabatan;
            }
            set
            {
                jabatan = value;
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




        private void frmPegawaiLookup_Load(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = "Nip";
            gridPegawai.DataSource = dt.DefaultView.ToTable();
            gridPegawai.Focus();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (gridPegawai.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void gridPegawai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (gridPegawai.SelectedCells.Count == 1)
            {
                nip = gridPegawai.SelectedCells[0].OwningRow.Cells["Nip"].Value.ToString();
                nama = gridPegawai.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString();
                unitKerja = gridPegawai.SelectedCells[0].OwningRow.Cells["UnitKerja"].Value.ToString();
                lp = gridPegawai.SelectedCells[0].OwningRow.Cells["LP"].Value.ToString();
                jabatan = gridPegawai.SelectedCells[0].OwningRow.Cells["Jabatan"].Value.ToString();
                alamat = gridPegawai.SelectedCells[0].OwningRow.Cells["Alamat"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gridPegawai_DoubleClick(object sender, EventArgs e)
        {
            if (gridPegawai.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void frmPegawaiLookup_Shown(object sender, EventArgs e)
        {
            if (gridPegawai.Rows.Count > 0)
            {
                gridPegawai.Focus();
            }
        }




    }
}
