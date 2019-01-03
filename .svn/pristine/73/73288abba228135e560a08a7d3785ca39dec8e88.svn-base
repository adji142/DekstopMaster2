using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;
using System.Data.SqlTypes;
using System.Collections;

namespace ISA.Trading.PO
{
    public partial class frmPODetailAdd : ISA.Trading.BaseForm
    {

        string id_brg, header, strNoPO, docNoPO = "NOMOR_PO";
        string IDBarang, RowID, idtr;
        DateTime _date;

        enum enumFormMode { New, Update };
        enumFormMode formMode1;

        DataTable dtNum;
        DataTable dtHeaderPO;
        int lebar, iNomor;
        string depan, belakang;
        string _headerRowId;


        public frmPODetailAdd(Form caller)
        {
            InitializeComponent();
            formMode1 = enumFormMode.New;
            this.Caller = caller;
            //MessageBox.Show(formMode1.ToString());
        }
        public frmPODetailAdd(Form caller, String HeaderRowID)
        {
            InitializeComponent();
            formMode1 = enumFormMode.New;
            this.Caller = caller;
            this._headerRowId = HeaderRowID;

        }
        private void frmPODetailAdd_Load(object sender, EventArgs e)
        {
            tbNOPO.Text = this._headerRowId;
            tbBO.Text = "0";
            tbRefil.Text = "0";
            //tbPO.Text = "0";
            tbQSamp.Text = "0";
            tbStock.Text = "0";
            tbBuffer.Text = "0";
            textBox6.Text = " /  /    /";

            using (Database db = new Database())
            {
                ;
                db.Commands.Add(db.CreateCommand("usp_getIdtrRefilPO"));
                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.VarChar, tbNOPO.Text));
                dtHeaderPO = db.Commands[0].ExecuteDataTable();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(tbQSamp.Text.ToString()); 
            //MessageBox.Show(formMode1.ToString());
            //DataTable dtNum = Tools.GetGeneralNumerator(docNoPO, Tools.GeneralInitial());
            //lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            //depan = Tools.GeneralInitial();
            //belakang = dtNum.Rows[0]["Belakang"].ToString();
            //iNomor++;
            //strNoPO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            switch (formMode1)
            {
                case enumFormMode.New:
                    InsertPODetail(strNoPO);
                    break;
                case enumFormMode.Update:
                    //UpdatePO();
                    break;
            }
            frmPO frmCaller = (frmPO)this.Caller;
            frmCaller.RefreshHeader();
            this.Close();
        }

        private bool validation()
        {

            string[, ,] cek = {{ 
                                {txtAlasan.Text.ToString().Replace(Environment.NewLine, string.Empty).TrimEnd(),"isNull","Alasan tidak boleh kosong"}
                             }};

            return Class.validation.error(cek);
        }

