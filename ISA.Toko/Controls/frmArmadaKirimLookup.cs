using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Controls
{
    public partial class frmArmadaKirimLookup : ISA.Toko.BaseForm
    {
        DataTable dt;
        string kodeArmada, kendaraan, nomorPolisi, tripMeterKM, kMPerLiter;

        public frmArmadaKirimLookup(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt.Copy();
        }

        public frmArmadaKirimLookup()
        {
            InitializeComponent();
        }

        public string _KodeArmada
        {
            get
            {
                return kodeArmada;
            }
            set
            {
                kodeArmada = value;
            }
        }

        public string _Kendaraan
        {
            get
            {
                return kendaraan;
            }
            set
            {
                kendaraan = value;
            }
        }

        public string _NomorPolisi
        {
            get
            {
                return nomorPolisi;
            }
            set
            {
                nomorPolisi = value;
            }
        }


        public string _TripMeterKM
        {
            get
            {
                return tripMeterKM;
            }
            set
            {
                tripMeterKM = value;
            }
        }

        public string _KMPerLiter
        {
            get
            {
                return kMPerLiter;
            }
            set
            {
                kMPerLiter = value;
            }
        }

        private void frmArmadaKirimLookup_Load(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = "KodeArmada";
            gvArmadaKirim.DataSource = dt.DefaultView.ToTable();
            gvArmadaKirim.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void gvArmadaKirim_DoubleClick(object sender, EventArgs e)
        {
            if (gvArmadaKirim.SelectedCells.Count > 0)
            {
                ConfirmSelect();
            }
        }

        private void gvArmadaKirim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (gvArmadaKirim.SelectedCells.Count == 1)
            {
                kodeArmada = gvArmadaKirim.SelectedCells[0].OwningRow.Cells["KodeArmada2"].Value.ToString();
                kendaraan = gvArmadaKirim.SelectedCells[0].OwningRow.Cells["Kendaraan2"].Value.ToString();
                nomorPolisi = gvArmadaKirim.SelectedCells[0].OwningRow.Cells["NomorPolisi2"].Value.ToString();
                tripMeterKM = gvArmadaKirim.SelectedCells[0].OwningRow.Cells["TripMeterKM2"].Value.ToString();
                kMPerLiter = gvArmadaKirim.SelectedCells[0].OwningRow.Cells["KMPerLiter2"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmArmadaKirimLookup_Shown(object sender, EventArgs e)
        {
            if (gvArmadaKirim.Rows.Count > 0)
            {
                gvArmadaKirim.Focus();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (gvArmadaKirim.Rows.Count > 0)
            {
                ConfirmSelect();
            }
        }
    }
}
