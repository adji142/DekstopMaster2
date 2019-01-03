using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;


namespace ISA.Toko.DO
{
    public partial class frmpilihbonusDO : ISA.Toko.BaseForm
    {
        string idToko, barangid;
        int SumqtyBarang, SumqtyKelompok, qtystokakhir, i, qtybonusfinal;
        DataTable dtsumKelipatanQtyBarang, dtsumKelipatanQtyKelompok, dtPromoTahunan;
        double SumHargaBarang, SumHargaKelompok;
        Guid rowidpromodetail;
        DataTable dt;

        public frmpilihbonusDO()
        {
            InitializeComponent();
        }

        public frmpilihbonusDO(Form caller, string TokoID, int sumqtybarang, double sumhargabarang, int sumqtykelompok, double sumhargakelompok, DataTable dtPromoBarangBonus, DataTable dtpromoKelompok, DataTable dtPromoTahun)
        {
            InitializeComponent();
            this.Caller = caller;
            idToko = TokoID;
            SumqtyBarang = sumqtybarang;
            SumHargaBarang = sumhargabarang;
            SumqtyKelompok = sumqtykelompok;
            SumHargaKelompok = sumhargakelompok;
            dtsumKelipatanQtyBarang = dtPromoBarangBonus;
            dtsumKelipatanQtyKelompok = dtpromoKelompok;
            dtPromoTahunan = dtPromoTahun;

        }

        public frmpilihbonusDO(Form caller)
        {
            this.Caller = caller;
        }

        private void frmpilihbonus_Load(object sender, EventArgs e)
        {
            DataPromoTetap(idToko);
            promobarang();
            PromoKelompok();
            PromoTahuanan();
            if (datagridviewpromokelompok.Rows.Count > 0)
            {
                DataGridViewCheckBoxCell checkrow = (DataGridViewCheckBoxCell)datagridviewpromokelompok.Rows[0].Cells["cek"];

                //memberi nilai awal pada checkbox

                if (checkrow.Value == null)
                {
                    checkrow.Value = true;
                }
                datagridviewpromokelompok.Invalidate();
            }
            
        }

        public void DataPromoTetap(string idToko)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_getPromoTetap"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, idToko));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "NamaToko";
                    datagridviewpromotetap.DataSource = dt.DefaultView;

