using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmBuktiTransferKeluarUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowIDTransferBank,_rowIDBank;
        string _recordIDTransferBank = string.Empty, _recordIDTransferBank2 = string.Empty;        
        bool _isFromPiutang;
        string _name;
        string _nip = string.Empty;
        string _jp = string.Empty;
        string _reff;
        string _noreff;
        string _cmbJU;
        string _BankID;
        double total;
        DataTable dt=new DataTable();
        DataTable dtH = new DataTable();
        
        public frmBuktiTransferKeluarUpdate(Form Caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = Caller;
        }


        public frmBuktiTransferKeluarUpdate(Form Caller, Guid RowID, bool isFromPiutang, string jp, string reff, string noreff,string nip)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowIDTransferBank = RowID;
            _isFromPiutang = isFromPiutang;
            _jp = jp;
            _reff = reff;
            _cmbJU = reff;
            _noreff = noreff;
            _nip = nip;
            this.Caller = Caller;
        }

        public frmBuktiTransferKeluarUpdate(Form Caller,string name, bool isFromPiutang, string nip,string jp,string cmbJU)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            _name = name;
            _isFromPiutang = isFromPiutang;
            _nip = nip;
            _jp = jp;
            _cmbJU = cmbJU;
            this.Caller = Caller;

        }

        public frmBuktiTransferKeluarUpdate()
        {
            InitializeComponent();
        }

        

        private void AddTransaksi()
        {
            _rowIDTransferBank = Guid.NewGuid();
            _recordIDTransferBank = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
            string penyetor = txtKepada.Text;            
            string kasir = SecurityManager.UserID;
            string noBBK = string.Empty;
            string MK = string.Empty;
            string dibukukan = string.Empty;
            string diketahui = string.Empty;            
            string namaBank = lookupBank1.NamaBank;
            string bankID = lookupBank1.BankID;

            if (_isFromPiutang == true)
            {

                if (_cmbJU == "TRK")
                {
                    noBBK = Numerator.BookNumeratorNew("BBK");
                    MK = "K";
                    _recordIDTransferBank = _recordIDTransferBank.Trim() + "1";

                }
                else if (_cmbJU == "TRM")
                {
                    noBBK = Numerator.BookNumeratorNew("BBM");
                    MK = "M";
                    _recordIDTransferBank = _recordIDTransferBank.Trim() + "2";
                }
                

            }
            else
            {
                noBBK = Numerator.BookNumeratorNew("BBK");
                MK = "K";
                _recordIDTransferBank = _recordIDTransferBank.Trim() + "4";
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                                        
                    Class.TransferBank.addHeader(db,
                        _rowIDTransferBank,
                        _rowIDTransferBank,
                        _recordIDTransferBank,
                        DateTime.Now.Date,
                        noBBK,
                        MK,
                        bankID,
                        namaBank,
                        dibukukan,
                        diketahui,
                        SecurityManager.UserID,
                        penyetor);

                    if (_isFromPiutang == true)
                    {
                        _recordIDTransferBank2 = _recordIDTransferBank.Substring(0, 22) + _jp;
                        Class.TransferBank.AddPinjamanPegawai(
                                db,
                                _rowIDTransferBank,
                                _recordIDTransferBank2,
                                _nip,
                                DateTime.Now.Date,
                                _cmbJU,
                                noBBK,
                                penyetor,
                                string.Empty,
                                0,
                                0,
                                _jp);
                    }
                }
                
                lblNoBkk.Visible = true;
                lblNoBkk.Text = noBBK;
                txtKepada.Enabled = true;
                lookupBank1.Enabled = false;                               
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

        private void UpdateTransaksi()
        {
            string penyetor = txtKepada.Text;            

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_TransferBank_UPDATE"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowIDTransferBank));                    
                    db.Commands[0].Parameters.Add(new Parameter("@Penyetor", SqlDbType.VarChar, penyetor));                    
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                    

                }
              
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

        private void frmBuktiTransferKeluarUpdate_Load(object sender, EventArgs e)
        {
            
            double Total = 0;
            if (formMode == enumFormMode.Update)
            {
                dt = new DataTable();
                dtH = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    //db.Commands.Add(db.CreateCommand("usp_BuktiTransferKeluarShowForUpdateHeader"));

                    dtH = TransferBank.ListHeaderRow(_rowIDTransferBank, "K");
                    dt = TransferBank.ListDetail(db, _rowIDTransferBank);

                    
                        gridTransfer.DataSource = dt.DefaultView;
                    

                    if (_isFromPiutang == false)
                    {
                        Total = Convert.ToDouble(ISA.Common.Tools.isNullOrEmpty(dt.Compute("SUM(Nominal)", string.Empty).ToString(), "0"));
                        _BankID = dtH.Rows[0]["BankID"].ToString();
                        _recordIDTransferBank = dtH.Rows[0]["RecordID"].ToString();
                        _rowIDBank = (Guid)dtH.Rows[0]["RowIDBank"];
                        lookupBank1.NamaBank = dtH.Rows[0]["NamaBank"].ToString();
                        lookupBank1.BankID = _BankID;
                        txtKepada.Text = dtH.Rows[0]["Penyetor"].ToString().Trim();
                        lblNoBkk.Text = dtH.Rows[0]["NoBBM"].ToString();
                        lblTanggal.Text = ((DateTime)dtH.Rows[0]["TglBBM"]).ToString("dd-MM-yyyy");
                        lblNoBkk.Visible = false;
                    }
                    else
                    {
                        Total = Convert.ToDouble(ISA.Common.Tools.isNullOrEmpty(dt.Compute("SUM(Nominal)", string.Empty).ToString(), "0"));                                               
                        txtKepada.Text = dtH.Rows[0]["Penyetor"].ToString().Trim();
                        lookupBank1.NamaBank = dtH.Rows[0]["NamaBank"].ToString();
                        lookupBank1.BankID = _BankID;
                        _BankID = dtH.Rows[0]["BankID"].ToString();
                        _recordIDTransferBank = dtH.Rows[0]["RecordID"].ToString();
                        _recordIDTransferBank2 = _recordIDTransferBank.Substring(0, 22) + _jp;
                        lblNoBkk.Text = dtH.Rows[0]["NoBBM"].ToString();
                        _rowIDBank = (Guid)dtH.Rows[0]["RowIDBank"];
                        txtKepada.Enabled = false;
                        lookupBank1.Enabled = false;
                        lblNoBkk.Visible = true;
                        lblTanggal.Text = ((DateTime)dtH.Rows[0]["TglBBM"]).ToString("dd-MM-yyyy");
                    }
                }

            }
            else
            {
                if (_isFromPiutang == true)
                {
                    txtKepada.Text = _name.Trim();
                }
                lblNoBkk.Visible = false;
                lblTanggal.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            }


            numericTextBox1.Text = Total.ToString("#,##0");
 
            
            
            
        }

        //public void RefreshRowData()
        //{
        //    double Total = 0;
        //    try
        //    {
        //        DataTable dtHeader = new DataTable();
        //        this.Cursor = Cursors.WaitCursor;
        //        using (Database db = new Database(GlobalVar.DBFinance))
        //        {                    
        //            //db.Commands.Add(db.CreateCommand("usp_BuktiTransferDetail_AfterFillDetail"));
        //            db.Commands.Add(db.CreateCommand("usp_TransferBankDetail_LIST"));
        //            db.Commands[0].Parameters.Add(new Parameter("@NoBBK", SqlDbType.VarChar, lblNoBkk.Text));                    
        //            dtHeader = db.Commands[0].ExecuteDataTable();
        //            gridTransfer.DataSource = dtHeader;

        //            Total = Convert.ToDouble(dtHeader.Compute("SUM(Nominal)", string.Empty));
        //        }



        //        numericTextBox1.Text = Total.ToString();
                
                
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }

        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        public void RefreshRowData(Guid rowIDDetail)
        {
            DataTable dtRefresh = new DataTable();
            dtRefresh = TransferBank.ListDetailRow(rowIDDetail);
            gridTransfer.RefreshDataRow(dtRefresh.Rows[0], "RowIDDetail", rowIDDetail.ToString());
        }

        public void FindRowData(string column, string value)
        {
            gridTransfer.FindRow(column, value);

        }

        private void lookupBank1_SelectData(object sender, EventArgs e)
        {
            if (lookupBank1.BankID == "" || lookupBank1.BankID == "[CODE]")
            {
                MessageBox.Show("Bank belum diisi");
                lookupBank1.Focus();
                return;
            }

            if (txtKepada.Text == "")
            {
                MessageBox.Show("Nama Belum Diisi");
                txtKepada.Focus();
                return;
            }

            if (MessageBox.Show("Data Sudah Benar ?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                switch (formMode)
                {
                case enumFormMode.New :
                        DateTime _Tanggal = DateTime.Now.Date;
                        if (PeriodeClosing.IsKasirClosed(_Tanggal))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                        AddTransaksi();
                        lblPetunjuk.Visible = true;
                	break;
                 case enumFormMode.Update:
                    UpdateTransaksi();
                    lblPetunjuk.Visible = true;
                        break;
                }

              
                        
            }
            catch
            {
              MessageBox.Show("GAGAL");
            }                    
                    
                
        }

        private void frmBuktiTransferKeluarUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_rowIDTransferBank.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                if (_isFromPiutang == false)
                {
                    Kasir.frmBuktiTransferKeluar frmCaller = (Kasir.frmBuktiTransferKeluar)this.Caller;
                    frmCaller.RefreshRowBuktiTransfer(_rowIDTransferBank);
                    if(formMode==enumFormMode.New)
                        frmCaller.FindRowHeader("RowID", _rowIDTransferBank.ToString());
                    frmCaller.RefreshBuktiTransferDetail();
                }
                else
                {

                    Kasir.frmPiutangKaryawan frmUtang = new Kasir.frmPiutangKaryawan();
                    frmUtang = (frmPiutangKaryawan)this.Caller;
                    frmUtang.RefreshPegawai(_nip);
                    frmUtang.FindRowPegawsai("NIP", _nip);
                    frmUtang.RefreshPiutang(_rowIDTransferBank);
                    frmUtang.FindRowPiutang("RowID", _rowIDTransferBank.ToString());
                }
            }
                    
        }


        private void frmBuktiTransferKeluarUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    if (_rowIDTransferBank != Guid.Empty)
                    {
                        string nmrBBK = string.Empty;

                        string recordIDDetail = string.Empty;
                        nmrBBK = lblNoBkk.Text;
                        total = numericTextBox1.GetDoubleValue;

                        if (lookupBank1.BankID != "[CODE]")
                        {
                            _BankID = lookupBank1.BankID;
                        }

                        if (_isFromPiutang == false)
                        {
                            Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, _recordIDTransferBank, _rowIDTransferBank, total, false, string.Empty, string.Empty, _cmbJU, nmrBBK, _BankID);
                            Program.MainForm.RegisterChild(ifrmDetail);
                            ifrmDetail.ShowDialog();
                        }
                        else
                        {


                            if (_cmbJU == "TRK")
                            {
                                Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail2 = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, _recordIDTransferBank2, _rowIDTransferBank, total, true, _nip, _jp, _cmbJU, nmrBBK, _BankID);
                                Program.MainForm.RegisterChild(ifrmDetail2);
                                ifrmDetail2.ShowDialog();
                            }
                            else if (_cmbJU == "TRM")
                            {
                                Kasir.frmBuktiTransferMasukDetailUpdate ifrmDetail3 = new Kasir.frmBuktiTransferMasukDetailUpdate(this, _recordIDTransferBank2, _rowIDTransferBank, _BankID, total, _nip, _jp, _cmbJU, nmrBBK);
                                Program.MainForm.RegisterChild(ifrmDetail3);
                                ifrmDetail3.ShowDialog();
                            }

                        }
                    }
                    break;
                case Keys.Space:
                    if (gridTransfer.Focused == true)
                    {
                        if (gridTransfer.SelectedCells.Count > 0)
                        {
                            Guid rowIDTransferBankDetail = (Guid)gridTransfer.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;


                            if (_isFromPiutang == false)
                            {
                                Kasir.frmBuktiTransferKeluarDetailUpdate ifrmUpdate = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, rowIDTransferBankDetail, Guid.Empty, string.Empty, false, _reff, _noreff, string.Empty);
                                Program.MainForm.RegisterChild(ifrmUpdate);
                                ifrmUpdate.ShowDialog();
                            }
                            else
                            {

                                if (_cmbJU == "TRK")
                                {
                                    Kasir.frmBuktiTransferKeluarDetailUpdate ifrmUpdate1 = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, rowIDTransferBankDetail, _rowIDTransferBank, _recordIDTransferBank2, true, _reff, _noreff, _jp);
                                    Program.MainForm.RegisterChild(ifrmUpdate1);
                                    ifrmUpdate1.ShowDialog();
                                }
                                else if (_cmbJU == "TRM")
                                {
                                    Kasir.frmBuktiTransferMasukDetailUpdate ifrmUpdate2 = new Kasir.frmBuktiTransferMasukDetailUpdate(this, rowIDTransferBankDetail, _rowIDTransferBank, _recordIDTransferBank2);
                                    Program.MainForm.RegisterChild(ifrmUpdate2);
                                    ifrmUpdate2.ShowDialog();
                                }


                            }


                        }
                        else
                        {
                            MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;

                case Keys.Delete:

                    if (gridTransfer.SelectedCells.Count > 0)
                    {
                        Guid rowIDTransferBankDetail = (Guid)gridTransfer.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                        if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (Database db = new Database(GlobalVar.DBFinance))
                            {
                                if (_isFromPiutang == false)
                                {
                                    db.BeginTransaction();
                                    Class.TransferBank.DeleteDetail(db, rowIDTransferBankDetail);

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowIDTransferBankDetail));
                                    db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier,_rowIDBank ));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }
                                else
                                {
                                    db.BeginTransaction();
                                    db.Commands.Clear();
                                    Class.TransferBank.DeleteDetail(db, rowIDTransferBankDetail);

                                    Class.TransferBank.UpdateUraianPinjaman(db, _rowIDTransferBank);

                                    db.Commands.Clear();
                                    db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowIDTransferBankDetail));
                                    db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, _rowIDBank));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }


                            }
                            gridTransfer.Rows.Remove(gridTransfer.SelectedCells[0].OwningRow);
                            #region "Tambahan"
                            int i = 0;
                            int n = 0;
                            i = gridTransfer.SelectedCells[0].RowIndex;
                            n = gridTransfer.SelectedCells[0].ColumnIndex;
                            DataRowView dv = (DataRowView)gridTransfer.SelectedCells[0].OwningRow.DataBoundItem;

                            DataRow dr = dv.Row;

                            dr.Delete();
                            dt.AcceptChanges();
                            gridTransfer.Focus();
                            gridTransfer.RefreshEdit();
                            if (gridTransfer.RowCount > 0)
                            {
                                if (i == 0)
                                {
                                    gridTransfer.CurrentCell = gridTransfer.Rows[0].Cells[n];
                                    gridTransfer.RefreshEdit();
                                }
                                else
                                {
                                    gridTransfer.CurrentCell = gridTransfer.Rows[i - 1].Cells[n];
                                    gridTransfer.RefreshEdit();
                                }

                            }
                            #endregion
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    break;

                case Keys.Escape:
                    this.Close();

                    break;

            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (_rowIDTransferBank != Guid.Empty)
            {
                string nmrBBK = string.Empty;

                string recordIDDetail = string.Empty;
                nmrBBK = lblNoBkk.Text;
                total = numericTextBox1.GetDoubleValue;

                if (lookupBank1.BankID != "[CODE]")
                {
                    _BankID = lookupBank1.BankID;
                }

                if (_isFromPiutang == false)
                {
                    Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, _recordIDTransferBank, _rowIDTransferBank, total, false, string.Empty, string.Empty, _cmbJU, nmrBBK, _BankID);
                    Program.MainForm.RegisterChild(ifrmDetail);
                    ifrmDetail.ShowDialog();
                }
                else
                {


                    if (_cmbJU == "TRK")
                    {
                        Kasir.frmBuktiTransferKeluarDetailUpdate ifrmDetail2 = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, _recordIDTransferBank2, _rowIDTransferBank, total, true, _nip, _jp, _cmbJU, nmrBBK, _BankID);
                        Program.MainForm.RegisterChild(ifrmDetail2);
                        ifrmDetail2.ShowDialog();
                    }
                    else if (_cmbJU == "TRM")
                    {
                        Kasir.frmBuktiTransferMasukDetailUpdate ifrmDetail3 = new Kasir.frmBuktiTransferMasukDetailUpdate(this, _recordIDTransferBank2, _rowIDTransferBank, _BankID, total, _nip, _jp, _cmbJU, nmrBBK);
                        Program.MainForm.RegisterChild(ifrmDetail3);
                        ifrmDetail3.ShowDialog();
                    }

                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (gridTransfer.SelectedCells.Count > 0)
            {
                Guid rowIDTransferBankDetail = (Guid)gridTransfer.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;


                if (_isFromPiutang == false)
                {
                    Kasir.frmBuktiTransferKeluarDetailUpdate ifrmUpdate = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, rowIDTransferBankDetail, Guid.Empty, string.Empty, false, _reff, _noreff, string.Empty);
                    Program.MainForm.RegisterChild(ifrmUpdate);
                    ifrmUpdate.ShowDialog();
                }
                else
                {

                    if (_cmbJU == "TRK")
                    {
                        Kasir.frmBuktiTransferKeluarDetailUpdate ifrmUpdate1 = new Kasir.frmBuktiTransferKeluarDetailUpdate(this, rowIDTransferBankDetail, _rowIDTransferBank, _recordIDTransferBank2, true, _reff, _noreff, _jp);
                        Program.MainForm.RegisterChild(ifrmUpdate1);
                        ifrmUpdate1.ShowDialog();
                    }
                    else if (_cmbJU == "TRM")
                    {
                        Kasir.frmBuktiTransferMasukDetailUpdate ifrmUpdate2 = new Kasir.frmBuktiTransferMasukDetailUpdate(this, rowIDTransferBankDetail, _rowIDTransferBank, _recordIDTransferBank2);
                        Program.MainForm.RegisterChild(ifrmUpdate2);
                        ifrmUpdate2.ShowDialog();
                    }


                }


            }
            else
            {
                MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (gridTransfer.SelectedCells.Count > 0)
            {
                Guid rowIDTransferBankDetail = (Guid)gridTransfer.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        if (_isFromPiutang == false)
                        {
                            db.BeginTransaction();
                            Class.TransferBank.DeleteDetail(db, rowIDTransferBankDetail);

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowIDTransferBankDetail));
                            db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, _rowIDBank));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }
                        else
                        {
                            db.BeginTransaction();
                            db.Commands.Clear();
                            Class.TransferBank.DeleteDetail(db, rowIDTransferBankDetail);

                            Class.TransferBank.UpdateUraianPinjaman(db, _rowIDTransferBank);

                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_BankDetail_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowIDDetail", SqlDbType.UniqueIdentifier, rowIDTransferBankDetail));
                            db.Commands[0].Parameters.Add(new Parameter("@headerIDBank1", SqlDbType.UniqueIdentifier, _rowIDBank));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();
                        }


                    }
                    gridTransfer.Rows.Remove(gridTransfer.SelectedCells[0].OwningRow);
                    #region "Tambahan"
                    int i = 0;
                    int n = 0;
                    i = gridTransfer.SelectedCells[0].RowIndex;
                    n = gridTransfer.SelectedCells[0].ColumnIndex;
                    DataRowView dv = (DataRowView)gridTransfer.SelectedCells[0].OwningRow.DataBoundItem;

                    DataRow dr = dv.Row;

                    dr.Delete();
                    dt.AcceptChanges();
                    gridTransfer.Focus();
                    gridTransfer.RefreshEdit();
                    if (gridTransfer.RowCount > 0)
                    {
                        if (i == 0)
                        {
                            gridTransfer.CurrentCell = gridTransfer.Rows[0].Cells[n];
                            gridTransfer.RefreshEdit();
                        }
                        else
                        {
                            gridTransfer.CurrentCell = gridTransfer.Rows[i - 1].Cells[n];
                            gridTransfer.RefreshEdit();
                        }

                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Belum Ada Data", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void gridTransfer_Enter(object sender, EventArgs e)
        {
            //cmdAdd.Enabled = true;
            //cmdEdit.Enabled = true;
            //cmdDelete.Enabled = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            AddTransaksi();
        }


        

        

    }
}
