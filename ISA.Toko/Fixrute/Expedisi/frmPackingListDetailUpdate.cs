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
    public partial class frmPackingListDetailUpdate : ISA.Toko.BaseForm
    {
        Guid _rowID, _headerID;
        //Guid doDetailID;
        int qtyKoli, KoliAwal, KoliAkhir, qtyNota;
        //string recID, htrID, kodeGudang, catatan;
        DataTable _dtNotaDetail;
        
        public frmPackingListDetailUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        #region tdk di pakai
        //public frmPackingListDetailUpdate(Form caller, Guid rowID/*, string NamaBarang, 
        //    Guid HeaderID, Guid DODetailID, string RecordID, string HtrID, string KodeGudang,
        //    string Catatan, int QtyNota, string Satuan, int QtyDO, int QtySJ, double HargaJual,
        //    int QtyKoli, int KoliAwalParam, string KetKoli, string Kelompok*/)
        //{
        //    InitializeComponent();
        //    _rowID = rowID;
        //    this.Caller = caller;

        //    txtNamaBarang.Text = NamaBarang;
        //    headerID = (Guid)HeaderID;
        //    doDetailID = (Guid)DODetailID;
        //    recID = RecordID;
        //    htrID = HtrID;
        //    kodeGudang = KodeGudang;
        //    catatan = Catatan;
        //    qtyNota = QtyNota;
        //    txtSatuan.Text = Satuan;
        //    txtJDO.Text = QtyDO.ToString();
        //    txtJSJ.Text = QtySJ.ToString();
        //    txtHargaJual.Text = HargaJual.ToString("#,##0");
        //    qtyKoli = QtyKoli;
        //    KoliAwal = KoliAwalParam;
        //    txtJKoli.Text = QtyKoli.ToString();
        //    txtKoliAwal.Text = KoliAwal.ToString();
        //    txtKelompok.Text = Kelompok;

        //    if (qtyKoli > 1)
        //    {
        //        KoliAkhir = qtyKoli + KoliAwal - 1;
        //    }
        //    else
        //    {
        //        KoliAkhir = 0;
        //    }
        //    if (qtyKoli == 0)
        //    {
        //        txtKoliAkhir.Enabled = true;
        //    }
        //    txtKoliAkhir.Text = KoliAkhir.ToString();
        //    string nokoli, koliAwals, koliAkhirs;
        //    if (KoliAwal > 0 & KoliAwal < 10)
        //    {
        //        koliAwals = "0" + KoliAwal.ToString();
        //    }
        //    else
        //    {
        //        koliAwals = KoliAwal.ToString();
        //    }
        //    if (KoliAkhir > 0 & KoliAkhir < 10)
        //    {
        //        koliAkhirs = "0" + KoliAkhir.ToString();
        //    }
        //    else
        //    {
        //        koliAkhirs = KoliAkhir.ToString();
        //    }

        //    if (qtyKoli > 1)
        //    {
        //        nokoli = koliAwals + " S/D " + koliAkhirs;
        //        txtNoKoli.Text = nokoli.ToString();
        //    }
        //    else if (qtyKoli == 1)
        //    {
        //        nokoli = koliAwals;
        //        txtNoKoli.Text = nokoli.ToString();
        //    }
        //    else if (qtyKoli == 0)
        //    {
        //        if (KoliAkhir > 0)
        //        {
        //            nokoli = koliAwals + "&" + koliAkhirs;
        //        }
        //        else
        //        {
        //            nokoli = koliAwals;
        //        }
        //        txtNoKoli.Text = nokoli.ToString();
        //    }

        //    txtKeterangan.Text = KetKoli;
        //    txtJKoli.Focus();

        //}
        #endregion

        private void frmPackingListDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database())
                {
                    _dtNotaDetail = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST_FILTER_RowID"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    _dtNotaDetail = db.Commands[0].ExecuteDataTable();


                    txtNamaBarang.Text = Tools.isNull(_dtNotaDetail.Rows[0]["NamaBarang"], "").ToString();
                    _headerID = (Guid)_dtNotaDetail.Rows[0]["HeaderID"];
                    //doDetailID = (Guid)_dtNotaDetail.Rows[0]["DODetailID"];
                    //recID = Tools.isNull(_dtNotaDetail.Rows[0]["RecordID"], "").ToString();
                    //htrID = Tools.isNull(_dtNotaDetail.Rows[0]["HtrID"], "").ToString();
                    //kodeGudang = Tools.isNull(_dtNotaDetail.Rows[0]["KodeGudang"], "").ToString();
                    //catatan = Tools.isNull(_dtNotaDetail.Rows[0]["Catatan"], "").ToString();
                    qtyNota = Convert.ToInt32(_dtNotaDetail.Rows[0]["QtyNota"]);
                    txtKelompok.Text = Tools.isNull(_dtNotaDetail.Rows[0]["KelBarangID"], "").ToString();
                    txtSatuan.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Satuan"], "").ToString();
                    txtJDO.Text = Tools.isNull(_dtNotaDetail.Rows[0]["QtyOrderDetail"], "").ToString();
                    txtJSJ.Text = Tools.isNull(_dtNotaDetail.Rows[0]["QtySuratJalan"], "").ToString();
                    txtHargaJual.Text = Tools.isNull(_dtNotaDetail.Rows[0]["HrgJual"], "").ToString();
                    qtyKoli = Convert.ToInt32(_dtNotaDetail.Rows[0]["QtyKoli"]);
                    KoliAwal = Convert.ToInt32(_dtNotaDetail.Rows[0]["KoliAwal"]);
                    txtJKoli.Text = Tools.isNull(_dtNotaDetail.Rows[0]["QtyKoli"], "").ToString();
                    txtKoliAwal.Text = Tools.isNull(_dtNotaDetail.Rows[0]["KoliAwal"], "").ToString();

                    if (qtyKoli > 1)
                    {
                        KoliAkhir = qtyKoli + KoliAwal - 1;
                    }
                    else
                    {
                        KoliAkhir = 0;
                    }
                    if (qtyKoli == 0)
                    {
                        txtKoliAkhir.Enabled = true;
                    }
                    txtKoliAkhir.Text = KoliAkhir.ToString();
                    string nokoli, koliAwals, koliAkhirs;
                    if (KoliAwal > 0 & KoliAwal < 10)
                    {
                        koliAwals = "0" + KoliAwal.ToString();
                    }
                    else
                    {
                        koliAwals = KoliAwal.ToString();
                    }
                    if (KoliAkhir > 0 & KoliAkhir < 10)
                    {
                        koliAkhirs = "0" + KoliAkhir.ToString();
                    }
                    else
                    {
                        koliAkhirs = KoliAkhir.ToString();
                    }

                    if (qtyKoli > 1)
                    {
                        nokoli = koliAwals + " S/D " + koliAkhirs;
                        txtNoKoli.Text = nokoli.ToString();
                    }
                    else if (qtyKoli == 1)
                    {
                        nokoli = koliAwals;
                        txtNoKoli.Text = nokoli.ToString();
                    }
                    else if (qtyKoli == 0)
                    {
                        if (KoliAkhir > 0)
                        {
                            nokoli = koliAwals + "&" + koliAkhirs;
                        }
                        else
                        {
                            nokoli = koliAwals;
                        }
                        txtNoKoli.Text = nokoli.ToString();
                    }

                    txtKeterangan.Text = Tools.isNull(_dtNotaDetail.Rows[0]["KetKoli"], "").ToString();
                    txtJKoli.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                        db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, _dtNotaDetail.Rows[0]["DOID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, _dtNotaDetail.Rows[0]["DODetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["RecordID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["HtrID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["BarangID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, _dtNotaDetail.Rows[0]["HrgJual"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _dtNotaDetail.Rows[0]["Disc1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _dtNotaDetail.Rows[0]["Disc2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _dtNotaDetail.Rows[0]["Disc3"]));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["DiscFormula"]));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, _dtNotaDetail.Rows[0]["Pot"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["KodeGudang"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, Convert.ToInt32(txtJSJ.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, qtyNota));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, Convert.ToInt32(txtJKoli.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, Convert.ToInt32(txtKoliAwal.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, Convert.ToInt32(txtKoliAkhir.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, txtNoKoli.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, txtKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["Catatan"]));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastupdatedby", SqlDbType.VarChar, SecurityManager.UserID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    this.DialogResult = DialogResult.OK;
                    frmPackingListBrowse frmCaller = (frmPackingListBrowse)this.Caller;
                    frmCaller.RefreshDataHeader();
                    frmCaller.FindHeader("RowID", _headerID.ToString());
                    frmCaller.FindDetail("RowIDD", _rowID.ToString());
                    this.Close();
                    frmCaller.Show();
                }
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

        public bool IsValid()
        {
            bool valid = true;
            if (txtKoliAwal.Text == "")
            {
                errorProvider1.SetError(txtKoliAwal, Messages.Error.InputRequired);
                txtKoliAwal.Focus();
                valid = false;
            }

            if (txtKoliAkhir.Text == "")
            {
                errorProvider1.SetError(txtKoliAkhir, Messages.Error.InputRequired);
                txtKoliAkhir.Focus();
                valid = false;
            }

           
            return valid;
        }

        private void txtJKoli_Leave(object sender, EventArgs e)
        {
            int _KoliAkhir = 0;

            if (txtJKoli.Text == "0" || string.IsNullOrEmpty(txtJKoli.Text))
            {
                txtJKoli.Text = "0";
                txtKoliAkhir.Text = "0";
            }
            else
            {
                _KoliAkhir = int.Parse(txtJKoli.Text) + (int.Parse(txtKoliAwal.Text)-1);

                txtKoliAkhir.Text = _KoliAkhir.ToString();
                generateNoKoli();
            }
        }

        private void generateNoKoli()
        {
            if (txtJKoli.Text.Equals("0") && txtKoliAwal.Text.Equals("0"))
            {
                txtKoliAkhir.Text = "0";
                txtNoKoli.Text = "0";
            }
            else
            {
                if (txtJKoli.Text.Equals("1"))
                {
                    txtKoliAkhir.Text = "0";
                    txtNoKoli.Text = txtKoliAwal.Text.PadLeft(2, '0');
                }
                else
                {
                    txtNoKoli.Text = txtKoliAwal.Text.PadLeft(2, '0') + " S/D " + txtKoliAkhir.Text.PadLeft(2, '0');
                }
            }
        }

        private void txtKoliAwal_Leave(object sender, EventArgs e)
        {
            int _KoliAkhir = 0;

            if (string.IsNullOrEmpty(txtKoliAwal.Text))
            {
                txtKoliAwal.Text = "0";
            }
            
            _KoliAkhir = int.Parse(txtJKoli.Text) + (int.Parse(txtKoliAwal.Text)-1);
            txtKoliAkhir.Text = _KoliAkhir.ToString();
            generateNoKoli();
        }
    }
}