        private void InsertPODetail(string NoPO)
        {
            string brgid = Tools.isNull(lookupStock.BarangID,"").ToString();
            string nmstk = Tools.isNull(lookupStock.NamaStock, "").ToString();

            using (Database db = new Database())
            {
                DataTable dtc = new DataTable();
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_PODetail_CekMaster"));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, brgid));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, nmstk));
                    dtc = db.Commands[0].ExecuteDataTable();
                    if (dtc.Rows.Count == 0)
                    {
                        MessageBox.Show("Master Stok tidak ada.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }

            using (Database db = new Database())
            {
                DataTable dt = new DataTable();
                try
                {
                    db.BeginTransaction();
                    db.Commands.Add(db.CreateCommand("usp_PODetail_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@header", SqlDbType.VarChar, tbNOPO.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, dtHeaderPO.Rows[0]["idtr"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, lookupStock.NamaStock));
                    db.Commands[0].Parameters.Add(new Parameter("@refil", SqlDbType.NChar, tbRefil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@bo", SqlDbType.NChar, tbBO.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.NChar, tbStock.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@buffer", SqlDbType.NChar, tbBuffer.Text));

                    if (textBox6.Text.Replace("/", string.Empty).Trim() != string.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.Date, textBox6.Text));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@sam", SqlDbType.NChar, tbQSamp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@fisik", SqlDbType.NChar, tbFisik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@spike", SqlDbType.NChar, tbSpike.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@po", SqlDbType.NChar, tbSpike.Text));
                    //db.Commands[0].Parameters.Add(new Parameter("@po", SqlDbType.NChar, tbPO.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtAlasan.Text.Replace(Environment.NewLine, string.Empty).TrimEnd()));

                    //////MessageBox.Show("masuk ke sp1");
                    //// update numerator
                    //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoPO));
                    //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    //db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    ////MessageBox.Show("masuk ke sp2");
                    db.Commands[0].ExecuteNonQuery();
                    //db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                    MessageBox.Show("Data Berhasil Di simpan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.RollbackTransaction();
                    MessageBox.Show("Gagal Menyimpan Data");
                }
            }
        }


        

        private void LookupStock_SelectData(object sender, EventArgs e)
        {
            id_brg = lookupStock.BarangID;

            btProses_Click_1(sender, e);
        }

        private void btProses_Click_1(object sender, EventArgs e)
        {
            //tglSampling
            using (Database db = new Database())
            {
                DataTable dt5 = new DataTable();
                try
                {
                    db.Commands.Add(db.CreateCommand("fsp_PODetailOpnam"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, id_brg));
                    //db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _date));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt5 = db.Commands[0].ExecuteDataTable();

                    if (dt5.Rows.Count > 0)
                    {
                        textBox6.Text = dt5.Rows[0]["TglOpname"].ToString();
                        tbQSamp.Text = dt5.Rows[0]["QtyOpname"].ToString();
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

                //refill
                {
                    using (Database db = new Database())
                    {
                        DataTable dt = new DataTable();
                        try
                        {
                            db.Commands.Add(db.CreateCommand("fsp_PODetaiReffil"));
                            db.Commands[0].Parameters.Add(new Parameter("@IdBarang", SqlDbType.VarChar, id_brg));
                            db.Commands[0].Parameters.Add(new Parameter("@tglfrom", SqlDbType.DateTime, DateTime.Today));
                            db.Commands[0].Parameters.Add(new Parameter("@tglto", SqlDbType.DateTime, DateTime.Today));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                tbRefil.Text = dt.Rows[0]["nQRefill"].ToString();
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    //stok
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt3 = new DataTable();
                            try
                            {
                                db.Commands.Add(db.CreateCommand("fsp_PODetailStok"));
                                db.Commands[0].Parameters.Add(new Parameter("@idbarang", SqlDbType.VarChar, id_brg));
                                dt3 = db.Commands[0].ExecuteDataTable();

                                if (dt3.Rows.Count > 0)
                                {
                                    tbStock.Text = dt3.Rows[0]["nQstok"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }

                    //backorder
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt1 = new DataTable();
                            try
                            {
                                db.Commands.Add(db.CreateCommand("fsp_POBackOrder"));
                                db.Commands[0].Parameters.Add(new Parameter("@idbarang", SqlDbType.VarChar, id_brg));
                                db.Commands[0].Parameters.Add(new Parameter("@tglfrom", SqlDbType.DateTime, DateTime.Today));
                                db.Commands[0].Parameters.Add(new Parameter("@tglto", SqlDbType.DateTime, DateTime.Today));
                                dt1 = db.Commands[0].ExecuteDataTable();

                                if (dt1.Rows.Count > 0)
                                {
                                    tbBO.Text = dt1.Rows[0]["nQBO"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }

                    //buffer
                    {
                        using (Database db = new Database())
                        {

                            DataTable dt2 = new DataTable();

                            try
                            {

                                db.Commands.Add(db.CreateCommand("fsp_PODetailBuffer"));
                                db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, id_brg));
                                dt2 = db.Commands[0].ExecuteDataTable();
                                if (dt2.Rows.Count > 0)
                                {
                                    tbBuffer.Text = dt2.Rows[0]["nQBuffer"].ToString();

                                }
                                else
                                {
                                    MessageBox.Show("ID Barang ini belum mempunyai Buffer");
                                    tbBuffer.Text = "0";
                                }
                        }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MessageBox.Show("Pilih Barang Terlebih Dahulu");
                            }
                        }
                    }
                }
            }
        


        private void tbNOPO_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPO_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbQSamp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbFisik_TextChanged(object sender, EventArgs e)
        {

           int _Po = Convert.ToInt32(tbBO.Text);
            int _fisik = Convert.ToInt32(Tools.isNull((tbFisik.Text),"0"));
            int _BO = Convert.ToInt32(tbBO.Text);
            int _spike = Convert.ToInt32(Tools.isNull((tbSpike.Text),"0"));
            int _buffer = Convert.ToInt32(tbBuffer.Text);

            if (_buffer != 0 )
            {
                _Po = _buffer - _fisik + _spike;
            }
            else
            {
                _Po = _BO - _fisik + _spike;
            }
            string po = _Po.ToString();
            tbPO.Text = po;
        }

        private void tbSpike_TextChanged(object sender, EventArgs e)
        {
            int _Po = Convert.ToInt32(tbPO.Text);
            int _fisik = Convert.ToInt32(Tools.isNull((tbFisik.Text), "0"));
            int _BO = Convert.ToInt32(tbBO.Text);
            int _spike = Convert.ToInt32(Tools.isNull((tbSpike.Text), "0"));
            int _buffer = Convert.ToInt32(tbBuffer.Text);

            _Po = _spike;

            //if (_buffer != 0)
            //{
            //    _Po = _buffer - _fisik + _spike;
            //}
            //else
            //{
            //    _Po = _BO - _fisik + _spike;
            //}
            string po = _Po.ToString();
            tbPO.Text = po;
        }

    }
}