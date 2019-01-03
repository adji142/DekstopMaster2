using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;

namespace ISA.Finance.Kasir
{
    public partial class frmBuktiBankKeluar : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowIDBBK = Guid.Empty;
        Guid _rowIDGiroIn = Guid.Empty;
        Guid _GiroID = Guid.Empty;
        Guid _rowIDBank;
        string _BankID, _NoBBK, _RecordIDBBK, _Penerima, _NamaBank, _CairTolak;
        DateTime _TglBBK;
        DataTable _dtGiroIn;
        public frmBuktiBankKeluar()
        {
            InitializeComponent();
        }

        public frmBuktiBankKeluar(Form caller)
        {
            
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();

        }

        public frmBuktiBankKeluar(Form caller,Guid RowIDBBK, string BankID)
        {
            _rowIDBBK = RowIDBBK;
            _BankID = BankID;
            this.Caller = caller;
            formMode = enumFormMode.Update;
            InitializeComponent();

        }

        private void GetInfoBBK()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName)) 
            {
                dt = Class.BBK.ListBBK(db, _rowIDBBK);
                 
            }

            _Penerima = Tools.isNull(dt.Rows[0]["Penerima"], "").ToString().Trim();
            _NamaBank = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString().Trim();
            _NoBBK = Tools.isNull(dt.Rows[0]["NoBBK"], "").ToString().Trim();
            _TglBBK = (DateTime)Tools.isNull(dt.Rows[0]["TglBBK"], "");
            _BankID = Tools.isNull(dt.Rows[0]["BankID"], "").ToString().Trim();
        }

        private void frmBuktiBankKeluar_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                lblTgl.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            }
            else if (formMode == enumFormMode.Update)
            {
                GetInfoBBK();
                txtKepada.Text = _Penerima;
                lookupBank1.NamaBank = _NamaBank;
                lookupBank1.BankID = _BankID;
                lblNo.Visible = true;
                lblNo.Text = _NoBBK;
                lblTgl.Text = _TglBBK.ToString("dd-MM-yyyy");
                

            }


            if (_rowIDBBK != Guid.Empty)
            {
                RefreshGiroInternalOnDetail();
                lblPetunjuk.Visible = true;
            }
            
        }

        private void AddBuktiBankKeluar()
        {
            _rowIDBBK = Guid.NewGuid();
            _BankID = lookupBank1.BankID;
            _NoBBK = Numerator.BookNumerator("BBK");
            _RecordIDBBK = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            _TglBBK = DateTime.Now.Date;
            _Penerima = txtKepada.Text;

            using (Database db = new Database(GlobalVar.DBName))
            {
                Class.BBK.AddBBK(db,
                    _rowIDBBK,
                    _RecordIDBBK,
                    _TglBBK,
                    _NoBBK,
                    _BankID,
                    string.Empty,
                    string.Empty,
                    _Penerima,
                    0,
                    0,
                    0);
            }

            lblNo.Visible = true;
            lblNo.Text = _NoBBK;


        }

        private void UpdateBuktiBankKeluar()
        {
            _Penerima = txtKepada.Text;
            _BankID = lookupBank1.BankID;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                db.Commands[0].Parameters.Add(new Parameter("@BankID", SqlDbType.VarChar, _BankID));
                db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, _Penerima));
                db.Commands[0].ExecuteNonQuery();
            }

        }

        private void GetInfoBank()
        {
            DataTable dt = new DataTable();
          
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Bank_LIST"));

                db.Commands[0].Parameters.Add(new Parameter("@bankID", SqlDbType.VarChar, _BankID));
                dt = db.Commands[0].ExecuteDataTable();
                _rowIDBank = (Guid)dt.Rows[0]["RowID"];
            }



        }


        private void GetInfoGiroInternal()
        {
            DataTable dt = new DataTable();
            _rowIDGiroIn = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["RowIDGiroIn"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST_ByRowID"));

                db.Commands[0].Parameters.Add(new Parameter("@RowIDGiroIn", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                dt = db.Commands[0].ExecuteDataTable();
            }

            _CairTolak = Tools.isNull(dt.Rows[0]["CairTolak"], "").ToString();


        }



        private void DeleteGiroInternal()
        {
            GetInfoBank();
            GetInfoGiroInternal();
            _GiroID = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {


                db.BeginTransaction();
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_DELETE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDGiroIn));
                db.Commands[0].ExecuteNonQuery();

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BBK_UPDATE"));

                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDBBK));
                db.Commands[0].Parameters.Add(new Parameter("@CairTolak", SqlDbType.VarChar, _CairTolak));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));

                db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, _GiroID));
                db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, _rowIDBank));
                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();


                db.CommitTransaction();
            }
        }


        private void frmBuktiBankKeluar_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblPetunjuk.Visible == true)
            {
                switch (e.KeyCode)
                {
                case Keys.Escape:

                    frmBukaGiro frm = new frmBukaGiro();
                    frm = (frmBukaGiro)this.Caller;
                    frm.RefreshBBK(_rowIDBBK);
                    frm.FindRowBBK("RowIDBBK", _rowIDBBK.ToString());
                    

                    break;

                    case Keys.Insert:

                    Kasir.frmBukaGiroDetailUpdate ifrmDetail1 = new Kasir.frmBukaGiroDetailUpdate(this, _rowIDBBK, txtKepada.Text, _BankID, false, _TglBBK);
                    Program.MainForm.RegisterChild(ifrmDetail1);
                    ifrmDetail1.ShowDialog();

                    break;

                    case Keys.Space:
                        if(gridGiroIn.SelectedCells.Count == 0 )
                        {
                            return;
                        }

                        _rowIDGiroIn = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["RowIDGiroIn"].Value;
                        _GiroID = (Guid)gridGiroIn.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                        Kasir.frmBukaGiroDetailUpdate ifrmDetail2 = new Kasir.frmBukaGiroDetailUpdate(this, _rowIDBBK, _rowIDGiroIn, _GiroID, txtKepada.Text, _BankID, false, _TglBBK);
                        Program.MainForm.RegisterChild(ifrmDetail2);
                        ifrmDetail2.ShowDialog();

                        break;

                    case Keys.Delete:
                        if (MessageBox.Show("Data Ini Akan Dihapus ?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }

                        DeleteGiroInternal();

                        #region "Tambahan"
                        int i = 0;
                        int n = 0;
                        i = gridGiroIn.SelectedCells[0].RowIndex;
                        n = gridGiroIn.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)gridGiroIn.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        dr.Delete();
                        _dtGiroIn.AcceptChanges();
                        gridGiroIn.Focus();
                        gridGiroIn.RefreshEdit();
                        if (gridGiroIn.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                gridGiroIn.CurrentCell = gridGiroIn.Rows[0].Cells[n];
                                gridGiroIn.RefreshEdit();
                            }
                            else
                            {
                                gridGiroIn.CurrentCell = gridGiroIn.Rows[i - 1].Cells[n];
                                gridGiroIn.RefreshEdit();
                            }

                        }
                        #endregion

                        frmBukaGiro frm2 = new frmBukaGiro();
                        frm2 = (frmBukaGiro)this.Caller;
                        frm2.FindRowGiroIn("RowIDGiroIn", _rowIDGiroIn.ToString());
                        frm2.refreshDeleteGiroIn();
                        

                        break;
                }
            }
        }

        public void RefreshGiroInternalOnDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _dtGiroIn = new DataTable();
                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBK", SqlDbType.UniqueIdentifier, _rowIDBBK));
                    _dtGiroIn = db.Commands[0].ExecuteDataTable();
                    
                }


                gridGiroIn.DataSource = _dtGiroIn;
                double total = Convert.ToDouble(ISA.Common.Tools.isNullOrEmpty(_dtGiroIn.Compute("SUM(Nominal)", string.Empty).ToString(),"0"));                
                nbTotal.Text = total.ToString("#,##0");
                

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void FindRowGiroInternalOnDetail(string column, string value)
        {
            gridGiroIn.FindRow(column, value);
        }

        private void lookupBank1_SelectData(object sender, EventArgs e)
        {
            try
            {
                if (lookupBank1.BankID == "" || lookupBank1.BankID == "[CODE]")
                {
                    MessageBox.Show("Bank Harus Diisi");
                    lookupBank1.Focus();
                    return;
                }

                if (txtKepada.Text == "")
                {
                    MessageBox.Show("Kepada Harus Diisi");
                    txtKepada.Focus();
                    return;
                }

                DateTime _Tanggal = DateTime.Now.Date;
                if (PeriodeClosing.IsKasirClosed(_Tanggal))
                {
                    MessageBox.Show("Sudah Closing!");
                    return;
                }
                if (MessageBox.Show("Data Sudah Benar ?","",MessageBoxButtons.OKCancel) == DialogResult.Cancel )
                {

                    return;
                }

                frmBukaGiro frm = new frmBukaGiro();
                frm = (frmBukaGiro)this.Caller;
                if (formMode == enumFormMode.New)
                {
                    AddBuktiBankKeluar();
                    frm.RefreshBBK(_rowIDBBK);
                    frm.FindRowBBK("RowIDBBK", _rowIDBBK.ToString());
                    RefreshGiroInternalOnDetail();
                }
                else
                {
                    UpdateBuktiBankKeluar();
                    frm.RefreshBBK(_rowIDBBK);
                }

                lblPetunjuk.Visible = true;
                gridGiroIn.Focus();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        public void RefreshGiroInternalOnDetail(Guid RowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_GiroInternal_LIST_ByRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowIDGiroIn", SqlDbType.UniqueIdentifier, RowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            gridGiroIn.RefreshDataRow(dtRefresh.Rows[0], "RowIDGiroIn", RowID.ToString());

            frmBukaGiro frm = new frmBukaGiro();
            frm = (frmBukaGiro)this.Caller;
            frm.RefreshBBK(_rowIDBBK);
            frm.RefreshGiroInternal(RowID);
            frm.FindRowGiroIn("RowIDGiroIn",RowID.ToString());
        }
    }
}
