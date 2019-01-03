using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Master
{
    public partial class frmHPPUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        String _BarangId;
        Guid RowID;
        string tampNama;
        DataTable dt;
        bool _drpembelian = false;

        public frmHPPUpdate(Form caller, String BarangId)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            _BarangId = BarangId;
            this.Caller = caller;
        }

        public frmHPPUpdate(Form caller, String BarangId, String Harga)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            _BarangId = BarangId;
            txtHargaHpp.Text = Harga;
            txtHargaHpp.Enabled = false;
            this.Caller = caller;
            _drpembelian = true;
        }

        public frmHPPUpdate(Form caller, Guid rowID , String BarangID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            _BarangId = BarangID;
            this.Caller = caller;
        }

        private void frmHPPUpdate_Load(object sender, EventArgs e)
        {


            if (formMode == enumFormMode.UPDATE)
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("[usp_HistoryHPP_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    txtHargaHpp.Text = Tools.isNull(dt.Rows[0]["HPP"], "").ToString();
                    txttglBerlaku.DateValue = (DateTime)dt.Rows[0]["TglAktif"];
                    txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                }
            }
            else { txttglBerlaku.DateValue = GlobalVar.DateOfServer; }

           
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty( txttglBerlaku.Text))
            {
                MessageBox.Show("Anda belum mengisi Tanggal Aktif");
                txttglBerlaku.Focus();
                return;
            }
            if (txtHargaHpp.GetIntValue < 1)
            {
                MessageBox.Show("Harga Beli Tidak boleh Kurang dari 1");
                txtHargaHpp.Focus();  
                return;
            }
            try
            {
                switch (formMode)
                {
                    case enumFormMode.NEW:
                        
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_HistoryHPP_INSERT]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@historyID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _BarangId));
                            db.Commands[0].Parameters.Add(new Parameter("@tglAktif", SqlDbType.VarChar, txttglBerlaku.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@HPP", SqlDbType.Money, txtnetto.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@hpp2", SqlDbType.Money, txtHargaHpp.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@discount", SqlDbType.Int, txtdiskon.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count == 1)
                            {

                                MessageBox.Show("Harga Jual Pada tanggal "+txttglBerlaku.Text+" Sudah Ada" );
                                txttglBerlaku.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            
                            db.Open();
                            DataTable dt = new DataTable();

                            db.Commands.Add(db.CreateCommand("[usp_HistoryHPP_UPDATE]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@historyID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _BarangId));
                            db.Commands[0].Parameters.Add(new Parameter("@tglAktif", SqlDbType.VarChar, txttglBerlaku.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@HPP", SqlDbType.Money, txtnetto.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@hpp2", SqlDbType.Money, txtHargaHpp.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@discount", SqlDbType.Int, txtdiskon.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                            db.Close();
                            db.Dispose();

                        }
                        break;
                }
                if (_drpembelian)
                {
                    MessageBox.Show("HPP Berhasil dimasukkan");
                    this.Close();
                    return;
                }
                
                this.DialogResult = DialogResult.OK;
                frmHPPBrowse frmcaller = (frmHPPBrowse)this.Caller;
                frmcaller.RefreshDataHPP();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmHPPUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJasaBrowse)
                {
                    frmJasaBrowse frmCaller = (frmJasaBrowse)this.Caller;                
                    frmCaller.RefreshData();
                    frmCaller.FindRow("TMT", txttglBerlaku.ToString());                
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtdiskon_TextChanged(object sender, EventArgs e)
        {
           
          
        }

        private void txtdiskon_Leave(object sender, EventArgs e)
        {

           double _hbeli = txtHargaHpp.GetDoubleValue;
             double _diskon = txtdiskon.GetDoubleValue;
            double _hnet = _hbeli - ((_diskon/100)*_hbeli);
            txtnetto.Text=_hnet.ToString();
        }

        private void txtdiskon_Validated(object sender, EventArgs e)
        {
                      
        }

      
      
      

    }
}
