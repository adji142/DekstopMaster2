using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Controls
{
    public partial class lookupArmadaKirim : UserControl
    {
        string _KodeArmada, _Kendaraan, _NomorPolisi,_TripMeterKM, _KMPerLiter;
        public event EventHandler SelectData;

        public string KodeArmada
        {
            get
            {
                return _KodeArmada;
            }
            set
            {
                _KodeArmada = value;
            }
        }

        public string Kendaraan
        {
            get
            {
                return _Kendaraan;
            }
            set
            {
                _Kendaraan = value;
            }
        }

        public string NomorPolisi
        {
            get
            {
                return _NomorPolisi;
            }
            set
            {
                _NomorPolisi = value;
            }
        }


        public string TripMeterKM
        {
            get
            {
                return _TripMeterKM;
            }
            set
            {
                _TripMeterKM = value;
            }
        }

        public string KMPerLiter
        {
            get
            {
                return _KMPerLiter;
            }
            set
            {
                _KMPerLiter = value;
            }
        }

        public lookupArmadaKirim()
        {
            InitializeComponent();
        }

        private void commonTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ShowDialogForm();
            }
        }

        private void ShowDialogForm()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Lookup_ArmadaKirim"));
                    db.Commands[0].Parameters.Add(new Parameter("@str", SqlDbType.VarChar, commonTextBox1.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                frmArmadaKirimLookup ifrmDialog = new frmArmadaKirimLookup(dt);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetDialogResult(frmArmadaKirimLookup dialogForm)
        {
            this._KodeArmada = dialogForm._KodeArmada;
            this._Kendaraan = dialogForm._Kendaraan;
            this._NomorPolisi = dialogForm._NomorPolisi;
            this._TripMeterKM = dialogForm._TripMeterKM;
            this._KMPerLiter = dialogForm._KMPerLiter;
            commonTextBox1.Text = dialogForm._Kendaraan;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
    }
}
