using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;

namespace ISA.Trading.Persediaan
{
    public partial class frmStokOpnameDetailUpdate : ISA.Trading.BaseForm
    {

        private enum enumFormMode { New, Update };
        enumFormMode formMode;


        int Data;
        int a, b, c, d;
        int baik = 0, cacat = 0, rusak = 0;

        Guid _RowID, _HeaderID;
        string _TransactionID, _cRowNumber;

        string usp;

        private void Sum(int baik, int cacat, int rusak)
        {
            a = baik;
            b = cacat;
            c = rusak;
            d = a + b + c;
            txtTotal.Text = d.ToString();
        }

        private bool ValidateInsert()
        {
            bool result = false;
            DataTable dtResult;
            usp = "usp_ValidateOpnameDetail_INSERT";
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                db.Commands.Add(db.CreateCommand(usp));
                db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                db.Commands[0].Parameters.Add(new Parameter("@hitung", SqlDbType.Int, Data));

                dtResult = db.Commands[0].ExecuteDataTable();
            }

            if (dtResult.Rows.Count > 0)
            {
                result = true;
            }

            return result;
        }

        private void ADD()
        {
            if (ValidateInsert())
            {
                if (MessageBox.Show("Hitung " + Data.ToString() + " sudah diinput lebih dari satu. Simpan data?", "Simpan Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                    return;
                }
            }
          
            try
            {
                string _kodeBarang = lookupStock1.BarangID;
                DataTable dtopn = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Opname_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, _kodeBarang));
                    dtopn = db.Commands[0].ExecuteDataTable();
                }
                if (dtopn.Rows.Count > 0)
                {
                    _HeaderID = new Guid(dtopn.Rows[0]["RowID"].ToString());
                }

