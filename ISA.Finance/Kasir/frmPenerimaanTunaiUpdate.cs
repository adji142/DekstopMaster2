using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.Data.SqlTypes;
using ISA.Finance.Class;
using System.Globalization;

namespace ISA.Finance.Kasir
{
    public partial class frmPenerimaanTunaiUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;        
        string CollectorID = "", NamaCollector = "";

        public event EventHandler SelectData;

        public frmPenerimaanTunaiUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPenerimaanTunaiUpdate(Form caller, Guid RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _RowID = RowID;
            this.Caller = caller;
        }

        private void frmPenerimaanTunaiUpdate_Load(object sender, EventArgs e)
        {
            tbTanggalTerima.DateValue = DateTime.Now;   // GlobalVar.DateOfServer;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            double _Nominal = double.Parse(tbNominal.Text);
            string _NomorTransaksi, _PublicKey;
            if (CollectorID == "")
            {
                MessageBox.Show("Collector belum diisi");
                tbCollector.Focus();
                return;
            }

            if (_Nominal == 0)
            {
                MessageBox.Show("Nominal belum diisi");
                tbNominal.Focus();
                return;
            }
            int mingguKe;
            string Gudang;


            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date = Convert.ToDateTime(GlobalVar.DateTimeOfServer);
            Calendar cal = dfi.Calendar;
            mingguKe = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            Gudang = GlobalVar.Gudang;
            string jam = date.ToString("HHmmss");

            _NomorTransaksi = Numerator.BookNumerator("PTU");
            //_PublicKey = Tools.pin(Convert.ToInt32(jam), mingguKe, date, PinId.Bagian.Keuangan, Convert.ToInt32(PinId.ModulId.PenerimaanTunai), Gudang);
           // _PublicKey = Tools.pin(Convert.ToInt32(jam), mingguKe, date, 12, Convert.ToInt32(PinId.ModulId.TempoSpesial), Gudang); //12 merupakan kode bagian dari PIN di menu penerimaan tunai

            string penerimaaninput_tunai = Class.AppSetting.GetValue("penerimaantunai_input");
            if (penerimaaninput_tunai != "true") {
                if (CollectorID != penerimaaninput_tunai)
                {
                    MessageBox.Show("Hanya boleh input penerimaan via paycoll");
                    return;
                }
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenerimaanTunai_INSERT"));
                            _RowID = Guid.NewGuid();
                            _PublicKey = Tools.GetKey(_RowID.ToString(), Gudang, 12); //12 merupakan kode bagian dari PIN di menu penerimaan tunai
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NomorTransaksi", SqlDbType.VarChar,_NomorTransaksi ));
                            db.Commands[0].Parameters.Add(new Parameter("@TanggalTerima", SqlDbType.DateTime, (DateTime)tbTanggalTerima.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, CollectorID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nominal", SqlDbType.Money, tbNominal.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@PublicKey", SqlDbType.VarChar, _PublicKey));
                            db.Commands[0].Parameters.Add(new Parameter("@CreatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                            dt = db.Commands[0].ExecuteDataTable();

                        }
                        break;                   
                        
                }
                this.DialogResult = DialogResult.OK;
                FormClose();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }


            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClose()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmPenerimaanTunai frmCaller = (frmPenerimaanTunai)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindRow(_RowID);
            }
        }

        private void tbCollector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lookupCollectorDialog();
            }
        }

        private void lookupCollectorDialog()
        {
            frmLookupCollector ifrmDialog = new frmLookupCollector(tbCollector.Text);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmLookupCollector dialogForm)
        {
            this.CollectorID = dialogForm.KodeCollector;
            this.NamaCollector = dialogForm.NamaCollector;
            tbCollector.Text = NamaCollector;

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }

        }

    }
}
