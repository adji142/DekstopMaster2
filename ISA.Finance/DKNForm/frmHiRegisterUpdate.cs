using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.DKNForm
{
    public partial class frmHiRegisterUpdate : ISA.Finance.BaseForm
    {
        enum enumModus { New, Update };
        enum enumBrow { Header, Detail };
        enumModus Modus;
        enumBrow Brow;
        Guid _HeaderID, _DetailID;
        DataTable dtPerkiraan;

        public frmHiRegisterUpdate(Form Caller)
        {
            InitializeComponent();
            Modus = enumModus.New;
            Brow = enumBrow.Header;
            this.Caller = Caller;
        }

        public frmHiRegisterUpdate(Form Caller, Guid HeaderID)
        {
            InitializeComponent();
            Modus = enumModus.Update;
            Brow = enumBrow.Header;
            _HeaderID = HeaderID;
            this.Caller = Caller;
        }
        public frmHiRegisterUpdate(Form Caller, Guid HeaderID, Guid DetailID)
        {
            InitializeComponent();
            Brow = enumBrow.Detail;
            if (DetailID == Guid.Empty) Modus = enumModus.New;
            else Modus = enumModus.Update;
            _HeaderID = HeaderID;
            _DetailID = DetailID;
            this.Caller = Caller;
        }

        private void frmHiRegisterUpdate_Load(object sender, EventArgs e)
        {
            IsiComboCabang();
            RefreshHeader();
            RefreshDetail();
        }

        private void IsiComboCabang()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DKNCabang_LIST"));
                cboCabang.DataSource = db.Commands[0].ExecuteDataTable();
                cboCabang.DisplayMember = "KodeCabang";
                cboCabang.ValueMember = "KodeCabang";
            }
        }

        private void RefreshHeader()
        {
            if (Brow == enumBrow.Header && Modus == enumModus.New)
            {
                dateDKN.DateValue = DateTime.Today;
                cboCabang.Text = "";
            }
            else
            {
                frmHiRegisterBrowse frmCaller = (frmHiRegisterBrowse)this.Caller;
                dateDKN.DateValue = Convert.ToDateTime(frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                txtNoDKN.Text = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["No_dkn"].Value.ToString();
                cboCabang.SelectedValue = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString();
                optDebet.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "D";
                optKredit.Checked = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["Dk"].Value.ToString() == "K";
            }
            cboCabang.Enabled = Brow == enumBrow.Header;
            txtPerkiraan.Enabled = Brow == enumBrow.Detail;
            txtUraian.Enabled = Brow == enumBrow.Detail;
            numJumlah.Enabled = Brow == enumBrow.Detail;
        }

        private void RefreshDetail()
        {
            frmHiRegisterBrowse frmCaller = (frmHiRegisterBrowse)this.Caller;
            if (Brow == enumBrow.Header || Modus == enumModus.New)
            {
                txtPerkiraan.NoPerkiraan = "";
                txtUraian.Text = "";
                numJumlah.Text = Convert.ToString(0);
            }
            else
            {
                txtPerkiraan.NoPerkiraan = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["No_perk"].Value.ToString();
                txtUraian.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Uraian"].Value.ToString();
                numJumlah.Text = frmCaller.gridDetail.SelectedCells[0].OwningRow.Cells["Jumlah"].Value.ToString();
                dtPerkiraan = Class.Perkiraan.GetPerkiraan(txtPerkiraan.NoPerkiraan);
                DataRow dr = dtPerkiraan.Rows[0];
                txtPerkiraan.NamaPerkiraan = dr["NamaPerkiraan"].ToString();
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            frmHiRegisterBrowse frmCaller = (frmHiRegisterBrowse)this.Caller;
            
            if (Brow == enumBrow.Header)
            {
                Guid RowID = Guid.NewGuid();
                string RecordID = GlobalVar.PerusahaanID + DateTime.Today.ToString();
                DateTime TglBukti = Convert.ToDateTime(dateDKN.DateValue);
                string Cabang = cboCabang.SelectedValue.ToString();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (Modus == enumModus.Update) RowID = _HeaderID;
                    DKN.HIInsert(db, RowID, RecordID, "D", "MAN", "B", "DKN", TglBukti, Cabang, "", RowID);
                }
                frmCaller.RefreshDkn();
            }
            else
            {
                string NoPerkiraan = txtPerkiraan.NoPerkiraan;
                string Uraian = txtUraian.Text;
                string HRecordID = frmCaller.gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
                string refRecordID = GlobalVar.PerusahaanID + DateTime.Today.ToString();
                Guid refRowID = Guid.NewGuid();
                Double Jumlah = Convert.ToDouble(numJumlah.Text);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    if (Modus == enumModus.Update) refRowID = _DetailID;

                    DKN.HIDetailInsert(db, _HeaderID, HRecordID, NoPerkiraan, Uraian, Jumlah, refRowID, refRecordID);
                }
                frmCaller.RefreshDknDetail();
            }
            this.Close();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