                    //int i = 0;
                    if (datagridviewpromotetap.Rows.Count > 0)
                    {
                        if (datagridviewpromotetap.Rows[0].Cells["qtybonus2"].Value.ToString() == "0")
                        {
                            datagridviewpromotetap.Rows[0].Cells["qtybonus2"].Value = "1";
                        }
                    }
                    //i++;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void cekstok(string barangid)
        {
            try
            {
                
                using (Database db = new Database())
                {
                    

                    db.Commands.Add(db.CreateCommand("usp_cekStokGudang"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));

                    dt = db.Commands[0].ExecuteDataTable();

                    if (dt.Rows.Count == 0)
                    {
                        qtystokakhir = 0;
                    }
                    else
                    {
                        qtystokakhir = Convert.ToInt32(dt.Rows[0]["StokAkhirGudang"]);
                    }


                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void promobarang()
        {
            DataTable dtPromoBarang = Prolib.DataPromoBarangBonus(SumqtyBarang, SumHargaBarang);
            datagridviewBarangPromo.DataSource = dtPromoBarang.DefaultView;

            for (int i = 0; i < datagridviewBarangPromo.Rows.Count; ++i)
            {
                barangid = dtPromoBarang.Rows[i]["id_brg"].ToString();
                cekstok(barangid);
                int qtybonus = Convert.ToInt32(dtsumKelipatanQtyBarang.Rows[i]["qty_bns"]);


                if (qtybonus > qtystokakhir)
                {
                    qtybonusfinal = qtystokakhir;
                }
                else
                {
                    qtybonusfinal = qtybonus;
                }

                datagridviewBarangPromo.Rows[i].Cells["QtyBonus"].Value = qtybonusfinal;
            }
        }

        public void PromoKelompok()
        {
            DataTable dtPromoKelompok = Prolib.DataPromoKelompok(SumqtyKelompok, SumHargaKelompok);
            datagridviewpromokelompok.DataSource = dtPromoKelompok.DefaultView;

            for (int i = 0; i < datagridviewpromokelompok.Rows.Count; i++)
            {
                barangid = dtPromoKelompok.Rows[i]["id_brg"].ToString();
                cekstok(barangid);
                int qtybonus = Convert.ToInt32(dtsumKelipatanQtyKelompok.Rows[i]["qty_bns"]);

                if (qtybonus > qtystokakhir)
                {
                    qtybonusfinal = qtystokakhir;
                }
                else
                {
                    qtybonusfinal = qtybonus;
                }
                datagridviewpromokelompok.Rows[i].Cells["qtybunus1"].Value = qtybonusfinal;
            }
        }

        public void PromoTahuanan()
        {
            //DataTable dtPromoKelompok = Prolib.DataPromoKelompok(SumqtyKelompok, SumHargaKelompok);
            datagridviewpromotetap.DataSource = dtPromoTahunan.DefaultView;

            for (int i = 0; i < datagridviewpromotetap.Rows.Count; i++)
            {
                barangid = dtPromoTahunan.Rows[i]["id_brg"].ToString();
                cekstok(barangid);
                int qtybonus = Convert.ToInt32(dtPromoTahunan.Rows[i]["qty_bns"]);

                if (qtybonus > qtystokakhir)
                {
                    qtybonusfinal = qtystokakhir;
                }
                else
                {
                    qtybonusfinal = qtybonus;
                }
                datagridviewpromotetap.Rows[i].Cells["qtybonus2"].Value = qtybonusfinal;
            }
        }

        
        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datagridviewpromotetap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (datagridviewpromotetap.Columns[e.ColumnIndex].Name == "pilihTetap")
            {
                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)datagridviewpromotetap.
                    Rows[e.RowIndex].Cells["pilihTetap"];

                if (checkCell.Value == null)
                    checkCell.Value = false;
                switch (checkCell.Value.ToString())
                {
                    case "True":
                        checkCell.Value = false;
                        break;
                    case "False":
                        checkCell.Value = true;
                        break;
                }
                //MessageBox.Show(checkCell.Value.ToString());
            }*/
        }

        private void datagridviewBarangPromo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagridviewBarangPromo.IsCurrentCellDirty)
            {
                datagridviewBarangPromo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void datagridviewBarangPromo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //kalo ngga ada count di gridnya diya balik lagi
            if (e.RowIndex < 0)
            {

                return; 
            }
            int ix = e.RowIndex;
            if (ix >= 0)
            {

                DataGridViewCheckBoxCell checkrow =
                    (DataGridViewCheckBoxCell)datagridviewBarangPromo.Rows[ix].Cells["pilih"];
                
                //memberi nilai awal pada checkbox

                if (checkrow.Value == null)
                {
                    checkrow.Value = false;
                }
                switch (checkrow.Value.ToString())
                {
                    case "True":
                        checkrow.Value = false;
                        break;
                    case "False":
                        checkrow.Value = true;
                        break;
                }

                bool isChecked = (Boolean)checkrow.Value;
                if (isChecked)
                {
                    // mencentang checkbox yang dipilih trus yang lain di uncententang
                    for (int i = 0; i < datagridviewBarangPromo.Rows.Count; i++)
                    {
                        if (i != datagridviewBarangPromo.Rows.Count)
                        {
                            ((DataGridViewCheckBoxCell)datagridviewBarangPromo.Rows[i].Cells["pilih"]).Value = false;
                        }
                    }
                }
                datagridviewBarangPromo.Invalidate();
            }
        }

