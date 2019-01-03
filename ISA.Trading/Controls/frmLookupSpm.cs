using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Trading.Controls
{
    public partial class frmLookupSpm : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();
        string NoPol, nmcust, KodeCust, spdm, kdspm, jnsspm, wrn, thn, kilometer, kluhan, noid,
            no_telp, id_member, alamat, ktp;

        public string nopol
        {
            get
            {
                return NoPol;
            }
        }
        public string namacust
        {
            get
            {
                return nmcust;
            }
        }
        public string kodecust
        {
            get
            {
                return KodeCust;
            }
        }
        public string Spm
        {
            get
            {
                return spdm;
            }
        }
        public string Kd_spm
        {
            get
            {
                return kdspm;
            }
        }
        public string Jns_spm
        {
            get
            {
                return jnsspm;
            }
        }
        public string Warna
        {
            get
            {
                return wrn;
            }
        }
        public string Tahun
        {
            get
            {
                return thn;
            }
        }
        public string Km
        {
            get
            {
                return kilometer;
            }
        }
        public string Keluhan
        {
            get
            {
                return kluhan;
            }
        }
        public string Noid
        {
            get
            {
                return noid;
            }
        }
        public string telpon
        {
            get
            {
                return no_telp;
            }
        }
        public string idmember
        {
            get
            {
                return id_member;
            }
        }
        public string Alamat
        {
            get
            {
                return alamat;
            }
        }
        public string Ktp
        {
            get
            {
                return ktp;
            }
        }

        public frmLookupSpm()
        {
            InitializeComponent();
        }

        public frmLookupSpm(string nopol, DataTable dt)
        {
            InitializeComponent();
            customGridView1.DataSource = dt.DefaultView;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLookupSpm_Load(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            confirmselect();
        }

        private void confirmselect()
        {
            nmcust = customGridView1.SelectedCells[0].OwningRow.Cells["nama_cust"].Value.ToString();
            KodeCust = customGridView1.SelectedCells[0].OwningRow.Cells["kd_cust"].Value.ToString();
            NoPol = customGridView1.SelectedCells[0].OwningRow.Cells["no_pol"].Value.ToString();
            spdm = customGridView1.SelectedCells[0].OwningRow.Cells["spm"].Value.ToString();
            jnsspm = customGridView1.SelectedCells[0].OwningRow.Cells["jns_spm"].Value.ToString();
            kdspm = customGridView1.SelectedCells[0].OwningRow.Cells["kode"].Value.ToString();
            wrn = customGridView1.SelectedCells[0].OwningRow.Cells["warna"].Value.ToString();
            thn = customGridView1.SelectedCells[0].OwningRow.Cells["tahun"].Value.ToString();
            //noid = customGridView1.SelectedCells[0].OwningRow.Cells["idcust"].Value.ToString();
            alamat = customGridView1.SelectedCells[0].OwningRow.Cells["alamat"].Value.ToString();
            no_telp = customGridView1.SelectedCells[0].OwningRow.Cells["no_telp"].Value.ToString();
            ktp = customGridView1.SelectedCells[0].OwningRow.Cells["ktp"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                confirmselect();
            }
        }
    }
}
