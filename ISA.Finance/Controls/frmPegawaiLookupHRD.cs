using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Controls
{
    public partial class frmPegawaiLookupHRD : ISA.Finance.BaseForm
    {
        DataTable dt;
        string _nip, _nama, _unitkerja, _lp, _jabatan, _alamat, _no_telp, _keterangan;
        DateTime _tgl_lahir, _tgl_masuk;


        public frmPegawaiLookupHRD(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt.Copy();
        }


        

        public string _NIP
        {
            get
            {
                return _nip;
            }
            set
            {
                _nip = value;
            }
        }

        public string _Nama
        {
            get
            {
                return _nama;
            }
            set
            {
                _nama = value;
            }
        }

        public string _Unitkerja
        {
            get
            {
                return _unitkerja;
            }
            set
            {
                _unitkerja = value;
            }
        }

        public string _LP
        {
            get
            {
                return _lp;
            }
            set
            {
                _lp = value;
            }
        }

        public string _Jabatan
        {
            get
            {
                return _jabatan;
            }
            set
            {
                _jabatan = value;
            }
        }

        public string _Alamat
        {
            get
            {
                return _alamat;
            }
            set
            {
                _alamat = value;
            }
        }


        public string _NoTelp
        {
            get
            {
                return _no_telp;
            }
            set
            {
                _no_telp = value;
            }
        }


        public DateTime _TglLahir
        {
            get
            {
                return _tgl_lahir;
            }
            set
            {
                _tgl_lahir = value;
            }
        }

        public DateTime _TglMasuk
        {
            get
            {
                return _tgl_masuk;
            }
            set
            {
                _tgl_masuk = value;
            }
        }

        

        public string _Keterangan
        {
            get
            {
                return _keterangan;
            }
            set
            {
                _keterangan = value;
            }
        }



        private void frmPegawaiLookup_Load(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = "nip";
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
                _nip = gridPegawai.SelectedCells[0].OwningRow.Cells["nip"].Value.ToString();
                _nama = gridPegawai.SelectedCells[0].OwningRow.Cells["nama"].Value.ToString();
                _unitkerja = gridPegawai.SelectedCells[0].OwningRow.Cells["unitkerja"].Value.ToString();
                _lp = gridPegawai.SelectedCells[0].OwningRow.Cells["lp"].Value.ToString();
                _jabatan = gridPegawai.SelectedCells[0].OwningRow.Cells["jabatan"].Value.ToString();
                _alamat = gridPegawai.SelectedCells[0].OwningRow.Cells["alamat"].Value.ToString();
                _no_telp = gridPegawai.SelectedCells[0].OwningRow.Cells["no_telp"].Value.ToString();
                _keterangan = gridPegawai.SelectedCells[0].OwningRow.Cells["keterangan"].Value.ToString();
                _tgl_lahir = (DateTime)gridPegawai.SelectedCells[0].OwningRow.Cells["tgl_lahir"].Value;
                _tgl_masuk = (DateTime)gridPegawai.SelectedCells[0].OwningRow.Cells["tgl_masuk"].Value;
                
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
