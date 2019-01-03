using System;
using System.Data;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmHargaJualBMK : ISA.Controls.BaseForm
    {
        Class.Enums.enumClsState _state = Class.Enums.enumClsState.Empty;
        Guid _rowID;
        string _stokID;

        public Guid RowID { get { return _rowID; } set { _rowID = value; } }

        public frmHargaJualBMK()
        {
            InitializeComponent();
        }

        public frmHargaJualBMK(Class.Enums.enumClsState tState, string tRecordID)
        {
            _state = tState;
            _stokID = tRecordID;
            InitializeComponent();
        }

        public frmHargaJualBMK(Class.Enums.enumClsState tState, Guid tRowID)
        {
            _state = tState;
            _rowID = tRowID; 
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHargaJualBMK_Load(object sender, EventArgs e)
        {
            try
            {
                switch (_state)
                {
                    case Class.Enums.enumClsState.Update:
                        {
                            DataTable dt = DBTools.DBGetDataTableByRowID("usp_HistoryBMKDepo_HargaJual_LIST", _rowID);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                DataRow dr = (DataRow)dt.Rows[0];
                                _stokID = dr["StokID"].ToString();
                                txtHarga.Text = double.Parse(dr["hjual_e"].ToString()).ToString("#,##0.00");
                                if (dr["TglAktif"] != System.DBNull.Value) rtTglBerlaku.FromDate = DateTime.Parse(dr["TglAktif"].ToString());
                                if (dr["TglPasif"] != System.DBNull.Value) rtTglBerlaku.FromDate = DateTime.Parse(dr["TglPasif"].ToString());
                                txtKeterangan.Text = dr["Keterangan"].ToString();
                            }
                        }
                        break;
                    case Class.Enums.enumClsState.New:
                        _rowID = Guid.NewGuid();
                        rtTglBerlaku.FromDate = GlobalVar.DateOfServer;
                        break;
                }
                lookupStock1.SetStockRecordID(_stokID);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            using (Database db = new Database())
            try
            {
                Command cmd = db.CreateCommand("usp_HistoryBMKDepo_INSERT");
                if (_rowID == null || _rowID == Guid.Empty) _rowID = Guid.NewGuid();

                int harga = Convert.ToInt32(Tools.isNull(txtHarga.GetIntValue, "0").ToString());  //txtHarga.GetDoubleValue;

                cmd.AddParameter("RowID",SqlDbType.UniqueIdentifier,_rowID);
                cmd.AddParameter("HistoryID",SqlDbType.VarChar,"");
                cmd.AddParameter("StokID",SqlDbType.VarChar,lookupStock1.RecordID); 
                cmd.AddParameter("BarangID", SqlDbType.VarChar, lookupStock1.BarangID); 
                cmd.AddParameter("TglAktif",SqlDbType.Date,rtTglBerlaku.FromDate);
                cmd.AddParameter("TglPasif",SqlDbType.Date,rtTglBerlaku.ToDate);
                cmd.AddParameter("HrgJualStd",SqlDbType.Money,harga);
                cmd.AddParameter("QtyMinB",SqlDbType.Int,0);
                cmd.AddParameter("HrgJualB",SqlDbType.Money, harga);
                cmd.AddParameter("QtyMinM",SqlDbType.Int,0);
                cmd.AddParameter("HrgJualM",SqlDbType.Money,harga);
                cmd.AddParameter("QtyMinK",SqlDbType.Int,0);
                cmd.AddParameter("HrgJualK",SqlDbType.Money,harga);
                cmd.AddParameter("Keterangan",SqlDbType.VarChar,txtKeterangan.Text);
                cmd.AddParameter("SyncFlag",SqlDbType.Bit,false);
                cmd.AddParameter("StatusLaba",SqlDbType.VarChar,"");
                cmd.AddParameter("hnet", SqlDbType.Int, harga);
                cmd.AddParameter("cash", SqlDbType.Int, 0);
                cmd.AddParameter("top10",SqlDbType.Int, 0);
                cmd.AddParameter("enduser",SqlDbType.Int, 0);
                cmd.AddParameter("hjual_c",SqlDbType.Int,harga);
                cmd.AddParameter("hjual_t",SqlDbType.Int,harga);
                cmd.AddParameter("hjual_e",SqlDbType.Int,harga);
                cmd.AddParameter("LastUpdatedBy",SqlDbType.VarChar,SecurityManager.UserID);

                object o = cmd.ExecuteNonQuery();
                MessageBox.Show("Data telah tersimpan.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