        private void datagridviewpromokelompok_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagridviewpromokelompok.IsCurrentCellDirty)
            {
                datagridviewpromokelompok.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void datagridviewpromokelompok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //kalo ngga ada count di gridnya diya balik lagi
            if (e.RowIndex < 0)
            {
                return;
            }
            int ix = e.RowIndex;
            if (ix >= 0)
            {

                DataGridViewCheckBoxCell checkrow =
                    (DataGridViewCheckBoxCell)datagridviewpromokelompok.Rows[ix].Cells["cek"];

                //memberi nilai awal pada checkbox

                if (checkrow.Value == null)
                {
                    checkrow.Value = false;
                }
                switch (checkrow.Value.ToString())
                {
                    case "True":
                        checkrow.Value = false;
                        break;
                    case "False":
                        checkrow.Value = true;
                        break;
                }

                bool isChecked = (Boolean)checkrow.Value;
                if (isChecked)
                {
                    // mencentang checkbox yang dipilih trus yang lain di uncententang
                    for (int i = 0; i < datagridviewpromokelompok.Rows.Count; i++)
                    {
                        if (i != datagridviewpromokelompok.Rows.Count)
                        {
                            ((DataGridViewCheckBoxCell)datagridviewpromokelompok.Rows[i].Cells["cek"]).Value = false;
                        }
                    }
                }
                datagridviewpromokelompok.Invalidate();
            }
        }

        private void cbSave_Click(object sender, EventArgs e)
        {

            if (this.Caller is FrmDO)
            {
                DO.FrmDO frmCaller = (DO.FrmDO)this.Caller;

                if (datagridviewBarangPromo.Rows.Count > 0)
                {
                    //DataTable<DataGridViewRow> rowschek = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in datagridviewBarangPromo.Rows)
                    {
                        i = datagridviewBarangPromo.Rows.Count;
                        //DataTable dt = new DataTable();
                        if (Convert.ToBoolean(row.Cells["pilih"].Value) == true && Convert.ToInt32(row.Cells["QtyBonus"].Value) > 0)
                        {
                            DataTable dtbarang = new DataTable();
                            dtbarang.Columns.Add("id_brg");
                            dtbarang.Columns.Add("nama_stok");
                            dtbarang.Columns.Add("qty_bns");
                            dtbarang.Columns.Add("satuan");
                            dtbarang.Columns.Add("h_jual");
                            dtbarang.Rows.Add(row.Cells["IDbarang"].Value, row.Cells["BarangP"].Value, row.Cells["QtyBonus"].Value, row.Cells["sat"].Value, row.Cells["h_jual"].Value);

                            if (!frmCaller.savepromo(dtbarang))
                                MessageBox.Show("Barang sudah ada.");

                        }
                    }
                }
                if (datagridviewpromokelompok.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in datagridviewpromokelompok.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["cek"].Value) == true && Convert.ToInt32(row.Cells["qtybunus1"].Value) > 0)
                        {
                            DataTable dtkelompok = new DataTable();
                            dtkelompok.Columns.Add("id_brg");
                            dtkelompok.Columns.Add("nama_stok");
                            dtkelompok.Columns.Add("qty_bns");
                            dtkelompok.Columns.Add("satuan");
                            dtkelompok.Columns.Add("h_jual");
                            dtkelompok.Rows.Add(row.Cells["kdbarang"].Value, row.Cells["NamaBarang"].Value, row.Cells["qtybunus1"].Value, row.Cells["stuan"].Value, row.Cells["hr_jual"].Value);

                            if (!frmCaller.savepromo(dtkelompok))
                                MessageBox.Show("Barang sudah ada.");
                        }
                        else
                        {
                            
                        }
                    }
                }

                if (datagridviewpromotetap.Rows.Count > 0)
                {
                    //datagridviewpromotetap.Rows[0].Cells[""].Value == asd;
                    foreach (DataGridViewRow row in datagridviewpromotetap.Rows)
                    {

                        DataTable dtetap = new DataTable();
                        dtetap.Columns.Add("id_brg");
                        dtetap.Columns.Add("nama_stok");
                        dtetap.Columns.Add("qty_bns");
                        dtetap.Columns.Add("satuan");
                        dtetap.Columns.Add("h_jual");
                        dtetap.Rows.Add(row.Cells["kd_brg"].Value, row.Cells["PromoTetap"].Value, row.Cells["QtyBonus2"].Value, row.Cells["Satuan"].Value, row.Cells["hrg_jual"].Value);
                        if (!frmCaller.savepromo(dtetap))
                            MessageBox.Show("Barang sudah ada.");



                        //jalankan fungsi untuk nambah ke datagridview
                        //frmCaller.savedonota;

                        //rowschek.Add(row);
                        //DataTable dt1 = rowschek;
                    }
                }
            }
            this.Close();
        }
            
                   
    }
}

