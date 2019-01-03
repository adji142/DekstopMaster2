using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Persediaan
{
    public partial class frmStandarStokHitungStandar : ISA.Toko.BaseForm
    {


        #region "Var & Function"
        public enum enumFormMode { One, All };
        enumFormMode formMode;

        string _KodeBarang, _NamaStok, _KodeRak, _KodeRak1, _KodeRak2, _SatSolo, _Bundle, _Kendaraan, _SatJual;
        Guid _RowID, RowIDStok;
        bool _StatusPasif;
        int _AVG, lamaKirim, hariRata2;


        public frmStandarStokHitungStandar(Form caller, string KodeBarang, int AVG)
        {
            formMode = enumFormMode.One;
            _AVG = AVG;
            _KodeBarang = KodeBarang;
            this.Caller = caller;
            InitializeComponent();
            DataStok(_KodeBarang);
        }


        public frmStandarStokHitungStandar(Form caller)
        {
            formMode = enumFormMode.All;
            this.Caller = caller;
            InitializeComponent();
        }

        private void RefreshData()
        {
            frmStandarStok frmCaller = (frmStandarStok)this.Caller;
            frmCaller.RefreshData1(_KodeBarang);
            
        }

        private void InsertAllRecord()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    db.Commands.Add(db.CreateCommand("psp_StandarStok_CalculateAll"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMT", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@Var1", SqlDbType.Float, txtMin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Var2", SqlDbType.Float, txtMax.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

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

        private void InsertRecord()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    lamaKirim = txtLamaKirim.GetIntValue;

                    db.Commands.Add(db.CreateCommand("usp_StandarStok_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, _KodeBarang));
                    db.Commands[0].Parameters.Add(new Parameter("@TglMT", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@Var1", SqlDbType.Float, txtMin.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Var2", SqlDbType.Float, txtMax.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@AVGHari", SqlDbType.Float, _AVG));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    db.Commands.Add(db.CreateCommand("usp_Stok_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, RowIDStok));
                    db.Commands[1].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _KodeBarang));
                    db.Commands[1].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, _NamaStok));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeRak", SqlDbType.VarChar, _KodeRak));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeRak1", SqlDbType.VarChar, _KodeRak1));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeRak2", SqlDbType.VarChar, _KodeRak2));
                    db.Commands[1].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, _SatJual));
                    db.Commands[1].Parameters.Add(new Parameter("@satSolo", SqlDbType.VarChar, _SatSolo));
                    db.Commands[1].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, _StatusPasif));
                    db.Commands[1].Parameters.Add(new Parameter("@prediksiLamaKirim", SqlDbType.Int, txtLamaKirim.Text));
                    db.Commands[1].Parameters.Add(new Parameter("@hariRataRata", SqlDbType.Int, txtHariRata2.Text));
                    db.Commands[1].Parameters.Add(new Parameter("@bundle", SqlDbType.VarChar, _Bundle));
                    db.Commands[1].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, _Kendaraan));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[1].ExecuteNonQuery();

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

        #endregion

        public frmStandarStokHitungStandar()
        {
            InitializeComponent();
        }

        private void frmStandarStokHitungStandar_Load(object sender, EventArgs e)
        {
            txtTgl.DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtTgl.ReadOnly = true;
            switch (formMode)
            {
                case enumFormMode.One:
                    _RowID = Guid.NewGuid();
                    this.Title = "Proses Perhitungan Perhitungan Item Per Barang";
                    break;
                case enumFormMode.All:
                    this.Title = "Proses Perhitungan Perhitungan Semua Item Barang";
                    break;
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {

            if (txtMax.GetDoubleValue <= 0 || txtMax.GetDoubleValue<txtMin.GetDoubleValue)
            {
                txtMax.Focus();
                return;
            }

            if (txtMin.GetDoubleValue <= 0 || txtMin.GetDoubleValue>txtMax.GetDoubleValue)
            {
                txtMin.Focus();
                return;
            }

         
            switch (formMode)
            {
                case enumFormMode.One:
                    InsertRecord();
                    RefreshData();
                    break;
                case enumFormMode.All:
                    InsertAllRecord();
                    RefreshData();
                    break;

            }

            cmdNo.PerformClick();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdYes.PerformClick();
            }
        }

        public void DataStok(string kodeBarang)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Stok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, kodeBarang));
                    dt = db.Commands[0].ExecuteDataTable();
                    RowIDStok = (Guid)dt.Rows[0]["RowID"];
                    _NamaStok = dt.Rows[0]["NamaStok"].ToString();
                    _KodeRak = dt.Rows[0]["KodeRak"].ToString();
                    _KodeRak1 = dt.Rows[0]["KodeRak1"].ToString();
                    _KodeRak2 = dt.Rows[0]["KodeRak2"].ToString();
                    _SatJual = dt.Rows[0]["SatJual"].ToString();
                    _SatSolo = dt.Rows[0]["SatSolo"].ToString();
                    _StatusPasif = bool.Parse(dt.Rows[0]["StatusPasif"].ToString());
                    _Bundle = dt.Rows[0]["Bundle"].ToString();
                    _Kendaraan = dt.Rows[0]["Kendaraan"].ToString();
                    txtLamaKirim.Text = dt.Rows[0]["PrediksiLamaKirim"].ToString();
                    txtHariRata2.Text = dt.Rows[0]["HariRataRata"].ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