                usp = "usp_OpnameDetail" + Data.ToString() + "_INSERT";
                this.Cursor = Cursors.WaitCursor;
                _RowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand(usp));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, _TransactionID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoForm", SqlDbType.VarChar, txtNoForm.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, TglOpname.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Baik", SqlDbType.Int, txtBaik.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Cacat", SqlDbType.Int, txtCacat.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Rusak", SqlDbType.Int, txtRusak.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Pengguna", SqlDbType.VarChar, txtPenghitung.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    this.DialogResult = DialogResult.OK;
                    Persediaan.frmStokOpname frmcall = (Persediaan.frmStokOpname)this.Caller;
                    frmcall.FindHeader("RowID", _HeaderID.ToString());

                    if (Data.ToString() == "1")
                    {

                    }
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

        public void RefeshData()
        {
            Persediaan.frmStokOpname frmcaller = (Persediaan.frmStokOpname)this.Caller;
            frmcaller.RefreshDetail();
        }

        //public frmStokOpnameDetailUpdate(Form caller, int Grid, Guid RowID)
        //{
        //    _RowID = RowID;
        //    formMode = enumFormMode.Update;
        //    Data = Grid;
        //    this.Caller = caller;
        //    InitializeComponent();
        //}

        //public frmStokOpnameDetailUpdate(Form caller, int Grid, Guid RowID, string RecordID)
        //{

        //    formMode = enumFormMode.New;
        //    _HeaderID = RowID;
        //    _TransactionID = RecordID;
        //    Data = Grid;

        //    this.Caller = caller;
        //    InitializeComponent();
        //}

        public frmStokOpnameDetailUpdate(Form caller, int Grid, Guid RowID,string barang)
        {
            _RowID = RowID;
            formMode = enumFormMode.Update;
            Data = Grid;
            this.Caller = caller;
            InitializeComponent();
            label8.Text = barang;
        }

        public frmStokOpnameDetailUpdate(Form caller, int Grid, Guid RowID, string RecordID, string barang)
        {

            formMode = enumFormMode.New;
            _HeaderID = RowID;
            _TransactionID = RecordID;
            Data = Grid;

            this.Caller = caller;
            InitializeComponent();
            label8.Text = barang;
        }

        public frmStokOpnameDetailUpdate(Form caller, int Grid, Guid RowID, string RecordID, string barang, string cRowNumber)
        {

            formMode = enumFormMode.New;
            _HeaderID = RowID;
            _TransactionID = RecordID;
            _cRowNumber = cRowNumber;
            Data = Grid;

            this.Caller = caller;
            InitializeComponent();
            label8.Text = barang;
        }

        public frmStokOpnameDetailUpdate()
        {
            InitializeComponent();
        }

        private void StokOpnameDetailUpdate_Load(object sender, EventArgs e)
        {

            switch (formMode)
            {
                case enumFormMode.New:
                    {
                        TglOpname.DateValue = DateTime.Now;
                        txtNoForm.Text = _cRowNumber;
                        this.Title = "Hitung " + Data.ToString();
                        lookupStock1.Focus();
                        //txtBaik.Focus();
                        txtBaik.SelectAll();
                    }
                    break;
                case enumFormMode.Update:
                    {
                        try
                        {


                            usp = "usp_OpnameDetail" + Data.ToString() + "_LIST";
                            this.Title = "Hitung " + Data.ToString();
                            this.Cursor = Cursors.WaitCursor;
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand(usp));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                dt = db.Commands[0].ExecuteDataTable();

                                TglOpname.DateValue = (DateTime)dt.Rows[0]["TglOpname"];
                                txtNoForm.Text = Tools.isNull(dt.Rows[0]["NoForm"], "").ToString();
                                txtBaik.Text = Tools.isNull(dt.Rows[0]["Baik"], "0").ToString();
                                txtCacat.Text = Tools.isNull(dt.Rows[0]["Cacat"], "0").ToString();
                                txtRusak.Text = Tools.isNull(dt.Rows[0]["Rusak"], "0").ToString();
                                txtPenghitung.Text = Tools.isNull(dt.Rows[0]["Pengguna"], "").ToString();
                                baik = int.Parse(Tools.isNull(dt.Rows[0]["Baik"], "0").ToString());
                                cacat = int.Parse(Tools.isNull(dt.Rows[0]["Cacat"], "0").ToString());
                                rusak = int.Parse(Tools.isNull(dt.Rows[0]["Rusak"], "0").ToString());
                                Sum(baik, cacat, rusak);
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

                    break;
            }

            a = 0; b = 0; c = 0; d = 0;
        }

        private void txtBaik_Leave(object sender, EventArgs e)
        {
            baik = txtBaik.GetIntValue;
            Sum(baik, cacat, rusak);
        }

        private void txtCacat_Leave(object sender, EventArgs e)
        {
            cacat = txtCacat.GetIntValue;
            Sum(baik, cacat, rusak);
        }

        private void txtRusak_Leave(object sender, EventArgs e)
        {
            rusak = txtRusak.GetIntValue;
            Sum(baik, cacat, rusak);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            switch (formMode)
            {
                case enumFormMode.New:
                    this.ADD();
                    break;
                case enumFormMode.Update:
                    try
                    {
                        usp = "usp_OpnameDetail" + Data.ToString() + "_UPDATE";
                        this.Cursor = Cursors.WaitCursor;                        
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand(usp));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@NoForm", SqlDbType.VarChar, txtNoForm.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TglOpname", SqlDbType.DateTime, TglOpname.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Baik", SqlDbType.Int, baik));
                            db.Commands[0].Parameters.Add(new Parameter("@Cacat", SqlDbType.Int, cacat));
                            db.Commands[0].Parameters.Add(new Parameter("@Rusak", SqlDbType.Int, rusak));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengguna", SqlDbType.VarChar, txtPenghitung.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                            this.DialogResult = DialogResult.OK;
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
                    break;
            }

            switch (formMode)
            {
                case enumFormMode.New:
                    this.DialogResult = DialogResult.OK;
                    //RefeshData();
                    //this.Close();

                    break;
                case enumFormMode.Update:
                    //MessageBox.Show("Data telah Di Update");
                    this.DialogResult = DialogResult.OK;
                    //RefeshData();
                    //this.Close();
                    break;
            }
            RefeshData();
            this.Close();
            this.Dispose();
            //cmdCancel.PerformClick();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void StokOpnameDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.DialogResult == DialogResult.OK)
            //{
            //    if (this.Caller is frmStokOpname)
            //    {
            //        frmStokOpname frmCaller = (frmStokOpname)this.Caller;
            //        frmCaller.RefreshDetail();
            //        switch (Data)
            //        {
            //            case 1: frmCaller.FindDetail1("RowID1", _RowID.ToString());
            //                break;
            //            case 2: frmCaller.FindDetail2("RowID2", _RowID.ToString());
            //                break;
            //            case 3: frmCaller.FindDetail3("RowID3", _RowID.ToString());
            //                break;

            //        }
                    
            //    }
            //}
        }

        private void txtPenghitung_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    cmdSave.PerformClick();
            //}
        }
    }
}
