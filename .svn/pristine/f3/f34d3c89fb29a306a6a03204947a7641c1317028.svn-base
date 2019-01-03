using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISA.Toko.Controls
{
    public partial class LookupJadwalExpedisi : UserControl
    {
        Guid _rowID;
        DateTime _DateAwal, _DateAkhir;
        public event EventHandler SelectData;

        public DateTime TglRQ
        {
            get;
            set;
        }

        public string KdGdg
        {
            get;
            set;
        }

        public Guid RowID
        {
            get
            {
                return _rowID;
            }
            set
            {
                _rowID = value;
            }
        }

        public LookupJadwalExpedisi()
        {
            InitializeComponent();
        }

        private void ShowDialogForm()
        {
            frmJadwalExpedisiLookup ifrmDialog = new frmJadwalExpedisiLookup(this.TglRQ,this.KdGdg);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmJadwalExpedisiLookup dialogForm)
        {

            _DateAwal = dialogForm.tglAwal;
            _DateAkhir = dialogForm.tglAkhir;
            _rowID = dialogForm.guidRowID;
            
            txtLookupName.Text = dialogForm.txtPeriode;
            TxtFromTo.Text = dialogForm.stringDate;
            labelRowID.Text = dialogForm.guidRowID.ToString();

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }


        private void cmdLookup_Click(object sender, EventArgs e)
        {
            ShowDialogForm();
        }
    }
}
