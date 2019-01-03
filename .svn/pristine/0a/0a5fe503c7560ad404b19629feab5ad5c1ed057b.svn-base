using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Ekspedisi
{
    public partial class frmPackingListHeaderUpdate : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DataTable dtNota = new DataTable();

        public frmPackingListHeaderUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
            txtTglSerahTerima.Text = DateTime.Today.ToString();
        }
       
        private void frmPackingListHeaderUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dtp = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Checker_LIST"));
                    dtp = db.Commands[0].ExecuteDataTable();
                    dtp.Rows.Add("");
                    dtp.DefaultView.Sort = "FirstName ASC";
                   
                    DataTable dts = new DataTable();
                    dts = db.Commands[0].ExecuteDataTable();
                    dts.Rows.Add("");
                    dts.DefaultView.Sort = "FirstName ASC";
                   
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID ));
                    dtNota = db.Commands[1].ExecuteDataTable();

                    //txtTglNota.DateValue = DateTime.Today; -- tgl nota isi bukan di sini tp di pj3
                    txtNamaSales.Text = Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString();
                    txtNoRequest.Text = Tools.isNull(dtNota.Rows[0]["NoRequest"], "").ToString();
                    txtTglRequest.DateValue=(DateTime?)dtNota.Rows[0]["TglRequest"];
                    txtNoDO.Text=Tools.isNull(dtNota.Rows[0]["NoDO"], "").ToString();
                    txtTglDO.DateValue = (DateTime?)dtNota.Rows[0]["TglDO"];
                    txtStatusBatal.Text = Tools.isNull(dtNota.Rows[0]["NoSuratJalan"], "").ToString();
                    txtTglStatusBatal.DateValue = (DateTime?)dtNota.Rows[0]["TglSuratJalan"];
                    txtNoNota.Text = Tools.isNull(dtNota.Rows[0]["NoNota"], "").ToString();
                    txtNamaToko.Text = Tools.isNull(dtNota.Rows[0]["NamaToko"], "").ToString();
                    txtAlamatKirim.Text = Tools.isNull(dtNota.Rows[0]["AlamatKirim"], "").ToString();
                    txtKota.Text = Tools.isNull(dtNota.Rows[0]["Kota"], "").ToString();
                    txtEkspedisi.Text = Tools.isNull(dtNota.Rows[0]["StatusBatal"], "").ToString();
                    txtTglTerima.DateValue = DateTime.Today;
                    txtTglSerahTerima.DateValue = DateTime.Today;
                    txtRpJual.Text = (dtNota.Rows[0]["RpJual2"]).ToString();
                    txtRpNet.Text = (dtNota.Rows[0]["RpNet2"]).ToString();
                    txtDisc1.Text = (dtNota.Rows[0]["Disc1"]).ToString();
                    txtDisc2.Text = (dtNota.Rows[0]["Disc2"]).ToString();
                    txtDisc3.Text = (dtNota.Rows[0]["Disc3"]).ToString();
                    txtHariKredit.Text = (dtNota.Rows[0]["HariKredit"]).ToString();
                    txtCatatan1.Text = Tools.isNull(dtNota.Rows[0]["Catatan1"], "").ToString();
                    txtCatatan2.Text = Tools.isNull(dtNota.Rows[0]["Catatan2"], "").ToString();
                    txtCatatan3.Text = Tools.isNull(dtNota.Rows[0]["Catatan3"], "").ToString();
                    txtCatatan4.Text = Tools.isNull(dtNota.Rows[0]["Catatan4"], "").ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTglSerahTerima.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTglSerahTerima, "Tgl Serah Terima masih kosong");
                valid = false;
            }

            if (lookupStafAdm1.Kode.ToString().Trim() == "")
            {
                errorProvider1.SetError(lookupStafAdm1, "Belum pilih checker 1");
                valid = false;
            }

            if (lookupStafAdm2.Kode.ToString().Trim() == "")
            {
                errorProvider1.SetError(lookupStafAdm2, "Belum pilih checker 2");
                valid = false;
            }

            return valid;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {

                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtNota.Rows[0]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, dtNota.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@DOID", SqlDbType.UniqueIdentifier, dtNota.Rows[0]["DOID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, dtNota.Rows[0]["NoNota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dtNota.Rows[0]["TglNota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noSJ", SqlDbType.VarChar, dtNota.Rows[0]["NoSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSJ", SqlDbType.DateTime, dtNota.Rows[0]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, dtNota.Rows[0]["TglTerima"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, txtTglSerahTerima.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtNota.Rows[0]["Cabang1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtNota.Rows[0]["Cabang2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang3", SqlDbType.VarChar, dtNota.Rows[0]["Cabang3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dtNota.Rows[0]["KodeSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtNota.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtNota.Rows[0]["alamatKirim"]));
                    //db.Commands[0].Parameters.Add(new Parameter("@alamatKirim", SqlDbType.VarChar, dtNota.Rows[0]["alamatKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, dtNota.Rows[0]["Kota"]));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtNota.Rows[0]["isClosed"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dtNota.Rows[0]["Cat1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dtNota.Rows[0]["Cat2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan3", SqlDbType.VarChar, dtNota.Rows[0]["Cat3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan4", SqlDbType.VarChar, dtNota.Rows[0]["Cat4"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan5", SqlDbType.VarChar, dtNota.Rows[0]["Cat5"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, dtNota.Rows[0]["LinkID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtNota.Rows[0]["NPrint"]));
                    db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, lookupStafAdm1.Nama));
                    db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, lookupStafAdm2.Nama));
                    db.Commands[0].Parameters.Add(new Parameter("@transactionType", SqlDbType.VarChar, dtNota.Rows[0]["TransactionType"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, dtNota.Rows[0]["HariKredit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKirim", SqlDbType.Int, dtNota.Rows[0]["HariKirim"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hariSales", SqlDbType.Int, dtNota.Rows[0]["HariSales"]));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                    //db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    //db.Commands[0].Parameters.Add(new Parameter("@tglSerahTerimaChecker", SqlDbType.DateTime, txtTglSerahTerima.DateValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@checker1", SqlDbType.VarChar, cboChecker1.SelectedValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@checker2", SqlDbType.VarChar, cboChecker2.SelectedValue));
                    //db.Commands[0].Parameters.Add(new Parameter("@lastupdatedby", SqlDbType.VarChar, SecurityManager.UserID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                
                this.DialogResult = DialogResult.OK;
                frmPackingListBrowse frmCaller = (frmPackingListBrowse)this.Caller;
                frmCaller.RefreshDataHeader();
                frmCaller.FindHeader("RowID", _rowID.ToString());
                this.Close();
                frmCaller.Show();
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
    
    }
}
