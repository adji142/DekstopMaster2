using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PO 
{
    public partial class frmGetDetailPO : ISA.Trading.BaseForm
    {
        enum enumFormMode { GetDetail , New, Update };
        enumFormMode _formMode;
        DataTable dtGetPO, dtStok, dtCekSampling;
        Guid _rowID;
        string _idbarang, _spike, _keterangan, PO, docNoPO; 
        bool _Closing;
        DataTable dtNum;
        int lebar, iNomor;
        string depan, belakang;
        string _headerRowId,_idtr;
        
        public frmGetDetailPO(Form caller)
        {
            InitializeComponent();
            _formMode = enumFormMode.New;
            this.Caller = caller;
        }
        public frmGetDetailPO(Form caller, Guid rowID, bool Closing, string idtr)
        {
            InitializeComponent();
            _formMode = enumFormMode.GetDetail;
            _rowID = rowID;
            _idtr = idtr;
            this.Caller = caller;
            _Closing = Closing;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada");
                return;
            }

            DataTable dtNum = Tools.GetGeneralNumerator(docNoPO, Tools.GeneralInitial());
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = Tools.GeneralInitial();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            PO = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            SaveDataGrid(PO);

            frmPO frmCaller = (frmPO)this.Caller;
            frmCaller.RefreshHeader() ;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public void SaveDataGrid(string PO)
        {
            int i = 0;
            for (i = 0; i < customGridView1.Rows.Count; i++)
            {
                string Idrec = Tools.CreateFingerPrint().ToString().Substring(0, 17) + i.ToString().Trim().PadLeft(5,'0');
                int po = Convert.ToInt32(customGridView1.Rows[i].Cells["poo"].Value.ToString());
                Int32 _cek = Convert.ToInt32(Tools.isNull(customGridView1.Rows[i].Cells["cek"].Value,"0").ToString());

                if (po > 0 && _cek == 1)
                {
                    using (Database db = new Database())
                    {

                        DataTable dt = new DataTable();
                        try
                        {
                            //    if (customGridView1.Rows[i].Cells[""].Value.ToString() == "0")
                            //{
                            db.Commands.Add(db.CreateCommand("usp_POGetDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@header", SqlDbType.VarChar, txtIDBarang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, _idtr.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Idrec));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, customGridView1.Rows[i].Cells["klmpk"].Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, customGridView1.Rows[i].Cells["namaStok"].Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, customGridView1.Rows[i].Cells["Sat"].Value.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@refil", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["refil"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@bo", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["backorder"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@stok", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["stokk"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@buffer", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["bufer"].Value,"0").ToString()));
                            //db.Commands[0].Parameters.Add(new Parameter("@tgl_opname", SqlDbType.Date, ));
                            db.Commands[0].Parameters.Add(new Parameter("@spike", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["spikee"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@fisik", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["fisk"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@opname", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["fisk"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@po", SqlDbType.NChar, Tools.isNull(customGridView1.Rows[i].Cells["poo"].Value,"0").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(customGridView1.Rows[i].Cells["ket"].Value,"").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(customGridView1.Rows[i].Cells["Keterangan"].Value,"").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].ExecuteNonQuery();
                            //db.CommitTransaction();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            db.RollbackTransaction();
                            MessageBox.Show("Gagal Menyimpan Data");
                        }
                    }
                }
            }
        }

        private void frmGetDetailPO_Load(object sender, EventArgs e)
        {
            this.Title = "Auto Order Entry Form";
            this.Text = "PO";

            try
            {
                dtGetPO = new DataTable();
                DataTable dt1 = new DataTable();
                using (Database db = new Database())
                {
                    if (_formMode == enumFormMode.GetDetail)
                    {
                        db.Commands.Add(db.CreateCommand("usp_POH_List"));
                        db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _rowID));
                        dtGetPO = db.Commands[0].ExecuteDataTable();
                    }

                }

                if (_formMode == enumFormMode.GetDetail)
                {
                    txtTglFrom.Text = Convert.ToDateTime(dtGetPO.Rows[0]["tanggal1"].ToString()).ToString("dd-MMMM-yyyy");
                    txtTglTo.Text = Convert.ToDateTime(dtGetPO.Rows[0]["tanggal2"].ToString()).ToString("dd-MMMM-yyyy");
                    txtNoPo.Text = dtGetPO.Rows[0]["no_po"].ToString();
                    txtIDBarang.Text = dtGetPO.Rows[0]["RowID"].ToString();
                    txtNoPo.ReadOnly = true;
                    txtTglFrom.ReadOnly = true;
                    txtTglTo.ReadOnly = true;
                    txtNamaStok.ReadOnly = true;
                    txtKelompok.ReadOnly = true;
                }
                else
                {
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public DataTable Stok()
        {
            customGridView1.AutoGenerateColumns = false;
            dtStok = new DataTable();
            using (Database db = new Database())
            {
                    db.Commands.Add(db.CreateCommand("usp_ProsesGetDetailPO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime , txtTglFrom.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txtTglTo.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dtStok = db.Commands[0].ExecuteDataTable();
                    //customGridView1.DataSource = dtStok;
                    //MessageBox.Show(dtStok.Rows[0]["nQrefil"].ToString());
            }

            return dtStok;
            }


        public void AutoValidation()
        {
                int i = 0;
                for (i = 0; i < dtStok.Rows.Count; i++)
                {
                    string _idbarang;
                    Int32 nQPO, nQBuffer, nQFisik, nQSpike, nQBo, nQStok;
                    nQBuffer = int.Parse(Tools.isNull(dtStok.Rows[i]["nqbufer"],"0").ToString());
                    nQBo = int.Parse(Tools.isNull(dtStok.Rows[i]["nQbo"],"0").ToString());
                    nQFisik = int.Parse(Tools.isNull(dtStok.Rows[i]["nQFisik"],"0").ToString());
                    nQSpike = int.Parse(Tools.isNull(dtStok.Rows[i]["nQSpike"],"0").ToString());
                    nQPO = int.Parse(Tools.isNull(dtStok.Rows[i]["nQPO"],"0").ToString());
                    nQStok = int.Parse(Tools.isNull(dtStok.Rows[i]["nQstok"],"0").ToString());

                    _idbarang = dtStok.Rows[i]["BarangID"].ToString();

                    //kebijakan agar depo mengirim PO lewat Getdetail, dan validasi sampling opname ditutup
                    //untuk memperlancar proses PO ke HO
                    //CekSampling(_idbarang);
                    //if (dtCekSampling.Rows.Count > 0)
                    //{
                    //if (nQBuffer != 0)
                    //{
                    //    nQPO = nQBuffer - nQFisik + nQSpike;
                    //}
                    //else
                    //{
                    //    nQPO = nQBo - nQFisik + nQSpike;
                    //}

                    nQPO = nQBuffer - nQStok;

                    if (nQPO <= 0)
                    {
                        nQPO = 0;
                        dtStok.Rows[i]["nQPO"] = nQPO.ToString();
                        dtStok.Rows[i]["alasan"] = "Not Order";
                        customGridView1.Rows[i].Cells["cek"].Value = 0;
                        customGridView1.Rows[i].Cells["Keterangan"].Value = "Not Order";
                    }
                    else
                    {
                        dtStok.Rows[i]["nQPO"] = nQPO.ToString();
                        dtStok.Rows[i]["alasan"] = "Request";
                        customGridView1.Rows[i].Cells["cek"].Value = 1;
                        customGridView1.Rows[i].Cells["Keterangan"].Value = "Order";
                    }
                }
                customGridView1.DataSource = dtStok;
            }

    
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void cmdProses_Click(object sender, EventArgs e)
        {
            DataTable dt = Stok();
            if (dt.Rows.Count > 0)
            {
                customGridView1.DataSource = dt;
            }

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdValidation_Click(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada");
                return;
            }
            if (MessageBox.Show("Apakah PO Mau DiValidasi ?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AutoValidation();
            }
        }

        private DataTable CekSampling(string idbarang)
        {
            dtCekSampling = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_POCekAutoVaidasi"));
                db.Commands[0].Parameters.Add(new Parameter("@idbarang", SqlDbType.VarChar, idbarang));
                dtCekSampling = db.Commands[0].ExecuteDataTable();
                

            }

            return dtCekSampling;
        }


        private void SpikeOrder_Click(object sender, EventArgs e)
        {
            string kodeBarang;
            bool Closing_ = false;
            if (customGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada");
                return;
            }
            kodeBarang = (string)customGridView1.SelectedCells[0].OwningRow.Cells["klmpk"].Value;
            PO.frmSpikeOrder ifrmChild = new PO.frmSpikeOrder(this, kodeBarang, Closing_);
            if (ifrmChild.ShowDialog(this) == DialogResult.OK)
            {
                this.customGridView1.SelectedCells[0].OwningRow.Cells["spikee"].Value = ifrmChild.Spike;
                this.customGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value = ifrmChild.keterangan;
            }

                

                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.MdiParent = Program.MainForm;
                //ifrmChild.Show();
                ifrmChild.Dispose();
                double nQPO, nQBuffer, nQFisik, nQSpike, nQBo;
                nQSpike = int.Parse(Tools.isNull(ifrmChild.Spike,"0").ToString());
                nQBuffer = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["bufer"].Value.ToString());
                nQBo = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["backorder"].Value.ToString());
                nQFisik = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["stokk"].Value.ToString());
                nQPO = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["poo"].Value.ToString());
                    if (nQBuffer != 0)
                    {
                        nQPO = nQBuffer - nQFisik + nQSpike;
                    }
                    else
                    {
                        nQPO = nQBo - nQFisik + nQSpike;
                    }
                customGridView1.SelectedCells[0].OwningRow.Cells["spikee"].Value = int.Parse(Tools.isNull(ifrmChild.Spike,"0").ToString());
                customGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value = Tools.isNull(ifrmChild.keterangan,"").ToString();
                customGridView1.SelectedCells[0].OwningRow.Cells["ket"].Value = "Spike";
                customGridView1.SelectedCells[0].OwningRow.Cells["cek"].Value = 1;
                customGridView1.SelectedCells[0].OwningRow.Cells["poo"].Value = nQPO;
                customGridView1.Refresh();
            }

        private void txtTglFrom_TextChanged(object sender, EventArgs e)
        {

        }



        private void validasiManual()
        {
            string _idbarang;
            double nQRq, nQPO, nQBuffer, nQStok, nQFisik, nQSpike, nQBo, nQRefil;
            nQBuffer = Convert.ToDouble(customGridView1.SelectedCells[0].OwningRow.Cells["bufer"].Value.ToString());
            nQRefil = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["Refil"].Value.ToString());
            nQBo = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["backorder"].Value.ToString());
            nQStok = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["stokk"].Value.ToString());
            nQFisik = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["stokk"].Value.ToString());
            nQSpike = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["spikee"].Value.ToString());
            nQPO = int.Parse(customGridView1.SelectedCells[0].OwningRow.Cells["poo"].Value.ToString());
            _idbarang = customGridView1.SelectedCells[0].OwningRow.Cells["klmpk"].Value.ToString();

            //tutup Ceksampling Opname
            //CekSampling(_idbarang);

            nQRq = nQRefil + nQBo;

            if (nQBuffer != 0)
            {
                nQPO = nQBuffer - nQFisik + nQSpike;
            }
            else
            {
                nQPO = nQBo - nQFisik + nQSpike;
            }

            if (nQPO <= 0)
            {
                customGridView1.SelectedCells[0].OwningRow.Cells["ket"].Value = "Not Order";
                customGridView1.SelectedCells[0].OwningRow.Cells["poo"].Value = nQPO.ToString();
                customGridView1.SelectedCells[0].OwningRow.Cells["cek"].Value = 1;
                //customGridView1.SelectedCells[0].OwningRow.Cells["Keterangan"].Value = "Not Order";
                //customGridView1.SelectedCells[0].OwningRow.Cells["nQPO"].Value = nQPO.ToString();
            }
            else
            {
                customGridView1.SelectedCells[0].OwningRow.Cells["ket"].Value = "Request";
                customGridView1.SelectedCells[0].OwningRow.Cells["poo"].Value = nQPO.ToString();
                Int32 _cek = Int32.Parse(Tools.isNull(customGridView1.SelectedCells[0].OwningRow.Cells["cek"].Value, 0).ToString());
                if (_cek == 1)
                    customGridView1.SelectedCells[0].OwningRow.Cells["cek"].Value = 0;
                else
                    customGridView1.SelectedCells[0].OwningRow.Cells["cek"].Value = 1;

            }

            customGridView1.DataSource = dtStok;
        }


        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    SpikeOrder_Click(sender, e);
                    break;
               case Keys.Space:
                    validasiManual();
                    break;
            }
        }

   }
}
